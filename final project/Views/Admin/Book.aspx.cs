using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace final_project.Views.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
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
                Con = new Models.Functions();
                Name.Text = Session["UserName"].ToString();
                if (!IsPostBack)
                {
                ShowBook();
                GetCategories();
                GetBookAuthor();

                }

            }
            

        }

        private void ShowBook()
        {
            string Query = "Select * from BookTable";
            BooksList.DataSource = Con.GetData(Query);
            BooksList.DataBind();
        }

        private void GetCategories()
        {
            string Query = "select * from CategoryTable";
            BcatTb.DataTextField = Con.GetData(Query).Columns["CatName"].ToString();
            BcatTb.DataValueField = Con.GetData(Query).Columns["Catid"].ToString();
            BcatTb.DataSource = Con.GetData(Query);
            BcatTb.DataBind();
        }

        private void GetBookAuthor()
        {
            string Query = "select * from AuthorTable";
            BATb.DataTextField = Con.GetData(Query).Columns["AuthName"].ToString();
            BATb.DataValueField = Con.GetData(Query).Columns["Authid"].ToString();
            BATb.DataSource = Con.GetData(Query);
            BATb.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BookTitleTb.Value == "" || BATb.SelectedIndex == -1 || BcatTb.SelectedIndex == -1 || priceTb.Value == "" || QuantityTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data !!";
                }
                else
                {
                    string BookTitle = BookTitleTb.Value;
                    string BA = BATb.SelectedValue.ToString();
                    string Bcat = BcatTb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(QuantityTb.Value);
                    int price = Convert.ToInt32(priceTb.Value);
                    

                    string Query = "insert into BookTable values('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query, BookTitle, BA, Bcat, Quantity, price);
                    Con.SetData(Query);
                    ShowBook();
                    ErrMsg.Text = "Book Inserted !!";

                    BookTitleTb.Value = "";
                    BATb.SelectedIndex = -1;
                    BcatTb.SelectedIndex = -1;
                    QuantityTb.Value = "";
                    priceTb.Value = "";
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
                if (BookTitleTb.Value == "" || BATb.SelectedIndex == -1 || BcatTb.SelectedIndex == -1 || priceTb.Value == "" || QuantityTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data !!";
                }
                else
                {
                    string BookTitle = BookTitleTb.Value;
                    string BA = BATb.SelectedValue.ToString();
                    string Bcat = BcatTb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(QuantityTb.Value);
                    int price = Convert.ToInt32(priceTb.Value);


                    string Query = "update BookTable set BName = '{0}', BAuthor = '{1}', BCategory = '{2}', BQty = '{3}', BPrice = '{4}' where Bid = '{5}'";
                    Query = string.Format(Query, BookTitle, BA, Bcat, Quantity, price , BooksList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowBook();
                    ErrMsg.Text = "Book's Info Updated !!";

                    BookTitleTb.Value = "";
                    BATb.SelectedIndex = -1;
                    BcatTb.SelectedIndex = -1;
                    QuantityTb.Value = "";
                    priceTb.Value = "";
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
                if (BookTitleTb.Value == "" || BATb.SelectedIndex == -1 || BcatTb.SelectedIndex == -1 || priceTb.Value == "" || QuantityTb.Value == "")
                {
                    ErrMsg.Text = "Select A Book !!";
                }
                else
                {
                    string BookTitle = BookTitleTb.Value;
                    string BA = BATb.SelectedValue.ToString();
                    string Bcat = BcatTb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(QuantityTb.Value);
                    int price = Convert.ToInt32(priceTb.Value);


                    string Query = "delete from BookTable where Bid = '{0}'";
                    Query = string.Format(Query, BooksList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowBook();
                    ErrMsg.Text = "Book Deleted !!";

                    BookTitleTb.Value = "";
                    BATb.SelectedIndex = -1;
                    BcatTb.SelectedIndex = -1;
                    QuantityTb.Value = "";
                    priceTb.Value = "";
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }

        }

        int key = 0;

        protected void BooksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BookTitleTb.Value = BooksList.SelectedRow.Cells[2].Text;
            BATb.SelectedValue = BooksList.SelectedRow.Cells[3].Text;
            BcatTb.SelectedValue = BooksList.SelectedRow.Cells[4].Text;
            QuantityTb.Value = BooksList.SelectedRow.Cells[5].Text;
            priceTb.Value = BooksList.SelectedRow.Cells[6].Text;

            if(BookTitleTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(BooksList.SelectedRow.Cells[1].Text);
            }

        }
    }
}