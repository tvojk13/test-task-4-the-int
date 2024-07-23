using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_task_4_the_int
{
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal SalaryPerHour { get; set; }

        public static void AddEmployee(Dictionary<string, string> parameters)
        {
            Employee employee = new Employee();
            employee.Id = Tools.GetNextId();
            employee.FirstName = parameters["FirstName"];
            employee.LastName = parameters["LastName"];
            employee.SalaryPerHour = decimal.Parse(parameters["SalaryPerHour"]);

            List<Employee> employees = JsonUtils.ReadAllEmployees();
            employees.Add(employee);
            JsonUtils.WriteAllEmployees(employees);
        }

        public static void UpdateEmployee(Dictionary<string, string> parameters)
        {
            int id = int.Parse(parameters["Id"]);
            List<Employee> employees = JsonUtils.ReadAllEmployees();

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == id)
                {
                    foreach (KeyValuePair<string, string> prm in parameters)
                    {
                        switch (prm.Key)
                        {
                            case "FirstName":
                                {
                                    employees[i].FirstName = prm.Value;
                                }
                                break;
                            case "LastName":
                                {
                                    employees[i].LastName = prm.Value;
                                }
                                break;
                            case "SalaryPerHour":
                                {
                                    employees[i].SalaryPerHour = Decimal.Parse(prm.Value);
                                }
                                break;
                        }
                    }

                    JsonUtils.WriteAllEmployees(employees);
                    return;
                }
                else
                {
                    Console.WriteLine($"ERROR: Employee with Id {id} not found.\n");
                    return;
                }
            }
        }

        public static void GetEmployeeById(Dictionary<string, string> parameters)
        {
            int id = int.Parse(parameters["Id"]);
            List<Employee> employees = JsonUtils.ReadAllEmployees();

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == id)
                {
                    Console.WriteLine($"Id = {employees[i].Id}, FirstName = {employees[i].FirstName}," +
                        $" LastName = {employees[i].LastName}, SalaryPerHour = {employees[i].SalaryPerHour}\n");
                    return;
                }
            }

            Console.WriteLine($"ERROR: Employee with Id {id} not found.\n");
            return;
        }

        public static void DeleteEmployeeById(Dictionary<string, string> parameters)
        {
            int id = int.Parse(parameters["Id"]);
            List<Employee> employees = JsonUtils.ReadAllEmployees();

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == id)
                {
                    Console.WriteLine($"INFO: The employee with Id {id} will be deleted.\n Are you sure you want to proceed? (y/n): ");
                    string answer = Console.ReadLine().ToLower();
                    if (answer != "y")
                    {
                        Console.WriteLine("INFO: Operation cancelled.\n");
                        return;
                    }

                    employees.RemoveAt(i);
                    JsonUtils.WriteAllEmployees(employees);
                    Console.WriteLine($"INFO: The employee with Id {id} has been successfully deleted.\n");
                    return;
                }
            }

            Console.WriteLine($"ERROR: Employee with Id {id} not found.\n");
            return;
        }

        public static void GetAllEmployees()
        {
            List<Employee> employees = JsonUtils.ReadAllEmployees();

            foreach (Employee employee in employees)
            {
                Console.WriteLine($"Id = {employee.Id}, FirstName = {employee.FirstName}," +
                        $" LastName = {employee.LastName}, SalaryPerHour = {employee.SalaryPerHour}\n");
            }
        }
    }
}
