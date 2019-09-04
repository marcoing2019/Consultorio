using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Repository
{
	public interface IRepository<T>
	{
		/// <summary>
		///Este metodo es usado para crear un simple crud de crear
		/// </summary>
		/// <param name="columnas">nombre de las columnas</param>
		/// <returns>Retorna el numero de filas afectadas</returns>
		int Agregar(T entity, string tabla = null);
		/// <summary>
		///Este metodo es usado para crear un simple crud de actulizar   
		/// </summary>
		/// <param name="columnas">nombre de las columnas</param>
		/// <returns>Retorna el numero de filas afectadas</returns>
		int Actulizar(T entity, string tabla = null);
		/// <summary>
		///Este metodo es usado para crear un simple crud de actulizar   
		/// </summary>
		/// <param name="columnas">nombre de las columnas</param>
		/// <returns>Retorna el numero de filas afectadas</returns>
		int BorrarConId(T entity, string tabla = null);

		T SelecionarConId(T entity, string tabla = null);

		ICollection<T> SelecionarTodo(string tabla = null);

	}
}
