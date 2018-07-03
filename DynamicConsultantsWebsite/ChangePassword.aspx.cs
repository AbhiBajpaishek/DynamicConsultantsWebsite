using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

public partial class ChangePassword : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        changePassword();
    }


    void changePassword()
    {
        DBA db = new DBA();
        DataTable dt = db.ReadBulkData("select Username, Password from Tbl_Login where Username='" + txtUser.Text + "'");
        if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == txtUser.Text && dt.Rows[0][1].ToString() == txtOldPassword.Text)
        {
            if (txtOldPassword.Text != ""||txtNewPassword.Text!="")
            {
                if (validationCheck(txtNewPassword.Text, txtReNewPassword.Text))
                {
                    if (db.InsertUpdateDelete("update Tbl_login SET Password = '" + txtNewPassword.Text + "' where Username= '" + txtUser.Text + "';"))
                    {
                        Console.Write("Password Changed Succesfully");
                        clearFields();
                    }

                    else
                        Console.Write("Some Error Occurred");
                }
                else
                    Console.Write("Passwords didn't match");
            }
            else
                Console.Write("Please Enter Missing Fields");

        }
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "Invalid Credentials", true); 

    }


    public bool validationCheck(String pass, String confirmPass)
    {
        if (pass.Equals(confirmPass))
        {
            return true;
        }
        return false;
    }


    public void clearFields()
    {
        txtUser.Text = "";
        txtOldPassword.Text = "";
        txtNewPassword.Text = "";
        txtReNewPassword.Text = "";
    }

    protected void showHidePassword_CheckedChanged(object sender, EventArgs e)
    {
        if(IsPostBack)
        if (showHidePassword.Checked)
        {
            txtNewPassword.TextMode = TextBoxMode.SingleLine;
            txtOldPassword.TextMode = TextBoxMode.SingleLine;
            txtReNewPassword.TextMode = TextBoxMode.SingleLine;
            showHidePassword.Text = "Hide";
        }
        else
        {
            txtNewPassword.TextMode = TextBoxMode.Password;
            txtOldPassword.TextMode = TextBoxMode.Password;
            txtReNewPassword.TextMode = TextBoxMode.Password;
            showHidePassword.Text = "Show";
        }
    }
}