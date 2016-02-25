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

public partial class Manage_Department_Add : System.Web.UI.Page
{
    clsDeparment objDeparment = new clsDeparment();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["DeparmentId"] != null)
            {
                getDeparmentDetails(Convert.ToInt32(Request["DeparmentId"].ToString()));
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

    protected void getDeparmentDetails(int DeparmentId)
    {
        objDeparment.DepartmentId= DeparmentId;
        objDeparment.SelectById();
        txtName.Text = objDeparment.DepartmentName.ToString();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Department.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        objDeparment.DepartmentName = txtName.Text.Trim();
        objDeparment.Insert();
        Response.Redirect("Manage-Department.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objDeparment.DepartmentId = Convert.ToInt32(Request["DeparmentId"].ToString());
        objDeparment.DepartmentName = txtName.Text.Trim();
        objDeparment.Update();
        Response.Redirect("Manage-Department.aspx");
    }
}
