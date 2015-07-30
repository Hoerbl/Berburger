﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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

			List<string> resultList = SqlAdapter.GetResultFromCommand(new SqlCommand("SELECT * FROM sys.databases"));

			foreach (var result in resultList) {
				comboBoxDatabases.Items.Add(result);
			}

			comboBoxDatabases.SelectedIndex = resultList.Count - 1;
		}

		private void buttonEditDatabase_Click(object sender, EventArgs e)
		{
			EditDatabaseForm editForm = new EditDatabaseForm(comboBoxDatabases.SelectedItem.ToString());
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

		private void buttonEditData_Click(object sender, EventArgs e)
		{

		}
	}
}
