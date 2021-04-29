using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public Appointment getSingleAppointments(string id) =>
            _dbCollection.Find(appointment => appointment.AppointmentID.ToIndentedJson() == id).FirstOrDefault();

        public List<Appointment> getAllAppointments() =>
            _dbCollection.Find(Appointment => true).ToList(); //Exception med ID kommer her. 

        public void Update(string id, Appointment appIn) =>
            _dbCollection.ReplaceOne(app => app.AppointmentID == id, appIn);

        public void AddAppointment(Appointment app)
        {
           _dbCollection.InsertOne(app);
        }

        public MongoDbContext context
        {
            get { return context as MongoDbContext; }
        }
    }
}
