using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BirthClinicMongoDB.Domainmodels
{
    public class Parents
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("ParentsID")]
        [JsonProperty("ParentsID")]
        public string ParentsID { get; set; }

        [BsonElement("MomCPR")]
        [JsonProperty("MomCPR")]
        public string MomCPR { get; set; }

        [BsonElement("MomFirstName")]
        [JsonProperty("MomFirstName")]
        public string MomFirstName { get; set; }

        [BsonElement("MomLastName")]
        [JsonProperty("MomLastName")]
        public string MomLastName { get; set; }

        [BsonElement("DadCPR")]
        [JsonProperty("DadCPR")]
        public string DadCPR { get; set; }

        [BsonElement("DadFirstName")]
        [JsonProperty("DadFirstName")]
        public string DadFirstName { get; set; }

        [BsonElement("DadLastName")]
        [JsonProperty("DadLastName")]
        public string DadLastName { get; set; }

        [BsonElement("Child")]
        [JsonProperty("Child")]
        public Child Child { get; set; }
    }
}
