using MongoDB.Driver;
using System.Collections.Generic;

namespace BirthClinicMongoDB
{
    public interface IMongoDbContext
    {
        IMongoCollection<Appointment> GetCollection<Appointment>(string name);

        public List<string> listDatabases();
    }
}
