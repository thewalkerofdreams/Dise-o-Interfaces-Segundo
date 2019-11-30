using _05_ADO_ASP.Models;
using _18_CRUD_Personas_UWP_DAL.Handler;
using System;

namespace _18_CRUD_Personas_UWP_BL.Handler
{
    public class ClsPersonaHandler_BL
    {
        /// <summary>
        /// Comentario: Este método nos permite insertar una persona en la base de datos. 
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellidos">Apellidos de la persona</param>
        /// <param name="telefono">Telefono de la persona</param>
        /// <param name="idDepartamento">Id del departamento</param>
        /// <param name="fechaNacimiento">Fecha de nacimiento de la persona</param>
        /// <returns>El método devuelve un valor booleano asociado al nombre, true si se ha conseguido insertar la nueva persona o false en caso contrario.</returns>
        public bool insertarPersona(String nombre, String apellidos, String telefono, DateTime fechaNacimiento, int idDepartamento)
        {
            ClsPersonaHandler_DAL clsPersonaHandler_DAL = new ClsPersonaHandler_DAL();
            return clsPersonaHandler_DAL.insertarPersona(nombre, apellidos, telefono, fechaNacimiento, idDepartamento);
        }

        /// <summary>
        /// Comentario: Este método nos permite insertar una persona en la base de datos. 
        /// </summary>
        /// <param name="persona">Un objeto del tipo ClsPersona</param>
        /// <returns>El método devuelve un valor booleano asociado al nombre, true si se ha conseguido insertar la nueva persona o false en caso contrario.</returns>
        public bool insertarPersona(ClsPersona persona)
        {
            ClsPersonaHandler_DAL clsPersonaHandler_DAL = new ClsPersonaHandler_DAL();
            return clsPersonaHandler_DAL.insertarPersona(persona);
        }

        /// <summary>
        /// Comentario: este método nos permite eliminar una persona de la base de datos.
        /// </summary>
        /// <param name="id">Id de la persona</param>
        /// <returns>El método devuelve un valor booleano asociado al nombre, true si ha conseguido eliminar la persona o false en caso contrario.</returns>
        public bool eliminarPersona(int id)
        {
            ClsPersonaHandler_DAL clsPersonaHandler_DAL = new ClsPersonaHandler_DAL();
            return clsPersonaHandler_DAL.eliminarPersona(id);
        }

        /// <summary>
        /// Comentario: Este método nos permite modificar una persona de la base de datos.
        /// </summary>
        /// <param name="id">Id de la persona</param>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellidos">Apellidos de la persona</param>
        /// <param name="telefono">Telefono de la persona</param>
        /// <param name="fechaNacimiento">Fecha de nacimiento de la persona.</param>
        /// <param name="idDepartamento">Id del departamento</param>
        /// <returns></returns>
        public bool editarPersona(int id, String nombre, String apellidos, String telefono, DateTime fechaNacimiento, int idDepartamento)
        {
            ClsPersonaHandler_DAL clsPersonaHandler_DAL = new ClsPersonaHandler_DAL();
            return clsPersonaHandler_DAL.editarPersona(id, nombre, apellidos, telefono, fechaNacimiento, idDepartamento);
        }

        /// <summary>
        /// Comentario: Este método nos permite modificar una persona de la base de datos.
        /// </summary>
        /// <param name="persona">El tipo ClsPersona</param>
        /// <returns></returns>
        public bool editarPersona(ClsPersona persona)
        {
            ClsPersonaHandler_DAL clsPersonaHandler_DAL = new ClsPersonaHandler_DAL();
            return clsPersonaHandler_DAL.editarPersona(persona);
        }

         /// <summary>
         /// Comentario: Este método nos permite obtener una persona de la base de datos.
         /// </summary>
         /// <param name="id">Id de la persona</param>
         /// <returns>El método devuelve un tipo ClsPersona asociado al nombre, que es la persona buscada o null si esa persona no existe en la base de datos.</returns>
         public ClsPersona obtenerPersona(int id)
        {
            ClsPersonaHandler_DAL clsPersonaHandler_DAL = new ClsPersonaHandler_DAL();
            return clsPersonaHandler_DAL.obtenerPersona(id);
        }
    }
}
