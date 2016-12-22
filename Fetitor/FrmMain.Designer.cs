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
			this.MenuOpen = new System.Windows.Forms.MenuItem();
			this.MenuSave = new System.Windows.Forms.MenuItem();
			this.MenuSaveAsXml = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.MenuExit = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.MenuAbout = new System.Windows.Forms.MenuItem();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.StatusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ToolStrip = new System.Windows.Forms.ToolStrip();
			this.BtnOpen = new System.Windows.Forms.ToolStripButton();
			this.BtnSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.BtnUndo = new System.Windows.Forms.ToolStripButton();
			this.BtnRedo = new System.Windows.Forms.ToolStripButton();
			this.SplMain = new System.Windows.Forms.SplitContainer();
			this.TxtEditor = new Fetitor.MyScintilla();
			this.LstFeatures = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.TxtFeatureFilter = new System.Windows.Forms.TextBox();
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
            this.MenuOpen,
            this.MenuSave,
            this.MenuSaveAsXml,
            this.menuItem5,
            this.MenuExit});
			this.menuItem1.Text = "&File";
			// 
			// MenuOpen
			// 
			this.MenuOpen.Index = 0;
			this.MenuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.MenuOpen.Text = "&Open";
			this.MenuOpen.Click += new System.EventHandler(this.BtnOpen_Click);
			// 
			// MenuSave
			// 
			this.MenuSave.Enabled = false;
			this.MenuSave.Index = 1;
			this.MenuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.MenuSave.Text = "&Save";
			// 
			// MenuSaveAsXml
			// 
			this.MenuSaveAsXml.Enabled = false;
			this.MenuSaveAsXml.Index = 2;
			this.MenuSaveAsXml.Text = "Save as XML...";
			this.MenuSaveAsXml.Click += new System.EventHandler(this.MenuSaveAsXml_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "-";
			// 
			// MenuExit
			// 
			this.MenuExit.Index = 4;
			this.MenuExit.Text = "&Exit";
			this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuAbout});
			this.menuItem2.Text = "?";
			// 
			// MenuAbout
			// 
			this.MenuAbout.Index = 0;
			this.MenuAbout.Text = "&About";
			this.MenuAbout.Click += new System.EventHandler(this.MenuAbout_Click);
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
            this.StatusBarLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 619);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(1008, 22);
			this.StatusStrip.TabIndex = 3;
			this.StatusStrip.Text = "statusStrip1";
			// 
			// StatusBarLabel
			// 
			this.StatusBarLabel.Name = "StatusBarLabel";
			this.StatusBarLabel.Size = new System.Drawing.Size(59, 17);
			this.StatusBarLabel.Text = "Status bar";
			// 
			// ToolStrip
			// 
			this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnOpen,
            this.BtnSave,
            this.toolStripSeparator1,
            this.BtnUndo,
            this.BtnRedo});
			this.ToolStrip.Location = new System.Drawing.Point(0, 0);
			this.ToolStrip.Name = "ToolStrip";
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
			this.SplMain.Panel2.Controls.Add(this.LstFeatures);
			this.SplMain.Panel2.Controls.Add(this.TxtFeatureFilter);
			this.SplMain.Size = new System.Drawing.Size(1008, 594);
			this.SplMain.SplitterDistance = 750;
			this.SplMain.TabIndex = 4;
			// 
			// TxtEditor
			// 
			this.TxtEditor.AllowDrop = true;
			this.TxtEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
			this.TxtEditor.Size = new System.Drawing.Size(750, 594);
			this.TxtEditor.TabIndex = 1;
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
			this.LstFeatures.Size = new System.Drawing.Size(254, 574);
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
			this.TxtFeatureFilter.Location = new System.Drawing.Point(0, 574);
			this.TxtFeatureFilter.Name = "TxtFeatureFilter";
			this.TxtFeatureFilter.Size = new System.Drawing.Size(254, 20);
			this.TxtFeatureFilter.TabIndex = 3;
			this.TxtFeatureFilter.Text = "Filter";
			this.TxtFeatureFilter.Enter += new System.EventHandler(this.TxtFeatureFilter_Enter);
			this.TxtFeatureFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtFeatureFilter_KeyUp);
			this.TxtFeatureFilter.Leave += new System.EventHandler(this.TxtFeatureFilter_Leave);
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
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Fetitor";
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
		private System.Windows.Forms.MenuItem MenuOpen;
		private System.Windows.Forms.MenuItem MenuSave;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem MenuExit;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem MenuAbout;
		private System.Windows.Forms.OpenFileDialog OpenFileDialog;
		private System.Windows.Forms.SaveFileDialog SaveFileDialog;
		private System.Windows.Forms.StatusStrip StatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel StatusBarLabel;
		private System.Windows.Forms.SplitContainer SplMain;
		private MyScintilla TxtEditor;
		private System.Windows.Forms.MenuItem MenuSaveAsXml;
		private System.Windows.Forms.ListView LstFeatures;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.TextBox TxtFeatureFilter;
	}
}

