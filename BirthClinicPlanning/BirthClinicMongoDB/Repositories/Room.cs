using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Linq;
using BirthClinicMongoDB.Domainmodels;
using BirthClinicMongoDB.Repositories.Interfaces;

namespace BirthClinicMongoDB.Repositories
{
    public class Room: BaseRepository<Room>, IRoomRepository
    {
        public Room(IMongoDbContext context) : base(context)
        {
        }

        public ObservableCollection<Room> GetAllRestRoom()
        {
            return new ObservableCollection<Room>(_dbCollection.Find(new BsonDocument()).ToList());
        }

        public Room GetRestRoomWithSpecificNumber(int no)
        {
            return _dbCollection.Find(r => r.RoomNumber == no).SingleOrDefault();
        }

        public Room GetSingleRestRoom(string id)
        {
            return _dbCollection.Find(r => r.RoomID == id).SingleOrDefault();
        }

        public void AddAppointmentToRoom(string roomid, Appointment appointment)
        {
            _dbCollection.Find(r => r.RoomID == roomid).SingleOrDefault().Appointments.Add(appointment);
        }

        public void AddRestRoom(Room restRoom)
        {
            _dbCollection.InsertOne(restRoom);
        }

        public void DelRestRoom(Room restRoom)
        {
            _dbCollection.DeleteOne(r => r.RoomID == restRoom.RoomID);
        }

        public MongoDbContext context
        {
            get { return context as MongoDbContext; }
        }
    }
}
