using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;
using CONSULTORIO_CON_SQLITE;

namespace CONSULTORIO_CON_SQLITE
{
    public partial class ALTAS_PACIENTES : Form
    {    
         private DATOSPACIENTES Mapeo()
			
         {
		
                 return  new DATOSPACIENTES
             {
                 ID     = textBox1.Text,
                 NOMBRE = textBox2.Text,
                 APELLIDOS = textBox3.Text,
                 EDAD = textBox4.Text,
                 SEXO = textBox5.Text,
                 FECHADECITA = textBox6.Text,
                 CONSULTORIO = textBox7.Text,
                 DOCTOR = textBox8.Text,
                 DIRECCION = textBox9.Text,

                
             };
         }
    
		

        public ALTAS_PACIENTES()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(dialog.FileName);

                button1.Tag = File.ReadAllBytes(dialog.FileName);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Procedo a realizar la actualización del registro en la Base de Datos.

            try
            {
                var cambios = new Repositorio().EditarDATOSPACI(Mapeo());


          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                // esto es todo lo que tienes que hacer haora 
                var result = new Repositorio().CrearDATOSPACI(Mapeo());
               

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

        private void button5_Click(object sender, EventArgs e)
        {
            String Sql = "DELETE  FROM ALTASPACIENTES  where  ID=" + textBox1.Text;

            SQLiteConnection con = new SQLiteConnection("Data Source=USUARIOS.db;Version=3;");
            SQLiteCommand cmd = new SQLiteCommand(Sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)

                    linkLabel1.Text = " LOS REGISTROS SE ELIMINARON CORRECTAMENTE , YA PUEDE PROCEDER CON SU NUEVO REGISTRO";

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";              
                pictureBox1.Image = null;
                textBox1.Focus();


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.ToString());

            }
            finally
            {

            }
            con.Close();

        }

        public void LimpiarFormulario()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            pictureBox1.Image = null;
            textBox1.Focus();
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void button6_Click(object sender, EventArgs e)
        {
          LimpiarFormulario();
            linkLabel1.Text = "SUS CAMPOS SE LIMPIARON PARA SU NUEVO REGISTRO";
        }

        private Image ConvertirBytesEnImagen(byte[] bytes)
        {

            //vamos a usar stream es algo que utiliza el systema operativo para trabajar con archivos este es bueno meterlo en un using 
            if (bytes != null) // checkamos que los bytes no esten nullos 
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            //retornamos null por hoara si no hay bites 
            return null;
        }

    }
}