using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace final_project.Views.Admin
{
    public partial class Categories : System.Web.UI.Page
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
                ShowCategories();

            }
                

        }

        private void ShowCategories()
        {
            string Query = "Select * from CategoryTable";
            CategoriesList.DataSource = Con.GetData(Query);
            CategoriesList.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "" || DiscriptionTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data !!";
                }
                else
                {
                    string CatName = CatNameTb.Value;
                    string Discription = DiscriptionTb.Value;

                    string Query = "insert into CategoryTable values('{0}','{1}')";
                    Query = string.Format(Query, CatName, Discription);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = "Category Inserted !!";

                    CatNameTb.Value = "";
                    DiscriptionTb.Value = "";
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
                if (CatNameTb.Value == "" || DiscriptionTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data !!";
                }
                else
                {
                    string CatName = CatNameTb.Value;
                    string Discription = DiscriptionTb.Value;

                    string Query = "update CategoryTable set CatName = '{0}', CatDescription = '{1}' where Catid = '{2}'";
                    Query = string.Format(Query, CatName, Discription , CategoriesList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = "Category Updated !!";

                    CatNameTb.Value = "";
                    DiscriptionTb.Value = "";
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
                if (CatNameTb.Value == "" || DiscriptionTb.Value == "")
                {
                    ErrMsg.Text = "Select A Category !!";
                }
                else
                {
                    string CatName = CatNameTb.Value;
                    string Discription = DiscriptionTb.Value;

                    string Query = "delete from CategoryTable where Catid = '{0}'";
                    Query = string.Format(Query, CategoriesList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.Text = "Category Deleted !!";

                    CatNameTb.Value = "";
                    DiscriptionTb.Value = "";
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        int key = 0;

        protected void CategoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatNameTb.Value = CategoriesList.SelectedRow.Cells[2].Text;
            DiscriptionTb.Value = CategoriesList.SelectedRow.Cells[3].Text;

            if (CatNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CategoriesList.SelectedRow.Cells[1].Text);
            }
        }
    }
}