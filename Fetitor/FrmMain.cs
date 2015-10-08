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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace Fetitor
{
	public partial class FrmMain : Form
	{
		private readonly string windowTitle;
		private string openedFilePath;
		private bool fileChanged;

		public FrmMain()
		{
			InitializeComponent();
			SetUpEditor();

			if (File.Exists("features.txt"))
				FeaturesFile.LoadFeatureNames("features.txt");

			windowTitle = Text;
			StatusBarLabel.Text = "";
			DisableSaving();
		}

		public void SetUpEditor()
		{
			editor.Styles[Style.Default].Font = "Courier New";
			editor.Styles[Style.Default].Size = 10;
			editor.Styles[Style.Xml.XmlStart].ForeColor = Color.Blue;
			editor.Styles[Style.Xml.XmlEnd].ForeColor = Color.Blue;
			editor.Styles[Style.Xml.TagEnd].ForeColor = Color.Blue;
			editor.Styles[Style.Xml.Tag].ForeColor = Color.Blue;
			editor.Styles[Style.Xml.TagEnd].ForeColor = Color.Blue;
			editor.Styles[Style.Xml.Attribute].ForeColor = Color.Red;
			editor.Styles[Style.Xml.DoubleString].ForeColor = Color.Blue;
			editor.Styles[Style.Xml.SingleString].ForeColor = Color.Blue;
			editor.Margins[0].Width = 40;
			editor.Lexer = Lexer.Xml;
			editor.TextChanged += OnTextChanged;
		}

		private void OnTextChanged(object sender, EventArgs e)
		{
			UpdateUndo();

			fileChanged = true;
			EnableSaving();
		}

		private void UpdateUndo()
		{
			BtnUndo.Enabled = editor.CanUndo;
			BtnRedo.Enabled = editor.CanRedo;
		}

		private void ResetUndo()
		{
			editor.EmptyUndoBuffer();
			BtnUndo.Enabled = BtnRedo.Enabled = false;
		}

		private void EnableSaving()
		{
			MenuSave.Enabled = true;
			BtnSave.Enabled = true;
		}

		private void DisableSaving()
		{
			MenuSave.Enabled = false;
			BtnSave.Enabled = false;
		}

		private void BtnOpen_Click(object sender, EventArgs e)
		{
			//OpenFile(@"D:\Mabinogi\mabinogi-data\na\features.xml.compiled");
			//OpenFile(@"E:\save\mabi\cn_mabinogi_setup_171\package\data\features.xml.compiled");

			var result = OpenFileDialog.ShowDialog();
			if (result != DialogResult.OK)
				return;

			OpenFile(OpenFileDialog.FileName);
		}

		private void BtnUndo_Click(object sender, EventArgs e)
		{
			editor.Undo();
		}

		private void BtnRedo_Click(object sender, EventArgs e)
		{
			editor.Redo();
		}

		private void MenuExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void FrmMain_DragDrop(object sender, DragEventArgs e)
		{
			var files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length == 0)
				return;

			OpenFile(files[0]);
		}

		private void FrmMain_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;

			Console.WriteLine("test");
		}

		private void OpenFile(string filePath)
		{
			// Check file's existence
			if (!File.Exists(filePath))
			{
				MessageBox.Show("File not found: " + filePath, windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Check file extension
			if (!Path.GetFileName(filePath).EndsWith(".xml.compiled"))
			{
				MessageBox.Show("Unknown file type, expected: *.xml.compiled", windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Read file
			try
			{
				string xml;
				using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
					xml = FeaturesFile.CompiledToXml(fs);

				editor.Text = xml;

				Text = windowTitle + " - " + filePath;

				openedFilePath = filePath;

				var known = Regex.Matches(xml, @"Name=""[^\?\""]+""").Count;
				var total = Regex.Matches(xml, @"Name=""").Count;
				StatusBarLabel.Text = string.Format("Known: {0}/{1}", known, total);

				ResetUndo();

				fileChanged = false;
				DisableSaving();
			}
			catch (InvalidDataException)
			{
				MessageBox.Show("Invalid file format.", windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (EndOfStreamException)
			{
				MessageBox.Show("Corrupted file.", windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (NotSupportedException)
			{
				MessageBox.Show("Unsupported file.", windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message, windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(openedFilePath))
				return;

			//var result = SaveFileDialog.ShowDialog();
			//if (result != DialogResult.OK)
			//	return;

			SaveFile(openedFilePath);
		}

		private void SaveFile(string filePath)
		{
			try
			{
				using (var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
					FeaturesFile.SaveXmlAsCompiled(editor.Text, fs);

				fileChanged = false;
				DisableSaving();
			}
			catch (XmlException ex)
			{
				MessageBox.Show("XML Error: " + ex.Message, windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.ToString(), windowTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
