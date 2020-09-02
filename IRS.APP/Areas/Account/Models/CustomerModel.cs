using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRS.APP.Areas.Account.Models
{
    public class CustomerModel : AccountModel
    {
        /// <summary>
        /// The account type.
        /// </summary>
        public string AccountType { get; set; }
    }
}
