using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using student_registration.Dtos.Student;
using student_registration.Dtos.Education;

namespace student_registration.Services.EducationService
{
    public interface IEducationService
    {
        Task<ServiceResponse<GetStudentDto>> AddEducation(AddEducationDto newEducation);
    }
}