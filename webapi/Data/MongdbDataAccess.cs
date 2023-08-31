using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace webapi.DataAccess
{
    public class MongoDataAccess
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDataAccess(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _mongoDatabase = client.GetDatabase(databaseName);
        }

        public int GetLastSavedEndWip()
        {
            var collection = _mongoDatabase.GetCollection<MongoNumberModel>("EndWipData");
            var latestDocument = collection.Find(new BsonDocument())
                                           .Sort(Builders<MongoNumberModel>.Sort.Descending(d => d.Timestamp))
                                           .Limit(1)
                                           .FirstOrDefault();

            if (latestDocument != null && int.TryParse(latestDocument.Value, out int result))
            {
                return result;
            }

            return 0; // Return 0 if no document is found or if the value isn't an integer
        }


        // Add more methods for other MongoDB interactions as needed
    }

    public class MongoNumberModel
    {
        public ObjectId Id { get; set; }
        public string Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
