using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BirthClinicPlanningMongoDbWebAPI.DomainObjects;
using BirthClinicPlanningMongoDbWebAPI.Repositories.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace BirthClinicPlanningMongoDbWebAPI.Repositories.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMongoRepository<Appointment> _appointmentRepository;

        public AppointmentController(IMongoRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        [HttpPost("addAppointment")]
        public async Task AddAppointment(Appointment app)
        {
            await _appointmentRepository.InsertOneAsync(app);
        }

        [HttpGet("getSingleAppointment")]
        public Appointment getSingleAppointment(string id)
        {
            return _appointmentRepository.FindById(id);
        }

        [HttpGet("getAllAppointment")]
        public ObservableCollection<Appointment> getAllAppointment()
        {
            return null;
        }

        [HttpPost("DelAppointment")]
        public async Task DelAppointment(Appointment appointmentToDelete)
        {
            var id = appointmentToDelete.AppointmentID;

            _appointmentRepository.DeleteById(id.ToString());
        }

    }


}
