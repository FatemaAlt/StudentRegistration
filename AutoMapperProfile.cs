using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using student_registration.Dtos.Student;
using student_registration.Dtos.Level;
using student_registration.Dtos.Education;

namespace student_registration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, GetStudentDto>();
            CreateMap<AddStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
            CreateMap<Education, GetEducationDto>();
            CreateMap<Level, GetLevelDto>();
        }
    }
}