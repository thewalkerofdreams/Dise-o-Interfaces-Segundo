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
    public class ClsListadoCompanias_BL
    {
        /// <summary>
        /// Nombre: obtenerListadoDeCompanias
        /// Comentario: Este método nos permite obtener un listado de las superheroes almacenadas en la base de datos.
        /// Cabecera: public ObservableCollection<ClsCompania> obtenerListadoDeCompanias()
        /// </summary>
        /// <returns>Devuelve un list del tipo ClsCompania</returns>
        public ObservableCollection<ClsCompania> obtenerListadoDeCompanias()
        {
            ClsListadoCompanias_DAL clsListadoCompanias_DAL = new ClsListadoCompanias_DAL();
            return clsListadoCompanias_DAL.obtenerListadoDeCompanias();
        }
    }
}
