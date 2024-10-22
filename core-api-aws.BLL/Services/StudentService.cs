using core_api_aws.DAL.TableServices;
using core_api_aws.Domain.DTO;

namespace core_api_aws.BLL.Services
{
    public class StudentService(IStudentContext _studentContext) : IStudentService
    {
        private readonly IStudentContext studentContext = _studentContext;

        public async Task<Student?> GetStudentAsync(string id)
        {
            var student = await studentContext.GetStudentAsync(id);
            return new Student { 
                Id = student.Id, 
                FirstName = student.FirstName, 
                LastName = student.LastName, 
                Class = student.Class, 
                Country = student.Country 
            };

        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            var stds = await studentContext.GetAllStudents();
            return stds.Select(student =>
            new Student
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Class = student.Class,
                Country = student.Country
                
            });
        }
    }
}
