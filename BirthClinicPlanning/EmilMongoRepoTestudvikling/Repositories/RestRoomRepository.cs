using BirthClinicPlanningMongoDbWebAPI.DomainObjects;
using EmilMongoRepoTestudvikling.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EmilMongoRepoTestudvikling.Repositories
{
    public class RestRoomRepository: BaseRepository<RestRoom>, IRestRoomRepository
    {
        public RestRoomRepository(IMongoDbContext context) : base(context)
        {
        }
        public void AddAppointmentToRoom(int roomid, Appointment appointment)
        {
            //_dbCollection.InsertOne()
        }

        public void AddRestRoom(RestRoom restRoom)
        {
            throw new NotImplementedException();
        }

        public void DelRestRoom(RestRoom restRoom)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<RestRoom> GetAllRestRoom()
        {
            throw new NotImplementedException();
        }

        public RestRoom GetRestRoomWithSpecificNumber(int no)
        {
            throw new NotImplementedException();
        }

        public RestRoom GetSingleRestRoom(int id)
        {
            throw new NotImplementedException();
        }
    }
}
