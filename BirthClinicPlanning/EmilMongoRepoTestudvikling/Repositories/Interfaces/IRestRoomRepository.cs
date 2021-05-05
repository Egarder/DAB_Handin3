using BirthClinicPlanningMongoDbWebAPI.DomainObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EmilMongoRepoTestudvikling.Repositories.Interfaces
{
    public interface IRestRoomRepository: IBaseRepository<RestRoom>
    {
        public ObservableCollection<RestRoom> GetAllRestRoom();

        public RestRoom GetRestRoomWithSpecificNumber(int no);

        public RestRoom GetSingleRestRoom(int id);

        public void DelRestRoom(RestRoom restRoom);

        public void AddAppointmentToRoom(int roomid, Appointment appointment);

        public void AddRestRoom(RestRoom restRoom);
    }
}
