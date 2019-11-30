using _15_Ejercicio3_UWP.Models;
using _16_PractivaViewModel_UWP_UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace _16_PractivaViewModel_UWP_UI.ViewModels
{
    public class ClsMainPageVM : INotifyPropertyChanged //Aquí InotificePropertycha
    {
        //Atributos
        private ClsPersona _personaSeleccionada;
        private ObservableCollection<ClsPersona> _listadoPersonas;
        private String _nombreBusqueda; //Le añado un nombre de busqueda para el comando

        //Constructor por defecto
        public ClsMainPageVM()
        {
            //Rellenamos el listado de personas
            this._listadoPersonas = ClsListadosPersonas.listadoCompletoDePersonas();
            this._nombreBusqueda = "";
        }

        //Propiedades públicas
        public ClsPersona PersonaSeleccionada
        {
            get{
                return _personaSeleccionada;
            }
            set
            {
                if (_personaSeleccionada != value)//Para evitar stackoverflow
                {
                    _personaSeleccionada = value;
                    NotifyPropertyChanged();
                }

            }
        }

        public ObservableCollection<ClsPersona> ListadoPersonas
        {
            get
            {
                return _listadoPersonas;
            }
            set
            {
                if (_listadoPersonas != value) { 
                 _listadoPersonas = value;
                 NotifyPropertyChanged("ListadoPersonas");
                }
            }
        }

        public String NombreBusqueda
        {
            get
            {
                return _nombreBusqueda;
            }
            set
            {
                _nombreBusqueda = value;
                NotifyPropertyChanged();
            }
        }

        public List<ClsPersona> ClsListadoPersonas { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            //Código para eliminar
            //bool encontrado = false;

            //for (int i = 0; i < _listadoPersonas.Count && !encontrado; i++)//Buscamos la persona en la lista
            //{
            //    if (_listadoPersonas.ElementAt(i).Equals(_personaSeleccionada))
            //    {
            //        _listadoPersonas.RemoveAt(i);
            //        encontrado = true;
            //    }
            //}
            _listadoPersonas.Remove(_personaSeleccionada);
            //NotifyPropertyChanged("ListadoPersonas");
        }

        public void Filtrar_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(_nombreBusqueda))//Si el texto de busqueda no esta vacío
            {
                var favoriteCommand = Application.Current.Resources["favoriteCommand"] as ICommand;
                favoriteCommand.Execute(this);
            }
        }
    }
}
