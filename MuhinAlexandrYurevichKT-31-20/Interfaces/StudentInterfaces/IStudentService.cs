using MuhinAlexandrYurevichKT_31_20.Database;
using MuhinAlexandrYurevichKT_31_20.Models;
using MuhinAlexandrYurevichKT_31_20.Filters.StudentFilters;
using Microsoft.EntityFrameworkCore;

namespace MuhinAlexandrYurevichKT_31_20.Interfaces.StudentInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
    }
    public class StudentService : IStudentService
    {
        private MuhinDbContext _dbContext;
        public StudentService(MuhinDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);
            return students;
        }
    }
}
