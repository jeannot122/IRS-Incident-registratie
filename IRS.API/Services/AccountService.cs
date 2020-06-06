using IRS.API.Data;
using IRS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRS.API.Services
{
    public interface IAccountService
    {
        bool Authenticate(string anUserName, string aPassword);
        IEnumerable<AccountModel> GetAll();
        AccountModel GetById(int Id);
        AccountModel Create(AccountModel anAccount, string aPassword);
        void Update(AccountModel anAccount, string aPassword = null);
        void Delete(int Id);
    }

    public class AccountService : IAccountService
    {
        private DatabaseContext mContext;

        public AccountService(DatabaseContext aContext)
        {
            mContext = aContext;
        }

        public bool Authenticate(string anUserName, string aPassword)
        {
            AccountModel lAccount = null;
            bool lAuthorized = false;

            if (string.IsNullOrEmpty(anUserName) || string.IsNullOrEmpty(aPassword))
            {
                lAuthorized = false;
            }
            else
            {
                // Gets the username and if no username is found lAccount is null.
                lAccount = mContext.Accounts.SingleOrDefault(x => x.UserName == anUserName);

                if (lAccount != null && lAccount.Password == aPassword)
                {
                    lAuthorized = true;
                }
            }
            
            return lAuthorized;
        }

        public AccountModel Create(AccountModel anAccount, string aPassword)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountModel> GetAll()
        {
            return mContext.Accounts;
        }

        public AccountModel GetById(int Id)
        {
            return mContext.Accounts.Find(Id);
        }

        public void Update(AccountModel anAccount, string aPassword = null)
        {
            throw new NotImplementedException();
        }
    }
}
