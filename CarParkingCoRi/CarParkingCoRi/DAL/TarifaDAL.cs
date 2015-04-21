using CarParkingCoRi.Class;
using CarParkingCoRi.Conexiones.Persistencia;
using CarParkingCoRi.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarParkingCoRi.DAL
{
    public class TarifaDAL
    {
        public static List<Tarifa> obtenerTodasTarifa()
        {
            try
            {
                SqlDataReader vuelve;
                List<Tarifa> listaTarifas=new List<Tarifa>();
                Tarifa tarifa = new Tarifa();
                configs cf = configs.getInstance();
                string dateFormat = cf.getNameStringDB();
                SqlCommand command = new SqlCommand();
                command.CommandText = "Select tipoTarifa,monto from Tarifas";
                command.CommandType = CommandType.Text;
                string userDB = cf.getUserDB();
                string passDB = cf.getPassDB();
                string nameDB = cf.getNameDB();
                using (DataBase db = DatabaseFactory.createdatabase(nameDB, userDB, passDB))
                {
                    vuelve = db.ExecuteReader(command);
                    while (vuelve.Read())
                    {
                        int tipo = (int)vuelve["TipoTarifa"];
                        double monto = (double)vuelve["monto"];
                        tarifa.tipoTarifa = tipo;
                        tarifa.monto = monto;
                        listaTarifas.Add(tarifa);
                    }
                }
                return listaTarifas;
            }
            catch (Exception err)
            {
                System.ArgumentException argEx = new System.ArgumentException("0x000033", err);
                throw argEx;
            }



        }

        public int modificarTarifa(int tipoTarifa,decimal monto)
        {
            try
            {
                int vuelve;
                configs cf = configs.getInstance();
                string dateFormat = cf.getNameStringDB();
                SqlCommand command = new SqlCommand();
                command.CommandText = "update Tarifas set monto="+monto+" where tipoTarifa="+tipoTarifa;
                command.CommandType = CommandType.Text;
                string userDB = cf.getUserDB();
                string passDB = cf.getPassDB();
                string nameDB = cf.getNameDB();
                using (DataBase db = DatabaseFactory.createdatabase(nameDB, userDB, passDB))
                {
                    vuelve = db.ExecuteNonQuery(command);
                    //db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                }

                return vuelve;

            }
            catch (Exception err)
            {
                System.ArgumentException argEx = new System.ArgumentException("0x000033", err);
                throw argEx;
            }
        }

        public int eliminarTarifa(int tipoTarifa)
        {
            try
            {
                int vuelve;
                configs cf = configs.getInstance();
                string dateFormat = cf.getNameStringDB();
                SqlCommand command = new SqlCommand();
                command.CommandText = "update Tarifas set estado=0 where tipoTarifa=" + tipoTarifa;
                command.CommandType = CommandType.Text;
                string userDB = cf.getUserDB();
                string passDB = cf.getPassDB();
                string nameDB = cf.getNameDB();
                using (DataBase db = DatabaseFactory.createdatabase(nameDB, userDB, passDB))
                {
                    vuelve = db.ExecuteNonQuery(command);
                    //db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                }

                return vuelve;

            }
            catch (Exception err)
            {
                System.ArgumentException argEx = new System.ArgumentException("0x000033", err);
                throw argEx;
            }
        }

        public int insertarTarifa(string descripcion, decimal monto)
        {
            try
            {
                int vuelve;
                configs cf = configs.getInstance();
                string dateFormat = cf.getNameStringDB();
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@monto", monto);
                command.CommandText = "prc_insertarNuevaTarifa";
                command.CommandType = CommandType.StoredProcedure;
                string userDB = cf.getUserDB();
                string passDB = cf.getPassDB();
                string nameDB = cf.getNameDB();
                using (DataBase db = DatabaseFactory.createdatabase(nameDB, userDB, passDB))
                {
                    vuelve = db.ExecuteNonQuery(command);
                    //db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                }
               
                return vuelve;

            }
            catch (Exception err)
            {
                System.ArgumentException argEx = new System.ArgumentException("0x000033", err);
                throw argEx;
            }
        }

    }
}