using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Employee.DAL;
using System.Data.SqlClient;

namespace Employee.BLL
{
    public class clsDeparment
    {
        public clsDeparment()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Variables
        DBBridge objDBBridge = new DBBridge();
        protected int _DepartmentId;
        protected string _DepartmentName = String.Empty;
        const string _spName = "sp_tblDepartment";
        #endregion

        #region Class Property
        public int DepartmentId
        {
            get { return _DepartmentId; }
            set { _DepartmentId = value; }
        }

        public string DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
        }

        #endregion

        #region Public Methods

        public int Insert()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "Insert");
            param[1] = new SqlParameter("@DepartmentName", _DepartmentName);
            return objDBBridge.ExecuteNonQuery(_spName, param);
        }

        public int Update()
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Mode", "Update");
            param[1] = new SqlParameter("@DepartmentName", _DepartmentName);
            param[2] = new SqlParameter("@DepartmentId", _DepartmentId);
            return objDBBridge.ExecuteNonQuery(_spName, param);
        }

        public int Delete()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "Delete");
            param[1] = new SqlParameter("@DepartmentId", _DepartmentId);
            return objDBBridge.ExecuteNonQuery(_spName, param);
        }

        public DataSet SelectAll()
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Mode", "View");
            return objDBBridge.ExecuteDataset(_spName, param);
        }

        public void SelectById()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "ViewByID");
            param[1] = new SqlParameter("@DepartmentId", _DepartmentId);
            DataTable dtDepartment = new DataTable();
            dtDepartment = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
            if (dtDepartment.Rows.Count != 0)
            {
                DataRow drDepartment;
                drDepartment = dtDepartment.Rows[0];
                _DepartmentName = drDepartment["DepartmentName"].ToString();
            }
        }
        #endregion
    }
}
