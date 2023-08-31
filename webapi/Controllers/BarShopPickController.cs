using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.DataAccess;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/barshoppick")]
    public class BarShopPickController : ControllerBase
    {
        private readonly DataAccess.DataAccess _dataAccess;

        public BarShopPickController(DataAccess.DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet]
        public IActionResult GetBarShopPick()
        {
            var barshoppick = _dataAccess.GetBarShopPick();
            return Ok(barshoppick);
        }
    }
}
