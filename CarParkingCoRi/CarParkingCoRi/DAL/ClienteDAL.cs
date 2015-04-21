using CarParkingCoRi.Class;
using CarParkingCoRi.Conexiones.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarParkingCoRi.Model;

namespace CarParkingCoRi.DAL
{
    public class ClienteDAL
    {
        public static Cliente obtenerClientePorId(int id)
        {
            Cliente cliente = new Cliente();
            try
            {
                SqlDataReader vuelve;
                configs cf = configs.getInstance();
                string dateFormat = cf.getNameStringDB();
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@id", id);
                command.CommandText = "usp_SELECT_ClientesPorMes_ByID";
                command.CommandType = CommandType.StoredProcedure;
                string userDB = cf.getUserDB();
                string passDB = cf.getPassDB();
                string nameDB = cf.getNameDB();
                using (DataBase db = DatabaseFactory.createdatabase(nameDB, userDB, passDB))
                {
                    vuelve = db.ExecuteReader(command);
                    //db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                    while (vuelve.Read())
                    {

                        string cedula = (string)vuelve["cedula"];
                        string nombre = (string)vuelve["nombre"];
                        string apellido1 = (string)vuelve["apellido1"];
                        string apellido2 = (string)vuelve["apellido2"];
                        string telefono = (string)vuelve["telefono"];
                        string placa = (string)vuelve["placa"];
                        string tipoServicio = (string)vuelve["descripcion"];
                        bool estado = (bool)vuelve["estado"];
                        cliente.id = id;
                        cliente.cedula = cedula;
                        cliente.nombre = nombre;
                        cliente.apellido1 = apellido1;
                        cliente.apellido2 = apellido2;
                        cliente.telefono = telefono;
                        cliente.placa = placa;
                        cliente.tipoServicio = tipoServicio;
                        cliente.estado = estado;
                    }
                }


                return cliente;
            }
            catch (Exception err)
            {
                System.ArgumentException argEx = new System.ArgumentException("0x000033", err);
                throw argEx;
            }

        }

        public static SqlDataReader obtenerTodosCliente()
        {
            try
            {
                SqlDataReader vuelve;
                configs cf = configs.getInstance();
                string dateFormat = cf.getNameStringDB();
                SqlCommand command = new SqlCommand();
                command.CommandText = "Select c.id ,c.cedula, c.nombre, c.apellido1, c.apellido2, c.telefono, c.placa, t.descripcion, c.estado" +
                " from Clientes c inner join TipoServicio t on c.tipoServicio=t.id";
                command.CommandType = CommandType.Text;
                string userDB = cf.getUserDB();
                string passDB = cf.getPassDB();
                string nameDB = cf.getNameDB();
                using (DataBase db = DatabaseFactory.createdatabase(nameDB, userDB, passDB))
                {
                    vuelve = db.ExecuteReader(command);
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

        public static int agregarCliente(string cedula, string nombre, string apellido1, string apellido2, string telefono, string placa, int tipoServicio)
        {
            try
            {
                DataSet vuelve = new DataSet();
                configs cf = configs.getInstance();
                string dateFormat = cf.getNameStringDB();
                SqlCommand command = new SqlCommand();
                command.CommandText = "INSERT INTO Clientes(cedula, nombre, apellido1, apellido2, telefono, placa, tipoServicio, estado) VALUES" +
                    "('" + cedula + "','" + nombre + "','" + apellido1 + "','" + apellido2 + "','" + telefono + "','" + placa + "'," + tipoServicio + ",1)";
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

        public static int eliminarCliente(int id)
        {
            try
            {
                DataSet vuelve = new DataSet();
                configs cf = configs.getInstance();
                string dateFormat = cf.getNameStringDB();
                SqlCommand command = new SqlCommand();
                command.CommandText = "Update Clientes set estado=0 where id=" + id;
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

        public static int modificarCliente(int id, string cedula, string nombre, string apellido1, string apellido2, string telefono, string placa, int tipoServicio)
        {
            try
            {
                int vuelve;
                configs cf = configs.getInstance();
                string dateFormat = cf.getNameStringDB();
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@cedula", cedula);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido1", apellido1);
                command.Parameters.AddWithValue("@apellido2", apellido2);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@placa", placa);
                command.Parameters.AddWithValue("@tipoServicio", tipoServicio);
                command.CommandText = "usp_Update_ClientesPorMes_ByID";
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