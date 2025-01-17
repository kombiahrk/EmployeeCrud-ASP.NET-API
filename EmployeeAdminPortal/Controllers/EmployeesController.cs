﻿using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    // Defines the base route for the API controller as api/Employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // Private field to hold the database context instance
        private readonly ApplicationDbContext dbContext;

        // Constructor that accepts a database context and assigns it to the private field
        public EmployeesController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        // Action method to handle HTTP GET requests and retrieve all employees
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            // Retrieves all employees from the database
            var allEmployees = dbContext.Employees.ToList();

            // Returns an HTTP 200 OK response with the list of employees
            return Ok(allEmployees);
        }

        // Action method to handle HTTP GET requests and retrieve an employee by ID
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            // Retrieves the employee with the specified ID from the database
            var employee = dbContext.Employees.Find(id);

            // Checks if the employee was found
            if (employee is null)
            {
                // Returns an HTTP 404 Not Found response if the employee was not found
                return NotFound();
            }

            // Returns an HTTP 200 OK response with the found employee entity
            return Ok(employee);
        }

        // Action method to handle HTTP POST requests and add a new employee
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            // Maps the AddEmployeeDto to a new Employee entity
            var employeeEntity = new Employee() 
            { 
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            };

            // Adds the new Employee entity to the database context
            dbContext.Employees.Add(employeeEntity);

            // Saves changes to the database
            dbContext.SaveChanges();

            // Returns an HTTP 200 OK response with the newly created employee entity
            return Ok(employeeEntity);
        }

        // Action method to handle HTTP PUT requests and update an existing employee
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            // Retrieves the employee with the specified ID from the database
            var employee = dbContext.Employees.Find(id);

            // Checks if the employee was found
            if (employee is null) 
            {
                // Returns an HTTP 404 Not Found response if the employee was not found
                return NotFound();
            }

            // Updates the employee entity with the provided data
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            // Saves changes to the database
            dbContext.SaveChanges();

            // Returns an HTTP 200 OK response with the updated employee entity
            return Ok(employee);
        }

        // Action method to handle HTTP DELETE requests and delete an employee by ID
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id) 
        {
            // Retrieves the employee with the specified ID from the database
            var employee = dbContext.Employees.Find(id);

            // Checks if the employee was found
            if (employee is null)
            {
                // Returns an HTTP 404 Not Found response if the employee was not found
                return NotFound();
            }

            // Removes the employee entity from the database context
            dbContext.Employees.Remove(employee);

            // Saves changes to the database
            dbContext.SaveChanges();

            // Returns an HTTP 200 OK response indicating successful deletion
            return Ok();
        }
    }
}
