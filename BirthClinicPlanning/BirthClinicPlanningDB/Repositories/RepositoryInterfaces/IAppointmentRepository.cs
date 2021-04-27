using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.DomainObjects;

namespace BirthClinicPlanningDB.Repositories.RepositoryInterfaces
{
    public interface IAppointmentRepository: IRepository<Appointment>
    {
        public ObservableCollection<Appointment> getAllAppointments();
        public Appointment getSingleAppointment(int id);

        public void AddAppointment(Appointment appointment);

        public void DelAppointment(Appointment appointment);
    }
}
