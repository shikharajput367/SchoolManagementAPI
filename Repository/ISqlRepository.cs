using Repository.Entities;

namespace Repository
{
    /// <summary>
    /// Defines the contract for a SQL repository that handles operations for teacher entities.
    /// </summary>
    public interface ISqlRepository
    {
        /// <summary>
        /// Asynchronously retrieves all teacher entities from the SQL database.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains an IEnumerable of Teacher.</returns>
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();

        /// <summary>
        /// Asynchronously adds a new teacher entity to the SQL database.
        /// </summary>
        /// <param name="teacher">The Teacher entity to be added.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddTeacherAsync(Teacher teacher);
    }
}
