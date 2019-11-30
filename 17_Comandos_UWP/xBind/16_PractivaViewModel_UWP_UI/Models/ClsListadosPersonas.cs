using _15_Ejercicio3_UWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static ObservableCollection<ClsPersona> listadoCompletoDePersonas()
        {
            ObservableCollection<ClsPersona> listado = new ObservableCollection<ClsPersona>();


            listado.Add(new ClsPersona("Pedro", "Apellido1", new DateTime()));
            listado.Add(new ClsPersona("PedroManuel", "Apellido2", new DateTime()));
            listado.Add(new ClsPersona("Carlos", "Apellido3", new DateTime()));
            listado.Add(new ClsPersona("Carolina", "Apellido4", new DateTime()));
            listado.Add(new ClsPersona("Pepe", "Apellido5", new DateTime()));

            return listado;
        }

        /// <summary>
        /// Comentario: Este método nos permite obtener un listado de personas, según un nombre.
        /// Si el nombre coincide completa o parcialmente con su inicio este formará parte de la
        /// nueva lista. Es decir, si el parámetro nombre es igual a Pedro y se encuentra un PedroManuel, este
        /// también se almacenará.
        /// </summary>
        /// <returns>ObservableCollection<ClsPersona> listaPersonas</returns>
        public static ObservableCollection<ClsPersona> listadoPersonasSegunNombre(String nombre)
        {
            ObservableCollection<ClsPersona> listaPersonas = new ObservableCollection<ClsPersona>();
            ObservableCollection<ClsPersona> listado = listadoCompletoDePersonas();//Obtenemos el listado completo de personas

            for (int i = 0; i < listado.Count; i++)//Recorremos la lista de personas
            {
                if (filtroCadena(nombre, listado.ElementAt(i).nombre))//Si el nombre cumple el filtrado
                {
                    listaPersonas.Add(listado.ElementAt(i));//Se almacena la persona en la nueva lista
                }
            }

            return listaPersonas;
        }

        /// <summary>
        /// Comentario: Este método nos permite saber si una cadena es igual que otra,
        /// si la segunda cadena es más larga pero comparte los mismos carácteres iniciales 
        /// de la primera se dará por válido.
        /// </summary>
        /// <returns>bool filtroCadena</returns>
        public static bool filtroCadena(String cadena1, String cadena2)
        {
            bool filtroCadena = true;
            int sizeCadena1 = cadena1.Length;
            int sizeCadena2 = cadena2.Length;
            if (sizeCadena1 <= sizeCadena2)
            {
                for (int i = 0; i < sizeCadena1 && filtroCadena; i++)
                {
                    if (cadena1[i] != cadena2[i])
                    {
                        filtroCadena = false;
                    }
                }
            }
            else
            {
                filtroCadena = false;
            }
            return filtroCadena;
        }
    }
}
