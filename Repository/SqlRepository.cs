using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository
{
    /// <summary>
    /// Implements the ISqlRepository interface for handling SQL database operations related to teacher entities.
    /// </summary>
    public class SqlRepository : ISqlRepository
    {
        private readonly SqlDbContext _context;

        public SqlRepository(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            try
            {
                return await _context.Teachers.Include(t => t.Courses).ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception message (or use Console.WriteLine for debugging)
                // You can replace this with your logger, e.g., _logger.LogError
                Console.WriteLine($"An error occurred: {ex.Message}");

                // Handle the exception gracefully
                return Enumerable.Empty<Teacher>();
            }
        }

        public async Task AddTeacherAsync(Teacher teacher)
        {
            try
            {
                await _context.Teachers.AddAsync(teacher);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                // Log the database update specific exception
                Console.WriteLine($"Database update error: {dbEx.Message}");
                // Handle specific DB errors, rethrow if necessary
                throw new Exception("An error occurred while updating the database. Please try again.", dbEx);
            }
            catch (Exception ex)
            {
                // Log the general exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Handle general errors
                throw new Exception("An unexpected error occurred while adding the teacher.", ex);
            }
        }
    }
}
