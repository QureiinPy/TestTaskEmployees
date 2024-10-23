using WorkConsole.Model;
using WorkConsole.BLL;
using WorkConsole.DB;
internal class Program
{
    public static void Main(string[] args)
    {
        var employee = new Employee();
        var employeeLogic = new EmployeeLogic();
        var employeeGenerator = new EmployeeGenerator();
        int command = 0;
        if (args.Length == 0)
        {
            Console.WriteLine("Введите команду");
        }
        else
        {
            command = int.Parse(args[0]);
        }
        //Выводит таблицу
        if (command == 1)
        {
            employeeLogic.DisplayEmployees();
        }
        //Выводит список сотрудников
        else if( command == 2)
        {
            employeeLogic.AddEmployee(args);
        }
        else if (command == 3)
        {
            employeeLogic.DisplayEmployees(true);
        }
        else if (command == 4)
        {
            List<Employee> generatedEmployees = new List<Employee>();
            generatedEmployees.AddRange(employeeGenerator.GenerateEmployees(1000000));
            generatedEmployees.AddRange(employeeGenerator.GenerateSpecificEmployees(100));
            employeeGenerator.SendToDatabase(generatedEmployees);
        }
    }
}
