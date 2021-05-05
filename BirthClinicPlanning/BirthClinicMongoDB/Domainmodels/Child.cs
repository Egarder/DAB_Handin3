using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BirthClinicMongoDB.Domainmodels
{
    public class Child
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("ChildID")]
        [JsonProperty("ChildID")]
        public string ChildID { get; set; }

        [BsonElement("FirstName")]
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [BsonElement("Weight")]
        [JsonProperty("Weight")]
        public int Weight { get; set; }

        [BsonElement("Length")]
        [JsonProperty("Length")]
        public int Length { get; set; }

        [BsonElement("BirthDate")]
        [JsonProperty("BirthDate")]
        public DateTime BirthDate { get; set; }


        public string DisplayDate { get => BirthDate.ToShortDateString(); set => DateTime.Parse(value); }
    }
}
