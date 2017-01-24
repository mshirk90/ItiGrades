using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using DatabaseHelper;

namespace ItiGrades.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Instructor"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Instructor instructor = (Instructor)Session["Instructor"];
            if (txtOldPassword.Text == instructor.Password)
            {
                if (txtNewPassword.Text == txtConfirmPassword.Text)
                {
                    instructor.Password = txtNewPassword.Text;
                    if (instructor.IsSavable() == true)
                    {
                        instructor.IsPasswordPending = false;
                        instructor.Save();                       
                        Response.Redirect("~/Default.aspx");
                    }
                    
                    else
                    {
                        //Show broken Rules
                        foreach (BrokenRule br in instructor.BrokenRules.List)
                        {
                            AddCustomError(br.Rule);
                        }
                    }
                }
            }
        }
        private void AddCustomError(string message)
        {
            CustomValidator cv = new CustomValidator();
            cv.ErrorMessage = message;
            cv.Enabled = true;
            cv.ValidationGroup = "vgChangePassword";
            cv.IsValid = false;
            Page.Validators.Add(cv);
        }
    }
}