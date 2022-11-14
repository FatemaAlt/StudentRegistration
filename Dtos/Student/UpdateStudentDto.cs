using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_registration.Dtos.Student
{
    public class UpdateStudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "Fatema";
        public string LastName { get; set; } = "Alteneiji";
        public DateTime DOB { get; set; }
        public string Specialization { get; set; } = "IT";
        public string University { get; set; } = "HCT";
    }
}