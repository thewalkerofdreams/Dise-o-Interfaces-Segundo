using _CRUD_Superheroe_UI.Commands;
using CRUD_Superheroe_BL.Handler;
using CRUD_Superheroe_BL.Lists;
using CRUD_Superheroe_Entities;
using CRUD_Superheroe_UI.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;

namespace CRUD_Superheroe_UI.ViewModels
{
    public class ClsMainPageVM : INotifyPropertyChanged
    {
        private ObservableCollection<ClsCompania> _listadoCompanias;
        private ObservableCollection<ClsSuperheroe> _listadoSuperheroes;
        private ClsCompania _companiaSeleccionada;
        private ClsSuperheroe _superheroeSeleccionado;
        private String _textoBusqueda;
        private String _mensajeErrorNombre;//Mensajes por pantalla...
        private String _mensajeErrorApellidos;
        private String _mensajeErrorApodo;
        private String _mensajeErrorSexo;
        private String _mensajeSuperheroeGuardado;
        private DelegateCommand _filtrarNombres;//Comandos...
        private DelegateCommand _refrescarLista;
        private DelegateCommand _eliminarSuperheroe;
        private DelegateCommand _guardarSuperheroe;
        private DelegateCommand _addSuperheroe;
        private bool _isSuperheroeSeleccionado;//Nos permite saber si hemos seleccionado una persona, nos ayudará a deshabilitar el boton de borrar persona cuando estemos creando una nueva persona.
        private BitmapImage _imagenAMostrar;

        public ClsMainPageVM()
        {
            ClsListadoCompanias_BL clsListadoCompanias_BL = new ClsListadoCompanias_BL();
            try
            {
                _listadoCompanias = clsListadoCompanias_BL.obtenerListadoDeCompanias();
            }
            catch (Exception e)
            {
                ClsMensajes.mensajeErrorSQLAsync();
            }

            _textoBusqueda = "";
            _filtrarNombres = new DelegateCommand(filtrarNombres, botonActivo);//Inicializamos los comandos
            _refrescarLista = new DelegateCommand(eliminarFiltro);
            _eliminarSuperheroe = new DelegateCommand(eliminarSuperheroeAsync, botonDeleteActivo);
            _guardarSuperheroe = new DelegateCommand(guardarSuperheroe);
            _addSuperheroe = new DelegateCommand(limpiarFoco);
            limpiarFoco();//Llamamos a la función de limpiar foco para que podamos crear una nueva persona desde el inicio, también nos ayuda a limpiar valores por defecto.
            
            _isSuperheroeSeleccionado = false;
            _mensajeErrorNombre = "";
            _mensajeErrorApellidos = "";
            _mensajeErrorApodo = "";
            _mensajeErrorSexo = "";
        }

        #region Propiedades Públicas

