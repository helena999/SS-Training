using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Employee.BLL;

public partial class Manage_Login_Add : System.Web.UI.Page
{
    clsLogin objLogin = new clsLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["LoginId"] != null)
            {
                getLoginDetails(Convert.ToInt32(Request["LoginId"].ToString()));
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
        }
    }

    protected void getLoginDetails(int loginId)
    {
        objLogin.LoginId = loginId;
        objLogin.SelectById();
        txtName.Text = objLogin.LoginName.ToString();
        txtEmail.Text = objLogin.Email.ToString();
        txtUsername.Text = objLogin.Username.ToString();
        txtPassword.Text = objLogin.Password.ToString();
        ddlRights.SelectedValue = objLogin.Rights.ToString();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Login.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        objLogin.LoginName = txtName.Text.Trim();
        objLogin.Email = txtEmail.Text.Trim();
        objLogin.Username = txtUsername.Text.Trim();
        objLogin.Password = txtPassword.Text.Trim();
        objLogin.Rights = Convert.ToInt32(ddlRights.SelectedValue.ToString());
        objLogin.Insert();
        Response.Redirect("Manage-Login.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objLogin.LoginId = Convert.ToInt32(Request["LoginId"].ToString());
        objLogin.LoginName = txtName.Text.Trim();
        objLogin.Email = txtEmail.Text.Trim();
        objLogin.Username = txtUsername.Text.Trim();
        objLogin.Password = txtPassword.Text.Trim();
        objLogin.Rights = Convert.ToInt32(ddlRights.SelectedValue.ToString());
        objLogin.Update();
        Response.Redirect("Manage-Login.aspx");
    }
}
