using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using BusinessObjects;

namespace ItiGrades
{
    public partial class SiteMaster : MasterPage
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Instructor"] != null)
            {
                MasterPage masterpage = Page.Master;

                Instructor instructor = (Instructor)Session["Instructor"];
                Menu menu = (Menu)this.FindControl("Menu1");
                lblSignUp.Visible = false;
                lblInstructor.InnerText = (String.Format("[Welcome {0}]", instructor.FirstName));
            }
                else
                {
                    
                }
            }
        

    private void RemoveMenuItem(String text)
        {
            Menu mnu = (Menu)this.FindControl("Menu1");
            MenuItem itemRemove = new MenuItem();
            foreach (MenuItem menuItem in mnu.Items)
            {
                if (menuItem.Value == text)
                {
                    itemRemove = menuItem;
                }
            }
            mnu.Items.Remove(itemRemove);
        }

        private void ChangeMenuItem(String value, String text)
        {
            Menu mnu = (Menu)this.FindControl("Menu1");
            foreach (MenuItem menuItem in mnu.Items)
            {
                if (menuItem.Value == value)
                {
                    menuItem.Text = text;
                }
            }
        }


    }

}