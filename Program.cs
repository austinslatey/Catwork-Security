using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CatWorx.BadgeMaker
{
    class Program
{

  static void PrintEmployees(List<Employee> employees)
  {
    for (int i = 0; i < employees.Count; i++)
    {
      // each item in employees is an Employee instance
      string template = "{0,-10}\t{1,-20}\t{2}";
      Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
    }
  }

  async static Task Main(string[] args)
  { 
    List<Employee> employees;
    Console.WriteLine("Wecome fellow Catworx Employee!\nWould you like to auto-generate 10 employees?\nY\nor\nN?\n Anykey other than y will run CLI");
    string answer = Console.ReadLine();
    if (answer == "y" || answer == "Y")
    {
      employees = await PeopleFetcher.GetFromApi();
    }
    else {
      employees = PeopleFetcher.GetEmployees();
    }
    
    // Print Employees to console
    Util.PrintEmployees(employees);
    // Print to .csv file
    Util.MakeCSV(employees);
    // Create Employee badge
    await Util.MakeBadges(employees);
    

  }
}
}
