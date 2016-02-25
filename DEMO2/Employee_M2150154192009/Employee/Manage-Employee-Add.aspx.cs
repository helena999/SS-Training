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

public partial class Manage_Employee_Add : System.Web.UI.Page
{
    clsDeparment objDeparment = new clsDeparment();
    clsEmployee objEmployee = new clsEmployee();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDeparments();
            if (Request["EmployeeId"] != null)
            {
                getEmployeeDetails(Convert.ToInt32(Request["EmployeeId"].ToString()));
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                imgPhoto.Visible = true;
            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                imgPhoto.Visible = false;
            }
        }
    }

    protected void FillDeparments()
    {
        DataSet dsDeparment = new DataSet();
        dsDeparment = objDeparment.SelectAll();
        ddlDepartment.DataTextField = "DepartmentName";
        ddlDepartment.DataValueField = "DepartmentId";
        ddlDepartment.DataSource = dsDeparment.Tables[0];
        ddlDepartment.DataBind();
    }

    protected void getEmployeeDetails(int EmployeeId)
    {
        objEmployee.EmployeeId = EmployeeId;
        objEmployee.SelectById();
        txtName.Text = objEmployee.Name.ToString();
        txtDesignation.Text = objEmployee.Designation.ToString();
        ddlDepartment.SelectedValue = objEmployee.DepartmentId.ToString();
        if (objEmployee.DOJ.CompareTo(Convert.ToDateTime("01/01/1900")) > 0)
        {
            txtDOJ.Text = objEmployee.DOJ.ToShortDateString();
        }
        else
        {
            txtDOJ.Text = "";
        }

        if (objEmployee.DOC.CompareTo(Convert.ToDateTime("01/01/1900")) > 0)
        {
            txtDOC.Text = objEmployee.DOC.ToShortDateString();
        }
        else
        {
            txtDOC.Text = "";
        }

        if (objEmployee.DOB.CompareTo(Convert.ToDateTime("01/01/1900")) > 0)
        {
            txtDOB.Text = objEmployee.DOB.ToShortDateString();
        }
        else
        {
            txtDOB.Text = "";
        }

        ddlStatus.SelectedValue = objEmployee.Status.ToString();
        txtAddress.Text = objEmployee.Address.ToString();
        txtCity.Text = objEmployee.City.ToString();
        txtState.Text = objEmployee.State.ToString();
        txtZipcode.Text = objEmployee.Zip.ToString();
        txtPhone.Text = objEmployee.Phone.ToString();
        txtMobile.Text = objEmployee.Mobile.ToString();
        txtEmail.Text = objEmployee.Email.ToString();
        txtBio.Text = objEmployee.Bio.ToString();
        txtDegree.Text = objEmployee.Degree.ToString();
        txtPhoto.Text = objEmployee.Photo.ToString();
        imgPhoto.ImageUrl = "EmpPhotos\\" + objEmployee.Photo.ToString();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Employee.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string sFilename = Guid.NewGuid().ToString();
        if (filePhoto.HasFile)
        {
            string sPath = "";
            string sFile = filePhoto.FileName.ToString();
            sPath = Server.MapPath("EmpPhotos");
            sFilename = sFilename + sFile.Substring(sFile.LastIndexOf("."));
            filePhoto.SaveAs(sPath + "\\" + sFilename);
        }
        else
        {
            sFilename = "NoImage.jpg";
        }
        objEmployee.Name = txtName.Text.Trim();
        objEmployee.Designation = txtDesignation.Text.Trim();
        objEmployee.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
        if (txtDOJ.Text.Trim() != "")
        {
            objEmployee.DOJ = Convert.ToDateTime(txtDOJ.Text.Trim());
        }
        else
        {
            objEmployee.DOJ = Convert.ToDateTime("01/01/1900");
        }
        if (txtDOC.Text.Trim() != "")
        {
            objEmployee.DOC = Convert.ToDateTime(txtDOC.Text.Trim());
        }
        else
        {
            objEmployee.DOC = Convert.ToDateTime("01/01/1900");
        }
        objEmployee.Status = Convert.ToInt32(ddlStatus.SelectedValue);
        if (txtDOB.Text.Trim() != "")
        {
            objEmployee.DOB = Convert.ToDateTime(txtDOB.Text.Trim());
        }
        else
        {
            objEmployee.DOB = Convert.ToDateTime("01/01/1900");
        }
        objEmployee.Address = txtAddress.Text.Trim();
        objEmployee.City = txtCity.Text.Trim();
        objEmployee.State= txtState.Text.Trim();
        objEmployee.Zip = txtZipcode.Text.Trim();
        objEmployee.Phone = txtPhone.Text.Trim();
        objEmployee.Mobile = txtMobile.Text.Trim();
        objEmployee.Email= txtEmail.Text.Trim();
        objEmployee.Bio = txtBio.Text.Trim();
        objEmployee.Degree = txtDegree.Text.Trim();
        objEmployee.Photo = sFilename;
        objEmployee.Insert();
        Response.Redirect("Manage-Employee.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objEmployee.EmployeeId = Convert.ToInt32(Request["EmployeeId"].ToString());
        string sFilename = Guid.NewGuid().ToString();
        if (filePhoto.HasFile)
        {
            string sPath = "";
            string sFile = filePhoto.FileName.ToString();
            sPath = Server.MapPath("EmpPhotos");
            sFilename = sFilename + sFile.Substring(sFile.LastIndexOf("."));
            filePhoto.SaveAs(sPath + "\\" + sFilename);
        }
        else
        {
            sFilename = txtPhoto.Text;
        }
        objEmployee.Name = txtName.Text.Trim();
        objEmployee.Designation = txtDesignation.Text.Trim();
        objEmployee.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
        if (txtDOJ.Text.Trim() != "")
        {
            objEmployee.DOJ = Convert.ToDateTime(txtDOJ.Text.Trim());
        }
        else
        {
            objEmployee.DOJ = Convert.ToDateTime("01/01/1900");
        }
        if (txtDOC.Text.Trim() != "")
        {
            objEmployee.DOC = Convert.ToDateTime(txtDOC.Text.Trim());
        }
        else
        {
            objEmployee.DOC = Convert.ToDateTime("01/01/1900");
        }
        objEmployee.Status = Convert.ToInt32(ddlStatus.SelectedValue);
        if (txtDOB.Text.Trim() != "")
        {
            objEmployee.DOB = Convert.ToDateTime(txtDOB.Text.Trim());
        }
        else
        {
            objEmployee.DOB = Convert.ToDateTime("01/01/1900");
        }
        objEmployee.Address = txtAddress.Text.Trim();
        objEmployee.City = txtCity.Text.Trim();
        objEmployee.State = txtState.Text.Trim();
        objEmployee.Zip = txtZipcode.Text.Trim();
        objEmployee.Phone = txtPhone.Text.Trim();
        objEmployee.Mobile = txtMobile.Text.Trim();
        objEmployee.Email = txtEmail.Text.Trim();
        objEmployee.Bio = txtBio.Text.Trim();
        objEmployee.Degree = txtDegree.Text.Trim();
        objEmployee.Photo = sFilename;
        objEmployee.Update();
        Response.Redirect("Manage-Employee.aspx");
    }
}
