using CarParkingCoRi.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarParkingCoRi.Views
{
    public partial class Intern : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loadRootPath()
        {
            functions fs = functions.getInstance();
            if (fs.isNullRootPath())
            {
                Uri MyUrl = Request.Url;
                fs.setRootPath(MyUrl);
            }
        }

        protected string rootPath()
        {
            return functions.getInstance().getRootPath();
        }

        protected string VehiclesPath()
        {
            return functions.getInstance().getVehiclesPath();
        }

        protected string CustomersPath()
        {
            return functions.getInstance().getCustomersPath();
        }

        protected string AreasPath()
        {
            return functions.getInstance().getAreasPath();
        }

        protected string UsersPath()
        {
            return functions.getInstance().getUsersPath();
        }

        protected string HomePath()
        {
            return functions.getInstance().getHomePath();
        }

        protected string IndexPath()
        {
            return functions.getInstance().getIndexPage();
        }

        protected string AddPath()
        {
            return functions.getInstance().getAddPage();
        }

        protected string DeletePath()
        {
            return functions.getInstance().getDeletePage();
        }

        protected string ListPath()
        {
            return functions.getInstance().getListPage();
        }

        protected string UpdatePath()
        {
            return functions.getInstance().getUpdatePage();
        }

        protected string detailPath()
        {
            return functions.getInstance().getDetailPage();
        }

    }
}