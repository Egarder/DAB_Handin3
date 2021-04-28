using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BirthClinicPlanningMongoDbWebAPI.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BirthClinicPlanningMongoDbWebAPI.DomainObjects
{
    [BsonCollection("Appointment")]
    public class Appointment: Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int AppointmentID { get; set; }

        [BsonElement("RoomID")]
        [JsonProperty("RoomID")]
        public int RoomID { get; set; }

        [BsonElement("Room")]
        [JsonProperty("Room")]
        public Room Room { get; set; }

        [BsonElement("Parents")]
        [JsonProperty("Parents")]
        public Parents Parents { get; set; }

        [BsonElement("Child")]
        [JsonProperty("Child")]
        public Child Child { get; set; }

        [BsonElement("Clinicians")]
        [JsonProperty("Clinicians")]
        public ObservableCollection<Clinician> Clinicians { get; set; }

        [BsonElement("StartTime")]
        [JsonProperty("StartTime")]
        public DateTime StartTime { get; set; }

        [BsonElement("EndTime")]
        [JsonProperty("EndTime")]
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
