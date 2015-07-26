using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

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
			if (IsConnected()) {
				command.Connection = currentConnection;
				return command.ExecuteNonQuery();
			}
			return -1;
		}
	}
}
