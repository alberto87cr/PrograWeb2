using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CarParkingCoRi.Conexiones.Persistencia
{
    public class DataBase : IDisposable
    {

        public SqlConnection Conexion { get; set; }

        public SqlDataReader ExecuteReader(SqlCommand pSqlCommand)
        {
            SqlDataReader lector = null;
            try
            {
                pSqlCommand.Connection = Conexion;
                lector = pSqlCommand.ExecuteReader();
                return lector;
            }
            catch (Exception error)
            {
                log(MethodBase.GetCurrentMethod().Name, error + "\n" + "SQL " + pSqlCommand.CommandText);
                throw error;
            }
        }

        public DataSet ExecuteReader(SqlCommand pSqlCommand, String pTabla)
        {
            DataSet dsTabla = new DataSet();
            try
            {
                using (SqlDataAdapter adaptador = new SqlDataAdapter(pSqlCommand))
                {
                    pSqlCommand.Connection = Conexion;
                    dsTabla = new DataSet();
                    adaptador.Fill(dsTabla, pTabla);
                }
                return dsTabla;
            }
            catch (Exception error)
            {
                log(MethodBase.GetCurrentMethod().Name, error + "\n" + "SQL " + pSqlCommand.CommandText);
                throw error;
            }
            finally
            {
                if (dsTabla != null)
                    dsTabla.Dispose();
            }
        }

        public int ExecuteNonQuery(SqlCommand pSQLCommand, IsolationLevel pIsolationLevel)
        {
            using (SqlTransaction transaccion = Conexion.BeginTransaction(pIsolationLevel))
            {
                int registrosafectados = 0;
                try
                {
                    pSQLCommand.Connection = Conexion;
                    pSQLCommand.Transaction = transaccion;
                    registrosafectados = pSQLCommand.ExecuteNonQuery();
                    transaccion.Commit();
                    return registrosafectados;
                }
                catch (Exception error)
                {
                    log(MethodBase.GetCurrentMethod().Name, error + "\n" + "SQL " + pSQLCommand.CommandText.ToString());
                    throw error;
                }
            }
        }

        public int ExecuteNonQuery(SqlCommand pSQLCommand)
        {
            int registrosafectados = 0;
            try
            {
                pSQLCommand.Connection = Conexion;
                registrosafectados = pSQLCommand.ExecuteNonQuery();
                return registrosafectados;
            }
            catch (Exception error)
            {
                log(MethodBase.GetCurrentMethod().Name, error + "\n" + "SQL " + pSQLCommand.CommandText.ToString());
                throw error;
            }
        }

        public void ExecuteNonQuery(ref SqlCommand pSQLCommand, IsolationLevel pIsolationLevel)
        {
            using (SqlTransaction transaccion = Conexion.BeginTransaction(pIsolationLevel))
            {
                try
                {
                    pSQLCommand.Connection = Conexion;
                    pSQLCommand.Transaction = transaccion;
                    pSQLCommand.ExecuteNonQuery();
                    transaccion.Commit();
                }
                catch (Exception error)
                {
                    log(MethodBase.GetCurrentMethod().Name, error + "\n" + "SQL " + pSQLCommand.CommandText.ToString());
                    throw error;
                }
            }
        }

        public void ExecuteNonQuery(List<SqlCommand> pCommands, IsolationLevel pIsolationLevel)
        {
            using (SqlTransaction transaccion = Conexion.BeginTransaction(pIsolationLevel))
            {
                try
                {
                    foreach (SqlCommand command in pCommands)
                    {
                        command.Connection = Conexion;
                        command.Transaction = transaccion;
                        command.ExecuteNonQuery();
                    }
                    transaccion.Commit();
                }
                catch (Exception error)
                {
                    log(MethodBase.GetCurrentMethod().Name, error + "\n" + "SQL " + pCommands.ToString());
                    throw error;
                }
                finally
                {
                }
            }
        }

        #region Log

        private static void log(String pMetodo, String pMensaje)
        {
            String fecha = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + " Hora " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            String archivo = "C:\\simsansa\\dbConnect " + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".txt";
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
            String archivo = "C:\\simsansa\\dbConnect" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".txt";
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

        #region IDisposable Members

        public void Dispose()
        {
            if (Conexion != null)
                Conexion.Close();
        }

        #endregion
    }
}