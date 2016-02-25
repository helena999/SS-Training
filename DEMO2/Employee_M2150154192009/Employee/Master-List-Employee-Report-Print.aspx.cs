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
public partial class Master_List_Employee_Report_Print : System.Web.UI.Page
{
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
            FillEmployeeDetails();
        }
    }

    protected void FillEmployeeDetails()
    {
        gvMaster.DataSource = objEmployee.Select();
        gvMaster.DataBind();
    }

    public string getFormatedDate(DateTime dDate)
    {
        if (dDate.CompareTo(Convert.ToDateTime("01/01/1900")) > 0)
        {
            return dDate.ToString("dd/MM/yyyy");
        }
        else
        {
            return "";

        }
    }
    public string getDepartmentName(int DeparmentId)
    {
        objDeparment.DepartmentId = DeparmentId;
        objDeparment.SelectById();
        return objDeparment.DepartmentName.ToString();
    }
}
