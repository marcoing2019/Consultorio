using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONSULTORIO_CON_SQLITE.GeneradorDePDF
{
	class Ejemplo
	{
		public Ejemplo()
		{
			var DatagridView1 = new DataGridView();
			// asi inicias los componentes basicos
			GeneradorDePDF.PDF pdf = new GeneradorDePDF.PDF
			{
				TextoDelLogo = "Empresa Acme",
				Imformacion1 = "Hola me llamo roberto <br/>",
				Imformacion2 = "Email:holamunddo@hotmail.com <br/>",
				ImformacionEnLosPies = "esto es un texto cualquierea"
			};

			//asi agregas el contenido de la table 
			pdf.Encabezados.Add(new GeneradorDePDF.Encabezado
			{
				Titulo = "Cabeza1",
				Contenido = "esto es el contenido de cabeza1 "

			});
			pdf.Encabezados.Add(new GeneradorDePDF.Encabezado
			{
				Titulo = "Cabeza2",
				Contenido = "esto es el contenido de cabeza2"

			});

			// aqui escribes la ruta  deonde deseas guadrar esto es un ejemplo tiene que terminar con .pdf
			pdf.GuardarPF(@"C:\Users\Documents\holamundo.pdf");

			// o si deaseas convetir un datagradidview a pdf 
			pdf.GuardarPF(DatagridView1, @"C:\Users\Documents\holamundo.pdf");



		}
	}
}
