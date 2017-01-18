<%@ Page Title="Forgot password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="ItiGrades.Account.ForgotPassword" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="space">
        <br />
    </div>
    <div class="space">
        <br />
    </div>
    <div class="space">
        <br />
    </div>



    <div class="row">
        <div class="col-md-8">
            <asp:PlaceHolder ID="loginForm" runat="server">
                <div class="form-horizontal">
                    <h4>Forgot your password?</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger" style="padding-left: 25px">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <asp:TextBox runat="server" ID="rvEmail" CssClass="form-control" Width="700px" Text="Password Revealed HERE" />
                    <div class="form-group pull-left" style="padding-left: 25px">
                        <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label" ID="lblEmail">Email</asp:Label>
                        <div class="col-md-10" style="padding-left: 10px">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" Width="700px" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                                CssClass="text-danger" ErrorMessage="The email field is required." ID="EmailVal" />
                        </div>
                    </div>
                    <div class="form-group pull-left">
                        <div class="col-md-10 pull-left">
                            <asp:Button runat="server" OnClick="Reveal" Text="Reveal Password" CssClass="btn btn-default pull-left div-margin" ID="revealEmail" />
                            <asp:Button runat="server" OnClick="Forgot" Text="Reset Password" CssClass="btn btn-default" ID="forgotEmail" />
                        </div>
                    </div>
                </div>
                <md-button class="btnRegister" ng-click="Forgot();"> Reset </md-button>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="DisplayEmail" Visible="false">
                <p class="text-info">
                    Please check your email to reset your password.
               
                </p>
            </asp:PlaceHolder>
        </div>
    </div>
    <div>
        <a href="#contact" class="btn btn-circle page-scroll">
            <i class="fa fa-angle-double-down animated"></i>
        </a>
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

    <section id="contact" class="download-section text-center">
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2">
                <a href="#page-top" class="btn btn-circle page-scroll">
                    <i class="fa fa-angle-double-up animated"></i>
                </a>
            </div>
        </div>
        <br />
     


    <style>
        .btnRegister{
            padding-left: 300px;
        }

    </style>
    <script>
        $(document).ready(function () {
            $('html, body').animate({
                scrollTop: $('.space').offset().top
            }, 'slow');
        });


        $('#<%=txtEmail.ClientID %>').keyup(function () {
            var value = $('#<%=txtEmail.ClientID %>').val();
            EmailChecker(value);
        });
        $('#<%=txtEmail.ClientID %>').change(function () {
            var value = $('#<%=txtEmail.ClientID %>').val();
            EmailChecker(value);
        });

        function EmailChecker(value) {
            $.ajax({
                type: 'POST',
                url: '../LooksGoodWS.asmx/DoesEmailExist',
                data: "{'email': '" + value + "'}",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: OnSuccess,
                error: function (response) {
                    alert(response.responseText);
                }
            });
        }
        function OnSuccess(response) {
            var txtEmail = document.getElementById('<%=txtEmail.ClientID %>');
            var lblStatus = document.getElementById('<%=lblEmail.ClientID %>');
            var btnRegister = document.getElementById('<%=forgotEmail.ClientID%>');
            switch (response.d) {
                case true:
                    txtEmail.style.color = "green";
                    lblStatus.innerText = "Email Address Found";
                    btnRegister.disabled = false;
                    break;

                case false:
                    txtEmail.style.color = "red";
                    lblStatus.innerText = "Valid e-mail not found";
                    btnRegister.disabled = true;
                    break;

            }
        }

</script>

</asp:Content>
