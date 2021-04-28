using BirthClinicPlanningDB.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthClinicPlanningDB.DomainObjects
{
    [BsonCollection("Room")]
    public class Room
    {
        public int RoomID { get; set; }

        public int RoomNumber { get; set; }

        public string RoomType { get; set; }

        public bool Occupied { get; set; }

        //[ForeignKey("AppointmentID")]
        public ObservableCollection<Appointment> Appointments { get; set; }
    }
}