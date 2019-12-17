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
    public partial class BUSCAPACI : Form
    {
        public BUSCAPACI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BUSCAPACI_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text) && textBox1.Text.Length > 0)
                label2.Text = " TOTAL DE REGISTROS ENCONTRADOS EN LA BASE " + Convert.ToString(dataGridView1.Rows.Count - 1);


			SingelTon.SingelTonConexion.Ejecutar((comando) =>

			  {
				  //codigo incompleto 
				  var query = new StringBuilder();
				  query.Append(" SELECT ");
				  query.Append("NOMBRE ");
				  query.Append("FROM");
				  query.Append("");
				  query.Append(" WHERE ");

				  query.Append("(NOMBRE LIKE%@BUSQUEDA%) OR (ID LIKE @BUSQUEDA%)");
				  comando.CommandText = query.ToString();

				

			  });

            
        }
    }
}

                        

                            

                   
                
                
