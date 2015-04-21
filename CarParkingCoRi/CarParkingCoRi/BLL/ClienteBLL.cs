using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarParkingCoRi.DAL;
using CarParkingCoRi.Model;
using System.Data.SqlClient;

namespace CarParkingCoRi.BLL
{
    public class ClienteBLL
    {
        public static Cliente obtenerClientePorId(int id)
        {
           
            try
            {
                return ClienteDAL.obtenerClientePorId(id);
            }
            catch (Exception err)
            {
                System.ArgumentException argEx = new System.ArgumentException("0x000033", err);
                throw argEx;
            }

        }

        public static List<Cliente> obtenerTodosCliente()
        {
            Cliente cliente = new Cliente();
            List<Cliente> listaCientes = new List<Cliente>();
            try
            {

                SqlDataReader vuelve=ClienteDAL.obtenerTodosCliente();
                while (vuelve.Read())
                {
                    int id = (int)vuelve["id"];
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
                    listaCientes.Add(cliente);
                }
                return listaCientes;
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
                return ClienteDAL.agregarCliente(cedula, nombre, apellido1, apellido2, telefono, placa, tipoServicio);

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
                return ClienteDAL.eliminarCliente(id);

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
               
                return ClienteDAL.modificarCliente(id,cedula,nombre,apellido1,apellido2,telefono,placa,tipoServicio);

            }
            catch (Exception err)
            {
                System.ArgumentException argEx = new System.ArgumentException("0x000033", err);
                throw argEx;
            }

        }
    }
}