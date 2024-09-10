using MongoDB.Driver;
using Repository.Entities;

namespace Repository
{
    /// <summary>
    /// Represents the MongoDB database context for accessing collections.
    /// This context provides access to the Teachers and Courses collections within the MongoDB database.
    /// </summary>
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoClient mongoClient, string databaseName)
        {
            _database = mongoClient.GetDatabase(databaseName);
        }

        public IMongoCollection<MongoTeacher> Teachers
            => _database.GetCollection<MongoTeacher>("Teachers");

        public IMongoCollection<MongoCourse> Courses
            => _database.GetCollection<MongoCourse>("Courses");
    }
}
