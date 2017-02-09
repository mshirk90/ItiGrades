using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LooksGood.Acct
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Instructor"] = null;
            Session.Abandon(); // same as previous, but eliminates everything else in the Session as well
            Response.Cookies["ITICookies"]["RememberMe"] = "false";
        }
    }
}