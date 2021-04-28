using System;
using BirthClinicPlanningMongoDbWebAPI.Repositories;
using MongoDB.Bson;

namespace BirthClinicPlanningMongoDbWebAPI.DomainObjects
{
    [BsonCollection("BirthRoom")]
    public class BirthRoom : Room
    {
        public BirthRoom() : base()
        {
            base.RoomType = "Birth Room";
        }

        public ObjectId Id { get; set; }
        public DateTime CreatedAt { get; }
    }
}