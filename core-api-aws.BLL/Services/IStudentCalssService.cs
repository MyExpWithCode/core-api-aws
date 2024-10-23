using core_api_aws.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core_api_aws.BLL.Services
{
    public interface IStudentCalssService
    {
        Task<StudentClass?> GetStudentClassAsync(string studentId);
        Task<IList<StudentClass>?> GetStudentClassesAsync();
        Task<string> SaveStudentClassAsync(StudentClass stdClass);
        Task<bool> DeleteStudentClassAsync(string id);
    }
}
