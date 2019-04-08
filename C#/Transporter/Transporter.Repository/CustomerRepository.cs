﻿// <copyright file="CustomerRepository.cs" company="PlaceholderCompany">
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
        private TransporterDatabaseEntities tde = new TransporterDatabaseEntities();

        /// <summary>
        /// Changes the customers adress.
        /// </summary>
        /// <param name="id">The customers id.</param>
        /// <param name="newAdress">The customers new adress.</param>
        public void ChangeAdress(int id, string newAdress)
        {
            this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID.Equals(id)).Single().CADRESS = newAdress;
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Changes the customers e-mail adress.
        /// </summary>
        /// <param name="id">The customers id.</param>
        /// <param name="newEmail">The customers new e-mail adress.</param>
        public void ChangeEmail(int id, string newEmail)
        {
            this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID.Equals(id)).Single().CE_MAIL = newEmail;
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Changes the customers phone number.
        /// </summary>
        /// <param name="id">The customers id.</param>
        /// <param name="newPhoneNum">The customers new phone number.</param>
        public void ChangePhoneNum(int id, string newPhoneNum)
        {
            this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID.Equals(id)).Single().CPHONE_NUM = newPhoneNum;
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Retturns all customers as IQueryable.
        /// </summary>
        /// <returns>Everything from the Customer table.</returns>
        public IQueryable<CUSTOMER> GetTable()
        {
            return this.tde.CUSTOMER.AsQueryable();
        }

        /// <summary>
        /// Inserts a new customer into the table.
        /// </summary>
        /// <param name="entity">The new Customer.</param>
        public void Insert(CUSTOMER entity)
        {
            this.tde.CUSTOMER.Add(entity);
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Removes a customer from the table.
        /// </summary>
        /// <param name="entity">The customer to remove as an entyty.</param>
        public void Remove(CUSTOMER entity)
        {
            this.tde.CUSTOMER.Remove(entity);
            this.tde.SaveChanges();
        }
    }
}
