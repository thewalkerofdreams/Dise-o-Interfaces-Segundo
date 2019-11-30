using System;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace _18_CRUD_Personas_UWP_UI.Models
{
    public class ByteArrayToImageConverter : IValueConverter    //El objetivo de esta clase era poder convertir el tipo de dato de array de bytes a BitmapImage y viceversa.
    {                                                           //Por falta de tiempo aún no he conseguido hacer la función de convertBack que me permite realizar la conversión del tipo de dato de vuelta.
        /// <summary>                                           //He solucionado el problema introduciendo otro atributo al ViewModel ClsMainPageVM.
        /// Comentario: Este método nos permite convertir un array de bytes en
        /// un tipo Bitmap, luego inserta el bitmap obtenido a nuestra etiqueta
        /// del tipo imagen del xaml, es decir, el bitmap se asigna a la dirección
        /// del tipo Image.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null || !(value is byte[]))
                //return File.ReadAllBytes("Assets/imagen_defecto.png");
                return null;

            using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                // Writes the image byte array in an InMemoryRandomAccessStream
                // that is needed to set the source of BitmapImage.
                using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes((byte[])value);

                    // The GetResults here forces to wait until the operation completes
                    // (i.e., it is executed synchronously), so this call can block the UI.
                    writer.StoreAsync().GetResults();
                }

                var image = new BitmapImage();
                image.SetSource(ms);
                return image;
            }
        }

        /// <summary>
        /// Comentario: Este método nos permite convertir un tipo bitmap en un array de bytes, 
        /// luego inserta el array de bytes obtenido a nuestra etiqueta del tipo imagen del xaml, es 
        /// decir, el array de bytes se asigna a la dirección del tipo Image.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)    //Aún en construcción
        {
            //throw new NotImplementedException();
            if (value != null)
            {
                //return ClsConversiones.ImageToByte((BitmapImage)value);
                return (BitmapImage)value;
            }
            else
            {
                return null;
            }
        }
    }

}
