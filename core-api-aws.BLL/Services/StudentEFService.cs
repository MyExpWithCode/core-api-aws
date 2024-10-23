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
            return await dbContext.Students
                .Select(x => new Student { FirstName = x.FirstName, LastName = x.LastName, Id = x.Id, Country = x.Country, StudentClass = x.StudentClass.Name })
                .ToListAsync();
        }

        public async Task<Student?> GetStudentAsync(string id)
        {
            return await dbContext.Students
                .Where(x => x.Id == id)
                .Select(x => new Student { FirstName = x.FirstName, LastName = x.LastName, Id = x.Id, Country = x.Country, StudentClass = x.StudentClass.Name })
                .FirstOrDefaultAsync();
        }

        public async Task<string> SaveStudentAsync(StudentSaveDto student)
        {
            EF.DTO.Student stdnt = new() { Id = "3", FirstName = student.FirstName, LastName = student.LastName, Country = student.Country, StudentClassId = student.StudentClassId, };
            var std = await dbContext.Students.AddAsync(stdnt);
            await dbContext.SaveChangesAsync();
            var dbValue = await std.GetDatabaseValuesAsync();
            return dbValue!.GetValue<string>("Id");
        }

        public async Task<string> UpdateStudentAsync(string id, StudentSaveDto student)
        {
            var std = await dbContext.Students
                .Where(x => x.Id == id)
                .Select(x => new Student { FirstName = x.FirstName, LastName = x.LastName, Id = x.Id, Country = x.Country, StudentClass = x.StudentClass.Name })
                .FirstOrDefaultAsync();
            if (std == null) throw new Exception($"student with {id} not found.");

            std.FirstName = student.FirstName;
            std.LastName = student.LastName;
            std.StudentClass = student.StudentClassId.ToString();
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
