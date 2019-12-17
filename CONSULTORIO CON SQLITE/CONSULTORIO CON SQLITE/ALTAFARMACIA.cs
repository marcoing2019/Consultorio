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
    public partial class ALTAFARMACIA : Form
    {
        public ALTAFARMACIA()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SingelTon.SingelTonConexion.Ejecutar((comando) =>
              {
                  try
                  {
                      var query = new StringBuilder();
                      query.Append(" INSERT INTO farmacia");
                      query.Append(" ");
                      query.Append("(NOMBRE,APELLIDOS,FECHACITA,DOCTOR,MEDICAMENTO,HORA,CANTIDAD,CADUCIDAD,ENEXISTENCIA,AGOTADAS,NOTA)");
                      query.Append("VALUES(@nombre,@apellidos,@fechacita,@doctor,@medicamento,@hora,@cantidad,@caducidad,@enexistencia,@agotadas,@nota)");
                      comando.CommandText = query.ToString();

                      comando.Parameters.AddWithValue("@nombre", textBox2.Text);
                      comando.Parameters.AddWithValue("@apellidos", textBox3.Text);
                      comando.Parameters.AddWithValue("@fechacita", textBox4.Text);
                      comando.Parameters.AddWithValue("@doctor", textBox5.Text);
                      comando.Parameters.AddWithValue("@medicamento", textBox6.Text);
                      comando.Parameters.AddWithValue("@hora", textBox7.Text);
                      comando.Parameters.AddWithValue("@cantidad", textBox8.Text);
                      comando.Parameters.AddWithValue("@caducidad", textBox9.Text);
                      comando.Parameters.AddWithValue("@enexistencia", textBox10.Text);
                      comando.Parameters.AddWithValue("@agotadas", textBox11.Text);
                      comando.Parameters.AddWithValue("@nota", textBox12.Text);


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
                          textBox1.Focus();
                      }
                  }

                  catch (Exception error)
                  {
                      MessageBox.Show(error.Message);
                  }
              });
        }



        private void ALTAFARMACIA_Load(object sender, EventArgs e)
        {
            SingelTon.SingelTonConexion.Ejecutar((comando) =>
            {
                try
                {
                    var query = new StringBuilder();
                    query.Append(" SELECT  ");
                    query.Append("ID,NOMBRE,APELLIDOS,FECHACITA,DOCTOR,MEDICAMENTO,HORA,CANTIDAD,CADUCIDAD,ENEXISTENCIA,AGOTADAS,NOTA ");
                    query.Append(" FROM FARMACIA ");
                    comando.CommandText = query.ToString();



                    SQLiteDataAdapter da = new SQLiteDataAdapter();

                    da.SelectCommand = comando;

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGridView1.DataSource = dt;



                }

                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                label14.Text = " TOTAL DE REGISTROS ENCONTRADOS EN LA BASE: " + Convert.ToString(dataGridView1.Rows.Count - 1);
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SingelTon.SingelTonConexion.Ejecutar((comando) =>
              {
                  try
                  {
                      var query = new StringBuilder();
                      query.Append("UPDATE farmacia  SET");
                      query.Append(" ");
                      query.Append("NOMBRE=@nombre,APELLIDOS=@apellidos,FECHACITA=@fechacita,DOCTOR=@doctor,MEDICAMENTO=@medicamento,HORA=@hora,CANTIDAD=@cantidad,CADUCIDAD=@caducidad,ENEXISTENCIA=@enexistencia,AGOTADAS=@agotadas,NOTA=@nota");
                      query.Append(" ");
                      query.Append("WHERE ID=@id;");
                      comando.CommandText = query.ToString();

                      comando.Parameters.AddWithValue("@id", textBox1.Text);
                      comando.Parameters.AddWithValue("@nombre", textBox2.Text);
                      comando.Parameters.AddWithValue("@apellidos", textBox3.Text);
                      comando.Parameters.AddWithValue("@fechacita", textBox4.Text);
                      comando.Parameters.AddWithValue("@doctor", textBox5.Text);
                      comando.Parameters.AddWithValue("@medicamento", textBox6.Text);
                      comando.Parameters.AddWithValue("@hora", textBox7.Text);
                      comando.Parameters.AddWithValue("@cantidad", textBox8.Text);
                      comando.Parameters.AddWithValue("@caducidad", textBox9.Text);
                      comando.Parameters.AddWithValue("@enexistencia", textBox10.Text);
                      comando.Parameters.AddWithValue("@agotadas", textBox11.Text);
                      comando.Parameters.AddWithValue("@nota", textBox12.Text);


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
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }    

        private void Button6_Click(object sender, EventArgs e)
        {

        }
        private void Button7_Click(object sender, EventArgs e)
        {
            using (var conexion = new SQLiteConnection(CONEXION.CADENA))
            {
                try
                {
                    var query = new StringBuilder();
                    query.Append(" SELECT  ");
                    query.Append("ID,NOMBRE,APELLIDOS,FECHACITA,DOCTOR,MEDICAMENTO,HORA,CANTIDAD,CADUCIDAD,ENEXISTENCIA,AGOTADAS,NOTA");
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
                        label14.Text = " Total de Registros: " + Convert.ToString(dataGridView1.Rows.Count - 1);

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