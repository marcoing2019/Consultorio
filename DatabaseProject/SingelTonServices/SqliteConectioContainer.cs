using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.SingelTonServices
{
	public class SQLiteConectador
	{
		private static string DefualtConnectionString = "Data Source=mydb.db;Version=3;";
		private static SQLiteConnection _con;

		public static SQLiteConnection ObtenerConexion
		{
			get
			{
			
				_con = new SQLiteConnection(DefualtConnectionString);
				return _con;
			}
		}
		public static void Abrir()
		{
			Cerrar();
			_con.Open();
		}
		public static void Cerrar()
		{
			if (_con.State == System.Data.ConnectionState.Open)
				_con.Close();

		}

	}
	
}
