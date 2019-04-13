// <copyright file="DriverRepository.cs" company="PlaceholderCompany">
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
    /// Repository for the driver table.
    /// </summary>
    public class DriverRepository : IDriverRepository
    {
        private TransporterDatabaseEntities tde = new TransporterDatabaseEntities();

        /// <summary>
        /// Initializes a new instance of the <see cref="DriverRepository"/> class.
        /// </summary>
        public DriverRepository()
        {
        }

        /// <summary>
        /// Changes the adress of the driver.
        /// </summary>
        /// <param name="id">The id of the driver.</param>
        /// <param name="newAdress">The new adress of the driver.</param>
        public void ChangeAdress(int id, string newAdress)
        {
            this.tde.DRIVER.Where(x => x.DRIVER_ID.Equals(id)).Single().DADRESS = newAdress;
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Changes the driver's licence plate number.
        /// </summary>
        /// <param name="id">The id of the driver.</param>
        /// <param name="newLicPlate">The new licence plate number.</param>
        public void ChangeLicPlate(int id, string newLicPlate)
        {
            this.tde.DRIVER.Where(x => x.DRIVER_ID.Equals(id)).Single().DLICENCE_PLATE = newLicPlate;
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Changes the phone number of the driver.
        /// </summary>
        /// <param name="id">The drivers id.</param>
        /// <param name="newPhoneNum">The new phone number.</param>
        public void ChangePhoneNum(int id, string newPhoneNum)
        {
            this.tde.DRIVER.Where(x => x.DRIVER_ID.Equals(id)).Single().DPHONE_NUM = newPhoneNum;
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Returns the id of a driver from its name and adress.
        /// </summary>
        /// <param name="entity">The drivers name and adress as a driver entity.</param>
        /// <returns>The drivers id.</returns>
        public int GetId(DRIVER entity)
        {
            return (int)this.tde.DRIVER.Where(x => x.DNAME.Equals(entity.DNAME) && x.DADRESS.Equals(entity.DADRESS)).Single().DRIVER_ID;
        }

        /// <summary>
        /// Returns the driver table.
        /// </summary>
        /// <returns>The whole table.</returns>
        public List<string[]> GetTable()
        {
            List<string[]> table = new List<string[]>();

            foreach (var item in this.tde.DRIVER)
            {
                table.Add(new string[]
                {
                    item.DRIVER_ID.ToString(),
                    item.DNAME,
                    item.DADRESS,
                    item.DBIRTH_DATE.ToString(),
                    item.DPHONE_NUM,
                    item.DLICENCE_PLATE
                });
            }

            return table;
        }

        /// <summary>
        /// Inserts a new driver into the table.
        /// </summary>
        /// <param name="entity">The new driver.</param>
        public void Insert(DRIVER entity)
        {
            this.tde.DRIVER.Add(entity);
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Removes a driver from the table.
        /// </summary>
        /// <param name="entity">The name and adress of the driver to remove as an entity.</param>
        public void Remove(DRIVER entity)
        {
            DRIVER toRemove = this.tde.DRIVER.Where(x => x.DNAME.Equals(entity.DNAME) && x.DADRESS.Equals(entity.DADRESS)).Single();
            this.tde.DRIVER.Remove(toRemove);
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Makes a driver entity for adding.
        /// </summary>
        /// <param name="id">The drivers id.</param>
        /// <param name="name">The new drivers name.</param>
        /// <param name="adress">The new drivers adress.</param>
        /// <param name="birthDate">The new drivers date of birth.</param>
        /// <param name="licencePlate">The new drivers licence plate.</param>
        /// <param name="phoneNum">The new drivers phone number.</param>
        /// <returns>A driver entity.</returns>
        public DRIVER ToDriver(int id, string name, string adress, DateTime birthDate, string licencePlate, string phoneNum)
        {
            return new DRIVER
            {
                DNAME = name,
                DADRESS = adress,
                DBIRTH_DATE = birthDate,
                DLICENCE_PLATE = licencePlate,
                DPHONE_NUM = phoneNum
            };
        }

        /// <summary>
        /// Makes a driver entity for searching and removeing.
        /// </summary>
        /// <param name="name">The drivers name.</param>
        /// <param name="adress">The drivers adress.</param>
        /// <returns>A drivers enity.</returns>
        public DRIVER ToDriver(string name, string adress)
        {
            return new DRIVER
            {
                DNAME = name,
                DADRESS = adress
            };
        }
    }
}
