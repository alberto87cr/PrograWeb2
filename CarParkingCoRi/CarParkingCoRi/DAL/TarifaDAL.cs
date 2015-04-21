using CarParkingCoRi.Class;
using CarParkingCoRi.Conexiones.Persistencia;
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

        internal static DataSet getRate(int tipoTarifa, double monto)
        {
            try
            {
                DataSet vuelve = new DataSet();
                configs cf = configs.getInstance();
                string dateFormat = cf.getNameStringDB();
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@tipoTarifa", tipoTarifa);
                command.Parameters.AddWithValue("@monto", monto);
                command.CommandText = "usp_tarifasGetRate";
                command.CommandType = CommandType.StoredProcedure;
                string userDB = cf.getUserDB();
                string passDB = cf.getPassDB();
                string nameDB = cf.getNameDB();
                using (DataBase db = DatabaseFactory.createdatabase(nameDB, userDB, passDB))
                {
                    vuelve = db.ExecuteReader(command, "consulta");
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

        internal static DataSet leerClasesNombres()
        {
            DataSet dsLista = new DataSet();
            string query = @"SELECT * FROM Tarifas";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            string userDB = configs.userDB;
            string passDB = configs.passDB;
            string nameDB = configs.nameDB;
            using (DataBase db = DatabaseFactory.createdatabase(nameDB, userDB, passDB))
            {
                dsLista = db.ExecuteReader(command, "consulta");
            }
            return dsLista;
        }

    }
}