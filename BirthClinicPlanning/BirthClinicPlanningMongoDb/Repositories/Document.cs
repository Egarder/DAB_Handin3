using System;
using BirthClinicPlanningMongoDbWebAPI.Repositories.RepositoryInterfaces;
using MongoDB.Bson;

namespace BirthClinicPlanningMongoDbWebAPI.Repositories
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