        public ObservableCollection<ClsCompania> ListadoCompanias
        {
            get
            {
                return _listadoCompanias;
            }
            set
            {
                _listadoCompanias = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<ClsSuperheroe> ListadoSuperheroes
        {
            get
            {
                return _listadoSuperheroes;
            }
            set
            {
                _listadoSuperheroes = value;
                NotifyPropertyChanged();
            }
        }

        public ClsCompania CompaniaSeleccionada
        {
            get
            {
                return _companiaSeleccionada;
            }
            set
            {
                _companiaSeleccionada = value;
                if (_companiaSeleccionada != null)
                {
                    ClsListadoSuperheroes_BL clsListadoSuperheroes_BL = new ClsListadoSuperheroes_BL();
                    _listadoSuperheroes = clsListadoSuperheroes_BL.obtenerListadoDeSeperheroes(_companiaSeleccionada.Id);
                    _superheroeSeleccionado = new ClsSuperheroe(0, " ", " ", " ", " ", _companiaSeleccionada.Id, null);//Creamos una personaSeleccionada por defecto
                    _isSuperheroeSeleccionado = false;//Para evitar que te permita borrar con heroes no insertados
                    NotifyPropertyChanged("IsSuperheroeSeleccionado");
                }
                else
                {
                    _listadoSuperheroes = null;
                    _superheroeSeleccionado = null;
                } 
                NotifyPropertyChanged("SuperheroeSeleccionado");
                NotifyPropertyChanged("ListadoSuperheroes");
                NotifyPropertyChanged();
                limpiarMensajes();
                NotifyPropertyChanged("FiltrarNombres");
            }
        }

        public ClsSuperheroe SuperheroeSeleccionado
        {
            get
            {
                return _superheroeSeleccionado;
            }
            set
            {
                _superheroeSeleccionado = value;
                _isSuperheroeSeleccionado = true;//Indicamos que hemos seleccionado una persona
                NotifyPropertyChanged("IsSuperheroeSeleccionado");
                NotifyPropertyChanged();
                limpiarMensajes();
                NotifyPropertyChanged("EliminarSuperheroe");//Le indicamos el cambio a los siguientes comandos.
                NotifyPropertyChanged("AddSuperheroe");

                if (_superheroeSeleccionado != null && _superheroeSeleccionado.Foto != null)
                {
                    cargarImagen();
                }
            }
        }

        public String TextoBusqueda
        {
            get
            {
                return _textoBusqueda;
            }
            set
            {
                _textoBusqueda = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("FiltrarNombres");
                if (_textoBusqueda == "")
                {
                    ClsListadoSuperheroes_BL clsListadoSuperheroes_BL = new ClsListadoSuperheroes_BL();
                    _listadoSuperheroes = clsListadoSuperheroes_BL.obtenerListadoDeSeperheroes(_companiaSeleccionada.Id);
                    NotifyPropertyChanged("ListadoSuperheroes");//Recargamos la lista de personas, al hacer esto desvinculamos la persona seleccionada
                }
            }
        }

        public String MensajeErrorNombre
        {
            get
            {
                return _mensajeErrorNombre;
            }
            set
            {
                _mensajeErrorNombre = value;
                NotifyPropertyChanged();
            }
        }

        public String MensajeErrorApellidos
        {
            get
            {
                return _mensajeErrorApellidos;
            }
            set
            {
                _mensajeErrorApellidos = value;
                NotifyPropertyChanged();
            }
        }

        public String MensajeErrorApodo
        {
            get
            {
                return _mensajeErrorApodo;
            }
            set
            {
                _mensajeErrorApodo = value;
                NotifyPropertyChanged();
            }
        }

        public String MensajeErrorSexo
        {
            get
            {
                return _mensajeErrorSexo;
            }
            set
            {
                _mensajeErrorSexo = value;
                NotifyPropertyChanged();
            }
        }

        public String MensajeSuperheroeGuardado
        {
            get
            {
                return _mensajeSuperheroeGuardado;
            }
            set
            {
                _mensajeSuperheroeGuardado = value;
                NotifyPropertyChanged();
            }
        }

        public DelegateCommand FiltrarNombres
        {
            get
            {
                return _filtrarNombres;
            }
        }

        public DelegateCommand RefrescarLista
        {
            get
            {
                return _refrescarLista;
            }
        }

        public DelegateCommand EliminarSuperheroe
        {
            get
            {
                return _eliminarSuperheroe;
            }
        }

        public DelegateCommand GuardarSuperheroe
        {
            get
            {
                return _guardarSuperheroe;
            }
        }

        public DelegateCommand AddSuperheroe
        {
            get
            {
                return _addSuperheroe;
            }
        }

        public bool IsSuperheroeSeleccionado
        {
            get
            {
                return _isSuperheroeSeleccionado;
            }
            set
            {
                _isSuperheroeSeleccionado = value;
                NotifyPropertyChanged();
            }
        }

        public BitmapImage ImagenAMostrar
        {
            get
            {
                return _imagenAMostrar;
            }
            set
            {
                _imagenAMostrar = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Funciones Comandos

        /// <summary>
        /// Comentario: Utilizado para el comando filtrarNombre. Nos permite filtrar la lista
        /// de personas por un nombre específico.
        /// </summary>
        private void filtrarNombres()
        {
            ClsBusquedasPersonalizadas clsBusquedasPersonalizadas = new ClsBusquedasPersonalizadas();
            try
            {
                _listadoSuperheroes = clsBusquedasPersonalizadas.listadoHeroesSegunNombre(_textoBusqueda, _companiaSeleccionada.Id);//Obtenemos un listado de personas según su nombre.
            }
            catch (Exception e)
            {
                ClsMensajes.mensajeErrorSQLAsync();
            }
            
            NotifyPropertyChanged("ListadoSuperheroes");
        }

        /// <summary>
        /// Comentario: Utilizado para el comando filtrarNombre. Permite saber si el boton
        /// se encuentra activo.
        /// </summary>
        /// <returns></returns>
        private Boolean botonActivo()
        {
            bool activo = true;

            if (String.IsNullOrEmpty(_textoBusqueda) || _companiaSeleccionada == null)
            {
                activo = false;
            }

            return activo;
        }

        /// <summary>
        /// Comentario: Este método es utilizado para el comando _cancelarFiltrado. Este método
        /// nos permite eliminar el texto de filtrado, volviendo a cargar la lista de personas
        /// por defecto.
        /// </summary>
        private void eliminarFiltro()
        {
            NotifyPropertyChanged("RefrescarLista");//Es necesario, cuando cliqueamos en cancel el boton seguiría activo.
            ClsListadoSuperheroes_BL clsListadoSuperheroes_BL = new ClsListadoSuperheroes_BL();
            _listadoSuperheroes = clsListadoSuperheroes_BL.obtenerListadoDeSeperheroes(_companiaSeleccionada.Id);//Recargamos la lista de personas
            NotifyPropertyChanged("ListadoSuperheroes");
            _superheroeSeleccionado = new ClsSuperheroe(0, "", "", "", " ", 1, null);//Instanciamos una persona seleccionada por defecto
            NotifyPropertyChanged("SuperheroeSeleccionado");

            _isSuperheroeSeleccionado = false;//Indicamos que ya no hay ninguna persona seleccionada
            NotifyPropertyChanged("IsSuperheroeSeleccionado");

            limpiarMensajes();//Limpiamos los mensajes tra eliminar el filtro
        }

        /// <summary>
        /// Comentario: Este método nos permite eliminar un superheroe de la lista. Este método
        /// lo utilizamos para el comando _eliminarSuperheroe.
        /// </summary>
        private async void eliminarSuperheroeAsync()
        {
            ContentDialog confirmarBorrado = new ContentDialog();

            confirmarBorrado.Title = "Eliminar";
            confirmarBorrado.Content = "¿Esta seguro de que quiere borrar?";
            confirmarBorrado.PrimaryButtonText = "Cancelar";
            confirmarBorrado.SecondaryButtonText = "Aceptar";
            ContentDialogResult resultado = await confirmarBorrado.ShowAsync();

            if (resultado == ContentDialogResult.Secondary)
            {

                ClsSuperheroeHandler_BL clsSuperheroeHandler_BL = new ClsSuperheroeHandler_BL();
                clsSuperheroeHandler_BL.eliminarSuperheroe(_superheroeSeleccionado.Id);
                _listadoSuperheroes.Remove(_superheroeSeleccionado);

                limpiarFoco();//Limpiamos el foco
                ClsListadoSuperheroes_BL clsListadoSuperheroes_BL = new ClsListadoSuperheroes_BL();
                _listadoSuperheroes =  clsListadoSuperheroes_BL.obtenerListadoDeSeperheroes(_companiaSeleccionada.Id);
                NotifyPropertyChanged("ListadoSuperheroes");//Recargamos la lista de personas, al hacer esto desvinculamos la persona seleccionada
            }
        }

        /// <summary>
        /// Comentario: Este método nos permite saber si el boton eliminar superheroe se encuentra activo. Este 
        /// método se pasara como segundo prámetro en el comando _eliminarSuperheroe.
        /// </summary>
        /// <returns></returns>
        private bool botonDeleteActivo()
        {
            bool activo = false;

            if (_superheroeSeleccionado != null && _isSuperheroeSeleccionado == true)
            {
                activo = true;
            }

            return activo;
        }

        /// <summary>
        /// Comentario: Este método nos permite eliminar el foco de _personaSeleccionada. 
        /// Este método se utiliza dentro del comando limpiarFoco.
        /// </summary>
        private void limpiarFoco()
        {
            _superheroeSeleccionado = null;    //Declaramos _superheroeSeleccionado a null y comenzamos a deshabilitar los siguientes comandos de abajo.
            NotifyPropertyChanged("SuperheroeSeleccionado");
            NotifyPropertyChanged("EliminarSuperheroe");
            NotifyPropertyChanged("AddSuperheroe");

            limpiarMensajes();//Limpiamos los posibles mensajes mostrados por pantalla.

            //Creamos una nueva persona para personaSeleccionada, esto nos ayudará a la hora de crear una nueva persona.
            _superheroeSeleccionado = new ClsSuperheroe(0, "", "", "", " ",  0, null);
            NotifyPropertyChanged("SuperheroeSeleccionado");

            _isSuperheroeSeleccionado = false;
            NotifyPropertyChanged("IsSuperheroeSeleccionado");
            cargarImagen();//Cargamos la imagen por defecto si no hay ninguna persona seleccionada
        }

        /// <summary>
        /// Comentario: Este método nos permite guardar un superheroe en la base de datos. 
        /// A la hora de guardarlo, el método comprobará si la id del heroe es 0, 
        /// es decir, por defecto, en ese caso inserta una nueva persona y en caso contrario 
        /// modificará el estado del heroe de la base de datos que tenga esa misma id.
        /// A la hora de guardar un heroe, si alguno de los campos de la vista no son correctos, 
        /// se mandará un mensaje de error para dicho campo y no se insertará el heroe.
        /// Este método se utiliza dentro del comando _guardarSuperheroe.
        /// </summary>
        private void guardarSuperheroe()
        {
            int idHeroe = 0;//Nos ayudará a la hora de editar un superheroe, para mantener la selección sobre ese superheroe tras ser guardada.
            bool personaCorrecta = true;

            if (String.IsNullOrEmpty(SuperheroeSeleccionado == null ? "" : SuperheroeSeleccionado.Nombre))
            {
                _mensajeErrorNombre = "El nombre no debe estar en blanco.";
                personaCorrecta = false;
            }
            else
            {
                _mensajeErrorNombre = "";
            }

            if (String.IsNullOrEmpty(SuperheroeSeleccionado == null ? "" : SuperheroeSeleccionado.Apellidos))
            {
                _mensajeErrorApellidos = "Los apellidos no debes estar en blanco.";
                personaCorrecta = false;
            }
            else
            {
                _mensajeErrorApellidos = "";
            }
            
            if (String.IsNullOrEmpty(SuperheroeSeleccionado == null ? "" : SuperheroeSeleccionado.Apodo))
            {
                _mensajeErrorApodo = "El apodo no debe estar en blanco.";
                personaCorrecta = false;
            }
            else
            {
                _mensajeErrorApodo = "";
            }

            if (String.IsNullOrEmpty(SuperheroeSeleccionado == null ? "" : SuperheroeSeleccionado.Sexo.ToString()) || (SuperheroeSeleccionado.Sexo != "M" && SuperheroeSeleccionado.Sexo != "H"))
            {
                _mensajeErrorSexo = "El sexo debe ser H o M.";
                personaCorrecta = false;
            }
            else
            {
                _mensajeErrorSexo = "";
            }

            NotifyPropertyChanged("MensajeErrorNombre");
            NotifyPropertyChanged("MensajeErrorApellidos");
            NotifyPropertyChanged("MensajeErrorApodo");
            NotifyPropertyChanged("MensajeErrorSexo");

            if (personaCorrecta && _companiaSeleccionada != null)//Si todos los atributos de la persona son válidos y se ha seleccionado una compañia
            {
                ClsSuperheroeHandler_BL clsSuperheroeHandler_BL = new ClsSuperheroeHandler_BL();
                if (SuperheroeSeleccionado.Id == 0)//Si la id es por defecto, insertamos un nuevo superheroe
                {
                    _superheroeSeleccionado.IdCompania = _companiaSeleccionada.Id;
                    try
                    {
                        if (clsSuperheroeHandler_BL.insertarPersona(SuperheroeSeleccionado))
                        {
                            limpiarFoco();//Si se ha conseguido almacenar la persona, se limpiarán los textBox.
                            cargarImagen();//Cargamos la imagen por defecto si no hay ninguna persona seleccionada

                            _mensajeSuperheroeGuardado = "Persona Guardada";//Mandamos un mensaje por pantalla
                            NotifyPropertyChanged("MensajeSuperheroeGuardado");
                        }
                    }
                    catch (Exception e)
                    {
                        ClsMensajes.mensajeErrorSQLAsync();
                    }
                }
                else//Sino modificamos una de la base de datos
                {
                    clsSuperheroeHandler_BL.editarSuperheroe(SuperheroeSeleccionado);
                    idHeroe = SuperheroeSeleccionado.Id;
                }

                ClsListadoSuperheroes_BL clsListadoSuperheroes_BL = new ClsListadoSuperheroes_BL();
                _listadoSuperheroes = clsListadoSuperheroes_BL.obtenerListadoDeSeperheroes(_companiaSeleccionada.Id);
                NotifyPropertyChanged("ListadoSuperheroes");//Recargamos la lista de personas, al hacer esto desvinculamos la persona seleccionada

                if (idHeroe != 0)//Si se ha realizado una modificación de una persona ya existente en la base de datos 
                {
                    _superheroeSeleccionado = clsSuperheroeHandler_BL.obtenerSuperheroe(idHeroe);
                    NotifyPropertyChanged("SuperheroeSeleccionado");//Actualizamos la persona seleccionada
                    _mensajeSuperheroeGuardado = "Persona Guardada";//Recargamos eñ mensaje por pantalla
                    NotifyPropertyChanged("MensajeSuperheroeGuardado");
                }
            }
        }

        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Funciones Extras
        /// <summary>
        /// Comentario: Este método nos permite limpiar los posibles mensajes mostrados
        /// por pantalla.
        /// </summary>
        private void limpiarMensajes()
        {
            _mensajeSuperheroeGuardado = "";
            NotifyPropertyChanged("MensajeSuperheroeGuardado");
            _mensajeErrorNombre = "";
            NotifyPropertyChanged("MensajeErrorNombre");
            _mensajeErrorApellidos = "";
            NotifyPropertyChanged("MensajeErrorApellidos");
            _mensajeErrorApodo = "";
            NotifyPropertyChanged("MensajeErrorApodo");
            _mensajeErrorSexo = "";
            NotifyPropertyChanged("MensajeErrorSexo");
        }

        #endregion

        #region Image

        /// <summary>
        /// Comentario: Este evento nos permite abrir un selector de archivos que admite
        /// los siguientes formatos de imagen: png, jpg, jpge o bmp. Al elegir una imagen
        /// de los archivos se colocará en nuestra etiqueta imagen del tipo Image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void PersonPicture01_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PersonPicture imagen = (PersonPicture)sender;

            if (SuperheroeSeleccionado != null && SuperheroeSeleccionado.Foto != null && SuperheroeSeleccionado.Foto.Length != 0)//Si el heroe seleccionado no es null y ya tiene una imagen
            {
                // Set the image source to the selected bitmap
                BitmapImage bitmapImage = new BitmapImage();

                bitmapImage = await ClsConversiones.byteArrayToBitmapAsync(SuperheroeSeleccionado.Foto);
                imagen.ProfilePicture = bitmapImage;
            }
            else//Sino sacamos una imagen del selector de archivos
            {
                var fileOpenPicker = new FileOpenPicker();
                fileOpenPicker.ViewMode = PickerViewMode.Thumbnail;
                fileOpenPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                fileOpenPicker.FileTypeFilter.Add(".png");
                fileOpenPicker.FileTypeFilter.Add(".jpg");
                fileOpenPicker.FileTypeFilter.Add(".jpeg");
                fileOpenPicker.FileTypeFilter.Add(".bmp");

                var storageFile = await fileOpenPicker.PickSingleFileAsync();

                if (storageFile != null)
                {
                    // Ensure the stream is disposed once the image is loaded
                    using (IRandomAccessStream fileStream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read))
                    {
                        // Set the image source to the selected bitmap
                        BitmapImage bitmapImage = new BitmapImage();

                        await bitmapImage.SetSourceAsync(fileStream);
                        imagen.ProfilePicture = bitmapImage;
                    }

                    //Almacenamos la imagen en la persona seleccionada
                    _superheroeSeleccionado.Foto = await ClsConversiones.fileToByteArrayAsync(storageFile);
                    NotifyPropertyChanged("SuperheroeSeleccionado");
                }   
                
            }
        }

        /// <summary>
        /// Comentario: Este método nos permite cargar la imagen de una persona al seleccionarla
        /// en la aplicación.
        /// </summary>
        public void cargarImagen()
        {
            using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                // Writes the image byte array in an InMemoryRandomAccessStream
                // that is needed to set the source of BitmapImage.
                using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes((byte[])_superheroeSeleccionado.Foto);

                    // The GetResults here forces to wait until the operation completes
                    // (i.e., it is executed synchronously), so this call can block the UI.
                    writer.StoreAsync().GetResults();
                }

                var image = new BitmapImage();
                image.SetSource(ms);
                _imagenAMostrar = image;
            }
            NotifyPropertyChanged("ImagenAMostrar");
        }
        #endregion
    }
}
