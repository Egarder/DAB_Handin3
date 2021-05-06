using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BirthClinicMongoDB.Domainmodels
{
    public class Clinician
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ClinicianBsonId { get; set; }

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

        [NotMapped]
        public string Display
        {
            get => $"{Type} {FirstName} {LastName}";
        }
    }
}
