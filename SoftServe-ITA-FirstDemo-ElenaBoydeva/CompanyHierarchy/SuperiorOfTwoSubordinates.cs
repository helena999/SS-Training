namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

                    Employee superior;
                    Employee subordinate;

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

                    superior.AddSubordinate(subordinate);
                }

                Console.WriteLine("\nEnter two employees on separete lines to find their most direct superior:");
                Console.Write("First Employee: ");
                string firstEmployeeName = Console.ReadLine();

                //Check if first given employee is in the company hierarchy
                bool isFirstIn = allEmployees.Keys.Where(x => x == firstEmployeeName).Any();
                if (!isFirstIn)
                {
                    Console.WriteLine("Please enter first employee that is in our company hiearchy");
                    Console.Write("First Employee: ");
                    firstEmployeeName = Console.ReadLine();
                }

                Console.Write("Second Employee: ");
                string secondEmployeeName = Console.ReadLine();

                //Check if second given employee is in company hierarchy
                bool isSecondIn = allEmployees.Keys.Where(x => x == secondEmployeeName).Any();
                if (!isSecondIn)
                {

                    Console.WriteLine("Please enter second employee that is in our company hierarchy");
                    Console.Write("Second Employee: ");
                    secondEmployeeName = Console.ReadLine();
                }

                Employee firstEmployee = allEmployees[firstEmployeeName];
                allSuperiorsOfEmployee.Add(firstEmployee.Name);
                List<string> superiorsOfFirstEmployee = ReturnSuperiors(firstEmployee);

                allSuperiorsOfEmployee = new List<string>();

                Employee secondEmployee = allEmployees[secondEmployeeName];
                allSuperiorsOfEmployee.Add(secondEmployee.Name);
                List<string> superiorsOfSecondEmployee = ReturnSuperiors(secondEmployee);

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
                Console.WriteLine("Please enter a valid number!");
            }          
        }

        public static List<string> ReturnSuperiors(Employee employee)
        {
            if (allEmployees[employee.Name].Superior == null )
            {
                return allSuperiorsOfEmployee;
            }
            else
            {
                string superiorName = employee.GetSuperior(employee);
                allSuperiorsOfEmployee.Add(superiorName);
                employee = allEmployees[superiorName];
                ReturnSuperiors(employee); 
            }
            return allSuperiorsOfEmployee;
        }
    }
}
