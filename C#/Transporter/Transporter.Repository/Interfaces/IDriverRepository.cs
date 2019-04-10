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
    internal interface IDriverRepository : IRepository<DRIVER>
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
        /// Makes a driver entity for adding.
        /// </summary>
        /// <param name="id">The id of the driver.</param>
        /// <param name="name">The new drivers name.</param>
        /// <param name="adress">The new drivers adress.</param>
        /// <param name="birthDate">The new drivers date of birth.</param>
        /// <param name="licencePlate">The new drivers licence plate.</param>
        /// <param name="phoneNum">The new drivers phone number.</param>
        /// <returns>A driver entity.</returns>
        DRIVER ToDriver(int id, string name, string adress, DateTime birthDate, string licencePlate, string phoneNum);

        /// <summary>
        /// Makes a driver entity for searching and removeing.
        /// </summary>
        /// <param name="name">The drivers name.</param>
        /// <param name="adress">The drivers adress.</param>
        /// <returns>A drivers enity.</returns>
        DRIVER ToDriver(string name, string adress);
    }
}
