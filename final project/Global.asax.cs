using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace final_project
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            
           
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["Logged in"] = false;
            Session["UserName"] = "";
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }
    }
}