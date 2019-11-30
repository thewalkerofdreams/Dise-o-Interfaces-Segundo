using CRUD_Superheroe_BL.Lists;
using CRUD_Superheroe_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Superheroe_UI.Utilities
{
    public class ClsBusquedasPersonalizadas
    {
        /// <summary>
        /// Comentario: Este método nos permite obtener un listado de superheroes, según un nombre.
        /// Si el nombre coincide completa o parcialmente con su inicio este formará parte de la
        /// nueva lista. Es decir, si el parámetro nombre es igual a Pedro y se encuentra un PedroManuel, este
        /// también se almacenará.
        /// </summary>
        /// <returns>ObservableCollection<ClsPersona> listaPersonas</returns>
        public ObservableCollection<ClsSuperheroe> listadoHeroesSegunNombre(String nombre, int idCompania)
        {
            ObservableCollection<ClsSuperheroe> listaPersonas = new ObservableCollection<ClsSuperheroe>();
            ClsListadoSuperheroes_BL clsListadoSuperheroes_BL = new ClsListadoSuperheroes_BL();
            ObservableCollection<ClsSuperheroe> listado = null;
            try
            {
                listado = clsListadoSuperheroes_BL.obtenerListadoDeSeperheroes(idCompania);//Obtenemos el listado completo de superheroes de una compañia

                for (int i = 0; i < listado.Count; i++)//Recorremos la lista de heroes
                {
                    if (filtroCadena(nombre, (listado.ElementAt(i).Nombre + " " + listado.ElementAt(i).Apellidos)))//Si el nombre cumple el filtrado
                    {
                        listaPersonas.Add(listado.ElementAt(i));//Se almacena el heroe en la nueva lista
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return listaPersonas;
        }

        /// <summary>
        /// Comentario: Este método nos permite saber si una cadena es igual que otra,
        /// si la segunda cadena es más larga pero comparte los mismos carácteres iniciales 
        /// de la primera se dará por válido.
        /// Este método es utilizado en el método listadoPersonasSegunNombre.
        /// </summary>
        /// <returns>bool filtroCadena</returns>
        private bool filtroCadena(String cadena1, String cadena2)
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
