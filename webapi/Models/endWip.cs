using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace webapi.Data
{
    [BsonCollection("endWipCollection")]
    public class endWip
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("Value")]
        public string Value { get; set; }

        [BsonElement("Timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
