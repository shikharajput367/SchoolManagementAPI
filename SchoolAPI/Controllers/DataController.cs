using Abstractions.DTOs;
using Business;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Provides endpoints for managing and retrieving teacher data from SQL and MongoDB databases.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly ITeacherService _teacherService;

        public DataController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        /// <summary>
        /// Retrieves all teachers from the SQL database.
        /// </summary>
        /// <returns>An IActionResult containing the status code and the list of teachers from SQL or an error message.</returns>
        [HttpGet("sql")]
        public async Task<IActionResult> GetSqlTeachers()
        {
            try
            {
                var teachers = await _teacherService.GetSqlTeachersAsync();

                if (teachers == null || !teachers.Any())
                {
                    return NotFound(new { StatusCode = 404, Message = "No teachers found in SQL." });
                }

                return Ok(new { StatusCode = 200, Data = teachers });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, Message = "An internal server error occurred.", Details = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves all teachers from MongoDB.
        /// </summary>
        /// <returns>An IActionResult containing the status code and the list of teachers from MongoDB or an error message.</returns>
        [HttpGet("mongo")]
        public async Task<IActionResult> GetMongoTeachers()
        {
            try
            {
                var teachers = await _teacherService.GetMongoTeachersAsync();

                if (teachers == null || !teachers.Any())
                {
                    return NotFound(new { StatusCode = 404, Message = "No teachers found in MongoDB." });
                }

                return Ok(new { StatusCode = 200, Data = teachers });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, Message = "An internal server error occurred.", Details = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves all teachers from both SQL and MongoDB and combines the results.
        /// </summary>
        /// <returns>An IActionResult containing the status code and the combined list of teachers or an error message.</returns>
        [HttpGet("combined")]
        public async Task<IActionResult> GetCombinedTeachers()
        {
            try
            {
                var teachers = await _teacherService.GetCombinedTeachersAsync();

                if (teachers == null || !teachers.Any())
                {
                    return NotFound(new { StatusCode = 404, Message = "No teachers found in SQL or MongoDB." });
                }

                return Ok(new { StatusCode = 200, Data = teachers });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, Message = "An internal server error occurred.", Details = ex.Message });
            }
        }

        /// <summary>
        /// Adds a new teacher to both the SQL database and MongoDB.
        /// </summary>
        /// <param name="teacherDto">The teacher data to be added.</param>
        /// <returns>An IActionResult indicating the result of the add operation or an error message.</returns>
        [HttpPost]
        public async Task<IActionResult> AddTeacher([FromBody] TeacherDto teacherDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { StatusCode = 400, Message = "Invalid model state.", Errors = ModelState });
            }

            try
            {
                await _teacherService.AddTeacherAsync(teacherDto);

                return StatusCode(201, new { StatusCode = 201, Message = "Teacher successfully added to both SQL and MongoDB." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, Message = "An internal server error occurred.", Details = ex.Message });
            }
        }
    }
}
