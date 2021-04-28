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
    public class Clinician
    {
        [Key]
        public int ClinicianID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Type { get; set; }

        public ObservableCollection<Appointment> Appointments { get; set; }

        [NotMapped]
        public string Display
        {
            get => $"{Type} {FirstName} {LastName}";
        }
    }
}
