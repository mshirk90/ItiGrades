<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ItiGrades.Account.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="space">
        <br />
    </div>

    <div class="imagefix" style=" padding-left: 80px">
        <div class="form-group">
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtOldPassword" TextMode="Password" CssClass="form-control" PlaceHolder="Old Password" Width="50%" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtOldPassword" CssClass="text-danger" ErrorMessage="The password field is required." ValidationGroup="vgChangePassword">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNewPassword" TextMode="Password" CssClass="form-control" PlaceHolder="New Password" Width="50%" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNewPassword" CssClass="text-danger" ErrorMessage="The password field is required." ValidationGroup="vgChangePassword">*</asp:RequiredFieldValidator>
            </div>

        </div>
        <div class="form-group">
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="form-control" PlaceHolder="Confirm Password" Width="50%" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmPassword" CssClass="text-danger" ErrorMessage="The password field is required." ValidationGroup="vgChangePassword">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-10">
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                <asp:ValidationSummary ID="vsChangePassword" runat="server" ValidationGroup="vgChangePassword" />
                <asp:Button runat="server" ID="btnChangePassword" Text="Change Password" CssClass="btn btn-default" OnClick="btnChangePassword_Click" />
                <asp:Label ID="pwRequirements" runat="server" Text=""></asp:Label>
            </div>
        </div>
       


</asp:Content>
