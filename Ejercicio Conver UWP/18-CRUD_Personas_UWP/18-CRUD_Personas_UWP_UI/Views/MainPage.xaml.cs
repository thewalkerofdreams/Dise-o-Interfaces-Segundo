using _05_ADO_ASP.Models;
using _18_CRUD_Personas_UWP_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _18_CRUD_Personas_UWP_UI
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ClsMainPageVM viewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            viewModel = (ClsMainPageVM)this.DataContext;//Para x:Bind
        }

        private void ListView01_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Actions_Persona_Flyout.ShowAt(ListView01, e.GetPosition(ListView01));//Muestra el flyout de la posición donde este el puntero
            ClsPersona personaSeleccionada = (ClsPersona)((FrameworkElement)e.OriginalSource).DataContext;//Nos permite seleccionar un elemento de la lista con click derecho
            this.ListView01.SelectedItem = personaSeleccionada;
        }
        
    }
}
