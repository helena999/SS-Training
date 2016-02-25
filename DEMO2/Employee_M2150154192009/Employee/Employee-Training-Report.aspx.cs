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

public partial class Employee_Training_Report : System.Web.UI.Page
{
    clsTrainings objTrainings = new clsTrainings();
    clsEmployee objEmployee = new clsEmployee();
    clsDeparment objDeparment = new clsDeparment();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["LoginName"] == null) || (Session["LoginName"].ToString() == ""))
        {
            Response.Redirect("login.aspx");
        }
        if (!Page.IsPostBack)
        {
            FillTrainingsDetails();
        }
    }

    protected void FillTrainingsDetails()
    {
        objEmployee.EmployeeId = Convert.ToInt32(Request["EmpId"].ToString());
        objEmployee.SelectById();
        lblEmployeeName.Text = objEmployee.Name.ToString();
        lblDesignation.Text = objEmployee.Designation.ToString();
        lblDegree.Text = objEmployee.Degree.ToString();
        if (objEmployee.DOJ.CompareTo(Convert.ToDateTime("01/01/1900")) > 0)
        {
            lblDOJ.Text = objEmployee.DOJ.ToString("dd/MM/yyyy");
        }
        else
        {
            lblDOJ.Text = "";
        }
        lblEmpId.Text = "EMP" + objEmployee.EmployeeId.ToString();
        objDeparment.DepartmentId = objEmployee.DepartmentId;
        objDeparment.SelectById();
        lblDepartment.Text = objDeparment.DepartmentName.ToString();
        objTrainings.EmployeeId = Convert.ToInt32(Request["EmpId"].ToString());
        objTrainings.JobType = 1;
        gvOnJob.DataSource = objTrainings.SelectByEmployee();
        gvOnJob.DataBind();
        objTrainings.EmployeeId = Convert.ToInt32(Request["EmpId"].ToString());
        objTrainings.JobType = 2;
        gvOffJob.DataSource = objTrainings.SelectByEmployee();
        gvOffJob.DataBind();
    }

    public string getDurationDate(DateTime dStartDate, DateTime dEndDate)
    {
        string sStartDate = "";
        string sEndDate = "";
        if (dStartDate.CompareTo(Convert.ToDateTime("01/01/1900")) > 0)
        {
            sStartDate = dStartDate.ToString("dd/MM/yyyy");
        }
        else
        {
            sStartDate = "";
        }

        if (dEndDate.CompareTo(Convert.ToDateTime("01/01/1900")) > 0)
        {
            sEndDate = dEndDate.ToString("dd/MM/yyyy");
        }
        else
        {
            sEndDate = "";
        }

        return sStartDate + " - " + sEndDate;
    }
}
