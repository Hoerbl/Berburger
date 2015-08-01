using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;

namespace Berburger
{
	static class SqlAdapter
	{
		public static string UserName { get; private set; }
		static SqlConnection currentConnection = null;
		
		public static bool Connect(string password, string userName, string server, string database)
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

		public static bool IsConnected() {
			return currentConnection.State == System.Data.ConnectionState.Open;
		}

		public static int RunCommand(SqlCommand command) {
			if (!IsConnected()) {
				throw new InvalidOperationException("Not connected to the server");
			}
			command.Connection = currentConnection;
			return command.ExecuteNonQuery();
		}

		public static List<string> GetResultFromCommand(SqlCommand command) {
			if (!IsConnected()) {
				throw new InvalidOperationException("Not connected to the server");
			}
			command.Connection = currentConnection;

			SqlDataReader reader = command.ExecuteReader();

			List<string> resultList = new List<string>();

			while (reader.Read())
			{
				resultList.Add(reader[0].ToString());
			}
			reader.Close();

			return resultList;
		}

		/// <summary>
		/// First list entry is the header row and the following entries are data
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
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

		public static SqlConnection GetConnection() {
			if (IsConnected()) {
				return currentConnection;
			}
			return null;
		}

		public static void Disconnect() {
			currentConnection.Close();
		}
	}
}
