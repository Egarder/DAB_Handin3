using System.Collections.Generic;
using System.Collections.ObjectModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace EmilMongoRepoTestudvikling.Domainmodels
{
    public class Room
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("RoomID")]
        [JsonProperty("RoomID")]
        public string RoomID { get; set; }

        [BsonElement("RoomNumber")]
        [JsonProperty("RoomNumber")]
        public int RoomNumber { get; set; }

        [BsonElement("RoomType")]
        [JsonProperty("RoomType")]
        public string RoomType { get; set; }

        [BsonElement("Occupied")]
        [JsonProperty("Occupied")]
        public bool Occupied { get; set; }

        [BsonElement("Appointments")]
        [JsonProperty("RoAppointmentsomID")]
        public ObservableCollection<Appointment> Appointments { get; set; }
    }
}