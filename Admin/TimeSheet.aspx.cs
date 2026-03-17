using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orient
{
    public partial class TimeSheet : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGrid();
                FillProjectMaster();
                FillResource();
            }
        }

        public void FillGrid()
        {
            try
            {

                string sql = string.Format("Select_TimeSheet");
                ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, sql);
                grdTimesheetDetail.DataSource = ds;
                grdTimesheetDetail.DataBind();
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;

            }
        }

        public void FillProjectMaster()
        {
            try
            {

                string sql = string.Format("Select * From ProjectMaster");
                ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql);
                ddlProjectName.DataSource = ds;
                ddlProjectName.DataTextField = "ProjectName";
                ddlProjectName.DataValueField = "ID";

                ddlProjectName.DataBind();
                ddlProjectName.Items.Insert(0, "--Select Project Name--");
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
                    SqlParameter[] prms = new SqlParameter[4];
                    prms[0] = new SqlParameter("@ProjectMasterID", ddlProjectName.SelectedValue);
                    prms[1] = new SqlParameter("@ResourceID", ddlResource.SelectedValue);
                    prms[2] = new SqlParameter("@TimeIn", txtStartDate.Text);
                    prms[3] = new SqlParameter("@TimeOut", txtEndDate.Text);

                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Insert_TimeSheet", prms);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Record has been Saved successfully.');", true);
                    FillGrid();
                    FillProjectMaster();
                    FillResource();
                    ddlProjectName.SelectedIndex = -1;
                    ddlResource.SelectedIndex = -1;
                    txtStartDate.Text = "";
                    txtEndDate.Text = ""; 
                }

                else if (btnsubmit.Text == "Update")
                {
                    SqlParameter[] prms = new SqlParameter[5];
                    prms[0] = new SqlParameter("@ID", hfValue.Value);
                    prms[1] = new SqlParameter("@ProjectMasterID", ddlProjectName.SelectedValue);
                    prms[2] = new SqlParameter("@ResourceID", ddlResource.SelectedValue);
                    prms[3] = new SqlParameter("@TimeIn", txtStartDate.Text);
                    prms[4] = new SqlParameter("@TimeOut", txtEndDate.Text);

                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Update_TimeSheet", prms);
                    FillGrid();
                    FillProjectMaster();
                    FillResource();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Record has been Updated successfully.');", true);
                    btnsubmit.Text = "Submit";
                    txtStartDate.Text = "";
                    txtEndDate.Text = ""; 
                }
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

                Label lblTimeIn = (Label)gvRow.FindControl("lblTimeIn");
                txtStartDate.Text = lblTimeIn.Text.ToString();

                Label lblTimeOut = (Label)gvRow.FindControl("lblTimeOut");
                txtEndDate.Text = lblTimeOut.Text.ToString();

                Label lblProject = (Label)gvRow.FindControl("lblProject");
                ddlProjectName.SelectedIndex  = ddlProjectName.Items.IndexOf(ddlProjectName.Items.FindByText(lblProject.Text));

                Label lblResource = (Label)gvRow.FindControl("lblResource");
                ddlResource.SelectedIndex = ddlResource.Items.IndexOf(ddlResource.Items.FindByText(lblResource.Text));

                hfValue.Value = ((int)grdTimesheetDetail.DataKeys[gvRow.RowIndex].Value).ToString();

                btnsubmit.Text = "Update";
               
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;
            }
        }

        

        protected void grdTimesheetDetail_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            try
            {
                 grdTimesheetDetail.PageIndex = e.NewPageIndex;
                 FillGrid();
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;
            }
        }

        protected void grdTimesheetDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                hfValue.Value = ((int)grdTimesheetDetail.DataKeys[e.RowIndex].Value).ToString();
                SqlParameter[] prms = new SqlParameter[1];
                prms[0] = new SqlParameter("@ID", hfValue.Value);


                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Delete_Timesheet", prms);
                FillGrid();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Record has been Deleted successfully.');", true);
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;
            }

            finally
            {
                hfValue.Value = null;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                txtStartDate.Text = "";
                txtEndDate.Text = ""; 
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;
            }
        }

    }
}