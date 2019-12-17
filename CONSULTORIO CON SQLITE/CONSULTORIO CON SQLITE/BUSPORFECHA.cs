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
    public partial class BUSPORFECHA : Form
    {
        public BUSPORFECHA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text) && textBox1.Text.Length > 0)
                label4.Text = " Total de Registros: " + Convert.ToString(dataGridView1.Rows.Count - 1);
                linkLabel1.Text ="SU FECHA INGRESADA FUE ENCONTRADA";

			SingelTon.SingelTonConexion.Ejecutar((comando) =>

			  {
				  var query = new StringBuilder();

				  query.Append(" SELECT ");
				  query.Append(" ID,NOMBRE,FECHADECITA,DOCTOR ");
				  query.Append("FROM");
				  query.Append(" AGENDA ");
				  query.Append(" WHERE ");
				  query.Append(" ID LIKE @BUSQUEDA OR NOMBRE LIKE @BUSQUEDA OR FECHADECITA LIKE @BUSQUEDA ");
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