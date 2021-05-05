using System.Collections.ObjectModel;
using BirthClinicMongoDB.Domainmodels;

namespace BirthClinicMongoDB.Repositories.Interfaces
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        public ObservableCollection<Room> GetAllRestRoom();

        public Room GetRestRoomWithSpecificNumber(int no);

        public Room GetSingleRestRoom(string id);

        public void DelRestRoom(Room restRoom);

        public void AddAppointmentToRoom(string roomid, Appointment appointment);

        public void AddRestRoom(Room restRoom);
    }
}
