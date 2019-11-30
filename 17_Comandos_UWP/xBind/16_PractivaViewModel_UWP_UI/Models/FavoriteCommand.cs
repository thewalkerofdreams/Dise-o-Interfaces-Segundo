using _15_Ejercicio3_UWP.Models;
using _16_PractivaViewModel_UWP_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _16_PractivaViewModel_UWP_UI.Models
{
    public class FavoriteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            // Perform the logic to "favorite" an item.
            ClsMainPageVM mainPageVM = (parameter as ClsMainPageVM);
            ObservableCollection<ClsPersona> observableCollection = ClsListadosPersonas.listadoPersonasSegunNombre(mainPageVM.NombreBusqueda);
            mainPageVM.ListadoPersonas = observableCollection;

        }
    }
}
