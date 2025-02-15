namespace EmployeeManagementApp.Models
{
    public interface IEmployee
    {
        decimal BonusPercent(); // Method to calculate bonus percentage
        void DisplayDetails();  // Method to display employee details
    }
}
