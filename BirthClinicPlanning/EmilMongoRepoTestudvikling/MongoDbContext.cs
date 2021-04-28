using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EmilMongoRepoTestudvikling
{
    public class MongoDbContext:IMongoDbContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoDbContext(string connectionstring, string databasename)
        {
            _mongoClient = new MongoClient(connectionstring);
            _db = _mongoClient.GetDatabase(databasename);
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }

        public List<string> listDatabases()
        {
            var dblist = _mongoClient.ListDatabases().ToList();

            List<string> stringretur = new List<string>();

            foreach (var VARIABLE in dblist)
            {
                stringretur.Add(VARIABLE.ToJson());
            }

            return stringretur;
        }
    }
}
