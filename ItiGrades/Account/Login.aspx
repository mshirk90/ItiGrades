<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LooksGood.Account.Login" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <div class="space" id="space">
        <br />
    </div>
    <div class="space">
        <br />
    </div>
    <div class="space">
        <br />
    </div>
     <div class="contain">
        <div>
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" PlaceHolder="Email" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                CssClass="text-danger" ErrorMessage="The email field is required." />
        </div>
        <div>
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" PlaceHolder="Password" />
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
            <i class="fa fa-angle-double-down animated"></i>
        </a>
        <div class="space">
            <br />
        </div>
        <div class="space">
            <br />
        </div>
        <div class="space">
            <br />
        </div>
        <div class="space">
            <br />
        </div>
        <div class="space">
            <br />
        </div>
        <div class="space">
            <br />
        </div>
        <div class="space">
            <br />
        </div>
        <div class="space">
            <br />
        </div>
    </div>





    <section id="contact" class="download-section text-center">
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2">
                <a href="#page-top" class="btn btn-circle page-scroll">
                    <i class="fa fa-angle-double-up animated"></i>
                </a>
            </div>
        </div>
        <br />
        <%--</section>--%>
        <div class="text-center">
            <div>
                <div>
                    <h2>Contact Us</h2>
                    <p>
                        <a href="mailto:feedback@startbootstrap.com">feedback@startbootstrap.com</a>
                    </p>
                    <ul class="list-inline banner-social-buttons">
                        <li>
                            <a href="https://twitter.com/SBootstrap" class="btn btn-default btn-lg"><i class="fa fa-twitter fa-fw"></i><span class="network-name">Twitter</span></a>
                        </li>
                        <li>
                            <a href="https://github.com/IronSummitMedia/startbootstrap" class="btn btn-default btn-lg"><i class="fa fa-github fa-fw"></i><span class="network-name">Github</span></a>
                        </li>
                        <li>
                            <a href="https://plus.google.com/+Startbootstrap/posts" class="btn btn-default btn-lg"><i class="fa fa-google-plus fa-fw"></i><span class="network-name">Google+</span></a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </section>
    <script>
        $(document).ready(function () {
            $('html, body').animate({
                scrollTop: $('.space').offset().top
            }, 'slow');
        });
    </script>
</asp:Content>


