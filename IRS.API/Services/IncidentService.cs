using IRS.API.Data;
using IRS.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRS.API.Services
{
    public interface IIncidentService
    {
        IEnumerable<IncidentModel> GetAll();
        IEnumerable<IncidentModel> GetAllOpen();
        IEnumerable<IncidentModel> GetAllClosed();
        IEnumerable<IncidentModel> GetAllOnHold();
        IncidentModel GetById(int anId);
        IncidentModel GetByNumber(int aNumber);    
    }

    public class IncidentService : IIncidentService
    {
        private DatabaseContext mContext;

        /// <summary>
        /// The database context.
        /// </summary>
        /// <param name="aContext"></param>
        public IncidentService(DatabaseContext aContext)
        {
            mContext = aContext;
        }

        /// <summary>
        /// Get all incidents.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IncidentModel> GetAll()
        {
            return mContext.Incidents;
        }

        /// <summary>
        /// Get all closed incidents.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IncidentModel> GetAllClosed()
        {
            return mContext.Incidents.Where(x => x.Status.Equals("Closed"));
        }

        /// <summary>
        /// Get all incidents with status on hold.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IncidentModel> GetAllOnHold()
        {
            return mContext.Incidents.Where(x => x.Status.Equals("Hold"));
        }

        /// <summary>
        /// Gets all open incidents.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IncidentModel> GetAllOpen()
        {
            return mContext.Incidents.Where(x => x.Status.Equals("Open"));
        }

        /// <summary>
        /// Gets the incident by Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IncidentModel GetById(int anId)
        {
            return mContext.Incidents.Find(anId);
        }

        /// <summary>
        /// Gets the incident by number.
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public IncidentModel GetByNumber(int aNumber)
        {
            return mContext.Incidents.Where(x => x.Number == aNumber).SingleOrDefault();
        }
    }
}
