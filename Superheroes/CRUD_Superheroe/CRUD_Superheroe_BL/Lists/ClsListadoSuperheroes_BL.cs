using CRUD_Superheroe_DAL.Lists;
using CRUD_Superheroe_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Superheroe_BL.Lists
{
    public class ClsListadoSuperheroes_BL
    {
        /// <summary>
        /// Nombre: obtenerListadoDeSuperheroes
        /// Comentario: Este método nos permite obtener un listado de las superheroes almacenadas en la base de datos.
        /// Cabecera: public List<ClsPersona> obtenerListadoDeSuperheroes(int idCompania)
        /// </summary>
        /// <paramref name="idCompania"/>
        /// <returns>Devuelve un list del tipo ClsPersona</returns>
        public ObservableCollection<ClsSuperheroe> obtenerListadoDeSeperheroes(int idCompania)
        {
            ClsListadoSuperheroes_DAL clsListadoSuperheroes_DAL = new ClsListadoSuperheroes_DAL();
            return clsListadoSuperheroes_DAL.obtenerListadoDeSuperheroes(idCompania);
        }
    }
}
