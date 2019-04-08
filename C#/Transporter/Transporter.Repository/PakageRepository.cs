// <copyright file="PakageRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Transporter.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Transporter.Data;

    /// <summary>
    /// Repository for Pakages table.
    /// </summary>
    internal class PakageRepository : IPakageRepository
    {
        private TransporterDatabaseEntities tde = new TransporterDatabaseEntities();

        /// <summary>
        /// Changes the pakage's driver.
        /// </summary>
        /// <param name="id">Id of the pakage.</param>
        /// <param name="newDriverId">Id of the new driver.</param>
        public void ChangeDriver(int id, int newDriverId)
        {
            this.tde.PAKAGE.Where(x => x.PAKAGE_ID.Equals(newDriverId)).Single().PDRIVER_ID = newDriverId;
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Returns the driver of the pakage.
        /// </summary>
        /// <param name="id">The id of the pakage.</param>
        /// <returns>The driver as a driver entity.</returns>
        public DRIVER GetDriver(int id)
        {
            return this.tde.DRIVER.Where(x => x.DRIVER_ID.Equals(this.tde.PAKAGE.Where(y => y.PAKAGE_ID.Equals(id)).Single())).Single();
        }

        /// <summary>
        /// Returns the route of the pakage.
        /// </summary>
        /// <param name="id">Id of the pakage.</param>
        /// <returns>A string array in "[0]from, [1](through driver), [2]to" form.</returns>
        public string[] GetRoute(int id)
        {
            string[] route = new string[3];

            route[0] = this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID.Equals(this.tde.PAKAGE.Where(y => y.PAKAGE_ID.Equals(id)).Single().PSENDER_ID)).Single().CUSTOMER_ID.ToString()
               + " " + this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID.Equals(this.tde.PAKAGE.Where(y => y.PAKAGE_ID.Equals(id)).Single().PSENDER_ID)).Single().CNAME.ToString();

            route[1] = this.GetDriver(id).DLICENCE_PLATE
               + " " + this.GetDriver(id).DNAME;

            route[2] = this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID.Equals(this.tde.PAKAGE.Where(y => y.PAKAGE_ID.Equals(id)).Single().PRECEIVER_ID)).Single().CUSTOMER_ID.ToString()
               + " " + this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID.Equals(this.tde.PAKAGE.Where(y => y.PAKAGE_ID.Equals(id)).Single().PRECEIVER_ID)).Single().CNAME.ToString();

            return route;
        }

        public IQueryable<PAKAGE> GetTable()
        {
            throw new NotImplementedException();
        }

        public void Insert(PAKAGE entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(PAKAGE entity)
        {
            throw new NotImplementedException();
        }
    }
}
