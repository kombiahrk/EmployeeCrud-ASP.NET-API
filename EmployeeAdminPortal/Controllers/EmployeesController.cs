﻿using EmployeeAdminPortal.Data;
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
    }
}