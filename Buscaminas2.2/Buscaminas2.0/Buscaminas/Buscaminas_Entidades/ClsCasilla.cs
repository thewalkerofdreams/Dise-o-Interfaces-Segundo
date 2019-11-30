using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas_Entidades
{
    public class ClsCasilla : INotifyPropertyChanged
    {
        private int _id;
        private bool _bomb;
        private bool _discovered;
        //private String _imageAddress;

        public ClsCasilla()
        {
            _id = 0;
            _bomb = false;
            _discovered = false;
            //_imageAddress = "/Assets/icono_interrogante.png";
        }

        public ClsCasilla(int id)
        {
            _id = id;
            _bomb = false;
            _discovered = false;
            //_imageAddress = "/Assets/icono_interrogante.png";
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public bool Bomb
        {
            get
            {
                return _bomb;
            }
            set
            {
                _bomb = value;
                NotifyPropertyChanged();
            }
        }

        public bool Discovered
        {
            get
            {
                return _discovered;
            }
            set
            {
                _discovered = value;
                NotifyPropertyChanged("ImageAddress");//Cuando se modifique el estado para que se acualice la imagen
            }
        }

        public String ImageAddress{
            
            get {
                String _imageAddress;
                if (!_discovered)
                {
                    _imageAddress = "/Assets/icono_interrogante.png";
                }
                else
                {
                    if (_bomb)
                    {
                        _imageAddress = "/Assets/icono_mina.jpg";
                    }
                    else
                    {
                        _imageAddress = "/Assets/icono_cara.png";
                    }
                }
                NotifyPropertyChanged("ImageAddress");

                return _imageAddress;
            }
            
         }

        //public String ImageAddress
        //{
            //get
           // {  
               // return _imageAddress;
           // }
            //set
            //{
                //_imageAddress = value;
                //NotifyPropertyChanged();
            //}
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
