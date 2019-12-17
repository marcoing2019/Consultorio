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
//using WkHtmlToPdf;

namespace CONSULTORIO_CON_SQLITE
{
    public partial class IMPRIMIR : Form
    {
        public IMPRIMIR()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var conexion = new SQLiteConnection(CONEXION.CADENA))
            {
                try
                {
                    var query = new StringBuilder();
                    query.Append(" SELECT  ");
                    query.Append("id,paciente,doctor,fecha,diagnostico");
                    query.Append(" FROM CONSULTASINTERNAS ");

                    using (var commando = new SQLiteCommand(query.ToString(), conexion))
                    {

                        conexion.Open();

                        SQLiteDataAdapter da = new SQLiteDataAdapter();

                        da.SelectCommand = commando;

                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dataGridView1.DataSource = dt;

                        conexion.Close();
                        label2.Text = " Total de Registros: " + Convert.ToString(dataGridView1.Rows.Count - 1);

                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text) && textBox1.Text.Length > 0)
                label2.Text = " Total de Registros: " + Convert.ToString(dataGridView1.Rows.Count - 1);

            SingelTon.SingelTonConexion.Ejecutar((comando) =>
            {
                var query = new StringBuilder();

                query.Append(" SELECT ");
                query.Append("id,paciente");
                query.Append(" FROM ");
                query.Append(" CONSULTASINTERNAS ");
                query.Append(" WHERE ");
                query.Append(" ID LIKE @BUSQUEDA OR PACIENTE LIKE @BUSQUEDA");
                comando.CommandText = query.ToString();

                comando.Parameters.AddWithValue("@BUSQUEDA", string.Format("%{0}%", textBox1.Text));


                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = comando;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            });
        }

		private void button2_Click(object sender, EventArgs e)
		{
			//WkHtmlToPdf.PdfGenerator gen = new PdfGenerator();
			
		}
	}


}