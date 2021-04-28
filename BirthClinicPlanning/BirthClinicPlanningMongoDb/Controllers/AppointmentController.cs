using BirthClinicPlanningMongoDbWebAPI.DomainObjects;
using BirthClinicPlanningMongoDbWebAPI.Repositories.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BirthClinicPlanningMongoDbWebAPI.Controllers
{
    [ApiController]
    [Route("[controller")]
    public class AppointmentController: ControllerBase
    {
        private readonly IMongoRepository<Appointment> _appointmentRepository;
    }
}
