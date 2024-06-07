using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core_api_aws.BLL.DTO
{
    public class Student
    {
        public string? Id { get; set; }

        public string FullName { get { return FirstName! + " " + LastName!; } }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Class { get; set; }

        public string? Country { get; set; }
    }
}
