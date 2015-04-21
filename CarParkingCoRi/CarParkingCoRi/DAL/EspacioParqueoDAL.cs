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
    public class EspacioParqueoDAL
    {

        internal static DataSet getEspacio(int id)
        {
            try
            {
                DataSet vuelve = new DataSet();
                configs cf = configs.getInstance();
                string dateFormat = cf.getNameStringDB();
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@id", id);

                command.CommandText = "usp_SELECT_EspacioParqueo_ByID";
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

        internal static int insertarEspacio()
        {
            try
            {

                configs cf = configs.getInstance();
                string dateFormat = cf.getNameStringDB();
                SqlCommand command = new SqlCommand();
                command.CommandText = "Insert into EspacioParqueo values (1,0)";
                command.CommandType = CommandType.Text;
                string userDB = cf.getUserDB();
                string passDB = cf.getPassDB();
                string nameDB = cf.getNameDB();
                using (DataBase db = DatabaseFactory.createdatabase(nameDB, userDB, passDB))
                {

                    return db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

            }
            catch (Exception err)
            {
                System.ArgumentException argEx = new System.ArgumentException("0x000033", err);
                throw argEx;
            }
        }


        internal static int eliminarEspacio()
        {
            try
            {

                configs cf = configs.getInstance();
                string dateFormat = cf.getNameStringDB();
                SqlCommand command = new SqlCommand();
                command.CommandText = "delete from EspacioParqueo where id=(select min(id) from EspacioParqueo)";
                command.CommandType = CommandType.Text;
                string userDB = cf.getUserDB();
                string passDB = cf.getPassDB();
                string nameDB = cf.getNameDB();
                using (DataBase db = DatabaseFactory.createdatabase(nameDB, userDB, passDB))
                {

                    return db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

            }
            catch (Exception err)
            {
                System.ArgumentException argEx = new System.ArgumentException("0x000033", err);
                throw argEx;
            }
        }

        internal static int seleccionarEspaciosDisponibles()
        {
            try
            {

                configs cf = configs.getInstance();
                string dateFormat = cf.getNameStringDB();
                SqlCommand command = new SqlCommand();
                command.CommandText = "select count (id) from EspacioParqueo where disponible=1 and reservado=0";
                command.CommandType = CommandType.Text;
                string userDB = cf.getUserDB();
                string passDB = cf.getPassDB();
                string nameDB = cf.getNameDB();
                using (DataBase db = DatabaseFactory.createdatabase(nameDB, userDB, passDB))
                {

                    int disponibles = Convert.ToInt32(command.ExecuteScalar());
                    return disponibles;
                }

            }

            catch (Exception err)
            {
                System.ArgumentException argEx = new System.ArgumentException("0x000033", err);
                throw argEx;
            }
        }

        internal static int ocuparEspacio()
        {
            try
            {

                configs cf = configs.getInstance();
                string dateFormat = cf.getNameStringDB();
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE EspacioParqueo SET disponible=0 where id=(select max (id) from EspacioParqueo where disponible=1 and reservado=0)";
                command.CommandType = CommandType.Text;
                string userDB = cf.getUserDB();
                string passDB = cf.getPassDB();
                string nameDB = cf.getNameDB();
                using (DataBase db = DatabaseFactory.createdatabase(nameDB, userDB, passDB))
                {

                    int insertado= db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                    if (insertado == 0)
                    {
                        return -1;
                    }
                    else
                    {
                        return insertado;
                    }
                }

            }
            catch (Exception err)
            {
                System.ArgumentException argEx = new System.ArgumentException("0x000033", err);
                throw argEx;
            }
        }

        internal static int desocuparEspacio()
        {
            try
            {

                configs cf = configs.getInstance();
                string dateFormat = cf.getNameStringDB();
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE EspacioParqueo SET disponible=1 where id=(select max (id) from EspacioParqueo where disponible=0 and reservado=0)";
                command.CommandType = CommandType.Text;
                string userDB = cf.getUserDB();
                string passDB = cf.getPassDB();
                string nameDB = cf.getNameDB();
                using (DataBase db = DatabaseFactory.createdatabase(nameDB, userDB, passDB))
                {

                    int insertado = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                    if (insertado == 0)
                    {
                        return -1;
                    }
                    else
                    {
                        return insertado;
                    }
                }

            }
            catch (Exception err)
            {
                System.ArgumentException argEx = new System.ArgumentException("0x000033", err);
                throw argEx;
            }
        }

        //crear metodo actualizar reservaciones
    }
}