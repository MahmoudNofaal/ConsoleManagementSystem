using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject;

public class Employees
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int Age { get; set; }
  public string Position { get; set; }
  public decimal Salary { get; set; }
  public string Email { get; set; }

  public Employees(int id, string fullName, int age, string position, decimal salary, string email)
  {
    Id = id;
    Name = fullName;
    Age = age;
    Position = position;
    Salary = salary;
    Email = email;
  }

  // Print [Id - Name]
  public string FormatIdName()
  {
    return $"  ║  |__ Id       : {Id}\n" +
           $"  ║  |__ Full-Name: {Name}\n" +
           $"  ║";
  }

  // Print [Name - Position - Salary]
  public string FormatNamePositionSalary()
  {
    return
           $"  ║  |__ Full-Name: {Name}\n" +
           $"  ║  |__ Position : {Position}\n" +
           $"  ║  |__ Salary   : {Salary}\n" +  // Display salary with currency format
           $"  ║";
  }

  // Print [Id - Name - Email]
  public string FormatIdNameEmail()
  {
    return $"  ║  |__ Id       : {Id}\n" +
           $"  ║  |__ Full-Name: {Name}\n" +
           $"  ║  |__ Email    : {Email}\n" +
           $"  ║";
  }

  // override ToString() to print users
  public override string ToString()
  {
    return $"  ║  |__ Id       : {Id}\n" +
           $"  ║  |__ Full-Name: {Name}\n" +
           $"  ║  |__ Age      : {Age}\n" +
           $"  ║  |__ Position : {Position}\n" +
           $"  ║  |__ Salary   : {Salary:C}\n" +  // Display salary with currency format
           $"  ║  |__ Email    : {Email}\n" +
           $"  ║";
  }

}
