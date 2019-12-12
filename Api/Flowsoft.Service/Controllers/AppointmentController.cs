using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Flowsoft.DataServices.Interfaces;
using Flowsoft.Domain.Models;
using Flowsoft.Domain.Viewmodels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Flowsoft.Hms.Controllers
{
    [Produces("application/json")]
    [EnableCors("CORS")]
    public class AppointmentController : Controller
    {
        private IOpdService opdService;

        public AppointmentController(IOpdService _opdService)
        {
            opdService = _opdService;
        }
        [HttpGet]
        [Route("api/Appointment/Monthly/{doctorId}")]
        public IEnumerable<MonthlyAppointments> GetMonthlyAppointments(int doctorId)
        {
            return opdService.GetMonthlyAppointments(doctorId);
        }
        
        [HttpGet]
        [Route("api/Appointment/Daily/{doctorId}/{opdDate}")]
        public IEnumerable<DailyAppointments> GetDailyAppointments(int doctorId,DateTime opdDate)
        {
            return opdService.GetDailyAppointments(doctorId, opdDate);
        }

        [HttpPut]
        [Route("api/Appointment/Edit")]
        public int Edit([FromBody]OpdDoctorUpdateData dailyAppointments)
        {
            return opdService.Save(dailyAppointments);
        }
        [HttpGet]
        [Route("api/Appointment/patient/Details/{id}")]
        public IEnumerable<OpdDetails> Details(int id)
        {
            return opdService.GetOpdDetailWithHistory(id);
        }


    }
}
