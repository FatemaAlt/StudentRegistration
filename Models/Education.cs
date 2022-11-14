using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_registration.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string Level { get; set; } = string.Empty;
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}