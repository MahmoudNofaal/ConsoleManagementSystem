using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject;

public class EmployeeManager
{
  private List<Employees> employees = new List<Employees>();
  public delegate string EmployeeFormatDelegate(Employees user);

  public void ShowAllEmployees()
  {
    ConsoleColor originalColor = Console.ForegroundColor;

    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("╔═════════════════════════╗");
    Console.WriteLine("║ Employees in The System ║");
    Console.WriteLine("╚═════════════════════════╝");

    // sort the employee by id by default
    var sortedEmployees = GetAllEmployees().OrderBy(e => e.Id).ToList();

    for (int i = 0; i < sortedEmployees.Count; i++)
    {
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      Console.WriteLine($"  ╔═ Employee {i + 1}:");
      Console.ForegroundColor = originalColor;

      Console.WriteLine(sortedEmployees[i]);
    }
  }

  // override ShowAllEmployees to format the show
  public void ShowAllEmployees(EmployeeFormatDelegate formatMethod)
  {
    ConsoleColor originalColor = Console.ForegroundColor;

    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("╔═════════════════════════╗");
    Console.WriteLine("║ Employees in The System ║");
    Console.WriteLine("╚═════════════════════════╝");

    var sortedEmployees = GetAllEmployees().OrderBy(e => e.Id).ToList();

    for (int i = 0; i < sortedEmployees.Count; i++)
    {
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      Console.WriteLine($"  ╔═ Employee {i + 1}:");
      Console.ForegroundColor = originalColor;

      Console.WriteLine(formatMethod(sortedEmployees[i]));
    }
  }


  // some operation on employees list
  public void PrintEmployeeNameAndId()
  {
    ConsoleColor originalColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("╔════════════════════╗");
    Console.WriteLine("║ Current Employees: ║");
    Console.WriteLine("╚════════════════════╝");
    Console.WriteLine("----------------------");
    Console.ForegroundColor = originalColor;
    for (int i = 0; i < employees.Count; i++)
    {
      Console.WriteLine($" {i + 1}. {employees[i].Id} - {employees[i].Name}");
    }
    Console.WriteLine();
  }
  public void AddEmployee(Employees user)
  {
    employees.Add(user);
  }
  public void EditEmployee(int index, Employees user)
  {
    if (index >= 0 && index < employees.Count)
    {
      employees[index] = user;
    }
  }
  public void RemoveEmployee(int index)
  {
    if (index >= 0 && index < employees.Count)
    {
      employees.RemoveAt(index);
    }
  }
  public List<Employees> SearchEmployee(string name)
  {
    return employees.FindAll(emp => emp.Name.ToLower().Contains(name.ToLower()));
  }
  public List<Employees> GetAllEmployees()
  {
    return employees;
  }
  public bool IsUniqueID(int id)
  {
    return !employees.Any(e => e.Id == id);
  }
  public Employees SearchEmployeeById(int id)
  {
    return employees.FirstOrDefault(emp => emp.Id == id);
  }

}
