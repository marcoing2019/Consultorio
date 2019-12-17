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
    public partial class LISTASDEPACIENTES : Form
    {
        public LISTASDEPACIENTES()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
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
                    query.Append("Id,Nombre,Apellidos,Doctor,Medicamento,Cantidad,Caducidad,Nota");
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
                        label2.Text = " Total de Registros: " + Convert.ToString(dataGridView1.Rows.Count - 1);

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
