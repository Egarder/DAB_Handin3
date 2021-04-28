using System.Collections.ObjectModel;
using BirthClinicPlanningMongoDbWebAPI.Repositories;

namespace BirthClinicPlanningMongoDbWebAPI.DomainObjects
{
    [BsonCollection("Room")]
    public class Room: Document
    {
        public int RoomID { get; set; }

        public int RoomNumber { get; set; }

        public string RoomType { get; set; }

        public bool Occupied { get; set; }

        //[ForeignKey("AppointmentID")]
        public ObservableCollection<Appointment> Appointments { get; set; }
    }
}