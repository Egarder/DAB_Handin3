using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace EmilMongoRepoTestudvikling
{
    public interface IMongoDbContext
    {
        IMongoCollection<Appointment> GetCollection<Appointment>(string name);

        public List<string> listDatabases();
    }
}
