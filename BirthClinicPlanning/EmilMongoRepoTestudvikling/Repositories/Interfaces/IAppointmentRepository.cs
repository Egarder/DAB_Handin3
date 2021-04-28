using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling.Domainmodels;
using MongoDB.Driver;

namespace EmilMongoRepoTestudvikling.Repositories.Interfaces
{
    public interface IAppointmentRepository: IBaseRepository<Appointment>
    {
        public Appointment getSingleAppointments(string id);

        public List<Appointment> getAllAppointments();
    }
}
