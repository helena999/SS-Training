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

public partial class includes_ucRightMenu : System.Web.UI.UserControl
{
    clsEmployee objEmployee = new clsEmployee();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Rights"].ToString() == "0")
        {
            divAdmin.Visible=false;
        }
        if (!IsPostBack)
        {
            lblEmpCount.Text = objEmployee.EmployeeCount();
            dlBirthday.DataSource = objEmployee.Birthday();
            dlBirthday.DataBind();
            if (dlBirthday.Items.Count == 0)
            {
                lblMessage.Text = "No Alerts this Month";
            }
        }
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["LoginName"] = null;
        Session["Rights"] = null;
        Response.Redirect("login.aspx");
    }
}
