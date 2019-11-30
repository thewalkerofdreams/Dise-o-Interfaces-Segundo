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

namespace _09_RelativePanel_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();
            fillListDefault();
        }

        /// <summary>
        /// Comentario: Este método rellena el elemento ListBox01 con 20 datos
        /// de prueba.
        /// Postcondiciones: El método introduce 20 elementos en la vista ListBox01.
        /// </summary>
        public void fillListDefault()
        {
            for (int i = 0; i < 20; i++)
            {
                ListBox01.Items.Add("Prueba "+(i+1));
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            addElement();
        }

        /// <summary>
        /// Comentario: Este método nos permite añadir un nuevo elemento a la 
        /// lista ListBox01. Si el elemento AddText02 se encuentra vacío, no se 
        /// añadirá ningún elemento. Una vez se haya agregado un elemento, el contenido
        /// de AddText02 se eliminará.
        /// </summary>
        /// <returns>El método devuelve un valor booleano asociado al nombre, true
        /// si se ha conseguido añadir un elemento o false en caso contrario.</returns>
        public bool addElement()
        {
            bool elementAdded = false;

            if (!String.IsNullOrEmpty(AddText02.Text))//Si un item tuviera más de un elemento se crearía una función de validación del item.
            {
                elementAdded = true;
                ListBox01.Items.Add(AddText02.Text);
                AddText02.Text = "";
            }

            return elementAdded;
        }

        private void IconTick_Click(object sender, RoutedEventArgs e)
        {
            marcarElemento();
        }

        private void ListBox01_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Comentario: Este método permite marcar un elemento como hecho.
        /// </summary>
        /// <returns>El método devuelve un valor booleano asociado al nombre, true
        /// si se ha conseguido marcar un elemento y false en caso contrario.</returns>
        public bool marcarElemento()
        {
            bool elementoMarcado = false;
            String txt;

            if (ListBox01.SelectedItem != null)//Si se ha seleccionado un elemento de la lista
            {
                txt = (String)ListBox01.Items[ListBox01.SelectedIndex];
                if (!txt.Contains(" (Realizado)"))//si el elemento aún no está marcado.
                {
                    ListBox01.Items[ListBox01.SelectedIndex] = txt + " (Realizado)";
                    elementoMarcado = true;
                }    
            }

            return elementoMarcado;
        }

        private void IconDelete_Click(object sender, RoutedEventArgs e)
        {
            eliminarElemento();
        }

        /// <summary>
        /// Comentario: Este método nos permite eliminar un elemento de la lista
        /// ListBox01. Si no hay ningún elemento marcado, no se eliminará ningún
        /// elemento.
        /// </summary>
        /// <returns>El método devuelve un valor booleano asociado al nombre, true
        /// si se ha eliminado un elemento o false en caso contrario.</returns>
        public bool eliminarElemento()
        {
            bool elementoEliminado = false;

            if (ListBox01.SelectedItem != null)//Si se ha seleccionado un elemento de la lista
            {
                ListBox01.Items.RemoveAt(ListBox01.SelectedIndex);
            }

            return elementoEliminado;
        }

        private void IconSearch_Click(object sender, RoutedEventArgs e)
        {
            searchElement();
        }

        public bool searchElement()
        {
            bool elementFinded = false;
            String texto;

            if (!String.IsNullOrEmpty(TextBoxSearch.Text))
            {
                for (int i = 0; i < ListBox01.Items.Count && !elementFinded; i++)
                {
                    ListBox01.SelectedIndex = i;
                    texto = (String)ListBox01.Items[ListBox01.SelectedIndex];
                    if (texto.Equals(TextBoxSearch.Text))
                    {
                        ListBox01.SelectedIndex = i;
                        elementFinded = true;
                    }
                }
            }

            return elementFinded;
        }
    }
}
