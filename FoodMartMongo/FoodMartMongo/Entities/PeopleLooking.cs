using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FoodMartMongo.Entities
{
   
    public class PeopleLooking
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PeopleLookingId { get; set; }
        public string Title { get; set; }
    }
}
