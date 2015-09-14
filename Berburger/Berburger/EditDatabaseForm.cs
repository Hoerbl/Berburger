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
		/// <summary>
		/// Database which the user is currently editing
		/// </summary>
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

		/// <summary>
		/// Show columns (data)
		/// </summary>
		/// <param name="database"></param>
		/// <param name="columns"></param>
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

		/// <summary>
		/// When a different table gets selected change the amount of columns and the content for the DataGridView
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBoxTables_SelectedValueChanged(object sender, EventArgs e)
		{
			dataGridView1.Columns.Clear();

			var amountColumns = SqlAdapter.GetResult(new SqlCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + comboBoxTables.SelectedItem.ToString() + "'"));

			labelColumns.Text = "Columns: " + amountColumns;

			// update datagridview1
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
			
			DataTable isNullable = SqlAdapter.GetDataTable(new SqlCommand("SELECT COLUMN_NAME, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + comboBoxTables.SelectedItem.ToString() + "'")); // COLUMN_NAME = '" + columnName + "'"

			dataGridView1.DataSource = dataTable;

			// color columns which are essential
			foreach (DataRow dr in isNullable.Rows)
			{
				Debug.Write("checking color for " + dr["COLUMN_NAME"]);
				if (dr["IS_NULLABLE"].ToString() == "NO")
				{
					if (showData)
					{
						dataGridView1.Columns[dr["COLUMN_NAME"].ToString()].DefaultCellStyle.BackColor = Color.LightCyan;
						Debug.WriteLine(": is essential");
					} else
					{
						int rowIndex = getRowIndex(dr["COLUMN_NAME"].ToString());
						if (rowIndex == -1)
						{
							throw new IndexOutOfRangeException("Exception 001");
						} else
						{
							dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightCyan;
							Debug.WriteLine(" is essential");
						}
					}
				}
			}
		}

		private int getRowIndex(string name)
		{
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (row.Cells[0].Value.ToString() == name)
				{
					return row.Index;
				}
			}
			return -1;
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
