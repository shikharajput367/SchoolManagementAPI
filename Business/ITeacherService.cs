using Abstractions.DTOs;

namespace Business
{
    /// <summary>
    /// Defines the contract for a service that handles operations related to teacher entities.
    /// This service provides methods for retrieving and adding teachers from both SQL and MongoDB sources, 
    /// as well as combining data from both sources.
    /// </summary>
    public interface ITeacherService
    {
        /// <summary>
        /// Asynchronously retrieves all teacher data from the SQL database and maps it to TeacherDto.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains an IEnumerable of TeacherDto.</returns>
        Task<IEnumerable<TeacherDto>> GetSqlTeachersAsync();

        /// <summary>
        /// Asynchronously retrieves all teacher data from MongoDB and maps it to TeacherDto.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains an IEnumerable of TeacherDto.</returns>
        Task<IEnumerable<TeacherDto>> GetMongoTeachersAsync();

        /// <summary>
        /// Asynchronously retrieves and combines teacher data from both SQL and MongoDB sources and maps it to TeacherDto.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains an IEnumerable of TeacherDto.</returns>
        Task<IEnumerable<TeacherDto>> GetCombinedTeachersAsync();

        /// <summary>
        /// Asynchronously adds a new teacher entity to the appropriate data source based on the provided TeacherDto.
        /// </summary>
        /// <param name="teacherDto">The TeacherDto entity to be added.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddTeacherAsync(TeacherDto teacherDto);
    }
}
