using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FoodMartMongo.Entities
{
    public class Discount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DiscountId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description  { get; set; }
        public string ImageUrl { get; set; }
    }
}
