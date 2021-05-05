using System.Collections.ObjectModel;
using BirthClinicMongoDB.Domainmodels;

namespace BirthClinicMongoDB.Repositories.Interfaces
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        public ObservableCollection<Room> GetAllRooms();

        public ObservableCollection<Room> GetAllBirthRooms();
        public ObservableCollection<Room> GetAllRestRooms();
        public ObservableCollection<Room> GetAllMaternityRooms();

        public Room GetBirthRoomWithSpecificNumber(int no);

        public Room GetRestRoomWithSpecificNumber(int no);

        public Room GetMaternityRoomWithSpecificNumber(int no);

        public Room GetSingleRoom(string id);

        public void DelRestRoom(Room room);

        public void AddAppointmentToRoom(string roomid, Appointment appointment);

        public void AddRoom(Room restRoom);

        public void UpdateRoom(Room restRoom);

        public bool RoomsExist();
    }
}
