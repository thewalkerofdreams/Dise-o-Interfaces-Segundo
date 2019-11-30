using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using static System.Net.Mime.MediaTypeNames;
using SharpDX.WIC;
using Windows.Graphics.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;

namespace _18_CRUD_Personas_UWP_UI.Utilidades
{

    public class ClsConversiones
    {
        /// <summary>
        /// Comentario: Este método nos permite sacar de un fichero un array de bytes.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static async Task<byte[]> fileToByteArrayAsync(StorageFile file)
        {
            using (var inputStream = await file.OpenSequentialReadAsync())//Abrimos la secuencia de lectura del fichero
            {
                var readStream = inputStream.AsStreamForRead();//Obtenemos un stream a través de la lectura del fichero.

                var byteArray = new byte[readStream.Length];//Creamos un array de bytes con el tamaño del stream anterior.

                await readStream.ReadAsync(byteArray, 0, byteArray.Length);//Leemos el stream de inicio a fin, almacenanso los datos leidos en el array de bytes

                return byteArray;
            }
        }

        /// <summary>
        /// Comentario: Este método nos permite convertir un array de bytes a un tipo bitmap. 
        /// </summary>
        /// <param name="byteArray">El array de bytes</param>
        /// <returns></returns>
        public static async Task<BitmapImage> byteArrayToBitmapAsync(byte[] byteArray)
        {
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())//Crea un stream de salida de acceso aleatorio.
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))//Crea un writer a partir del stream anterior.
                {
                    writer.WriteBytes(byteArray);//Escribe el array de bytes en el stream.
                    await writer.StoreAsync();//Confirma y almacena los datos en el stream.
                }

                var image = new BitmapImage();//Creamos el tipo BitImage
                await image.SetSourceAsync(stream);//Asigna los datos del stream a la imagen.

                return image;
            }
        }   
    }
}
