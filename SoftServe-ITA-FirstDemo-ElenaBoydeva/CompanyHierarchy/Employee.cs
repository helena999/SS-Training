namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {  
        private string name;
        private string superior;
        private List<Employee> subordinates;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;

            }
        }

        public string Superior
        {
            get
            {
                return this.superior;
            }
            set
            {
                this.superior = value;

            }
        }

        public Employee(string employeeName)
        {
            this.Name = employeeName;
            this.subordinates = new List<Employee>();

        }

        public void AddSubordinate(Employee employee)
        {
            subordinates.Add(employee);
            employee.Superior = Name;

            if (subordinates.Count > 2)
            {
                Console.WriteLine("Superior does not allow to have more than 2 subordinates!");
            }
        }

        public string GetSuperior(Employee employee)
        {
            string superior = employee.Superior;
            return superior;
        }
    }
}
