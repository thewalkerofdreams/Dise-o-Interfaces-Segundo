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
    public class ClsListadoCompanias_DAL
    {
        /// <summary>
        /// Nombre: obtenerListadoDeCompanias
        /// Comentario: Este método nos permite obtener un listado de las superheroes almacenadas en la base de datos.
        /// Cabecera: public ObservableCollection<ClsCompania> obtenerListadoDeCompanias()
        /// </summary>
        /// <returns>Devuelve un list del tipo ClsCompania</returns>
        public ObservableCollection<ClsCompania> obtenerListadoDeCompanias()
        {
            ObservableCollection<ClsCompania> listadoCompanias = new ObservableCollection<ClsCompania>();
            SqlDataReader miLector = null;
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection connection = null;
            try
            {
                connection = clsMyConnection.getConnection();//Es posible que no se pueda llegar a realizar la conexión y salte una excepción.
                SqlCommand sqlCommand = new SqlCommand();

                ClsCompania compania;


                sqlCommand.CommandText = "SELECT * FROM dbo.Companhias";
                sqlCommand.Connection = connection;

                miLector = sqlCommand.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        compania = new ClsCompania();
                        compania.Id = (Int16)miLector["ID"];
                        compania.Nombre = (miLector["Nombre"] is DBNull) ? "DEFAULT" : (string)miLector["Nombre"];
                        listadoCompanias.Add(compania);
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

            return listadoCompanias;
        }
    }
}
