using core_api_aws.BLL.Services;
using core_api_aws.DAL.DTO;
using core_api_aws.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentEf>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentEf>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
