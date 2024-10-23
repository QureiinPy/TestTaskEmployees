using System;
using WorkConsole.DB;
using WorkConsole.Model;

namespace WorkConsole.BLL
{
    public class EmployeeGenerator
    {
        private static readonly Random random = new Random();
        private static readonly string[] maleFirstNames = { "Alex", "John", "Michael", "Frank", "David" };
        private static readonly string[] femaleFirstNames = { "Anna", "Maria", "Julia", "Fiona", "Diana" };
        private static readonly string[] secondNames = { "Ivanov", "Petrov", "Sidorov", "Fedorov" };
        private static readonly string[] lastNames = { "Sergeevich", "Aleksandrovich", "Egorovich" };

        //Автоматическое создание списка сотрудников
        public List<Employee> GenerateEmployees(int count)
        {
            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < count; i++)
            {
                Gender gender = random.Next(2) == 0 ? Gender.Male : Gender.Female;
                string firstName = gender == Gender.Male ?
                    maleFirstNames[random.Next(maleFirstNames.Length)] :
                    femaleFirstNames[random.Next(femaleFirstNames.Length)];

                string secondName = secondNames[random.Next(secondNames.Length)];
                string lastName = lastNames[random.Next(lastNames.Length)];

                employees.Add(new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    SecondName = secondName,
                    Gender = gender
                });
            }
            return employees;
        }
        public List<Employee> GenerateSpecificEmployees(int count)
        {
            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < count; i++)
            {
                Gender gender = Gender.Male;
                string firstName = maleFirstNames[random.Next(maleFirstNames.Length)];
                string secondName = "Franke";
                string lastName = lastNames[random.Next(lastNames.Length)];

                employees.Add(new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    SecondName = secondName,
                    Gender = gender
                });
            }

            return employees;
        }

        public void SendToDatabase(List<Employee> employees)
        {
            //Пакетная отправка списка в БД
            using (var db = new AppDbContext())
            {
                db.Employees.AddRange(employees);
                db.SaveChanges();
            }
        }
    }
}
