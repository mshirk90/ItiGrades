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
                                <asp:Button ID="btnAddClass" class="button alt" runat="server" Text="Add Class" OnClick="btnAddClass_Click" /></li>
                            <li>
                                <asp:Button ID="btnAddDepartment" class="button alt" runat="server" Text="Add Department" OnClick="btnAddDepartment_Click" /></li>
                            <li>
                                <asp:Button ID="btnAddStudent" class="button alt" runat="server" Text="Add Student" OnClick="btnAddStudent_Click" /></li>

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
                                <asp:Label ID="lblOne" runat="server"></asp:Label>
                                <asp:TextBox ID="txtOne" runat="server"></asp:TextBox>
                                <asp:DropDownList ID="ddlDepartment" runat="server"></asp:DropDownList>
                                <asp:Button ID="btnOne" class="button alt" runat="server" Text="" OnClick="btnOne_Click"/>
                            </div>
                            <div>
                                <asp:Label ID="lblTwo" runat="server"></asp:Label>
                                <asp:TextBox ID="txtTwo" runat="server"></asp:TextBox>
                                <asp:Button ID="btnTwo" class="button alt" runat="server" Text="" OnClick="btnTwo_Click"/>
                            </div>
                            <div>
                                <asp:Label ID="lblThree" runat="server"></asp:Label>
                                <asp:TextBox ID="txtThree" runat="server"></asp:TextBox>
                                <asp:Button ID="btnThree" class="button alt" runat="server" Text="" OnClick="btnThree_Click"/>
                            </div>
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
