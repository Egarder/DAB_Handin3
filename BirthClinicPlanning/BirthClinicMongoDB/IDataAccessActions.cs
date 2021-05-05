using BirthClinicMongoDB.Repositories.Interfaces;

namespace BirthClinicMongoDB
{
    public interface IDataAccessActions
    {
        public IAppointmentRepository Appointments { get; }
        public IBirthRoomRepository BirthRooms { get; }
        public IRestRoomRepository RestRooms { get; }
        public IClinicianRepository Clinicians { get; }
        public IMaternityRoomRepository MaternityRooms { get; }
    }
}
