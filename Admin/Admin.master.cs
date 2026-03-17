using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (Session["AdminLog"] == null)
        //{
        //    Response.Redirect("~/Default.aspx");
        //}
        if (!IsPostBack)
        {
            if (HttpContext.Current.User!=null)
            {
                lblHeading.Text = HttpContext.Current.User.Identity.Name;
                //Session["UserName"] = HttpContext.Current.User.Identity.Name;
            }
           
        }
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
       
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
       
    }
    //void LoginCheck()
    //{
    //    try
    //    {
    //        if (Session["UserType"].ToString() == "Super Admin")
    //        {
    //           // AdminReg.Visible = true;
    //           // BankDetail.Visible = true;
    //        }
    //        else
    //        {
    //          //  AdminReg.Visible = false;
    //           // BankDetail.Visible = true;
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        //throw ex;
    //    }
    //}
}
