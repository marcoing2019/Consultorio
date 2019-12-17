using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingelTon
{



	public class SingelTonConexion
	{
		private static SQLiteConnection con;
		private const string cadena = "Data Source=USUARIOS.db;Version=3;";
		private static SQLiteCommand cmd;
		public static void Ejecutar(Action<SQLiteCommand> action)
		{
			try
			{
				if (con == null)
					con = new SQLiteConnection(cadena);
				if (cmd == null)
					cmd = new SQLiteCommand();
				if (con.State == ConnectionState.Open)
					con.Close();

				cmd.Connection = con;
				con.Open();
				action(cmd);
				con.Close();
				cmd.Dispose();
				con.Dispose();
				con = null;
				cmd = null;
			}
			catch (Exception e)
			{
				throw e;
			}


		}
	}
}

