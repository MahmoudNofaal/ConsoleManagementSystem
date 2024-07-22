/*
 Author: Nofaal

look like spider
 */

namespace ConsoleProject;

internal class Program
{
  static void Main(string[] args)
  {
    UserInterface ui = new UserInterface();

    ConsoleColor originalColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("... Good Bye ...");
    Console.ForegroundColor = originalColor;

  }
}
