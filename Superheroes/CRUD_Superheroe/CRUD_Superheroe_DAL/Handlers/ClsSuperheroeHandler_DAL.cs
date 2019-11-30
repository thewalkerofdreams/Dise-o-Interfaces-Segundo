using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _CRUD_Superheroe_DAL.Connection;
using CRUD_Superheroe_Entities;

namespace CRUD_Superheroe_DAL.Handlers
{
    public class ClsSuperheroeHandler_DAL
    {
        /// <summary>
        /// Comentario: Este método nos permite modificar un heroe de la base de datos.
        /// </summary>
        /// <param name="superheroe">El tipo ClsSuperheroe</param>
        /// <returns></returns>
        public bool editarSuperheroe(ClsSuperheroe superheroe)
        {
            bool heroeEditado = true;
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection connection = null;

            try
            {
                connection = clsMyConnection.getConnection();//Es posible que no se pueda llegar a realizar la conexión y salte una excepción.
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.CommandText = "UPDATE Superheros SET Nombre = @Nombre, Apellidos = @Apellidos, Apodo = @Apodo, Sexo = @Sexo, IDCompanhia = @IdCompanhia, Foto = @Foto WHERE ID = @Id";
                sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = superheroe.Id;
                sqlCommand.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = superheroe.Nombre;
                sqlCommand.Parameters.Add("@Apellidos", System.Data.SqlDbType.VarChar).Value = superheroe.Apellidos;
                sqlCommand.Parameters.Add("@Apodo", System.Data.SqlDbType.VarChar).Value = superheroe.Apodo;
                sqlCommand.Parameters.Add("@Sexo", System.Data.SqlDbType.Char).Value = superheroe.Sexo;
                sqlCommand.Parameters.Add("@IdCompanhia", System.Data.SqlDbType.Int).Value = superheroe.IdCompania;
                if (superheroe.Foto != null && superheroe.Foto.Length != 0)//Si la foto no es nula o por defecto
                {
                    sqlCommand.Parameters.Add("@Foto", SqlDbType.VarBinary).Value = superheroe.Foto;
                }
                else
                {
                    sqlCommand.Parameters.Add("@Foto", SqlDbType.VarBinary).Value = new Byte[0];
                }

                sqlCommand.Connection = connection;
                if (sqlCommand.ExecuteNonQuery() == 0)//Si no indica que se haya modificado alguna fila
                {
                    heroeEditado = false;
                }

                clsMyConnection.closeConnection(ref connection);//Cerramos la conexión con la base de datos
            }
            catch (Exception e)
            {
                heroeEditado = false; //Esto podría modificarlo
                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    clsMyConnection.closeConnection(ref connection);
                }
            }


            return heroeEditado;
        }

        /// <summary>
        /// Comentario: Este método nos permite eliminar un heroe de la base de datos.
        /// </summary>
        /// <param name="id">Id del heroe</param>
        /// <returns>El método devuelve un valor booleano asociado al nombre, true si ha conseguido eliminar al heroe o false en caso contrario.</returns>
        public bool eliminarSuperheroe(int id)
        {
            bool heroeEliminado = true;
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection connection = null;

            try
            {
                connection = clsMyConnection.getConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.CommandText = "DELETE FROM Superheros WHERE ID = @Id";
                sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                sqlCommand.Connection = connection;
                if (sqlCommand.ExecuteNonQuery() == 0)//Si no indica que se haya modificado alguna fila
                {
                    heroeEliminado = false;
                }
            }
            catch (Exception e)
            {
                heroeEliminado = false;
                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    clsMyConnection.closeConnection(ref connection);//Cerramos la conexión con la base de datos
                }
            }

            return heroeEliminado;
        }

        /// <summary>
        /// Comentario: Este método nos permite insertar un superheroe en la base de datos. 
        /// </summary>
        /// <param name="superheroe">Un objeto del tipo ClsSuperheroe</param>
        /// <returns>El método devuelve un valor booleano asociado al nombre, true si se ha conseguido insertar el nuevo heroe o false en caso contrario.</returns>
        public bool insertarPersona(ClsSuperheroe superheroe)
        {
            bool heroeInsertado = true;
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection connection = null;

            try
            {
                connection = clsMyConnection.getConnection();//Es posible que no se pueda llegar a realizar la conexión y salte una excepción.
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.CommandText = "INSERT INTO Superheros(Nombre, Apellidos, Apodo, Sexo, IDCompanhia, Foto) values (@Nombre, @Apellidos, @Apodo, @Sexo, @IDCompanhia, @Foto)";
                sqlCommand.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = superheroe.Nombre;
                sqlCommand.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = superheroe.Apellidos;
                sqlCommand.Parameters.Add("@Apodo", SqlDbType.VarChar).Value = superheroe.Apodo;
                sqlCommand.Parameters.Add("@Sexo", SqlDbType.Char).Value = superheroe.Sexo;
                sqlCommand.Parameters.Add("@IDCompanhia", SqlDbType.Int).Value = superheroe.IdCompania;
                if (superheroe.Foto != null)
                {
                    sqlCommand.Parameters.Add("@Foto", SqlDbType.VarBinary).Value = superheroe.Foto;
                }
                else
                {
                    sqlCommand.Parameters.Add("@Foto", SqlDbType.VarBinary).Value = new Byte[0];
                }

                sqlCommand.Connection = connection;
                sqlCommand.ExecuteNonQuery();//Ejecutamos la inserción 
            }
            catch (Exception e)
            {
                heroeInsertado = false;
                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    clsMyConnection.closeConnection(ref connection);
                }
            }

            return heroeInsertado;
        }

        /// <summary>
        /// Comentario: Este método nos permite obtener un superheroe de la base de datos.
        /// </summary>
        /// <param name="id">Id del superheroe</param>
        /// <returns>El método devuelve un tipo ClsSuperheroe asociado al nombre, que es el superheroe buscado o null si ese heroe no existe en la base de datos.</returns>
        public ClsSuperheroe obtenerSuperheroe(int id)
        {
            ClsSuperheroe superhero = null;
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection connection = null;

            try
            {
                connection = clsMyConnection.getConnection();
                SqlDataReader miLector;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.CommandText = "SELECT ID, Nombre, Apellidos, Apodo, Sexo, Foto, IDCompanhia FROM Superheros WHERE ID = @Id";
                sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                sqlCommand.Connection = connection;
                miLector = sqlCommand.ExecuteReader();

                if (miLector.HasRows)
                {
                    miLector.Read();//Leemos la primera columna
                    superhero = new ClsSuperheroe();
                    superhero.Id = (Int16)miLector["ID"];
                    superhero.IdCompania = (miLector["IDCompanhia"] is DBNull) ? 0 : (Int16)miLector["IDCompanhia"];
                    superhero.Foto = (miLector["Foto"] is DBNull) ? new byte[0] : (byte[])miLector["Foto"];
                    superhero.Nombre = (miLector["Nombre"] is DBNull) ? "DEFAULT" : (string)miLector["Nombre"];
                    superhero.Apellidos = (miLector["Apellidos"] is DBNull) ? "DEFAULT" : (string)miLector["Apellidos"];
                    superhero.Apodo = (miLector["Apodo"] is DBNull) ? "DEFAULT" : (string)miLector["Apodo"];
                    superhero.Sexo = (miLector["Sexo"] is DBNull) ? "W" : (String)miLector["Sexo"];
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    clsMyConnection.closeConnection(ref connection);//Cerramos la conexión con la base de datos
                }
            }

            return superhero;
        }
    }
}
