using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRS.API.Data;
using IRS.API.Models;
using IRS.API.Services;
using IRS.Business.Incidents;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly ILogger<IncidentController> _logger;

        public IncidentController(ILogger<IncidentController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetById")]
        public IncidentModel GetById(int anId)
        {
            IncidentModel lIncident = null;

            try
            {
                if (ModelState.IsValid)
                {
                    DatabaseContext lContext = new DatabaseContext();
                    IncidentService lService = new IncidentService(lContext);
                    lIncident = lService.GetById(anId);
                }
            }
            catch
            {
                ModelState.AddModelError("", "Cannot save changes, try again.");
                _logger.LogError("Failed to get all Incidents.");
            }

            return lIncident;
        }

        [HttpGet("GetByNumber")]
        public IncidentModel GetByNumber(int aNumber)
        {
            IncidentModel lIncident = null;

            try
            {
                if (ModelState.IsValid)
                {
                    DatabaseContext lContext = new DatabaseContext();
                    IncidentService lService = new IncidentService(lContext);
                    lIncident = lService.GetByNumber(aNumber);
                }
            }
            catch
            {
                ModelState.AddModelError("", "Cannot save changes, try again.");
                _logger.LogError("Failed to get all Incidents.");
            }

            return lIncident;
        }

        [HttpGet("GetAll")]
        public IEnumerable<IncidentModel> GetAll()
        {
            IEnumerable<IncidentModel> lIncidents = null;

            try
            {
                if (ModelState.IsValid)
                {
                    DatabaseContext lContext = new DatabaseContext();
                    IncidentService lService = new IncidentService(lContext);
                    lIncidents = lService.GetAll();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Cannot save changes, try again.");
                _logger.LogError("Failed to get all Incidents.");
            }

            return lIncidents;
        }

        [HttpGet("GetAllOpen")]
        public IEnumerable<IncidentModel> GetAllOpen()
        {
            IEnumerable<IncidentModel> lIncidents = null;

            try
            {
                if (ModelState.IsValid)
                {
                    DatabaseContext lContext = new DatabaseContext();
                    IncidentService lService = new IncidentService(lContext);
                    lIncidents = lService.GetAllOpen();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Cannot save changes, try again.");
                _logger.LogError("Failed to get all open Incidents.");
            }

            return lIncidents;
        }

        [HttpGet("GetAll")]
        public IEnumerable<IncidentModel> GetAllClosed()
        {
            IEnumerable<IncidentModel> lIncidents = null;

            try
            {
                if (ModelState.IsValid)
                {
                    DatabaseContext lContext = new DatabaseContext();
                    IncidentService lService = new IncidentService(lContext);
                    lIncidents = lService.GetAllClosed();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Cannot save changes, try again.");
                _logger.LogError("Failed to get all closed Incidents.");
            }

            return lIncidents;
        }

        [HttpGet("GetAllOnHold")]
        public IEnumerable<IncidentModel> GetAllOnHold()
        {
            IEnumerable<IncidentModel> lIncidents = null;

            try
            {
                if (ModelState.IsValid)
                {
                    DatabaseContext lContext = new DatabaseContext();
                    IncidentService lService = new IncidentService(lContext);
                    lIncidents = lService.GetAllOnHold();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Cannot save changes, try again.");
                _logger.LogError("Failed to get all on hold Incidents.");
            }

            return lIncidents;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] IncidentModel anIncident)
        {
            ObjectResult lResult = null;
            try
            {
                DatabaseContext lContext = new DatabaseContext();
                if (ModelState.IsValid)
                {
                    await lContext.Incidents.AddAsync(anIncident);
                    await lContext.SaveChangesAsync();

                    lResult = new ObjectResult("Created");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Cannot save changes, try again.");
                _logger.LogError("Failed to create Incident.");
                lResult = new ObjectResult("Failed to create");
            }

            return lResult;
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] IncidentModel anIncident, int Id)
        {
            ObjectResult lResult = null;
            try
            {
                DatabaseContext lContext = new DatabaseContext();
                if (ModelState.IsValid)
                {
                    var lIncidentToUpdate = lContext.Incidents.Where(x => x.Id == Id).SingleOrDefault();
                    lIncidentToUpdate.Number = anIncident.Number;
                    lIncidentToUpdate.Description= anIncident.Description;
                    lIncidentToUpdate.TypeId = anIncident.TypeId;
                    lIncidentToUpdate.Status = anIncident.Status;

                    lContext.Incidents.Update(lIncidentToUpdate);
                    await lContext.SaveChangesAsync();

                    lResult = new ObjectResult("Updated");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Cannot save changes, try again.");
                _logger.LogError("Failed to update incident.");

                lResult = new ObjectResult("Failed to update");
            }

            return lResult;
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            ObjectResult lResult = null;
            try
            {
                DatabaseContext lContext = new DatabaseContext();
                if (ModelState.IsValid)
                {
                    var lIncidentToDelete = lContext.Incidents.Where(x => x.Id == Id).SingleOrDefault();
                    lContext.Incidents.Remove(lIncidentToDelete);
                    await lContext.SaveChangesAsync();

                    lResult = new ObjectResult("Removed");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Cannot save changes, try again.");
                _logger.LogError("Failed to delete incident.");
                lResult = new ObjectResult("Failed to delete");
            }

            return lResult;
        }
    }
}
