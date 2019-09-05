using DatabaseProject.SingelTonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace DatabaseProject.Repository
{
	public class Repository<T>  : IRepository<T>  where T : class
	{
		public int Actulizar(T entity, string tabla =null)
		{
			using (var con = SQLiteConectador.ObtenerConexion)
			{
				try
				{
					if (tabla == null)
						tabla = typeof(T).Name;

					StringBuilder SQLiteQuery = new StringBuilder();
					SQLiteQuery.Append(string.Format(" UPDATE {0} SET", tabla));

					var properties = GetColumnsWithoutKeys();
					var propertiesIds = GetIdColums();

					StringBuilder parameters = new StringBuilder();
					StringBuilder IdsParameters = new StringBuilder();
					SQLiteCommand SQLiteCommand = new SQLiteCommand();

					for (int i = 0; i < properties.Count; i++)
					{

						string delimiter = (i + 1 < properties.Count) ? "," : string.Empty;
						parameters.Append(string.Format("{0} = @{1}{2}", properties[i], properties[i], delimiter));
						SQLiteCommand.Parameters.AddWithValue("@" + properties[i], entity.GetType().GetProperty(properties[i]).GetValue(entity));

					}

					for (int i = 0; i < propertiesIds.Count; i++)
					{
						string delimiter = (i + 1 < properties.Count) ? "AND" : string.Empty;
						parameters.Append(string.Format("({0} = @{1}) {2} ", properties[i], properties[i], delimiter));
						SQLiteCommand.Parameters.AddWithValue("@" + properties[i], entity.GetType().GetProperty(properties[i]).GetValue(entity));

					}
					SQLiteQuery.Append(string.Format("{0} WHERE {1};", parameters.ToString(), IdsParameters.ToString()));
					SQLiteCommand.CommandText = SQLiteQuery.ToString();
					SQLiteCommand.Connection = con;
					con.Open();
					int result = SQLiteCommand.ExecuteNonQuery();
					return result;

				}
				catch (Exception e)
				{

					throw e;
				}



			}


		}



		public int Agregar(T entidad, string tabla = null)
		{
			try
			{
				
				if (tabla == null)
					tabla = typeof(T).Name;

				StringBuilder SQLiteQuery = new StringBuilder();
				SQLiteQuery.Append(string.Format(" INSERT INTO {0} ", tabla));
				SQLiteQuery.Append(" ( ");
				var properties = GetColumnsWithoutKeys();
				var propertiesIds = GetIdColums();

				StringBuilder parameters = new StringBuilder();
				StringBuilder values = new StringBuilder();
				SQLiteCommand SQLiteCommand = new SQLiteCommand();

				for (int i = 0; i < properties.Count; i++)
				{
					string delimiter = (i + 1 < properties.Count) ? "," : string.Empty;
					parameters.Append(string.Format("{0}{1}", properties[i], delimiter));
					values.Append(string.Format("@{0}{1}",properties[i],delimiter));
					SQLiteCommand.Parameters.AddWithValue("@"+properties[i],entidad.GetType().GetProperty(properties[i]).GetValue(entidad));
				}
				SQLiteQuery.Append(string.Format("{0}) ", parameters.ToString()));
				SQLiteQuery.Append(string.Format(" VALUES({0}); ", values.ToString()));
				//SQLiteQuery.Append(" SELECT last_insert_rowid()");
				SQLiteCommand.CommandText = SQLiteQuery.ToString();
				SQLiteCommand.Connection = SQLiteConectador.ObtenerConexion;
				SQLiteConectador.Abrir();
				var result  = SQLiteCommand.ExecuteNonQuery();
				SQLiteConectador.Cerrar();
				return result;
			}


			catch (Exception e)
			{

				throw e;
			}
			finally
			{
				SQLiteConectador.Cerrar();
			}
		}

		public int BorrarConId(T entity, string tabla = null)
		{
			try
			{

				if (tabla == null)
					tabla = typeof(T).Name;

				StringBuilder SQLiteQuery = new StringBuilder();
				SQLiteQuery.Append(string.Format(" DELETE FROM {0} ", tabla));
				SQLiteQuery.Append(" WHERE ");
				var properties = GetIdColums();

				StringBuilder parameters = new StringBuilder();
				
				SQLiteCommand SQLiteCommand = new SQLiteCommand();

				for (int i = 0; i < properties.Count; i++)
				{
					string delimiter = (i + 1 < properties.Count) ? "AND" : string.Empty;
					parameters.Append(string.Format("({0} = @{1}) {2} ", properties[i], properties[i], delimiter));
					SQLiteCommand.Parameters.AddWithValue("@" + properties[i], entity.GetType().GetProperty(properties[i]).GetValue(entity));
				}
				
				SQLiteQuery.Append(string.Format("{0}", parameters));
				SQLiteCommand.CommandText = SQLiteQuery.ToString();
				SQLiteCommand.Connection = SQLiteConectador.ObtenerConexion;
				SQLiteConectador.Abrir();
				var result = SQLiteCommand.ExecuteNonQuery();
				SQLiteConectador.Cerrar();
				return result;
			}


			catch (Exception e)
			{

				throw e;
			}
			finally
			{
				SQLiteConectador.Cerrar();
			}
		}

		public ICollection<T> SelecionarTodo(string tabla = null)
		{
			using (var con = SQLiteConectador.ObtenerConexion)
			{
				try
				{
					if (tabla == null)
						tabla = typeof(T).Name;

					var list = new List<T>();
					StringBuilder SQLiteQuery = new StringBuilder();
					SQLiteQuery.Append("SELECT ");

					var properties = typeof(T).GetProperties();

					string parameters = string.Empty;
					SQLiteCommand SQLiteCommand = new SQLiteCommand();
					for (int i = 0; i < properties.Length; i++)
					{
						string delimiter = (i + 1 < properties.Length) ? "," : string.Empty;
						parameters += string.Format(" {0} {1} ", properties[i].Name,delimiter);

					}
					SQLiteQuery.Append(parameters);
					SQLiteQuery.Append(string.Format("FROM {0}", tabla));

					SQLiteCommand.CommandText = SQLiteQuery.ToString();
					SQLiteCommand.Connection = con;
					con.Open();
					var read = SQLiteCommand.ExecuteReader();
					if (read.HasRows)
					{
						var prop = typeof(T).GetProperties();
						while (read.Read())
						{
							var entity = Activator.CreateInstance<T>();
							for (int i = 0; i < prop.Length; i++)
							{
								var value = read[prop[i].Name];
								prop[i].SetValue(entity, Convert.ChangeType(value, Nullable.GetUnderlyingType(prop[i].PropertyType) ?? prop[i].PropertyType));
							}
							list.Add(entity);
						}

					}
					return list;


				}
				catch (Exception e)
				{

					throw e;
				}



			}
		}

		public T SelecionarConId(T entity , string tabla = null)
		{
			try
			{

				if (tabla == null)
					tabla = typeof(T).Name;

				StringBuilder SQLiteQuery = new StringBuilder();
				SQLiteQuery.Append(" SELECT ");
				
				var propIds = GetIdColums();
				var properties = entity.GetType().GetProperties().Where(e => !e.PropertyType.GetTypeInfo().IsGenericType).Select(e => e.Name).ToList();
				StringBuilder parameters = new StringBuilder();

				SQLiteCommand SQLiteCommand = new SQLiteCommand();

				for (int i = 0; i < properties.Count; i++)
				{

					string delimiter = (i + 1 < properties.Count) ? "," : string.Empty;
					parameters.Append(string.Format("{0}{1}", properties[i], delimiter));
					
				}
				SQLiteQuery.Append(string.Format(" FROM {0}", tabla));
				SQLiteQuery.Append(" WHERE ");
				for (int i = 0; i < propIds.Count; i++)
				{
					string delimiter = (i + 1 < propIds.Count) ? "AND" : string.Empty;
					parameters.Append(string.Format("({0} = @{1}) {2} ", propIds[i], propIds[i], delimiter));
					SQLiteCommand.Parameters.AddWithValue("@" + propIds[i], entity.GetType().GetProperty(propIds[i]).GetValue(entity));
				}

				SQLiteQuery.Append(string.Format("{0}", parameters));
				SQLiteCommand.CommandText = SQLiteQuery.ToString();
				SQLiteCommand.Connection = SQLiteConectador.ObtenerConexion;
				SQLiteConectador.Abrir();
				var result = Activator.CreateInstance<T>();
				var read = SQLiteCommand.ExecuteReader();
				if (read.HasRows)
				{
					var prop = typeof(T).GetProperties();
					while (read.Read())
					{
						
						for (int i = 0; i < prop.Length; i++)
						{
							var value = read[prop[i].Name];
							prop[i].SetValue(result, Convert.ChangeType(value, Nullable.GetUnderlyingType(prop[i].PropertyType) ?? prop[i].PropertyType));
						}
					
					}
					SQLiteConectador.Cerrar();
					return result;
				}

				
				throw new Exception("El Dato no ha sido encontrado");
			}


			catch (Exception e)
			{

				throw e;
			}
			finally
			{
				SQLiteConectador.Cerrar();
			}
		}

		private List<string> GetColumnsWithoutKeys()
		{
			return typeof(T)
					.GetProperties()
					.Where(e => !Attribute.IsDefined(e, typeof(PrimaryKeyAttribute)) && !e.PropertyType.GetTypeInfo().IsGenericType)
					.Select(e => e.Name).ToList();
		}

		private List<string> GetIdColums()
		{
			return typeof(T)
					.GetProperties()
					.Where(e => Attribute.IsDefined(e, typeof(PrimaryKeyAttribute)) && !e.PropertyType.GetTypeInfo().IsGenericType)
					.Select(e => e.Name).ToList();
		}


	}
}
