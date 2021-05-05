using System.Collections.Generic;
using System.Collections.ObjectModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EmilMongoRepoTestudvikling.Domainmodels
{
    public class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string RoomID { get; set; }

        public int RoomNumber { get; set; }

        public string RoomType { get; set; }

        public bool Occupied { get; set; }
        
        public ObservableCollection<Appointment> Appointments { get; set; }
    }
}