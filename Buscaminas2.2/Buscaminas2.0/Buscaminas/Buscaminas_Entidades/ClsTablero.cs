using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas_Entidades
{
    public class ClsTablero
    {
        /// <summary>
        /// Comentario: Este método nos permite generar un tablero de 8 x 8
        /// casillas, con 6 minas en el tablero.
        /// Postcondiciones: El método devuelve una lista de 64 casillas del tipo
        /// ClsCasilla.
        /// </summary>
        /// <returns></returns>
        public List<ClsCasilla> generarTableroSimple()
        {
            List<ClsCasilla> tableroSimple = new List<ClsCasilla>();
            Random random = new Random();
            int posicionCasilla = 0;

            for (int i = 0; i < 64; i++)//generar las 64 casillas
            {
                tableroSimple.Add(new ClsCasilla(i));//La primera casilla tendrá id 0
            }

            for (int i = 0; i < 6; i++)//Insertamos las 6 minas
            {
                posicionCasilla = random.Next(0, 63);
                if (!tableroSimple.ElementAt(posicionCasilla).Bomb)//Si la casilla no tiene una mina
                {
                    tableroSimple.ElementAt(posicionCasilla).Bomb = true;//Le insertamos la mina
                }
                else//si esa casilla ya tiene una bomba
                {
                    i--;
                }
            }

            return tableroSimple;
        }


    }
}
