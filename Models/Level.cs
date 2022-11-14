using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_registration.Models
{
    public class Level
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Student> Students { get; set; }
    }
}