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
    public partial class ForgotPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Attributes.Add("autocomplete", "off");
            if (Session["User"] != null)
            {
                EmailVal.Enabled = false;
                lblEmail.Visible = false;
                txtEmail.Enabled = false;
                txtEmail.Visible = false;
                forgotEmail.Enabled = false;
                forgotEmail.Visible = false;
                Student student = (Student)Session["User"];
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
            Student user = (Student)Session["User"];
            rvEmail.Text = string.Format("We saved your password: {0}", user.Password);
        }


        protected void Forgot(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //^^ Validate the user's email addres
                Student student = new Student();
                student = student.Exists(txtEmail.Text);
                if (student != null)
                {
                    Email.SendEmail(student.Email, "Your Looks Good website password", "Your password = " + student.Password);
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
    



