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

			Settings.LoadSettings();
			if (Settings.Contains("lastServer"))
			{
				textBoxServer.Text = Settings.GetValue("lastServer");
			}
			if (Settings.Contains("lastUser"))
			{
				textBoxUser.Text = Settings.GetValue("lastUser");
			}

			if (textBoxServer.Text != "" && textBoxUser.Text != "")
			{
				textBoxPassword.Select();
			}
		}

		private void buttonConnect_Click(object sender, EventArgs e)
		{
			if (SqlAdapter.Connect(textBoxServer.Text, textBoxUser.Text, textBoxPassword.Text, "master")) {
				DialogResult = DialogResult.OK;
			} else {
				MessageBox.Show("Authentication Failed: **reason**");
				DialogResult = DialogResult.Abort;
			}
			Settings.SetProperty("lastServer", textBoxServer.Text);
			Settings.SetProperty("lastUser", textBoxUser.Text);
			Settings.SaveConfig();
		}
	}
}
