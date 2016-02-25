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

public partial class Employee_Service_Report : System.Web.UI.Page
{
    clsEmployee objEmployee = new clsEmployee();
    clsDeparment objDeparment = new clsDeparment();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillYears();
            FillEmployeeDetails();           
        }
    }

    protected void FillEmployeeDetails()
    {
        if (ddlExperience.SelectedValue == "View All")
        {
            objEmployee.Years = -1;
        }
        else
        {
            objEmployee.Years = Convert.ToInt32(ddlExperience.SelectedValue);
        }
        gvMaster.DataSource = objEmployee.SelectByExperience();
        gvMaster.DataBind();
    }
    protected void FillYears()
    {
        ddlExperience.Items.Add("View All");
        DataTable dt = new DataTable();
        dt = objEmployee.ViewYears().Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            ddlExperience.Items.Add(dr[0].ToString());
        }
    }
    protected void ddlExperience_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillEmployeeDetails();
    }
}
