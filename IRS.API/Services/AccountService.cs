using IRS.API.Data;
using IRS.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRS.API.Services
{
    public interface IAccountService
    {
        Task<ObjectResult> Authenticate(string anUserName, string aPassword);
        IEnumerable<AccountModel> GetAll();
        AccountModel GetById(int anId);
    }

    public class AccountService : IAccountService
    {
        private DatabaseContext mContext;

        /// <summary>
        /// The database context.
        /// </summary>
        /// <param name="aContext"></param>
        public AccountService(DatabaseContext aContext)
        {
            mContext = aContext;
        }

        /// <summary>
        /// Authenticates the username and password.
        /// </summary>
        /// <param name="anUserName"></param>
        /// <param name="aPassword"></param>
        /// <returns></returns>
        public async Task<ObjectResult> Authenticate(string anUserName, string aPassword)
        {
            AccountModel lAccount = null;
            ObjectResult lAuthorized = null;

            if (string.IsNullOrEmpty(anUserName) || string.IsNullOrEmpty(aPassword))
            {
                lAuthorized = new ObjectResult("Fail");
            }
            else
            {
                // Gets the username and if no username is found lAccount is null.
                lAccount = mContext.Accounts.SingleOrDefault(x => x.UserName == anUserName);

                if (lAccount != null && lAccount.Password == aPassword)
                {
                    lAuthorized = new ObjectResult("Ok");
                }
            }
            
            return lAuthorized;
        }

        /// <summary>
        /// Gets all Accounts.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AccountModel> GetAll()
        {
            return mContext.Accounts;
        }

        /// <summary>
        /// Gets account by Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public AccountModel GetById(int anId)
        {
            return mContext.Accounts.Find(anId);
        }
    }
}
