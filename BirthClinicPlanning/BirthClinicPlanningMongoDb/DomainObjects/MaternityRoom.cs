using BirthClinicPlanningMongoDbWebAPI.Repositories;

namespace BirthClinicPlanningMongoDbWebAPI.DomainObjects
{
    [BsonCollection("MaternityRoom")]
    public class MaternityRoom : Room
    {
        public MaternityRoom() : base()
        {
            base.RoomType = "Maternity Room";
        }
    }
}
