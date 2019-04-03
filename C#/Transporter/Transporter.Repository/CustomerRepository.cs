// <copyright file="CustomerRepository.cs" company="PlaceholderCompany">
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
    /// Repository for Customer table.
    /// </summary>
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly TransporterDatabaseEntities tde = new TransporterDatabaseEntities();

        /// <summary>
        /// Changes the customers adress.
        /// </summary>
        /// <param name="id">The customers id.</param>
        /// <param name="newAdress">The customers new adress.</param>
        public void ChangeAdress(int id, string newAdress)
        {
            CUSTOMER customer = this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID == id).Single();
            customer.CADRESS = newAdress;
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Changes the customers e-mail adress.
        /// </summary>
        /// <param name="id">The customers id.</param>
        /// <param name="newEmail">The customers new e-mail adress.</param>
        public void ChangeEmail(int id, string newEmail)
        {
            CUSTOMER customer = this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID == id).Single();
            customer.CE_MAIL = newEmail;
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Changes the customers phone number.
        /// </summary>
        /// <param name="id">The customers id.</param>
        /// <param name="newPhoneNum">The customers new phone number.</param>
        public void ChangePhoneNum(int id, string newPhoneNum)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retturns all customers as IQueryable.
        /// </summary>
        /// <returns>Everything from the Customer table.</returns>
        public IQueryable<CUSTOMER> GetTable()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts a new customer into the table.
        /// </summary>
        /// <param name="entity">The new Customer.</param>
        public void Insert(CUSTOMER entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes a customer from the table.
        /// </summary>
        /// <param name="entity">The customer to remove as an entyty.</param>
        public void Remove(CUSTOMER entity)
        {
            throw new NotImplementedException();
        }
    }
}
