using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling;
using EmilMongoRepoTestudvikling.Domainmodels;
using EmilMongoRepoTestudvikling.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
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

            //var test = access.Appointments.getSingleAppointments("1");
            //Console.WriteLine($"{test.AppointmentID}");


            var test2 = access.Appointments.getAllAppointments();

            foreach (var item in test2)
            {
                Console.WriteLine($"{item.AppointmentID}");
            }

        }

    }
}
