using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace ConsoleProject;

public class DataManager
{
  private const string DataFilePath = "employeesData.txt";

  // Method to save employee data to a text file
  public void SaveData(List<Employees> employees)
  {
    try
    {
      using (StreamWriter writer = new StreamWriter(DataFilePath))
      {
        foreach (var employee in employees)
        {
          // Write each employee's data as a line in the text file
          writer.WriteLine($"{employee.Id}|{employee.Name}|{employee.Age}|{employee.Position}|{employee.Salary}|{employee.Email}");
        }
      }

      Console.WriteLine("\nData saved successfully.");
    } //endOf Try
    catch (Exception ex)
    {
      Console.WriteLine($"Error saving data: {ex.Message}");
    }
  } //endOf SaveData()

  // Method to load employee data from a text file
  public List<Employees> LoadData()
  {
    var employees = new List<Employees>();

    try
    {
      if (File.Exists(DataFilePath))
      {
        using (StreamReader reader = new StreamReader(DataFilePath))
        {
          string line;

          while ((line = reader.ReadLine()) != null)
          {
            // Split the line into individual data fields
            var fields = line.Split('|');

            if (fields.Length == 6)
            {
              // Create a new Users object and add it to the list
              if (
                  int.TryParse(fields[0], out int id) &&
                  int.TryParse(fields[2], out int age) &&
                  decimal.TryParse(fields[4], out decimal salary)
                 ) // conditions
              {
                var user = new Employees(id, fields[1], age, fields[3], salary, fields[5]);
                employees.Add(user);
              }// endOf if
            }
          } // endOf While Loop
        }//endOf using

        Console.WriteLine("Data loaded successfully.");
      } // if file is exist
      else
      {
        Console.WriteLine("No data file found, starting with an empty list.");
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error loading data: {ex.Message}");
    }

    return employees;
  }

}
