using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace EmilMongoRepoTestudvikling.Domainmodels
{
    public class Clinician
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("ClinicianID")]
        [JsonProperty("ClinicianID")]
        public string ClinicianID { get; set; }

        [BsonElement("FirstName")]
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [BsonElement("Type")]
        [JsonProperty("Type")]
        public string Type { get; set; }

        [BsonElement("Appointments")]
        [JsonProperty("Appointments")]
        public ObservableCollection<Appointment> Appointments { get; set; }

        [NotMapped]
        public string Display
        {
            get => $"{Type} {FirstName} {LastName}";
        }
    }
}
