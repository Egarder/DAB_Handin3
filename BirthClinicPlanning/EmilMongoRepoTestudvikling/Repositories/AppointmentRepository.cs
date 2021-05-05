using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling.Domainmodels;
using EmilMongoRepoTestudvikling.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using NetFusion.Common.Extensions;

namespace EmilMongoRepoTestudvikling.Repositories
{
    public class AppointmentRepository: BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(IMongoDbContext context) : base(context)
        {
        }

        public Appointment GetSingleAppointment(string id)
        {
            var projection = Builders<Appointment>.Projection.Include(b => b.AppointmentID).Include(c=>c.RoomID)
                .Include(d=>d.StartTime)
                .Include(e=>e.EndTime)
                .Include(f=>f.Room); //Add other properties

            var bson = _dbCollection.Find<Appointment>(app => app.AppointmentID == id).Project(projection)
                .FirstOrDefault();

            var tempobj = new Appointment()
            {
                AppointmentID = bson.GetElement("AppointmentID").Value.AsString,
                RoomID = bson.GetElement("RoomID").Value.AsInt32,
                StartTime = (DateTime) bson.GetElement("StartTime").Value,
                EndTime = (DateTime) bson.GetElement("EndTime").Value,
                Room = new Room() {RoomNumber = bson.GetElement("Room: {RoomNumber}").Value.AsInt32 }
            };

            return tempobj;
        }

        public ObservableCollection<Appointment> GetAllAppointments()
        {
            return new ObservableCollection<Appointment>(_dbCollection.Find(new BsonDocument()).ToList());
        }

        public void Update(string id, Appointment appIn) =>
            _dbCollection.ReplaceOne(app => app.AppointmentID == id, appIn);

        public void AddAppointment(Appointment app)
        {
           _dbCollection.InsertOne(app);
        }

        public void DelAppointment(Appointment appointment)
        {
            var id = appointment.AppointmentID;
            var objectid = new ObjectId(id);

            _dbCollection.DeleteOneAsync(Builders<Appointment>.Filter.Eq("_id", objectid));
        }

        public MongoDbContext context
        {
            get { return context as MongoDbContext; }
        }
    }
}
