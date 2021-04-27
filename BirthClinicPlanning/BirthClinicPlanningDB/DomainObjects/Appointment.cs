using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.DomainObjects
{
    public class Appointment
    {
        [Key] 
        public int AppointmentID { get; set; }

        [ForeignKey("RoomID")]
        public int RoomID { get; set; }

        public Room Room { get; set; }

        [ForeignKey("ParentsID")]
        public Parents Parents { get; set; }

        [ForeignKey("ChildID")]
        public Child Child { get; set; }

        public ObservableCollection<Clinician> Clinicians { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [NotMapped]
        public string DisplayStartDateTime
        {
            get => StartTime.ToString("g");
            set => StartTime = DateTime.Parse(value);
        }

        [NotMapped]
        public string DisplayEndDateTime
        {
            get => EndTime.ToString("g");
            set => EndTime = DateTime.Parse(value);
        }

        [NotMapped]
        public string BookedFor
        {
            get => $"{(EndTime - StartTime).Days} days - {(EndTime - StartTime).Hours} hours";
        }
    }
}
