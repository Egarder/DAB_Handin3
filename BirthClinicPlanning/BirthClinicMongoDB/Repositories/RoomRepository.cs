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

        public ObservableCollection<Room> GetAllBirthRooms()
        {
            return new ObservableCollection<Room>(_dbCollection.Find(r => r.RoomType == "BirthRoom").ToList());
        }

        public ObservableCollection<Room> GetAllRestRooms()
        {
            return new ObservableCollection<Room>(_dbCollection.Find(r => r.RoomType == "RestRoom").ToList());
        }

        public ObservableCollection<Room> GetAllMaternityRooms()
        {
            return new ObservableCollection<Room>(_dbCollection.Find(r => r.RoomType == "MaternityRoom").ToList());
        }

        public Room GetBirthRoomWithSpecificNumber(int no)
        {
            return _dbCollection.Find(r => r.RoomType == "BirthRoom" && r.RoomNumber == no).SingleOrDefault();
        }

        public Room GetRestRoomWithSpecificNumber(int no)
        {
            return _dbCollection.Find(r => r.RoomType == "RestRoom" && r.RoomNumber == no).SingleOrDefault();
        }

        public Room GetMaternityRoomWithSpecificNumber(int no)
        {
            return _dbCollection.Find(r => r.RoomType == "MaternityRoom" && r.RoomNumber == no).SingleOrDefault();
        }

        public Room GetSingleRoom(string id)
        {
            return _dbCollection.Find(r => r.RoomBsonID == id).SingleOrDefault();
        }

        public void DelRestRoom(Room room)
        {
            throw new System.NotImplementedException();
        }

        public void AddAppointmentToRoom(string roomid, Appointment appointment)
        {
            _dbCollection.Find(r => r.RoomID == roomid).SingleOrDefault().Appointments.Add(appointment);
        }


        public void AddRoom(Room room)
        {
            _dbCollection.InsertOne(room);
        }

        public bool RoomsExist()
        {
            return _dbCollection.Find(FilterDefinition<Room>.Empty).Any();
        }

        public void DelRoom(Room room)
        {
            _dbCollection.DeleteOne(r => r.RoomID == room.RoomID);
        }

        public void UpdateRoom(Room room, Appointment appointment)
        {
            var update = Builders<Room>.Update
                .Push<Appointment>(e => e.Appointments, appointment);

            _dbCollection.UpdateOne(r => r.RoomBsonID == room.RoomBsonID, update);

            //_dbCollection.ReplaceOne(r => r.RoomID == room.RoomID, room);
        }

        public MongoDbContext context
        {
            get { return context as MongoDbContext; }
        }
    }
}
