using System;
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

		private void button1_Click(object sender, EventArgs e)
		{
			Form1 editForm = new Form1();
			editForm.Show();
		}

		private void buttonExecuteCommand_Click(object sender, EventArgs e)
		{
			List<string> resultList = SqlAdapter.GetResultFromCommand(new SqlCommand(textBoxCommand.Text));

			textBoxResult.Text = string.Join(", ", resultList);
		}
	}
}
