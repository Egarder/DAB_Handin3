using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling.Repositories.Interfaces;

namespace EmilMongoRepoTestudvikling
{
    public interface IDataAccessActions
    {
        public IAppointmentRepository Appointments { get; }
        public IBirthRoomRepository BirthRooms { get; }
        public IRestRoomRepository RestRooms { get; }
        public IClinicianRepository Clinicians { get; }
    }
}
