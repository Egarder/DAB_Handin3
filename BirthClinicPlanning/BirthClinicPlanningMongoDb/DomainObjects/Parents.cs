using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BirthClinicPlanningMongoDbWebAPI.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BirthClinicPlanningMongoDbWebAPI.DomainObjects
{
    [BsonCollection("Parents")]
    public class Parents: Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ParentsID { get; set; }

        public string MomCPR { get; set; }

        public string MomFirstName { get; set; }

        public string MomLastName { get; set; }

        public string DadCPR { get; set; }

        public string DadFirstName { get; set; }

        public string DadLastName { get; set; }

        [ForeignKey("ChildID")]
        public Child Child { get; set; }
    }
}
