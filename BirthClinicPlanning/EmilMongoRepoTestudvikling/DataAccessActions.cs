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
        public IBirthRoomRepository BirthRooms { get; private set; }
        public IRestRoomRepository RestRooms { get; private set; }
        public IClinicianRepository Clinicians { get; private set; }
        public IMaternityRoomRepository MaternityRooms { get; private set; }

        public DataAccessActions(MongoDbContext context)
        {
            _context = context;
            Appointments = new AppointmentRepository(_context);
            BirthRooms = new BirthRoomRepository(_context);
            RestRooms = new RestRoomRepository(_context);
            Clinicians = new ClinicianRepository(_context);
        }
    }
}
