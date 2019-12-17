using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pechkin;

namespace CONSULTORIO_CON_SQLITE.GeneradorDePDF
{
	public class Encabezado
	{
		public string Titulo { get; set; }
		public string Contenido { get; set; }
	}
	public class PDF
	{
		public string TextoDelLogo { get; set; }
		public string Imformacion1 { get; set; }
		public string Imformacion2 { get; set; }
		public string ImformacionEnLosPies { get; set; }
		public List<Encabezado> Encabezados { get; set; } = new List<Encabezado>();

		private bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
		{
			try
			{
				// Open file for reading
				FileStream _FileStream = new FileStream(_FileName, FileMode.Create, FileAccess.Write);
				// Writes a block of bytes to this stream using data from  a byte array.
				_FileStream.Write(_ByteArray, 0, _ByteArray.Length);

				// Close file stream
				_FileStream.Close();

				return true;
			}
			catch (Exception _Exception)
			{
				Console.WriteLine("Exception caught in process while trying to save : {0}", _Exception.ToString());
			}

			return false;
		}
		public bool GuardarPF(string ruta)
		{
			return ByteArrayToFile(ruta, GenerarPDFBytes());
		}

		public byte[] GenerarPDFBytes()
		{

			byte[] pdfContent = new SimplePechkin(new GlobalConfig()).Convert(this.ToString());
			return pdfContent;
		}
		private string ParserHeaderBodyFooter()
		{
			var headervalues = new StringBuilder();
			var bodyValues = new StringBuilder();
			var footer = string.Format(HtmlTemplates.FooterCredits, ImformacionEnLosPies);
			Encabezados.ForEach((x) =>
			{
				headervalues.Append(string.Format(HtmlTemplates.HeaderValues, x.Titulo));
				bodyValues.Append(string.Format(HtmlTemplates.BodyValues, x.Contenido));
			});
			var header = string.Format(HtmlTemplates.TitleContainer, headervalues.ToString());
			var body = string.Format(HtmlTemplates.BodyContainer, bodyValues.ToString());
			return string.Format(HtmlTemplates.TheTable, header, body, footer);
		}
		public override string ToString()
		{
			var logo = string.Format(HtmlTemplates.LogotextTop, TextoDelLogo);
			var midinfo = string.Format(HtmlTemplates.MidInfo, Imformacion1,Imformacion2);
			var table = ParserHeaderBodyFooter();


			return string.Format(HtmlTemplates.TheContainer, logo,midinfo,table, HtmlTemplates.TheStyles);
		}
	}
}
