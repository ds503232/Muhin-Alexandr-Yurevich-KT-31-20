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

        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }
        [HttpPost(Name = "GetStudentsBuGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken)
        {

            var students = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);
            return Ok(students);
        }
    }
}
