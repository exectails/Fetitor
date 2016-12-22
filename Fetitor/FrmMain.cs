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

using ScintillaNET;
using System;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Generic;

namespace Fetitor
{
	public partial class FrmMain : Form
	{
		private readonly string _windowTitle;
		private string _openedFilePath;
		private bool _fileChanged;
		private List<ListViewItem> _features = new List<ListViewItem>();

		/// <summary>
		/// Creates new instance.
		/// </summary>
		public FrmMain()
		{
			this.InitializeComponent();
			this.SetUpEditor();

			var featuresPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "features.txt");
			if (File.Exists(featuresPath))
				FeaturesFile.LoadFeatureNames(featuresPath);

			_windowTitle = Text;
			this.StatusBarLabel.Text = "";
			this.ToolStrip.Renderer = new MySR();

			this.UpdateSaveButtons();
		}

		/// <summary>
		/// Called when the form loads.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmMain_Load(object sender, EventArgs e)
		{
			var args = Environment.GetCommandLineArgs();
			if (args.Length > 1)
			{
				var filePath = args[1];
				this.OpenFile(filePath);
			}
		}

		/// <summary>
		/// Sets up the editor for XML code and subscribes to its events.
		/// </summary>
		public void SetUpEditor()
		{
			this.TxtEditor.Styles[Style.Default].Font = "Courier New";
			this.TxtEditor.Styles[Style.Default].Size = 10;
			this.TxtEditor.Styles[Style.Xml.XmlStart].ForeColor = Color.Blue;
			this.TxtEditor.Styles[Style.Xml.XmlEnd].ForeColor = Color.Blue;
			this.TxtEditor.Styles[Style.Xml.TagEnd].ForeColor = Color.Blue;
			this.TxtEditor.Styles[Style.Xml.Tag].ForeColor = Color.Blue;
			this.TxtEditor.Styles[Style.Xml.TagEnd].ForeColor = Color.Blue;
			this.TxtEditor.Styles[Style.Xml.Attribute].ForeColor = Color.Red;
			this.TxtEditor.Styles[Style.Xml.DoubleString].ForeColor = Color.Blue;
			this.TxtEditor.Styles[Style.Xml.SingleString].ForeColor = Color.Blue;
			this.TxtEditor.Margins[0].Width = 40;
			this.TxtEditor.Lexer = Lexer.Xml;
			this.TxtEditor.TextChanged += this.TxtEditor_OnTextChanged;
			this.TxtEditor.CtrlS += this.TxtEditor_OnCtrlS;
		}

		/// <summary>
		/// Called when text in the editor changes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtEditor_OnTextChanged(object sender, EventArgs e)
		{
			_fileChanged = true;

			this.UpdateUndo();
			this.UpdateSaveButtons();
		}

		/// <summary>
		/// Called when Ctrl+S is pressed in the editor.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtEditor_OnCtrlS(object sender, EventArgs e)
		{
			if (this.BtnSave.Enabled)
				this.BtnSave.PerformClick();
		}

		/// <summary>
		/// Updated Undo and Redo buttons, based on the editor's state.
		/// </summary>
		private void UpdateUndo()
		{
			this.BtnUndo.Enabled = this.TxtEditor.CanUndo;
			this.BtnRedo.Enabled = this.TxtEditor.CanRedo;
		}

		/// <summary>
		/// Resets Undo and Redo in the editor and updates the buttons.
		/// </summary>
		private void ResetUndo()
		{
			this.TxtEditor.EmptyUndoBuffer();
			this.UpdateUndo();
		}

		/// <summary>
		/// Toggles save buttons, based on whether saving is possible right
		/// now.
		/// </summary>
		private void UpdateSaveButtons()
		{
			var enabled = (_fileChanged && !string.IsNullOrWhiteSpace(_openedFilePath));
			this.MenuSave.Enabled = this.BtnSave.Enabled = enabled;

			var fileOpen = (_openedFilePath != null);
			this.MenuSaveAsXml.Enabled = fileOpen;
		}

		/// <summary>
		/// Updates feature name jump list.
		/// </summary>
		private void UpdateFeatureList()
		{
			var text = this.TxtEditor.Text;

			var index = text.IndexOf("<Features>");
			if (index == -1)
				return;

			var list = new List<ListViewItem>();

			while ((index = text.IndexOf("Name=", index)) != -1)
			{
				var nameStartIndex = index + "Name=\"".Length;
				var nameEndIndex = text.IndexOf("\"", nameStartIndex);
				var length = nameEndIndex - nameStartIndex;

				index = nameEndIndex;

				var name = text.Substring(nameStartIndex, length);
				if (name == "?")
					continue;

				var lvi = new ListViewItem(name);
				lvi.Tag = new Tuple<int, int>(nameStartIndex, nameEndIndex);

				list.Add(lvi);
			}

			_features = list;

			this.PopulateFeatureList(_features);
		}

		/// <summary>
		/// Called when feature list is double clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LstFeatures_DoubleClick(object sender, EventArgs e)
		{
			if (this.LstFeatures.SelectedItems.Count == 0)
				return;

			var selectedItem = this.LstFeatures.SelectedItems[0];
			if (selectedItem == null || selectedItem.Tag == null)
				return;

			var indices = selectedItem.Tag as Tuple<int, int>;
			if (indices == null)
				return;

			this.TxtEditor.SetSelection(indices.Item1, indices.Item2);
			this.TxtEditor.ScrollRange(indices.Item1, indices.Item2);
			this.TxtEditor.Focus();
		}

