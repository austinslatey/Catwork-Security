// Import correct packages
using System;
using System.IO;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    // Static Util class method
    class Util
    {
        // Add List parameter to method
        public static void PrintEmployees(List<Employee> employees)
        {
           for (int i = 0; i < employees.Count; i++)
           {
            string template = "{0,-10}\t{1,-20}\t{2}";
            Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
           } 
        }

        // Static method that will create the csv file
        public static void MakeCSV(List<Employee> employees)
        {
        // Check to see if a data folder exists !exists => create a for-loop over all given employees
        if (!Directory.Exists("data"))
        {
            Directory.CreateDirectory("data");
        }
        // Write employees info as a string seperated by commas
        using (StreamWriter file = new StreamWriter("data/employees.csv"))
        {
            // Any code that needs StreamWriter goes here
            file.WriteLine("ID,Name,PhotoUrl");

            // Loop over employees
            for (int i = 0; i < employees.Count; i++)
            {
                // Write each employee to .csv file
                string template = "{0}{1}{2}";
                file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
            }
        }
        }
        

    }
}