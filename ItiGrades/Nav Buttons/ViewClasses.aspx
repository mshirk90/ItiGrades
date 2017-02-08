<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Site.Master" CodeBehind="ViewClasses.aspx.cs" Inherits="ItiGrades.Nav_Buttons.ViewClasses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <!-- Main -->
    <section id="main" class="wrapper style1">
        <header class="major">
            <h2>
                <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
            <p>View all classes here</p>
        </header>
        <div class="container">
            <div class="row">
                <div class="4u">
                    <section>
                        <h3>--Start Here</h3>
                        <%--<p>Feugiat amet accumsan ante aliquet feugiat accumsan. Ante blandit accumsan eu amet tortor non lorem felis semper. Interdum adipiscing orci feugiat penatibus adipiscing col cubilia lorem ipsum dolor sit amet feugiat consequat.</p>--%>
                        <ul class="actions">
                            <li>
                                <asp:Button ID="btnViewClasses" class="button alt" runat="server" Text="View Classes" OnClick="btnViewClasses_Click" /></li>
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
                        <div style="white-space: nowrap">
                           
                                <asp:DropDownList ID="ddlSections" runat="server" DataTextField="Name" DataValueField="Id" Style="width: auto; display:inline-block" OnSelectedIndexChanged="ddlSections_SelectedIndexChanged" Visible="false" AutoPostBack="true"></asp:DropDownList>
                               
                      
                                <asp:Label ID="lblOrderBy" runat="server" Visible="false" Text="Order by:" style="padding-left: 40px;"/>
                                <asp:DropDownList runat="server" Visible="false" AutoPostBack="true" ID="ddlSelection" Style="width: auto; display:inline-block" OnSelectedIndexChanged="ddlSelection_SelectedIndexChanged">
                                    <asp:ListItem Text="Student Name" Value="Student Name" />
                                    <asp:ListItem Text="Class Name" Value="Class Name" />
                                </asp:DropDownList>

                                <asp:DropDownList runat="server" Visible="false" AutoPostBack="true" ID="ddlDirection" Style="width: auto; display:inline-block" OnSelectedIndexChanged="ddlDirection_SelectedIndexChanged">
                                    <asp:ListItem Text="ASC" />
                                     <asp:ListItem Text="DESC" />
                                </asp:DropDownList>
                              
                           </div>
                       <hr />
                        <asp:GridView ID="gvViewClass" runat="server" Visible="false"></asp:GridView>

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
