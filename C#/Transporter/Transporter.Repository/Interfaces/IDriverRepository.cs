// <copyright file="IDriverRepository.cs" company="PlaceholderCompany">
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
    /// Repository interface for driver specific methods.
    /// </summary>
    public interface IDriverRepository : IRepository<DRIVER>
    {
        /// <summary>
        /// Changes the drivers adress.
        /// </summary>
        /// <param name="id">The id of the driver.</param>
        /// <param name="newAdress">The drivers new adress.</param>
        void ChangeAdress(int id, string newAdress);

        /// <summary>
        /// Changes the phone number of the driver.
        /// </summary>
        /// <param name="id">The id of the driver.</param>
        /// <param name="newPhoneNum">The new phone number.</param>
        void ChangePhoneNum(int id, string newPhoneNum);

        /// <summary>
        /// Changes the licence plate of the driver.
        /// </summary>
        /// <param name="id">The id of the driver.</param>
        /// <param name="newLicPlate">The new licence plate.</param>
        void ChangeLicPlate(int id, string newLicPlate);

        /// <summary>
        /// Inserts an Entity into the table.
        /// </summary>
        /// <param name="id">The drivers id.</param>
        /// <param name="name">The drivers name.</param>
        /// <param name="adress">The drivers adress.</param>
        /// <param name="birthDate">The drivers date of birth.</param>
        /// <param name="licencePlate">The drivers licence plate number.</param>
        /// <param name="phoneNum">The drivers phone number.</param>
        void Insert(int id, string name, string adress, DateTime birthDate, string licencePlate, string phoneNum);
    }
}
