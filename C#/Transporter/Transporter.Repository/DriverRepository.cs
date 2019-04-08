﻿// <copyright file="DriverRepository.cs" company="PlaceholderCompany">
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
    internal class DriverRepository : IDriverRepository
    {
        private TransporterDatabaseEntities tde = new TransporterDatabaseEntities();

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
        /// Returns the driver table.
        /// </summary>
        /// <returns>The whole table.</returns>
        public IQueryable<DRIVER> GetTable()
        {
            return this.tde.DRIVER.AsQueryable();
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

        public void Remove(DRIVER entity)
        {
            throw new NotImplementedException();
        }
    }
}
