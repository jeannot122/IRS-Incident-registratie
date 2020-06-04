using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IRS.API.Models
{
    public class CustomerModel
    {
        /// <summary>
        /// The identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of the customer.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The location.
        /// </summary>
        [Required]
        public string LocationName { get; set; }

        /// <summary>
        /// The location type.
        /// </summary>
        public string LocationType { get; set; }

        /// <summary>
        /// The email address
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string BusinessEmailAddress { get; set; }
    }
}
