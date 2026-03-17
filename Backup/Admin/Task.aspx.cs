using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orient
{
    public partial class Task : System.Web.UI.Page
    {
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDown();
                FillGrid();
            }
            
        }

        public void FillDropDown()
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

        public void FillGrid()
        {
            try
            {

                string sql = string.Format("Select_Task");
                ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, sql);
                grdTaskDetail.DataSource = ds;
                grdTaskDetail.DataBind();
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
                    SqlParameter[] prms = new SqlParameter[5];
                    prms[0] = new SqlParameter("@ProjectID", ddlProjectName.SelectedValue);
                    prms[1] = new SqlParameter("@TaskName", txtTaskName.Text);
                    prms[2] = new SqlParameter("@TaskDetails", txtTaskDetails.Text);
                    prms[3] = new SqlParameter("@TaskStart", txtStartDate.Text);
                    prms[4] = new SqlParameter("@TaskEnd", txtEndDate.Text);
                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Insert_Task", prms);
                    FillDropDown();
                    FillGrid();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Record has been Saved successfully.');", true);
                    ddlProjectName.SelectedIndex = -1;
                    txtTaskName.Text = "";
                    txtTaskDetails.Text = "";
                    txtStartDate.Text = "";
                    txtEndDate.Text = ""; 
                }

                else if (btnsubmit.Text == "Update")
                {
                    SqlParameter[] prms = new SqlParameter[6];
                    prms[0] = new SqlParameter("@ID", hfValue.Value);
                    prms[1] = new SqlParameter("@ProjectID", ddlProjectName.SelectedValue);
                    prms[2] = new SqlParameter("@TaskName", txtTaskName.Text);
                    prms[3] = new SqlParameter("@TaskDetails", txtTaskDetails.Text);
                    prms[4] = new SqlParameter("@TaskStart", txtStartDate.Text);
                    prms[5] = new SqlParameter("@TaskEnd", txtEndDate.Text);

                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Update_Task", prms);
                    FillGrid();
                    FillDropDown();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Record has been Updated successfully.');", true);
                    btnsubmit.Text = "Submit";
                    txtStartDate.Text = "";
                    txtEndDate.Text = "";
                    txtTaskDetails.Text = "";
                    txtTaskName.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;
            }
        }

        protected void grdTaskDetail_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                hfValue.Value = ((int)grdTaskDetail.DataKeys[e.RowIndex].Value).ToString();
                SqlParameter[] prms = new SqlParameter[1];
                prms[0] = new SqlParameter("@ID", hfValue.Value);
               

                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Delete_Task", prms);
                FillGrid();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Record has been Deleted successfully.');", true);
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;
            }
        }

        protected void grdTaskDetail_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            try
            {
                grdTaskDetail.PageIndex = e.NewPageIndex;
                 FillGrid();
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

                Label lblProject = (Label)gvRow.FindControl("lblProject");
                ddlProjectName.SelectedIndex = ddlProjectName.Items.IndexOf(ddlProjectName.Items.FindByText(lblProject.Text));

                Label lblTaskName = (Label)gvRow.FindControl("lblTaskName");
                txtTaskName.Text = lblTaskName.Text.ToString();

                Label lblTaskDetails = (Label)gvRow.FindControl("lblTaskDetails");
                txtTaskDetails.Text = lblTaskDetails.Text.ToString();

                Label lblTaskStart = (Label)gvRow.FindControl("lblTaskStart");
                txtStartDate.Text = lblTaskStart.Text.ToString();

                Label lblTaskEnd = (Label)gvRow.FindControl("lblTaskEnd");
                txtEndDate.Text = lblTaskEnd.Text.ToString();

                hfValue.Value = ((int)grdTaskDetail.DataKeys[gvRow.RowIndex].Value).ToString();

                btnsubmit.Text = "Update";
               


            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                txtStartDate.Text = "";
                    txtEndDate.Text = "";
                    txtTaskDetails.Text = "";
                    txtTaskName.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;
            }
        }
    }
}