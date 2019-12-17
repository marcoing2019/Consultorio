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
    public partial class CONSULTAS : Form
    {
        public CONSULTAS()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
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
					  query.Append(" INSERT INTO consultas");
					  query.Append(" ");
					  query.Append("(NOMBRE,APELLIDOS,SEXO,EDAD,TELEFONO,NUMIMSS,SEGUROPOPULAR,RFC,FECHADECONSULTA,DOCTOR,CEDULA,ENFERMEDAD)");
					  query.Append("VALUES(@nombre,@apellidos,@sexo,@edad,@telefono,@numimss,@seguropopular,@rfc,@fechadeconsulta,@doctor,@cedula,@enfermedad)");
					  comando.CommandText = query.ToString();
					  comando.Parameters.AddWithValue("@nombre", textBox2.Text);
					  comando.Parameters.AddWithValue("@apellidos", textBox3.Text);
					  comando.Parameters.AddWithValue("@sexo", textBox4.Text);
					  comando.Parameters.AddWithValue("@edad", textBox5.Text);
					  comando.Parameters.AddWithValue("@telefono", textBox6.Text);
					  comando.Parameters.AddWithValue("@numimss", textBox7.Text);
					  comando.Parameters.AddWithValue("@seguropopular", textBox8.Text);
					  comando.Parameters.AddWithValue("@rfc", textBox9.Text);
					  comando.Parameters.AddWithValue("@fechadeconsulta", textBox10.Text);
					  comando.Parameters.AddWithValue("@doctor", textBox11.Text);
					  comando.Parameters.AddWithValue("@cedula", textBox12.Text);
					  comando.Parameters.AddWithValue("@enfermedad", textBox13.Text);
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
						  textBox10.Text = "";
						  textBox11.Text = "";
						  textBox12.Text = "";
						  textBox13.Text = "";
						  textBox1.Focus();
					  }

				  }
				  catch (Exception error)
				  {
					  MessageBox.Show(error.Message);
				  }

			  });
        }

        private void CONSULTAS_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
				SingelTon.SingelTonConexion.Ejecutar((comando) =>
				  {
					  try
					  {
						  var query = new StringBuilder();
						  query.Append("UPDATE consultas SET");
						  query.Append(" ");
						  query.Append("NOMBRE=@nombre,APELLIDOS=@apellidos,SEXO=@sexo,EDAD=@edad,TELEFONO=@telefono,NUMIMSS=@numimss,SEGUROPOPULAR=@seguropopular,RFC=@rfc,FECHADECONSULTA=@fechadeconsulta,DOCTOR=@doctor,CEDULA=@cedula,ENFERMEDAD=@enfermedad");
						  query.Append(" ");
						  query.Append("WHERE ID=@id;");
						  comando.CommandText = query.ToString();
						  comando.Parameters.AddWithValue("@id", textBox1.Text);
						  comando.Parameters.AddWithValue("@nombre", textBox2.Text);
						  comando.Parameters.AddWithValue("@apellidos", textBox3.Text);
						  comando.Parameters.AddWithValue("@sexo", textBox4.Text);
						  comando.Parameters.AddWithValue("@edad", textBox5.Text);
						  comando.Parameters.AddWithValue("@telefono", textBox6.Text);
						  comando.Parameters.AddWithValue("@numimss", textBox7.Text);
						  comando.Parameters.AddWithValue("@seguropopular", textBox8.Text);
						  comando.Parameters.AddWithValue("@rfc", textBox9.Text);
						  comando.Parameters.AddWithValue("@fechadeconsulta", textBox10.Text);
						  comando.Parameters.AddWithValue("@doctor", textBox11.Text);
						  comando.Parameters.AddWithValue("@cedula", textBox12.Text);
						  comando.Parameters.AddWithValue("@enfermedad", textBox13.Text);

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
							  textBox8.Text = "";
							  textBox9.Text = "";
							  textBox10.Text = "";
							  textBox11.Text = "";
							  textBox12.Text = "";
							  textBox13.Text = "";
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

                string sql = "SELECT * FROM consultas WHERE ID=" + textBox1.Text;
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
							textBox10.Text = reader[9].ToString();
							textBox11.Text = reader[10].ToString();
							textBox12.Text = reader[11].ToString();
							textBox13.Text = reader[12].ToString();

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

			SingelTon.SingelTonConexion.Ejecutar((comando) =>
			  {
				  try
				  {
					  var query = new StringBuilder();
					  query.Append("DELETE FROM CONSULTAS ");
					  query.Append(" ");
					  query.Append("WHERE ID=@id");
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
						  textBox10.Text = "";
						  textBox11.Text = "";
						  textBox12.Text = "";
						  textBox13.Text = "";
						  textBox1.Focus();


						  MessageBox.Show(" SUS DATOS SE HAN ELIMINADO SASTIFACTORIAMENTE ");
					  }

				  }

				  catch (Exception error)
				  {
					  MessageBox.Show(error.Message);
				  }


			  });
        }

        private void button4_Click(object sender, EventArgs e)
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
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox1.Focus();
        }
    }
}
