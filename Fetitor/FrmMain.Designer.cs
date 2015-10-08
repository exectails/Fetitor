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
			this.editor = new Fetitor.MyScintilla();
			this.ToolStrip = new System.Windows.Forms.ToolStrip();
			this.BtnOpen = new System.Windows.Forms.ToolStripButton();
			this.BtnSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.BtnUndo = new System.Windows.Forms.ToolStripButton();
			this.BtnRedo = new System.Windows.Forms.ToolStripButton();
			this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.MenuOpen = new System.Windows.Forms.MenuItem();
			this.MenuSave = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.MenuExit = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.StatusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ToolStrip.SuspendLayout();
			this.StatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// editor
			// 
			this.editor.AllowDrop = true;
			this.editor.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editor.HighlightGuide = 0;
			this.editor.IndentationGuides = ScintillaNET.IndentView.Real;
			this.editor.Location = new System.Drawing.Point(0, 25);
			this.editor.Name = "editor";
			this.editor.RectangularSelectionAnchor = 0;
			this.editor.RectangularSelectionAnchorVirtualSpace = 0;
			this.editor.RectangularSelectionCaret = 0;
			this.editor.RectangularSelectionCaretVirtualSpace = 0;
			this.editor.ScrollWidth = 100;
			this.editor.Size = new System.Drawing.Size(1008, 662);
			this.editor.TabIndex = 0;
			this.editor.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragDrop);
			this.editor.DragEnter += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragEnter);
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
            this.menuItem5,
            this.MenuExit});
			this.menuItem1.Text = "&File";
			// 
			// MenuOpen
			// 
			this.MenuOpen.Index = 0;
			this.MenuOpen.Text = "&Open";
			this.MenuOpen.Click += new System.EventHandler(this.BtnOpen_Click);
			// 
			// MenuSave
			// 
			this.MenuSave.Enabled = false;
			this.MenuSave.Index = 1;
			this.MenuSave.Text = "&Save";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 2;
			this.menuItem5.Text = "-";
			// 
			// MenuExit
			// 
			this.MenuExit.Index = 3;
			this.MenuExit.Text = "&Exit";
			this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem3});
			this.menuItem2.Text = "?";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.Text = "&About";
			// 
			// OpenFileDialog
			// 
			this.OpenFileDialog.Filter = "Compiled XML file|*.xml.compiled";
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 687);
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
			// FrmMain
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 709);
			this.Controls.Add(this.editor);
			this.Controls.Add(this.ToolStrip);
			this.Controls.Add(this.StatusStrip);
			this.Menu = this.MainMenu;
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Fetitor";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragEnter);
			this.ToolStrip.ResumeLayout(false);
			this.ToolStrip.PerformLayout();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MyScintilla editor;
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
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.OpenFileDialog OpenFileDialog;
		private System.Windows.Forms.SaveFileDialog SaveFileDialog;
		private System.Windows.Forms.StatusStrip StatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel StatusBarLabel;
	}
}

