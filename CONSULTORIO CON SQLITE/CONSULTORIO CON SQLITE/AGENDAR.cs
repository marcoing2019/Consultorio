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
using CONSULTORIO_CON_SQLITE;

namespace CONSULTORIO_CON_SQLITE
{
	public partial class AGENDAR : Form
	{
		public AGENDAR()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{

			SingelTon.SingelTonConexion.Ejecutar((comando) =>

			  {
				  try
				  {
					  var query = new StringBuilder();
					  query.Append(" INSERT INTO agenda");
					  query.Append(" ");
					  query.Append("(NOMBRE,APELLIDOS,SEXO,EDAD,FECHADECITA,DOCTOR,TELEFONO,DIRECCION)");
					  query.Append("VALUES(@nombre,@apellidos,@sexo,@edad,@fechadecita,@doctor,@telefono,@direccion)");
					  comando.CommandText = query.ToString();
					  comando.Parameters.AddWithValue("@nombre", textBox2.Text);
					  comando.Parameters.AddWithValue("@apellidos", textBox3.Text);
					  comando.Parameters.AddWithValue("@sexo", textBox4.Text);
					  comando.Parameters.AddWithValue("@edad", textBox5.Text);
					  comando.Parameters.AddWithValue("@fechadecita", textBox6.Text);
					  comando.Parameters.AddWithValue("@doctor", textBox7.Text);
					  comando.Parameters.AddWithValue("@telefono", textBox8.Text);
					  comando.Parameters.AddWithValue("@direccion", textBox9.Text);

					  int resultado = comando.ExecuteNonQuery();
					  if (resultado > 0)
					  {
						  linkLabel1.Text = " SUS DATOS SE HAN GUARDADO SASTIFACTORIAMENTE ";

						  textBox1.Text = "";
						  textBox2.Text = "";
						  textBox3.Text = "";
						  textBox4.Text = "";
						  textBox5.Text = "";
						  textBox6.Text = "";
						  textBox7.Text = "";
						  textBox8.Text = "";
						  textBox9.Text = "";
						  textBox1.Focus();
					  }
				  }

				  catch (Exception error)
				  {
					  MessageBox.Show(error.Message);
				  }
			  });
		}



		private void button3_Click(object sender, EventArgs e)
		{

			SingelTon.SingelTonConexion.Ejecutar((comando) =>
			  {
				  try
				  {
					  var query = new StringBuilder();
					  query.Append("UPDATE agenda SET");
					  query.Append(" ");
					  query.Append("NOMBRE=@nombre,APELLIDOS=@apellidos,SEXO=@sexo,EDAD=@edad,FECHADECITA=@fechadecita,DOCTOR=@doctor,TELEFONO=@telefono,DIRECCION=@direccion");
					  query.Append(" ");
					  query.Append("WHERE ID=@id;");
					  comando.CommandText = query.ToString();

					  comando.Parameters.AddWithValue("@id", textBox1.Text);
					  comando.Parameters.AddWithValue("@nombre", textBox2.Text);
					  comando.Parameters.AddWithValue("@apellidos", textBox3.Text);
					  comando.Parameters.AddWithValue("@sexo", textBox4.Text);
					  comando.Parameters.AddWithValue("@edad", textBox5.Text);
					  comando.Parameters.AddWithValue("@fechadecita", textBox6.Text);
					  comando.Parameters.AddWithValue("@doctor", textBox7.Text);
					  comando.Parameters.AddWithValue("@telefono", textBox8.Text);
					  comando.Parameters.AddWithValue("@direccion", textBox9.Text);

					  int resultado = comando.ExecuteNonQuery();
					  if (resultado > 0)
					  {
						  linkLabel1.Text = " SUS DATOS SE HAN CORREGIDO SASTIFACTORIAMENTE ";

						  textBox1.Text = "";
						  textBox2.Text = "";
						  textBox3.Text = "";
						  textBox4.Text = "";
						  textBox5.Text = "";
						  textBox6.Text = "";
						  textBox7.Text = "";
						  textBox8.Text = "";
						  textBox9.Text = "";
						  textBox1.Focus();

					  }
				  }


				  catch (Exception error)
				  {
					  MessageBox.Show(error.Message);
				  }
			  });


		}

		private void button6_Click(object sender, EventArgs e)
		{
         // Cuando hago click en el botón Buscar, procedo a buscar en la Base de Datos.

			string sql = "SELECT * FROM agenda WHERE ID=" + textBox1.Text;
			SingelTon.SingelTonConexion.Ejecutar((cmd) =>
			{
				cmd.CommandText = sql;
				
				try
				{
					var reader = cmd.ExecuteReader();

					if (reader.Read())
					{
						textBox1.Text = reader[0].ToString();
						textBox2.Text = reader[1].ToString();
						textBox3.Text = reader[2].ToString();
						textBox4.Text = reader[3].ToString();
						textBox5.Text = reader[4].ToString();
						textBox6.Text = reader[5].ToString();
						textBox7.Text = reader[6].ToString();
						textBox8.Text = reader[7].ToString();
						textBox9.Text = reader[8].ToString();

						linkLabel1.Text = "SUS DATOS SE AN MOSTRADO PARA SU CORRECCION Y VERIFICACION";
					}

					else
						linkLabel1.Text = "Ningun registro encontrado con el Id ingresado";

					reader.Close();

				}

				catch (Exception ex)
				{

					MessageBox.Show("Erro: " + ex.ToString());

				}
				



			});


		}

		private void button4_Click(object sender, EventArgs e)
		{
			SingelTon.SingelTonConexion.Ejecutar((comando) =>
			{
				try
				{
					var query = new StringBuilder();
					query.Append(" DELETE FROM AGENDA ");
					query.Append(" WHERE  ID=@id ");
					comando.CommandText = query.ToString();
					comando.Parameters.AddWithValue("@id", textBox1.Text);

					int resultado = comando.ExecuteNonQuery();
					if (resultado > 0)
					{
						textBox1.Text = "";
						textBox2.Text = "";
						textBox3.Text = "";
						textBox4.Text = "";
						textBox5.Text = "";
						textBox6.Text = "";
						textBox7.Text = "";
						textBox8.Text = "";
						textBox9.Text = "";
						textBox1.Focus();

						linkLabel1.Text = "SUS DATOS FUERON ELIMINADOS";
					}

				}




				catch (Exception error)

				{
					MessageBox.Show(error.Message);
				}
			});
		}




		private void button5_Click(object sender, EventArgs e)
		{

			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			textBox6.Text = "";
			textBox7.Text = "";
			textBox8.Text = "";
			textBox9.Text = "";
			textBox1.Focus();
			linkLabel1.Text = " SUS CASILLAS SE HAN LIMPIADO PARA SU NUEVA CAPTURA ";
		}
	}
}