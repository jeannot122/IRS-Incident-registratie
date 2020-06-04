using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRS.APP.Areas.Customer.Models.Locations
{
    public class Location
    {
        /// <summary>
        /// The identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The location name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The street.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// The housenumber.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// The housenumber addition.
        /// </summary>
        public string Addition { get; set; }

        /// <summary>
        /// The zipcode of the location.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// The location type.
        /// </summary>
        public string Type { get; set; }
    }
}
