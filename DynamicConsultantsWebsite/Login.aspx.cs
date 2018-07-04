using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<script>alert('Hello');</script>");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        DBA db = new DBA();
        DataTable dt=db.ReadBulkData("select * from Tbl_Login where Username='"+txtUser.Text+"'");
        if(dt.Rows.Count>0)
        {
            if(dt.Rows[0][1].ToString().Equals(txtPassword.Text))
            {
                Session["uid"] = txtUser.Text;
                Response.Redirect("/AdminRegistration.aspx");
            }
            else
            {
                lblError.Text = "Invalid Credentials";
            }
        }
        else
        {
            lblError.Text = "Invalid Credentials";
        }
    }
}