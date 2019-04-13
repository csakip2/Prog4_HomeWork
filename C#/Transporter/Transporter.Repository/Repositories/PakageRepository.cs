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
        /// <param name="param1">The pakages sender id.</param>
        /// <param name="param2">The pakages reciver id.</param>
        /// <returns>The pakages id.</returns>
        public int GetId(object param1, object param2)
        {
            return (int)this.tde.PAKAGE.Where(x => x.PSENDER_ID.Equals(param1) && x.PRECEIVER_ID.Equals(param2)).Single().PAKAGE_ID;
        }

        /// <summary>
        /// Returns the last id of the table.
        /// </summary>
        /// <returns>The last id of the table.</returns>
        public int GetLastId()
        {
            int max = 0;
            foreach (var item in this.tde.PAKAGE)
            {
                int cur = (int)item.PAKAGE_ID;
                if (max < cur)
                {
                    max = cur;
                }
            }

            return max;
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
        /// Inserts an Entity into the table.
        /// </summary>
        /// <param name="id">The pakages id.</param>
        /// <param name="senderId">The senders id.</param>
        /// <param name="receiverId">The recivers id.</param>
        /// <param name="weight">The pakages weight.</param>
        /// <param name="size">The pakages size.</param>
        /// <param name="driverId">The drivers id.</param>
        public void Insert(int id, int senderId, int receiverId, int weight, string size, int driverId)
        {
            this.tde.PAKAGE.Add(new PAKAGE
            {
                PAKAGE_ID = id,
                PSENDER_ID = senderId,
                PRECEIVER_ID = receiverId,
                PWEIGHT = weight,
                PSIZE = size,
                PDRIVER_ID = driverId
            });
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Removes a pakage from the table.
        /// </summary>
        /// <param name="id">The id of the pakage.</param>
        public void Remove(int id)
        {
            this.tde.PAKAGE.Remove(this.tde.PAKAGE.Where(x => x.PAKAGE_ID.Equals(id)).Single());
            this.tde.SaveChanges();
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
