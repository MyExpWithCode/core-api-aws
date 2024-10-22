using core_api_aws.Domain.DTO;

namespace core_api_aws.BLL.Services
{
    public interface IStudentEFService
    {
        Task<Student?> GetStudentAsync(string id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
    }
}
