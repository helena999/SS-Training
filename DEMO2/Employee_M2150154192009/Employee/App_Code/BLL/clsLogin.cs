using System;
using System.Data;
using Employee.DAL;
using System.Data.SqlClient;

namespace Employee.BLL
{
    public class clsLogin
    {
        public clsLogin()
        {
            
        }
        #region Variables
        DBBridge objDBBridge = new DBBridge();
        protected int _loginId;
        protected string _loginName = String.Empty;
        protected string _email = String.Empty;
        protected string _username = String.Empty;
        protected string _password = String.Empty;
        protected int _rights;
        protected DataSet _dsLogin = new DataSet();
        const string _spName = "sp_tblLogin";
        #endregion

        #region Class Property
        public int LoginId
        {
            get { return _loginId; }
            set { _loginId = value; }
        }

        public string LoginName
        {
            get { return _loginName; }
            set { _loginName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public int Rights
        {
            get { return _rights; }
            set { _rights = value; }
        }

        public DataSet dsLogin
        {
            get { return _dsLogin; }
            set { _dsLogin = value; }
        }
        #endregion

        #region Public Methods

        public int Insert()
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Mode", "Insert");
            param[1] = new SqlParameter("@LoginName", _loginName);
            param[2] = new SqlParameter("@Email", _email);
            param[3] = new SqlParameter("@Username", _username);
            param[4] = new SqlParameter("@Password", _password);
            param[5] = new SqlParameter("@Rights", _rights);
            return objDBBridge.ExecuteNonQuery(_spName, param);
        }

        public int Update()
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@Mode", "Update");
            param[1] = new SqlParameter("@LoginName", _loginName);
            param[2] = new SqlParameter("@Email", _email);
            param[3] = new SqlParameter("@Username", _username);
            param[4] = new SqlParameter("@Password", _password);
            param[5] = new SqlParameter("@Rights", _rights);
            param[6] = new SqlParameter("@LoginId", _loginId);
            return objDBBridge.ExecuteNonQuery(_spName, param);
        }

        public int Delete()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "Delete");
            param[1] = new SqlParameter("@LoginId", _loginId.ToString());
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
            param[1] = new SqlParameter("@LoginId", _loginId.ToString());
            DataTable dtUser = new DataTable();
            dtUser = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
            if (dtUser.Rows.Count != 0)
            {
                DataRow drLogin;
                drLogin = dtUser.Rows[0];
                _loginName = drLogin["LoginName"].ToString();
                _email = drLogin["Email"].ToString();
                _username = drLogin["Username"].ToString();
                _password = drLogin["Password"].ToString();
                _rights = Convert.ToInt32(drLogin["Rights"].ToString());
            }
        }

        public DataTable ValidateLogin()
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Mode", "ChkLogin");
            param[1] = new SqlParameter("@Username", _username);
            param[2] = new SqlParameter("@Password", _password);
            return objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        }      

        #endregion
    }
}
