using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IRS.API.Models
{
    public class LocationModel
    {
        /// <summary>
        /// The identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// The location name.
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// The street.
        /// </summary>
        [Required]
        public string Street { get; set; }
        
        /// <summary>
        /// The housenumber.
        /// </summary>
        [Required]
        public int Number { get; set; }
        
        /// <summary>
        /// The housenumber addition.
        /// </summary>
        public string Addition { get; set; }

        /// <summary>
        /// The zipcode of the location.
        /// </summary>
        [Required]
        public string ZipCode { get; set; }
            
        /// <summary>
        /// The type of the location.
        /// </summary>
        public string TypeId { get; set; }
    }
}
