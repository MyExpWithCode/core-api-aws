using core_api_aws.Domain.DTO;
using System.Threading.Tasks;

namespace core_api_aws.BLL.Services
{
    public interface IStudentEFService
    {
        Task<Student?> GetStudentAsync(string id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<string> SaveStudentAsync(Student student);
        Task<string> UpdateStudentAsync(string id,Student student);
        Task<bool> DeleteStudentAsync(string id);
    }
}
