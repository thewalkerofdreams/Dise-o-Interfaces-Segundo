using _18_CRUD_Personas_UWP_DAL.Handler;
using _18_CRUD_Personas_UWP_Entities;

namespace _18_CRUD_Personas_UWP_BL.Handler
{
    public class ClsDepartamentoHandler_BL
    {
        /// <summary>
        /// Comentario: Este método nos permite obtener un departamento de la base de datos.
        /// </summary>
        /// <param name="id">Id del departamento</param>
        /// <returns>El método devuelve un clsDepartamento asociado al nombre o null, si no se ha encontrado un departamento con esa id en la base de datos.</returns>
        public clsDepartamento obtenerDepartamento(int id)
        {
            ClsDepartamentoHandler_DAL clsDepartamentoHandler_DAL = new ClsDepartamentoHandler_DAL();
            return clsDepartamentoHandler_DAL.obtenerDepartamento(id);
        }
    }
}
