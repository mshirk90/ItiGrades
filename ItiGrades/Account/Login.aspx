<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ItiGrades.Account.Login" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="space">
        <div>
            <h2>
                <asp:Label ID="lblLogin" runat="server" Text="Log In" Class="fa-file-text-o"></asp:Label></h2>
        </div>
    </div>
    <div class="text-center" style="padding-left: 380px;">
        <div>
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" PlaceHolder="Email" Width="70%" Style="color: black" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                CssClass="text-danger" ErrorMessage="The email field is required." />
        </div>
        <div>
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" PlaceHolder="Password" Width="70%" Style="color: black" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="text-danger" ErrorMessage="The password field is required." />
        </div>
        <div>
            <asp:Button runat="server" ID="btnLogin" Text="Log in" CssClass="btn btn-default" OnClick="btnLogin_Click" />
            <asp:HyperLink NavigateUrl="~/Account/Register.aspx" runat="server" ID="RegisterHyperLink" Visible="true" ViewStateMode="Disabled">Register</asp:HyperLink>
        </div>
        <div>
            <div class="checkbox">
                <asp:CheckBox runat="server" ID="RememberMe" />
                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
            </div>
        </div>
        <div>
            <%--Enable this once you have account confirmation enabled for password reset functionality--%>
            <asp:HyperLink NavigateUrl="~/Account/Forgot.aspx" runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
        </div>
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <a href="#contact" class="btn btn-circle page-scroll">
            <i class="fa fa-angle-double-down animated"></i></a>
        <br />
    </div>
</asp:Content>


