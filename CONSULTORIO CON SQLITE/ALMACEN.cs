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
    public partial class ALMACEN : Form
    {
        public ALMACEN()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
            linkLabel1.Text = "SUS CASILLAS SE LIMPIARON CORRECTAMENTE , INGRESE DATOS ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
			SingelTon.SingelTonConexion.Ejecutar((comando) =>
			{
				try
				{
					var query = new StringBuilder();
					query.Append(" SELECT  ");
					query.Append("ID,MEDICAMENTO,CANTIDAD,CADUCIDAD,ENEXISTENCIA ");
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

			});
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
                if (!String.IsNullOrWhiteSpace(textBox1.Text) && textBox1.Text.Length > 0)
                    label2.Text = "TOTAL DE REGISTROS ENCONTRADOS EN LA BASE" + Convert.ToString(dataGridView1.Rows.Count - 1);
                
					SingelTon.SingelTonConexion.Ejecutar((comando) =>
					  {
						  var query = new StringBuilder();

						  query.Append(" SELECT ");
						  query.Append("ID,NOMBRE,FECHADECITA,DOCTOR ");
						  query.Append("FROM");
						  query.Append(" FARMACIA ");
						  query.Append(" WHERE ");
						  query.Append("ID LIKE @BUSQUEDA OR NOMBRE LIKE @BUSQUEDA ");
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
