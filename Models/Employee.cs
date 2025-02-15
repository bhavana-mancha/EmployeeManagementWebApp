using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Models
{
    public class Employee : IEmployee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public decimal Salary { get; set; } // ✅ Added Salary

        [Required(ErrorMessage = "Years of Experience is required")]
        [Range(0, 50, ErrorMessage = "Years of Experience must be between 0 and 50")]
        public int YearsOfExperience { get; set; } // ✅ Added YearsOfExperience

        [Required(ErrorMessage = "Role is required")]
        public required string Role { get; set; } // ✅ Added Role

        public virtual decimal BonusPercent()
        {
            return 0.05m; // Default 5% bonus
        }

        // Implement DisplayDetails Method
        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Employee: {Name}, Role: {Role}, Email: {Email}, Salary: {Salary}, Experience: {YearsOfExperience} years");
        }
    }
}
