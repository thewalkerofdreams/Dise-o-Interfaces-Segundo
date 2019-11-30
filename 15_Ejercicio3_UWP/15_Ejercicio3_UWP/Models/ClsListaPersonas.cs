using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Ejercicio3_UWP.Models
{
    class ClsListaPersonas
    {
        /// <summary>
        /// Comentario: Este método nos permite obtener una lista de personas por defecto.
        /// Posteriormente esto se modificará para trabajar con una base de datos.
        /// </summary>
        /// <returns></returns>
        public static List<ClsPersona> ListaPersonas()
        {
            List<ClsPersona> lista = new List<ClsPersona>();
            lista = new List<ClsPersona>();
            lista.Add(new ClsPersona("Pepe", "Garcia", "799000666", new DateTime(1998, 1, 1), "Calle la piruleta nº1"));
            lista.Add(new ClsPersona("Pedro", "Lobo", "699665334", new DateTime(1996, 1, 1), "Calle la piruleta nº2"));
            lista.Add(new ClsPersona("Lucas", "Jin", "677899445", new DateTime(1993, 1, 1), "Calle la piruleta nº3"));
            lista.Add(new ClsPersona("Maria", "Hernández", "566899644", new DateTime(1968, 1, 1), "Calle la piruleta nº4"));

            return lista;
        }

      
    }
}
