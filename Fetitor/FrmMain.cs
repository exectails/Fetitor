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
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace Fetitor
{
	public partial class FrmMain : Form
	{
		private readonly string _windowTitle;
		private string _openedFilePath;
		private bool _fileChanged;

		public FrmMain()
		{
			this.InitializeComponent();
			this.SetUpEditor();

			if (File.Exists("features.txt"))
				FeaturesFile.LoadFeatureNames("features.txt");

			_windowTitle = Text;
			this.StatusBarLabel.Text = "";
			this.ToolStrip.Renderer = new MySR();

			this.UpdateSaveButton();
		}

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
			this.TxtEditor.TextChanged += this.OnTextChanged;
		}

		private void OnTextChanged(object sender, EventArgs e)
		{
			_fileChanged = true;

			this.UpdateUndo();
			this.UpdateSaveButton();
		}

		private void UpdateUndo()
		{
			this.BtnUndo.Enabled = this.TxtEditor.CanUndo;
			this.BtnRedo.Enabled = this.TxtEditor.CanRedo;
		}

		private void ResetUndo()
		{
			this.TxtEditor.EmptyUndoBuffer();
			this.BtnUndo.Enabled = this.BtnRedo.Enabled = false;
		}

		private void UpdateSaveButton()
		{
			var enabled = (_fileChanged && !string.IsNullOrWhiteSpace(_openedFilePath));
			this.MenuSave.Enabled = this.BtnSave.Enabled = enabled;
		}

		private void BtnOpen_Click(object sender, EventArgs e)
		{
			var result = this.OpenFileDialog.ShowDialog();
			if (result != DialogResult.OK)
				return;

			this.OpenFile(OpenFileDialog.FileName);
		}

		private void BtnUndo_Click(object sender, EventArgs e)
		{
			this.TxtEditor.Undo();

			this.UpdateUndo();
			this.UpdateSaveButton();
		}

		private void BtnRedo_Click(object sender, EventArgs e)
		{
			this.TxtEditor.Redo();

			this.UpdateUndo();
			this.UpdateSaveButton();
		}

		private void MenuExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void FrmMain_DragDrop(object sender, DragEventArgs e)
		{
			var files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length == 0)
				return;

			this.OpenFile(files[0]);
		}

		private void FrmMain_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
		}

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
				this.UpdateSaveButton();
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

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(_openedFilePath))
				return;

			try
			{
				this.SaveFile(_openedFilePath);

				_fileChanged = false;
				this.UpdateSaveButton();
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

		private void SaveFile(string filePath)
		{
			using (var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
				FeaturesFile.SaveXmlAsCompiled(TxtEditor.Text, fs);
		}
	}
}
