using MongoDB.Driver;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using BirthClinicMongoDB.Domainmodels;
using BirthClinicMongoDB.Repositories.Interfaces;
using MongoDB.Bson;

namespace BirthClinicMongoDB.Repositories
{
    public class AppointmentRepository: BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(IMongoDbContext context) : base(context)
        {
        }

        public Appointment GetSingleAppointment(string id)
        {
            return _dbCollection.Find<Appointment>(a => a.AppointmentBsonId == id).SingleOrDefault();
        }

        public ObservableCollection<Appointment> GetAllAppointments()
        {
            return new ObservableCollection<Appointment>(_dbCollection.Find(new BsonDocument()).ToList()); 
        }

        public void AddAppointment(Appointment app)
        {
           _dbCollection.InsertOne(app);
        }

        public void DelAppointment(Appointment appointment)
        {
            _dbCollection.DeleteOne(a => a.AppointmentBsonId == appointment.AppointmentBsonId);
        }

        public bool AppointmentsExist()
        {
            return _dbCollection.Find(FilterDefinition<Appointment>.Empty).Any();
        }

        public ObservableCollection<Appointment> GetNumberOfAppointments(int n)
        {
            return new ObservableCollection<Appointment>(_dbCollection.Find(x => true).Limit(n).ToList());
        }

        public Appointment ReturnLastAppointment()
        {
            var temp = new ObservableCollection<Appointment>(_dbCollection.Find(new BsonDocument()).ToList());

            int i = temp.Count;

            return temp[i-1];
        }

        public MongoDbContext context
        {
            get { return context as MongoDbContext; }
        }
    }
}
