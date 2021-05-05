using MongoDB.Bson.Serialization.Attributes;

namespace BirthClinicMongoDB.Domainmodels
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
