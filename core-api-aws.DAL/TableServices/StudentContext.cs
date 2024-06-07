using Amazon.DynamoDBv2.DataModel;
using core_api_aws.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core_api_aws.DAL.TableServices
{
    public class StudentContext : IStudentContext
    {
        private readonly IDynamoDBContext _context;
        public StudentContext(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentAsync(string id) { return await _context.LoadAsync<Student>(id); }

        public async Task<IList<Student>> GetAllStudents()
        {
            return await _context.ScanAsync<Student>(default).GetRemainingAsync();
        }
    }
}
