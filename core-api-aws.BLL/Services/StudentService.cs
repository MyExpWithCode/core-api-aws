using core_api_aws.BLL.DTO;
using core_api_aws.DAL.TableServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core_api_aws.BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentContext studentContext;
        public StudentService(IStudentContext _studentContext)
        {
            studentContext = _studentContext;
        }
        public async Task<Student> GetStudentAsync(string id)
        {
            var student = await studentContext.GetStudentAsync(id);
            return new Student { Id = student.Id, FirstName = student.FirstName, LastName = student.LastName, Class = student.Class, Country = student.Country };

        }

        public Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
