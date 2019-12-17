using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace CONSULTORIO_CON_SQLITE
{
	public partial class REPORTES : Form
	{
		public REPORTES()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			using (var conexion = new SQLiteConnection(CONEXION.CADENA))
			{
				try
				{
					var query = new StringBuilder();
					query.Append(" SELECT ");
					query.Append("Id,Nombre,Apellidos,Doctor,Medicamento,Hora,Cantidad,Caducidad,Nota");
					query.Append(" FROM FARMACIA ");

					using (var commando = new SQLiteCommand(query.ToString(), conexion))
					{

						conexion.Open();

						SQLiteDataAdapter da = new SQLiteDataAdapter();

						da.SelectCommand = commando;

						DataTable dt = new DataTable();

						da.Fill(dt);

						dataGridView1.DataSource = dt;

						conexion.Close();

					}
				}
				catch (Exception error)
				{
					MessageBox.Show(error.Message);
				}

			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

			if (!String.IsNullOrWhiteSpace(textBox1.Text) && textBox1.Text.Length > 0)
				label2.Text = " Total de Registros: " + Convert.ToString(dataGridView1.Rows.Count - 1);

			SingelTon.SingelTonConexion.Ejecutar((comando) =>
			  {
				  var query = new StringBuilder();

				  query.Append(" SELECT ");
				  query.Append("FECHADECITA,DOCTOR,CANTIDAD,CADUCIDAD");
				  query.Append(" FROM ");
				  query.Append(" FARMACIA ");
				  query.Append(" WHERE ");
				  query.Append(" ID LIKE @BUSQUEDA OR NOMBRE LIKE @BUSQUEDA");
				  comando.CommandText = query.ToString();

				  comando.Parameters.AddWithValue("@BUSQUEDA", string.Format("%{0}%", textBox1.Text));


				  SQLiteDataAdapter da = new SQLiteDataAdapter();
				  da.SelectCommand = comando;
				  DataTable dt = new DataTable();
				  da.Fill(dt);
				  dataGridView1.DataSource = dt;

				  
			  });



		}
	}
}