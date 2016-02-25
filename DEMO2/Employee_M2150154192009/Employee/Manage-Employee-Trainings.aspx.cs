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

public partial class Manage_Employee_Trainings : System.Web.UI.Page
{
    clsTrainings objTrainings = new clsTrainings();
    clsEmployee objEmployee = new clsEmployee();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillTrainingsDetails();
        }
    }

    protected void FillTrainingsDetails()
    {
        if (Request["JobType"].ToString() == "1")
        {
            lblTraining.Text = "In Job Trainings";
        }
        else if (Request["JobType"].ToString() == "2")
        {
            lblTraining.Text = "Off Job Trainings";
        }
        objEmployee.EmployeeId = Convert.ToInt32(Request["EmpId"].ToString());
        objEmployee.SelectById();
        lblEmployeeName.Text = objEmployee.Name.ToString();
        objTrainings.EmployeeId = Convert.ToInt32(Request["EmpId"].ToString());
        objTrainings.JobType = Convert.ToInt32(Request["JobType"].ToString());
        gvMaster.DataSource = objTrainings.SelectByEmployee();
        gvMaster.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Employee-Trainings-Add.aspx?EmpId=" + Request["EmpId"].ToString() + "&JobType=" + Request["JobType"].ToString());
    }

    protected void gvMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString().ToUpper() == "EDIT")
        {
            Response.Redirect("Manage-Employee-Trainings-Add.aspx?EmpId=" + Request["EmpId"].ToString() + "&JobType=" + Request["JobType"].ToString() + "&TrainingId=" + e.CommandArgument.ToString());
        }
        if (e.CommandName.ToString().ToUpper() == "DELETE")
        {
            objTrainings.TrainingId = Convert.ToInt32(e.CommandArgument.ToString());
            objTrainings.Delete();
            lblMessage.Text = "Training Details successfully deleted!";
        }
    }

    protected void gvMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        FillTrainingsDetails();
    }

    protected void gvMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbDelete = (LinkButton)e.Row.FindControl("lbDelete");
            lbDelete.Attributes.Add("onclick", "return confirm('Are you sure to delete?');");
        }
    }

    protected void gvMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMaster.PageIndex = e.NewPageIndex;
        FillTrainingsDetails();
    }

    protected void chkStatus_CheckedChanged(object sender, EventArgs e)
    {
        FillTrainingsDetails();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Employee.aspx");
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
