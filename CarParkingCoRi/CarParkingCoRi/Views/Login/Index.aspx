<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CarParkingCoRi.Views.Login.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <% loadRootPath(); %>
    <style type="text/css">
		body { background: url(<% Response.Write(rootPath());%>Content/img/bg-login.jpg) !important; }
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">

    <asp:LoginView ID="LoginView1" runat="server" EnableTheming="False">
        <AnonymousTemplate>
            <asp:Login ID="Login1" runat="server" CssClass="container-fluid-full" EnableTheming="False" Height="100%" Width="100%">
                <LayoutTemplate>
                    <div class="row-fluid">
                        <div class="row-fluid">
                            <div class="login-box">
                                <h2>Ingrese en su cuenta</h2>
                                <fieldset>
                                    <div class="input-prepend" title="Username">
                                        <span class="add-on"><i class="halflings-icon user"></i></span>
                                        <asp:TextBox ID="UserName" runat="server" CssClass="input-large span10" placeholder="Nombre de usuario"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                                    </div>
                                </fieldset>
                                    <div class="clearfix"></div>
                                <fieldset>
                                    <div class="input-prepend" title="Password">
                                        <span class="add-on"><i class="halflings-icon lock"></i></span>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="input-large span10" placeholder="Contraseña"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                                    </div>
                                </fieldset>
                                    <div class="clearfix"></div>
                                    <label class="remember" for="remember">
                                        <asp:CheckBox ID="RememberMe" runat="server" />
                                        Recordarme
                                    </label>
                                    <div class="clearfix"></div>
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    <div class="clearfix"></div>
                                <fieldset>
                                    <div class="button-login">
                                        <asp:Button ID="LoginButton" CssClass="btn btn-primary" runat="server" CommandName="Login" Text="Inicio de sesión" ValidationGroup="ctl00$Login1" />
                                    </div>
                                </fieldset>
                                    <div class="clearfix"></div>
                                <br />
                            </div>
                        </div>
                    </div>
                </LayoutTemplate>
            </asp:Login>
        </AnonymousTemplate>
    </asp:LoginView>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
