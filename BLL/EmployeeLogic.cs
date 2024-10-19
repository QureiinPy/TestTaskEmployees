using WorkConsole.Model;

namespace WorkConsole.BLL
{
    public class EmployeeLogic
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee(){FirstName = "First", SecondName = "Second", LastName = "Last", Gender = Gender.Male},
            new Employee(){FirstName = "Andrey", SecondName = "WUW", LastName = "LAST", Gender = Gender.Female}
        };

        public void DisplayEmployees()
        {
            Console.WriteLine("\nСписок сотрудников:");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("| {0,-20} | {1,-12} | {2,-6} |", "ФИО", "Дата рождения", "Пол");
            Console.WriteLine("-------------------------------------------------");

            foreach (var emp in employees)
            {
                Console.WriteLine("| {0,-20} | {1,-12:yyyy-MM-dd} | {2,-6} |", $"{emp.FirstName} {emp.SecondName} {emp.LastName}", emp.BirthDate, emp.Gender);
            }

            Console.WriteLine("-------------------------------------------------");
        }
    }
}
