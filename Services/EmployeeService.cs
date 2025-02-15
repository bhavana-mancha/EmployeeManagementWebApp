using EmployeeManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementApp.Services
{
    public class EmployeeService
    {
        private static readonly List<Employee> _employees = new List<Employee>(); // ✅ Use 'readonly' to prevent reassignment

        // Returns a list of all employees
        public List<Employee> GetAllEmployees() => _employees.ToList(); // ✅ Prevent accidental modification

        // Returns an employee by ID, or null if not found
        public Employee? GetEmployeeById(int id) => _employees.FirstOrDefault(e => e.Id == id);
          

        
        // Adds a new employee to the list
        public void AddEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), "Employee cannot be null.");

            // ✅ Check if employee with the same ID already exists
            if (_employees.Any(e => e.Id == employee.Id))
                throw new ArgumentException($"Employee with ID {employee.Id} already exists.");

            //employee.Id = _employees.Any() ? _employees.Max(e => e.Id) + 1 : 1; // Auto-increment ID
            _employees.Add(employee);
        }

        // Updates an existing employee
        public void UpdateEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), "Employee cannot be null.");

            var existingEmployee = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existingEmployee == null)
                throw new ArgumentException($"Employee with ID {employee.Id} not found.");

            // ✅ Use object initializer for cleaner updates
            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.YearsOfExperience = employee.YearsOfExperience;
            existingEmployee.Role = employee.Role;
        }
   
        // Deletes an employee by ID
        public void DeleteEmployee(int id)
        {
            if (!_employees.Any(e => e.Id == id))
                throw new ArgumentException($"Employee with ID {id} not found.");

            _employees.RemoveAll(e => e.Id == id); // ✅ Cleaner way to remove employees
        }
    }
}
