using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace Orient
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prms = new SqlParameter[2];
                    prms[0] = new SqlParameter("@Password", txtCPass.Text);
                    prms[1] = new SqlParameter("@NewPassword", txtNPass.Text);
                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "ChangePass_Admin", prms);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Password has been Changed successfully.');", true);
                    txtCPass.Text = "";
                    txtNPass.Text = "";
                    txtxRePass.Text = "";
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
                txtCPass.Text = "";
                txtNPass.Text = "";
                txtxRePass.Text = "";

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}