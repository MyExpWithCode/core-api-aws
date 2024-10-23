using core_api_aws.DAL.DTO;
using core_api_aws.Domain.DTO;
using core_api_aws.ef.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core_api_aws.BLL.Services
{
    public class StudentClassService : IStudentCalssService
    {
        private readonly EfContext dbContext = new();
        public async Task<bool> DeleteStudentClassAsync(string id)
        {
            var std = await GetStudentClassAsync(id);
            if (std == null) throw new Exception($"student with {id} not found.");
            dbContext.Remove(std);
            var result = await dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<StudentClass?> GetStudentClassAsync(string studentId)
        {
            return studentId != null
                ? await dbContext.Classes
                .Where(x => x.Id == int.Parse(studentId!))
                .Select(x => new StudentClass { Id = x.Id, Name = x.Name })
                .FirstOrDefaultAsync()
                : null;
        }

        public async Task<IList<StudentClass>?> GetStudentClassesAsync()
        {
            return await dbContext.Classes.Select(x => new StudentClass { Id = x.Id, Name = x.Name }).ToListAsync();
        }

        public async Task<string> SaveStudentClassAsync(StudentClass stdClass)
        {
            var temp = new EF.DTO.StudentClass { Id = stdClass.Id, Name = stdClass.Name };
            var std = await dbContext.Classes.AddAsync(temp);
            await dbContext.SaveChangesAsync();
            var dbValue = await std.GetDatabaseValuesAsync();
            return dbValue!.GetValue<int>("Id").ToString();
        }
    }
}
