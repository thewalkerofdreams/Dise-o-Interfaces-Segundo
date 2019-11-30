using _18_CRUD_Personas_UWP_Entities;
using System;
using _18_CRUD_Personas_UWP_DAL.Connections;
using System.Data;
using System.Data.SqlClient;

namespace _18_CRUD_Personas_UWP_DAL.Handler
{
    public class ClsDepartamentoHandler_DAL
    {
        /// <summary>
        /// Comentario: Este método nos permite obtener un departamento de la base de datos.
        /// </summary>
        /// <param name="id">Id del departamento</param>
        /// <returns>El método devuelve un clsDepartamento asociado al nombre o null, si no se ha encontrado un departamento con esa id en la base de datos.</returns>
        public clsDepartamento obtenerDepartamento(int id)
        {
            clsDepartamento departamento = null;
            clsMyConnection clsMyConnection = new clsMyConnection("yeray.database.windows.net", "PersonasDB", "yeray", "Mi_tesoro"); ;
            SqlDataReader miLector = null;
            SqlConnection connection = null;
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.CommandText = "SELECT IdDepartamento, NombreDepartamento FROM PD_Departamentos WHERE IdDepartamento = @Id";
                sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                sqlCommand.Connection = connection;
                miLector = sqlCommand.ExecuteReader();

                if (miLector.HasRows)
                {
                    miLector.Read();//Leeemos la primera columna
                    departamento = new clsDepartamento();
                    departamento.Id = (int)miLector["IdDepartamento"];
                    departamento.Nombre = (string)miLector["NombreDepartamento"];
                }
            }
            catch (Exception e)
            {
                //ClsMensajes.mensajeErrorSQLAsync();
                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    clsMyConnection.closeConnection(ref connection);
                }

                if (miLector != null)
                {
                    miLector.Close();
                }     
            }

            return departamento;
        }
    }
}
