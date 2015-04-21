using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarParkingCoRi.DAL;


namespace CarParkingCoRi.BLL
{
    public class EspacioParqueoBLL
    {
        internal static int insertarEspacio()
        {
            try
            {
                return EspacioParqueoDAL.insertarEspacio();

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

                return EspacioParqueoDAL.eliminarEspacio();

            }
            catch (Exception err)
            {
                System.ArgumentException argEx = new System.ArgumentException("0x000033", err);
                throw argEx;
            }
        }

        internal static int seleccionarEspaciosDisponibles()
        {
           return EspacioParqueoDAL.seleccionarEspaciosDisponibles();
        }


        internal static int ocuparEspacio()
        {
            try
            {
                return EspacioParqueoDAL.ocuparEspacio();//retorna -1 si no logro actualizar
                
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
                return EspacioParqueoDAL.desocuparEspacio();

            }
            catch (Exception err)
            {
                System.ArgumentException argEx = new System.ArgumentException("0x000033", err);
                throw argEx;
            }
        }

    }
}