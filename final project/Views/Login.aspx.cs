using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace final_project.Views
{
    public partial class Login : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            Session["Logged in"] = false;

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameTb.Value) || string.IsNullOrEmpty(PasswordTb.Value))
            {
                ErrMsg.Text = "Please enter both username and password.";
                return;
            }
            else
            {
                try
                {


                    string Query = "select * from SellerTable where SellerEmail = '{0}' and SellerPassword = '{1}'";
                    Query = string.Format(Query, UsernameTb.Value, PasswordTb.Value);
                    DataTable dt = Con.GetData(Query);
                    if (dt.Rows.Count == 0)
                    {
                        ErrMsg.Text = "Invalid Data !!";
                    }
                    else
                    {
                        Session["Logged in"] = true;
                        Session["UserName"] = dt.Rows[0][1].ToString(); // Store the username
                        Response.Redirect("Admin/Book.aspx");

                    }
                }
                catch (Exception ex)
                {
                    ErrMsg.Text = "An error occurred: " + ex.Message;
                }
            }
            

        }
    }
}