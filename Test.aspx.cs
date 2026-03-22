using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Net;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave1_Click(object sender, EventArgs e)
    {




        string sCon = "        ";
        sCon = System.Configuration.ConfigurationManager.AppSettings["Strcon"].ToString();
        SqlConnection con = new SqlConnection(sCon);
        string sQuery = "";   
        sQuery = " insert into tblEnquiry(Name,Contact_No,Email_Id,Enquiry_Date,Query) values('" + txtName.Text + "','" + txtContact.Text + "','" + txtEmail.Text + "',Getdate(),'" + txtQuery.Text + "'" + ")";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sQuery;
        cmd.Connection = con;
        cmd.Connection.Open();




        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "addScript", "alert('Enquiry send successfully.');", true);
        txtName.Text = "";
        txtQuery.Text = "";
        txtEmail.Text = "";
        txtContact.Text = "";

       // Response.Write("Save succesfully ");
    }
}