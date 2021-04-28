using System;
using BirthClinicPlanningMongoDbWebAPI;
using BirthClinicPlanningMongoDbWebAPI.DomainObjects;
using BirthClinicPlanningMongoDbWebAPI.Repositories;
using BirthClinicPlanningMongoDbWebAPI.Repositories.Controllers;
using BirthClinicPlanningMongoDbWebAPI.Repositories.RepositoryInterfaces;

namespace MongoRepositoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoDbSettings setting = new MongoDbSettings();

            setting.DatabaseName = "BirthClinicPlanning";
            setting.ConnectionString = "mongodb://localhost:27017";

            MongoRepository<Appointment> repo = new MongoRepository<Appointment>(setting);

            AppointmentController controller = new AppointmentController(repo);


        }
    }
}
