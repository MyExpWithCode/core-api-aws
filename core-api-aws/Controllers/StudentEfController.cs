using core_api_aws.BLL.Services;
using core_api_aws.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace core_api_aws.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentEfController(IStudentEFService studentService) : ControllerBase
    {

        // GET: api/<StudentEf>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await studentService.GetAllStudentsAsync();
            if (students == null) return NotFound();
            return Ok(students);
        }

        // GET api/<StudentEf>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var student = await studentService.GetStudentAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        // POST api/<StudentEf>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentSaveDto student)
        {
            if (student == null) return BadRequest();
            var id = await studentService.SaveStudentAsync(student);
            return Created();
        }

        // PUT api/<StudentEf>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] StudentSaveDto student)
        {
            if (student == null) return BadRequest();
            var entryId = await studentService.UpdateStudentAsync(id, student);
            return NoContent();
        }

        // DELETE api/<StudentEf>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var entryId = await studentService.DeleteStudentAsync(id);
            return entryId == true ? Accepted(entryId) : new StatusCodeResult(statusCode: 500);
        }
    }
}
