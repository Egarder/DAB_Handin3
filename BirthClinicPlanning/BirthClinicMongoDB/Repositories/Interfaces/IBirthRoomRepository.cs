using System.Collections.ObjectModel;
using BirthClinicMongoDB.Domainmodels;

namespace BirthClinicMongoDB.Repositories.Interfaces
{
    public interface IBirthRoomRepository : IBaseRepository<Domainmodels.Room>
    {
        public ObservableCollection<Domainmodels.Room> GetAllBirthsRooms();

        public Domainmodels.Room GetBirthRoomWithSpecificNumber(int no);


        public Domainmodels.Room GetSingleBirthRoom(string id);

        public void AddBirthRoom(Domainmodels.Room room);
    }
}