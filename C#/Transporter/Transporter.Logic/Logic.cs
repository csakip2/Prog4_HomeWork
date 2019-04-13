// <copyright file="Logic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Transporter.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Transporter.Repository;

    /// <summary>
    /// Logic class. Handels repository methods.
    /// </summary>
    internal class Logic : ILogic
    {
        private CustomerRepository crep;
        private PakageRepository prep;
        private DriverRepository drep;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// </summary>
        public Logic()
        {
            this.crep = new CustomerRepository();
            this.prep = new PakageRepository();
            this.drep = new DriverRepository();
        }

        /// <summary>
        /// Adds a new customer to the table.
        /// </summary>
        /// <param name="name">The new customers name.</param>
        /// <param name="adress">The new customers adress.</param>
        /// <param name="phoneNum">The new customers phone number.</param>
        /// <param name="e_mail">The new customers e-mail adress.</param>
        public void AddCustomer(string name, string adress, string phoneNum, string e_mail)
        {
            int id = this.crep.GetLastId() + 1;
            this.crep.Insert(id, name, adress, phoneNum, e_mail);
        }

        /// <summary>
        /// Adds a new driver to the table.
        /// </summary>
        /// <param name="name">The new drivers name.</param>
        /// <param name="adress">The new drivers adress.</param>
        /// <param name="birthDate">The new drivers birth date.</param>
        /// <param name="licencePlate">The new drivers licence plate number.</param>
        /// <param name="phoneNum">The new drivers phone number.</param>
        public void AddDriver(string name, string adress, DateTime birthDate, string licencePlate, string phoneNum)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a new pakage to the table.
        /// </summary>
        /// <param name="senderName">The new pakages senders name.</param>
        /// <param name="senderAdress">The new pakages senders adress.</param>
        /// <param name="receiverName">The new pakages recivers name.</param>
        /// <param name="receiverAdress">The new pakages recivers adress.</param>
        /// <param name="weight">The new pakages weight.</param>
        /// <param name="size">The new pakages size.</param>
        public void AddPakage(string senderName, string senderAdress, string receiverName, string receiverAdress, int weight, string size)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Changes a customers adress.
        /// </summary>
        /// <param name="name">The name of the customer.</param>
        /// <param name="oldAdress">The current adress of the customer.</param>
        /// <param name="newAdress">The new adress of the customer.</param>
        public void ChangeCustomerAdress(string name, string oldAdress, string newAdress)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Changes the customers e-mail adress.
        /// </summary>
        /// <param name="name">The customers name.</param>
        /// <param name="adress">The customers adress.</param>
        /// <param name="newEmail">The customers new e-mail adress.</param>
        public void ChangeCustomerEmail(string name, string adress, string newEmail)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Changes the customers phone number.
        /// </summary>
        /// <param name="name">The customers name.</param>
        /// <param name="adress">The customers adress.</param>
        /// <param name="newPhoneNum">The customers new phone number.</param>
        public void ChangeCustomerPhoneNum(string name, string adress, string newPhoneNum)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Changes the drivers adress.
        /// </summary>
        /// <param name="name">The drivers name.</param>
        /// <param name="oldAdress">The drivers old adress.</param>
        /// <param name="newAdress">The drivers new adress.</param>
        public void ChangeDriverAdress(string name, string oldAdress, string newAdress)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Changes the drivers licence plate number.
        /// </summary>
        /// <param name="name">The name of the driver.</param>
        /// <param name="adress">The adress of the driver.</param>
        /// <param name="newLicPlate">The drivers new licence plate number.</param>
        public void ChangeDriverLicPlate(string name, string adress, string newLicPlate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Changes the drivers phone number.
        /// </summary>
        /// <param name="name">The drivers name.</param>
        /// <param name="adress">The drivers adress.</param>
        /// <param name="newPhoneNum">The drivers new phone number.</param>
        public void ChangeDriverPhoneNum(string name, string adress, string newPhoneNum)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Changes the driver of a pakage.
        /// </summary>
        /// <param name="id">The pakage ID.</param>
        /// <param name="newDriver_id">The id of the new driver.</param>
        public void ChangePakageDriver(int id, int newDriver_id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the pakages drivers name and licence plate number ([0]driverName, [1]licencePlateNumber).
        /// </summary>
        /// <param name="id">The pakages id.</param>
        /// <returns>The drivers name and licence plate number ([0]driverName, [1]licencePlateNumber).</returns>
        public string[] GetPakageDriver(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the route of the pakage.
        /// </summary>
        /// <param name="id">The pakages id.</param>
        /// <returns>The route of the pakage.</returns>
        public string[] GetPakageRoute(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes a customer from the table.
        /// </summary>
        /// <param name="name">The customers name.</param>
        /// <param name="adress">The customers adress.</param>
        public void RemoveCustomer(string name, string adress)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes a driver from the table.
        /// </summary>
        /// <param name="name">The drivers name.</param>
        /// <param name="adress">The drivers adress.</param>
        public void RemoveDriver(string name, string adress)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes a pakage from the table.
        /// </summary>
        /// <param name="id">The id of the pakage.</param>
        public void RemovePakage(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrives the customer table.
        /// </summary>
        /// <returns>All elements in a tring array.</returns>
        public string[] RetriveCustomers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrives the driver table.
        /// </summary>
        /// <returns>All elements in a tring array.</returns>
        public string[] RetriveDrivers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrives the pakage table.
        /// </summary>
        /// <returns>All elements in a tring array.</returns>
        public string[] RetrivePakages()
        {
            throw new NotImplementedException();
        }
    }
}
