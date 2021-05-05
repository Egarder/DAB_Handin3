using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling.Domainmodels;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EmilMongoRepoTestudvikling.Repositories.Interfaces
{
    public interface IAppointmentRepository: IBaseRepository<Appointment>
    {
        public Appointment getSingleAppointment(string id);

        public ObservableCollection<Appointment> getAllAppointments();

        public void Update(string id, Appointment appIn);

        public void AddAppointment(Appointment app);

        public void DelAppointment(Appointment appointment);
    }
}
