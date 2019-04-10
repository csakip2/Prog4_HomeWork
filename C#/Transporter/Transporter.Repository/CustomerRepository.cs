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
    public class CustomerRepository : ICustomerRepository
    {
        private TransporterDatabaseEntities tde = new TransporterDatabaseEntities();

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        public CustomerRepository()
        {
        }

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
        /// Returns the ID of the customer from its name and adress.
        /// </summary>
        /// <param name="entity">The customers name and adress as a customer entity.</param>
        /// <returns>The ID of the customer.</returns>
        public int GetId(CUSTOMER entity)
        {
            return (int)this.tde.CUSTOMER.Where(x => x.CNAME.Equals(entity.CNAME) && x.CADRESS.Equals(entity.CADRESS)).Single().CUSTOMER_ID;
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
        /// <param name="entity">The name and adress of the customer to remove as an entyty.</param>
        public void Remove(CUSTOMER entity)
        {
            CUSTOMER toRemove = this.tde.CUSTOMER.Where(x => x.CNAME.Equals(entity.CNAME) && x.CADRESS.Equals(entity.CADRESS)).Single();
            this.tde.CUSTOMER.Remove(toRemove);
            this.tde.SaveChanges();
        }
    }
}
