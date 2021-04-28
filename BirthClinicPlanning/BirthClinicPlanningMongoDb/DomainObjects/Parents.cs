using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BirthClinicPlanningMongoDbWebAPI.Repositories;

namespace BirthClinicPlanningMongoDbWebAPI.DomainObjects
{
    [BsonCollection("Parents")]
    public class Parents: Document
    {
        [Key]
        public int ParentsID { get; set; }

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
