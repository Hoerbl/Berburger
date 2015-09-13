using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace Berburger
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			connectToServer();
			loadDatabasesFromServer();
		}

		void loadDatabasesFromServer()
		{
			if (SqlAdapter.IsConnected())
			{
				var databases = SqlAdapter.GetDataTable(new SqlCommand("SELECT name FROM sys.databases"));

				foreach (DataRow result in databases.Rows)
				{
					comboBoxDatabases.Items.Add(result["name"]);
				}

				comboBoxDatabases.SelectedIndex = databases.Rows.Count - 1;
			}
		}

		void connectToServer()
		{
			LoginForm login = new LoginForm();

			while (login.DialogResult != DialogResult.OK)
			{
				login.ShowDialog();

				if (login.DialogResult == DialogResult.Cancel)
				{
					break;
				}
			}
			login.Close();

			labelServer.Text = Settings.GetValue("lastServer");
			labelUser.Text = Settings.GetValue("lastUser");
		}

		private void buttonEditDatabase_Click(object sender, EventArgs e)
		{
			EditDatabaseForm editForm = new EditDatabaseForm(comboBoxDatabases.SelectedItem.ToString());
			editForm.Owner = this;
			editForm.Show();
		}

		private void buttonEditData_Click(object sender, EventArgs e)
		{
			EditDatabaseForm editForm = new EditDatabaseForm(comboBoxDatabases.SelectedItem.ToString(), new string[] { "a" });
			editForm.Owner = this;
			editForm.Show();
		}

		private void buttonExecuteCommand_Click(object sender, EventArgs e)
		{
			SqlAdapter.RunCommand(new SqlCommand("use " + comboBoxDatabases.SelectedItem.ToString()));

			var resultList = SqlAdapter.GetMultipleRowsFromCommand(new SqlCommand(textBoxCommand.Text));

			textBoxResult.Text = string.Join(", ", resultList);
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			SqlAdapter.Disconnect();
		}

		private void comboBoxDatabases_SelectedIndexChanged(object sender, EventArgs e)
		{
			labelTablesCount.Text = SqlAdapter.GetResult(new SqlCommand("SELECT count(*) FROM " + comboBoxDatabases.SelectedItem.ToString() + ".INFORMATION_SCHEMA.Tables ")) + " Tables";
		}

		private void buttonChangeServer_Click(object sender, EventArgs e)
		{
			Settings.RemoveProperty("autoConnect");
			Settings.SaveConfig();
			connectToServer();
			loadDatabasesFromServer();
		}
	}
}
