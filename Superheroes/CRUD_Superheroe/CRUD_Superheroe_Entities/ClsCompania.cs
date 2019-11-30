using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Superheroe_Entities
{
    public class ClsCompania
    {
        private int _id;
        private String _nombre;

        public ClsCompania()
        {
            _id = 0;
            _nombre = "DEFAULT";
        }

        public ClsCompania(int id, String nombre)
        {
            _id = id;
            _nombre = nombre;
        }

        public ClsCompania(ClsCompania compania)
        {
            _id = compania.Id;
            _nombre = compania.Nombre;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public String Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }
    }
}
