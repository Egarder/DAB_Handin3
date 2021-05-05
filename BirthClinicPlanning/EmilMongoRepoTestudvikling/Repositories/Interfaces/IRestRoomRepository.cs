using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling.Domainmodels;

namespace EmilMongoRepoTestudvikling.Repositories.Interfaces
{
    public interface IRestRoomRepository : IBaseRepository<RestRoom>
    {
        public ObservableCollection<RestRoom> GetAllRestRoom();

        public RestRoom GetRestRoomWithSpecificNumber(int no);


        public void DelRestRoom(RestRoom restRoom);

        public void AddAppointmentToRoom(string roomid, Appointment appointment);

        public void AddRestRoom(RestRoom restRoom);
    }
}
