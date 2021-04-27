using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.Repositories;
using BirthClinicPlanningDB.Repositories.RepositoryInterfaces;

namespace BirthClinicPlanningDB
{
    public class DataAccessActions : IDataAccessActions
    {
        private readonly Context _context;
        public IAppointmentRepository Appointments { get; private set; }
        public IRestRoomRepository RestRooms { get; private set; }
        public IMaternityRoomRepository MaternityRooms { get; private set; }
        public IClinicianRepository Clinicians { get; private set; }
        public IBirthRoomRepository BirthRooms { get; private set; }

        //public repository object (by interface) declaration as property

        public DataAccessActions(Context context)
        {
            _context = context;
            Appointments = new AppointmentsRepository(_context);
            RestRooms = new RestRoomRepository(_context);
            MaternityRooms = new MaternityRoomRepository(_context);
            BirthRooms = new BirthRoomRepository(_context);
            Clinicians = new ClinicianRepository(_context);

            //Instantiate repository objects
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
