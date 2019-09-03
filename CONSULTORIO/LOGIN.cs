﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseProject;
using DatabaseProject.Tablas;

namespace CONSULTORIO
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            USUARIOS usuario = new USUARIOS();
            usuario.Show();

        }

		private void button1_Click(object sender, EventArgs e)
		{
			var persona = DatabaseCrud.GetAll<Persona>().Where(x => x.Clave == textBox2.Text && x.Usuario == textBox1.Text).FirstOrDefault();
			if (persona == null)
				MessageBox.Show("Usuario no encontrado!");
			else
				MessageBox.Show("Usuario Encontrado");
		}
	}
}
