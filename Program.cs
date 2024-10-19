using WorkConsole.Model;
using WorkConsole.BLL;
internal class Program
{
    public static void Main(string[] args)
    {
        var employee = new Employee();
        var employeeLogic = new EmployeeLogic();
        int command = 0;
        if (args.Length == 0)
        {
            Console.WriteLine("Введите команду");
        }
        else
        {
            command = int.Parse(args[0]);
        }
        switch (command)
        {
            case 1:
                employeeLogic.DisplayEmployees();
                break;

        }
    }
}
