
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using _18_CRUD_Personas_UWP_DAL.Connections;
using _18_CRUD_Personas_UWP_Entities;

namespace _18_CRUD_Personas_UWP_DAL.Lists
{
    public class ClsListadosDepartamentosDAL
    {
        /// <summary>
        /// Comentario: Este método nos permite obtener todos los departamentos de la base de datos.
        /// </summary>
        /// <returns>El método devuelve una lista del tipo clsDepartamento, que son todos los departamentos de la base de datos.</returns>
        public static ObservableCollection<clsDepartamento> obtenerListadoDeDepartamentos()
        {
            ObservableCollection<clsDepartamento> listadoDepartamentos = new ObservableCollection<clsDepartamento>();

            clsMyConnection clsMyConnection = clsMyConnection = new clsMyConnection("yeray.database.windows.net", "PersonasDB", "yeray", "Mi_tesoro");
            SqlConnection connection = null;
            SqlDataReader miLector = null;
            try
            {
                connection = clsMyConnection.getConnection();//Es posible que no se pueda llegar a realizar la conexión y salte una excepción.
                SqlCommand sqlCommand = new SqlCommand();
                
                clsDepartamento departamento;    
                sqlCommand.CommandText = "SELECT * FROM PD_Departamentos";
                sqlCommand.Connection = connection;

                miLector = sqlCommand.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        departamento = new clsDepartamento();
                        departamento.Id = (int)miLector["IdDepartamento"];
                        departamento.Nombre = (string)miLector["NombreDepartamento"];
                        listadoDepartamentos.Add(departamento);
                    }
                }
            }
            catch (Exception e)//Es posible que no podamos acceder a la base de datos
            {
                throw e;
            }
            finally
            {
                if(connection != null)
                {
                    clsMyConnection.closeConnection(ref connection);
                }

                if (miLector != null)
                {
                    miLector.Close();
                }
            }

            return listadoDepartamentos;
        }

    }
}
