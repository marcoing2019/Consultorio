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
    public partial class FARMACIAMENU : Form
    {
        public FARMACIAMENU()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            ALTAFARMACIA farma = new ALTAFARMACIA();
            farma.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            ALMACEN almacen = new ALMACEN();
            almacen.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            REPORTES reporte = new REPORTES();
            reporte.Show();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            MEDICAMENTO medicina = new  MEDICAMENTO();
            medicina.Show();
        }
    }
}
