using System;
using System.IO;
using System.Collections.Generic;


namespace CatWorx.BadgeMaker
{
    class Program
{
  static List<Employee> GetEmployees()
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
        // Ask permission to write to .csv file
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

  static void PrintEmployees(List<Employee> employees)
  {
    for (int i = 0; i < employees.Count; i++)
    {
      // each item in employees is an Employee instance
      string template = "{0,-10}\t{1,-20}\t{2}";
      Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
    }
  }

  static void Main(string[] args)
  {
    List<Employee> employees = GetEmployees();
    Util.PrintEmployees(employees);
    // Print to .csv file
    Util.MakeCSV(employees);
  }
}
}
