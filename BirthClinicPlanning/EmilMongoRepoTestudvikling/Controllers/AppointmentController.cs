using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmilMongoRepoTestudvikling.Domainmodels;
using EmilMongoRepoTestudvikling.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmilMongoRepoTestudvikling.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController:ControllerBase
    {
        private readonly IAppointmentRepository _apprepo;

        public AppointmentController(IAppointmentRepository repo)
        {
            _apprepo = repo;
        }

        [HttpGet]
        [Route("allappointments")]
        public async Task<ActionResult<IEnumerable<Appointment>>> Get()
        {
            var appointments = await _apprepo.Get();
            return Ok(appointments);
        }
    }
}
