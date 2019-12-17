//using Microsoft.ReportingServices.DataProcessing;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using CONSULTORIO_CON_SQLITE;

namespace CONSULTORIO_CON_SQLITE
{
    
       public static class ExtencionesImage
    {
        // PROCEDIMIENTO PARA GUARDAR  DATOS
        // esto es una funcion una caja que retorna un valor con inputs o sin inputs 
           public static byte[] ConvertirImagenABytes(this Image image)
        {
            // nose por que vota error aqui es algo con las imagenes voy a veriguar
            if (image != null)
            {         
              using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    try
                    {
                        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        return ms.GetBuffer();
                    }
                    catch(Exception )
                    {

                    }
                }
            }
            return null;

        }
    }
    // aqui debes de meter tus llamdas ala db 
    public enum Aciones
    {
        Actulizar,
        Crear,
        Eliminar
    }
    public static class ContenedorDeQuerys
    {
        public static SQLiteCommand ComandoParaALTAS_PACIENTES(this SQLiteConnection con, DATOSPACIENTES entidad, Aciones aciones)
        {
            SQLiteCommand cmd = new SQLiteCommand(ContenedorDeQuerys.QueryParaDATOSPACI(aciones), con);
            if(aciones == Aciones.Crear || aciones == Aciones.Actulizar)
            cmd.Parameters.AddWithValue("@nombre", entidad.NOMBRE);
            cmd.Parameters.AddWithValue("@apellidos", entidad.APELLIDOS);
            cmd.Parameters.AddWithValue("@edad", entidad.EDAD);
            cmd.Parameters.AddWithValue("@sexo", entidad.SEXO);
            cmd.Parameters.AddWithValue("@fechadecita", entidad.FECHADECITA);
            cmd.Parameters.AddWithValue("@consultorio", entidad.CONSULTORIO);
            cmd.Parameters.AddWithValue("@doctor", entidad.DOCTOR);
            cmd.Parameters.AddWithValue("@direccion", entidad.DIRECCION);            
            cmd.Parameters.AddWithValue("@imagen", entidad.IMAGEN.ConvertirImagenABytes());
            if (aciones == Aciones.Eliminar || aciones == Aciones.Actulizar)
                cmd.Parameters.AddWithValue("@id", entidad.ID);
            return cmd;

        }
        public static string QueryParaDATOSPACI(Aciones aciones)
        {
            var query = new StringBuilder();
            query.Append((aciones == Aciones.Actulizar) ? "UPDATE ALTASPACIENTES SET " : (aciones == Aciones.Crear) ? "INSERT INTO DATOSPACI " : "DELETE FROM DATOSPACI ");
            switch (aciones)
            {

                case Aciones.Actulizar:
                    query.Append(" NOMBRE = @nombre,");
                    query.Append(" APELLIDOS = @apellidos,");
                    query.Append(" EDAD = @edad,");
                    query.Append(" SEXO = @sexo,");
                    query.Append(" TELEFONO = @telefono,");
                    query.Append(" FECHADECITA = @fechadecita,");
                    query.Append("CONSULTORIO = @consultorio,");
                    query.Append("DOCTOR = @doctor,");
                    query.Append("IMAGEN = @imagen ");
                    query.Append("WHERE ID =@id");
                    break;

                case Aciones.Crear:
                    query.Append("(NOMBRE, APELLIDOS, EDAD,SEXO,TELEFONO,FECHADECITA,CONSULTORIO,DOCTOR,IMAGEN)");
                    query.Append(" VALUES (@nombre, @apellidos, @edad,@sexo, @telefono,@fechadecita,@consultorio,@doctor,@imagen); ");
                    break;

                //VALUES (value1, value2, value3, ...);")

                case Aciones.Eliminar:
                    query.Append("WHERE ID =@id");
                    break;
                default:
                    throw new Exception("No se pudo crear la cadena");

            }
            return query.ToString();

        }
    }
    public class Repositorio
    {
        private const string Cadena = "Data Source=USUARIOS.db;Version=3;";
        public int EditarDATOSPACI(DATOSPACIENTES entidad)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(Cadena))
                {

                    if (entidad == null)
                        throw new ArgumentNullException();

                    con.Open();
                    // no repitas tanto codgo usa funciones para resiclar
                    var result = con.ComandoParaALTAS_PACIENTES(entidad, Aciones.Actulizar).ExecuteNonQuery();
                    return result;

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }
        public int BorrarALTASPACIENTES(string id)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(Cadena))
                {

                    if (id == null)
                        throw new ArgumentNullException();

                    con.Open();
                    // no repitas tanto codgo usa funciones para resiclar
                    var result = con.ComandoParaALTAS_PACIENTES(new DATOSPACIENTES { ID = id }, Aciones.Crear).ExecuteNonQuery();
                    return result;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int CrearDATOSPACI(DATOSPACIENTES entidad)
        {
            try
            {
                using (var conexion = new SQLiteConnection(Cadena))
                {

                    if (entidad == null)
                        throw new ArgumentNullException();

                    conexion.Open();
                    // no repitas tanto codgo usa funciones para resiclar
                    var result = conexion.ComandoParaALTAS_PACIENTES(entidad, Aciones.Crear).ExecuteNonQuery();
                    return result;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

}
