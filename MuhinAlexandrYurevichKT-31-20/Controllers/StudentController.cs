using MuhinAlexandrYurevichKT_31_20.Database;
using MuhinAlexandrYurevichKT_31_20.Filters.StudentFilters;
using MuhinAlexandrYurevichKT_31_20.Interfaces.StudentInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuhinAlexandrYurevichKT_31_20.Models;
using System.Text.RegularExpressions;

namespace MuhinAlexandrYurevichKT_31_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;
        public MuhinDbContext _dbcontext;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService, MuhinDbContext context)
        {
            _logger = logger;
            _studentService = studentService;
            _dbcontext = context;
        }

        [HttpPost(Name = "GetStudentsByGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);
            return Ok(students);
        }

        [HttpPost("AddStudent", Name = "AddStudent")]
        public IActionResult CreateStudent([FromBody] StudentAddFilter filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var student = new Student();
            student.FirstName = filter.FirstName;
            student.LastName = filter.LastName;
            student.MiddleName = filter.MiddleName;
            student.GroupId = _dbcontext.Set<Models.Group>().FirstOrDefault(g => g.GroupId == filter.GroupId).GroupId;

            _dbcontext.Set<Student>().Add(student);
            _dbcontext.SaveChanges();
            return Ok(student);
        }

        [HttpPut("EditStudent")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentAddFilter filter)
        {
            var existingStudent = _dbcontext.Set<Student>().FirstOrDefault(g => g.StudentId == id);

            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.FirstName = filter.FirstName;
            existingStudent.LastName = filter.LastName;
            existingStudent.MiddleName = filter.MiddleName;
            existingStudent.GroupId = _dbcontext.Set<Models.Group>().FirstOrDefault(g => g.GroupId == filter.GroupId).GroupId;
            _dbcontext.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteGroup(int id)
        {
            var existingStudent = _dbcontext.Set<Student>().FirstOrDefault(g => g.StudentId == id);

            if (existingStudent == null)
            {
                return NotFound();
            }
            _dbcontext.Set<Student>().Remove(existingStudent);
            _dbcontext.SaveChanges();

            return Ok();
        }
    }
}
