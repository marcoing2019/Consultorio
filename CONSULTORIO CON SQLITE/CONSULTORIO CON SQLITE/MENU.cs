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
    public partial class MENU : Form
    {
        public MENU()
        {
            InitializeComponent();
        }

        private void bUSCARPACIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ALTAS_PACIENTES pacientes = new ALTAS_PACIENTES();
            pacientes.Show();
        }

        private void bUSCARPACIENTESToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CONSULTAS consul = new CONSULTAS();
            consul.Show();
        }

        private void cITASAGENDASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AGENDADECITAS agenda = new AGENDADECITAS();
            agenda.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iNFORMEPACIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            INFORMEPACI informe = new INFORMEPACI();
            informe.Show();
        }

        private void cONSULTASToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FARMACIAMENU medicina = new  FARMACIAMENU();
            medicina.Show();

        }

        private void lISTASDEPACIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LISTASDEPACIENTES pacientes = new LISTASDEPACIENTES();
            pacientes.Show();
        }

        private void cONSULTAINTERNAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CONSULTAINTERNA consulta = new CONSULTAINTERNA();
            consulta.Show();
        }

        private void RESETAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RESETA reseta = new RESETA();
            reseta.Show();
        }
    }
}  

        
   