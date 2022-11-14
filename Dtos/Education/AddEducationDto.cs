using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_registration.Dtos.Education
{
    public class AddEducationDto
    {
        public string Level { get; set; } = string.Empty;
        public int StudentId { get; set; }
    }
}