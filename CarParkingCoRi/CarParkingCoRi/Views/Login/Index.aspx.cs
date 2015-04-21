using CarParkingCoRi.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarParkingCoRi.Views.Login
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                functions fs = functions.getInstance();
                loadRootPath();
                string dashFile = fs.getHomePath() + fs.getIndexPage();
                Response.Redirect(dashFile, false);
            }
            else
            {
                Session.Clear();
            }
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
    }
}