using core_api_aws.Domain.DTO;
using core_api_aws.ef.DAL;
using Microsoft.EntityFrameworkCore;

namespace core_api_aws.BLL.Services
{
    public class StudentEFService : IStudentEFService
    {
        private readonly EfContext dbContext = new();

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await dbContext.Students.ToListAsync();
        }

        public async Task<Student?> GetStudentAsync(string id)
        {
            return await dbContext.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
