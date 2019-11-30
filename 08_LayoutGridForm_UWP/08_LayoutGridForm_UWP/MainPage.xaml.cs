using Classess;
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

namespace _08_LayoutGridForm_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            saludar();
        }

        private void saludar()
        {
            bool personaValida = true;
            ClsPersona persona;
            DateTime dateOut = new DateTime();

            if (String.IsNullOrEmpty(txtBoxName.Text))
            {
                personaValida = false;
                txtErrorName.Text = "Se te olvidó el nombre.";
            }
            else
            {
                txtErrorName.Text = "";
            }

            if (String.IsNullOrEmpty(txtBoxSurname.Text))
            {
                personaValida = false;
                txtErrorSurname.Text = "Se te olvidó el apellido.";
            }
            else
            {
                txtErrorSurname.Text = "";
            }

            if (String.IsNullOrEmpty(txtBoxDate.Text))
            {
                personaValida = false;
                txtErrorDate.Text = "Se te olvidó la fecha de nacimiento.";
            }
            else
            {
                if (DateTime.TryParse(txtBoxDate.Text, out dateOut))
                {
                    if (dateOut >= DateTime.Now)
                    {
                        personaValida = false;
                        txtErrorDate.Text = "La fecha es posterior a la actual.";
                    }
                    else
                    {
                        txtErrorDate.Text = "";
                    }
                  
                }
                else
                {
                    personaValida = false;
                    txtErrorDate.Text = "La fecha es incorrecta.";
                }
                
            }

            if (personaValida)
            {
                persona = new ClsPersona(txtBoxName.Text, txtBoxSurname.Text, dateOut);
                txtBlockSaludo.Text = "Saludos " + persona.nombre+" "+persona.apellidos+" con edad de "+persona.getEdad()+" años.";
            }
            else
            {
                txtBlockSaludo.Text = "";
            }
        }
    }
}
