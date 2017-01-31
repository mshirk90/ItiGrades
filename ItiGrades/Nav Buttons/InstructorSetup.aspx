<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Site.Master" CodeBehind="InstructorSetup.aspx.cs" Inherits="ItiGrades.Nav_Buttons.InstructorSetup" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <!-- Main -->
    <section id="main" class="wrapper style1">
        <header class="major">
            <h2>Left Sidebar</h2>
            <p>Tempus adipiscing commodo ut aliquam blandit</p>
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
                        <h3>Ante sed commodo</h3>
                        <ul class="alt">
                            <li><a href="#">Erat blandit risus vis adipiscing</a></li>
                            <li><a href="#">Tempus ultricies faucibus amet</a></li>
                            <li><a href="#">Arcu commodo non adipiscing quis</a></li>
                            <li><a href="#">Accumsan vis lacinia semper</a></li>
                            <li><a href="#">Erat blandit risus vis adipiscing</a></li>
                            <li><a href="#">Tempus ultricies faucibus amet</a></li>
                            <li><a href="#">Arcu commodo non adipiscing quis</a></li>
                            <li><a href="#">Accumsan vis lacinia semper</a></li>
                        </ul>
                    </section>
                </div>
                <div class="8u skel-cell-important">
                    <section>
                        <div>
                            <div>
                                <asp:DropDownList ID="ddlSections" runat="server" DataTextField="Name" DataValueField="Id" ></asp:DropDownList>
                                <asp:DropDownList ID="ddlDepartment" runat="server" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <asp:DropDownList ID="ddlSelectClass" runat="server" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                                <asp:Button ID="btnAddStudents" class="button alt" runat="server" Text="Add Students" OnClick="btnAddStudents_Click" />

                            </div>
                            <div>
                                <div>
                                    <asp:Label ID="lblFirstName1" runat="server" Text="First Name"></asp:Label>
                                    <asp:TextBox ID="txtFirstName1" runat="server"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:Label ID="lblLastName1" runat="server" Text="Last Name"></asp:Label>
                                    <asp:TextBox ID="txtLastName1" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div>
                                <asp:Label ID="lblFirstName2" runat="server" Text="First Name"></asp:Label>
                                <asp:TextBox ID="txtFirstName2" runat="server"></asp:TextBox>
                                <asp:Label ID="lblLastName2" runat="server" Text="Last Name"></asp:Label>
                                <asp:TextBox ID="txtLastName2" runat="server"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lblFirstName3" runat="server" Text="First Name"></asp:Label>
                                <asp:TextBox ID="txtFirstName3" runat="server"></asp:TextBox>
                                <asp:Label ID="lblLastName3" runat="server" Text="Last Name"></asp:Label>
                                <asp:TextBox ID="txtLastName3" runat="server"></asp:TextBox>
                            </div>
                            <asp:Button ID="btnSaveClass" class="button alt" runat="server" Text="Save Class" OnClick="btnSaveClass_Click" />

                        </div>
                        <div>
                        </div>

                        <asp:GridView ID="dgGridView" runat="server"></asp:GridView>

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
