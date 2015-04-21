using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarParkingCoRi.Class
{
    public class configs
    {

        #region Atributos

        public static string userDB { set; get; }
        public static string passDB { set; get; }
        public static string nameDB { set; get; }
        public static string nameStringDB { set; get; }
        public static string dateFormat { set; get; }

        #endregion

        #region singlenton
        private static configs instance = null;
        public static configs getInstance()
        {
            if (instance == null)
            {
                instance = new configs();
            }
            return instance;
        }
        #endregion

        #region public methods

        public configs()
        {
            userDB = "sa";
            passDB = "hacp1687";
            nameDB = "simsansa";
            nameStringDB = "conectionServer";
            dateFormat = "yyyyMMdd HH:mm:ss";
        }

        public string getNameStringDB()
        {
            return nameStringDB;
        }

        public string getDateFormat()
        {
            return dateFormat;
        }

        public string getUserDB()
        {
            return userDB;
        }

        public string getPassDB()
        {
            return passDB;
        }

        public string getNameDB()
        {
            return nameDB;
        }

        #endregion

    }
}