using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRS.API.Models
{
    public class AccountModel
    {
        /// <summary>
        /// The identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The user username/emailadress
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        /// <summary>
        /// The user password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

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
