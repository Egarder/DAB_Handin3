using System.Collections.ObjectModel;
using BirthClinicMongoDB.Domainmodels;

namespace BirthClinicMongoDB.Repositories.Interfaces
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        public ObservableCollection<Room> GetAllRooms();

        public Room GetRoomWithSpecificNumber(int no);

        public Room GetSingleRoom(string id);

        public void DelRestRoom(Room room);

        public void AddAppointmentToRoom(string roomid, Appointment appointment);

        public void AddRoom(Room restRoom);
    }
}
