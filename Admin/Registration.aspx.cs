using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

namespace Orient
{
    public partial class Registration : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                FillGrid();
                FillResource();
                lblUserType.Text = HttpContext.Current.User.Identity.Name;
            }
        }

        public void FillGrid()
        {
            try
            {

                string sql = string.Format("Select_UserLogin");
                ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, sql);
                grdRegistrationDetail.DataSource = ds;
                grdRegistrationDetail.DataBind();
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;

            }
        }

        public void FillResource()
        {
            try
            {
                string sql = string.Format("Select * From Resource");
                ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql);
                ddlResource.DataSource = ds;
                ddlResource.DataTextField = "ResourceName";
                ddlResource.DataValueField = "ID";

                ddlResource.DataBind();
                ddlResource.Items.Insert(0, "--Select Resource--");
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;

            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnsubmit.Text=="Submit")
                {
                    SqlParameter[] prms = new SqlParameter[6];
                    prms[0] = new SqlParameter("@UserName", txtUserName.Text);
                    prms[1] = new SqlParameter("@Password", txtPassword.Text);
                    prms[2] = new SqlParameter("@EmailId", txtEmail.Text);
                    prms[3] = new SqlParameter("@ResourceId", ddlResource.SelectedValue);
                    prms[4] = new SqlParameter("@ExpiryDate", txtExpiryDate.Text);
                    prms[5] = new SqlParameter("@UserType", ddlUserType.SelectedValue);

                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Insert_Users", prms);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Record has been Saved successfully.');", true);
                    FillResource();
                    FillGrid();
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    txtEmail.Text = "";
                    ddlUserType.SelectedIndex = -1;
                    txtExpiryDate.Text = ""; 
                }

                else if (btnsubmit.Text=="Update")
                {
                    SqlParameter[] prms = new SqlParameter[6];
                    prms[0] = new SqlParameter("@Id", hfValue.Value);
                    prms[1] = new SqlParameter("@UserName", txtUserName.Text);
                    prms[2] = new SqlParameter("@EmailId", txtEmail.Text);
                    prms[3] = new SqlParameter("@ResourceId", ddlResource.SelectedValue);
                    prms[4] = new SqlParameter("@ExpiryDate", txtExpiryDate.Text);
                    prms[5] = new SqlParameter("@UserType", ddlUserType.SelectedValue);

                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Update_Users", prms);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Record has been Updated successfully.');", true);
                    FillResource();
                    FillGrid();
                    pass.Visible = true;
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    txtEmail.Text = "";
                    ddlUserType.SelectedIndex = -1;
                    txtExpiryDate.Text = "";
                    btnsubmit.Text = "Submit";
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            FillResource();
            pass.Visible = true;
            txtExpiryDate.Text = ""; 
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            ddlUserType.SelectedIndex = -1;
        }

        protected void grdRegistrationDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdRegistrationDetail.PageIndex = e.NewPageIndex;
                FillGrid();
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;

            }
        }

        protected void grdRegistrationDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                hfValue.Value = ((int)grdRegistrationDetail.DataKeys[e.RowIndex].Value).ToString();
                SqlParameter[] prms = new SqlParameter[1];
                prms[0] = new SqlParameter("@Id", hfValue.Value);

                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Delete_Users", prms);
                FillGrid();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Record has been Deleted successfully.');", true);
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;

            }
        }

        protected void imgbtnViewDetail_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnButton = sender as Button;
                GridViewRow gvRow = (GridViewRow)btnButton.NamingContainer;

                Label lblUserName = (Label)gvRow.FindControl("lblUserName");
                txtUserName.Text = lblUserName.Text.ToString();

                Label lblEmailId = (Label)gvRow.FindControl("lblEmailId");
                txtEmail.Text = lblEmailId.Text.ToString();

                Label lblExpiryDate = (Label)gvRow.FindControl("lblExpiryDate");
                txtExpiryDate.Text = lblExpiryDate.Text.ToString();

                Label lblResourceName = (Label)gvRow.FindControl("lblResourceName");
                ddlResource.SelectedIndex = ddlResource.Items.IndexOf(ddlResource.Items.FindByText(lblResourceName.Text.ToString()));

                Label lblUserType = (Label)gvRow.FindControl("lblUserType");
                ddlUserType.SelectedValue = lblUserType.Text.ToString();

                hfValue.Value = ((int)grdRegistrationDetail.DataKeys[gvRow.RowIndex].Value).ToString();

                pass.Visible = false;

                btnsubmit.Text = "Update";
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;
            }
        }
    }
}