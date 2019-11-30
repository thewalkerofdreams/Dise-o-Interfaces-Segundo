using _16_PractivaViewModel_UWP_UI.ViewModels;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _16_PractivaViewModel_UWP_UI
{

    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ClsMainPageVM ViewModel { get; } = new ClsMainPageVM();//Necesitamos declarar un objeto VM en el code behind de la página para que los x:Bind funcionen.
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new ClsMainPageVM();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnInsertPerson_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void listaElementos_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
