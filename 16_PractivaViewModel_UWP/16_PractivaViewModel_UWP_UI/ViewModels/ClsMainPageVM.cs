using _15_Ejercicio3_UWP.Models;
using _16_PractivaViewModel_UWP_UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _16_PractivaViewModel_UWP_UI.ViewModels
{
    public class ClsMainPageVM : INotifyPropertyChanged //Aquí InotificePropertycha
    {
        //Atributos
        private ClsPersona _personaSeleccionada;
        private List<ClsPersona> _listadoPersonas;

        //Constructor por defecto
        public ClsMainPageVM()
        {
            //Rellenamos el listado de personas
            this._listadoPersonas = ClsListadosPersonas.listadoCompletoDePersonas();
        }

        //Propiedades públicas
        public ClsPersona PersonaSeleccionada
        {
            get{
                return _personaSeleccionada;
            }
            set
            {
                _personaSeleccionada = value;
                NotifyPropertyChanged();
            }
        }

        public List<ClsPersona> ListadoPersonas
        {
            get
            {
                return _listadoPersonas;
            }
        }

        public List<ClsPersona> ClsListadoPersonas { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
