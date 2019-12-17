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
    public partial class INFORMEPACI : Form
    {
        public INFORMEPACI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {          
                SQLiteConnection conexion = new SQLiteConnection("Data Source=USUARIOS.db;Version=3;");

                SQLiteDataAdapter da= new SQLiteDataAdapter(" Select * from consultas where fechadeconsulta between '" + dateTimePicker1.Value.ToString() + "'and'" + dateTimePicker2.Value.ToString() + "'", conexion);

                DataTable sd = new DataTable();

                da.Fill(sd);

                dataGridView1.DataSource = sd;

                label1.Text = " Total de Registros: " + Convert.ToString(dataGridView1.Rows.Count - 1);
            }

        private void INFORMEPACI_Load(object sender, EventArgs e)
        {

        }
    }
    }

