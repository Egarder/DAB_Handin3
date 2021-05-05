using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling.Domainmodels;
using EmilMongoRepoTestudvikling.Repositories;
using EmilMongoRepoTestudvikling.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Polly;

namespace EmilMongoRepoTestudvikling.Repositories
{
    public class BirthRoomRepository : BaseRepository<BirthRoom>, IBirthRoomRepository
    {
        public BirthRoomRepository(IMongoDbContext context) : base(context)
        {
        }

        public ObservableCollection<BirthRoom> GetAllBirthsRooms()
        {
            return new ObservableCollection<BirthRoom>(_dbCollection.Find(new BsonDocument()).ToList());
        }

        public BirthRoom GetBirthRoomWithSpecificNumber(int no)
        {
            return _dbCollection.Find(r => r.RoomNumber == no).SingleOrDefault();
        }


        public BirthRoom GetSingleBirthRoom(string id)
        {
            return _dbCollection.Find(r => r.RoomID == id).SingleOrDefault();
        }

        public void AddBirthRoom(BirthRoom room)
        {
            _dbCollection.InsertOne(room);
        }

        public MongoDbContext context
        {
            get { return context as MongoDbContext; }
        }
    }
}
