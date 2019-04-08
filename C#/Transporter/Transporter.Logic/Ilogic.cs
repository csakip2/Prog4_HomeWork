// <copyright file="Ilogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Transporter.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Logic interface.
    /// </summary>
    internal interface ILogic
    {
        /// <summary>
        /// Retrives the customer table.
        /// </summary>
        /// <returns>All elements in a tring array.</returns>
        string[] RetriveCustomers();

        /// <summary>
        /// Retrives the pakage table.
        /// </summary>
        /// <returns>All elements in a tring array.</returns>
        string[] RetrivePakages();

        /// <summary>
        /// Retrives the driver table.
        /// </summary>
        /// <returns>All elements in a tring array.</returns>
        string[] RetriveDrivers();

        /// <summary>
        /// Adds a new customer to the table.
        /// </summary>
        /// <param name="name">The new customers name.</param>
        /// <param name="adress">The new customers adress.</param>
        /// <param name="phoneNum">The new customers phone number.</param>
        /// <param name="e_mail">The new customers e-mail adress.</param>
        void AddCustomer(string name, string adress, string phoneNum, string e_mail);

        /// <summary>
        /// Adds a new pakage to the table.
        /// </summary>
        /// <param name="senderName">The new pakages senders name.</param>
        /// <param name="senderAdress">The new pakages senders adress.</param>
        /// <param name="receiverName">The new pakages recivers name.</param>
        /// <param name="receiverAdress">The new pakages recivers adress.</param>
        /// <param name="weight">The new pakages weight.</param>
        /// <param name="size">The new pakages size.</param>
        void AddPakage(string senderName, string senderAdress, string receiverName, string receiverAdress, int weight, string size);

        /// <summary>
        /// Adds a new driver to the table.
        /// </summary>
        /// <param name="name">The new drivers name.</param>
        /// <param name="adress">The new drivers adress.</param>
        /// <param name="birthDate">The new drivers birth date.</param>
        /// <param name="licencePlate">The new drivers licence plate number.</param>
        /// <param name="phoneNum">The new drivers phone number.</param>
        void AddDriver(string name, string adress, DateTime birthDate, string licencePlate, string phoneNum);
    }
}
