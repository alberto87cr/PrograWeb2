using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarParkingCoRi.Class
{
    public class functions
    {
        #region Atributos

        public static string hostRoot { set; get; }
        public static string errorPage { set; get; }
        public static string errorPageExtern { set; get; }
        public static string loginRoot { set; get; }
        public static string homeRoot { set; get; }
        public static string UsersRoot { set; get; }
        public static string VehiclesRoot { set; get; }
        public static string AreasRoot { set; get; }
        public static string CustomersRoot { set; get; }
        public static string indexPage { set; get; }
        public static string AddPage { set; get; }
        public static string DeletePage { set; get; }
        public static string UpdatePage { set; get; }
        public static string ListPage { set; get; }
        public static string DetailPage { set; get; }
        public static string nameStringDB { set; get; }

        #endregion

        #region singlenton

        private static functions instance = null;
        public static functions getInstance()
        {
            if (instance == null)
            {
                instance = new functions();
            }
            return instance;
        }
        public void destroyInstance(bool confirm)
        {
            if (confirm)
            {
                functions.instance = null;
            }
        }

        #endregion

        #region Public Methods

        // Empty Constructor
        public functions()
        {
            hostRoot = "";
            // Errors Pages
            errorPage = "Views/Others/errors.aspx";
            errorPageExtern = "Views/Others/errorShow.aspx";
            // Login Pages or Paths
            loginRoot = "Views/Login/";
            // Home Pages or Paths
            homeRoot = "Views/Home/";
            // Users Pages or Paths
            UsersRoot = "Views/Users/";
            // Vehicles Pages or Paths
            VehiclesRoot = "Views/Vehicles/";
            // Costumers Pages or Paths
            CustomersRoot = "Views/Costumers/";
            // Parking Areas Pages or Paths
            AreasRoot = "Views/ParkingAreas/";
            // Globals Pages or Paths
            indexPage = "Index.aspx";
            AddPage = "add.aspx";
            DeletePage = "delete.aspx";
            UpdatePage = "update.aspx";
            ListPage = "list.aspx";
            DetailPage = "detail.aspx";
            // Database Conections
            nameStringDB = "conectionServer";
        }

        public void setRootPath(Uri RequestP)
        {
            hostRoot = RequestP.AbsoluteUri.Replace(RequestP.AbsolutePath, "") + "/";
        }

        // Globals Paths

        public string getRootPath()
        {
            return hostRoot;
        }

        public bool isNullRootPath()
        {
            if (functions.getInstance().getRootPath().Equals(""))
                return true;
            else
                return false;
        }

        public string getErrorPage()
        {
            return hostRoot + errorPage;
        }

        // Sections Paths

        public string getErrorExternPage()
        {
            return hostRoot + errorPageExtern;
        }

        public string getLoginPath()
        {
            return hostRoot + loginRoot;
        }

        public string getHomePath()
        {
            return hostRoot + homeRoot;
        }

        public string getUsersPath()
        {
            return hostRoot + UsersRoot;
        }

        public string getCustomersPath()
        {
            return hostRoot + CustomersRoot;
        }

        public string getAreasPath()
        {
            return hostRoot + AreasRoot;
        }

        public string getVehiclesPath()
        {
            return hostRoot + VehiclesRoot;
        }

        // Pages

        public string getIndexPage()
        {
            return indexPage;
        }

        public string getAddPage()
        {
            return AddPage;
        }

        public string getDeletePage()
        {
            return DeletePage;
        }

        public string getUpdatePage()
        {
            return UpdatePage;
        }

        public string getListPage()
        {
            return ListPage;
        }

        public string getDetailPage()
        {
            return DetailPage;
        }

        public string getDataBaseString()
        {
            return nameStringDB;
        }

        #endregion

        #region Private Methods

        #endregion

    }
}