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
    public class StateController : Controller
    {
        private IStateService stateService;

        public StateController(IStateService _stateService)
        {
            stateService = _stateService;
        }
        [HttpGet]
        [Route("api/State/Index")]
        public IEnumerable<States> Index()
        {
            return stateService.Get();
        }

        [HttpPost]
        [Route("api/State/Create")]
        public int Create([FromBody] States state)
        {
            return stateService.Add(state);
        }

        [HttpGet]
        [Route("api/State/Details/{id}")]
        public States Details(int id)
        {
            return stateService.GetById(id);
        }

        [HttpPut]
        [Route("api/State/Edit")]
        public int Edit([FromBody]States state)
        {
            return stateService.Update(state);
        }

        [HttpDelete]
        [Route("api/State/Delete/{id}")]
        public int Delete(int id)
        {
            return stateService.Delete(id);
        }
    }
}