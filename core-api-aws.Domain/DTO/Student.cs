using System.ComponentModel.DataAnnotations;

namespace core_api_aws.Domain.DTO
{
    public class Student
    {
        public string? Id { get; set; }

        public string FullName { get { return FirstName! + " " + LastName!; } }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Country { get; set; }
        public required string StudentClass { get; set; }
    }

    public class StudentSaveDto
    {

        public string FullName { get { return FirstName! + " " + LastName!; } }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Country { get; set; }
        public required int StudentClassId { get; set; }
    }
}
