using DatabaseProject.Repository;
using DatabaseProject.Tablas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONSULTORIO
{
    public partial class USUARIOS : Form
    {
        public USUARIOS()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

		private void button1_Click(object sender, EventArgs e)
		{
			// mira la carpeta ejemplos de uso 
			//simpre importa estas dos cosas si va a usar repositorios 
			//using DatabaseProject.Repository;
			//using DatabaseProject.Tablas;
			IRepository<Persona> repo = new Repository<Persona>();
			try
			{
				var reusultado = repo.Agregar(
					new Persona {
					Apellido = txtApellidos.Text,
					Clave = txtClave.Text,
					Nombre = txtNombre.Text,
					Usuario = txtUsuario.Text,
				});
				if (reusultado > 0)
					MessageBox.Show("Usuario creado");
				else
					MessageBox.Show("Usuario No ha podido ser creado");
			}
			catch(Exception error)
			{
				MessageBox.Show("Usuario No ha podido ser creado"+error.Message);
			}
		}
	}
}
