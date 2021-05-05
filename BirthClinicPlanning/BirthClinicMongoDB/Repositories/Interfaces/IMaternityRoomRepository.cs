using System.Collections.ObjectModel;
using BirthClinicMongoDB.Domainmodels;

namespace BirthClinicMongoDB.Repositories.Interfaces
{
    public interface IMaternityRoomRepository: IBaseRepository<MaternityRoom>
    {
        public ObservableCollection<MaternityRoom> GetAllMaternityRooms();

        public MaternityRoom GetMaternityRoomWithSpecificNumber(int no);
        public MaternityRoom GetSingleMaternityRoom(string id);

        public void AddAppointmentToRoom(string roomid, Appointment appointment);

        public void AddMaternity(MaternityRoom maternityRoom);
    }
}
