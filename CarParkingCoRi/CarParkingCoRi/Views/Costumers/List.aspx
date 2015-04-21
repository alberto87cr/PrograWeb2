<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Costumers/Costumers.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="CarParkingCoRi.Views.Costumers.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderInterns" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainInterns" runat="server">
    <div id="content" class="span10">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home"></i>
                <a href="index.html">Home</a>
                <i class="icon-angle-right"></i>
            </li>
            <li><a href="#">Tables</a></li>
        </ul>

        <div class="row-fluid sortable">
            <div class="box span12">
                <div class="box-header" >
                    <h2><i class="halflings-icon user"></i><span class="break"></span>Listado de Clientes</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-minimize"><i class="halflings-icon chevron-up"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <table class="table table-striped table-bordered bootstrap-datatable datatable">
                        <thead>
                            <tr>
                                <th>Nombre</th>
                                <th>Identificacion</th>
                                <th>Tipo de Servicio</th>
                                <th>Proximo Pago</th>
                                <th>Estado</th>
                                <th>Eventos</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Label ID="listadoClientes" runat="server" Text="Label"></asp:Label>
                            <tr>
                                <td>Alberto Castro</td>
                                <td class="center">206340088</td>
                                <td class="center">Mensual</td>
                                <td class="center">01-05-2015</td>
                                <td class="center">
                                    <span class="label label-success">Activo</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="halflings-icon white zoom-in"></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="halflings-icon white edit"></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="halflings-icon white trash"></i>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Alberto Castro</td>
                                <td class="center">206340088</td>
                                <td class="center">Mensual Diurno</td>
                                <td class="center">01-05-2015</td>
                                <td class="center">
                                    <span class="label label-success">Activo</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="halflings-icon white zoom-in"></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="halflings-icon white edit"></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="halflings-icon white trash"></i>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>Alberto Castro</td>
                                <td class="center">206340088</td>
                                <td class="center">Mensual Nocturno</td>
                                <td class="center">01-05-2015</td>
                                <td class="center">
                                    <span class="label label-success">Activo</span>
                                </td>
                                <td class="center">
                                    <a class="btn btn-success" href="#">
                                        <i class="halflings-icon white zoom-in"></i>
                                    </a>
                                    <a class="btn btn-info" href="#">
                                        <i class="halflings-icon white edit"></i>
                                    </a>
                                    <a class="btn btn-danger" href="#">
                                        <i class="halflings-icon white trash"></i>
                                    </a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <!--/span-->

        </div>
    </div>
    <!--/row-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterInternTops" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterInternBottoms" runat="server">
</asp:Content>
