using employees.Data;
using employees.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = dbContext.Employees.ToList();
            return Ok(allEmployees);
        }
        
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetAllEmployeeById(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            
            if (employee == null) return NotFound();
            
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, employee);
        }

        // [HttpDelete]
        // [Route("{id:guid}")]
        // public IActionResult DeleteEmployee(Guid id)
        // {
        //     var employee = dbContext.Employees.Remove(id);    
        //     
        // }
        
        
    }
}
