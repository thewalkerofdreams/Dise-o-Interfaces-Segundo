using _15_Ejercicio3_UWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _15_Ejercicio3_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ListView listaPersonas = new ListView();

        public MainPage()
        {
            this.InitializeComponent();
            //reset();
        }

        ///// <summary>
        ///// Comentario: Este método genera una lista por defecto de personas.
        ///// </summary>
        //public void generarListaPorDefecto()
        //{
        //    // Create a new ListView and add content. 
        //    listaPersonas.Items.Add(new ClsPersona("Pepe", "Garcia", new DateTime(1998, 1, 1)));
        //    listaPersonas.Items.Add(new ClsPersona("Pedro", "Lobo", new DateTime(1996, 1, 1)));
        //    listaPersonas.Items.Add(new ClsPersona("Lucas", "Jin", new DateTime(1993, 1, 1)));
        //    listaPersonas.Items.Add(new ClsPersona("Maria", "Hernández", new DateTime(1968, 1, 1)));
        //    listaPersonas.Items.Add(new ClsPersona("Luisa", "Perez", new DateTime(1978, 1, 1)));

        //    // Add the ListView to a parent container in the visual tree (that you created in the corresponding XAML file).
        //    listaElementos.Children.Add(listaPersonas);
        //}

        /// <summary>
        /// Comentario: Este método permite resetear los valores por defecto de la aplicación. Dejando
        /// los valores principales por defecto (Botones, Textboxs...).
        /// Postcondiciones: El método cambia el estado de la pantalla MainPage.
        /// </summary>
        public void reset()
        {
            btnAdd.IsEnabled = true;
            btnEdit.IsEnabled = false;
            btnCancel.IsEnabled = false;
            txtBoxNombre.Text = "";
            txtBoxNombre.IsEnabled = false;
            txtBoxApellidos.Text = "";
            txtBoxApellidos.IsEnabled = false;
            txtBoxFechaNacimiento.Text = "";
            txtBoxFechaNacimiento.IsEnabled = false;
            txtBoxTelefono.Text = "";
            txtBoxTelefono.IsEnabled = false;
            txtBoxDireccion02.Text = "";
            txtBoxDireccion02.IsEnabled = false;
        }

        /// <summary>
        /// Comentario: Este método nos permite realizar diferentes acciones, según el
        /// boton que hayamos clicado. Este método se puede ver como un seleccionador global
        /// que relaciona cada boton con su función a realizar.
        /// Postcondiciones: El método ejecutará una acción según el parámetro introducido.
        /// </summary>
        /// <param name="button"></param>
        public void clickButton(String button)
        {
            switch (button)
            {
                case "btnAdd":
                    modificacionesBtnAdd();
                    break;
                case "btnEdit":
                    modificacionesBtnEdit();
                    break;
                case "btnCancel":
                    reset();
                    break;
                case "btnSubmit":
                    if (añadirPersona())
                    {
                        reset();
                    }
                    break;
            }
        }

        /// <summary>
        /// Comentario: Este método nos permite modificar el estado de los botones y casillas
        /// cuando el usuario pulsa el botón de editar persona.
        /// </summary>
        public void modificacionesBtnEdit()
        {
            btnAdd.IsEnabled = true;
            btnCancel.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnInsertPerson.IsEnabled = true;
            txtBoxNombre.IsEnabled = true;
            txtBoxApellidos.IsEnabled = true;
            txtBoxFechaNacimiento.IsEnabled = true;
            txtBoxTelefono.IsEnabled = true;
            txtBoxDireccion02.IsEnabled = true;
        }

        /// <summary>
        /// Comentario: Este método nos permite modiifcar el estado de los botones y casillas
        /// cuando el usuario pulsa el botón de añadir persona.
        /// </summary>
        public void modificacionesBtnAdd()
        {
            btnAdd.IsEnabled = false;
            btnCancel.IsEnabled = true;
            btnEdit.IsEnabled = false;
            btnInsertPerson.IsEnabled = true;
            txtBoxNombre.IsEnabled = true;
            txtBoxApellidos.IsEnabled = true;
            txtBoxFechaNacimiento.IsEnabled = true;
            txtBoxTelefono.IsEnabled = true;
            txtBoxDireccion02.IsEnabled = true;
        }

        /// <summary>
        /// Comentario: Este método nos permite añadir una persona a la lista.
        /// Los datos de la persona se recogerán en los textbox del formulario.
        /// Si falta el nombre, los apellidos o la fecha de nacimiento de la persona, 
        /// esta no se creará.
        /// Postcondiciones: El método devuelve un valor booleano asociado al nombre, 
        /// true si se ha creado la persona o false en caso contrario. 
        /// </summary>

        public bool añadirPersona() //En construcción
        {
            bool personaCreada = false;

            if (validarCreacionPersona())
            {
                //ObservableCollection<ClsPersona> dataList = new ObservableCollection<ClsPersona>();
                ClsPersona persona = new ClsPersona(txtBoxNombre.Text, txtBoxApellidos.Text, txtBoxTelefono.Text, DateTime.Parse(txtBoxFechaNacimiento.Text), txtBoxDireccion02.Text);
                //dataList.Add(persona);
                //listaElementos.ItemsSource = dataList;
                //string[] row = { txtBoxNombre.Text, txtBoxApellidos.Text, txtBoxTelefono.Text, txtBoxFechaNacimiento.Text, txtBoxDireccion02.Text };
                //var listViewItem = new ListViewItem(persona);
                //listaElementos.Items.Add(listViewItem);
                personaCreada = true;
            }

            return personaCreada;
        }

        /// <summary>
        /// Comentario: Este método nos permite verificar si es posible crear un
        /// tipo persona.
        /// Postcondiciones: El método devuelve un valor booleano asociado al nombre, 
        /// true si es posible crear la persona o false en caso contrario. 
        /// </summary>
        /// <returns>bool</returns>
        public bool validarCreacionPersona()
        {
            bool valido = false;
            DateTime temp;

            if (!String.IsNullOrEmpty(txtBoxNombre.Text) && !String.IsNullOrEmpty(txtBoxApellidos.Text) && !String.IsNullOrEmpty(txtBoxFechaNacimiento.Text))//Si ningún textbox se encuentra vacío
            {
                if (DateTime.TryParse(txtBoxFechaNacimiento.Text, out temp))//Si fechaNacimiento realmente puede convertirse en un tipo DateTime
                {
                    valido = true;
                }   
            }

            return valido;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            clickButton("btnAdd");
        }

        private void btnInsertPerson_Click(object sender, RoutedEventArgs e)
        {
            clickButton("btnSubmit");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            clickButton("btnCancel");
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            clickButton("btnEdit");
        }

        private void listaElementos_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
