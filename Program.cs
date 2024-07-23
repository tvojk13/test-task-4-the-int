using System;
using System.IO;
using Newtonsoft.Json;
using test_task_4_the_int;

class Program
{
    private static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("ERROR: No command has been entered.\n");
            return;
        }

        string enteredCommand = args[0];
        string[] enteredParameters = new string[args.Length - 1];
        Dictionary<string, string> prms;

        switch (enteredCommand)
        {
            case "-add":
                string[] addOptions = { "FirstName", "LastName", "SalaryPerHour" };

                if (enteredParameters.Length != addOptions.Length)
                {
                    Console.WriteLine("ERROR: Invalid options.\n");
                    return;
                }

                prms = Tools.ProcessParameters(args, enteredParameters, addOptions);
                Employee.AddEmployee(prms);
                break;

            case "-update":
                string[] updateOptions = { "Id", "FirstName", "LastName", "SalaryPerHour" };

                if (enteredParameters.Length < 1 || enteredParameters.Length > updateOptions.Length)
                {
                    Console.WriteLine("ERROR: Invalid options.\n");
                    return;
                }

                prms = Tools.ProcessParameters(args, enteredParameters, updateOptions);
                Employee.UpdateEmployee(prms);
                break;
            case "-get":

                string[] getOptions = { "Id" };

                if (enteredParameters.Length < 1 || enteredParameters.Length > getOptions.Length)
                {
                    Console.WriteLine("ERROR: Invalid options.\n");
                    return;
                }

                prms = Tools.ProcessParameters(args, enteredParameters, getOptions);
                Employee.GetEmployeeById(prms);
                break;
            case "-delete":

                string[] deleteOptions = { "Id" };

                if (enteredParameters.Length < 1 || enteredParameters.Length > deleteOptions.Length)
                {
                    Console.WriteLine("ERROR: Invalid options.\n");
                    return;
                }

                prms = Tools.ProcessParameters(args, enteredParameters, deleteOptions);
                Employee.DeleteEmployeeById(prms);
                break;
            case "-getall":

                if (enteredParameters.Length != 0)
                {
                    Console.WriteLine("ERROR: Invalid options.\n");
                    return;
                }

                Employee.GetAllEmployees();
                break;

            default:
                Console.WriteLine("ERROR: Invalid command.\n");
                break;
        }

    }
}
