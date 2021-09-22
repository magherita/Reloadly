using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Foundation
{
    public class Foundation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Events { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsVerified { get; set; }
        public Niche  Niche { get; set; }
        public Location.Location Location { get; set; }
    }

    public enum Niche
    {
        Education = 1,
        ChildCare = 2,
        ReliefAid = 3,
        GirlChild =4,
        HealthCare = 5
    }
}