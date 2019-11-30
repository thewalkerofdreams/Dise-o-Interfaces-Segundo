using CRUD_Superheroe_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _CRUD_Superheroe_DAL.Connection;

namespace CRUD_Superheroe_DAL.Lists
{
    public class ClsListadoSuperheroes_DAL
    {
        /// <summary>
        /// Nombre: obtenerListadoDeSuperheroes
        /// Comentario: Este método nos permite obtener un listado de las superheroes almacenadas en la base de datos.
        /// Cabecera: public ObservableCollection<ClsSuperheroe> obtenerListadoDeSuperheroes(int idCompania)
        /// </summary>
        /// <paramref name="idCompania"/>
        /// <returns>Devuelve un list del tipo ClsSuperheroe</returns>
        public ObservableCollection<ClsSuperheroe> obtenerListadoDeSuperheroes(int idCompania)
        {
            ObservableCollection<ClsSuperheroe> listadoHeroes = new ObservableCollection<ClsSuperheroe>();
            SqlDataReader miLector = null;
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection connection = null;
            try
            {
                connection = clsMyConnection.getConnection();//Es posible que no se pueda llegar a realizar la conexión y salte una excepción.
                SqlCommand sqlCommand = new SqlCommand();

                ClsSuperheroe superheroe;

                sqlCommand.CommandText = "SELECT * FROM Superheros WHERE IDCompanhia = "+ idCompania;
                sqlCommand.Connection = connection;

                miLector = sqlCommand.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {   
                        superheroe = new ClsSuperheroe();
                        superheroe.Id = (Int16)miLector["ID"];
                        superheroe.IdCompania = (miLector["IDCompanhia"] is DBNull) ? 0 : (Int16)miLector["IDCompanhia"];
                        superheroe.Foto = (miLector["Foto"] is DBNull) ? new Byte[0] : (Byte[])miLector["Foto"];
                        superheroe.Nombre = (miLector["Nombre"] is DBNull) ? "DEFAULT" : (string)miLector["Nombre"];
                        superheroe.Apellidos = (miLector["Apellidos"] is DBNull) ? "DEFAULT" : (string)miLector["Apellidos"];
                        superheroe.Apodo = (miLector["Apodo"] is DBNull) ? "DEFAULT" : (string)miLector["Apodo"];
                        superheroe.Sexo = (miLector["Sexo"] is DBNull) ? "W": (String)miLector["Sexo"];
                        listadoHeroes.Add(superheroe);
                    }
                }

                miLector.Close();
                clsMyConnection.closeConnection(ref connection);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (miLector != null)
                {
                    miLector.Close();
                }

                if (connection != null)
                {
                    clsMyConnection.closeConnection(ref connection);
                }
            }

            return listadoHeroes;
        }
    }
}
