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
	public partial class USUARIOS : Form
	{
		public USUARIOS()
		{
			InitializeComponent();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SingelTon.SingelTonConexion.Ejecutar((comando) =>

			  {
				  try
				  {
					  var query = new StringBuilder();
					  query.Append(" INSERT INTO datos");
					  query.Append(" ");
					  query.Append("(USUARIO,CLAVE,NOMBRE,TELEFONO,APELLIDOS,DIRECCION)");
					  query.Append("VALUES(@usuario,@clave,@nombre,@telefono,@apellidos,@direccion)");
					  comando.CommandText = query.ToString();
					  comando.Parameters.AddWithValue("@usuario", textBox2.Text);
					  comando.Parameters.AddWithValue("@clave", textBox3.Text);
					  comando.Parameters.AddWithValue("@nombre", textBox4.Text);
					  comando.Parameters.AddWithValue("@telefono", textBox5.Text);
					  comando.Parameters.AddWithValue("@apellidos", textBox6.Text);
					  comando.Parameters.AddWithValue("@direccion", textBox7.Text);


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
						  textBox1.Focus();
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


			// Cuando hago click en el botón Buscar, procedo a buscar en la Base de Datos.

			string sql = "SELECT * FROM DATOS WHERE ID=" + textBox1.Text;



			SingelTon.SingelTonConexion.Ejecutar((comando) =>
			{

				try
				{
					comando.CommandText = sql;
					var reader = comando.ExecuteReader();


					if (reader.Read())
					{

						textBox1.Text = reader[0].ToString();
						textBox2.Text = reader[1].ToString();
						textBox3.Text = reader[2].ToString();
						textBox4.Text = reader[3].ToString();
						textBox5.Text = reader[4].ToString();
						textBox6.Text = reader[5].ToString();
						textBox7.Text = reader[6].ToString();

						linkLabel1.Text = "SUS DATOS AN SIDO MOSTRADOS PARA SU ACTUALIZACION";
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


		private void button3_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			textBox6.Text = "";
			textBox7.Text = "";
			textBox1.Focus();
			linkLabel1.Text = "SUS CASILLAS SE LIMPIARON CORRECTAMENTE ";
		}

		private void button2_Click(object sender, EventArgs e)
		{

			SingelTon.SingelTonConexion.Ejecutar((comando) =>
			  {
				  try
				  {
					  var query = new StringBuilder();
					  query.Append("UPDATE datos SET");
					  query.Append(" ");
					  query.Append("USUARIO=@usuario,CLAVE=@clave,NOMBRE=@nombre,APELLIDOS=@apellidos,TELEFONO=@telefono,DIRECCION=@direccion");
					  query.Append(" ");
					  query.Append("WHERE ID=@id;");
					  comando.CommandText = query.ToString();
					  comando.Parameters.AddWithValue("@id", textBox1.Text);
					  comando.Parameters.AddWithValue("@usuario", textBox2.Text);
					  comando.Parameters.AddWithValue("@clave", textBox3.Text);
					  comando.Parameters.AddWithValue("@nombre", textBox4.Text);
					  comando.Parameters.AddWithValue("@apellidos", textBox5.Text);
					  comando.Parameters.AddWithValue("@telefono", textBox6.Text);
					  comando.Parameters.AddWithValue("@direccion", textBox7.Text);



					  int resultado = comando.ExecuteNonQuery();
					  if (resultado > 0)
					  {
						  linkLabel1.Text = " SUS DATOS SE HAN CORREGIDOS SASTIFACTORIAMENTE ";

						  textBox1.Text = "";
						  textBox2.Text = "";
						  textBox3.Text = "";
						  textBox4.Text = "";
						  textBox5.Text = "";
						  textBox6.Text = "";
						  textBox7.Text = "";
						  textBox1.Focus();
					  }


				  }
				  catch (Exception error)
				  {
					  MessageBox.Show(error.Message);
				  }


			  });
		}

		private void USUARIOS_Load(object sender, EventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}
	}
}