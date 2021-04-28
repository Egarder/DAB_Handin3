using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling.Domainmodels;
using EmilMongoRepoTestudvikling.Repositories.Interfaces;
using MongoDB.Driver;

namespace EmilMongoRepoTestudvikling.Repositories
{
    public class AppointmentRepository: BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(IMongoDbContext context) : base(context)
        {
        }

        public IMongoCollection<Appointment> getAllAppointment(string collectionname)
        {
            var temp = context.GetCollection<Appointment>(collectionname);

            return temp;

        }

        public MongoDbContext context
        {
            get { return context as MongoDbContext; }
        }
    }
}
