<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ItiGrades._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       <!-- Banner -->
    <section id="banner">
        <div class="inner">
            <h2>ITI Technical College</h2>
            <p>Grade Portal <a href="http://templated.co"></a></p>
            <ul class="actions">
                <li>
                   <asp:Label ID="lblSignUp" runat="server"><a href="Account/Register.aspx" class="button big special">Sign Up</a></asp:Label>
                </li>
                <li>
                    <asp:Label ID="lblLogIn" runat="server"><a href="Account/Login.aspx" class="button big alt">Log In></a></asp:Label>
                </li>
            </ul>
        </div>
    </section>

     <!-- One -->
<div id="sectionMain" runat="server">   
     
    <section id="one" class="wrapper style1">        
        <header class="major">
            <h2 id="lblHeader" runat="server">Ipsum feugiat consequat</h2>
            <p>Navigate using the buttons below</p>
        </header>

        <div class="container" style="width:98% !important;">
            <div class="row">
                 <div class="4u" style="width: 24.5% !important;">
                    <section class="special box" style="height: 375px !important;">
                        <a href="Nav%20Buttons/EditAttendance.aspx"><i class="icon fa-bell major"></i></a>
                        <h3>Edit Attendance</h3>
                        <p>Enter/Edit attendance here.</p>
                    </section>
                </div>
                <div class="4u" style="width: 24.5% !important;">
                    <section class="special box" style="height: 375px !important;">
                        <a href="Nav%20Buttons/EditGrades.aspx"><i class="icon fa-area-chart major"></i></a>
                        <h3>Edit Grades</h3>
                        <p>Enter/edit student grades here.</p>
                    </section>
                </div>
                <div class="4u" style="width: 24.5% !important;">
                    <section class="special box" style="height: 375px !important;">
                       <a href="Nav%20Buttons/ViewClasses.aspx"><i class="icon fa-briefcase major"></i></a>
                        <h3>View all classes</h3>
                        <p>View classes, students and grades.</p>
                    </section>
                </div>
                <div class="4u" style="width: 24.5% !important;">
                    <section class="special box" style="height: 375px !important;">
                        <a href="Nav%20Buttons/InstructorSetup.aspx"><i class="icon fa-cog major"></i></a>
                        <h3>Class Setup</h3>
                        <p>Add your classes students for this term.</p>
                    </section>
                </div>
            </div>
        </div>
    </section>
</div>

    <!-- Two -->
  <%--  <section id="two" class="wrapper style2">
        <header class="major">
            <h2>Commodo accumsan aliquam</h2>
            <p>Amet nisi nunc lorem accumsan</p>
        </header>
        <div class="container">
            <div class="row">
                <div class="6u">
                    <section class="special">
                        <a href="#" class="image fit">
                            <img src="images/pic01.jpg" alt="" /></a>
                        <h3>Mollis adipiscing nisl</h3>
                        <p>Eget mi ac magna cep lobortis faucibus accumsan enim lacinia adipiscing metus urna adipiscing cep commodo id. Ac quis arcu amet. Arcu nascetur lorem adipiscing non faucibus odio nullam arcu lobortis. Aliquet ante feugiat. Turpis aliquet ac posuere volutpat lorem arcu aliquam lorem.</p>
                        <ul class="actions">
                            <li><a href="#" class="button alt">Learn More</a></li>
                        </ul>
                    </section>
                </div>
                <div class="6u">
                    <section class="special">
                        <a href="#" class="image fit">
                            <img src="images/pic02.jpg" alt="" /></a>
                        <h3>Neque ornare adipiscing</h3>
                        <p>Eget mi ac magna cep lobortis faucibus accumsan enim lacinia adipiscing metus urna adipiscing cep commodo id. Ac quis arcu amet. Arcu nascetur lorem adipiscing non faucibus odio nullam arcu lobortis. Aliquet ante feugiat. Turpis aliquet ac posuere volutpat lorem arcu aliquam lorem.</p>
                        <ul class="actions">
                            <li><a href="#" class="button alt">Learn More</a></li>
                        </ul>
                    </section>
                </div>
            </div>
        </div>
    </section>

    <!-- Three -->
    <section id="three" class="wrapper style1">
        <div class="container">
            <div class="row">
                <div class="8u">
                    <section>
                        <h2>Mollis ut adipiscing</h2>
                        <a href="#" class="image fit">
                            <img src="images/pic03.jpg" alt="" /></a>
                        <p>Vis accumsan feugiat adipiscing nisl amet adipiscing accumsan blandit accumsan sapien blandit ac amet faucibus aliquet placerat commodo. Interdum ante aliquet commodo accumsan vis phasellus adipiscing. Ornare a in lacinia. Vestibulum accumsan ac metus massa tempor. Accumsan in lacinia ornare massa amet. Ac interdum ac non praesent. Cubilia lacinia interdum massa faucibus blandit nullam. Accumsan phasellus nunc integer. Accumsan euismod nunc adipiscing lacinia erat ut sit. Arcu amet. Id massa aliquet arcu accumsan lorem amet accumsan commodo odio cubilia ac eu interdum placerat placerat arcu commodo lobortis adipiscing semper ornare pellentesque.</p>
                    </section>
                </div>
                <div class="4u">
                    <section>
                        <h3>Magna massa blandit</h3>
                        <p>Feugiat amet accumsan ante aliquet feugiat accumsan. Ante blandit accumsan eu amet tortor non lorem felis semper. Interdum adipiscing orci feugiat penatibus adipiscing col cubilia lorem ipsum dolor sit amet feugiat consequat.</p>
                        <ul class="actions">
                            <li><a href="#" class="button alt">Learn More</a></li>
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
                        </ul>
                    </section>
                </div>
            </div>
        </div>
    </section>--%>
    

</asp:Content>
