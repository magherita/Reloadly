using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Donation
{
    public class Donation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Email { get; set; }
        public string  PhoneNumber { get; set; }
        public string Password { get; set; }
        public  Location.Location Location{ get; set; }
        public string Amount { get; set; }
    }
}