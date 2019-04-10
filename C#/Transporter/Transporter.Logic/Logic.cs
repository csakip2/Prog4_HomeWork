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

    /// <summary>
    /// Logic class. Handels repository methods.
    /// </summary>
    internal class Logic : ILogic
    {
        public void AddCustomer(string name, string adress, string phoneNum, string e_mail)
        {
            throw new NotImplementedException();
        }

        public void AddDriver(string name, string adress, DateTime birthDate, string licencePlate, string phoneNum)
        {
            throw new NotImplementedException();
        }

        public void AddPakage(string senderName, string senderAdress, string receiverName, string receiverAdress, int weight, string size)
        {
            throw new NotImplementedException();
        }

        public void ChangeCustomerAdress(string name, string oldAdress, string newAdress)
        {
            throw new NotImplementedException();
        }

        public void ChangeCustomerEmail(string name, string adress, string newEmail)
        {
            throw new NotImplementedException();
        }

        public void ChangeCustomerPhoneNum(string name, string adress, string newPhoneNum)
        {
            throw new NotImplementedException();
        }

        public void ChangeDriverAdress(string name, string oldAdress, string newAdress)
        {
            throw new NotImplementedException();
        }

        public void ChangeDriverLicPlate(string name, string adress, string newLicPlate)
        {
            throw new NotImplementedException();
        }

        public void ChangeDriverPhoneNum(string name, string adress, string newPhoneNum)
        {
            throw new NotImplementedException();
        }

        public void ChangePakageDriver(int id, int newDriver_id)
        {
            throw new NotImplementedException();
        }

        public string[] GetPakageDriver(int id)
        {
            throw new NotImplementedException();
        }

        public string[] GetPakageRoute(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomer(string name, string adress)
        {
            throw new NotImplementedException();
        }

        public void RemoveDriver(string name, string adress)
        {
            throw new NotImplementedException();
        }

        public void RemovePakage(int id)
        {
            throw new NotImplementedException();
        }

        public string[] RetriveCustomers()
        {
            throw new NotImplementedException();
        }

        public string[] RetriveDrivers()
        {
            throw new NotImplementedException();
        }

        public string[] RetrivePakages()
        {
            throw new NotImplementedException();
        }
    }
}
