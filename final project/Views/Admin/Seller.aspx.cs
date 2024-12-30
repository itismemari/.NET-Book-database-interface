using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace final_project.Views.Admin
{
    public partial class Seller : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToBoolean(Session["Logged in"]) == false)
            {
                Response.Redirect("../Login.aspx"); // Redirect to the login page
            }
            else
            {
                Name.Text = Session["UserName"].ToString();
                Con = new Models.Functions();
                ShowSeller();

            }      

        }

        private void ShowSeller()
        {
            string Query = "Select * from SellerTable";
            SellersList.DataSource = Con.GetData(Query);
            SellersList.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameTb.Value == "" || EmailTb.Value == "" || PhoneTb.Value == "" || PasswordTb.Value== "")
                {
                    ErrMsg.Text = "Missing Data !!";
                }
                else
                {
                    string Name = NameTb.Value;
                    string Email = EmailTb.Value;
                    string Phone = PhoneTb.Value;
                    string Password = PasswordTb.Value;

                    string Query = "insert into SellerTable values('{0}','{1}','{2}','{3}')";
                    Query = string.Format(Query, Name, Email, Phone, Password);
                    Con.SetData(Query);
                    ShowSeller();
                    ErrMsg.Text = "Seller Added !!";

                    NameTb.Value = "";
                    EmailTb.Value = "";
                    PhoneTb.Value = "";
                    PasswordTb.Value = "";
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }

        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameTb.Value == "" || EmailTb.Value == "" || PhoneTb.Value == "" || PasswordTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data !!";
                }
                else
                {
                    string Name = NameTb.Value;
                    string Email = EmailTb.Value;
                    string Phone = PhoneTb.Value;
                    string Password = PasswordTb.Value;

                    string Query = "update SellerTable set SellerName = '{0}',SellerEmail = '{1}',SellerPhone = '{2}',SellerPassword = '{3}' where Sellerid = '{4}'";
                    Query = string.Format(Query, Name, Email, Phone, Password, SellersList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowSeller();
                    ErrMsg.Text = "Seller's Info Updated !!";

                    NameTb.Value = "";
                    EmailTb.Value = "";
                    PhoneTb.Value = "";
                    PasswordTb.Value = "";
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }

        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameTb.Value == "" || EmailTb.Value == "" || PhoneTb.Value == "" || PasswordTb.Value == "")
                {
                    ErrMsg.Text = "Select An Item !!";
                }
                else
                {
                    string Name = NameTb.Value;
                    string Email = EmailTb.Value;
                    string Phone = PhoneTb.Value;
                    string Password = PasswordTb.Value;

                    string Query = "delete from SellerTable where Sellerid = '{0}'";
                    Query = string.Format(Query, SellersList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowSeller();
                    ErrMsg.Text = "Seller's Info Deleted !!";

                    NameTb.Value = "";
                    EmailTb.Value = "";
                    PhoneTb.Value = "";
                    PasswordTb.Value = "";
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        int key = 0;

        protected void SellersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            NameTb.Value = SellersList.SelectedRow.Cells[2].Text;
            EmailTb.Value = SellersList.SelectedRow.Cells[3].Text;
            PhoneTb.Value = SellersList.SelectedRow.Cells[4].Text;
            PasswordTb.Value = SellersList.SelectedRow.Cells[5].Text;

            if(NameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(SellersList.SelectedRow.Cells[1].Text);
            }


        }
    }
}