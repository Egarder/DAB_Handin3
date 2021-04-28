using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BirthClinicPlanningMongoDbWebAPI.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BirthClinicPlanningMongoDbWebAPI.DomainObjects
{
    [BsonCollection("Clinician")]
    public class Clinician: Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ClinicianID { get; set; }

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
