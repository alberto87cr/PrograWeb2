using CarParkingCoRi.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarParkingCoRi.Views
{
    public partial class Intern : System.Web.UI.MasterPage
    {

        protected int porcentGeneral = 0;
        protected int porcentReservate = 0;
        protected int porcentPublic = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                functions fs = functions.getInstance();
                loadRootPath();
                string dashFile = fs.getLoginPath() + fs.getIndexPage();
                Response.Redirect(dashFile, false);
            }
            else
            {
                if ( Session["isAuth"] == null || !(Boolean)Session["isAuth"] )
                {
                    Session["userName"] = HttpContext.Current.User.Identity.Name;
                    Session["isAuth"] = HttpContext.Current.User.Identity.IsAuthenticated;
                }
                setValues();
            }
        }

        protected void setValues()
        {
            porcentPublic = 20;
            porcentReservate = 15;
            porcentGeneral = porcentPublic + porcentReservate;

        }

        protected string userName()
        {
            if (Session["userName"] == null)
                Session["userName"] = "";
            return Session["userName"].ToString();
        }

        protected int getPorGenUse()
        {
            return porcentGeneral;
        }

        protected int getPorResUse()
        {
            return porcentReservate;
        }

        protected int getPubUse()
        {
            return porcentPublic;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] roles = Roles.GetRolesForUser();
            
        }

    }
}