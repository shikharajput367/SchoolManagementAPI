namespace Abstractions.DTOs
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for a teacher.
    /// This DTO contains the name of the teacher and a list of courses they teach.
    /// </summary>
    public class TeacherDto
    {
        /// <summary>
        /// Gets or sets the name of the teacher.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of courses taught by the teacher.
        /// </summary>
        public List<CourseDto> Courses { get; set; }
    }
}
