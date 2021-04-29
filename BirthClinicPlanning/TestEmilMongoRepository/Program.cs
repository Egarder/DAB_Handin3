using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling;
using EmilMongoRepoTestudvikling.Domainmodels;
using EmilMongoRepoTestudvikling.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.IO;
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
            var context = new MongoDbContext(settings.ConnectionString, settings.DatabaseName);

            IDataAccessActions access = new DataAccessActions(context);

            ////==== DB context test = Works!
            //var databaser = context.listDatabases();

            //foreach (var item in databaser)
            //{
            //    Console.WriteLine($"{item}");
            //}


            ////===== Test af Appointment Repository Update = Almost works....
            //var list = access.Appointments.getAllAppointments();

            //foreach (var item in list)
            //{
            //    access.Appointments.Update(item.AppointmentID, item);
            //    Console.WriteLine(item);
            //}

            //==== Test af Appointment Repo create = 

            Appointment newapp = new Appointment()
            {
                AppointmentID = "4",
                Parents = new Parents() {DadCPR = "2003922955", DadFirstName = "Thom",DadLastName = "Poulsen",MomCPR = "2003922955", MomFirstName = "Karin",MomLastName = "poulsen"},
                StartTime = Convert.ToDateTime("29-04-2021"),
                EndTime = Convert.ToDateTime("30-04-2021")
            };

            access.Appointments.AddAppointment(newapp);

            //var test = access.Appointments.getSingleAppointments("6089acf4895344269ca820ec");
            //Console.WriteLine($"{test.ToJson()}");


            //var test2 = access.Appointments.getAllAppointments();

            //foreach (var item in test2)
            //{
            //    Console.WriteLine($"{item.AppointmentID}");
            //}

        }

    }
}
