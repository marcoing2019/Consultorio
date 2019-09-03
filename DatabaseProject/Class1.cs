using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace DatabaseProject
{


	public class BaseEntity
	{
		[Indentity]
		public int Id { get; set; }
	}
	
	public  class DatabaseCrud
	{

		public static string GetConnectionString(string key = "Data Source=mydb.db;Version=3;")
		{
			try
			{
				return key;
			}
			catch (Exception e)
			{
			
				// voto el error 
				throw e;
			}

		}
		// static por que es Consola no otra app 
		private static SQLiteConnection con;



		// crear base de datos
		public static void CreateDatabase()
		{
			// instanceo la conexion 
			using (con = new SQLiteConnection(GetConnectionString()))
			{
				try
				{

					string SQLiteQueryCreateDatabase = " Use master; " +
						" CREATE DATABASE testDB; ";

					SQLiteCommand SQLiteCommand = new SQLiteCommand(SQLiteQueryCreateDatabase, con);
					con.Open();
					SQLiteCommand.ExecuteNonQuery();
					var SQLiteQueryCrateTable = " Use testDB; " +
						 "CREATE TABLE Person (" +
						 "Id int IDENTITY(1,1)" +
						 " PRIMARY KEY, LastName " +
						 "varchar(255) NOT NULL, " +
						 "FirstName varchar(255),Age int);";
					SQLiteCommand.CommandText = SQLiteQueryCrateTable;
					SQLiteCommand.ExecuteNonQuery();
					//printo los posibles errores 
					Console.WriteLine("Base de datos creada!");

				}
				catch (Exception e)
				{
					
					// voto el error 
					throw e;
				}
			}

		}
		// necistas una clase que herede de BaseEntity para utilizar esta funcion 

		public static List<T> GetAll<T>() where T : BaseEntity, new()
		{
			using (con = new SQLiteConnection(GetConnectionString()))
			{
				try
				{
					var list = new List<T>();
					StringBuilder SQLiteQuery = new StringBuilder();
					SQLiteQuery.Append("SELECT ");

					var properties = typeof(T).GetProperties();

					string parameters = string.Empty;
					SQLiteCommand SQLiteCommand = new SQLiteCommand();
					for (int i = 0; i < properties.Length; i++)
					{
						string delimiter = (i + 1 < properties.Length) ? "," : string.Empty;
						parameters += $" {properties[i].Name} {delimiter} ";

					}
					SQLiteQuery.Append(parameters);
					SQLiteQuery.Append(string.Format("FROM {0}", typeof(T).Name));

					SQLiteCommand.CommandText = SQLiteQuery.ToString();
					SQLiteCommand.Connection = con;
					con.Open();
					var read = SQLiteCommand.ExecuteReader();
					if (read.HasRows)
					{
						var prop = typeof(T).GetProperties();
						while (read.Read())
						{
							var entity = new T();
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

		public static T Update<T>(T entity) where T : BaseEntity
		{
			using (con = new SQLiteConnection(GetConnectionString()))
			{
				try
				{

					StringBuilder SQLiteQuery = new StringBuilder();
					SQLiteQuery.Append(string.Format(" UPDATE {0} SET", typeof(T).Name));

					var properties = typeof(T).GetProperties().Where(x => !Attribute.IsDefined(x, typeof(IndentityAttribute))).ToArray();

					string parameters = string.Empty;
					SQLiteCommand SQLiteCommand = new SQLiteCommand();
					for (int i = 0; i < properties.Length; i++)
					{

						string delimiter = (i + 1 < properties.Length) ? "," : string.Empty;
						parameters += $" {properties[i].Name} = @{properties[i].Name}{delimiter} ";

						SQLiteCommand.Parameters.AddWithValue($"@{properties[i].Name}", properties[i].GetValue(entity));
					}
					SQLiteQuery.Append($"{parameters} WHERE {nameof(entity.Id)} = @{nameof(entity.Id)};");
					SQLiteCommand.Parameters.AddWithValue($"@{nameof(entity.Id)}", entity.Id);


					SQLiteCommand.CommandText = SQLiteQuery.ToString();
					SQLiteCommand.Connection = con;
					con.Open();
					SQLiteCommand.ExecuteNonQuery();
					

				}
				catch (Exception e)
				{
					
					throw e;
				}

				return entity;

			}
		}
		public static void Delete<T>(T entity) where T : BaseEntity
		{
			using (con = new SQLiteConnection(GetConnectionString()))
			{
				try
				{
					StringBuilder SQLiteQuery = new StringBuilder();
					SQLiteQuery.Append(string.Format(" Delete FROM {0} ", typeof(T).Name));

					SQLiteCommand SQLiteCommand = new SQLiteCommand();

					SQLiteQuery.Append($" WHERE {nameof(entity.Id)} = @{nameof(entity.Id)};");
					SQLiteCommand.Parameters.AddWithValue($"@{nameof(entity.Id)}", entity.Id);

					SQLiteCommand.CommandText = SQLiteQuery.ToString();
					SQLiteCommand.Connection = con;
					con.Open();
					SQLiteCommand.ExecuteNonQuery();
					
				}
				catch (Exception e)
				{
					
					// voto el error 
					throw e;
				}



			}
		}
		public static T Create<T>(T entity) where T : BaseEntity
		{
			using (con = new SQLiteConnection(GetConnectionString()))
			{
				try
				{

					StringBuilder SQLiteQuery = new StringBuilder();
					SQLiteQuery.Append(string.Format(" INSERT INTO {0} ", entity.GetType().Name));
					SQLiteQuery.Append(" ( ");
					var properties = typeof(T).GetProperties().Where(x => !Attribute.IsDefined(x, typeof(IndentityAttribute))).ToArray();

					string parameters = string.Empty;
					string values = string.Empty;
					SQLiteCommand SQLiteCommand = new SQLiteCommand();
					for (int i = 0; i < properties.Length; i++)
					{
						string delimiter = (i + 1 < properties.Length) ? "," : string.Empty;
						parameters += $" {properties[i].Name}{delimiter} ";
						values += $" @{properties[i].Name}{delimiter} ";
						SQLiteCommand.Parameters.AddWithValue($"@{properties[i].Name}", properties[i].GetValue(entity));
					}
					SQLiteQuery.Append($"{parameters}) ");
					SQLiteQuery.Append($" VALUES({values}); ");
					SQLiteQuery.Append(" SELECT SCOPE_IDENTITY() ");
					SQLiteCommand.CommandText = SQLiteQuery.ToString();
					SQLiteCommand.Connection = con;
					con.Open();
					entity.Id = Convert.ToInt32(SQLiteCommand.ExecuteScalar());
					

				}
				catch (Exception e)
				{
					
					throw e;
				}

				return entity;

			}
		}
	}
}
		
