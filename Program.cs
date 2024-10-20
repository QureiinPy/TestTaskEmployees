using WorkConsole.Model;
using WorkConsole.BLL;
using WorkConsole.DB;
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
            case 2:
                using (var db = new AppDbContext())
                {
                    List<Employee> employees = db.Employees.ToList();
                }
                    break;

        }
    }
}
