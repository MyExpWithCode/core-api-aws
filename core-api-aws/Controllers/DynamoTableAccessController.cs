using Amazon.DynamoDBv2.DataModel;
using core_api_aws.BLL.DTO;
using core_api_aws.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace core_api_aws.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDynamoDBContext _context;
        private readonly IStudentService studentService;
        public StudentsController(IDynamoDBContext context, IStudentService _studentService)
        {
            _context = context;
            studentService=_studentService;
        }
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetById(string studentId)
        {
            var student = await studentService.GetStudentAsync(studentId);
            if (student == null) return NotFound();
            return Ok(student);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var student = await studentService.GetAllStudentsAsync();
            return Ok(student);
        }

    }
}
