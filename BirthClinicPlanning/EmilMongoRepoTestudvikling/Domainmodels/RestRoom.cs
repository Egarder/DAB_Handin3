using MongoDB.Bson.Serialization.Attributes;

namespace EmilMongoRepoTestudvikling.Domainmodels
{
    public class RestRoom : Room
    {
        [BsonDiscriminator("RestRoom")]
        public RestRoom() : base()
        {
            base.RoomType = "Rest Room";
        }
    }
}
