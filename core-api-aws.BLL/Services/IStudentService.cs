using core_api_aws.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core_api_aws.BLL.Services
{
    public interface IStudentService
    {
        Task<Student> GetStudentAsync(string id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
    }
}
