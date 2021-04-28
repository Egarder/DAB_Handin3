using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EmilMongoRepoTestudvikling.Domainmodels
{
    public class Clinician
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
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
