using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling.Repositories;
using EmilMongoRepoTestudvikling.Repositories.Interfaces;

namespace EmilMongoRepoTestudvikling
{
    public class DataAccessActions:IDataAccessActions
    {
        private readonly MongoDbContext _context;
        public IAppointmentRepository Appointments { get; private set; }

        public DataAccessActions(MongoDbContext context)
        {
            _context = context;
            Appointments = new AppointmentRepository(_context);
        }
    }
}
