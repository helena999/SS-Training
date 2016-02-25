using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeesManagementSystem.Models
{
    public class TeamEmployees
    {
        public int TeamId { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JobPositionID { get; set; }
        public string JobPosition { get; set; }
    }
}