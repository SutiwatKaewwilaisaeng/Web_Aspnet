using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace Web_Aspnet
{
    public partial class Dashboard : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
        SqlConnection sqlcon;

        protected void Page_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection();
          
            sqlcon.ConnectionString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;

            if (Session["username"] == null)
                Response.Redirect("Login.aspx");
            lblUserDetails.Text = "Username :" + Session["username"];
            if (!IsPostBack)
            {


                btnDelete.Enabled = false;
                GridFill();
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }


        void GridFill()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ContactViewAll", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlcon.Close();
            gvContact.DataSource = dtbl;
            gvContact.DataBind();
        }
        protected void lnkSelect_Onclick(object sender, EventArgs e)
        {


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("ContactDeleteByID", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@Contractid", Convert.ToInt32(hfContactID.Value));

            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            Clear();
            GridFill();
            lblSuccessMessage.Text = "Deleted Successfully";
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            hfContactID.Value = "";
            txtName.Text = txtMobile.Text = txtAddress.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            lblErrorMessage.Text = lblSuccessMessage.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            if(sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("ContactCreateOrUpdate", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@Contractid", Convert.ToInt32(hfContactID.Value == "" ? "0" : hfContactID.Value));

            sqlcmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            string Contractid = hfContactID.Value;
            Clear();
            if (hfContactID.Value == "")
                lblSuccessMessage.Text = "Saved Successfully";
            else
                lblSuccessMessage.Text = "Updated Successfully";
                GridFill();

        }

        protected void lnk_Onclick (object sender, EventArgs e)
        {
            int Contractid = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ContactViewByID", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Contractid", Contractid);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlcon.Close();
            hfContactID.Value = Contractid.ToString();
            txtName.Text = dtbl.Rows[0]["Name"].ToString();
            txtMobile.Text = dtbl.Rows[0]["Mobile"].ToString();
            txtAddress.Text = dtbl.Rows[0]["Address"].ToString();
            btnSave.Text = "Update";
            btnDelete.Enabled = true;



        }
    }

    
}
