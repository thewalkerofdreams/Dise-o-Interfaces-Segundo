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

namespace _04_BotonesEnTiempoDeEjecucion
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
            Button btn3 = new Button();

           
            btn3.HorizontalContentAlignment = HorizontalAlignment.Center;
            btn3.VerticalContentAlignment = VerticalAlignment.Center;
            btn3.HorizontalAlignment = HorizontalAlignment.Center;
            btn3.VerticalAlignment = VerticalAlignment.Center;
            btn3.Height = 70;
            btn3.Width = 200;
            btn3.FontSize = 16;
            btn3.Content = "Boton 3";
            btn3.Background = new SolidColorBrush(Windows.UI.Colors.Blue);
            btn3.FontStyle = Windows.UI.Text.FontStyle.Oblique;
            btn3.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Yellow);
            btn3.FontFamily = new FontFamily("Verdana");
            panelPrincipal.Children.Add(btn3);
        }
    }
}
