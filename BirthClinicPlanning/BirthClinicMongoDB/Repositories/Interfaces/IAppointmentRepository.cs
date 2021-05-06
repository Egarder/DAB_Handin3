using BirthClinicMongoDB.Domainmodels;
using System.Collections.ObjectModel;

namespace BirthClinicMongoDB.Repositories.Interfaces
{
    public interface IAppointmentRepository: IBaseRepository<Appointment>
    {
        public Appointment GetSingleAppointment(string id);

        public ObservableCollection<Appointment> GetAllAppointments();

        public void AddAppointment(Appointment app);

        public void DelAppointment(Appointment appointment);

        public bool AppointmentsExist();

        public ObservableCollection<Appointment> GetNumberOfAppointments(int n);
    }
}
