using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Berburger
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			LoginForm login = new LoginForm();
			login.ShowDialog();

			if (login.DialogResult == DialogResult.Abort) {
				Close();
			} else if (login.DialogResult == DialogResult.OK) {
				login.Close();
			}

			InitializeComponent();
		}
	}
}
