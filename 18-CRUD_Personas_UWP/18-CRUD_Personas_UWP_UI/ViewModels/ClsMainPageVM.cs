using _05_ADO_ASP.Models;
using _13_DataContext.ViewModels;
using _18_CRUD_Personas_UWP_BL.Handler;
using _18_CRUD_Personas_UWP_BL.Lists;
using _18_CRUD_Personas_UWP_Entities;
using _18_CRUD_Personas_UWP_UI.Models;
using _18_CRUD_Personas_UWP_UI.Utilidades;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;

namespace _18_CRUD_Personas_UWP_UI.ViewModels
{
    public class ClsMainPageVM : INotifyPropertyChanged 
    {
        //Propiedades privadas
        private ObservableCollection<ClsPersona> _listadoPersonas;
        private ObservableCollection<clsDepartamento> _listadoDepartamentos;
        private ClsPersona _personaSeleccionada;
        private String _textoBusqueda;//Texto del buscador de personas
        private DelegateCommand _filtrarNombres;//Comandos...
        private DelegateCommand _refrescarLista;
        private DelegateCommand _eliminarPersona;
        private DelegateCommand _guardarPersona;
        private DelegateCommand _addPersona;

        private bool _isPersonaSeleccionada;//Nos permite saber si hemos seleccionado una persona, nos ayudará a deshabilitar el boton de borrar persona cuando estemos creando una nueva persona.
        private String _mensajeCreacionPersona;//Nos permite mostrar un mensaje por pantalla cada vez que guardemos una persona.

        private String _textErrorNombre;//Errores que se mostrarán a la hora de intentar crear o modificar una persona con datos no válidos.
        private String _textErrorApellidos;
        private String _textErrorFechaNacimiento;
        private String _textErrorTelefono;

        BitmapImage _imagenAMostrar;//Este atributo nos permite poder modificar la imagen de pantalla al ir seleccionando personas de la lista.

