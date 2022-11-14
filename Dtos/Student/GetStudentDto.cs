using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using student_registration.Dtos.Level;
using student_registration.Dtos.Education;

namespace student_registration.Dtos.Student
{
    public class GetStudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "Fatema";
        public string LastName { get; set; } = "Alteneiji";
        public DateTime DOB { get; set; }
        public GetEducationDto Education { get; set; }
        public List<GetLevelDto> levels { get; set; }
        public string Specialization { get; set; } = "IT";
        public string University { get; set; } = "IT";
    }
}