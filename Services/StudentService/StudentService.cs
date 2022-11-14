using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using student_registration.Data;
using student_registration.Dtos.Student;
using Microsoft.EntityFrameworkCore;

namespace student_registration.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StudentService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetStudentDto>>> AddStudent(AddStudentDto newStudent)
        {
            var serviceResponse = new ServiceResponse<List<GetStudentDto>>();
            Student student = _mapper.Map<Student>(newStudent);
            student.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Students
                .Where(s => s.User.Id == GetUserId())
                .Select(s => _mapper.Map<GetStudentDto>(s))
                .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> DeleteStudent(int id)
        {
            ServiceResponse<List<GetStudentDto>> response = new ServiceResponse<List<GetStudentDto>>();

            try
            {
                Student student = await _context.Students
                    .FirstOrDefaultAsync(s => s.Id == id && s.User.Id == GetUserId());
                if (student != null)
                {
                    _context.Students.Remove(student);
                    await _context.SaveChangesAsync();
                    response.Data = _context.Students
                        .Where(s => s.User.Id == GetUserId())
                        .Select(s => _mapper.Map<GetStudentDto>(s)).ToList();
                }
                else
                {
                    response.Success = false;
                    response.Message = "Student not found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents()
        {
            var response = new ServiceResponse<List<GetStudentDto>>();
            var dbStudents = await _context.Students
                .Include(s => s.Education)
                .Include(s => s.levels)
                .Where(s => s.User.Id == GetUserId())
                .ToListAsync();
            response.Data = dbStudents.Select(s => _mapper.Map<GetStudentDto>(s)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetStudentDto>> GetStudentById(int id)
        {
            var serviceResponse = new ServiceResponse<GetStudentDto>();
            var dbStudent = await _context.Students
                .Include(s => s.Education)
                .Include(s => s.levels)
                .FirstOrDefaultAsync(s => s.Id == id && s.User.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetStudentDto>(dbStudent);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStudentDto>> UpdateStudent(UpdateStudentDto updatedStudent)
        {
            ServiceResponse<GetStudentDto> response = new ServiceResponse<GetStudentDto>();

            try
            {
                var student = await _context.Students
                    .Include(s => s.User)
                    .FirstOrDefaultAsync(s => s.Id == updatedStudent.Id);

                if (student.User.Id == GetUserId())
                {

                    _mapper.Map(updatedStudent, student);

                    await _context.SaveChangesAsync();

                    response.Data = _mapper.Map<GetStudentDto>(student);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Student not found.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetStudentDto>> AddStudentEducation(AddStudentEducationDto newStudentEducation)
        {
            var response = new ServiceResponse<GetStudentDto>();
            try
            {
                var student = await _context.Students
                    .Include(s => s.Education)
                    .Include(s => s.levels)
                    .FirstOrDefaultAsync(s => s.Id == newStudentEducation.StudentId &&
                    s.User.Id == GetUserId());

                if (student == null)
                {
                    response.Success = false;
                    response.Message = "Student not found.";
                    return response;
                }

                var level = await _context.Levels.FirstOrDefaultAsync(s => s.Id == newStudentEducation.LevelId);
                if (level == null)
                {
                    response.Success = false;
                    response.Message = "Level not found.";
                    return response;
                }

                student.levels.Add(level);
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