        //Constructor por defecto
        public ClsMainPageVM()
        {
            try
            {
                _listadoPersonas = ClsListadosPersonasBL.listadoPersonas(); //Evitamos que la aplicación "pete" por fallos de conexión con la base de datos.
                _listadoDepartamentos = ClsListadosDepartamentosBL.obtenerListadoDeDepartamentos();
            }
            catch (Exception e)
            {
                ClsMensajes.mensajeErrorSQLAsync();
            }
          
            _textoBusqueda = "";
            _filtrarNombres = new DelegateCommand(filtrarNombres, botonActivo);//Inicializamos los comandos
            _refrescarLista = new DelegateCommand(eliminarFiltro);
            _eliminarPersona = new DelegateCommand(eliminarPersonaAsync, botonDeleteActivo);
            _guardarPersona = new DelegateCommand(guardarPersona);
            _addPersona = new DelegateCommand(limpiarFoco);
            limpiarFoco();//Llamamos a la función de limpiar foco para que podamos crear una nueva persona desde el inicio, también nos ayuda a limpiar valores por defecto.

            _textErrorNombre = "";
            _textErrorApellidos = "";
            _textErrorTelefono = "";
            _textErrorFechaNacimiento = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #region Propiedades públicas
        public ObservableCollection<ClsPersona> ListadoPersonas
        {
            get
            {
                return _listadoPersonas;
            }
            set
            {
                _listadoPersonas = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<clsDepartamento> ListadoDepartamentos
        {
            get
            {
                return _listadoDepartamentos;
            }
        }
        
        public String MensajeCreacionPersona
        {
            get
            {
                return _mensajeCreacionPersona;
            }
            set
            {
                _mensajeCreacionPersona = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsPersonaSeleccionada   //En ningún momento llamamos a esta propiedad pública, podríamos quitarla.
        {
            get
            {
                return _isPersonaSeleccionada;
            }
            set
            {
                _isPersonaSeleccionada = value;
                NotifyPropertyChanged();
            }
        }

        public ClsPersona PersonaSeleccionada
        {
            get
            {
                return _personaSeleccionada;
            }
            set
            {
                _personaSeleccionada = value;
                _isPersonaSeleccionada = true;//Indicamos que hemos seleccionado una persona
                NotifyPropertyChanged();
                NotifyPropertyChanged("EliminarPersona");   //Le indicamos el cambio a los siguientes comandos.
                NotifyPropertyChanged("AddPersona");

                limpiarMensajes();//Limpiamos los posibles mensajes que se muestren por pantalla.

                if (_personaSeleccionada != null)//Si personaSeleccionada no es nula y tiene una imagen la muestra por pantalla.
                {
                    cargarImagen();//Nos permite mostrar la imagen de la persona.
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
                if (_textoBusqueda == "")//Con esto, cuando vaciemos el texto de filtro se volverá a cargar la lista de personas completas.
                {
                    this._listadoPersonas = ClsListadosPersonasBL.listadoPersonas();
                    NotifyPropertyChanged("ListadoPersonas");
                }
                else
                {
                    NotifyPropertyChanged("RefrescarLista");//Nos permite activar el boton de recargar cuando escribimos en el buscador de personas.
                }
                NotifyPropertyChanged("FiltrarNombres");
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
                NotifyPropertyChanged("ImagenAMostrar");
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

        public DelegateCommand EliminarPersona
        {
            get
            {
                return _eliminarPersona;
            }
        }

        public DelegateCommand GuardarPersona
        {
            get
            {
                return _guardarPersona;
            }
        }

        public DelegateCommand AddPersona
        {
            get
            {
                return _addPersona;
            }
        }

        public String TextErrorNombre
        {
            get
            {
                return _textErrorNombre;
            }
            set
            {
                _textErrorNombre = value;
                NotifyPropertyChanged();
            }
        }

        public String TextErrorApellidos
        {
            get
            {
                return _textErrorApellidos;
            }
            set
            {
                _textErrorApellidos = value;
                NotifyPropertyChanged();
            }
        }

        public String TextErrorFechaNacimiento
        {
            get
            {
                return _textErrorFechaNacimiento;
            }
            set
            {
                _textErrorFechaNacimiento = value;
                NotifyPropertyChanged();
            }
        }

        public String TextErrorTelefono
        {
            get
            {
                return _textErrorTelefono;
            }
            set
            {
                _textErrorTelefono = value;
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
            _listadoPersonas = clsBusquedasPersonalizadas.listadoPersonasSegunNombre(_textoBusqueda);//Obtenemos un listado de personas según su nombre.
            NotifyPropertyChanged("ListadoPersonas");
        }

        /// <summary>
        /// Comentario: Utilizado para el comando filtrarNombre. Permite saber si el boton
        /// se encuentra activo.
        /// </summary>
        /// <returns></returns>
        private Boolean botonActivo()
        {
            bool activo = true;

            if (String.IsNullOrEmpty(_textoBusqueda))
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
            _listadoPersonas = ClsListadosPersonasBL.listadoPersonas();//Recargamos la lista de personas
            NotifyPropertyChanged("ListadoPersonas");
            _personaSeleccionada = new ClsPersona(0, "", "", "",  new DateTime(), 1);//Instanciamos una persona seleccionada por defecto
            NotifyPropertyChanged("PersonaSeleccionada");
            
            _isPersonaSeleccionada = false;//Indicamos que ya no hay ninguna persona seleccionada
            NotifyPropertyChanged("IsPersonaSeleccionada");

            limpiarMensajes();//Limpiamos los mensajes tra eliminar el filtro
        }

        /// <summary>
        /// Comentario: Este método nos permite eliminar una persona de la lista. Este método
        /// lo utilizamos para el comando _eliminarPersonas.
        /// </summary>
        private async void eliminarPersonaAsync()
        {
            ContentDialog confirmarBorrado = new ContentDialog();

            confirmarBorrado.Title = "Eliminar";
            confirmarBorrado.Content = "¿Esta seguro de que quiere borrar?";
            confirmarBorrado.PrimaryButtonText = "Cancelar";
            confirmarBorrado.SecondaryButtonText = "Aceptar";
            ContentDialogResult resultado = await confirmarBorrado.ShowAsync();

            if (resultado == ContentDialogResult.Secondary)
            {
                
                ClsPersonaHandler_BL clsPersonaHandler_BL = new ClsPersonaHandler_BL();
                clsPersonaHandler_BL.eliminarPersona(_personaSeleccionada.id);
                _listadoPersonas.Remove(_personaSeleccionada);

                limpiarFoco();//Limpiamos el foco
                _listadoPersonas = ClsListadosPersonasBL.listadoPersonas();
                NotifyPropertyChanged("ListadoPersonas");//Recargamos la lista de personas, al hacer esto desvinculamos la persona seleccionada
            }
        }

        /// <summary>
        /// Comentario: Este método nos permite saber si el boton eliminar persona se encuentra activo. Este 
        /// método se pasara como segundo prámetro en el comando _eliminarPersonas.
        /// </summary>
        /// <returns></returns>
        private bool botonDeleteActivo()
        {
            bool activo = false;

            if (_personaSeleccionada != null && _isPersonaSeleccionada == true)
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
            _personaSeleccionada = null;    //Declaramos _personaSeleccionada a null y comenzamos a deshabilitar los siguientes comandos de abajo.
            NotifyPropertyChanged("PersonaSeleccionada");
            NotifyPropertyChanged("EliminarPersona");
            NotifyPropertyChanged("AddPersona");

            limpiarMensajes();//Limpiamos los posibles mensajes mostrados por pantalla.

            //Creamos una nueva persona para personaSeleccionada, esto nos ayudará a la hora de crear una nueva persona.
            _personaSeleccionada = new ClsPersona(0, "", "", "", new DateTime(),  1);
            NotifyPropertyChanged("PersonaSeleccionada");

            cargarImagen();//Cargamos la imagen por defecto si no hay ninguna persona seleccionada
        }

        /// <summary>
        /// Comentario: Este método nos permite guardar una persona en la base de datos. 
        /// A la hora de guardar la persona, el método comprobará si la id de la persona es 0, 
        /// es decir, por defecto, en ese caso inserta una nueva persona y en caso contrario 
        /// modificará el estado de la persona de la base de datos que tenga esa misma id.
        /// A la hora de insertar una persona, si alguno de los campos de la vista no son correctos, 
        /// se mandará un mensaje de error para dicho campo y no se insertará la persona.
        /// Este método se utiliza dentro del comando _guardarPersona.
        /// </summary>
        private void guardarPersona()
        {
            int idPersona = 0;//Nos ayudará a la hora de editar una persona, para mantener la selección sobre esa persona tras ser guardada.
            bool personaCorrecta = true;
            
            if (String.IsNullOrEmpty(PersonaSeleccionada == null ? "" : PersonaSeleccionada.nombre))
            {
                _textErrorNombre = "El nombre no debe estar en blanco.";
                personaCorrecta = false;
            }
            else
            {
                _textErrorNombre = "";
            }

            if (String.IsNullOrEmpty(PersonaSeleccionada == null ? "" : PersonaSeleccionada.apellidos))
            {
                _textErrorApellidos = "Los apellidos no debes estar en blanco.";
                personaCorrecta = false;
            }
            else
            {
                _textErrorApellidos = "";
            }

            if (String.IsNullOrEmpty(PersonaSeleccionada == null ? "" : PersonaSeleccionada.telefono))
            {
                _textErrorTelefono = "El telefono no debes estar en blanco.";
                personaCorrecta = false;
            }
            else
            {
                if (PersonaSeleccionada.telefono.Length != 9 || char.GetNumericValue(PersonaSeleccionada.telefono[0]) < 6 || char.GetNumericValue(PersonaSeleccionada.telefono[0]) > 8)
                {
                    _textErrorTelefono = "El telefono debe tener 9 digitos y empezar por 6, 7 o 8.";
                    personaCorrecta = false;
                }
                else
                {
                    _textErrorTelefono = "";
                }
            }

            NotifyPropertyChanged("TextErrorNombre");
            NotifyPropertyChanged("TextErrorApellidos");
            NotifyPropertyChanged("TextErrorTelefono");

            if (personaCorrecta)//Si todos los atributos de la persona son válidos
            {
                ClsPersonaHandler_BL clsPersonaHandler_BL = new ClsPersonaHandler_BL();
                if (PersonaSeleccionada.id == 0)//Si la id es por defecto, insertamos una nueva persona
                {
                    if (clsPersonaHandler_BL.insertarPersona(PersonaSeleccionada))
                    {
                        limpiarFoco();//Si se ha conseguido almacenar la persona, se limpiarán los textBox.
                        cargarImagen();//Cargamos la imagen por defecto si no hay ninguna persona seleccionada

                        _mensajeCreacionPersona = "Persona Guardada";//Mandamos un mensaje por pantalla
                        NotifyPropertyChanged("MensajeCreacionPersona");
                    }
                }
                else//Sino modificamos una de la base de datos
                {
                    clsPersonaHandler_BL.editarPersona(PersonaSeleccionada);
                    idPersona = PersonaSeleccionada.id;
                }

                _listadoPersonas = ClsListadosPersonasBL.listadoPersonas();
                NotifyPropertyChanged("ListadoPersonas");//Recargamos la lista de personas, al hacer esto desvinculamos la persona seleccionada

                if (idPersona != 0)//Si se ha realizado una modificación de una persona ya existente en la base de datos 
                {
                    _personaSeleccionada = clsPersonaHandler_BL.obtenerPersona(idPersona);
                    NotifyPropertyChanged("PersonaSeleccionada");//Actualizamos la persona seleccionada
                    _mensajeCreacionPersona = "Persona Guardada";//Recargamos eñ mensaje por pantalla
                    NotifyPropertyChanged("MensajeCreacionPersona");
                }
            }
        }

        #endregion

        #region Funciones extras, Fernando no sabia como llamar a estas funciones jaja saludos

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

            if (PersonaSeleccionada != null && PersonaSeleccionada.fotoPersona != null && PersonaSeleccionada.fotoPersona.Length != 0)//Si la persona seleccionada no es null y ya tiene una imagen
            {
                // Set the image source to the selected bitmap
                BitmapImage bitmapImage = new BitmapImage();

                bitmapImage = await ClsConversiones.byteArrayToBitmapAsync(PersonaSeleccionada.fotoPersona);
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
                }

                //Almacenamos la imagen en la persona seleccionada
                _personaSeleccionada.fotoPersona = await ClsConversiones.fileToByteArrayAsync(storageFile);
            }
        }

        /// <summary>
        /// Comentario: Este método nos permite limpiar los posibles mensajes mostrados
        /// por pantalla.
        /// </summary>
        private void limpiarMensajes()
        {
            _mensajeCreacionPersona = "";
            NotifyPropertyChanged("MensajeCreacionPersona");
            _textErrorNombre = "";
            NotifyPropertyChanged("TextErrorNombre");
            _textErrorApellidos = "";
            NotifyPropertyChanged("TextErrorApellidos");
            _textErrorTelefono = "";
            NotifyPropertyChanged("TextErrorTelefono");
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
                    writer.WriteBytes((byte[])_personaSeleccionada.fotoPersona);

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
