using _15_Ejercicio3_UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_PractivaViewModel_UWP_UI.Models
{
    class ClsListadosPersonas
    {
        /// <summary>
        /// Comentario: Este método nos permite obtener un listado completo de personas.
        /// Postcondiciones: La función devuelve un listado del tipo ClsPersona asociado al nombre.
        /// </summary>
        /// <returns>List<ClsPersona> listado</returns>
        public static List<ClsPersona> listadoCompletoDePersonas()
        {
            List<ClsPersona> listado = new List<ClsPersona>();

            for (int i = 0; i < 5; i++)
            {
                listado.Add(new ClsPersona("Desconocido"+(i+1), "Apellido"+(i+1), new DateTime()));
            }

            return listado;
        }
    }
}
