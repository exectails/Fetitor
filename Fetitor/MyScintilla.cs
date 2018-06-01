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
using System.Windows.Forms;

namespace Fetitor
{
	/// <summary>
	/// A version of Scintilla with additional hotkeys.
	/// </summary>
	class MyScintilla : Scintilla
	{
		/// <summary>
		/// Raised when Ctrl+S is pressed.
		/// </summary>
		public event EventHandler CtrlS;

		/// <summary>
		/// Raised when Ctrl+F is pressed.
		/// </summary>
		public event EventHandler CtrlF;

		/// <summary>
		/// Catches hotkeys and raises their events.
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="keyData"></param>
		/// <returns></returns>
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Control | Keys.S:
					this.CtrlS?.Invoke(this, null);
					return true;

				case Keys.Control | Keys.F:
					this.CtrlF?.Invoke(this, null);
					return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}
