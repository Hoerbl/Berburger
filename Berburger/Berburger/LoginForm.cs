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
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

		private void buttonConnect_Click(object sender, EventArgs e)
		{
			if (SqlAdapter.Connect(textBoxServer.Text, textBoxUser.Text, textBoxPassword.Text, "master")) {
				DialogResult = DialogResult.OK;
			} else {
				MessageBox.Show("Authentication Failed: **reason**");
				DialogResult = DialogResult.Abort;
			}
		}
	}
}
