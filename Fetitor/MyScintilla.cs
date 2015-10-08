using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fetitor
{
	class MyScintilla : Scintilla
	{
		public event EventHandler CtrlS;

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Control | Keys.S:
					var ev = CtrlS;
					if (ev != null)
						ev(this, null);
					return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}
