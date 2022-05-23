namespace Fetitor
{
	partial class FrmAbout
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
			this.PnlHeader = new System.Windows.Forms.Panel();
			this.LblVersion = new System.Windows.Forms.Label();
			this.ImgIcon = new System.Windows.Forms.PictureBox();
			this.LblName = new System.Windows.Forms.Label();
			this.BtnOK = new System.Windows.Forms.Button();
			this.ImgGitHub = new System.Windows.Forms.PictureBox();
			this.ImgPatreon = new System.Windows.Forms.PictureBox();
			this.GrpScintilla = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.GrpLicense = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.PnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImgIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ImgGitHub)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ImgPatreon)).BeginInit();
			this.GrpScintilla.SuspendLayout();
			this.GrpLicense.SuspendLayout();
			this.SuspendLayout();
			// 
			// PnlHeader
			// 
			this.PnlHeader.BackColor = System.Drawing.Color.White;
			this.PnlHeader.Controls.Add(this.LblVersion);
			this.PnlHeader.Controls.Add(this.ImgIcon);
			this.PnlHeader.Controls.Add(this.LblName);
			this.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.PnlHeader.Location = new System.Drawing.Point(0, 0);
			this.PnlHeader.Name = "PnlHeader";
			this.PnlHeader.Size = new System.Drawing.Size(483, 58);
			this.PnlHeader.TabIndex = 18;
			// 
			// LblVersion
			// 
			this.LblVersion.AutoSize = true;
			this.LblVersion.ForeColor = System.Drawing.Color.Gray;
			this.LblVersion.Location = new System.Drawing.Point(136, 28);
			this.LblVersion.Name = "LblVersion";
			this.LblVersion.Size = new System.Drawing.Size(37, 13);
			this.LblVersion.TabIndex = 17;
			this.LblVersion.Text = "v1.2.7";
			// 
			// ImgIcon
			// 
			this.ImgIcon.Image = ((System.Drawing.Image)(resources.GetObject("ImgIcon.Image")));
			this.ImgIcon.Location = new System.Drawing.Point(12, 12);
			this.ImgIcon.Name = "ImgIcon";
			this.ImgIcon.Size = new System.Drawing.Size(32, 32);
			this.ImgIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.ImgIcon.TabIndex = 16;
			this.ImgIcon.TabStop = false;
			// 
			// LblName
			// 
			this.LblName.AutoSize = true;
			this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.LblName.Location = new System.Drawing.Point(50, 13);
			this.LblName.Name = "LblName";
			this.LblName.Size = new System.Drawing.Size(92, 31);
			this.LblName.TabIndex = 15;
			this.LblName.Text = "Fetitor";
			// 
			// BtnOK
			// 
			this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnOK.Location = new System.Drawing.Point(398, 518);
			this.BtnOK.Name = "BtnOK";
			this.BtnOK.Size = new System.Drawing.Size(75, 23);
			this.BtnOK.TabIndex = 1;
			this.BtnOK.Text = "OK";
			this.BtnOK.UseVisualStyleBackColor = true;
			this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
			// 
			// ImgGitHub
			// 
			this.ImgGitHub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ImgGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ImgGitHub.Image = ((System.Drawing.Image)(resources.GetObject("ImgGitHub.Image")));
			this.ImgGitHub.Location = new System.Drawing.Point(207, 509);
			this.ImgGitHub.Name = "ImgGitHub";
			this.ImgGitHub.Size = new System.Drawing.Size(32, 32);
			this.ImgGitHub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.ImgGitHub.TabIndex = 19;
			this.ImgGitHub.TabStop = false;
			this.ImgGitHub.Tag = "https://github.com/exectails";
			this.ToolTip.SetToolTip(this.ImgGitHub, "https://github.com/exectails");
			this.ImgGitHub.Click += new System.EventHandler(this.LinkImage_Click);
			// 
			// ImgPatreon
			// 
			this.ImgPatreon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ImgPatreon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ImgPatreon.Image = ((System.Drawing.Image)(resources.GetObject("ImgPatreon.Image")));
			this.ImgPatreon.Location = new System.Drawing.Point(12, 509);
			this.ImgPatreon.Name = "ImgPatreon";
			this.ImgPatreon.Size = new System.Drawing.Size(189, 32);
			this.ImgPatreon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.ImgPatreon.TabIndex = 20;
			this.ImgPatreon.TabStop = false;
			this.ImgPatreon.Tag = "https://www.patreon.com/exectails";
			this.ToolTip.SetToolTip(this.ImgPatreon, "https://www.patreon.com/exectails");
			this.ImgPatreon.Click += new System.EventHandler(this.LinkImage_Click);
			// 
			// GrpScintilla
			// 
			this.GrpScintilla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GrpScintilla.BackColor = System.Drawing.SystemColors.Control;
			this.GrpScintilla.Controls.Add(this.textBox2);
			this.GrpScintilla.Location = new System.Drawing.Point(14, 229);
			this.GrpScintilla.Name = "GrpScintilla";
			this.GrpScintilla.Size = new System.Drawing.Size(459, 272);
			this.GrpScintilla.TabIndex = 22;
			this.GrpScintilla.TabStop = false;
			this.GrpScintilla.Text = "ScintillaNET License";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.BackColor = System.Drawing.SystemColors.Control;
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox2.Location = new System.Drawing.Point(8, 19);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(443, 247);
			this.textBox2.TabIndex = 3;
			this.textBox2.TabStop = false;
			this.textBox2.Text = resources.GetString("textBox2.Text");
			// 
			// GrpLicense
			// 
			this.GrpLicense.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GrpLicense.BackColor = System.Drawing.SystemColors.Control;
			this.GrpLicense.Controls.Add(this.textBox1);
			this.GrpLicense.Location = new System.Drawing.Point(12, 64);
			this.GrpLicense.Name = "GrpLicense";
			this.GrpLicense.Size = new System.Drawing.Size(459, 159);
			this.GrpLicense.TabIndex = 21;
			this.GrpLicense.TabStop = false;
			this.GrpLicense.Text = "License";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.BackColor = System.Drawing.SystemColors.Control;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Location = new System.Drawing.Point(8, 19);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(443, 134);
			this.textBox1.TabIndex = 3;
			this.textBox1.TabStop = false;
			this.textBox1.Text = resources.GetString("textBox1.Text");
			// 
			// FrmAbout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(483, 553);
			this.Controls.Add(this.GrpScintilla);
			this.Controls.Add(this.GrpLicense);
			this.Controls.Add(this.ImgPatreon);
			this.Controls.Add(this.ImgGitHub);
			this.Controls.Add(this.BtnOK);
			this.Controls.Add(this.PnlHeader);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmAbout";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			this.PnlHeader.ResumeLayout(false);
			this.PnlHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImgIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ImgGitHub)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ImgPatreon)).EndInit();
			this.GrpScintilla.ResumeLayout(false);
			this.GrpScintilla.PerformLayout();
			this.GrpLicense.ResumeLayout(false);
			this.GrpLicense.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Panel PnlHeader;
		private System.Windows.Forms.Label LblVersion;
		private System.Windows.Forms.PictureBox ImgIcon;
		private System.Windows.Forms.Label LblName;
		private System.Windows.Forms.Button BtnOK;
		private System.Windows.Forms.PictureBox ImgGitHub;
		private System.Windows.Forms.PictureBox ImgPatreon;
		private System.Windows.Forms.GroupBox GrpScintilla;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.GroupBox GrpLicense;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ToolTip ToolTip;
	}
}