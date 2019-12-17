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
    public partial class CONSULTAINTERNA : Form
    {
        public CONSULTAINTERNA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IMPRIMIR imprimir = new IMPRIMIR();
            imprimir.Show();
            this.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SingelTon.SingelTonConexion.Ejecutar((comando) =>
            {

                try
                {
                    var query = new StringBuilder();
                    query.Append(" INSERT INTO CONSULTASINTERNAS ");
                    query.Append(" ");
                    query.Append("(PACIENTE,DOCTOR,CEDULA,HORA,FECHA,DIAGNOSTICO,NOTA)");
                    query.Append("VALUES(@paciente,@doctor,@cedula,@hora,@fecha,@diagnostico,@nota)");
                    comando.CommandText = query.ToString();
                    comando.Parameters.AddWithValue("@paciente", textBox2.Text);
                    comando.Parameters.AddWithValue("@doctor", textBox3.Text);
                    comando.Parameters.AddWithValue("@cedula", textBox4.Text);
                    comando.Parameters.AddWithValue("@hora", textBox5.Text);
                    comando.Parameters.AddWithValue("@fecha", textBox6.Text);
                    comando.Parameters.AddWithValue("@diagnostico", textBox7.Text);
                    comando.Parameters.AddWithValue("@nota", textBox8.Text);


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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox1.Focus();
            linkLabel1.Text = " SUS CASILLAS ESTAN LIMPIAS, INGRESE SUS NUEVOS DATOS ";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SingelTon.SingelTonConexion.Ejecutar((comando) =>
              {
                  try
                  {
                      var query = new StringBuilder();
                      query.Append(" UPDATE CONSULTASINTERNAS SET ");
                      query.Append(" ");
                      query.Append("PACIENTE=@paciente,DOCTOR=@doctor,CEDULA=@cedula,HORA=@hora,FECHA=@fecha,DIAGNOSTICO=@diagnostico,NOTA=@nota");
                      query.Append(" ");
                      query.Append("WHERE ID=@id;");
                      comando.CommandText = query.ToString();

                      comando.Parameters.AddWithValue("@id", textBox1.Text);
                      comando.Parameters.AddWithValue("@paciente", textBox2.Text);
                      comando.Parameters.AddWithValue("@doctor", textBox3.Text);
                      comando.Parameters.AddWithValue("@cedula", textBox4.Text);
                      comando.Parameters.AddWithValue("@hora", textBox5.Text);
                      comando.Parameters.AddWithValue("@fecha", textBox6.Text);
                      comando.Parameters.AddWithValue("@diagnostico", textBox7.Text);
                      comando.Parameters.AddWithValue("@nota", textBox8.Text);

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
                          textBox1.Focus();
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

            SingelTon.SingelTonConexion.Ejecutar((comando) =>
              {
                  try
                  {
                      var query = new StringBuilder();
                      query.Append("DELETE FROM CONSULTASINTERNAS ");
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
                          textBox8.Text = ""; ;
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

        private void Button7_Click(object sender, EventArgs e)
        {
            {

                // Cuando hago click en el botón Buscar, procedo a buscar en la Base de Datos.

                string sql = "SELECT * FROM consultasinternas WHERE ID=" + textBox1.Text;



                SQLiteConnection con = new SQLiteConnection("Data Source=USUARIOS.db;Version=3;");

                SQLiteCommand cmd = new SQLiteCommand(sql, con);




                try
                {
                    cmd.CommandType = CommandType.Text;

                    SQLiteDataReader reader;

                    con.Open();

                    reader = cmd.ExecuteReader();

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

                        linkLabel1.Text = "SUS DATOS AN SIDO MOSTRADOS PARA SU ACTUALIZACION";
                    }

                    else

                        linkLabel1.Text = "NO SE ENCONTRO EL ID INGRESADO EN LA BASE";

                }

                catch (Exception ex)
                {

                    MessageBox.Show("Erro: " + ex.ToString());

                }

                finally
                {

                    // Cierro la Conexión.
                    cmd.Dispose();

                    con.Close();

                }

            }
        }
    }
}
    
