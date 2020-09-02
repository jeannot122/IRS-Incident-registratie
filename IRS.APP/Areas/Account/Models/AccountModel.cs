using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IRS.APP.Areas.Account.Models
{
    public class AccountModel
    {
        /// <summary>
        /// The user username/emailadress
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Gebruikersnaam")]
        public string UserName { get; set; }

        /// <summary>
        /// The user password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Wachtwoord")]
        public string Password { get; set; }

        /// <summary>
        /// The hash for password encryption.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// The salt for password encryption.
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// The user full name.
        /// </summary>
        public string UserFullName { get; set; }

        /// <summary>
        /// The account type.
        /// </summary>
        public string TypeId { get; set; }
    }
}
