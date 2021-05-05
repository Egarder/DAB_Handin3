using System;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling;
using EmilMongoRepoTestudvikling.Domainmodels;
using EmilMongoRepoTestudvikling.Repositories;
using EmilMongoRepoTestudvikling.Repositories.Interfaces;
using Json.Net;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Extensions;
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

            IBirthRoomRepository testBirthRoomRepository = new BirthRoomRepository(context);

            var roomToInsert = new BirthRoom()
            {
                Appointments = new ObservableCollection<Appointment>(), 
                RoomNumber = 2,
                RoomType = "BirthRoom"
            };

            //testBirthRoomRepository.AddBirthRoom(roomToInsert);

            //var roomToPrint = testBirthRoomRepository.GetSingleBirthRoom("6092562a010aee0d36787cce");

            //Console.WriteLine($"{roomToPrint.RoomNumber}, {roomToPrint.Occupied}, {roomToPrint.RoomType}");

            var roomsToPrint = testBirthRoomRepository.GetAllBirthsRooms();

            foreach (var room in roomsToPrint)
            {
                Console.WriteLine($"{room.RoomNumber}, {room.Occupied}, {room.RoomType}");
            }

            ////==== DB context test = Works! ====================================================
            //var databaser = context.listDatabases();

            //foreach (var item in databaser)
            //{
            //    Console.WriteLine($"{item}");
            //}


            ////===== Test af Appointment Repository getallappointments og update = Almost works....=====================

            //var list = access.Appointments.getAllAppointments();
            //foreach (var item in list)
            //{
            //access.Appointments.Update(item.AppointmentID, item);
            //Console.WriteLine(item.AppointmentID);
            //}

            ////===== Test af Appointment Repository getsingleappointment = Works!   But needs more methods....=====================

            //var tester = access.Appointments.getSingleAppointment("5");

            //Console.WriteLine(tester.StartTime);

            //=======Test af getAllAppointmentsmetoder====

            //var tester2 = access.Appointments.getAllAppointments2();

            //foreach (var item in tester2)
            //{
            //    Console.WriteLine($"{item.AppointmentID}");
            //}

            //==== Test af Appointment Repo create = Works!========================================
            //Appointment newapp = new Appointment()
            //{
            //    AppointmentID = "5",
            //    Parents = new Parents() { DadCPR = "2003922955", DadFirstName = "Thom", DadLastName = "Poulsen", MomCPR = "2003922955", MomFirstName = "Karin", MomLastName = "poulsen" },
            //    Room = new BirthRoom() { RoomNumber = 1},
            //    StartTime = Convert.ToDateTime("29-04-2021"),
            //    EndTime = Convert.ToDateTime("30-04-2021")
            //};
            //access.Appointments.AddAppointment(newapp);

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
