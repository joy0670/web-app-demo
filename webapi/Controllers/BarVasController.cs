using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.DataAccess;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/barvas")]
    public class BarVasController : ControllerBase
    {
        private readonly DataAccess.DataAccess _dataAccess;

        public BarVasController(DataAccess.DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet]
        public IActionResult GetBarVas()
        {
            var barvas = _dataAccess.GetBarVas();
            return Ok(barvas);
        }
    }
}
