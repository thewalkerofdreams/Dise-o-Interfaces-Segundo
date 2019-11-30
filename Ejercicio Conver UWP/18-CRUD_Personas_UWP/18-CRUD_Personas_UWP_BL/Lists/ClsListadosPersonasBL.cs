using _05_ADO_ASP.Models;
using _18_CRUD_Personas_UWP_DAL.Lists;
using System.Collections.ObjectModel;

namespace _18_CRUD_Personas_UWP_BL.Lists
{
    public class ClsListadosPersonasBL
    {
        /// <summary>
        /// Nombre: listadoPersonas
        /// Comentario: Este método nos permite obtener un listado de personas de la base de datos.
        /// Dentro se llama al método obtenerListadoDePersonas de la clase clsListadosPersona.
        /// </summary>
        /// <returns>Devuelve un listado de personas (ObservableCollection<ClsPersona>).</returns>
        public static ObservableCollection<ClsPersona> listadoPersonas()
        {
            ClsListadosPersonasDAL clsListadosPersona = new ClsListadosPersonasDAL();
            return clsListadosPersona.obtenerListadoDePersonas();
        }
        
    }
}
