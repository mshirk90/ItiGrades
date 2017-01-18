using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using EmailHelper;
using System.Web.Services;
	

namespace ItiGrades.Account
{
    public partial class Register : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Attributes.Add("autocomplete", "off");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Student student = null;
            if (IsValid)
            {
                if (Session["Student"] == null)
                {
                    student = new Student();
                }
                else
                {
                    student = (Student)Session["Student"];
                }

                try
                {
                    if (student.EmailSent == false)
                    {
                        student.Register(txtFirstName.Text, txtLastName.Text, txtEmail.Text);
                        Session.Add("Student", student);
                    }
                }
                catch (Exception ex)
                {
                    // show the broken rules
                    for (Int32 i = 0; i < student.BrokenRules.Count; i++)
                    {
                        CustomValidator cvRules = new CustomValidator();
                        cvRules.ErrorMessage = student.BrokenRules.List[i].Rule;
                        cvRules.Enabled = true;
                        cvRules.IsValid = false;
                        cvRules.ValidationGroup = "vgRegister";
                        Page.Validators.Add(cvRules);
                        // customer.BrokenRules.List
                    }
                }
                try
                {
                    if (Page.IsValid == true)
                    {
                        if (student.EmailSent == false)
                        {

                            EmailHelper.Email.SendEmail(student.Email, "Registration Password", "Your password is: " + student.Password);
                            lblStatus.Text = "Please check your email for creditials.";
                            student.EmailSent = true;
                            student.Save();
                        }
                        else
                        {
                            lblStatus.Text = "Email already sent.";
                        }
                    }
                }
                catch (Exception exEmail)
                {
                    lblStatus.Text = exEmail.Message;
                }
            }

            else
            {
                txtEmail.Text = "User Email not found";
            }
        }
    }
}
//