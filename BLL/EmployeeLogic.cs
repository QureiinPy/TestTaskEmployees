using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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

        public void DisplaySpecificEmployees(List<Employee> employees)
        {
            Console.WriteLine("\nСписок сотрудников:");
            Console.WriteLine("+----+---------------------------+--------------+-----------+");
            Console.WriteLine("| Id |          ФИО             |   Дата рождения  |   Пол    |");
            Console.WriteLine("+----+---------------------------+--------------+-----------+");
            foreach (var employee in employees)
            {
                string FullName = $"{employee.LastName} {employee.FirstName} {employee.SecondName}";
                Console.WriteLine($"| {employee.Id,2} | {FullName,-25} | {employee.BirthDate.ToShortDateString(),-13}     | {employee.Gender,-8} |");
            }
            Console.WriteLine("+----+---------------------------+--------------+-----------+");
        }

        public void DisplayEmployees(bool SortedUniqueEmployees = false)
        {
            if (!SortedUniqueEmployees)
            {
            Console.WriteLine("\nСписок сотрудников:");
            Console.WriteLine("+----+---------------------------+--------------+-----------+");
            Console.WriteLine("| Id |          ФИО             |   Дата рождения  |   Пол    |");
            Console.WriteLine("+----+---------------------------+--------------+-----------+");

            using (var db = new AppDbContext())
            {
                foreach (var employee in db.Employees)
                {
                    string FullName = $"{employee.LastName} {employee.FirstName} {employee.SecondName}";
                    Console.WriteLine($"| {employee.Id,2} | {FullName,-25} | {employee.BirthDate.ToShortDateString(),-13}     | {employee.Gender,-8} |");
                }
            }
            Console.WriteLine("+----+---------------------------+--------------+-----------+");
            }
            else
            {
                Console.WriteLine("\nСписок сотрудников:");
                Console.WriteLine("+----+---------------------------+--------------+-----------+");
                Console.WriteLine("|          ФИО             |   Возраст  |   Пол    |");
                Console.WriteLine("+----+---------------------------+--------------+-----------+");

                using (var db = new AppDbContext())
                {
                    foreach (var employee in SortByFullName())
                    {
                        string FullName = $"{employee.LastName} {employee.FirstName} {employee.SecondName}";
                        Console.WriteLine($"| {FullName,-25} | {CalculateAge(employee.BirthDate),-6}    | {employee.Gender,-8} |");
                    }
                }
                Console.WriteLine("+----+---------------------------+--------------+-----------+");
            }
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
        }

        public int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Now;
            TimeSpan ageSpan = today - birthDate;
            int age = (int)(ageSpan.TotalDays / 365.25);
            return age;
        }

        public List<Employee> SortByFullName()
        {
            List<Employee> uniqueEmployees = new List<Employee>();
            using (var db = new AppDbContext())
            {
                List<Employee> employees = db.Employees.ToList();
                uniqueEmployees = employees.DistinctBy(e => e.FirstName)
                    .Distinct()
                    .ToList();
            }
            var sortedList = uniqueEmployees.OrderBy(e => e.LastName)
                .OrderBy(e => e.FirstName)
                .OrderBy(e => e.SecondName)
                .ToList();
            return sortedList;
        }
    }
}
