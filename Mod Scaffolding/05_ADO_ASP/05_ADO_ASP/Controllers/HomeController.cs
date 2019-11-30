using _05_ADO_ASP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _05_ADO_ASP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()//Primera vez que entras
        {
            return View();
        }

        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost()
        {
            SqlConnection miConexion = new SqlConnection();
            ViewBag.texto = "";

            try
            {
                miConexion.ConnectionString = "server=yeray.database.windows.net; database =PersonasDB;uid=yeray;pwd=Mi_tesoro;";
                miConexion.Open();

                ViewBag.texto = miConexion.State;

                miConexion.Close();//Cerramos la conexión
            }
            catch (SqlException error)
            {
                ViewBag.texto = "Error en la conexión";
            }

            return View("Index");
        }

        public ActionResult ListaPersonas()
        {
            SqlConnection miConexion = new SqlConnection();
            List<ClsPersona> listaPersonas = new List<ClsPersona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            ClsPersona oPersona = null;
            ViewBag.texto = "";

            try
            {
                miConexion.ConnectionString = "server=yeray.database.windows.net; database =PersonasDB;uid=yeray;pwd=Mi_tesoro;";
                miConexion.Open();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)
                miComando.CommandText = "SELECT * FROM PD_Personas";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new ClsPersona();
                        oPersona.id = (int)miLector["IDPersona"];
                        oPersona.nombre = (string)miLector["NombrePersona"];
                        oPersona.apellidos = (string)miLector["ApellidosPersona"];
                        oPersona.fechaNacimiento = (DateTime)miLector["FechaNacimientoPersona"];
                        oPersona.telefono = (string)miLector["TelefonoPersona"];
                        listaPersonas.Add(oPersona);
                    }
                }
                ViewBag.texto = miConexion.State;

                miLector.Close();
                miConexion.Close();//Cerramos la conexión
            }
            catch (SqlException error)
            {
                ViewBag.texto = "Error en la conexión";
            }

            return View(listaPersonas);
        }
    }
}