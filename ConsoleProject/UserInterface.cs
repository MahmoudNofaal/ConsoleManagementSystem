using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject;

public class UserInterface
{
  ConsoleColor originalColor = Console.ForegroundColor;


  private Manager manager;
  private EmployeeManager employeeManager;
  private DataManager dataManager;

  // Constructor to call other classes functions
  public UserInterface()
  {
    manager = new Manager();
    employeeManager = new EmployeeManager();
    dataManager = new DataManager();

    manager.CheckLogin();
    LoadData();
    PrintMenuOptions();
  }

  // printing menu options to select from
  public void PrintMenuOptions()
  {
    Console.Clear();

    ConsoleColor originalColor = Console.ForegroundColor;

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("╔═════════════════════════════════════════════════════╗");
    Console.WriteLine("║                                                     ║");
    Console.WriteLine("║             EMPLOYEES MANAGEMENT SYSTEM             ║");
    Console.WriteLine("║                                                     ║");
    Console.WriteLine("╚═════════════════════════════════════════════════════╝");

    Console.WriteLine("_______________________________________________________");
    Console.WriteLine("Hello Manager, Welcome To Management System\n");
    Console.ForegroundColor = originalColor;

    // array of options
    string[] menuOptions =
    {
      "Show All Employees",
      "Add Employee",
      "Edit Employee",
      "Search An Employee",
      "Remove Employee",
      "Exit"
    };

    // printing all options to the user
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("║ Menu Options ║");
    Console.WriteLine("----------------");
    for (int i = 0; i < menuOptions.Length; i++)
    {
      Console.WriteLine($"{i + 1}. {menuOptions[i]}");
    }
    Console.ForegroundColor = originalColor;
    Console.WriteLine();

    // take user selected option
    Console.Write("Please Enter Your Menu Option: ");
    bool tryParse = int.TryParse(Console.ReadLine(), out int menuOption);

    // validate the selected option
    if (tryParse && menuOption >= 1 && menuOption <= menuOptions.Length)
    {
      // cases for options
      switch (menuOption)
      {
        case 1:
          ShowAllEmployees();
          break;
        case 2:
          AddEmployee();
          break;
        case 3:
          EditEmployee();
          break;
        case 4:
          SearchAnEmployee();
          break;
        case 5:
          RemoveEmployee();
          break;
        case 6:
          return;
      }

    } // endOf if [validation]
    else
    {
      OutputMessage("Incorrect Menu Choice!");
    }

    PrintMenuOptions();
  } //endOf func PrintMenuOptions()

  /// <summary>
  /// Implement Menu Options
  /// </summary>

  // showing all employees
  private void ShowAllEmployees()
  {
    StartOption("Showing all employees");

    string[] options =
    {
      "Show Id - Name",
      "Show Name - Position - Salary",
      "Show Id - Name - Email",
      "Show All Employee Data"
    };


    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("Select One Option: ");
    Console.ForegroundColor = ConsoleColor.White;
    for (int i = 0; i < options.Length; i++)
    {
      Console.WriteLine($" |_ {i + 1}. {options[i]}");
    }
    Console.ForegroundColor = originalColor;
    Console.WriteLine();

    Console.Write("Enter Show-Employee Option: ");
    var indexSelection = Convert.ToInt32(Console.ReadLine());

    if (indexSelection >= 1 && indexSelection <= 4)
    {

      if (indexSelection == 1)
      {
        // Show ID and Name
        employeeManager.ShowAllEmployees(emp => emp.FormatIdName());
      }
      else if (indexSelection == 2)
      {
        // Show Name, Position, and Salary
        employeeManager.ShowAllEmployees(emp => emp.FormatNamePositionSalary());
      }
      else if (indexSelection == 3)
      {
        // Show ID, Name, and Email
        employeeManager.ShowAllEmployees(emp => emp.FormatIdNameEmail());
      }
      else
      {
        employeeManager.ShowAllEmployees();
      }
      FinishOption();
    }
    else
    {
      OutputMessage("Invalid index selection");
      //Console.WriteLine("Invalid index selection");
      ShowAllEmployees();
    }
  }

