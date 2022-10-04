using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker
{
    class PeopleFetcher
    {
        // Moved from Program.cs
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            while (true)
            {
                // Move the initial prompt inside the loop, so it repeats for each employee
                Console.WriteLine("Please first name: (leave empty to exit): ");

                // Change input to firstName
                string firstName = Console.ReadLine() ?? "";

               if (firstName == "")
                {
                    // Eventually prompt a y/n permission to write .csv file
                    break;       
                }

                // Add a console.ReadLine() for each value
                Console.WriteLine("Enter last name: ");
                string lastName = Console.ReadLine() ?? "";
                Console.Write("Enter ID: ");
                int id = Int32.Parse(Console.ReadLine() ?? "");
                Console.Write("Enter Photo URL: ");
                string photoUrl = Console.ReadLine() ?? "";

                // Create a new Employee instance
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                // Add currentEmployee not a string  
                employees.Add(currentEmployee);
            }
            // Update the metod return type

            return employees;
            
        }

        async public static Task<List<Employee>> GetFromApi()
        {
            List<Employee> employees = new List<Employee>();
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                JObject json = JObject.Parse(response);
                // Console.WriteLine(json.SelectToken("results[0].name.first"));
                Console.WriteLine(response);
                foreach (JToken token in json.SelectToken("results")) 
                {
                    // Parse JSON data
                    Employee emp = new Employee
                    (
                        token.SelectToken("name.first").ToString(),
                        token.SelectToken("name.last").ToString(),
                        Int32.Parse(token.SelectToken("id.value").ToString().Replace("-", "")),
                        token.SelectToken("picture.large").ToString()
                        );
                    employees.Add(emp);
                }
            return employees;
         }
    }
}
}