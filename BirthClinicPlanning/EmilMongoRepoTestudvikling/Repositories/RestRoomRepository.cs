using EmilMongoRepoTestudvikling.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling.Domainmodels;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using Polly;

namespace EmilMongoRepoTestudvikling.Repositories
{
    public class RestRoomRepository: BaseRepository<RestRoom>, IRestRoomRepository
    {
        public RestRoomRepository(IMongoDbContext context) : base(context)
        {

        }

        public ObservableCollection<RestRoom> GetAllRestRoom()
        {
            return new ObservableCollection<RestRoom>(_dbCollection.Find(new BsonDocument()).ToList());
        }

        public RestRoom GetRestRoomWithSpecificNumber(int no)
        {
            return _dbCollection.Find(r => r.RoomNumber == no).SingleOrDefault();
        }

        public RestRoom GetSingleRestRoom(string id)
        {
            return _dbCollection.Find(r => r.RoomID == id).SingleOrDefault();
        }

        public void AddAppointmentToRoom(string roomid, Appointment appointment)
        {
            _dbCollection.Find(r => r.RoomID == roomid).SingleOrDefault().Appointments.Add(appointment);
        }

        public void AddRestRoom(RestRoom restRoom)
        {
            _dbCollection.InsertOne(restRoom);
        }

        public void DelRestRoom(RestRoom restRoom)
        {
            _dbCollection.DeleteOne(r => r.RoomID == restRoom.RoomID);
        }

        public MongoDbContext context
        {
            get { return context as MongoDbContext; }
        }
    }
}
