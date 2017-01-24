using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BusinessObjects;

namespace ItiGrades.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //MasterPage masterpage = Page.Master;
            //Label label = (Label)masterpage.FindControl("lblForgotPassword");
            //label.Visible = true;


            // READ THE COOKIE
            if (Request.Cookies["ITICookies"] != null /*&& Convert.ToBoolean(Request.Cookies["ITICookies"]["RememberMe"]) == true*/)
            {
                txtEmail.Text = Request.Cookies["ITICookies"]["UserName"];
                txtPassword.Text = Request.Cookies["ITICookies"]["Password"];
                UserLogin();
            }
        }

        private void UserLogin()
        {
            Instructor instructor = new Instructor();
            instructor = instructor.Login(txtEmail.Text, txtPassword.Text);


            if (instructor == null)
            {
                lblStatus.Text = "Invalid Username or Password";
            }
            else if (instructor.Version == 0 && instructor.IsPasswordPending == true)
            {
                Session.Add("Instructor", instructor);
                Response.Redirect("ChangePassword.aspx");
            }
            else
            {
                if (this.RememberMe.Checked == true)
                {
                    Response.Cookies["ITICookies"]["UserName"] = txtEmail.Text;
                    Response.Cookies["ITICookies"]["Password"] = txtPassword.Text;
                    Response.Cookies["ITICookies"]["RememberMe"] = "true";
                    Response.Cookies["ITICookies"]["LastVisited"] = DateTime.Now.ToLongDateString();
                    Response.Cookies["ITICookies"].Expires = DateTime.MaxValue;
                }
                Session.Add("Instructor", instructor);
                //if (Request.QueryString["returnURL"] != null && Request.QueryString["returnURL"].Contains("ExpandedPost"))
                //{
                //    string URL = Request.QueryString["returnURL"] + "&userId=" + user.Id;
                //    Response.Redirect(URL);
                //}
                if (Request.QueryString["returnURL"] != null && Request.QueryString["returnURL"].Contains("Profile"))
                {
                    string URL = Request.QueryString["returnURL"];
                    Response.Redirect(URL);
                }
                if (Request.QueryString["returnURL"] != null && Request.QueryString["returnURL"].Contains("Default"))
                {
                    string URL = Request.QueryString["returnURL"];
                    Response.Redirect(URL);
                }
                else
                {
                    Response.Redirect("../Default.aspx?userId=" + instructor.Id);
                }
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserLogin();
        }
    }
}