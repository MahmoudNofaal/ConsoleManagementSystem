# ConsoleEmployeeManager
## 🧑‍💼 Employee Management System

A console-based Employee Management System built with C#.

## Features 🚀

- **🔒 Secure Login**: Managers must authenticate using a username and password.
- **👥 Employee Management**: Add, edit, search, and remove employees.
- **💾 Data Persistence**: Employee data is saved to and loaded from a text file.
- **🖨️ Formatted Output**: Console output is neatly formatted for better readability.

## Getting Started 🌟

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.

### Running the Application 🏃‍♂️

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/EmployeeManagementSystem.git
    ```

2. Navigate to the project directory:
    ```sh
    cd EmployeeManagementSystem
    ```

3. Run the application:
    ```sh
    dotnet run
    ```

### Project Structure 🏗️

- **Users.cs**: Defines the `Users` class.
- **Manager.cs**: Handles manager authentication.
- **DataManager.cs**: Handles data persistence.
- **EmployeeManager.cs**: Manages employee records.
- **UserInterface.cs**: Provides the console-based user interface.
- **Program.cs**: Entry point of the application.

## Usage 📋

### Main Menu

- Show All Employees
- Add Employee
- Edit Employee
- Search An Employee
- Remove Employee
- Exit

### Employee Operations

1. **Show All Employees**: Displays a list of all employees with options for different views.
2. **Add Employee**: Prompts the manager to enter employee details and adds the employee to the system.
3. **Edit Employee**: Allows the manager to select and edit an existing employee's details.
4. **Search An Employee**: Searches for an employee by ID and displays their details.
5. **Remove Employee**: Allows the manager to select and remove an employee from the system.

## Data Persistence 💾

Employee data is saved to `employeesData.txt` in the project directory. The file is loaded at startup to populate the employee list.

## Contributing 🤝

Contributions are welcome! Please open an issue or submit a pull request for any changes or enhancements.

## Contact 📫

For any questions or suggestions, please contact [Mahmoud](mailto:ma7nemahmoud73@gmail.com).

