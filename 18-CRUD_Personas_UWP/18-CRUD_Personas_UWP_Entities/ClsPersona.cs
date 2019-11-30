﻿using System;
using System.ComponentModel;
namespace _05_ADO_ASP.Models
{
    public class ClsPersona : INotifyPropertyChanged
    {
        //Atributos privados
        private int _id;
        private string _nombre;
        private string _apellidos;
        private string _telefono;
        private String _direccion;
        private byte[] _fotoPersona;
        private int _idDepartamento;
        private DateTime _fechaNacimiento;

        public event PropertyChangedEventHandler PropertyChanged;

        //Constructor por defecto
        public ClsPersona()
        {
            _id = 0;
            _nombre = "DEFAULT";
            _apellidos = "DEFAULT";
            _telefono = "000000000";
            _fechaNacimiento = new DateTime();
            _direccion = "DEFAULT";
            _idDepartamento = 0;
            _fotoPersona = null;
        }

        //Constructor con parámetros
        public ClsPersona(String nombre, String apellidos, String telefono, DateTime fechaNacimiento)
        {
            _id = 0;
            _nombre = nombre;
            _apellidos = apellidos;
            _telefono = telefono;
            _direccion = "DAFAULT";
            _fechaNacimiento = fechaNacimiento;
            _idDepartamento = 0;
            _fotoPersona = null;
        }

        public ClsPersona(int id, String nombre, String apellidos, String telefono, DateTime fechaNacimiento, int idDepartamento)
        {
            _id = id;
            _nombre = nombre;
            _apellidos = apellidos;
            _telefono = telefono;
            _direccion = "DEFAULT";
            _fechaNacimiento = fechaNacimiento;
            _idDepartamento = idDepartamento;
            _fotoPersona = null;
        }

        public ClsPersona(String nombre, String apellidos, DateTime fechaNacimiento)
        {
            _id = 0;
            _nombre = nombre;
            _apellidos = apellidos;
            _telefono = "000000000";
            _direccion = "DAFAULT";
            _fechaNacimiento = fechaNacimiento;
            _idDepartamento = 0;
            _fotoPersona = null;
        }

        public ClsPersona(String nombre, String apellidos, DateTime fechaNacimiento, String direccion)
        {
            _id = 0;
            _nombre = nombre;
            _apellidos = apellidos;
            _telefono = "000000000";
            _direccion = direccion;
            _fechaNacimiento = fechaNacimiento;
            _idDepartamento = 0;
            _fotoPersona = null;
        }

        //Propiedades públicas
        public int id
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

        public int idDepartamento
        {
            get
            {
                return _idDepartamento;
            }
            set
            {
                _idDepartamento = value;
            }
        }

        public byte[] fotoPersona
        {
            get
            {
                return _fotoPersona;
            }
            set
            {
                _fotoPersona = value;
            }
        }

        //[Required(ErrorMessage = "Campo obligatorio")]
        public string nombre
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

        public string apellidos
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

        public string telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
            }
        }

        public string direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
            }
        }

        public DateTime fechaNacimiento
        {
            get
            {
                return _fechaNacimiento;
            }
            set
            {
                _fechaNacimiento = value;
            }
        }

        /// <summary>
        /// Comentario: Esta función nos permite obtener la edad de la persona.
        /// Postcondiciones: La función devuelve un entero asociado al nombre, 
        /// que es la edad de la persona. Si la fecha de nacimiento tiene un valor
        /// por defecto la función devuelve -1.
        /// </summary>
        /// <returns></returns>
        public int getEdad()
        {
            int edad = -1;
            if (_fechaNacimiento != new DateTime())
            {
                edad = aniosEntreDateTimes(_fechaNacimiento, DateTime.Now);  
            }

            return edad;
        }
        /// <summary>
        /// Comentario: Como no puedo sobreecribir ToString he tenido que crear esta función.
        /// </summary>
        /// <returns></returns>
        public String mostrarPersona()
        {
            string mensaje;
            if (_telefono.Equals("000000000") || _telefono == null)
            {
                mensaje = $"{_nombre} {_apellidos} con edad de {getEdad()} años";
            }
            else
            {
                mensaje = $"{_nombre} {_apellidos} con edad de {getEdad()} años y telefono {_telefono}";
            }
            return mensaje;
        }
        /// <summary>
        /// Comentario: Esta función nos permite obtener la diferencia de años entre dos fechas.
        /// Precondiciones: fecha1 debe ser menor o igual que fecha2.
        /// Postcondiciones: La función devuelve un número entero asociado al nombre, que son
        /// los años de diferencia.
        /// </summary>
        /// <param name="fecha1"></param>
        /// <param name="fecha2"></param>
        /// <returns></returns>
        private int aniosEntreDateTimes(DateTime fecha1, DateTime fecha2)
        {
            int years = fecha2.Year - fecha1.Year;

            if (years != 0 && ((fecha1.Month > fecha2.Month) || (fecha1.Month == fecha2.Month && fecha1.Day > fecha2.Day)))
            {
                years--;
            }
            return years;
        }
    }
}