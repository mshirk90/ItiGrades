<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditAttendance.aspx.cs" Inherits="ItiGrades.Nav_Buttons.EditAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <!-- Main -->
    <section id="main" class="wrapper style1">
        <header class="major">
            <h2>
                <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
            <p>View/edit attendance here.</p>
        </header>
        <div class="container">
            <div class="row">
                <div class="4u">
                    <section>
                        <h3>--Start Here</h3>
                        <%--<p>Feugiat amet accumsan ante aliquet feugiat accumsan. Ante blandit accumsan eu amet tortor non lorem felis semper. Interdum adipiscing orci feugiat penatibus adipiscing col cubilia lorem ipsum dolor sit amet feugiat consequat.</p>--%>
                        <ul class="actions">
                            <li>
                                <asp:Button ID="btnSelectClass" class="button alt" runat="server" Text="View/Edit Attendance" OnClick="btnSelectClass_Click" /></li>
                        </ul>
                    </section>
                    <hr />
                    <section>
                        <h3></h3>
                        <ul class="alt">
                        </ul>
                    </section>
                </div>
                <div class="8u skel-cell-important">
                    <section>
                        <div>
                            <div>
                                <asp:DropDownList ID="ddlSections" Visible="false" runat="server" DataTextField="Name" DataValueField="Id" Style="width: auto;" OnSelectedIndexChanged="ddlSections_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                                <asp:DropDownList ID="ddlDepartment" Visible="false" runat="server" DataTextField="Name" DataValueField="Id" Style="width: auto;" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                                <asp:DropDownList ID="ddlSelectClass" Visible="false" runat="server" DataTextField="Name" DataValueField="Id" Style="width: auto;"></asp:DropDownList>

                                <asp:Button ID="btnEditAttendance" Visible="false" class="button alt" runat="server" Text="Edit Attendance" OnClick="btnEditAttendance_Click" />
                                <div style="white-space:nowrap; margin-bottom: 10px;">
                                <asp:DropDownList ID="ddlSelectStudent" Visible="false" runat="server" DataTextField="FullName" DataValueField="Id" Style="width: auto; display:inline-block;"></asp:DropDownList>
                                 <asp:Button ID="btnMarkAbsent" Visible="false" class="button alt" runat="server" Text="Mark Absent" style="display:inline-block;" OnClick="btnMarkAbsent_Click" />
                            </div>
                            </div>



                            <div>
                                <asp:Label ID="lblStatus1" runat="server"></asp:Label><asp:Label ID="lblStatus2" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div>
                        </div>
                        <asp:GridView ID="GridView1" runat="server">                                         
                        </asp:GridView>
                    </section>
                </div>
            </div>
            <hr class="major" />
            <%--<div class="row">
						<div class="6u">
							<section class="special">
								<a href="#" class="image fit"><img src="../images/pic01.jpg" alt="" /></a>
								<h3>Mollis adipiscing nisl</h3>
								<p>Eget mi ac magna cep lobortis faucibus accumsan enim lacinia adipiscing metus urna adipiscing cep commodo id. Ac quis arcu amet. Arcu nascetur lorem adipiscing non faucibus odio nullam arcu lobortis. Aliquet ante feugiat. Turpis aliquet ac posuere volutpat lorem arcu aliquam lorem.</p>
								<ul class="actions">
									<li><a href="#" class="button alt">Learn More</a></li>
								</ul>
							</section>
						</div>
						<div class="6u">
							<section class="special">
								<a href="#" class="image fit"><img src="../images/pic02.jpg" alt="" /></a>
								<h3>Neque ornare adipiscing</h3>
								<p>Eget mi ac magna cep lobortis faucibus accumsan enim lacinia adipiscing metus urna adipiscing cep commodo id. Ac quis arcu amet. Arcu nascetur lorem adipiscing non faucibus odio nullam arcu lobortis. Aliquet ante feugiat. Turpis aliquet ac posuere volutpat lorem arcu aliquam lorem.</p>
								<ul class="actions">
									<li><a href="#" class="button alt">Learn More</a></li>
								</ul>
							</section>
						</div>
					</div>--%>
        </div>
    </section>


</asp:Content>
