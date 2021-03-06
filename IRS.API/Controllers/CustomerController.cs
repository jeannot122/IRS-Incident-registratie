﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRS.API.Data;
using IRS.API.Models;
using IRS.APP.Areas.Customer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IRS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CustomerModel aCustomer)
        {
            ObjectResult lResult = null; 
            try
            {
                DatabaseContext lContext = new DatabaseContext();
                if (ModelState.IsValid)
                {
                    await lContext.Customers.AddAsync(aCustomer);
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
        public async Task<IActionResult> Update([FromBody] CustomerModel aCustomer, int anId)
        {
            ObjectResult lResult = null;
            try
            {
                DatabaseContext lContext = new DatabaseContext();
                if (ModelState.IsValid)
                {
                    var lCustomerToUpdate = lContext.Customers.Where(x => x.Id == anId).SingleOrDefault();
                    lCustomerToUpdate.LocationName = aCustomer.LocationName;
                    lCustomerToUpdate.LocationType = aCustomer.LocationType;
                    lCustomerToUpdate.BusinessEmailAddress = aCustomer.BusinessEmailAddress;
                    lCustomerToUpdate.Name = aCustomer.Name;
                    
                    lContext.Customers.Update(lCustomerToUpdate);
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
                    var CustomerToDelete = lContext.Customers.Where(x => x.Id == anId).SingleOrDefault();
                    lContext.Customers.Remove(CustomerToDelete);
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
