using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Berburger
{
	public partial class LoginForm : Form
	{
		private static readonly byte[] entropy = { 1, 7, 6, 9, 4 };

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
			if (Settings.Contains("lastPassword"))
			{
				byte[] ciphertext = StringToByteArray(Settings.GetValue("lastPassword"));

				var data = ProtectedData.Unprotect(ciphertext, entropy, DataProtectionScope.CurrentUser);

				textBoxPassword.Text = Encoding.UTF8.GetString(data);

				if (Settings.Contains("autoConnect"))
				{
					checkBoxAutoConnect.Checked = true;
					buttonConnect_Click(null, null);
				}
            }

			if (textBoxServer.Text != "" && textBoxUser.Text != "" && textBoxPassword.Text.Length == 0)
			{
				textBoxPassword.Select();
			} else if (textBoxServer.Text.Length == 0)
			{
				textBoxServer.Select();
			} else if (textBoxUser.Text.Length == 0)
			{
				textBoxUser.Select();
			} else
			{
				buttonConnect.Focus();
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
				return;
			} catch (Exception ex)
			{
				Debug.WriteLine(ex.GetType());
				MessageBox.Show("Authentication Failed: " + ex.Message);
				return;
			}

			Settings.SetProperty("lastServer", textBoxServer.Text);
			Settings.SetProperty("lastUser", textBoxUser.Text);

			if (checkBoxSavePass.Checked)
			{
				byte[] passwordPlain = Encoding.UTF8.GetBytes(textBoxPassword.Text);

				byte[] ciphertext = ProtectedData.Protect(passwordPlain, entropy, DataProtectionScope.CurrentUser);

				Settings.SetProperty("lastPassword", ByteArrayToString(ciphertext));
			}
			if (checkBoxAutoConnect.Checked)
			{
				Settings.SetProperty("autoConnect", "true");
			} else
			{
				if (Settings.Contains("autoConnect"))
				{
					Settings.RemoveProperty("autoConnect");
				}
			}

			Settings.SaveConfig();
		}

		public static string ByteArrayToString(byte[] ba)
		{
			string hex = BitConverter.ToString(ba);
			return hex.Replace("-", "");
		}

		public static byte[] StringToByteArray(String hex)
		{
			int NumberChars = hex.Length;
			byte[] bytes = new byte[NumberChars / 2];
			for (int i = 0; i < NumberChars; i += 2)
				bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
			return bytes;
		}
	}
}
