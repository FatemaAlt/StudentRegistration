using System.Text.Json.Serialization;

namespace student_registration.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RoleClass
    {
        Student = 1,
        Admin = 2
    }
}
