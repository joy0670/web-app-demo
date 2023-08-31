

using Microsoft.AspNetCore.Mvc;
using webapi.DataAccess;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly DataAccess.DataAccess _dataAccess;

        public EmployeesController(DataAccess.DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }


        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _dataAccess.GetEmployees();
            return Ok(employees);
        }

        // Other actions to manipulate employee data
    }
}
