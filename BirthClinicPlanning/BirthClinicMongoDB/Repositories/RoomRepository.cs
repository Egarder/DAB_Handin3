using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Linq;
using BirthClinicMongoDB.Domainmodels;
using BirthClinicMongoDB.Repositories.Interfaces;

namespace BirthClinicMongoDB.Repositories
{
    public class RoomRepository: BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(IMongoDbContext context) : base(context)
        {
        }

        public ObservableCollection<Room> GetAllRooms()
        {
            return new ObservableCollection<Room>(_dbCollection.Find(new BsonDocument()).ToList());
        }

        public Room GetRoomWithSpecificNumber(int no)
        {
            return _dbCollection.Find(r => r.RoomNumber == no).SingleOrDefault();
        }

        public Room GetSingleRoom(string id)
        {
            return _dbCollection.Find(r => r.RoomID == id).SingleOrDefault();
        }

        public void AddAppointmentToRoom(string roomid, Appointment appointment)
        {
            _dbCollection.Find(r => r.RoomID == roomid).SingleOrDefault().Appointments.Add(appointment);
        }

        public void AddRestRoom(Room room)
        {
            _dbCollection.InsertOne(room);
        }

        public void DelRoom(Room room)
        {
            _dbCollection.DeleteOne(r => r.RoomID == room.RoomID);
        }

        public MongoDbContext context
        {
            get { return context as MongoDbContext; }
        }
    }
}
