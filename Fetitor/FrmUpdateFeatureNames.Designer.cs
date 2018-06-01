namespace Fetitor
{
	partial class FrmUpdateFeatureNames
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpdateFeatureNames));
			this.LblHelp = new System.Windows.Forms.Label();
			this.GrpFolders = new System.Windows.Forms.GroupBox();
			this.ChkIncludeCurrent = new System.Windows.Forms.CheckBox();
			this.TxtFolders = new System.Windows.Forms.TextBox();
			this.GrpResults = new System.Windows.Forms.GroupBox();
			this.TxtResults = new System.Windows.Forms.TextBox();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.BtnSave = new System.Windows.Forms.Button();
			this.BtnClose = new System.Windows.Forms.Button();
			this.BtnSearch = new System.Windows.Forms.Button();
			this.GrpFolders.SuspendLayout();
			this.GrpResults.SuspendLayout();
			this.SuspendLayout();
			// 
			// LblHelp
			// 
			this.LblHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.LblHelp.ForeColor = System.Drawing.Color.Gray;
			this.LblHelp.Location = new System.Drawing.Point(9, 407);
			this.LblHelp.Name = "LblHelp";
			this.LblHelp.Size = new System.Drawing.Size(516, 48);
			this.LblHelp.TabIndex = 0;
			this.LblHelp.Text = resources.GetString("LblHelp.Text");
			// 
			// GrpFolders
			// 
			this.GrpFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.GrpFolders.Controls.Add(this.ChkIncludeCurrent);
			this.GrpFolders.Controls.Add(this.TxtFolders);
			this.GrpFolders.Location = new System.Drawing.Point(12, 12);
			this.GrpFolders.Name = "GrpFolders";
			this.GrpFolders.Size = new System.Drawing.Size(513, 185);
			this.GrpFolders.TabIndex = 3;
			this.GrpFolders.TabStop = false;
			this.GrpFolders.Text = "Directories";
			// 
			// ChkIncludeCurrent
			// 
			this.ChkIncludeCurrent.AutoSize = true;
			this.ChkIncludeCurrent.Checked = true;
			this.ChkIncludeCurrent.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkIncludeCurrent.Location = new System.Drawing.Point(11, 161);
			this.ChkIncludeCurrent.Name = "ChkIncludeCurrent";
			this.ChkIncludeCurrent.Size = new System.Drawing.Size(204, 17);
			this.ChkIncludeCurrent.TabIndex = 5;
			this.ChkIncludeCurrent.Text = "Include features in current features.txt";
			this.ChkIncludeCurrent.UseVisualStyleBackColor = true;
			// 
			// TxtFolders
			// 
			this.TxtFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.TxtFolders.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtFolders.Location = new System.Drawing.Point(11, 19);
			this.TxtFolders.Multiline = true;
			this.TxtFolders.Name = "TxtFolders";
			this.TxtFolders.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TxtFolders.Size = new System.Drawing.Size(491, 136);
			this.TxtFolders.TabIndex = 4;
			this.TxtFolders.WordWrap = false;
			// 
			// GrpResults
			// 
			this.GrpResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.GrpResults.Controls.Add(this.TxtResults);
			this.GrpResults.Location = new System.Drawing.Point(12, 203);
			this.GrpResults.Name = "GrpResults";
			this.GrpResults.Size = new System.Drawing.Size(513, 158);
			this.GrpResults.TabIndex = 4;
			this.GrpResults.TabStop = false;
			this.GrpResults.Text = "Results";
			// 
			// TxtResults
			// 
			this.TxtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.TxtResults.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtResults.Location = new System.Drawing.Point(11, 19);
			this.TxtResults.Multiline = true;
			this.TxtResults.Name = "TxtResults";
			this.TxtResults.ReadOnly = true;
			this.TxtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TxtResults.Size = new System.Drawing.Size(491, 128);
			this.TxtResults.TabIndex = 6;
			this.TxtResults.WordWrap = false;
			// 
			// ProgressBar
			// 
			this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.ProgressBar.Location = new System.Drawing.Point(12, 370);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(270, 23);
			this.ProgressBar.TabIndex = 5;
			// 
			// BtnSave
			// 
			this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnSave.Enabled = false;
			this.BtnSave.Location = new System.Drawing.Point(369, 370);
			this.BtnSave.Name = "BtnSave";
			this.BtnSave.Size = new System.Drawing.Size(75, 23);
			this.BtnSave.TabIndex = 2;
			this.BtnSave.Text = "Save";
			this.BtnSave.UseVisualStyleBackColor = true;
			this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// BtnClose
			// 
			this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnClose.Location = new System.Drawing.Point(450, 370);
			this.BtnClose.Name = "BtnClose";
			this.BtnClose.Size = new System.Drawing.Size(75, 23);
			this.BtnClose.TabIndex = 3;
			this.BtnClose.Text = "Close";
			this.BtnClose.UseVisualStyleBackColor = true;
			this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// BtnSearch
			// 
			this.BtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnSearch.Location = new System.Drawing.Point(288, 370);
			this.BtnSearch.Name = "BtnSearch";
			this.BtnSearch.Size = new System.Drawing.Size(75, 23);
			this.BtnSearch.TabIndex = 1;
			this.BtnSearch.Text = "Search";
			this.BtnSearch.UseVisualStyleBackColor = true;
			this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			// 
			// FrmUpdateFeatureNames
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(537, 464);
			this.Controls.Add(this.BtnSearch);
			this.Controls.Add(this.BtnClose);
			this.Controls.Add(this.BtnSave);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.GrpResults);
			this.Controls.Add(this.GrpFolders);
			this.Controls.Add(this.LblHelp);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmUpdateFeatureNames";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Search Feature Names";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUpdateFeatureNames_FormClosing);
			this.GrpFolders.ResumeLayout(false);
			this.GrpFolders.PerformLayout();
			this.GrpResults.ResumeLayout(false);
			this.GrpResults.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label LblHelp;
		private System.Windows.Forms.GroupBox GrpFolders;
		private System.Windows.Forms.TextBox TxtFolders;
		private System.Windows.Forms.GroupBox GrpResults;
		private System.Windows.Forms.TextBox TxtResults;
		private System.Windows.Forms.ProgressBar ProgressBar;
		private System.Windows.Forms.Button BtnSave;
		private System.Windows.Forms.Button BtnClose;
		private System.Windows.Forms.Button BtnSearch;
		private System.Windows.Forms.CheckBox ChkIncludeCurrent;
	}
}
