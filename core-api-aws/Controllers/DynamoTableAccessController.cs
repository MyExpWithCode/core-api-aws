using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace core_api_aws.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamoTableAccessController : ControllerBase
    {

        public DynamoTableAccessController() { }

        [HttpGet("GetAll")]
        public IActionResult GetAllRecords()
        {
            return Ok();

        }
        [HttpGet("GetBatch")]
        public async Task GetBatch()
        {

        }

        [HttpGet("GetItem")]
        public async Task GetItem()
        {

        }

        [HttpPost("AddItem")]
        public async void AddItem()
        {

        }
        [HttpDelete("DeleteItem")]
        public async void DeleteItem()
        {

        }

    }
}
