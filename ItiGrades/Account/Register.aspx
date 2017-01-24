<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ItiGrades.Account.Register" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="space">
        <div>
            <h2><asp:Label ID="lblRegister" runat="server" Text="Register New Account" Class="fa-file-text-o"></asp:Label></h2>
        </div>
    </div>
    <div class="text-center" style="padding-left: 380px;">
        <div>
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" Placeholder="Email" Width="70%" Style="color: black" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                CssClass="text-danger" ErrorMessage="The email field is required." ID="EmailVal" />
        </div>

        <div>
            <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" PlaceHolder="First Name" Width="70%" Style="color: black" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName"
                CssClass="text-danger" ErrorMessage="The first name field is required." ID="rvFirstName" ValidationGroup="vgRegister"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" PlaceHolder="Last Name" Width="70%" Style="color: black" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastName"
                CssClass="text-danger" ErrorMessage="The first name field is required." ID="RequiredFieldValidator1" ValidationGroup="vgRegister"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="lblStatus" runat="server" BorderStyle="None" ForeColor="White"></asp:Label>
        </div>
            <asp:Button ID="btnRegister" runat="server" Text="Register" Class="button align-right" OnClick="btnRegister_Click" Style="color: black;" />

    </div>




    <div>
        <a href="#contact" class="btn btn-circle page-scroll">
            <i class="fa fa-angle-double-down animated"></i>
        </a>
    </div>







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

        //function EmailChecker(value) {
        //    $.ajax({
        //        type: 'POST',
        //        url: '../LooksGoodWS.asmx/DoesEmailExist',
        //        data: "{'email': '" + value + "'}",
        //        contentType: 'application/json; charset=utf-8',
        //        dataType: 'json',
        //        success: OnSuccess,
        //        error: function (response) {
        //            alert(response.responseText);
        //        }
        //    });
        //}
        function OnSuccess(response) {
            var txtEmail = document.getElementById('<%=txtEmail.ClientID %>');
            var lblStatus = document.getElementById('<%=lblStatus.ClientID %>');
            var btnRegister = document.getElementById('<%=btnRegister.ClientID%>');
            switch (response.d) {
                case false:
                    txtEmail.style.color = "green";
                    lblStatus.innerText = "Email Availible";
                    btnRegister.disabled = false;
                    break;

                case true:
                    txtEmail.style.color = "red";
                    lblStatus.innerText = "Email already in use";
                    btnRegister.disabled = true;
                    break;

            }
        }

</script>

    <%--    <link href="../css/style.css" rel="stylesheet" /> --%>
</asp:Content>
