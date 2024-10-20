
namespace WorkConsole.Model;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; } = DateTime.Now;
    public Gender Gender { get; set; }
}
