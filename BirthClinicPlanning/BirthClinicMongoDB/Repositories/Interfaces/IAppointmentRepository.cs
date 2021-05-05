using BirthClinicMongoDB.Domainmodels;
using System.Collections.ObjectModel;

namespace BirthClinicMongoDB.Repositories.Interfaces
{
    public interface IAppointmentRepository: IBaseRepository<Appointment>
    {
        public Appointment GetSingleAppointment(string id);

        public Appointment GetSingleAppointmentByID(string id);

        public ObservableCollection<Appointment> GetAllAppointments();

        public void Update(string id, Appointment appIn);

        public void AddAppointment(Appointment app);

        public void DelAppointment(Appointment appointment);

        public bool AppointmentsExist();

        public void UpdateAppointment(Appointment appointment);

        public long CountAppointments();
    }
}
