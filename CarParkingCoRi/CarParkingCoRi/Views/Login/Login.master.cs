using CarParkingCoRi.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarParkingCoRi.Views.Login
{
    public partial class Login : System.Web.UI.MasterPage
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

    }
}