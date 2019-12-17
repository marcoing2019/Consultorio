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
    public partial class CLAVE : Form
    {
       
        public CLAVE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        
        {
            Validarusuario();
        }
        // METODO PARA VALIDAR USUARIO
        SQLiteDataReader leer;
        void Validarusuario()
        {
#if DEBUG
			MENU frmmenu = new MENU();
			frmmenu.Show();
#else
			SingelTon.SingelTonConexion.Ejecutar((cmd) =>
			{

				string select = "SELECT * FROM DATOS where USUARIO ='" + textBox1.Text + "'and CLAVE='" + textBox2.Text + "'";
				try
				{
					cmd.CommandText = select;
					// esto es un reader 
					leer = cmd.ExecuteReader();
					var hasUser = leer.Read();
					leer.Close();
					if (hasUser)
					{
						this.Hide();
						MENU frmmenu = new MENU();
						frmmenu.Show();
						
					}
					else linkLabel2.Text = "¿ No Tienes una Cuenta ,   Registrate ?";
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			});
#endif


		}


		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            USUARIOS usu = new USUARIOS();
             usu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        bool Estadochekado = true;
        private void pictureasterisco(object sender, EventArgs e)
     {
            if (Estadochekado == false)
            {
                if (textBox2.PasswordChar == '*')

                  {
                    textBox2.PasswordChar = '\0';
                  }                
         
               }
             
            else
            {
                textBox2.PasswordChar ='*';
            }

          }
     }
               
}


