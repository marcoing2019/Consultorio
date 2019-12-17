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
    public partial class AGENDADECITAS : Form
    {
        public AGENDADECITAS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AGENDAR agenda = new AGENDAR();
            agenda.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DIRECTORIO direc = new DIRECTORIO();
            direc.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            BUSQUEDAGENERAL bus = new BUSQUEDAGENERAL();
            bus.Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            BUSPORFECHA buscar = new BUSPORFECHA();
            buscar.Show();
            this.Close();
        }
    }
}
