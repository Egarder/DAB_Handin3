using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling.Domainmodels;
using EmilMongoRepoTestudvikling.Repositories;
using EmilMongoRepoTestudvikling.Repositories.Interfaces;
using Polly;

namespace EmilMongoRepoTestudvikling.Repositories.Interfaces
{
    public interface IBirthRoomRepository : IBaseRepository<BirthRoom>
    {
        public ObservableCollection<BirthRoom> GetAllBirthsRooms();

        public BirthRoom GetBirthRoomWithSpecificNumber(int no);


        public BirthRoom GetSingleBirthRoom(string id);

        public void AddBirthRoom(BirthRoom room);
    }
}