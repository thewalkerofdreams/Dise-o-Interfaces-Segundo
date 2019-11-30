using Buscaminas_Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Buscaminas_UI.ViewModels
{
    public class ClsMainPageVM : INotifyPropertyChanged
    {
        private List<ClsCasilla> _tablero;
        private ClsCasilla _casillaSeleccionada;
        private int _numeroCasillasSeleccionadas;

        public ClsMainPageVM()
        {
            ClsTablero tablero = new ClsTablero();
            _tablero = tablero.generarTableroSimple();
            _casillaSeleccionada = null;
            _numeroCasillasSeleccionadas = 0;
        }

        /// <summary>
        /// Comentario: Este método nos permite resetear el buscaminas.
        /// </summary>
        public void reset()
        {
            ClsTablero tablero = new ClsTablero();
            _tablero = tablero.generarTableroSimple();
            _casillaSeleccionada = null;
            _numeroCasillasSeleccionadas = 0;
            NotifyPropertyChanged("Tablero");
        }

        public List<ClsCasilla> Tablero
        {
            get
            {
                return _tablero;
            }
            set
            {
                _tablero = value;
                NotifyPropertyChanged();
            }
        }

        public ClsCasilla CasillaSeleccionada
        {
            get
            {
                return _casillaSeleccionada;
            }
            set
            {
                if (value != null && !value.Discovered)//Si la casilla no ha sido aún descubierta
                {
                    _casillaSeleccionada = value;
                    _casillaSeleccionada.Discovered = true;
                    //value.Discovered = true;
                    if (value.Bomb)//si la casilla tiene una mina
                    {
                        //value.ImageAddress = "/Assets/icono_mina.jpg";
                        mensajeFinPartida(false);//Mesanje de has perdido
                    }
                    else
                    {
                        _numeroCasillasSeleccionadas++;
                        //value.ImageAddress = "/Assets/icono_cara.png";
                        if (_numeroCasillasSeleccionadas >= 5)
                        {
                            mensajeFinPartida(true);//Mensaje de has ganado
                        }
                    }
                    
                    NotifyPropertyChanged();

                    //if (_casillaSeleccionada.ImageAddress.Equals("/Assets/icono_mina.jpg") || _numeroCasillasSeleccionadas >= 3)//Si la partida ha finalizado
                    //{
                        
                    //    reset();
                    //}
                }
                
            }
        }

        public int NumeroCasillasSeleccionadas
        {
            get
            {
                return _numeroCasillasSeleccionadas;
            }
            set
            {
                _numeroCasillasSeleccionadas = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Comentario: Este método nos permite mostrar un mensaje por pantalla,
        /// dependiendo del parámetro de entrada:
        /// Si el prametro de entrada es true significa que el jugador gano la partida y
        /// false indica justamente lo contrario. Al finalizar este método se reinicia el juego
        /// tras seleccionar el gialogo por pantalla.   //Lo último es nuevo sino queda muy fue por pantalla 
        /// Cabecera: public async void mensajeFinPartida(bool resultado)
        /// Entrada:
        ///     -bool resultado
        /// Postcondiciones: El método muestra un mensaje por pantalla.    
        /// </summary>
        /// <param name="resultado"></param>
        public async void mensajeFinPartida(bool resultado)
        {
            if (resultado)
            {
                var dialog = new MessageDialog("Has ganado chulo!!");
                await dialog.ShowAsync();
            }
            else
            {
                var dialog = new MessageDialog("Has perdido!!");
                await dialog.ShowAsync();
            }
            reset();//Para que await funcione correctamente
        }

    }
}
