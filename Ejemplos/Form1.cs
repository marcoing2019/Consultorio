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
using Recursos;

namespace Ejemplos
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using(var conexion = new SQLiteConnection(Recurso.Cadena))
			{
				try
				{
					var query = new StringBuilder();
					query.Append(" INSERT INTO MITABLA ");
					query.Append("(Nombre,,Appellidos)");
					query.Append("VALUES(@Appellidos,@Nombre);");
					using (var commando = new SQLiteCommand(query.ToString(),conexion))
					{
						commando.Parameters.AddWithValue("@Appellidos", textBoxApellidos.Text);
						commando.Parameters.AddWithValue("@Nombre", textBoxNombre.Text);
						conexion.Open();
						int resultado = commando.ExecuteNonQuery();
						if(resultado > 0)
						{
							MessageBox.Show("Guardado");
						}
					

					}
				}
				catch(Exception error)
				{
					MessageBox.Show(error.Message);
				}

			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			using (var conexion = new SQLiteConnection(Recurso.Cadena))
			{
				try
				{
					var query = new StringBuilder();
					query.Append(" UPDATE MITABLA SET ");
					query.Append("Nombre=@Nombre,Appellidos=@Appellidos");
					query.Append("WHERE Id=@Id;");
					using (var commando = new SQLiteCommand(query.ToString(), conexion))
					{
						commando.Parameters.AddWithValue("@Id", textBoxID.Text);
						commando.Parameters.AddWithValue("@Appellidos", textBoxApellidos.Text);
						commando.Parameters.AddWithValue("@Nombre", textBoxNombre.Text);
						conexion.Open();
						int resultado = commando.ExecuteNonQuery();
						if (resultado > 0)
						{
							MessageBox.Show("Actulizado");
						}


					}
				}
				catch (Exception error)
				{
					MessageBox.Show(error.Message);
				}

			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			using (var conexion = new SQLiteConnection(Recurso.Cadena))
			{
				try
				{
					var query = new StringBuilder();
					query.Append(" SELECT  ");
					query.Append("Id,Nombre,Appellidos");
					query.Append(" FROM MITABLA ");
					query.Append(" WHERE Id=@Id ");
					using (var commando = new SQLiteCommand(query.ToString(), conexion))
					{
						commando.Parameters.AddWithValue("@Id", textBoxID.Text);
						conexion.Open();
						var reader = commando.ExecuteReader();
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								textBoxID.Text =  reader["Id"].ToString();
								textBoxNombre.Text = reader["Nobre"].ToString();
								textBoxApellidos.Text = reader["Appellidos"].ToString();
							}
						}
						else
						{
							MessageBox.Show("No se encontro nada");
						}


					}
				}
				catch (Exception error)
				{
					MessageBox.Show(error.Message);
				}

			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			using (var conexion = new SQLiteConnection(Recurso.Cadena))
			{
				try
				{
					var query = new StringBuilder();
					query.Append(" DELETE FROM MITABLA  ");
					query.Append(" WHERE Id=@Id ");
					using (var commando = new SQLiteCommand(query.ToString(), conexion))
					{

						conexion.Open();
						commando.Parameters.AddWithValue("@Id", textBoxID.Text);
						conexion.Open();
						int resultado = commando.ExecuteNonQuery();
						if (resultado > 0)
						{
							MessageBox.Show("Borrado");
						}


					}
				}
				catch (Exception error)
				{
					MessageBox.Show(error.Message);
				}

			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			using (var conexion = new SQLiteConnection(Recurso.Cadena))
			{
				try
				{
					var query = new StringBuilder();
					query.Append(" SELECT  ");
					query.Append("Id,Nombre,Appellidos");
					query.Append(" FROM MITABLA ");
					query.Append(" WHERE Id=@Id ");
					using (var commando = new SQLiteCommand(query.ToString(), conexion))
					{
						commando.Parameters.AddWithValue("@Id", textBoxID.Text);
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

		private void button6_Click(object sender, EventArgs e)
		{
			using (var conexion = new SQLiteConnection(Recurso.Cadena))
			{
				try
				{
					var query = new StringBuilder();
					query.Append(" SELECT  ");
					query.Append("Id,Nombre,Appellidos");
					query.Append(" FROM MITABLA ");
				
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
	}
}
