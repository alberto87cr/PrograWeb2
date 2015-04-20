<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/Home.master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CarParkingCoRi.Views.Home.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderPage" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPage" runat="server">
    <!-- start: Content -->
    <div id="content" class="span10">
        <ul class="breadcrumb">
            <li>
                <i class="icon-home"></i>
                <a href="index.html">Home</a>
                <i class="icon-angle-right"></i>
            </li>
            <li><a href="#">Index</a></li>
        </ul>
        <div class="row-fluid">
            <a class="quick-button metro yellow span2">
                <i class="icon-dashboard"></i>
                <p>Vehiculos</p>
                <span class="badge">10</span>
            </a>
            <a class="quick-button metro blue span2">
                <i class="icon-user"></i>
                <p>Clientes</p>
                <span class="badge">25</span>
            </a>
            <a class="quick-button metro red span2">
                <i class="icon-group"></i>
                <p>Usuarios</p>
                <span class="badge">3</span>
            </a>
            <a class="quick-button metro pink span2">
                <i class="icon-wrench"></i>
                <p>Ajustes</p>
                <span class="badge">88</span>
            </a>

            <div class="clearfix"></div>

        </div>
        <!--/row-->

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterTopPage" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterBottomPage" runat="server">
</asp:Content>
