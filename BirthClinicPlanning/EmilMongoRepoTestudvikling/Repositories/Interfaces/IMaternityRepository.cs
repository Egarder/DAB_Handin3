using System;
using EmilMongoRepoTestudvikling.Domainmodels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EmilMongoRepoTestudvikling.Repositories.Interfaces
{
    public interface IMaternityRepository: IBaseRepository<MaternityRoom>
    {
        public ObservableCollection<MaternityRoom> GetAllMaternityRooms();

        public MaternityRoom GetMaternityRoomWithSpecificNumber(int no);
        public MaternityRoom GetSingleMaternityRoom(string id);

        public void AddAppointmentToRoom(string roomid, Appointment appointment);

        public void AddMaternity(MaternityRoom maternityRoom);
    }
}
