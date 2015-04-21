using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CarParkingCoRi.Conexiones.Persistencia
{
    public class DatabaseFactory
    {

        public static DataBase createDataBase(string pDataBase)
        {
            String con = "";
            try
            {
                DataBase db = new DataBase();
                con = ConfigurationManager.ConnectionStrings[pDataBase].ToString();
                SqlConnection conexion = new SqlConnection(con);
                conexion.Open();
                db.Conexion = conexion;
                if (conexion.State != ConnectionState.Open)
                {
                    throw new Exception("No se pudo abrir la Base de Datos, revise los parámetros de conexión! ");
                }
                return db;
            }
            catch (Exception error)
            {
                log(MethodBase.GetCurrentMethod().Name, error + "\n" + " Conexion " + con + "\nParámetro" + pDataBase);
                throw error;
            }
        }

        public static DataBase createdatabase(string pdatabase, string pusuario, string pcontrasena)
        {
            String con = "";
            try
            {
                DataBase db = new DataBase();
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = ConfigurationManager.ConnectionStrings["conectionCompaq"].ConnectionString;
                conexion.Open();
                db.Conexion = conexion;
                if (conexion.State != ConnectionState.Open)
                {
                    throw new Exception("No se pudo abrir la Base de Datos, revise los parámetros de conexión! ");
                }
                return db;
            }
            catch (SqlException sqlErr)
            {
                System.ArgumentException argEx = new System.ArgumentException("0x000035", sqlErr);
                throw argEx;
            }
            catch (Exception error)
            {
                log(MethodBase.GetCurrentMethod().Name, error + "\n" + " Conexion " + con + "Parámetro :" + pdatabase);
                System.ArgumentException argEx = new System.ArgumentException("0x000034", error);
                throw argEx;
            }
        }

        #region Log

        private static void log(String pMetodo, String pMensaje)
        {
            String fecha = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + " Hora " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            String archivo = "C:\\simsansa\\Error_Conexion_Base_Datos " + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".txt";
            if (System.IO.File.Exists(@archivo) == false)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(@archivo);
                file.WriteLine("------------------------------------------");
                file.WriteLine("Método :" + pMetodo);
                file.WriteLine("Fecha  :" + fecha);
                file.WriteLine("Detalle");
                file.WriteLine("\n");
                file.WriteLine("Message " + pMensaje);
                file.WriteLine("\n");
                file.WriteLine("------------------------------------------");
                file.WriteLine("\n");
                file.Close();
            }
            else
            {
                System.IO.StreamWriter file;
                file = System.IO.File.AppendText(@archivo);
                file.WriteLine("------------------------------------------");
                file.WriteLine("Método :" + pMetodo);
                file.WriteLine("Fecha  :" + fecha);
                file.WriteLine("Detalle");
                file.WriteLine("\n");
                file.WriteLine("Message " + pMensaje);
                file.WriteLine("\n");
                file.WriteLine("------------------------------------------");
                file.WriteLine("\n");
                file.Close();
            }
        }

        private void log(String pMetodo, Exception error)
        {
            String fecha = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + " Hora " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            String archivo = "C:\\simsansa\\Error_Conexion_Base_Datos" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".txt";
            try
            {
                if (System.IO.File.Exists(@archivo) == false)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(@archivo);
                    file.WriteLine("------------------------------------------");
                    file.WriteLine("Método :" + pMetodo);
                    file.WriteLine("Fecha  :" + fecha);
                    file.WriteLine("Detalle");
                    file.WriteLine("\n");
                    file.WriteLine("Message " + error.Message);
                    file.WriteLine("\n");
                    file.WriteLine("StackTrace " + error.StackTrace);
                    file.WriteLine("\n");
                    file.WriteLine("Source " + error.Source);
                    file.WriteLine("\n");
                    file.WriteLine("ToString() " + error.ToString());
                    file.WriteLine("------------------------------------------");
                    file.WriteLine("\n");
                    file.Close();
                }
                else
                {
                    System.IO.StreamWriter file;
                    file = System.IO.File.AppendText(@archivo);
                    file.WriteLine("------------------------------------------");
                    file.WriteLine("Método :" + pMetodo);
                    file.WriteLine("Fecha  :" + fecha);
                    file.WriteLine("Detalle");
                    file.WriteLine("\n");
                    file.WriteLine("Message " + error.Message);
                    file.WriteLine("\n");
                    file.WriteLine("StackTrace " + error.StackTrace);
                    file.WriteLine("\n");
                    file.WriteLine("Source " + error.Source);
                    file.WriteLine("\n");
                    file.WriteLine("ToString() " + error.ToString());
                    file.WriteLine("------------------------------------------");
                    file.WriteLine("\n");
                    file.Close();
                }
            }
            catch { }
        }

        #endregion

    }

}
