<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ItiGrades.Account.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="space">
        <br />
    </div>

    <div class="imagefix" style=" padding-left: 80px">
        <div class="form-group">
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtOldPassword" TextMode="Password" CssClass="form-control" PlaceHolder="Old Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtOldPassword" CssClass="text-danger" ErrorMessage="The password field is required." ValidationGroup="vgChangePassword">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNewPassword" TextMode="Password" CssClass="form-control" PlaceHolder="New Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNewPassword" CssClass="text-danger" ErrorMessage="The password field is required." ValidationGroup="vgChangePassword">*</asp:RequiredFieldValidator>
            </div>

        </div>
        <div class="form-group">
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="form-control" PlaceHolder="Confirm Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmPassword" CssClass="text-danger" ErrorMessage="The password field is required." ValidationGroup="vgChangePassword">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-10">
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                <asp:ValidationSummary ID="vsChangePassword" runat="server" ValidationGroup="vgChangePassword" />
                <asp:Button runat="server" ID="btnChangePassword" Text="Change Password" CssClass="btn btn-default" OnClick="btnChangePassword_Click" />
                <asp:Label ID="pwRequirements" runat="server" Text="Password must contain at least on uppercaser, special, and numerical character."></asp:Label>
            </div>
        </div>
         <a href="#contact" class="btn btn-circle page-scroll">
                <i class="fa fa-angle-double-down animated"></i>
            </a>
    </div>

    
    <div class="space">
        <br />
        <br />
        <br />
        <br />
        <br />
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
