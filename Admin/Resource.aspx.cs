using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Orient
{
    public partial class Resource : System.Web.UI.Page
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

                string sql = string.Format("Select * from Resource");
                ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.Text, sql);
                grdResourceDetail.DataSource = ds;
                grdResourceDetail.DataBind();
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
                    SqlParameter[] prms = new SqlParameter[1];
                    prms[0] = new SqlParameter("@ResourceName", txtResourceName.Text);

                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Insert_Resource", prms);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Record has been Saved successfully.');", true);
                    FillGrid();
                    txtResourceName.Text = "";

                }

                else if (btnsubmit.Text == "Update")
                {
                    SqlParameter[] prms = new SqlParameter[2];
                    prms[0] = new SqlParameter("@ID", hfValue.Value);
                    prms[1] = new SqlParameter("@ResourceName", txtResourceName.Text);


                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Update_Resource", prms);
                    FillGrid();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Record has been Updated successfully.');", true);
                    btnsubmit.Text = "Submit";
                    txtResourceName.Text = "";
                    
                }

                
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;

            }
        }

        protected void grdResourceDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdResourceDetail.PageIndex = e.NewPageIndex;
                FillGrid();
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;

            }
        }

        protected void grdResourceDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                hfValue.Value = ((int)grdResourceDetail.DataKeys[e.RowIndex].Value).ToString();
                SqlParameter[] prms = new SqlParameter[1];
                prms[0] = new SqlParameter("@ID", hfValue.Value);


                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Delete_Resource", prms);
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

                Label lblProject = (Label)gvRow.FindControl("lblProject");
                txtResourceName.Text = lblProject.Text.ToString();
                hfValue.Value = ((int)grdResourceDetail.DataKeys[gvRow.RowIndex].Value).ToString();

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
                txtResourceName.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;
            }
        }
    }
}