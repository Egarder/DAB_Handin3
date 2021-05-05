using BirthClinicMongoDB.Repositories.Interfaces;

namespace BirthClinicMongoDB
{
    public interface IDataAccessActions
    {
        public IAppointmentRepository Appointments { get; }
        public IClinicianRepository Clinicians { get; }
        public IRoomRepository Rooms { get; }
    }
}
