﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
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

        public Appointment getSingleAppointment(string id)
        {
            var projection = Builders<Appointment>.Projection.Include(b => b.AppointmentID).Include(c=>c.RoomID);

            var bson = _dbCollection.Find<Appointment>(app => app.AppointmentID == id).Project(projection)
                .FirstOrDefault();

            var tempobj = new Appointment()
            {
                AppointmentID = bson.GetElement("AppointmentID").Value.AsString,
                RoomID = bson.GetElement("RoomID").Value.AsInt32
            };

            return tempobj;
        }

        public List<Appointment> getAllAppointments2()
        {
            var temp = _dbCollection.Find(new BsonDocument()).ToList();


            return temp;
        }

        public List<Appointment> getAllAppointments() =>
            _dbCollection.Find(Appointment => Appointment.AppointmentID!=null).ToList(); //Exception med ID kommer her. 

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
