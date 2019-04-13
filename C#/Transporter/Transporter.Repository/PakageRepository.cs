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
        /// Returns a pakages driver as a string array.
        /// </summary>
        /// <param name="id">The pakages id.</param>
        /// <returns>The pakages driver.</returns>
        public string[] GetDriver(int id)
        {
            DRIVER driver = this.tde.DRIVER.Where(x => x.DRIVER_ID.Equals(this.tde.PAKAGE.Where(y => y.PAKAGE_ID.Equals(id)).Single())).Single();

            return new string[]
            {
                driver.DRIVER_ID.ToString(),
                driver.DNAME,
                driver.DADRESS,
                driver.DBIRTH_DATE.ToString(),
                driver.DLICENCE_PLATE,
                driver.DPHONE_NUM
            };
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

        public int GetId(object param1, object param2)
        {
            throw new NotImplementedException();
        }

        public int GetLastId()
        {
            throw new NotImplementedException();
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

            route[1] = this.GetDriverAsDriver(id).DLICENCE_PLATE
               + " " + this.GetDriverAsDriver(id).DNAME;

            route[2] = this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID.Equals(this.tde.PAKAGE.Where(y => y.PAKAGE_ID.Equals(id)).Single().PRECEIVER_ID)).Single().CUSTOMER_ID.ToString()
               + " " + this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID.Equals(this.tde.PAKAGE.Where(y => y.PAKAGE_ID.Equals(id)).Single().PRECEIVER_ID)).Single().CNAME.ToString();

            return route;
        }

        /// <summary>
        /// Returns the pakage table.
        /// </summary>
        /// <returns>The whole table.</returns>
        public List<string[]> GetTable()
        {
            List<string[]> table = new List<string[]>();

            foreach (var item in this.tde.PAKAGE)
            {
                string[] row = new string[6];

                row[0] = item.PAKAGE_ID.ToString();
                row[1] = item.PSIZE.ToString();
                row[2] = item.PWEIGHT.ToString();
                row[3] = item.PSENDER_ID.ToString();
                row[4] = item.PRECEIVER_ID.ToString();
                row[5] = item.PDRIVER_ID.ToString();

                table.Add(row);
            }

            return table;
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

        public void Insert(int id, int senderId, string receiverId, int weight, string size, int driverId)
        {
            throw new NotImplementedException();
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

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the driver of the pakage as a Driver object.
        /// </summary>
        /// <param name="id">The id of the pakage.</param>
        /// <returns>The driver as a driver entity.</returns>
        private DRIVER GetDriverAsDriver(int id)
        {
            return this.tde.DRIVER.Where(x => x.DRIVER_ID.Equals(this.tde.PAKAGE.Where(y => y.PAKAGE_ID.Equals(id)).Single())).Single();
        }
    }
}
