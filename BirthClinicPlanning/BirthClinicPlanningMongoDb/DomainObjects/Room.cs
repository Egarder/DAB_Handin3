using System.Collections.ObjectModel;
using BirthClinicPlanningMongoDbWebAPI.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BirthClinicPlanningMongoDbWebAPI.DomainObjects
{
    [BsonCollection("Room")]
    public class Room: Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string RoomID { get; set; }

        public int RoomNumber { get; set; }

        public string RoomType { get; set; }

        public bool Occupied { get; set; }

        //[ForeignKey("AppointmentID")]
        public ObservableCollection<Appointment> Appointments { get; set; }
    }
}