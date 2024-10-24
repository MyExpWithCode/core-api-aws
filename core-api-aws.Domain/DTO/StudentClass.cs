﻿namespace core_api_aws.Domain.DTO
{
    public class StudentClass
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }

    public class ClassHistory
    {
        public required int Id { get; set; }
        public int ClassId { get; set; }
        public int Year { get; set; }
        public double PassPercentage { get; set; }
        public double MaxPercentage { get; set; }
        public string? TeacherName { get; set; }
    }

}
