using System;
using System.Web;
using System.Web.UI;
using BusinessObjects;
using ConfigurationHelper;
using System.Data.SqlClient;
using System.Data;
using EmailHelper;
using DatabaseHelper;



namespace ItiGrades.Account
{
    public partial class Forgot : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Attributes.Add("autocomplete", "off");
            if (Session["Instructor"] != null)
            {
                EmailVal.Enabled = false;
                lblEmail.Visible = false;
                txtEmail.Enabled = false;
                txtEmail.Visible = false;
                forgotEmail.Enabled = false;
                forgotEmail.Visible = false;
                Instructor instructor = (Instructor)Session["Instructor"];
            }
            else
            {
                rvEmail.Enabled = false;
                rvEmail.Visible = false;
                revealEmail.Enabled = false;
                revealEmail.Visible = false;
            }
        }

        protected void Reveal(object sender, EventArgs e)
        {
            Instructor instructor = (Instructor)Session["Instructor"];
            rvEmail.Text = string.Format("We saved your password: {0}", instructor.Password);
        }


        protected void ForgotPassword(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //^^ Validate the user's email addres
                Instructor instructor = new Instructor();
                instructor = instructor.Exists(txtEmail.Text);
                if (instructor != null)
                {
                    Email.SendEmail(instructor.Email, "Your Looks Good website password", "Your password = " + instructor.Password);
                    //^^ reads the data base rows equivalent to user e-mail and password from the user table and e-mails to the e-mail
                    Response.Redirect("~/Account/PassWordConfirmation.aspx");
                }
                else
                {
                    txtEmail.Text = "User Email not found";
                    FailureText.Text = "Please submit a registered Email";
                }

            }
        }

    }
}
    



