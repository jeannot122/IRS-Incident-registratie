using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRS.API.Data;
using IRS.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;

        public LocationController(ILogger<LocationController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] LocationModel aLocation)
        {
            ObjectResult lResult = null;
            try
            {
                DatabaseContext lContext = new DatabaseContext();
                if (ModelState.IsValid)
                {
                    await lContext.Locations.AddAsync(aLocation);
                    await lContext.SaveChangesAsync();

                    lResult = new ObjectResult("Created");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Cannot save changes, try again.");
                lResult = new ObjectResult("Failed to create");
            }

            return lResult;
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] LocationModel aLocation, int anId)
        {
            ObjectResult lResult = null;
            try
            {
                DatabaseContext lContext = new DatabaseContext();
                if (ModelState.IsValid)
                {
                    var lLocationToUpdate = lContext.Locations.Where(x => x.Id == anId).SingleOrDefault();
                    lLocationToUpdate.Street = aLocation.Street;
                    lLocationToUpdate.Number = aLocation.Number;
                    lLocationToUpdate.Addition = aLocation.Addition;
                    lLocationToUpdate.ZipCode = aLocation.ZipCode;
                    lLocationToUpdate.TypeId = aLocation.TypeId;

                    lContext.Locations.Update(lLocationToUpdate);
                    await lContext.SaveChangesAsync();

                    lResult = new ObjectResult("Updated");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Cannot save changes, try again.");
                lResult = new ObjectResult("Failed to update");
            }

            return lResult;
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int anId)
        {
            ObjectResult lResult = null;
            try
            {
                DatabaseContext lContext = new DatabaseContext();
                if (ModelState.IsValid)
                {
                    var lLocationToRemove = lContext.Locations.Where(x => x.Id == anId).SingleOrDefault();
                    lContext.Locations.Remove(lLocationToRemove);
                    await lContext.SaveChangesAsync();

                    lResult = new ObjectResult("Removed");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Cannot save changes, try again.");
                lResult = new ObjectResult("Failed to delete");
            }

            return lResult;
        }
    }
}
