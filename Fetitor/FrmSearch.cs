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
