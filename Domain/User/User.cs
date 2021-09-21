using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.User
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        [BsonElement("lastname")]
        public string LastName { get; set; }
        [BsonElement("email")]
        public string  Email { get; set; }
        [BsonElement("phonenumber")]
        public string  PhoneNumber { get; set; }
        [BsonElement("username")]
        public string UserName { get; set; }
        [BsonElement("country")]
        public string Country { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
    }
}