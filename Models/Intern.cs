namespace EmployeeManagementApp.Models
{
    public class Intern : IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public int YearsOfExperience { get; set; }
        public string Role { get; set; }
        public Intern()
        {}

        // Constructor
        public Intern(int id, string name, string email, decimal salary, int yearsOfExperience, string role)
        {
            Id = id;
            Name = name;
            Email = email;
            Salary = salary;
            YearsOfExperience = yearsOfExperience;
            Role = role;
        }

        // Implement BonusPercent Method
        public decimal BonusPercent()
        {
            return 0m; // Interns do not receive a bonus
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Employee: {Name}, Role: {Role}, Email: {Email}, Salary: {Salary}, Experience: {YearsOfExperience} years");
        }
    }
}
