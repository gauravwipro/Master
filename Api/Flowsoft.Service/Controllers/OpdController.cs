using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Flowsoft.DataServices.Interfaces;
using Flowsoft.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace Flowsoft.Hms.Controllers
{
    [Produces("application/json")]
    [EnableCors("CORS")]
    public class OpdController : Controller
    {
        private IOpdService opdService;

        public OpdController(IOpdService _opdService)
        {
            opdService = _opdService;
        }
        [HttpGet]
        [Route("api/Opd/Index")]
        public IEnumerable<Opds> Index()
        {
            return opdService.Get();
        }

        [HttpPost]
        [Route("api/Opd/Create")]
        public int Create([FromBody] Opds opd)
        {
            opd.TokenNumber = opdService.GenerateToken(opd.DoctorId, opd.OpdDate);
            return opdService.Add(opd);
        }

        [HttpGet]
        [Route("api/Opd/Details/{id}")]
        public Opds Details(int id)
        {
            return opdService.GetById(id);
        }

        [HttpGet]
        [Route("api/Opd/Details/GetTodayAppointment/{id}")]
        public IEnumerable<OpdDetails> GetTodayAppointment(int id)
        {
            return opdService.GetTodayAppointment(id);
        }
        [HttpPut]
        [Route("api/Opd/Edit")]
        public int Edit([FromBody]Opds opd)
        {
            return opdService.Update(opd);
        }

        [HttpDelete]
        [Route("api/Opd/Delete/{id}")]
        public int Delete(int id)
        {
            return opdService.Delete(id);
        }
    }
}