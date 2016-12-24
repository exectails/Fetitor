using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fetitor
{
	public partial class FrmSearch : Form
	{
		private FrmMain _mainForm;

		public FrmSearch(FrmMain mainForm)
		{
			InitializeComponent();
			_mainForm = mainForm;
		}

		private void BtnClose_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void BtnSearch_Click(object sender, EventArgs e)
		{
			var searchText = this.TxtSearchText.Text;

			if (!_mainForm.SearchFor(searchText))
				MessageBox.Show("Text not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public void SelectSearchText()
		{
			this.TxtSearchText.Focus();
			this.TxtSearchText.SelectAll();
		}
	}
}
