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

		public EditDatabaseForm(string database, string[] columns)
		{
			this.database = database;
			this.columns = columns;
			SqlAdapter.RunCommand(new SqlCommand("use " + database));
			showData = true;

			InitializeComponent();

			dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
			loadTables();
		}

		/// <summary>
		/// Loads the tables the user can edit for the combobox
		/// </summary>
		void loadTables()
		{
			var tables = SqlAdapter.GetDataTable(new SqlCommand("SELECT TABLE_NAME FROM " + database + ".INFORMATION_SCHEMA.Tables "));

			foreach (DataRow table in tables.Rows)
			{
				comboBoxTables.Items.Add(table["table_name"]);
			}

			comboBoxTables.SelectedIndex = 0;
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{

		}

		private void comboBoxTables_SelectedValueChanged(object sender, EventArgs e)
		{
			dataGridView1.Columns.Clear();

			var columns = SqlAdapter.GetDataTable(new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + comboBoxTables.SelectedItem.ToString() + "'"));

			labelColumns.Text = "Columns: " + columns.Rows.Count;

			string command = "";
			if (showData)
			{
				command = "SELECT * FROM " + comboBoxTables.SelectedItem.ToString();
			}
			else
			{
				command = "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE, COLUMN_DEFAULT FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + comboBoxTables.SelectedItem.ToString() + "' ORDER BY ORDINAL_POSITION ASC; ";
			}

			var dataTable = SqlAdapter.GetDataTable(new SqlCommand(command));

			dataGridView1.DataSource = dataTable;

		}

		private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			Debug.WriteLine("CellEndEdit");

		}

		private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			Debug.WriteLine("RowsAdded");
		}
	}
}
