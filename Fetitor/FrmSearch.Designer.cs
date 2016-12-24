namespace Fetitor
{
	partial class FrmSearch
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSearch));
			this.TxtSearchText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.BtnSearch = new System.Windows.Forms.Button();
			this.BtnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TxtSearchText
			// 
			this.TxtSearchText.Location = new System.Drawing.Point(74, 12);
			this.TxtSearchText.Name = "TxtSearchText";
			this.TxtSearchText.Size = new System.Drawing.Size(289, 20);
			this.TxtSearchText.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Search for";
			// 
			// BtnSearch
			// 
			this.BtnSearch.Location = new System.Drawing.Point(207, 38);
			this.BtnSearch.Name = "BtnSearch";
			this.BtnSearch.Size = new System.Drawing.Size(75, 23);
			this.BtnSearch.TabIndex = 2;
			this.BtnSearch.Text = "Search";
			this.BtnSearch.UseVisualStyleBackColor = true;
			this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			// 
			// BtnClose
			// 
			this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnClose.Location = new System.Drawing.Point(288, 38);
			this.BtnClose.Name = "BtnClose";
			this.BtnClose.Size = new System.Drawing.Size(75, 23);
			this.BtnClose.TabIndex = 3;
			this.BtnClose.Text = "Close";
			this.BtnClose.UseVisualStyleBackColor = true;
			this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// FrmSearch
			// 
			this.AcceptButton = this.BtnSearch;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.BtnClose;
			this.ClientSize = new System.Drawing.Size(375, 71);
			this.Controls.Add(this.BtnClose);
			this.Controls.Add(this.BtnSearch);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TxtSearchText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmSearch";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Search";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TxtSearchText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button BtnSearch;
		private System.Windows.Forms.Button BtnClose;
	}
}