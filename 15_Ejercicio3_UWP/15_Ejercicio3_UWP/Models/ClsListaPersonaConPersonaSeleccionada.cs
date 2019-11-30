using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _15_Ejercicio3_UWP.Models
{
    class ClsListaPersonaConPersonaSeleccionada : INotifyPropertyChanged
    {
        private List<ClsPersona> _listaPersonas;
        private ClsPersona _personaSeleccionada;

        public ClsListaPersonaConPersonaSeleccionada()
        {
            _listaPersonas = ClsListaPersonas.ListaPersonas();
            _personaSeleccionada = new ClsPersona();
        }

        public ClsListaPersonaConPersonaSeleccionada(ClsPersona persona)
        {
            _listaPersonas = ClsListaPersonas.ListaPersonas();
            _personaSeleccionada = persona;
        }

        public List<ClsPersona> ListaPersonas
        {
            get
            {
                return _listaPersonas;
            }
            set
            {
                _listaPersonas = value;
                //OnPropertyChanged("ListaPersonas");
                NotifyPropertyChanged();
            }
        }

        public ClsPersona PersonaSeleccionada
        {
            get
            {
                return _personaSeleccionada;
            }
            set
            {
                _personaSeleccionada = value;
                //OnPropertyChanged("PersonaSeleccionada");
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        //protected void OnPropertyChanged(string name)
        //{
        //    if (PropertyChanged != null)//En el caso de que se encuentre instanciado a null
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(name));
        //    }
        //}

        //Segunda forma
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
