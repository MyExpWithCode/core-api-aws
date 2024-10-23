using core_api_aws.BLL.Services;
using core_api_aws.DAL.DTO;
using core_api_aws.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace core_api_aws.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentClassController(IStudentCalssService studentCalssService) : ControllerBase
    {
        // GET: api/<StudentClassController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await studentCalssService.GetStudentClassesAsync());
        }

        // GET api/<StudentClassController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await studentCalssService.GetStudentClassAsync(id));
        }
        

        // POST api/<StudentClassController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentClass value)
        {
                if(value == null) return BadRequest();
                var id = await studentCalssService.SaveStudentClassAsync(value);
                return Created();
            }

        // PUT api/<StudentClassController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentClassController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var entryId = await studentCalssService.DeleteStudentClassAsync(id);
            return entryId ? Accepted(entryId) : new StatusCodeResult(statusCode: 500);
        }
    }
}
