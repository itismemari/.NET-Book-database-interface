using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace final_project.Views.Admin
{
    public partial class Auther : System.Web.UI.Page
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
                ShowAuthors();

            }
                
        }

        private void ShowAuthors()
        {
            string Query = "Select * from AuthorTable";
            AuthorsList.DataSource = Con.GetData(Query);
            AuthorsList.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(ANameTb.Value == "" || GenCb.SelectedIndex == -1 || CountryCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Missing Data !!";
                }
                else
                {
                    string AName = ANameTb.Value;
                    string Gen = GenCb.SelectedItem.ToString();
                    string Country = CountryCb.SelectedItem.ToString();

                    string Query = "insert into AuthorTable values('{0}','{1}','{2}')";
                    Query = string.Format(Query, AName, Gen, Country);
                    Con.SetData(Query);
                    ShowAuthors();
                    ErrMsg.Text = "Author Inserted !!";

                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryCb.SelectedIndex = -1;
                }

            }
            catch(Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }

        }

        int key = 0;

        protected void AuthorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ANameTb.Value = AuthorsList.SelectedRow.Cells[2].Text;
            GenCb.SelectedItem.Value = AuthorsList.SelectedRow.Cells[3].Text;
            CountryCb.SelectedItem.Value = AuthorsList.SelectedRow.Cells[4].Text;

            if(ANameTb.Value =="")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(AuthorsList.SelectedRow.Cells[1].Text);
            }
            

        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ANameTb.Value == "" || GenCb.SelectedIndex == -1 || CountryCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Missing Data !!";
                }
                else
                {
                    string AName = ANameTb.Value;
                    string Gen = GenCb.SelectedItem.ToString();
                    string Country = CountryCb.SelectedItem.ToString();

                    string Query = "update AuthorTable set AuthName = '{0}' , AuthGender = '{1}' , AuthCountry = '{2}' Where Authid = '{3}'";
                    Query = string.Format(Query, AName, Gen, Country, AuthorsList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowAuthors();
                    ErrMsg.Text = "Author Updated !!";

                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryCb.SelectedIndex = -1;
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
                if (ANameTb.Value == "" || GenCb.SelectedIndex == -1 || CountryCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Select An Author !! ";
                }
                else
                {
                    string AName = ANameTb.Value;
                    string Gen = GenCb.SelectedItem.ToString();
                    string Country = CountryCb.SelectedItem.ToString();

                    string Query = "delete from AuthorTable where Authid = '{0}'";
                    Query = string.Format(Query, AuthorsList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowAuthors();
                    ErrMsg.Text = "Author Deleted !!";

                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryCb.SelectedIndex = -1;
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
    }
} 