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
using System.Diagnostics;

namespace Berburger
{
    public partial class EditDatabaseForm : Form
    {
		private string database;
		private bool showData = false;
		private string[] columns;


		public EditDatabaseForm(string database)
		{
			this.database = database;
			SqlAdapter.RunCommand(new SqlCommand("use " + database));

			InitializeComponent();

			dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
			loadTables();
		}

		public EditDatabaseForm(string database, string[] columns) {
			this.database = database;
			this.columns = columns;
			SqlAdapter.RunCommand(new SqlCommand("use " + database));
			showData = true;

			InitializeComponent();

			dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
			loadTables();
		}

		void loadTables() {
			List<string> tables = SqlAdapter.GetResultFromCommand(new SqlCommand("SELECT TABLE_NAME FROM " + database + ".INFORMATION_SCHEMA.Tables "));

			foreach (var table in tables)
			{
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

			List<string> columns = SqlAdapter.GetResultFromCommand(new SqlCommand("SELECT COLUMN_NAME,* FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + comboBoxTables.SelectedItem.ToString() + "'"));

			labelColumns.Text = "Columns: " + columns.Count;

			List<string[]> data = null;
			//first array is header

			if (showData) {
				data = SqlAdapter.GetMultipleRowsFromCommand(new SqlCommand("SELECT * FROM " + comboBoxTables.SelectedItem.ToString()));
			} else {
				data = SqlAdapter.GetMultipleRowsFromCommand(new SqlCommand("SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE, COLUMN_DEFAULT FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + comboBoxTables.SelectedItem.ToString() + "' ORDER BY ORDINAL_POSITION ASC; "));	
			}

			foreach (string columnName in data.First())
			{
				DataGridViewCell cellTemplate = new DataGridViewTextBoxCell();

				var isNullable = SqlAdapter.GetResultFromCommand(new SqlCommand("SELECT IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + comboBoxTables.SelectedItem.ToString() + "' and COLUMN_NAME = '" + columnName + "'"));
				
				if (isNullable.Count == 1 && isNullable[0] == "YES")
				{
					cellTemplate.Style.BackColor = Color.LightCyan;
				}

				DataGridViewColumn column = new DataGridViewColumn(cellTemplate);

				column.HeaderText = columnName;

				dataGridView1.Columns.Add(column);
			}

			for (int i = 1; i < data.Count; i++)
			{
				dataGridView1.Rows.Add(data[i]);
			}
		}
	}
}
