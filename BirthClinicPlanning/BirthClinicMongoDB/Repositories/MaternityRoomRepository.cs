using BirthClinicMongoDB.Domainmodels;
using BirthClinicMongoDB.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Linq;

namespace BirthClinicMongoDB.Repositories
{
    public class MaternityRoomRepository: BaseRepository<MaternityRoom>, IMaternityRoomRepository
    {
        public MaternityRoomRepository(IMongoDbContext context) : base(context)
        {

        }
        public void AddAppointmentToRoom(string roomid, Appointment appointment)
        {
            _dbCollection.Find(r => r.RoomID == roomid).SingleOrDefault().Appointments.Add(appointment);
        }

        public void AddMaternity(MaternityRoom maternityRoom)
        {
            _dbCollection.InsertOne(maternityRoom);
        }

        public ObservableCollection<MaternityRoom> GetAllMaternityRooms()
        {
            return new ObservableCollection<MaternityRoom>(_dbCollection.Find(new BsonDocument()).ToList());
        }

        public MaternityRoom GetMaternityRoomWithSpecificNumber(int no)
        {
            return _dbCollection.Find(r => r.RoomNumber == no).SingleOrDefault();
        }

        public MaternityRoom GetSingleMaternityRoom(string id)
        {
            return _dbCollection.Find(r => r.RoomID == id).SingleOrDefault();
        }
    }
}
