using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONSULTORIO_CON_SQLITE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            {
                progressBar1.Value += 1;

                linkLabel1.Text = ("CARGANDO EL SISTEMA PORFABOR ESPERE");

                if (progressBar1.Value == 100)
                {
                    timer1.Stop();

                    this.Hide();
                    CLAVE usuario = new CLAVE();
                    usuario.Show();



                }



            }

        }

    }
}
