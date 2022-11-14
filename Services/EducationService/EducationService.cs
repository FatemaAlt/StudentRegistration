using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using student_registration.Data;
using student_registration.Dtos.Student;
using student_registration.Dtos.Education;
using Microsoft.EntityFrameworkCore;

namespace student_registration.Services.EducationService
{
    public class EducationService : IEducationService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public EducationService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetStudentDto>> AddEducation(AddEducationDto newEducation)
        {
            ServiceResponse<GetStudentDto> response = new ServiceResponse<GetStudentDto>();
            try
            {
                Student student = await _context.Students
                    .FirstOrDefaultAsync(s => s.Id == newEducation.StudentId &&
                    s.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
                if (student == null)
                {
                    response.Success = false;
                    response.Message = "Student not found.";
                    return response;
                }

                Education education = new Education
                {
                    Level = newEducation.Level,
                    Student = student
                };

                _context.Educations.Add(education);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetStudentDto>(student);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}