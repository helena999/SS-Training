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
    public class clsTrainings
    {
        public clsTrainings()
        {
        }

        #region Variables
        DBBridge objDBBridge = new DBBridge();
        protected int _TrainingId;
        protected DateTime _StartDate;
        protected DateTime _EndDate;
        protected string _TrainingDetails = String.Empty;
        protected string _Effectiveness = String.Empty;
        protected int _JobType;
        protected int _EmployeeId;
        const string _spName = "sp_tblTrainings";
        #endregion

        #region Class Property
        public int TrainingId
        {
            get { return _TrainingId; }
            set { _TrainingId = value; }
        }

        public DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }

        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }

        public string TrainingDetails
        {
            get { return _TrainingDetails; }
            set { _TrainingDetails = value; }
        }

        public string Effectiveness
        {
            get { return _Effectiveness; }
            set { _Effectiveness = value; }
        }

        public int JobType
        {
            get { return _JobType; }
            set { _JobType = value; }
        }

        public int EmployeeId
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value; }
        }

        #endregion

        #region Public Methods

        public int Insert()
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@Mode", "Insert");
            param[1] = new SqlParameter("@StartDate", _StartDate);
            param[2] = new SqlParameter("@EndDate", _EndDate);
            param[3] = new SqlParameter("@TrainingDetails", _TrainingDetails);
            param[4] = new SqlParameter("@Effectiveness", _Effectiveness);
            param[5] = new SqlParameter("@JobType", _JobType);
            param[6] = new SqlParameter("@EmployeeId", _EmployeeId);
            return objDBBridge.ExecuteNonQuery(_spName, param);
        }

        public int Update()
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@Mode", "Update");
            param[1] = new SqlParameter("@StartDate", _StartDate);
            param[2] = new SqlParameter("@EndDate", _EndDate);
            param[3] = new SqlParameter("@TrainingDetails", _TrainingDetails);
            param[4] = new SqlParameter("@Effectiveness", _Effectiveness);
            param[5] = new SqlParameter("@JobType", _JobType);
            param[6] = new SqlParameter("@EmployeeId", _EmployeeId);
            param[7] = new SqlParameter("@TrainingId", _TrainingId);
            return objDBBridge.ExecuteNonQuery(_spName, param);
        }

        public int Delete()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "Delete");
            param[1] = new SqlParameter("@TrainingId", _TrainingId);
            return objDBBridge.ExecuteNonQuery(_spName, param);
        }

        public DataSet SelectByEmployee()
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Mode", "ViewByEmployee");
            param[1] = new SqlParameter("@JobType", _JobType);
            param[2] = new SqlParameter("@EmployeeId", _EmployeeId);
            return objDBBridge.ExecuteDataset(_spName, param);
        }

        public void SelectById()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "ViewByID");
            param[1] = new SqlParameter("@TrainingId", _TrainingId);
            DataTable dtTraining = new DataTable();
            dtTraining = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
            if (dtTraining.Rows.Count != 0)
            {
                DataRow drTraining;
                drTraining = dtTraining.Rows[0];
                _StartDate = Convert.ToDateTime(drTraining["StartDate"]);
                _EndDate = Convert.ToDateTime(drTraining["EndDate"]);
                _TrainingDetails = drTraining["TrainingDetails"].ToString();
                _Effectiveness = drTraining["Effectiveness"].ToString();
                _JobType = Convert.ToInt32(drTraining["JobType"]);
                _EmployeeId = Convert.ToInt32(drTraining["EmployeeId"]);
            }
        }
        #endregion
    }
}