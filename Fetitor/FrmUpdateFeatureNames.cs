// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fetitor.Properties;

namespace Fetitor
{
	/// <summary>
	/// Provides a form to update the features.txt.
	/// </summary>
	public partial class FrmUpdateFeatureNames : Form
	{
		private readonly static string[] FileExtensions = new[] { ".xml", ".txt", ".data" };
		private readonly static string FeaturesListPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "features.txt");
		private readonly static Regex GfRegex = new Regex(@"(gf[a-zA-Z][\w\-]+)", RegexOptions.Compiled);
		private readonly static Regex FeatureStrRegex = new Regex(@"(feature[a-zA-Z][\w\-]+)", RegexOptions.Compiled);
		private readonly static Regex FeatureAttr1Regex = new Regex(@"feature\s*=\s*""([^""]+)""", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		private readonly static Regex FeatureAttr2Regex = new Regex(@"feature\s*=\s*&quot;([^&]+)&quot;", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		private bool _closing;

		/// <summary>
		/// Creates new instance.
		/// </summary>
		public FrmUpdateFeatureNames()
		{
			InitializeComponent();

			this.TxtFolders.Text = Settings.Default.NameSearchFolders;
			this.TxtFolders.SelectionStart = 0;
			this.BtnSave.Select();
		}

		/// <summary>
		/// Called when closing the form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmUpdateFeatureNames_FormClosing(object sender, FormClosingEventArgs e)
		{
			_closing = true;
			Settings.Default.NameSearchFolders = this.TxtFolders.Text;
		}

		/// <summary>
		/// Closes form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Saves the results to the features.txt
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSave_Click(object sender, EventArgs e)
		{
			this.BtnSave.Enabled = false;
			File.WriteAllText(FeaturesListPath, this.TxtResults.Text);
		}

		/// <summary>
		/// Starts search for feature names.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSearch_Click(object sender, EventArgs e)
		{
			var folderPaths = this.TxtFolders.Lines;
			var includeCurrent = this.ChkIncludeCurrent.Checked;

			this.BtnSearch.Enabled = false;
			this.BtnSave.Enabled = false;
			this.GrpFolders.Enabled = false;
			this.ProgressBar.Value = 0;

			Task.Run(() =>
			{
				var filePaths = this.FindFiles(folderPaths);
				if (includeCurrent)
					filePaths.Add(FeaturesListPath);

				if (_closing)
					return;

				var foundFeatures = this.SearchFeatures(filePaths);
				var features = new HashSet<string>();

				if (_closing)
					return;

				for (var i = 0; i < foundFeatures.Length; ++i)
				{
					var f = foundFeatures[i];

					var name = f.Trim();
					name = name.TrimStart('!');
					name = name.TrimStart('-');
					name = name.TrimEnd('-');
					features.Add(name);

					if (name.StartsWith("feature"))
						features.Add("gf" + name.Substring("feature".Length));
				}

				var sb = new StringBuilder();

				if (features.Any())
				{
					sb.AppendLine("// This file contains a number of strings that *could* be feature names.");
					sb.AppendLine("// The editor checks every line against the features and uses them as names");
					sb.AppendLine("// if they turn out to be valid.");
					sb.AppendLine("");
					foreach (var feature in features.OrderBy(a => a).Where(a => !string.IsNullOrWhiteSpace(a)))
						sb.AppendLine(feature);
				}
				else
				{
					sb.AppendLine("No feature names found.");
				}

				this.Invoke((MethodInvoker)delegate
				{
					this.TxtResults.Text = sb.ToString();
					this.BtnSearch.Enabled = true;
					this.GrpFolders.Enabled = true;
					this.ProgressBar.Value = this.ProgressBar.Maximum;

					if (features.Any())
						this.BtnSave.Enabled = true;

					var totalCount = features.Count;
					var newCount = (totalCount - FeaturesFile.FetureNameCount);

					if (newCount > 0)
						MessageBox.Show(this, $"Found {totalCount} potential feature names, {newCount} more than in the features.txt.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
					else if (newCount == 0)
						MessageBox.Show(this, $"Found {totalCount} potential feature names, no new ones were found.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
					else
						MessageBox.Show(this, $"Found {totalCount} potential feature names.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				});
			});
		}

		/// <summary>
		/// Returns list of files that may be searched for feature names,
		/// ignores folders that don't exist, but gives a warning about
		/// them.
		/// </summary>
		/// <param name="paths"></param>
		/// <returns></returns>
		private HashSet<string> FindFiles(string[] paths)
		{
			var result = new HashSet<string>();

			foreach (var path in paths)
			{
				if (_closing)
					return result;

				if (!Directory.Exists(path))
				{
					this.Invoke((MethodInvoker)delegate
					{
						MessageBox.Show(this, $"Directory '{path}' not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					});
					continue;
				}

				foreach (var filePath in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
				{
					if (_closing)
						return result;

					var ext = Path.GetExtension(filePath);
					if (!FileExtensions.Contains(ext))
						continue;

					result.Add(filePath);
				}
			}

			return result;
		}

		/// <summary>
		/// Searches for feature names in given files and returns them,
		/// ignores files that don't exist.
		/// </summary>
		/// <param name="filePaths"></param>
		/// <returns></returns>
		private string[] SearchFeatures(IEnumerable<string> filePaths)
		{
			var result = new HashSet<string>();

			this.Invoke((MethodInvoker)delegate
			{
				this.ProgressBar.Maximum = filePaths.Count();
			});

			Parallel.ForEach(filePaths, filePath =>
			{
				if (_closing)
					return;

				if (!File.Exists(filePath))
					return;

				var isFeatureList = (filePath == FeaturesListPath);

				using (var fr = new StreamReader(filePath))
				{
					string line = null;
					while ((line = fr.ReadLine()) != null)
					{
						if (_closing)
							return;

						if (!isFeatureList && line.StartsWith("// This file contains a number of strings that *could* be feature names."))
							isFeatureList = true;

						if (isFeatureList)
						{
							line = line.Trim();
							if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("//"))
							{
								lock (result)
									result.Add(line);
							}

							continue;
						}

						var matches = GfRegex.Matches(line);
						foreach (Match match in matches)
						{
							lock (result)
								result.Add(match.Groups[1].Value);
						}

						matches = FeatureStrRegex.Matches(line);
						foreach (Match match in matches)
						{
							lock (result)
								result.Add(match.Groups[1].Value);
						}

						matches = FeatureAttr1Regex.Matches(line);
						foreach (Match match in matches)
						{
							lock (result)
								result.Add(match.Groups[1].Value);
						}

						matches = FeatureAttr2Regex.Matches(line);
						foreach (Match match in matches)
						{
							lock (result)
								result.Add(match.Groups[1].Value);
						}
					}
				}

				if (_closing)
					return;

				try
				{
					this.Invoke((MethodInvoker)delegate
					{
						this.ProgressBar.Increment(1);
					});
				}
				catch (ObjectDisposedException)
				{
				}
			});

			result.RemoveWhere(a => a.Length > 40 || a.Any(b => b > 128));

			var multi = result.Where(a => a.Contains('|')).ToArray();
			foreach (var name in multi)
			{
				var split = name.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (var s in split)
					result.Add(s);

				result.Remove(name);
			}

			return result.ToArray();
		}

		/// <summary>
		/// Returns hash for the given string.
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static uint GetStringHash(string str)
		{
			var s = 5381;
			foreach (var ch in str)
				s = s * 33 + ch;
			return (uint)s;
		}
	}
}
