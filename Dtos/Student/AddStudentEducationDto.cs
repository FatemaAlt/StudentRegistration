using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_registration.Dtos.Student
{
    public class AddStudentEducationDto
    {
        public int StudentId { get; set; }
        public int LevelId { get; set; }
    }
}