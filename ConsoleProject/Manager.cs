using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject;

public class Manager
{
  private const string _username = "nofaal";
  private const string _password = "12345";

  // Check Login [username - password]
  public void CheckLogin()
  {
    ConsoleColor originalColor = Console.ForegroundColor;

    // Loop to handle incorrect password attempts
    while (true)
    {
      Console.Clear();

      // Display the header in green
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      string str = "WELCOME TO EMPLOYEES MANAGEMENT SYSTEM";
      Console.WriteLine("╔════════════════════════════════════╗");
      Console.WriteLine("║                                    ║");
      Console.WriteLine($"{ThreadFunc(str, 60)}");
      Console.WriteLine("║                                    ║");
      Console.WriteLine("╚════════════════════════════════════╝");
      Console.WriteLine();

      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine("║  Sign In  ║");
      Console.WriteLine();

      Console.ForegroundColor = originalColor;


      Console.Write("\nPlease Enter Your Username: ");
      string usernameInput = Console.ReadLine();

      Console.Write("\nPlease Enter Your Password: ");
      string passwordInput = Console.ReadLine();


      // Validate the credentials
      if (usernameInput != _username || passwordInput != _password)
      {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Thread.Sleep(450); // Update every second
        OutputMessage("\nWronge Passwords");
        Console.ForegroundColor = originalColor;
        Console.WriteLine(); // Add a blank line for spacing
      }
      else
      {
        ThreadFunc(">>>", 300);
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nAccess Granted..!");
        Console.ForegroundColor = originalColor;

        Thread.Sleep(300); // Update every second

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(".. Press <Enter> To Go To The Home Page .. ");
        Console.ForegroundColor = originalColor;
        Console.ReadLine();
        break; // Exit the loop if credentials are correct
      }
    }

  }

  // func to take msg and make operation after print this msg
  public void OutputMessage(string str)
  {
    if (string.IsNullOrEmpty(str))
    {
      Console.WriteLine("Press any button to return to the menu.");
    }
    else
    {
      Console.WriteLine($"{str} Press <Enter> to try again.");
    }

    Console.ReadLine();
    Console.Clear();
  }

  private string ThreadFunc(string str, int time)
  {
    for (int i = 0; i < str.Length; i++)
    {
      Console.Write($"{str[i]}");
      Thread.Sleep(time);
    }
    return "";
  }
}