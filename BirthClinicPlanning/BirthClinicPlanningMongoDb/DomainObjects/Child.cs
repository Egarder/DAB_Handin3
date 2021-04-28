using BirthClinicPlanningDB.Repositories;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthClinicPlanningDB.DomainObjects
{
    [BsonCollection("Child")]
    public class Child
    {
        [Key]
        public int ChildID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Weight { get; set; }

        public int Length { get; set; }

        public DateTime BirthDate { get; set; }


        public string DisplayDate { get => BirthDate.ToShortDateString(); set => DateTime.Parse(value); }
    }
}
