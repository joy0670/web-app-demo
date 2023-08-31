using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataController : ControllerBase
    {
        private readonly CombineDataHandler _dataHandler;

        public DataController(CombineDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        [HttpGet("combined-data")]
        public IActionResult GetCombinedData()
        {
            var data = _dataHandler.GetCombinedData();
            return Ok(data);
        }
    }
}
