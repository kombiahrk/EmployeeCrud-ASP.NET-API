namespace EmployeeAdminPortal.Models
{
    // Data Transfer Object (DTO) for updating an employee
    public class UpdateEmployeeDto
    {
        // Required property for the employee's name
        public required string Name { get; set; }

        // Required property for the employee's email
        public required string Email { get; set; }

        // Optional property for the employee's phone number
        public string? Phone { get; set; }

        // Property for the employee's salary
        public decimal Salary { get; set; }
    }
}
