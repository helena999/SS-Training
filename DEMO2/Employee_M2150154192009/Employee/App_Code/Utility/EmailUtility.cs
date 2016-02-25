using System;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace Employee.Utility
{
    public class EmailUtility
    {
        public EmailUtility()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Variables
        protected string _EmailTo = String.Empty;
        protected string _EmailMessage = String.Empty;
        protected string _EmailSubject = String.Empty;
        #endregion

        #region Class Property
        public string EmailTo
        {
            get { return _EmailTo; }
            set { _EmailTo = value; }
        }

        public string EmailMessage
        {
            get { return _EmailMessage; }
            set { _EmailMessage = value; }
        }

        public string EmailSubject
        {
            get { return _EmailSubject; }
            set { _EmailSubject = value; }
        }
        #endregion

        #region Public Methods
        public bool SendEmail()
        {
            NetworkCredential loginInfo = new NetworkCredential(ConfigurationManager.AppSettings["EmailUsername"].ToString(), ConfigurationManager.AppSettings["EmailPassword"].ToString());
            MailMessage objMailMessage = new MailMessage(ConfigurationManager.AppSettings["EmailFrom"].ToString(), _EmailTo);
            objMailMessage.Subject = _EmailSubject;
            objMailMessage.Body = _EmailMessage;
            objMailMessage.IsBodyHtml = true;
            SmtpClient objSmtp = new SmtpClient();
            objSmtp.Host = ConfigurationManager.AppSettings["EmailServer"].ToString();
            objSmtp.UseDefaultCredentials = false;
            objSmtp.Credentials = loginInfo;
            objSmtp.Send(objMailMessage);
            return true;
        }
        #endregion
    }
}