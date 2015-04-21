using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarParkingCoRi.DAL;

namespace CarParkingCoRi.Views.Costumers
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteDAL.modificarCliente (1,"33333","oko","dd","dd","333","dd",1);
           
        }
    }
}