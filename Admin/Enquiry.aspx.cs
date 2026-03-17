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
    public partial class Enquiry : System.Web.UI.Page
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
                string sql = string.Format("Select_ContactDetails");
                ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, sql);
                grdEnquiryDetail.DataSource = ds;
                grdEnquiryDetail.DataBind();
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


                Label lblName = (Label)gvRow.FindControl("Label1");
                lblNamePop.Text = lblName.Text.ToString();

                Label lblemail = (Label)gvRow.FindControl("Label4");
                lblEmailpop.Text = lblemail.Text.ToString();

                Label lblMobile = (Label)gvRow.FindControl("Label1f");
                lblMobilepop.Text = lblMobile.Text.ToString();


                HiddenField lbldetail = (HiddenField)gvRow.FindControl("hfdetail");
                lblQuerypop.Text = lbldetail.Value;

                Label lblPostedDate = (Label)gvRow.FindControl("Label16");
                lblQuiryDate.Text = lblPostedDate.Text.ToString();


                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "OpenPopup();", true);

            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;
            }
        }
        protected void grdEnquiryDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                hfValue.Value = ((int)grdEnquiryDetail.DataKeys[e.RowIndex].Value).ToString();
                SqlParameter[] prms = new SqlParameter[1];
                prms[0] = new SqlParameter("@ID", hfValue.Value);

                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Delete_ContactDetails", prms);
                FillGrid();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Record has been Deleted successfully.');", true);
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;
            }
        }

        protected void grdEnquiryDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdEnquiryDetail.PageIndex = e.NewPageIndex;
            FillGrid();
        }
    }
}