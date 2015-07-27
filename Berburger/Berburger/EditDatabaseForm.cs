using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Berburger
{
    public partial class EditDatabaseForm : Form
    {
		private string database;

		public EditDatabaseForm(string database) : base()
		{
			this.database = database;

			InitializeComponent();

			List<string> tables = SqlAdapter.GetResultFromCommand(new SqlCommand("SELECT TABLE_NAME FROM " + database + ".INFORMATION_SCHEMA.Tables "));

			foreach (var table in tables) {
				comboBoxTables.Items.Add(table);
			}

			comboBoxTables.SelectedIndex = 0;
		}

		private void buttonDelete_Click(object sender, EventArgs e)
        {
			
        }

		private void comboBoxTables_SelectedValueChanged(object sender, EventArgs e)
		{
			dataGridView1.Columns.Clear();

			List<string> columns = SqlAdapter.GetResultFromCommand(new SqlCommand("use " + database + "; SELECT COLUMN_NAME,* FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + comboBoxTables.SelectedItem.ToString() + "'"));

			foreach (string s in columns)
			{
				dataGridView1.Columns.Add("column_" + s, s);
			}

			labelColumns.Text = "Columns: " + columns.Count;
		}
	}
}
