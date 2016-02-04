namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;

    public class SuperiorOfTwoSubordinates
    {
        static Dictionary<string, Employee> allEmployees = new Dictionary<string, Employee>();
        static List<string> allSuperiorsOfEmployee = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Find superior of given two subordinates in company hierachy\n");
            Console.WriteLine("Please enter number of relation pairs Superior-Subordinate:");
            string numberAsString = Console.ReadLine();
            int number;

            if (int.TryParse(numberAsString, out number))
            {
                Console.WriteLine("\nEnter on single line relations (Superior-Subordinate):");
                for (int i = 0; i < number; i++)
                {
                    string relation = Console.ReadLine();
                    string[] separatedRelation = relation.Split(new char[] { '-' },
                        StringSplitOptions.RemoveEmptyEntries);

                    string superiorName = separatedRelation[0];
                    string subordinateName = separatedRelation[1];

                    Employee superior; //parentNode
                    Employee subordinate; //childNode

                    if (allEmployees.ContainsKey(superiorName))
                    {
                        superior = allEmployees[superiorName];
                    }
                    else
                    {
                        superior = new Employee(superiorName);
                        allEmployees.Add(superiorName, superior);
                    }

                    if (allEmployees.ContainsKey(subordinateName))
                    {
                        subordinate = allEmployees[subordinateName];
                    }
                    else
                    {
                        subordinate = new Employee(subordinateName);
                        allEmployees.Add(subordinateName, subordinate);
                    }

                    //make the connection between them. Add child to parent
                    superior.AddSubordinate(subordinate);

                    if (superior.NumberOfSubordinates > 2)
                    {
                        throw new ArgumentException(superior.Name, "Superior does not allow to have more than 2 subordinates!");
                    }
                }

                Console.WriteLine("\nEnter two employees on separete lines to find their most direct superior:");
                string firstEmployeeName = Console.ReadLine();
                string secondEmployeeName = Console.ReadLine();

                Employee firstEmployee = allEmployees[firstEmployeeName];
                allSuperiorsOfEmployee.Add(firstEmployee.Name);
                List<string> superiorsOfFirstEmployee = ReturnSuperiors(firstEmployee);
                allSuperiorsOfEmployee = new List<string>();

                Employee secondEmployee = allEmployees[secondEmployeeName];
                allSuperiorsOfEmployee.Add(secondEmployee.Name);
                List<string> superiorsOfSecondEmployee = ReturnSuperiors(secondEmployee);
                allSuperiorsOfEmployee = new List<string>();

                Console.WriteLine("\nThe most direct superior is:");
                foreach (string superior in superiorsOfSecondEmployee)
                {
                    if (superiorsOfFirstEmployee.Contains(superior))
                    {
                        Console.WriteLine(superior);
                        break;
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Please enter correct input as number!");
            }
        }

        public static List<string> ReturnSuperiors(Employee employee)
        {
            if (allEmployees[employee.Name].Parent == null )
            {
                return allSuperiorsOfEmployee;
            }
            else
            {
                string employeeName = employee.GetSuperior(employee).Name;
                allSuperiorsOfEmployee.Add(employeeName);
                employee = allEmployees[employeeName];
                ReturnSuperiors(employee); 
            }
            return allSuperiorsOfEmployee;
        }
    }
}
