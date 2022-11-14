using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_registration.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "Fatema";
        public string LastName { get; set; } = "Alteneiji";
        public DateTime DOB { get; set; } 
        public Education Education { get; set; }
        public List<Level> levels { get; set; }
        public string Specialization { get; set; } = "IT";
        public string University { get; set; } = "IT";
        public User? User { get; set; }
       
    }
}