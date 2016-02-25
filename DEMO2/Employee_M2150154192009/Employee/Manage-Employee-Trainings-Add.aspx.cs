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

public partial class Manage_Employee_Trainings_Add : System.Web.UI.Page
{
    clsTrainings objTrainings = new clsTrainings();
    clsEmployee objEmployee = new clsEmployee();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["TrainingId"] != null)
            {
                getTrainingDetails(Convert.ToInt32(Request["TrainingId"].ToString()));
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
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
    }

    protected void getTrainingDetails(int TrainingId)
    {
        objTrainings.TrainingId = TrainingId;
        objTrainings.SelectById();
        if (objTrainings.StartDate.CompareTo(Convert.ToDateTime("01/01/1900")) > 0)
        {
            txtStartDate.Text = objTrainings.StartDate.ToShortDateString();
        }
        else
        {
            txtStartDate.Text = "";
        }
        if (objTrainings.EndDate.CompareTo(Convert.ToDateTime("01/01/1900")) > 0)
        {
            txtEndDate.Text = objTrainings.EndDate.ToShortDateString();
        }
        else
        {
            txtEndDate.Text = "";
        }
        txtTrainings.Text = objTrainings.TrainingDetails.ToString();
        txtEffectiveness.Text = objTrainings.Effectiveness.ToString();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Employee-Trainings.aspx?EmpId=" + Request["EmpId"].ToString() + "&JobType=" + Request["JobType"].ToString());
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtStartDate.Text.Trim() != "")
        {
            objTrainings.StartDate = Convert.ToDateTime(txtStartDate.Text.Trim());
        }
        else
        {
            objTrainings.StartDate = Convert.ToDateTime("01/01/1900");
        }
        if (txtEndDate.Text.Trim() != "")
        {
            objTrainings.EndDate = Convert.ToDateTime(txtEndDate.Text.Trim());
        }
        else
        {
            objTrainings.EndDate = Convert.ToDateTime("01/01/1900");
        }
        objTrainings.TrainingDetails = txtTrainings.Text.Trim();
        objTrainings.Effectiveness = txtEffectiveness.Text.Trim();
        objTrainings.EmployeeId = Convert.ToInt32(Request["EmpId"].ToString());
        objTrainings.JobType = Convert.ToInt32(Request["JobType"].ToString());
        objTrainings.Insert();
        Response.Redirect("Manage-Employee-Trainings.aspx?EmpId=" + Request["EmpId"].ToString() + "&JobType=" + Request["JobType"].ToString());
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objTrainings.TrainingId = Convert.ToInt32(Request["TrainingId"].ToString());
        if (txtStartDate.Text.Trim() != "")
        {
            objTrainings.StartDate = Convert.ToDateTime(txtStartDate.Text.Trim());
        }
        else
        {
            objTrainings.StartDate = Convert.ToDateTime("01/01/1900");
        }
        if (txtEndDate.Text.Trim() != "")
        {
            objTrainings.EndDate = Convert.ToDateTime(txtEndDate.Text.Trim());
        }
        else
        {
            objTrainings.EndDate = Convert.ToDateTime("01/01/1900");
        }
        objTrainings.TrainingDetails = txtTrainings.Text.Trim();
        objTrainings.Effectiveness = txtEffectiveness.Text.Trim();
        objTrainings.EmployeeId = Convert.ToInt32(Request["EmpId"].ToString());
        objTrainings.JobType = Convert.ToInt32(Request["JobType"].ToString());
        objTrainings.Update();
        Response.Redirect("Manage-Employee-Trainings.aspx?EmpId=" + Request["EmpId"].ToString() + "&JobType=" + Request["JobType"].ToString());
    }
}
