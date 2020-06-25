using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRS.API.Data;
using IRS.API.Models;
using IRS.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace IRS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetById")]
        public AccountModel GetAll(int anId)
        {
            AccountModel lAccount = null;

            try
            {
                if (ModelState.IsValid)
                {
                    DatabaseContext lContext = new DatabaseContext();
                    AccountService lService = new AccountService(lContext);
                    lAccount = lService.GetById(anId);
                }
            }
            catch
            {
                ModelState.AddModelError("", "Cannot save changes, try again.");
                _logger.LogError("Failed to get account.");
            }

            return lAccount;
        }

        [HttpGet("GetAll")]
        public IEnumerable<AccountModel> GetAll()
        {
            IEnumerable<AccountModel> lAccounts = null;

            try
            {
                if (ModelState.IsValid)
                {
                    DatabaseContext lContext = new DatabaseContext();
                    AccountService lService = new AccountService(lContext);
                    lAccounts = lService.GetAll();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Cannot save changes, try again.");
                _logger.LogError("Failed to get all Accounts.");
            }

            return lAccounts;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AccountModel anAccount)
        {
            ObjectResult lResult = null;

            try
            {
                if (ModelState.IsValid) 
                {
                    DatabaseContext lContext = new DatabaseContext();
                    AccountService lService = new AccountService(lContext);
                    ObjectResult lAuthenticated = await lService.Authenticate(anAccount.UserName, anAccount.Password);

                    if (lAuthenticated.Value.ToString() == "Ok")
                    {
                        lResult = new ObjectResult("Authenticated");
                    }
                    else
                    {
                        lResult = new ObjectResult("Failed to authenticate");
                    }
                }
                else
                {
                    throw new Exception("The modelstate was invalid");
                }
            }
            catch
            {
                lResult = new ObjectResult("Failed to authenticate");
            }

            return lResult;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]AccountModel anAccount)
        {
            ObjectResult lResult = null;
            try
            {
                DatabaseContext lContext = new DatabaseContext();
                if (ModelState.IsValid)
                {
                    await lContext.Accounts.AddAsync(anAccount);
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
        public async Task<IActionResult> Update([FromBody] AccountModel anAccount, int Id)
        {
            ObjectResult lResult = null;
            try
            {
                DatabaseContext lContext = new DatabaseContext();
                if (ModelState.IsValid)
                {
                    var lAccountToUpdate = lContext.Accounts.Where(x => x.Id == Id).SingleOrDefault();
                    lAccountToUpdate.UserName = anAccount.UserName;
                    lAccountToUpdate.UserFullName = anAccount.UserFullName;
                    lAccountToUpdate.Password = anAccount.Password;
                    lAccountToUpdate.TypeId = anAccount.TypeId;

                    lContext.Accounts.Update(lAccountToUpdate);
                    await lContext.SaveChangesAsync();

                    lResult = new ObjectResult("Updated");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Cannot save changes, try again.");
                lResult = new ObjectResult("Failed to create");
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
                    var lAccountToDelete = lContext.Accounts.Where(x => x.Id == Id).SingleOrDefault();
                    lContext.Accounts.Remove(lAccountToDelete);
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
