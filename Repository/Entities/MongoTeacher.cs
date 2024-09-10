using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Repository.Entities
{
    /// <summary>
    /// Represents a teacher entity in the MongoDB database.
    /// This class contains details about a teacher, including their ID, name, and the list of courses they teach.
    /// </summary>
    public class MongoTeacher
    {
        /// <summary>
        /// Gets or sets the unique identifier for the teacher in MongoDB.
        /// MongoDB uses a string representation of ObjectId for unique IDs.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }  // MongoDB uses string IDs (ObjectId)

        /// <summary>
        /// Gets or sets the name of the teacher.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of courses taught by the teacher.
        /// </summary>
        public List<MongoCourse> Courses { get; set; }
    }
}
