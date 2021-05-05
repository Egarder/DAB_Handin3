using BirthClinicPlanningMongoDbWebAPI.DomainObjects;
using EmilMongoRepoTestudvikling.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling.Domainmodels;
using EmilMongoRepoTestudvikling.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using Polly;

namespace EmilMongoRepoTestudvikling.Repositories
{
    public class RestRoomRepository: BaseRepository<RestRoom>, IRestRoomRepository
    {
        public RestRoomRepository(IMongoDbContext context) : base(context)
        {

        }

        public ObservableCollection<RestRoom> GetAllRestRoom()
        {
        }

        {
        }

        {
        }

        {
        }

        {
        }

        {
        }
    }
}
