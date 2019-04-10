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
    public class PakageRepository : IPakageRepository
    {
        private TransporterDatabaseEntities tde = new TransporterDatabaseEntities();

        /// <summary>
        /// Initializes a new instance of the <see cref="PakageRepository"/> class.
        /// </summary>
        public PakageRepository()
        {
        }

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
        /// Returns the id of a pakage from its sender id and receiver id.
        /// </summary>
        /// <param name="entity">The pakages sender id and receiver id as a pakage entity.</param>
        /// <returns>The pakages id.</returns>
        public int GetId(PAKAGE entity)
        {
            return (int)this.tde.PAKAGE.Where(x => x.PSENDER_ID.Equals(entity.PSENDER_ID) && x.PRECEIVER_ID.Equals(entity.PRECEIVER_ID)).Single().PAKAGE_ID;
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

        /// <summary>
        /// Returns the pakage table.
        /// </summary>
        /// <returns>The whole table.</returns>
        public IQueryable<PAKAGE> GetTable()
        {
            return this.tde.PAKAGE.AsQueryable();
        }

        /// <summary>
        /// Inserts a new pakage.
        /// </summary>
        /// <param name="entity">The new pakage.</param>
        public void Insert(PAKAGE entity)
        {
            this.tde.PAKAGE.Add(entity);
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Removes a pakage from the table.
        /// </summary>
        /// <param name="entity">The id of the pakage to remove as a pakage entity.</param>
        public void Remove(PAKAGE entity)
        {
            PAKAGE toRemove = this.tde.PAKAGE.Where(x => x.PAKAGE_ID.Equals(entity.PAKAGE_ID)).Single();
            this.tde.PAKAGE.Remove(toRemove);
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Makes a pakage entity for adding.
        /// </summary>
        /// <param name="id">The id of the pakage.</param>
        /// <param name="senderName">The sender name.</param>
        /// <param name="senderAdress">The sender adress.</param>
        /// <param name="receiverName">The reciver name.</param>
        /// <param name="receiverAdress">The reciver adress.</param>
        /// <param name="weight">The pakages weight.</param>
        /// <param name="size">The pakages size.</param>
        /// <param name="driverId">The drivers id.</param>
        /// <returns>A pakage entity.</returns>
        public PAKAGE ToPakage(int id, string senderName, string senderAdress, string receiverName, string receiverAdress, int weight, string size, int driverId)
        {
            return new PAKAGE
            {
                PAKAGE_ID = id,
                PSENDER_ID = new CustomerRepository().GetId(new CUSTOMER { CNAME = senderName, CADRESS = senderAdress }),
                PRECEIVER_ID = new CustomerRepository().GetId(new CUSTOMER { CNAME = receiverName, CADRESS = receiverAdress }),
                PWEIGHT = weight,
                PSIZE = size,
                PDRIVER_ID = driverId
            };
        }

        /// <summary>
        /// Returns a pakage entity for searching and removeing.
        /// </summary>
        /// <param name="senderId">The senders id.</param>
        /// <param name="reciverId">The recivers id.</param>
        /// <returns>A pakage entity.</returns>
        public PAKAGE ToPakage(int senderId, int reciverId)
        {
            return new PAKAGE
            {
                PSENDER_ID = senderId,
                PRECEIVER_ID = reciverId
            };
        }
    }
}
