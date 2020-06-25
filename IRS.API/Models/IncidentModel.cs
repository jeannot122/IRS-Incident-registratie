using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IRS.API.Models
{
    public class IncidentModel
    {
        /// <summary>
        /// The identifier.
        /// </summary
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The ticket number.
        /// </summary>
        [Required]
        public int Number { get; set; }

        /// <summary>
        /// The description.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// The incident type.
        /// </summary>
        public string TypeId { get; set; }

        /// <summary>
        /// The status of the incident.
        /// </summary>
        public string Status { get; set; }
    }
}
