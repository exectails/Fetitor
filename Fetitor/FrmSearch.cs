using System;
using System.Windows.Forms;

namespace Fetitor
{
	/// <summary>
	/// Provides a form to input a search text.
	/// </summary>
	public partial class FrmSearch : Form
	{
		private FrmMain _mainForm;

		/// <summary>
		/// Creates new instance.
		/// </summary>
		/// <param name="mainForm"></param>
		public FrmSearch(FrmMain mainForm)
		{
			InitializeComponent();
			_mainForm = mainForm;
		}

		/// <summary>
		/// Hides form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnClose_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		/// <summary>
		/// Calls search method on main form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSearch_Click(object sender, EventArgs e)
		{
			var searchText = this.TxtSearchText.Text;

			if (!_mainForm.SearchFor(searchText))
				MessageBox.Show("Text not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Selects the search text.
		/// </summary>
		public void SelectSearchText()
		{
			this.TxtSearchText.Focus();
			this.TxtSearchText.SelectAll();
		}

		/// <summary>
		/// Changes opacity when the form's focus changes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmSearch_Deactivate(object sender, EventArgs e)
		{
			this.Opacity = 0.8;
		}

		/// <summary>
		/// Changes opacity when the form's focus changes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmSearch_Activated(object sender, EventArgs e)
		{
			this.Opacity = 1;
		}
	}
}
