using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CONSULTORIO_CON_SQLITE
{
   public class DATOSPACIENTES
    {
         public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }
        public string EDAD { get; set; }
        public string SEXO { get; set; }
        public string FECHADECITA { get; set; }
        public string CONSULTORIO { get; set; }
        public string DOCTOR { get; set; }
        public string DIRECCION { get; set; }
        public string ID { get; set; }
		//byte 64
        public Image IMAGEN { get; set; }

        public DATOSPACIENTES()
        
        {

        }
    }
}

