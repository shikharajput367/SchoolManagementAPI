using Repository.Entities;

namespace Repository
{
    /// <summary>
    /// Defines the contract for a MongoDB repository that handles operations for teacher entities.
    /// </summary>
    public interface IMongoRepository
    {
        /// <summary>
        /// Asynchronously retrieves all teacher entities from the MongoDB database.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains an IEnumerable of MongoTeacher.</returns>
        Task<IEnumerable<MongoTeacher>> GetAllTeachersAsync();

        /// <summary>
        /// Asynchronously adds a new teacher entity to the MongoDB database.
        /// </summary>
        /// <param name="teacher">The MongoTeacher entity to be added.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddTeacherAsync(MongoTeacher teacher);
    }
}
