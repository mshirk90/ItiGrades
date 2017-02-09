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
            Instructor instructor = null;
            if (IsValid)
            {
                if (Session["Instructor"] == null)
                {
                    instructor = new Instructor();
                }
                else
                {
                    instructor = (Instructor)Session["Instructor"];
                }

                try
                {
                    if (instructor.EmailSent == false)
                    {
                        instructor.Register(txtFirstName.Text, txtLastName.Text, txtEmail.Text);                    
                    }
                }
                catch (Exception ex)
                {
                    // show the broken rules
                    for (Int32 i = 0; i < instructor.BrokenRules.Count; i++)
                    {
                        CustomValidator cvRules = new CustomValidator();
                        cvRules.ErrorMessage = instructor.BrokenRules.List[i].Rule;
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
                        if (instructor.EmailSent == false)
                        {

                            Email.SendEmail(instructor.Email, "Registration Password", "Your password is: " + instructor.Password);
                            lblStatus.Text = "Please check your email for creditials.";
                            instructor.EmailSent = true;
                            instructor.Save();
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