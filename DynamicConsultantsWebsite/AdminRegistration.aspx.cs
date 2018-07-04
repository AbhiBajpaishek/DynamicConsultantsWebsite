using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class AdminRegistration : System.Web.UI.Page
{
    String query = "select * from Tbl_Registration where Status='Active';";
    DBA db = new DBA();

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["uid"] = "Admin";
        dropDownAge();
        registeredDataGridView.DataSource = db.ReadBulkData(query);
        registeredDataGridView.DataBind();
    }


    //for adding values to age drop down list
    void dropDownAge()
    {
        ageDropDown.Items.Add(new ListItem("Select"));
        for (int i = 17; i < 90; i++)
        {
            ageDropDown.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        ageDropDown.Items.Add(new ListItem("90+", "90"));
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (emptyCheck())
        {
            //if the fields aren't empty it will check for existing data or fresh registration
            if (validationCheck(txtPassword.Text, txtRePassword.Text))
            {
                if (db.ReadBulkData("select Name from Tbl_Registration where Email= '" + txtMail.Text + "';").Rows.Count > 0)
                {
                    //for update
                    if (db.spUpdate(txtName.Text, txtMail.Text, ageDropDown.SelectedValue, genderList.SelectedValue, txtPassword.Text))
                    {
                        Response.Write("<script>alert('Updated Successfully')</script>");
                        clearFields();
                    }
                       
                    else
                        Response.Write("<script>alert('Some Error Occured')</script>");
                    registeredDataGridView.DataSource = db.ReadBulkData(query);
                    registeredDataGridView.DataBind();
                }
                else
                {
                    //for fresh registration
                    if (db.spRegistration(txtName.Text, txtMail.Text, ageDropDown.SelectedValue, genderList.SelectedValue, txtPassword.Text, Session["uid"].ToString()))
                    {
                        Response.Write("<script>alert('Registration Succesfull')</script>");
                        clearFields();
                    }
                    else
                        Response.Write("<script>alert('Failure')</script>");
                }
            }
            else
                lblPasswordError.Text = "Passwords didn't Match";
        }
        registeredDataGridView.DataSource = db.ReadBulkData(query);
        registeredDataGridView.DataBind();
    }


    //for clearing fields
    public void clearFields()
    {
        ageDropDown.SelectedIndex = 0;
        txtMail.Text = "";
        txtName.Text = "";
        txtPassword.Text = "";
        txtRePassword.Text = "";
        genderList.SelectedIndex = 0;
    }

    //for checking passwords matching or not

    public bool validationCheck(String pass, String confirmPass)
    {
        if (pass.Equals(confirmPass))
        {
            return true;
        }
        return false;
    }

    //for checking empty fields
    public bool emptyCheck()
    {
        bool flag = true;
        lblNameError.Text = "";
        lblPasswordError.Text = "";
        lblRePasswordError.Text = "";
        lblGenderError.Text = "";
        lblMailError.Text = "";
        lblAgeError.Text = "";
        if (txtName.Text == "")
        {
            flag = false;
            lblNameError.Text = "Please Enter Name!!";
        }

        if (txtMail.Text == "")
        {
            flag = false;
            lblMailError.Text = "Please Enter E-Mail!!";
        }
        if(txtPassword.Text=="")
        {
            flag = false;
            lblPasswordError.Text = "Enter Password";
        }
        if(txtRePassword.Text=="")
        {
            flag = false;
            lblRePasswordError.Text = "Please re-enter Password";
        }
        if (ageDropDown.SelectedValue == "Select")
        {
            flag = false;
            lblAgeError.Text = "Select Age!!";
        }
        if (genderList.SelectedIndex != 0 && genderList.SelectedIndex != 1)
        {
            lblGenderError.Text = "Please Choose Gender!!";
            flag = false;
        }
        return flag;
    }

    protected void registeredDataGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = db.ReadBulkData(query);
        if (db.spDelete(dt.Rows[e.RowIndex][1].ToString()))
            Response.Write("Record Deleted");
        else
            Response.Write("Some Error Occured");
        registeredDataGridView.DataSource = db.ReadBulkData(query);
        registeredDataGridView.DataBind();
        //clearFields();
    }

    protected void registeredDataGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataTable dt = db.ReadBulkData(query);
        txtName.Text = dt.Rows[e.NewEditIndex][0].ToString();
        txtMail.Text = dt.Rows[e.NewEditIndex][1].ToString();
        if (dt.Rows[e.NewEditIndex][2].ToString() == "Male")
            genderList.SelectedIndex = 0;
        else
            genderList.SelectedIndex = 1;
        txtPassword.TextMode = TextBoxMode.SingleLine;
        txtRePassword.TextMode = TextBoxMode.SingleLine;
        txtPassword.Text = db.ReadBulkData("select Password from Tbl_Login where Username = '" + txtMail.Text + "'").Rows[0][0].ToString();
        txtRePassword.Text = txtPassword.Text;
        //txtPassword.TextMode = TextBoxMode.Password;
        //txtRePassword.TextMode = TextBoxMode.Password;
        ageDropDown.SelectedValue = dt.Rows[e.NewEditIndex][3].ToString();
        registeredDataGridView.DataSource = db.ReadBulkData(query);
        registeredDataGridView.DataBind();
        e.Cancel = true;
    }
}