using CarParkingCoRi.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CarParkingCoRi.BLL
{
    public class TarifaBLL
    {

        #region Public Methods

        public DataSet getRate(int tipoTarifa, double monto)
        {
            try
            {
                DataSet ds = new DataSet();
                //ds = TarifaDAL.getRate(tipoTarifa, monto);
                return ds;
            }
            catch (Exception err)
            {
                System.ArgumentException argEx = new System.ArgumentException("0x000032", err);
                throw argEx;
            }
        }



        #endregion

        #region Private Methods



        #endregion

    }
}