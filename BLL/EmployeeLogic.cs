using WorkConsole.DB;
using WorkConsole.Model;

namespace WorkConsole.BLL
{
    public class EmployeeLogic
    {

        public void DisplayTable()
        {
            Console.WriteLine("\nСписок сотрудников:");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("| {0,-20} | {1,-12} | {2,-6} |", "ФИО", "Дата рождения", "Пол");
            Console.WriteLine("-------------------------------------------------");
        }

        public void DisplayEmployees()
        {
            Console.WriteLine("\nСписок сотрудников:");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("| {0,-20} | {1,-12} | {2,-6} |", "ФИО", "Дата рождения", "Пол");
            Console.WriteLine("-------------------------------------------------");

            using (var db = new AppDbContext())
            {
                foreach (var emp in db.Employees)
                {
                    Console.WriteLine("| {0,-20} | {1,-12:yyyy-MM-dd} | {2,-6} |", $"{emp.LastName} {emp.FirstName} {emp.SecondName}", emp.BirthDate, emp.Gender);
                }
            }
            Console.WriteLine("-------------------------------------------------");
        }

        public void AddEmployee(string[] args)
        {
            string firstName = args[1].Split()[1];
            string secondName = args[1].Split()[2];
            string lastName = args[1].Split()[0];
            DateTime birthDate = DateTime.Parse(args[2]);
            Gender gender = args[3] == "Male" ? Gender.Male : Gender.Female;

            var newEmployee = new Employee()
            {
                FirstName = firstName,
                SecondName = secondName,
                LastName = lastName,
                BirthDate = birthDate,
                Gender = gender
            };

            //DB
            using (var db = new AppDbContext())
            {
                db.Employees.Add(newEmployee);
                db.SaveChanges();
                List<Employee> employees = db.Employees.ToList();
            }
            int age = CalculateAge(birthDate);
            Console.WriteLine($"Его возраст {age}");
        }

        public int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Now;
            TimeSpan ageSpan = today - birthDate;
            int age = (int)(ageSpan.TotalDays / 365.25);
            return age;
        }
    }
}
