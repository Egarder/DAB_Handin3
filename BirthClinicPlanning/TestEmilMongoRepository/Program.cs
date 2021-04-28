using System;
using EmilMongoRepoTestudvikling;
using EmilMongoRepoTestudvikling.Domainmodels;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace TestEmilMongoRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            IMongoDbSettings settings = new MongoDbSettings();
            settings.ConnectionString = "mongodb://localhost:27017";
            settings.DatabaseName = "BirthClinicPlanning";

            IDataAccessActions access = new DataAccessActions(new MongoDbContext(settings.ConnectionString, settings.DatabaseName));

            IMongoCollection<Appointment> test = access.Appointments.getAllAppointment("Appointment");

            
            foreach (var item in test)
            {
                
            }
        }
    }
}
