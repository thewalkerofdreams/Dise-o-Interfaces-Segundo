using CRUD_Superheroe_DAL.Handlers;
using CRUD_Superheroe_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Superheroe_BL.Handler
{
    public class ClsSuperheroeHandler_BL
    {
        /// <summary>
        /// Comentario: Este método nos permite modificar un heroe de la base de datos.
        /// </summary>
        /// <param name="superheroe">El tipo ClsSuperheroe</param>
        /// <returns></returns>
        public bool editarSuperheroe(ClsSuperheroe superheroe)
        {
            ClsSuperheroeHandler_DAL clsSuperheroeHandler_DAL = new ClsSuperheroeHandler_DAL();
            return clsSuperheroeHandler_DAL.editarSuperheroe(superheroe);
        }

        /// <summary>
        /// Comentario: Este método nos permite eliminar un heroe de la base de datos.
        /// </summary>
        /// <param name="id">Id del heroe</param>
        /// <returns>El método devuelve un valor booleano asociado al nombre, true si ha conseguido eliminar al heroe o false en caso contrario.</returns>
        public bool eliminarSuperheroe(int id)
        {
            ClsSuperheroeHandler_DAL clsSuperheroeHandler_DAL = new ClsSuperheroeHandler_DAL();
            return clsSuperheroeHandler_DAL.eliminarSuperheroe(id);
        }

        /// <summary>
        /// Comentario: Este método nos permite insertar un superheroe en la base de datos. 
        /// </summary>
        /// <param name="superheroe">Un objeto del tipo ClsSuperheroe</param>
        /// <returns>El método devuelve un valor booleano asociado al nombre, true si se ha conseguido insertar el nuevo heroe o false en caso contrario.</returns>
        public bool insertarPersona(ClsSuperheroe superheroe)
        {
            ClsSuperheroeHandler_DAL clsSuperheroeHandler_DAL = new ClsSuperheroeHandler_DAL();
            return clsSuperheroeHandler_DAL.insertarPersona(superheroe);
        }

        /// <summary>
        /// Comentario: Este método nos permite obtener un superheroe de la base de datos.
        /// </summary>
        /// <param name="id">Id del superheroe</param>
        /// <returns>El método devuelve un tipo ClsSuperheroe asociado al nombre, que es el superheroe buscado o null si ese heroe no existe en la base de datos.</returns>
        public ClsSuperheroe obtenerSuperheroe(int id)
        {
            ClsSuperheroeHandler_DAL clsSuperheroeHandler_DAL = new ClsSuperheroeHandler_DAL();
            return clsSuperheroeHandler_DAL.obtenerSuperheroe(id);
        }
    }
}
