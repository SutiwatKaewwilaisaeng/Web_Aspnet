using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Web_Aspnet
{
    public partial class WebForm1 : System.Web.UI.Page
    {
       
       string ConnectionString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;

          
        //string connectionString = @"Data Source = DESKTOP-4E3SROQ;Intial Catalog=UserRegistrationDB; Integrated Security=True;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int userID = Convert.ToInt32(Request.QueryString["id"]);
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                    {
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("UserViewByID", sqlCon);
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("@UserID", userID);
                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);

                        hfUserID.Value = userID.ToString();
                        txtFirstname.Text = dtbl.Rows[0][1].ToString();
                        txtLastname.Text = dtbl.Rows[0][2].ToString();
                        txtContract.Text = dtbl.Rows[0][3].ToString();
                        dd1Gender.Items.FindByValue(dtbl.Rows[0][4].ToString()).Selected = true;
                        txtAddress.Text = dtbl.Rows[0][5].ToString();
                        txtUsername.Text = dtbl.Rows[0][6].ToString();
                        txtPassword.Text = dtbl.Rows[0][7].ToString();
                        txtPassword.Attributes.Add("value", dtbl.Rows[0][7].ToString());
                        txtconfilmpass.Text = dtbl.Rows[0][7].ToString();
                        txtconfilmpass.Attributes.Add("value", dtbl.Rows[0][7].ToString());
                    }
                }
            }
                    
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                lblErrorMessage.Text = "Please Fill Mandatory Fields";
            }
            else if (txtPassword.Text != txtconfilmpass.Text)
            {

                lblErrorMessage.Text = "Password do not match";
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    sqlCon.Open();

                    SqlCommand sqlcmd = new SqlCommand("UserAddOrEdit", sqlCon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value));
                    sqlcmd.Parameters.AddWithValue("@FirstName", txtFirstname.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@LastName", txtLastname.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Contact", txtContract.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Gender", dd1Gender.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    sqlcmd.ExecuteNonQuery();
                    Clear();
                    lblSuccessMessage.Text = "Submitted Successfully";
                    lblErrorMessage.Text = "";
                }
            }
        }

        void Clear()
        {
            txtFirstname.Text = txtLastname.Text = txtContract.Text = txtAddress.Text = txtUsername.Text = txtPassword.Text = txtconfilmpass.Text = "";
              hfUserID.Value = "";
              lblSuccessMessage.Text = lblErrorMessage.Text = "";
             

        }
                
    }
}