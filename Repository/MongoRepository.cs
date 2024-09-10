using MongoDB.Driver;
using Repository.Entities;

namespace Repository
{
    /// <summary>
    /// Implements the IMongoRepository interface for handling MongoDB operations related to teacher entities.
    /// </summary>
    public class MongoRepository :IMongoRepository
    {
        private readonly MongoDbContext _context;

        public MongoRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MongoTeacher>> GetAllTeachersAsync()
        {
            try
            {
                return await _context.Teachers.Find(_ => true).ToListAsync();
            }
            catch (MongoException mongoEx)
            {
                // Log MongoDB specific exceptions
                Console.WriteLine($"MongoDB error: {mongoEx.Message}");
                // Handle MongoDB-specific errors if necessary
                return Enumerable.Empty<MongoTeacher>();
            }
            catch (Exception ex)
            {
                // Log general exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Handle general errors
                return Enumerable.Empty<MongoTeacher>();
            }
        }

        public async Task AddTeacherAsync(MongoTeacher teacher)
        {
            try
            {
                await _context.Teachers.InsertOneAsync(teacher);
            }
            catch (MongoWriteException mongoEx)
            {
                // Log MongoDB write-specific exceptions, e.g., unique constraint violations
                Console.WriteLine($"MongoDB write error: {mongoEx.Message}");
                // Optionally, throw or handle the error in a way that informs the user
                throw new Exception("An error occurred while writing to the MongoDB database.", mongoEx);
            }
            catch (MongoException mongoEx)
            {
                // Log general MongoDB exceptions
                Console.WriteLine($"MongoDB error: {mongoEx.Message}");
                // Optionally, throw or handle the error in a user-friendly manner
                throw new Exception("An error occurred while interacting with MongoDB.", mongoEx);
            }
            catch (Exception ex)
            {
                // Log any general exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Optionally, rethrow or handle the error
                throw new Exception("An unexpected error occurred while adding the teacher.", ex);
            }
        }
    }
}
