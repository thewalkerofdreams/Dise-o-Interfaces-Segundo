using _18_CRUD_Personas_UWP_DAL.Lists;
using _18_CRUD_Personas_UWP_Entities;
using System.Collections.ObjectModel;

namespace _18_CRUD_Personas_UWP_BL.Lists
{
    public class ClsListadosDepartamentosBL
    {
        /// <summary>
        /// Comentario: Este método nos permite obtener todos los departamentos de la base de datos.
        /// </summary>
        /// <returns>El método devuelve una lista del tipo clsDepartamento, que son todos los departamentos de la base de datos.</returns>
        public static ObservableCollection<clsDepartamento> obtenerListadoDeDepartamentos()
        {
            return ClsListadosDepartamentosDAL.obtenerListadoDeDepartamentos();
        }

    }
}
