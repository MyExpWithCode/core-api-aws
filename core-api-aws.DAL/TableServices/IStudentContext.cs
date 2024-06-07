using core_api_aws.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core_api_aws.DAL.TableServices
{
    public interface IStudentContext
    {
        Task<Student> GetStudentAsync(string id);
        Task<IList<Student>> GetAllStudents();
    }
}
