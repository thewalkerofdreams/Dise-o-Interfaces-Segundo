using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace _18_CRUD_Personas_UWP_UI.Utilidades
{
    public class ClsMensajes
    {
        /*
         Interfaz
         Nombre: mensajeErrorSQLAsync
         Comentario: Este método muestra por pantalla un mensaje de error de conexión de SQL.
         Cabecera: public static async void mensajeErrorSQLAsync()
         */
        public static async void mensajeErrorSQLAsync()
        {
            ContentDialog confirmar = new ContentDialog();
            confirmar.Title = "Error base de datos";
            confirmar.Content = "¡Error en la conexión con la base de datos!";
            confirmar.PrimaryButtonText = "Aceptar";
            ContentDialogResult resultado = await confirmar.ShowAsync();
        }
        
    }
}
