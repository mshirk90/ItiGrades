<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Site.Master" CodeBehind="InstructorSetup.aspx.cs" Inherits="ItiGrades.Nav_Buttons.InstructorSetup" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <!-- Main -->
    <section id="main" class="wrapper style1">
        <header class="major">
            <h2>
                <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
            <p>Beginning of term class setup</p>
        </header>
        <div class="container">
            <div class="row">
                <div class="4u">
                    <section>
                        <h3>--Start Here</h3>
                        <%--<p>Feugiat amet accumsan ante aliquet feugiat accumsan. Ante blandit accumsan eu amet tortor non lorem felis semper. Interdum adipiscing orci feugiat penatibus adipiscing col cubilia lorem ipsum dolor sit amet feugiat consequat.</p>--%>
                        <ul class="actions">
                            <li>
                                <asp:Button ID="btnSetupClass" class="button alt" runat="server" Text="Setup Class" OnClick="btnSetupClass_Click" /></li>
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

                                <asp:Button ID="btnAddStudents" Visible="false" class="button alt" runat="server" Text="Add Students" OnClick="btnAddStudents_Click" />
                            </div>


                            <asp:Table runat="server" ID="tblInsert" Visible="false">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtFirstName" runat="server" Placeholder="First Name" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtLastName" runat="server" Placeholder="Last Name" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                        <asp:Button ID="btnSaveClass" Visible="false" class="button alt" runat="server" Text="Save Class" Style="padding-left: 20px;" OnClick="btnSaveClass_Click" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <br />
                            <div>
                                <asp:Label ID="lblStatus1" runat="server"></asp:Label>
                                <asp:Label ID="lblStatus2" runat="server"></asp:Label>
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
