using CRUD_Superheroe_Entities;
using CRUD_Superheroe_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CRUD_Superheroe_UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
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
                Actions_Persona_Flyout.ShowAt(ListView02, e.GetPosition(ListView02));//Muestra el flyout de la posición donde este el puntero
                ClsSuperheroe superheroeSeleccionado = (ClsSuperheroe)((FrameworkElement)e.OriginalSource).DataContext;//Nos permite seleccionar un elemento de la lista con click derecho
                this.ListView02.SelectedItem = superheroeSeleccionado;
        }
    }
}
