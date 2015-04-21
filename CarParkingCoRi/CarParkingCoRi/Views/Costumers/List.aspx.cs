using CarParkingCoRi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarParkingCoRi.Views.Costumers
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            listadoClientes.Text = "";
            String listadoFinal = "";
            List<Cliente> listado = null;
            foreach (Cliente client in listado)
            {
                String tipoServicio = "Mensual";
                String fechaPago = "01-mayo-2015";
                listadoFinal +=
                    "<tr>" +
                        "<td>" + client.nombre + " " + client.apellido1 + " " + client.apellido2 + "</td>" +
                        "<td class='center'>" + client.cedula + "</td>" +
                        "<td class='center'>" + tipoServicio + "</td>" +
                        "<td class='center'>" + fechaPago + "</td>" +
                        "<td class='center'>";
                if (true)
                    listadoFinal +=
                            "<span class='label label-success'>Activo</span>";
                else
                    listadoFinal +=
                            "<span class='label label-important'>Inactivo</span>";
                listadoFinal +=
                        "</td>" +
                        "<td class='center'>" +
                            "<a class='btn btn-success' href='#'>" +
                                "<i class='halflings-icon white zoom-in'></i>" +
                            "</a>" +
                            "<a class='btn btn-info' href='#'>" +
                                "<i class='halflings-icon white edit'></i>" +
                            "</a>" +
                            "<a class='btn btn-danger' href='#'>" +
                                "<i class='halflings-icon white trash'></i>" +
                            "</a>" +
                        "</td>" +
                    "</tr>";
            }
            listadoClientes.Text = listadoFinal;
        }
    }
}