using System.ComponentModel.DataAnnotations;

namespace core_api_aws.Domain.DTO
{
    public class Student
    {
        [Key]
        public string? Id { get; set; }

        public string FullName { get { return FirstName! + " " + LastName!; } }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int ClassId { get; set; }

        public string? Country { get; set; }
    }
}
