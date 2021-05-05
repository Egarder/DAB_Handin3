using System.Collections.ObjectModel;
using BirthClinicMongoDB.Domainmodels;

namespace BirthClinicMongoDB.Repositories.Interfaces
{
    public interface IBirthRoomRepository : IBaseRepository<BirthRoom>
    {
        public ObservableCollection<BirthRoom> GetAllBirthsRooms();

        public BirthRoom GetBirthRoomWithSpecificNumber(int no);


        public BirthRoom GetSingleBirthRoom(string id);

        public void AddBirthRoom(BirthRoom room);
    }
}