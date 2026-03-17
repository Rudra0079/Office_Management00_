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
    public partial class Admin : System.Web.UI.Page
    {
        UserLogin obj = new UserLogin();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prms = new SqlParameter[2];
                prms[0] = new SqlParameter("@UserName", txtUserId.Text);
                prms[1] = new SqlParameter("@Password", txtPassword.Text);

                ds= SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Select_User", prms);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    obj.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                    obj.UserName = dt.Rows[0]["UserName"].ToString();
                    obj.EmailId = dt.Rows[0]["EmailId"].ToString();
                    obj.ResourceId = Convert.ToInt32(dt.Rows[0]["ResourceId"].ToString());
                    obj.ExpiryDate = Convert.ToDateTime(dt.Rows[0]["ExpiryDate"].ToString());
                    obj.HitCounter = Convert.ToInt32(dt.Rows[0]["HitCounter"].ToString());
                    obj.UserType = dt.Rows[0]["UserType"].ToString();

                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(txtUserId.Text.Trim(), true);
                    Response.Redirect("~/Admin/Default.aspx");
                }

            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = ex.Message;
            }
        }
    }
}