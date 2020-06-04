using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRS.APP.Areas.Customer.Models.Locations
{
    public class SubLocation : Location
    {
        /// <summary>
        /// The type identifier.
        /// </summary>
        public string TypeId { get; set; }
    }
}
