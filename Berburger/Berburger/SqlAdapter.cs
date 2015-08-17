using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;

namespace Berburger
{
	static class SqlAdapter
	{
		/// <summary>
		/// The username used to connect to the server
		/// </summary>
		public static string UserName { get; private set; }
		/// <summary>
		/// Currently used connnection
		/// </summary>
		static SqlConnection currentConnection = null;

		/// <summary>
		/// Connects the SqlAdapter to a specified server
		/// </summary>
		/// <param name="server">Server IP-Address or URL</param>
		/// <param name="userName">Username</param>
		/// <param name="password">Plaintext password</param>
		/// <param name="database">Databasename to connect to</param>
		/// <returns>True if successful, else false</returns>
		public static bool Connect(string server, string userName, string password, string database)
		{
			currentConnection = new SqlConnection(string.Format("user id={0};password={1};server={2};Trusted_Connection=no;database={3};connection timeout=10", userName, password, server, database));
			// Trusted_Connection=no is important to be able to login onto another machine
			try {
				currentConnection.Open();
			} catch (Exception e) {
				MessageBox.Show(e.Message);
				return false;
			}
			return true;
		}

		/// <summary>
		/// Connects the SqlAdapter to a specified server and the master database
		/// </summary>
		/// <param name="server">Server IP-Address or URL</param>
		/// <param name="userName">Username</param>
		/// <param name="password">Plaintext password</param>
		/// <returns>True if successful, else false</returns>
		/// <returns></returns>
		public static bool Connect(string server, string userName, string password)
		{
			return Connect(server, userName, password, "master");
		}

		/// <summary>
		/// Closes the connection to the server
		/// </summary>
		public static void Disconnect()
		{
			currentConnection.Close();
		}

		/// <summary>
		/// Check if connected
		/// </summary>
		/// <returns>True if connection is open, else false</returns>
		public static bool IsConnected() {
			return currentConnection.State == System.Data.ConnectionState.Open;
		}

		/// <summary>
		/// Executes the given command
		/// </summary>
		/// <param name="command">Sql command</param>
		/// <returns>Affected rows</returns>
		public static int RunCommand(SqlCommand command) {
			if (!IsConnected()) {
				throw new InvalidOperationException("Not connected to the server");
			}
			command.Connection = currentConnection;
			return command.ExecuteNonQuery();
		}

		/// <summary>
		/// Gets a DataTable
		/// </summary>
		/// <param name="command">Command to execute</param>
		/// <returns>DataTable with contents</returns>
		public static DataTable GetDataTable(SqlCommand command)
		{
			if (!IsConnected())
			{
				throw new InvalidOperationException("Not connected to the server");
			}
			var sqlDataAdapter = new SqlDataAdapter(command);
			var datatable = new DataTable();

			sqlDataAdapter.SelectCommand.Connection = currentConnection;

			sqlDataAdapter.Fill(datatable);

			return datatable;
		}

		/// <summary>
		/// Gets the result from a query with only 1 possible result (Scalar)
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		public static object GetResult(SqlCommand command)
		{
			command.Connection = currentConnection;
			return command.ExecuteScalar();
		}

		public static List<string[]> GetMultipleRowsFromCommand(SqlCommand command) {
			command.Connection = currentConnection;

			List<string[]> rows = new List<string[]>();
			try
			{
				SqlDataReader reader = command.ExecuteReader();

				string[] columnHead = new string[reader.FieldCount];
				// get columns
				for (int i = 0; i < reader.FieldCount;i++) {
					columnHead[i] = reader.GetName(i);
                }
				rows.Add(columnHead);

				// get data
				while (reader.Read())
				{
					string[] row = new string[reader.FieldCount];

					for (int i = 0; i < reader.FieldCount; i++)
					{
						row[i] = reader.GetValue(i).ToString();
					}

					rows.Add(row);
				}
				reader.Close();
			} catch (Exception e)
			{
				MessageBox.Show(e.Message + "\nSTACKTRACE:\n\n" + e.StackTrace);
				return null;
			}

			return rows;
		}
	}
}
