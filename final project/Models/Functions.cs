using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace final_project.Models
{
    public class Functions
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string Constr;
        public Functions() {
            Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\youse\Documents\BookShopDB.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(Constr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        public DataTable GetData(string Query) {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, Constr);
            sda.Fill(dt);
            return dt;
        }

        public int SetData(string Query) {
            int cnt = 0;
            if(Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            Cmd.CommandText = Query;
            cnt = Cmd.ExecuteNonQuery();
            Con.Close();
            return cnt;
        }
    }
}