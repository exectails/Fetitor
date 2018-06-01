namespace Fetitor
{
	partial class FrmMain
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.MnuOpen = new System.Windows.Forms.MenuItem();
			this.MnuSave = new System.Windows.Forms.MenuItem();
			this.MnuSaveAsXml = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.MnuExit = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.MnuAbout = new System.Windows.Forms.MenuItem();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.LblCurLine = new System.Windows.Forms.ToolStripStatusLabel();
			this.LblCurCol = new System.Windows.Forms.ToolStripStatusLabel();
			this.LblKnownFeatureCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.ToolStrip = new System.Windows.Forms.ToolStrip();
			this.BtnOpen = new System.Windows.Forms.ToolStripButton();
			this.BtnSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.BtnUndo = new System.Windows.Forms.ToolStripButton();
			this.BtnRedo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.BtnSearch = new System.Windows.Forms.ToolStripButton();
			this.SplMain = new System.Windows.Forms.SplitContainer();
			this.TxtEditor = new Fetitor.MyScintilla();
			this.BtnClearFilter = new System.Windows.Forms.Button();
			this.LstFeatures = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.TxtFeatureFilter = new System.Windows.Forms.TextBox();
			this.BtnUpdateFeatureNames = new System.Windows.Forms.ToolStripButton();
			this.StatusStrip.SuspendLayout();
			this.ToolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SplMain)).BeginInit();
			this.SplMain.Panel1.SuspendLayout();
			this.SplMain.Panel2.SuspendLayout();
			this.SplMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MnuOpen,
            this.MnuSave,
            this.MnuSaveAsXml,
            this.menuItem5,
            this.MnuExit});
			this.menuItem1.Text = "&File";
			// 
			// MnuOpen
			// 
			this.MnuOpen.Index = 0;
			this.MnuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.MnuOpen.Text = "&Open";
			this.MnuOpen.Click += new System.EventHandler(this.BtnOpen_Click);
			// 
			// MnuSave
			// 
			this.MnuSave.Enabled = false;
			this.MnuSave.Index = 1;
			this.MnuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.MnuSave.Text = "&Save";
			this.MnuSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// MnuSaveAsXml
			// 
			this.MnuSaveAsXml.Enabled = false;
			this.MnuSaveAsXml.Index = 2;
			this.MnuSaveAsXml.Text = "Save as XML...";
			this.MnuSaveAsXml.Click += new System.EventHandler(this.MenuSaveAsXml_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "-";
			// 
			// MnuExit
			// 
			this.MnuExit.Index = 4;
			this.MnuExit.Text = "&Exit";
			this.MnuExit.Click += new System.EventHandler(this.MenuExit_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MnuAbout});
			this.menuItem2.Text = "?";
			// 
			// MnuAbout
			// 
			this.MnuAbout.Index = 0;
			this.MnuAbout.Text = "&About";
			this.MnuAbout.Click += new System.EventHandler(this.MenuAbout_Click);
			// 
			// OpenFileDialog
			// 
			this.OpenFileDialog.Filter = "Compiled XML file|*.xml.compiled";
			// 
			// SaveFileDialog
			// 
			this.SaveFileDialog.Filter = "XML file|*.xml";
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblCurLine,
            this.LblCurCol,
            this.LblKnownFeatureCount});
			this.StatusStrip.Location = new System.Drawing.Point(0, 617);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(1008, 24);
			this.StatusStrip.TabIndex = 3;
			this.StatusStrip.Text = "statusStrip1";
			// 
			// LblCurLine
			// 
			this.LblCurLine.AutoSize = false;
			this.LblCurLine.Name = "LblCurLine";
			this.LblCurLine.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
			this.LblCurLine.Size = new System.Drawing.Size(60, 19);
			this.LblCurLine.Text = "Line 0";
			this.LblCurLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblCurCol
			// 
			this.LblCurCol.AutoSize = false;
			this.LblCurCol.Name = "LblCurCol";
			this.LblCurCol.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
			this.LblCurCol.Size = new System.Drawing.Size(60, 19);
			this.LblCurCol.Text = "Col 0";
			this.LblCurCol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblKnownFeatureCount
			// 
			this.LblKnownFeatureCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
			this.LblKnownFeatureCount.Name = "LblKnownFeatureCount";
			this.LblKnownFeatureCount.Size = new System.Drawing.Size(126, 19);
			this.LblKnownFeatureCount.Text = "Known Feature Count";
			// 
			// ToolStrip
			// 
			this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnOpen,
            this.BtnSave,
            this.toolStripSeparator1,
            this.BtnUndo,
            this.BtnRedo,
            this.toolStripSeparator2,
            this.BtnSearch,
            this.BtnUpdateFeatureNames});
			this.ToolStrip.Location = new System.Drawing.Point(0, 0);
			this.ToolStrip.Name = "ToolStrip";
			this.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ToolStrip.Size = new System.Drawing.Size(1008, 25);
			this.ToolStrip.TabIndex = 2;
			this.ToolStrip.Text = "toolStrip1";
			// 
			// BtnOpen
			// 
			this.BtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("BtnOpen.Image")));
			this.BtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnOpen.Name = "BtnOpen";
			this.BtnOpen.Size = new System.Drawing.Size(23, 22);
			this.BtnOpen.Text = "Open";
			this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
			// 
			// BtnSave
			// 
			this.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnSave.Enabled = false;
			this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
			this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnSave.Name = "BtnSave";
			this.BtnSave.Size = new System.Drawing.Size(23, 22);
			this.BtnSave.Text = "Save";
			this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// BtnUndo
			// 
			this.BtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnUndo.Enabled = false;
			this.BtnUndo.Image = ((System.Drawing.Image)(resources.GetObject("BtnUndo.Image")));
			this.BtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnUndo.Name = "BtnUndo";
			this.BtnUndo.Size = new System.Drawing.Size(23, 22);
			this.BtnUndo.Text = "Undo";
			this.BtnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
			// 
			// BtnRedo
			// 
			this.BtnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnRedo.Enabled = false;
			this.BtnRedo.Image = ((System.Drawing.Image)(resources.GetObject("BtnRedo.Image")));
			this.BtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnRedo.Name = "BtnRedo";
			this.BtnRedo.Size = new System.Drawing.Size(23, 22);
			this.BtnRedo.Text = "Redo";
			this.BtnRedo.Click += new System.EventHandler(this.BtnRedo_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// BtnSearch
			// 
			this.BtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearch.Image")));
			this.BtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnSearch.Name = "BtnSearch";
			this.BtnSearch.Size = new System.Drawing.Size(23, 22);
			this.BtnSearch.Text = "Search";
			this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			// 
			// SplMain
			// 
			this.SplMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.SplMain.IsSplitterFixed = true;
			this.SplMain.Location = new System.Drawing.Point(0, 25);
			this.SplMain.Name = "SplMain";
			// 
			// SplMain.Panel1
			// 
			this.SplMain.Panel1.Controls.Add(this.TxtEditor);
			// 
			// SplMain.Panel2
			// 
			this.SplMain.Panel2.Controls.Add(this.BtnClearFilter);
			this.SplMain.Panel2.Controls.Add(this.LstFeatures);
			this.SplMain.Panel2.Controls.Add(this.TxtFeatureFilter);
			this.SplMain.Size = new System.Drawing.Size(1008, 592);
			this.SplMain.SplitterDistance = 730;
			this.SplMain.TabIndex = 4;
			// 
			// TxtEditor
			// 
			this.TxtEditor.AllowDrop = true;
			this.TxtEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TxtEditor.CaretLineBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
			this.TxtEditor.CaretLineVisible = true;
			this.TxtEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TxtEditor.HighlightGuide = 0;
			this.TxtEditor.IndentationGuides = ScintillaNET.IndentView.Real;
			this.TxtEditor.Location = new System.Drawing.Point(0, 0);
			this.TxtEditor.Name = "TxtEditor";
			this.TxtEditor.RectangularSelectionAnchor = 0;
			this.TxtEditor.RectangularSelectionAnchorVirtualSpace = 0;
			this.TxtEditor.RectangularSelectionCaret = 0;
			this.TxtEditor.RectangularSelectionCaretVirtualSpace = 0;
			this.TxtEditor.ScrollWidth = 100;
			this.TxtEditor.Size = new System.Drawing.Size(730, 592);
			this.TxtEditor.TabIndex = 1;
			// 
			// BtnClearFilter
			// 
			this.BtnClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnClearFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnClearFilter.Location = new System.Drawing.Point(255, 574);
			this.BtnClearFilter.Name = "BtnClearFilter";
			this.BtnClearFilter.Size = new System.Drawing.Size(18, 18);
			this.BtnClearFilter.TabIndex = 4;
			this.BtnClearFilter.Text = "X";
			this.BtnClearFilter.UseVisualStyleBackColor = true;
			this.BtnClearFilter.Click += new System.EventHandler(this.BtnClearFilter_Click);
			// 
			// LstFeatures
			// 
			this.LstFeatures.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LstFeatures.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.LstFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LstFeatures.FullRowSelect = true;
			this.LstFeatures.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.LstFeatures.HideSelection = false;
			this.LstFeatures.Location = new System.Drawing.Point(0, 0);
			this.LstFeatures.Name = "LstFeatures";
			this.LstFeatures.Size = new System.Drawing.Size(274, 572);
			this.LstFeatures.TabIndex = 2;
			this.LstFeatures.UseCompatibleStateImageBehavior = false;
			this.LstFeatures.View = System.Windows.Forms.View.Details;
			this.LstFeatures.DoubleClick += new System.EventHandler(this.LstFeatures_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 100;
			// 
			// TxtFeatureFilter
			// 
			this.TxtFeatureFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.TxtFeatureFilter.ForeColor = System.Drawing.Color.Silver;
			this.TxtFeatureFilter.Location = new System.Drawing.Point(0, 572);
			this.TxtFeatureFilter.Name = "TxtFeatureFilter";
			this.TxtFeatureFilter.Size = new System.Drawing.Size(274, 20);
			this.TxtFeatureFilter.TabIndex = 3;
			this.TxtFeatureFilter.Text = "Filter";
			this.TxtFeatureFilter.Enter += new System.EventHandler(this.TxtFeatureFilter_Enter);
			this.TxtFeatureFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtFeatureFilter_KeyUp);
			this.TxtFeatureFilter.Leave += new System.EventHandler(this.TxtFeatureFilter_Leave);
			// 
			// BtnUpdateFeatureNames
			// 
			this.BtnUpdateFeatureNames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnUpdateFeatureNames.Image = ((System.Drawing.Image)(resources.GetObject("BtnUpdateFeatureNames.Image")));
			this.BtnUpdateFeatureNames.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnUpdateFeatureNames.Name = "BtnUpdateFeatureNames";
			this.BtnUpdateFeatureNames.Size = new System.Drawing.Size(23, 22);
			this.BtnUpdateFeatureNames.Text = "Update Feature Names";
			this.BtnUpdateFeatureNames.Click += new System.EventHandler(this.BtnUpdateFeatureNames_Click);
			// 
			// FrmMain
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 641);
			this.Controls.Add(this.SplMain);
			this.Controls.Add(this.ToolStrip);
			this.Controls.Add(this.StatusStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.MainMenu;
			this.MinimumSize = new System.Drawing.Size(520, 240);
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Fetitor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragEnter);
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.ToolStrip.ResumeLayout(false);
			this.ToolStrip.PerformLayout();
			this.SplMain.Panel1.ResumeLayout(false);
			this.SplMain.Panel2.ResumeLayout(false);
			this.SplMain.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SplMain)).EndInit();
			this.SplMain.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip ToolStrip;
		private System.Windows.Forms.ToolStripButton BtnOpen;
		private System.Windows.Forms.MainMenu MainMenu;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.ToolStripButton BtnSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton BtnUndo;
		private System.Windows.Forms.ToolStripButton BtnRedo;
		private System.Windows.Forms.MenuItem MnuOpen;
		private System.Windows.Forms.MenuItem MnuSave;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem MnuExit;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem MnuAbout;
		private System.Windows.Forms.OpenFileDialog OpenFileDialog;
		private System.Windows.Forms.SaveFileDialog SaveFileDialog;
		private System.Windows.Forms.StatusStrip StatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel LblKnownFeatureCount;
		private System.Windows.Forms.SplitContainer SplMain;
		private MyScintilla TxtEditor;
		private System.Windows.Forms.MenuItem MnuSaveAsXml;
		private System.Windows.Forms.ListView LstFeatures;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.TextBox TxtFeatureFilter;
		private System.Windows.Forms.ToolStripStatusLabel LblCurCol;
		private System.Windows.Forms.ToolStripStatusLabel LblCurLine;
		private System.Windows.Forms.Button BtnClearFilter;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton BtnSearch;
		private System.Windows.Forms.ToolStripButton BtnUpdateFeatureNames;
	}
}

