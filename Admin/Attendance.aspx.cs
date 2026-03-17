using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Orient
{
    public partial class Attendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            LblHeading.Visible=false;
            LblHeading.Text=HttpContext.Current.User.Identity.Name;
            try
            {
                SqlParameter[] prms = new SqlParameter[1];
                prms[0] = new SqlParameter("@UserName", LblHeading.Text);

                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Insert_Attendance", prms);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Record has been Saved successfully.');", true);
                    btnsubmit.Enabled = false;
                    btnCancel.Enabled = true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            LblHeading.Visible = false;
            LblHeading.Text = HttpContext.Current.User.Identity.Name;
            try
            {
                SqlParameter[] prms = new SqlParameter[1];
                prms[0] = new SqlParameter("@UserName", LblHeading.Text);

                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Update_Attendance", prms);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Record has been Updated successfully.');", true);
                btnsubmit.Enabled = true;
                btnCancel.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}