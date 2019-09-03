using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Tablas
{
	public class Persona : BaseEntity
	{

		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Clave { get; set; }
		public string Usuario { get; set; }
		//public byte[] Foto { get; set; }


	}
}