		/// <summary>
		/// Called when one of the Open buttons is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOpen_Click(object sender, EventArgs e)
		{
			var result = this.OpenFileDialog.ShowDialog();
			if (result != DialogResult.OK)
				return;

			this.OpenFile(OpenFileDialog.FileName);
		}

		/// <summary>
		/// Called if the Undo button is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnUndo_Click(object sender, EventArgs e)
		{
			this.TxtEditor.Undo();

			this.UpdateUndo();
			this.UpdateSaveButtons();
		}

		/// <summary>
		/// Called if the Redo button is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnRedo_Click(object sender, EventArgs e)
		{
			this.TxtEditor.Redo();

			this.UpdateUndo();
			this.UpdateSaveButtons();
		}

		/// <summary>
		/// Called if the Exit menu item is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MenuExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Called if a file is dragged onto the form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmMain_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
		}

		/// <summary>
		/// Called if a file is dropped on the form. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmMain_DragDrop(object sender, DragEventArgs e)
		{
			var files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length == 0)
				return;

			this.OpenFile(files[0]);
		}

		/// <summary>
		/// Tries to open compiled XML file at the given path in the editor.
		/// </summary>
		/// <param name="filePath"></param>
		private void OpenFile(string filePath)
		{
			// Check file's existence
			if (!File.Exists(filePath))
			{
				MessageBox.Show("File not found: " + filePath, _windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Check file extension
			if (!Path.GetFileName(filePath).EndsWith(".xml.compiled"))
			{
				MessageBox.Show("Unknown file type, expected: *.xml.compiled", _windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Read file
			try
			{
				string xml;
				using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
					xml = FeaturesFile.CompiledToXml(fs);

				this.TxtEditor.Text = xml;
				this.Text = _windowTitle + " - " + filePath;

				_openedFilePath = filePath;

				var known = Regex.Matches(xml, @"Name=""[^\?\""]+""").Count;
				var total = Regex.Matches(xml, @"Name=""").Count;
				this.StatusBarLabel.Text = string.Format("Known: {0}/{1}", known, total);

				_fileChanged = false;
				this.ResetUndo();
				this.UpdateSaveButtons();
				this.UpdateFeatureList();
			}
			catch (InvalidDataException)
			{
				MessageBox.Show("Invalid file format.", _windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (EndOfStreamException)
			{
				MessageBox.Show("Corrupted file.", _windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (NotSupportedException)
			{
				MessageBox.Show("Unsupported file.", _windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message, _windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Called if one of the Save buttons is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(_openedFilePath))
				return;

			try
			{
				this.SaveFile(_openedFilePath);

				_fileChanged = false;
				this.UpdateSaveButtons();
			}
			catch (XmlException ex)
			{
				MessageBox.Show("XML Error: " + ex.Message, _windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.ToString(), _windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Saves file to given path.
		/// </summary>
		/// <param name="filePath"></param>
		private void SaveFile(string filePath)
		{
			using (var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
				FeaturesFile.SaveXmlAsCompiled(TxtEditor.Text, fs);
		}

		/// <summary>
		/// Called if the Save as XML menu item is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MenuSaveAsXml_Click(object sender, EventArgs e)
		{
			this.SaveFileDialog.InitialDirectory = Path.GetDirectoryName(_openedFilePath);
			this.SaveFileDialog.FileName = "features.xml";

			if (this.SaveFileDialog.ShowDialog() != DialogResult.OK)
				return;

			try
			{
				using (var fs = this.SaveFileDialog.OpenFile())
				using (var sw = new StreamWriter(fs))
					sw.Write(this.TxtEditor.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.ToString(), _windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Called if the About menu item is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MenuAbout_Click(object sender, EventArgs e)
		{
			var form = new FrmAbout();
			form.ShowDialog();
		}

		/// <summary>
		/// Called if TxtFeatureFilter gets the focus.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtFeatureFilter_Enter(object sender, EventArgs e)
		{
			if (this.TxtFeatureFilter.ForeColor == Color.Silver)
			{
				this.TxtFeatureFilter.ForeColor = Color.Black;
				this.TxtFeatureFilter.Text = "";
			}
		}

		/// <summary>
		/// Called if TxtFeatureFilter loses the focus.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtFeatureFilter_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(this.TxtFeatureFilter.Text.Trim()))
			{
				this.TxtFeatureFilter.ForeColor = Color.Silver;
				this.TxtFeatureFilter.Text = "Filter";
				this.FilterFeatures("");
			}
		}

		/// <summary>
		/// Filters the feature list, only showing those that contain
		/// the given string.
		/// </summary>
		/// <param name="filter"></param>
		private void FilterFeatures(string filter)
		{
			this.PopulateFeatureList(_features.Where(a => a.Text.ToUpper().Contains(filter.ToUpper())));
		}

		/// <summary>
		/// Fills feature list with the given items.
		/// </summary>
		/// <param name="items"></param>
		private void PopulateFeatureList(IEnumerable<ListViewItem> items)
		{
			this.LstFeatures.BeginUpdate();
			this.LstFeatures.Items.Clear();

			// Add names alphabetically
			foreach (var item in items.OrderBy(a => a.Text))
				this.LstFeatures.Items.Add(item);

			// Autosize column header
			this.LstFeatures.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
			this.LstFeatures.Columns[0].Width -= 5;

			this.LstFeatures.EndUpdate();
		}

		/// <summary>
		/// Called if a key is let go of in TxtFeatureFilter.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtFeatureFilter_KeyUp(object sender, KeyEventArgs e)
		{
			var filter = this.TxtFeatureFilter.Text;
			this.FilterFeatures(filter);
		}
	}
}
