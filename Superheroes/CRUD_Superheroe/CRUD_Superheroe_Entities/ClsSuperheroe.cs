using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Superheroe_Entities
{
    public class ClsSuperheroe
    {
        private int _id;
        private String _nombre;
        private String _apellidos;
        private String _apodo;
        private String _sexo;
        private int _idCompania;
        private byte[] _foto;

        public ClsSuperheroe()
        {
            _id = 0;
            _nombre = "DEFAULT";
            _apellidos = "DEFAULT";
            _apodo = "DEFAULT";
            _sexo = "W";
            _idCompania = 0;
            _foto = null;
        }

        public ClsSuperheroe(int id, String nombre, String apellidos, String apodo, String sexo, int idCompania, byte[] foto)
        {
            _id = id;
            _nombre = nombre;
            _apellidos = apellidos;
            _apodo = apodo;
            _sexo = sexo;
            _idCompania = idCompania;
            _foto = foto;
        }

        public ClsSuperheroe(ClsSuperheroe superheroe)
        {
            _id = superheroe.Id;
            _nombre = superheroe.Nombre;
            _apellidos = superheroe.Apellidos;
            _apodo = superheroe.Apodo;
            _sexo = superheroe.Sexo;
            _idCompania = superheroe.IdCompania;
            _foto = superheroe.Foto;
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

        public String Apellidos
        {
            get
            {
                return _apellidos;
            }
            set
            {
                _apellidos = value;
            }
        }

        public String Apodo
        {
            get
            {
                return _apodo;
            }
            set
            {
                _apodo = value;
            }
        }

        public String Sexo
        {
            get
            {
                return _sexo;
            }
            set
            {
                _sexo = value;
            }
        }

        public int IdCompania
        {
            get
            {
                return _idCompania;
            }
            set
            {
                _idCompania = value;
            }
        }

        public byte[] Foto
        {
            get
            {
                return _foto;
            }
            set
            {
                _foto = value;
            }
        }
    }
}
