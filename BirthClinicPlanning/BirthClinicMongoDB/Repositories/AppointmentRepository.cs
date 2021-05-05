﻿using MongoDB.Driver;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using BirthClinicMongoDB.Domainmodels;
using BirthClinicMongoDB.Repositories.Interfaces;

namespace BirthClinicMongoDB.Repositories
{
    public class AppointmentRepository: BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(IMongoDbContext context) : base(context)
        {

        }

        public Appointment GetSingleAppointment(string id)
        {
            var projection = Builders<Appointment>.Projection
                .Include(b => b.AppointmentID)
                .Include(c=>c.RoomID)
                .Include(d=>d.StartTime)
                .Include(e=>e.EndTime)
                .Include(f=>f.Room)
                .Include(t => t.Parents); //Add other properties

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
            ObservableCollection<Appointment> tempobjcollection = new ObservableCollection<Appointment>();

            var projection = Builders<Appointment>.Projection
                .Include(b => b.AppointmentID)
                .Include(c => c.RoomID)
                .Include(d => d.StartTime)
                .Include(e => e.EndTime)
                .Include(f => f.Room)
                .Include(t => t.Parents); //Add other properties

            var bson = _dbCollection.Find<Appointment>(app => app.AppointmentID !=null).Project(projection)
                .ToList();

            foreach (var item in bson)
            {
                var tempobj = new Appointment()
                {
                    AppointmentID = item.GetElement("AppointmentID").Value.AsString,
                    RoomID = item.GetElement("RoomID").Value.AsInt32,
                    StartTime = (DateTime)item.GetElement("StartTime").Value,
                    EndTime = (DateTime)item.GetElement("EndTime").Value,
                    Room = new Room() { RoomNumber = item.GetElement("Room: {RoomNumber}").Value.AsInt32 }
                };

                tempobjcollection.Add(tempobj);
            }

            return tempobjcollection; 
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

            _dbCollection.DeleteOneAsync(Builders<Appointment>.Filter.Eq("AppointmentID", id));
        }

        public MongoDbContext context
        {
            get { return context as MongoDbContext; }
        }
    }
}
