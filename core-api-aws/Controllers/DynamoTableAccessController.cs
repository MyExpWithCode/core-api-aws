using core_api_aws.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace core_api_aws.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(IStudentService _studentService) : ControllerBase
    {
        private readonly IStudentService studentService = _studentService;

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
