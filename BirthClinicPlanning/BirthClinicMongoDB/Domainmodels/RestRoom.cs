using MongoDB.Bson.Serialization.Attributes;

namespace EmilMongoRepoTestudvikling.Domainmodels
{
    [BsonDiscriminator("RestRoom")]
    public class RestRoom : Room
    {
        public RestRoom() : base()
        {
            base.RoomType = "Rest Room";
        }
    }
}
