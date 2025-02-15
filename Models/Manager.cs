namespace EmployeeManagementApp.Models
{
    public class Manager : IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public int YearsOfExperience { get; set; }
        public string Role { get; set; }

        // Constructor
        
        // Implement BonusPercent Method
        public decimal BonusPercent()
        {
            return 0.10m; // Managers get a 10% bonus
        }
        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Employee: {Name}, Role: {Role}, Email: {Email}, Salary: {Salary}, Experience: {YearsOfExperience} years");
        }
    }
}
