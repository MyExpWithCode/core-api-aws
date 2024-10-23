using System.ComponentModel.DataAnnotations;

namespace core_api_aws.EF.DTO
{
    public class Student
    {
        [Key]
        public string? Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Country { get; set; }

        // Foregin key property
        public int StudentClassId { get; set; }

        //Reference Navigation property
        public StudentClass StudentClass { get; set; }
    }
}
