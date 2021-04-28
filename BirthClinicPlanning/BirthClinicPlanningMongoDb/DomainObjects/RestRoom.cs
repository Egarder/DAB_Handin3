using BirthClinicPlanningMongoDbWebAPI.Repositories;

namespace BirthClinicPlanningMongoDbWebAPI.DomainObjects
{
    [BsonCollection("RestRoom")]
    public class RestRoom : Room
    {
        public RestRoom() : base()
        {
            base.RoomType = "Rest Room";
        }
    }
}
