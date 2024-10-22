using Amazon.DynamoDBv2.Model.Internal.MarshallTransformations;
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

        public async Task<string> SaveStudentAsync(Student student)
        {
            var std = await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            var dbValue = await std.GetDatabaseValuesAsync();
            return dbValue!.GetValue<string>("Id");
        }

        public async Task<string> UpdateStudentAsync(string id, Student student)
        {
            var std = await GetStudentAsync(id);
            if (std == null) throw new Exception($"student with {id} not found.");

            std.FirstName = student.FirstName;
            std.LastName = student.LastName;
            std.Class = student.Class;
            std.Country = student.Country;

            await dbContext.SaveChangesAsync();
            return id;
        }


        public async Task<bool> DeleteStudentAsync(string id)
        {
            var std = await GetStudentAsync(id);
            if (std == null) throw new Exception($"student with {id} not found.");
            dbContext.Remove(std);
            var result = await dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
