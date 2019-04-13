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
        /// Returns the ID of the driver from its name and adress.
        /// </summary>
        /// <param name="param1">The drivers name.</param>
        /// <param name="param2">The drivers adress.</param>
        /// <returns>The ID of the driver.</returns>
        public int GetId(object param1, object param2)
        {
            return (int)this.tde.DRIVER.Where(x => x.DNAME.Equals(param1) && x.DADRESS.Equals(param2)).Single().DRIVER_ID;
        }

        /// <summary>
        /// Returns the last used id in the table.
        /// </summary>
        /// <returns>The last used id inn the table.</returns>
        public int GetLastId()
        {
            int max = 0;
            foreach (var item in this.tde.DRIVER)
            {
                int cur = (int)item.DRIVER_ID;
                if (max < cur)
                {
                    max = cur;
                }
            }

            return max;
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
        /// Inserts an Entity into the table.
        /// </summary>
        /// <param name="id">The drivers id.</param>
        /// <param name="name">The drivers name.</param>
        /// <param name="adress">The drivers adress.</param>
        /// <param name="birthDate">The drivers date of birth.</param>
        /// <param name="licencePlate">The drivers licence plate number.</param>
        /// <param name="phoneNum">The drivers phone number.</param>
        public void Insert(int id, string name, string adress, DateTime birthDate, string licencePlate, string phoneNum)
        {
            this.tde.DRIVER.Add(new DRIVER
            {
                DRIVER_ID = id,
                DNAME = name,
                DADRESS = adress,
                DBIRTH_DATE = birthDate,
                DLICENCE_PLATE = licencePlate,
                DPHONE_NUM = phoneNum
            });
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Removes a driver from the table.
        /// </summary>
        /// <param name="id">The id of the driver.</param>
        public void Remove(int id)
        {
            this.tde.DRIVER.Remove(this.tde.DRIVER.Where(x => x.DRIVER_ID.Equals(id)).Single());
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
