using System;
using System.Data.SqlClient;
using System.Diagnostics;
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
			try
			{
				SqlAdapter.Connect(textBoxServer.Text, textBoxUser.Text, textBoxPassword.Text);
				DialogResult = DialogResult.OK;
			} catch (SqlException ex)
			{
				MessageBox.Show(ex.Message);
				DialogResult = DialogResult.Abort;
			} catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				MessageBox.Show("here: " + ex.GetType());
				
				MessageBox.Show("Authentication Failed: **reason**");
			}

			Settings.SetProperty("lastServer", textBoxServer.Text);
			Settings.SetProperty("lastUser", textBoxUser.Text);
			Settings.SaveConfig();
		}
	}
}
