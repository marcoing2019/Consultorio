using DatabaseProject.Repository;
using DatabaseProject.Tablas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Ejemplos_de_Uso
{

	class Ejemplo
	{
		private void ComoUsar()
		{
			// pones arriba using DatabaseProject.Repository y using DatabaseProject.Tablas; donde creamos las classes tabla ;
			IRepository<Persona> repository = new Repository<Persona>();
			// Crear nueva persona la funcion  retorna 0 si no gurado nada 
			repository.Agregar(new Persona { Apellido = "gomez", Clave = "123", Nombre = "pedro" });
			// vamos a leer a perdro de la base de datos aqui solo ocupamos su id  digamos que tiene id 1 esto nos retorna una persona;
			Persona persona = repository.SelecionarConId(new Persona { Id = 1 });
			//vamos a actulizar a pedro para eso nescitams su id le vamos a cambiar el apellido, la variable persona ya tiene este Id
			persona.Apellido = "Escobar";
			repository.Actulizar(persona);
			// opcion2 para actulizar 
			repository.Actulizar(new Persona { Apellido = "Escobarmez", Clave = "123", Nombre = "pedro", Id = 1 });
			//vamos a actulizar a borrar a pedro solo necisitamos un Id 
			//opcion 1 
			repository.BorrarConId(new Persona { Id = 1 });
			//opcion 2 
			repository.BorrarConId(persona);
			// vamos a leer todo lo que hay en la tabla persona 
			ICollection<Persona> personas = repository.SelecionarTodo();

		}
		class Automovil
		{

			[PrimaryKey]// esto es para decirle que es una llave a nuestro repositorio 
			public int Id { get; set; }
			public string Placa { get; set; }
			public string Marca { get; set; }

		}
		private void Como_Usar_Si_Creamos_Una_Nueva_Tabla_en_la_db()
		{
			//digamos que creamos una nueva tabla en la db llamada autos como trabajo con ella ?  
			// primero creamos la classe Atomovil recuerda que la clase debe de tener el msimo nombre que la tabla pero hay alternavias para no tener que hacer esto
			//1. Crea una tabla en la db llamada Automovil por ejemplo 
			//2. Crea la clase  
			//public class Automovil
			//{

			//}
			// especifica las llave Y las columnas 
			//public class Automovil
			//{
			//[PrimaryKey]// esto es para decirle que es una llave a nuestro repositorio 
			//public int Id { get; set; }
			//public string Placa { get; set; }
			//public string Marca { get; set; }
			//}
			// mira como quedo la clase de arriba llamada Automovil 

			//Haora usemos nuestro repositorio generico para hacer operciones simples de crud
			IRepository<Automovil> repositorioAutomovil = new Repository<Automovil>();

			// Crear nueva persona la funcion  retorna 0 si no gurado nada 
			int resultado = repositorioAutomovil.Agregar(new Automovil { Marca = "Mercedez", Placa = "ABC" });
			if (resultado > 0)
			{
				//codigo
				//se guardo correctamente 
			}

			// vamos a leer el automovil de la base de datos aqui solo ocupamos su id  digamos que tiene id 1 esto nos retorna el automovil deseado y lo guardamos en una variable
			Automovil automovil = repositorioAutomovil.SelecionarConId(new Automovil { Id = 1 });

			// haora pemos actulizarla o mostrar los valores al usuario 
			// si quieres mostrar la placa del auto en un texbox facil !
			/*
			 *		texbox1.Text = automovil.Placa;
			 * 
			 */

			//opcion 1 
			// como actulizamos facil ya solo necitamos un id y los y los nuevos valores , en este caso es solamente la placa
			repositorioAutomovil.Actulizar(new Automovil { Marca = "Mercedez", Placa = "ABC2", Id = 1 });

			//opcion 2 
			automovil.Placa = "ABC2";
			// tambien podemos ver si se ha actulizado algo 
			int resultado2 = repositorioAutomovil.Actulizar(automovil);
			if (resultado2 > 0)
			{
				//codigo
				//se guardo correctamente 
			}


			//vamos  a borrar a el auto solo necisitamos un Id 
			//opcion 1 
			repositorioAutomovil.BorrarConId(new Automovil { Id = 1 });
			//opcion 2 
			repositorioAutomovil.BorrarConId(automovil);

			// vamos a leer todo lo que hay en la tabla automovil 

			ICollection<Automovil> automviles = repositorioAutomovil.SelecionarTodo();
			// haora pemos actulizarla o mostrar todos los automoviles en una tabla facil !
			// agrega using System.ComponentModel;

			/*
			 * 	// PRIMERO HACEMOS UN BINDING LE METOMOS NUESTRA VARIBLE automviles
				var bindingList = new BindingList<Automovil>(automviles.ToList());
				var source = new BindingSource(bindingList, null);
				//LUEGO LE DAS EL VALOR DE SOURCE A TU DATA GRID VIEW
				DatagridView1.DataSource = source;
			
			 */


		}

	}
}

