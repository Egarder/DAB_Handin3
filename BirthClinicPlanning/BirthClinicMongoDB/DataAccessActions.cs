using BirthClinicMongoDB.Repositories;
using BirthClinicMongoDB.Repositories.Interfaces;

namespace BirthClinicMongoDB
{
    public class DataAccessActions : IDataAccessActions
    {
        private readonly MongoDbContext _context;
        public IAppointmentRepository Appointments { get; private set; }

        public IClinicianRepository Clinicians { get; private set; }
        public IRoomRepository Rooms { get; private set; }

        public DataAccessActions(MongoDbContext context)
        {
            _context = context;
            Appointments = new AppointmentRepository(_context);
            Rooms = new RoomRepository(_context);
            Clinicians = new ClinicianRepository(_context);
        }
    }
}