  // adding new employee to the system
  private void AddEmployee()
  {
    StartOption("Adding an employee");

    Console.WriteLine("════════════════════════════════════════════════════════════");
    Console.WriteLine("Emp: [Id] - [Name] - [Age] - [Position] - [Salary] - [Email]\n");

    try
    {
      Employees user = GetUser();
      if (user != null)
      {
        employeeManager.AddEmployee(user);

        Console.ForegroundColor = ConsoleColor.Green;
        dataManager.SaveData(employeeManager.GetAllEmployees());
        Console.WriteLine("Successfully added employee.");

        Console.ForegroundColor = originalColor;
        FinishOption();
      }
      else
      {
        OutputMessage("Invalid input. Employee not added.");
      }
    }
    catch (Exception ex)
    {
      OutputMessage($"Something went wrong: {ex.Message}");
    }
  }

  // editting an employee in the system
  private void EditEmployee()
  {
    StartOption("Editing an employee");
    if (!IsSystemEmpty())
    {
      employeeManager.PrintEmployeeNameAndId();
      int indexSelection = GetValidIntInput("Enter index selection: ", 1, employeeManager.GetAllEmployees().Count) - 1;

      // Confirmation prompt
      if (ConfirmAction("Are you sure you want to edit this employee? (y/n): "))
      {
        Console.WriteLine("\n... Editing The User ...");
        Employees user = GetUser();
        if (user != null)
        {
          employeeManager.EditEmployee(indexSelection, user);

          Console.ForegroundColor = ConsoleColor.Green;
          dataManager.SaveData(employeeManager.GetAllEmployees());
          Console.WriteLine("Successfully edited employee.");
          Console.ForegroundColor = originalColor;

          FinishOption();
        }
        else
        {
          OutputMessage("Invalid input. Employee not edited.");
        }
      }
      else
      {
        OutputMessage("Editing canceled.");
      }
    }
    else
    {
      OutputMessage("");
    }

  }

  // searching an employee in the system
  private void SearchAnEmployee()
  {
    StartOption("Searching for an employee by ID");
    Console.WriteLine("═════════════════════════════");


    int id = GetValidIntInput("Enter employee ID: ", 1, int.MaxValue);
    Employees employee = employeeManager.SearchEmployeeById(id);

    Console.WriteLine("------------------------------\n");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Employee:");
    Console.ForegroundColor = originalColor;
    if (employee != null)
    {
      Console.WriteLine(employee);
    }
    else
    {
      Console.WriteLine("No employee found with the given ID.");
    }
    FinishOption();

  }

  // removing an employee from the system
  private void RemoveEmployee()
  {
    StartOption("Removing an employee");
    if (!IsSystemEmpty())
    {
      employeeManager.PrintEmployeeNameAndId();
      int index = GetValidIntInput("Enter an index: ", 1, employeeManager.GetAllEmployees().Count) - 1;

      // Confirmation prompt
      if (ConfirmAction("Are you sure you want to remove this employee? (y/n): "))
      {
        employeeManager.RemoveEmployee(index);
        dataManager.SaveData(employeeManager.GetAllEmployees());
        Console.WriteLine("Successfully removed the employee.");
        FinishOption();
      }
      else
      {
        OutputMessage("Removal canceled.");
      }
    }
    else
    {
      OutputMessage("");
    }
  }
  //--------------------------------------------------------



