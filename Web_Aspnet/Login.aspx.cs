using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Aspnet
{
    public partial class Login : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM UserRegistration WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlcmd = new SqlCommand(query,sqlCon);
                sqlcmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["username"] = txtUserName.Text.Trim();
                    Response.Redirect("Dashboard.aspx");
                }
                else { lblErrorMessage.Visible = true; }
            }
            }
    }
}