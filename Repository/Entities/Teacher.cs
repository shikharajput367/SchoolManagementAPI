namespace Repository.Entities
{
    /// <summary>
    /// Represents a teacher entity in the SQL database.
    /// This entity contains details about a teacher, including their ID, name, and the courses they teach.
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// Gets or sets the unique identifier for the teacher.
        /// </summary>
        public int TeacherId { get; set; }

        /// <summary>
        /// Gets or sets the name of the teacher.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of courses taught by the teacher.
        /// </summary>
        public ICollection<Course> Courses { get; set; }
    }
}
