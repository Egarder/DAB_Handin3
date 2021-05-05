using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BirthClinicMongoDB.Domainmodels;

namespace BirthClinicMongoDB
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }

        public MongoDbContext(string connectionstring, string databasename)
        {
            _mongoClient = new MongoClient(connectionstring);
            _db = _mongoClient.GetDatabase(databasename);
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }

        public List<string> listDatabases()
        {
            var dblist = _mongoClient.ListDatabases().ToList();

            List<string> stringretur = new List<string>();

            foreach (var VARIABLE in dblist)
            {
                stringretur.Add(VARIABLE.ToJson());
            }

            return stringretur;
        }

        public void Seed(IDataAccessActions context)
        {
            SeedClinicians(context);

            SeedRooms(context);

            SeedAppointments(context);
        }

        private static void SeedAppointments(IDataAccessActions modelBuilder)
        {
            var appointments = new ObservableCollection<Appointment>
            {
                new Appointment
                {
                    AppointmentID = "1",
                    StartTime = new DateTime(2021,06,07),
                    EndTime = new DateTime(2021,06,08),
                },

                new Appointment
                {
                    AppointmentID = "2",
                    StartTime = new DateTime(2021,07,08),
                    EndTime = new DateTime(2021,07,09),
                }

            };

            foreach (var app in appointments)
            {
                modelBuilder.Appointments.AddAppointment(app);
            }
        }

        private static void SeedClinicians(IDataAccessActions modelBuilder)
        {
            var clinicians = new ObservableCollection<Clinician>
            {
                new Clinician
                {
                    ClinicianID = "1",
                    FirstName = "Camilla",
                    LastName = "Holmstoel",
                    Type = "Doctor"
                },
                new Clinician
                {
                    ClinicianID = "2",
                    FirstName = "Thomas",
                    LastName = "Daugaard",
                    Type = "Doctor"
                },
                new Clinician
                {
                    ClinicianID = "3",
                    FirstName = "Emil",
                    LastName = "Garder",
                    Type = "Doctor"
                },
                new Clinician
                {
                    ClinicianID = "4",
                    FirstName = "Camilla",
                    LastName = "Boesen",
                    Type = "Doctor"
                },
                new Clinician
                {
                    ClinicianID = "5",
                    FirstName = "Thomas",
                    LastName = "Boesen",
                    Type = "Doctor"
                },
                new Clinician
                {
                  ClinicianID = "6",
                  FirstName = "Emil",
                  LastName = "Boesen",
                  Type = "Secretary"
                },
                new Clinician
                {
                    ClinicianID = "7",
                    FirstName = "Camilla",
                    LastName = "Mikkelsen",
                    Type = "Secretary"
                },
                new Clinician
                {
                    ClinicianID = "8",
                    FirstName = "Thomas",
                    LastName = "Mikkelsen",
                    Type = "Secretary"
                },
                new Clinician
                {
                    ClinicianID = "9",
                    FirstName = "Emil",
                    LastName = "Mikkelsen",
                    Type = "Secretary"
                },
                new Clinician
                {
                    ClinicianID = "10",
                    FirstName = "Camilla",
                    LastName = "Overgaard",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "11",
                    FirstName = "Thomas",
                    LastName = "Overgaard",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "12",
                    FirstName = "Emil",
                    LastName = "Overgaard",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "13",
                    FirstName = "Jørgen",
                    LastName = "Poulsen",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "14",
                    FirstName = "Jan",
                    LastName = "Hellesøe",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "15",
                    FirstName = "Lonny",
                    LastName = "Luderhår",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "16",
                    FirstName = "Sleske",
                    LastName = "Svend",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "17",
                    FirstName = "Bo",
                    LastName = "Bedre",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "18",
                    FirstName = "Tåløse",
                    LastName = "Tomme",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "19",
                    FirstName = "Linée",
                    LastName = "Havnedronning",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "20",
                    FirstName = "Kirsten",
                    LastName = "Nedersø",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "21",
                    FirstName = "Kathrine",
                    LastName = "Klit",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "22",
                    FirstName = "Richard",
                    LastName = "Rust",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "23",
                    FirstName = "Garn",
                    LastName = "Svensker",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "24",
                    FirstName = "Hans",
                    LastName = "Haard",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "25",
                    FirstName = "Benny",
                    LastName = "Balsam",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "26",
                    FirstName = "Lone",
                    LastName = "Large",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "27",
                    FirstName = "Mads",
                    LastName = "Middelmådig",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "28",
                    FirstName = "Knud",
                    LastName = "Kattekilling",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "29",
                    FirstName = "Ine",
                    LastName = "Indelukket",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = "30",
                    FirstName = "Kvart",
                    LastName = "Palle",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "31",
                    FirstName = "Yda",
                    LastName = "Ydermeget",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "32",
                    FirstName = "Carla",
                    LastName = "Carletti",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "33",
                    FirstName = "Inge",
                    LastName = "Ingenveddet",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "34",
                    FirstName = "Kim",
                    LastName = "Karate",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "35",
                    FirstName = "Ymer",
                    LastName = "Johansen",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "36",
                    FirstName = "Uno",
                    LastName = "Dos Tres",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "37",
                    FirstName = "Gunnar",
                    LastName = "Big Gun",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "38",
                    FirstName = "Keine",
                    LastName = "Inspiration",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "39",
                    FirstName = "Heinz",
                    LastName = "Heino",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "40",
                    FirstName = "Mogens",
                    LastName = "Morgensur",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "41",
                    FirstName = "Bolette",
                    LastName = "Børnelokker",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "42",
                    FirstName = "Line",
                    LastName = "Linedanser",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "43",
                    FirstName = "Mikkel",
                    LastName = "Pampers",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "44",
                    FirstName = "Toke",
                    LastName = "Son of Loke",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "45",
                    FirstName = "Svetlana",
                    LastName = "From Havanna",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "46",
                    FirstName = "Arne",
                    LastName = "Analfabet",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "47",
                    FirstName = "Sir",
                    LastName = "Elton John",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "48",
                    FirstName = "Queen",
                    LastName = "Bee",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "49",
                    FirstName = "Frank",
                    LastName = "BodHoldt Jakobsen",
                    Type = "Nurse"
                },
                new Clinician
                {
                    ClinicianID = "50",
                    FirstName = "Dine",
                    LastName = "The deliverer",
                    Type = "Midwife"
                },
                new Clinician
                {
                    ClinicianID = "51",
                    FirstName = "Bjørk",
                    LastName = "Babypuller",
                    Type = "Midwife"
                },
                new Clinician
                {
                    ClinicianID = "52",
                    FirstName = "Puk",
                    LastName = "Push Push",
                    Type = "MidWife"
                },
                new Clinician
                {
                    ClinicianID = "53",
                    FirstName = "Palle",
                    LastName = "Peekaboo",
                    Type = "Midwife"
                },
                new Clinician
                {
                    ClinicianID = "54",
                    FirstName = "Ole",
                    LastName = "Opigen",
                    Type = "Midwife"
                },
                new Clinician
                {
                    ClinicianID = "55",
                    FirstName = "Palle",
                    LastName = "Pres Pres",
                    Type = "Midwife"
                },
                new Clinician
                {
                    ClinicianID = "56",
                    FirstName = "Kirsten",
                    LastName = "CuntWhisperer",
                    Type = "Midwife"
                },
                new Clinician
                {
                    ClinicianID = "57",
                    FirstName = "Niels",
                    LastName = "Nukommerbaby",
                    Type = "Midwife"
                },
                new Clinician
                {
                    ClinicianID = "58",
                    FirstName = "Peter",
                    LastName = "Pop",
                    Type = "Midwife"
                },
                new Clinician
                {
                    ClinicianID = "59",
                    FirstName = "Inger",
                    LastName = "Ikkefler",
                    Type = "Midwife"
                }
            };

            foreach (var clin in clinicians)
            {                                        

                modelBuilder.Clinicians.AddClinician(clin);
            }
        }

        private static void SeedRooms(IDataAccessActions modelBuilder)
        {
            var rooms = new ObservableCollection<RestRoom>
            {
                new RestRoom()
                {
                    RoomID = "1",
                    RoomNumber = 1,
                    Occupied = false
                },

                new RestRoom()
                {
                    RoomID = "2",
                    RoomNumber = 2,
                    Occupied = false
                },
                new RestRoom()
                {
                    RoomID = "3",
                    RoomNumber = 3,
                    Occupied = false
                },
                new RestRoom()
                {
                    RoomID = "4",
                    RoomNumber = 4,
                    Occupied = false
                },
                new RestRoom()
                {
                    RoomID = "5",
                    RoomNumber = 5,
                    Occupied = false
                }
            };

            foreach (var room in rooms)
            {
                 modelBuilder.RestRooms.AddRestRoom(room);
            }

            var matrooms = new ObservableCollection<MaternityRoom>
            {
                new MaternityRoom()
                {
                    RoomID = "6",
                    RoomNumber = 1,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "7",
                    RoomNumber = 2,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "8",
                    RoomNumber = 3,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "9",
                    RoomNumber = 4,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "10",
                    RoomNumber = 5,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "11",
                    RoomNumber = 6,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "12",
                    RoomNumber = 7,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "13",
                    RoomNumber = 8,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "14",
                    RoomNumber = 9,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "15",
                    RoomNumber = 10,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "16",
                    RoomNumber = 11,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "17",
                    RoomNumber = 12,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "18",
                    RoomNumber = 13,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "19",
                    RoomNumber = 14,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "20",
                    RoomNumber = 15,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "21",
                    RoomNumber = 16,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "22",
                    RoomNumber = 17,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "23",
                    RoomNumber = 18,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "24",
                    RoomNumber = 19,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "25",
                    RoomNumber = 20,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "26",
                    RoomNumber = 21,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = "27",
                    RoomNumber = 22,
                    Occupied = false
                }
            };

            foreach (var room in matrooms)
            {
                modelBuilder.MaternityRooms.AddMaternity(room);
            }


            var birthrooms = new ObservableCollection<BirthRoom>
            {
                new BirthRoom()
                {
                    RoomID = "28",
                    RoomNumber = 1,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = "29",
                    RoomNumber = 2,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = "30",
                    RoomNumber = 3,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = "31",
                    RoomNumber = 4,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = "32",
                    RoomNumber = 5,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = "33",
                    RoomNumber = 6,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = "34",
                    RoomNumber = 7,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = "35",
                    RoomNumber = 8,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = "36",
                    RoomNumber = 9,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = "37",
                    RoomNumber = 10,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = "38",
                    RoomNumber = 11,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = "39",
                    RoomNumber = 12,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = "40",
                    RoomNumber = 13,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = "41",
                    RoomNumber = 14,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = "42",
                    RoomNumber = 15,
                    Occupied = false
                }
            };

            foreach (var room in birthrooms)
            {
                modelBuilder.BirthRooms.AddBirthRoom(room);
            }
        }
    }
}
