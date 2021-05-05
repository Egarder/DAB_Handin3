using System.Collections.ObjectModel;
using BirthClinicMongoDB.Domainmodels;

namespace BirthClinicMongoDB.Repositories.Interfaces
{
    public interface IRestRoomRepository : IBaseRepository<RestRoom>
    {
        public ObservableCollection<RestRoom> GetAllRestRoom();

        public RestRoom GetRestRoomWithSpecificNumber(int no);

        public RestRoom GetSingleRestRoom(string id);

        public void DelRestRoom(RestRoom restRoom);

        public void AddAppointmentToRoom(string roomid, Appointment appointment);

        public void AddRestRoom(RestRoom restRoom);
    }
}
