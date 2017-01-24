using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace ItiGrades
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Instructor"] != null)
            {
                MasterPage masterpage = Page.Master;

                Instructor instructor = (Instructor)Session["Instructor"];

                lblLogIn.Visible = false;
                lblSignUp.Visible = false;
                lblHeader.InnerText = "Welcome to the portal " + instructor.FirstName;
            }
            else
            {
                sectionMain.Visible = false;
            }            
        }
    }
}