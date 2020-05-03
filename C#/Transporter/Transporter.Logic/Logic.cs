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
    public class Logic : ILogic
    {
        private ICustomerRepository crep;
        private IPakageRepository prep;
        private IDriverRepository drep;

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
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// Only used for moq.
        /// </summary>
        /// <param name="crep">The mocked CustomerRepository.</param>
        /// <param name="prep">The mocked PakageRepository.</param>
        /// <param name="drep">The mocked DriverRepository.</param>
        public Logic(ICustomerRepository crep, IPakageRepository prep, IDriverRepository drep)
        {
            this.crep = crep;
            this.prep = prep;
            this.drep = drep;
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
            int id = this.crep.LastId + 1;
            this.crep.Insert(id, name, adress, phoneNum, e_mail);
        }

        public void ChangeCustomer(int id, string name, string adress, string phoneNum, string eMail)
        {
            this.crep.ChangeAdress(id, adress);
            this.crep.ChangePhoneNum(id, phoneNum);
            this.crep.ChangeEmail(id, phoneNum);
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
            int id = this.drep.LastId + 1;
            this.drep.Insert(id, name, adress, birthDate, licencePlate, phoneNum);
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
            int id = this.prep.LastId + 1;
            int driverId = new Random().Next(0, this.drep.LastId);
            this.prep.Insert(id, this.crep.GetId(senderName, senderAdress), this.crep.GetId(receiverName, receiverAdress), weight, size, driverId);
        }

        /// <summary>
        /// Changes a customers adress.
        /// </summary>
        /// <param name="name">The name of the customer.</param>
        /// <param name="oldAdress">The current adress of the customer.</param>
        /// <param name="newAdress">The new adress of the customer.</param>
        public void ChangeCustomerAdress(string name, string oldAdress, string newAdress)
        {
            this.crep.ChangeAdress(this.crep.GetId(name, oldAdress), newAdress);
        }

        /// <summary>
        /// Changes the customers e-mail adress.
        /// </summary>
        /// <param name="name">The customers name.</param>
        /// <param name="adress">The customers adress.</param>
        /// <param name="newEmail">The customers new e-mail adress.</param>
        public void ChangeCustomerEmail(string name, string adress, string newEmail)
        {
            this.crep.ChangeEmail(this.crep.GetId(name, adress), newEmail);
        }

        /// <summary>
        /// Changes the customers phone number.
        /// </summary>
        /// <param name="name">The customers name.</param>
        /// <param name="adress">The customers adress.</param>
        /// <param name="newPhoneNum">The customers new phone number.</param>
        public void ChangeCustomerPhoneNum(string name, string adress, string newPhoneNum)
        {
            this.crep.ChangePhoneNum(this.crep.GetId(name, adress), newPhoneNum);
        }

        /// <summary>
        /// Changes the drivers adress.
        /// </summary>
        /// <param name="name">The drivers name.</param>
        /// <param name="oldAdress">The drivers old adress.</param>
        /// <param name="newAdress">The drivers new adress.</param>
        public void ChangeDriverAdress(string name, string oldAdress, string newAdress)
        {
            this.drep.ChangeAdress(this.drep.GetId(name, oldAdress), newAdress);
        }

        /// <summary>
        /// Changes the drivers licence plate number.
        /// </summary>
        /// <param name="name">The name of the driver.</param>
        /// <param name="adress">The adress of the driver.</param>
        /// <param name="newLicPlate">The drivers new licence plate number.</param>
        public void ChangeDriverLicPlate(string name, string adress, string newLicPlate)
        {
            this.drep.ChangeLicPlate(this.drep.GetId(name, adress), newLicPlate);
        }

        /// <summary>
        /// Changes the drivers phone number.
        /// </summary>
        /// <param name="name">The drivers name.</param>
        /// <param name="adress">The drivers adress.</param>
        /// <param name="newPhoneNum">The drivers new phone number.</param>
        public void ChangeDriverPhoneNum(string name, string adress, string newPhoneNum)
        {
            this.drep.ChangePhoneNum(this.drep.GetId(name, adress), newPhoneNum);
        }

        /// <summary>
        /// Changes the driver of a pakage.
        /// </summary>
        /// <param name="id">The pakage ID.</param>
        /// <param name="newDriver_id">The id of the new driver.</param>
        public void ChangePakageDriver(int id, int newDriver_id)
        {
            this.prep.ChangeDriver(id, newDriver_id);
        }

        /// <summary>
        /// Returns the pakages drivers name and licence plate number ([0]driverName, [1]licencePlateNumber).
        /// </summary>
        /// <param name="id">The pakages id.</param>
        /// <returns>The drivers name and licence plate number ([0]driverName, [1]licencePlateNumber).</returns>
        public string[] GetPakageDriver(int id)
        {
            return this.prep.GetDriver(id);
        }

        /// <summary>
        /// Returns the route of the pakage.
        /// </summary>
        /// <param name="id">The pakages id.</param>
        /// <returns>The route of the pakage.</returns>
        public string[] GetPakageRoute(int id)
        {
            return this.prep.GetRoute(id);
        }

        /// <summary>
        /// Removes a customer from the table.
        /// </summary>
        /// <param name="name">The customers name.</param>
        /// <param name="adress">The customers adress.</param>
        public void RemoveCustomer(string name, string adress)
        {
            this.crep.Remove(this.crep.GetId(name, adress));
        }

        public bool RemoveCustomer(int id)
        {
            this.crep.Remove(id);
            return true;
        }

        /// <summary>
        /// Removes a driver from the table.
        /// </summary>
        /// <param name="name">The drivers name.</param>
        /// <param name="adress">The drivers adress.</param>
        public void RemoveDriver(string name, string adress)
        {
            this.drep.Remove(this.drep.GetId(name, adress));
        }

        /// <summary>
        /// Removes a pakage from the table.
        /// </summary>
        /// <param name="id">The id of the pakage.</param>
        public void RemovePakage(int id)
        {
            this.prep.Remove(id);
        }

        /// <summary>
        /// Retrives the customer table.
        /// </summary>
        /// <returns>All elements in a tring array.</returns>
        public string[] RetriveCustomers()
        {
            List<string[]> list = this.crep.GetTable();
            int i = 0;
            string[] table = new string[list.Count];

            foreach (var item in list)
            {
                table[i] = $"{item[0]}, {item[1]}, {item[2]}, {item[3]}, {item[4]}";
                i++;
            }

            return table;
        }

        /// <summary>
        /// Returns a list of the customers.
        /// </summary>
        /// <returns>List.</returns>
        public List<Transporter.Data.CUSTOMER> GetCustomerList()
        {
            return this.crep.GetTableList();
        }

        /// <summary>
        /// Retrives the driver table.
        /// </summary>
        /// <returns>All elements in a tring array.</returns>
        public string[] RetriveDrivers()
        {
            List<string[]> list = this.drep.GetTable();
            int i = 0;
            string[] table = new string[list.Count];

            foreach (var item in list)
            {
                table[i] = $"{item[0]}, {item[1]}, {item[2]}, {item[3]}, {item[4]}, {item[5]}";
                i++;
            }

            return table;
        }

        /// <summary>
        /// Retrives the pakage table.
        /// </summary>
        /// <returns>All elements in a tring array.</returns>
        public string[] RetrivePakages()
        {
            List<string[]> list = this.prep.GetTable();
            int i = 0;
            string[] table = new string[list.Count];

            foreach (var item in list)
            {
                table[i] = $"{item[0]}, {item[1]}, {item[2]}, {item[3]}, {item[4]}, {item[5]}";
                i++;
            }

            return table;
        }

        public Transporter.Data.CUSTOMER GetOneCustomer(int id)
        {
            return this.crep.GetOneCustomer(id);
        }
    }
}
