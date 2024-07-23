using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_task_4_the_int
{
    static class Tools
    {
        public static int GetNextId()
        {
            if (!File.Exists("employees.json"))
            {
                return 1;
            }

            string json = File.ReadAllText("employees.json");
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(json);

            return employees.Count > 0 ? employees.Max(e => e.Id) + 1 : 1;
        }

        public static Dictionary<string, string> ProcessParameters(string[] args, string[] parameters, string[] options)
        {
            for (int i = 1; i < args.Length; i++)
            {
                string param = args[i];
                int equalsIndex = param.IndexOf(":");

                if (equalsIndex != -1)
                {
                    string paramName = param.Substring(0, equalsIndex);

                    // Check if paramName is present in the options array before processing further
                    if (!options.Contains(paramName))
                    {
                        Console.WriteLine("ERROR: Invalid option '{0}'", paramName);
                        break;
                    }

                    string paramValue = param.Substring(equalsIndex + 1);
                    parameters[i - 1] = $"{paramName}:{paramValue}";
                }
                else
                {
                    // Ignore parameters without values
                    continue;
                }
            }

            // Process the parameters array
            Dictionary<string, string> processedPrms = new Dictionary<string, string>();

            foreach (string param in parameters)
            {
                string[] parts = param.Split(':');
                string name = parts[0];
                string value = parts[1];

                processedPrms.Add(name, value);
            }

            return processedPrms;
        }
    }
}
