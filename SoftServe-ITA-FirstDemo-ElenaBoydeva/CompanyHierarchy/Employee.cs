namespace CompanyHierarchy
{
    using System.Collections.Generic;

    public class Employee
    {  
        //fields
        private string name; //value
        private List<Employee> subordinates; //children
        private int numberOfSubordinates; //number of children
  
        //properties
        public string Parent { get; set; }

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

        public int NumberOfSubordinates
        {
            get
            {
                return this.subordinates.Count;
            }
        }

        //constructor
        public Employee(string employeeName)
        {
            this.Name = employeeName;
            this.subordinates = new List<Employee>();
        }

        //methods
        public void AddSubordinate(Employee employee)
        {
            subordinates.Add(employee);
            employee.Parent = Name;
        }

        public Employee GetSuperior(Employee input)
        {
            Employee employee = new Employee(input.Parent);
            return employee;
        }
    }
}
