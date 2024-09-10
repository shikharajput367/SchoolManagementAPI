namespace Repository.Entities
{
    /// <summary>
    /// Represents a course entity in the SQL database.
    /// This entity contains details about a course, including its ID, title, and the associated teacher.
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Gets or sets the unique identifier for the course.
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Gets or sets the title of the course.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the teacher associated with the course.
        /// </summary>
        public int TeacherId { get; set; }

        /// <summary>
        /// Gets or sets the teacher entity associated with the course.
        /// </summary>
        public Teacher Teacher { get; set; }
    }
}
