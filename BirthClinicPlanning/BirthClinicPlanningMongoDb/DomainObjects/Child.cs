using System;
using System.ComponentModel.DataAnnotations;
using BirthClinicPlanningMongoDbWebAPI.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BirthClinicPlanningMongoDbWebAPI.DomainObjects
{
    [BsonCollection("Child")]
    public class Child: Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ChildID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Weight { get; set; }

        public int Length { get; set; }

        public DateTime BirthDate { get; set; }


        public string DisplayDate { get => BirthDate.ToShortDateString(); set => DateTime.Parse(value); }
    }
}
