using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EmilMongoRepoTestudvikling.Domainmodels
{
    public class Parents
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
        public Child Child { get; set; }
    }
}
