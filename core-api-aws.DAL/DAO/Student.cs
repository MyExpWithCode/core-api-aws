using Amazon.DynamoDBv2.DataModel;

namespace core_api_aws.DAL.DTO
{
    [DynamoDBTable("streamliners-sample-poc")]
    public class Student
    {
        [DynamoDBHashKey("id")]
        public string? Id { get; set; }

        [DynamoDBProperty("first_name")]
        public string? FirstName { get; set; }

        [DynamoDBProperty("last_name")]
        public string? LastName { get; set; }

        [DynamoDBProperty("class")]
        public int Class { get; set; }

        [DynamoDBProperty("country")]
        public string? Country { get; set; }
    }
}
