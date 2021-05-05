using MongoDB.Bson.Serialization.Attributes;

namespace BirthClinicMongoDB.Domainmodels
{
    [BsonDiscriminator("BirthRoom")]
    public class BirthRoom : Room
    {
        public BirthRoom() : base()
        {
            base.RoomType = "Birth Room";
        }
    }
}