  // function to help [AddEmployee, EditEmployee]
  private Employees GetUser()
  {
    int idInput;
    bool isUnique;
    do
    {
      idInput = GetValidIntInput(" |_ Enter user id: ", 1, 1000000);
      isUnique = employeeManager.IsUniqueID(idInput);

      if (!isUnique)
      {
        Console.WriteLine("ID is already in use. Please enter a unique ID.");
      }
    } while (!isUnique);

    string nameInput = GetValidatedStringInput(" |_ Enter user name: ");
    int ageInput = GetValidIntInput(" |_ Enter user age: ", 18, 55);
    string positionInput = GetValidatedStringInput(" |_ Enter user position: ");
    decimal salaryInput = GetValidDecimalInput(" |_ Enter user salary: ", 6000, 40000);
    string emailInput = GetValidatedStringInput(" |_ Enter user email [name@fake.com]: ");

    Console.WriteLine();

    if (IsValidEmail(emailInput))
    {
      return new Employees(idInput, nameInput, ageInput, positionInput, salaryInput, emailInput);
    }
    else
    {
      Console.WriteLine("Invalid email format.");
      return null;
    }
  }
  private string GetValidatedStringInput(string prompt)
  {
    string input;
    do
    {
      Console.Write(prompt);
      input = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(input))
      {
        Console.WriteLine("Input cannot be empty. Please try again.");
      }
    } while (string.IsNullOrWhiteSpace(input));

    return input;
  }
  private int GetValidIntInput(string prompt, int minValue, int maxValue)
  {
    int result;
    Console.Write(prompt);
    while (!int.TryParse(Console.ReadLine(), out result) || result < minValue || result > maxValue)
    {
      Console.WriteLine($"Invalid input. Please enter a number between {minValue} and {maxValue}.");
      Console.Write(prompt);
    }
    return result;
  }
  private decimal GetValidDecimalInput(string prompt, decimal minValue, decimal maxValue)
  {
    decimal result;
    Console.Write(prompt);
    while (!decimal.TryParse(Console.ReadLine(), out result) || result < minValue || result > maxValue)
    {
      Console.WriteLine($"Invalid input. Please enter a number between {minValue} and {maxValue}.");
      Console.Write(prompt);
    }
    return result;
  }
  private bool IsValidEmail(string email)
  {
    try
    {
      var addr = new MailAddress(email);
      return true;
    }
    catch
    {
      return false;
    }
  }



  // Operation to done when an menu option start
  private void StartOption(string msg)
  {
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.Write($"{msg}");
    ThreadFunc("...", 80);

    Console.ForegroundColor = originalColor;
  }
  // Operation to done when an menu option end
  private void FinishOption()
  {
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write($"{Environment.NewLine}You Have Finished This Option. Press <Enter> to Return to The Menu.");
    Console.ForegroundColor = originalColor;
    Console.ReadLine();
    Console.Clear();
  }


  // check if the system does not have any employees
  private bool IsSystemEmpty()
  {
    if (employeeManager.GetAllEmployees().Count == 0)
    {
      Console.ForegroundColor = ConsoleColor.DarkGray;
      Console.WriteLine("There are no employees in the system!!");
      Console.ForegroundColor = originalColor;
      return true;
    }
    return false;
  }



  // print a message and then do some operations
  private void OutputMessage(string str)
  {

    Console.ForegroundColor = ConsoleColor.DarkRed;
    if (string.IsNullOrEmpty(str))
    {
      Console.WriteLine("\n... Press any button to return to the menu ...");
    }
    else
    {
      Console.WriteLine($"\n... {str} Press <Enter> to try again ...");
    }
    Console.ForegroundColor = originalColor;

    Console.ReadLine();
    Console.Clear();
  }


  // load data every executions for the program
  private void LoadData()
  {
    var employees = dataManager.LoadData();
    foreach (var emp in employees)
    {
      employeeManager.AddEmployee(emp);
    }
  }


  // some operation to check
  private bool ConfirmAction(string message)
  {
    Console.Write(message);
    string input = Console.ReadLine().ToLower();
    return input == "y" || input == "yes";
  }
  // some operation to print sugar console to user
  private void ThreadFunc(string str, int time)
  {
    for (int i = 0; i < str.Length; i++)
    {
      Console.Write($"{str[i]}");
      Thread.Sleep(time);
    }
    Console.WriteLine("\n");
  }

}
