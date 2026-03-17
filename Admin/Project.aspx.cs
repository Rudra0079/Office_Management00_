using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Orient
{
    public partial class Project : System.Web.UI.Page
    {
        
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGrid();
            }
        }


        public void FillGrid()
        {
            try
            {
               
                string sql = string.Format("Select * From ProjectMaster");
                ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql);
                grdProjectDetail.DataSource = ds;
                grdProjectDetail.DataBind();
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
                if (btnsubmit.Text == "Submit")
                {
                    SqlParameter[] prms = new SqlParameter[2];
                    prms[0] = new SqlParameter("@ProjectName", txtProjectName.Text);
                    prms[1] = new SqlParameter("@ProjectDetails", txtProjectDetails.Text);
                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Insert_Project", prms);
                    FillGrid();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Record has been Saved successfully.');", true);
                    txtProjectDetails.Text = "";
                    txtProjectName.Text = "";
                }

                else if (btnsubmit.Text == "Update")
                {
                    SqlParameter[] prms = new SqlParameter[3];
                    prms[0] = new SqlParameter("@ID", hfValue.Value);
                    prms[1] = new SqlParameter("@ProjectName", txtProjectName.Text);
                    prms[2] = new SqlParameter("@ProjectDetails", txtProjectDetails.Text);

                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Update_Project", prms);
                    FillGrid();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Record has been Updated successfully.');", true);
                    btnsubmit.Text = "Submit";
                    txtProjectName.Text = "";
                    txtProjectDetails.Text = "";
                }
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
                txtProjectName.Text = "";
                txtProjectDetails.Text = "";
                btnsubmit.Text = "Submit";
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;
            }
        }

        protected void grdProjectDetail_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            try
            {
                 grdProjectDetail.PageIndex = e.NewPageIndex;
                 FillGrid();
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;
            }
        }

        protected void grdProjectDetail_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                hfValue.Value = ((int)grdProjectDetail.DataKeys[e.RowIndex].Value).ToString();
                SqlParameter[] prms = new SqlParameter[1];
                prms[0] = new SqlParameter("@ID", hfValue.Value);

                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Delete_Project", prms);
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

                Label lblProjectName = (Label)gvRow.FindControl("lblProjectName");
                txtProjectName.Text = lblProjectName.Text.ToString();

                Label lblProjectDetail = (Label)gvRow.FindControl("lblProjectDetail");
                txtProjectDetails.Text = lblProjectDetail.Text.ToString();

                hfValue.Value = ((int)grdProjectDetail.DataKeys[gvRow.RowIndex].Value).ToString();

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