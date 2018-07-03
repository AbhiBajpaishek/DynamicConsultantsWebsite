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
        for (int i = 17; i < 90; i++)
        {
            ageDropDown.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        ageDropDown.Items.Add(new ListItem("90+", "90"));
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (validationCheck(txtPassword.Text, txtRePassword.Text) == false)
        {
            lblPasswordError.Text = "Password didn't match";
            lblRePasswordError.Text = "Password didn't match";
        }
        else if (emptyCheck() && txtPassword.Text != "")
        {//if the fields aren't empty it will chekc for existing data or fresh registration
            if (db.ReadBulkData("select Name from Tbl_Registration where Email= '" + txtMail.Text + "';").Rows.Count > 0)
            {//for update
                if (db.spUpdate(txtName.Text, txtMail.Text, ageDropDown.SelectedValue, genderList.SelectedValue, txtPassword.Text))
                    Console.Write("<script>alert('Updated Successfully')</script>");
                else
                    Console.Write("<script>alert('Some Error Occured')</script>");
                registeredDataGridView.DataSource = db.ReadBulkData(query);
                registeredDataGridView.DataBind();
            }
            else
            {//for fresh registration
                if (db.spRegistration(txtName.Text, txtMail.Text, ageDropDown.SelectedValue, genderList.SelectedValue, txtPassword.Text, Session["uid"].ToString()))
                    Console.Write("<script>alert('Registration Succesfull')</script>");
                else
                    Console.Write("<script>alert('Failure')</script>");
            }
        }
        registeredDataGridView.DataSource = db.ReadBulkData(query);
        registeredDataGridView.DataBind();
        clearFields();
    }



    //for clearing filds
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
        if (txtName.Text != "")
        {
            if (txtMail.Text != "")
            {
                if (ageDropDown.SelectedValue != "Select")
                    return true;
                else
                    lblAgeError.Text = "Select Age";
            }
            else
                lblMailError.Text = "Please Enter E-Mail ";
        }
        else
            lblNameError.Text = "Please Enter Name";
        return false;

    }

    protected void registeredDataGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = db.ReadBulkData(query);
        if (db.spDelete(dt.Rows[e.RowIndex][1].ToString()))
            Console.Write("Record Deleted");
        else
            Console.Write("Some Error Occured");
        registeredDataGridView.DataSource = db.ReadBulkData(query);
        registeredDataGridView.DataBind();
        clearFields();
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
        ageDropDown.SelectedValue = dt.Rows[e.NewEditIndex][3].ToString();
    }
}