using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_task_4_the_int
{
    public class JsonUtils
    {
        /// <summary>
        /// Reads all employees from the "employees.json" file and returns them as a list.
        /// </summary>
        /// <returns></returns>
        public static List<Employee> ReadAllEmployees()
        {
            if (File.Exists("employees.json"))
            {
                string json = File.ReadAllText("employees.json");
                return JsonConvert.DeserializeObject<List<Employee>>(json);
            }

            return new List<Employee>();
        }

        /// <summary>
        /// Writes a list of employees to the "employees.json" file.
        /// </summary>
        /// <param name="employees"></param>
        public static void WriteAllEmployees(List<Employee> employees)
        {
            File.WriteAllText("employees.json", JsonConvert.SerializeObject(employees));
        }
    }
}
