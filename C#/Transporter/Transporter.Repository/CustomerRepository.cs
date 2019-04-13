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
        /// <param name="param1">The customers name.</param>
        /// <param name="param2">The customers adress.</param>
        /// <returns>The ID of the customer.</returns>
        public int GetId(object param1, object param2)
        {
            return (int)this.tde.CUSTOMER.Where(x => x.CNAME.Equals(param1.ToString()) && x.CADRESS.Equals(param2.ToString())).Single().CUSTOMER_ID;
        }

        /// <summary>
        /// Returns the last used id in the table.
        /// </summary>
        /// <returns>The last used id inn the table.</returns>
        public int GetLastId()
        {
            int max = 0;
            foreach (var item in this.tde.CUSTOMER)
            {
                int cur = (int)item.CUSTOMER_ID;
                if (max < cur)
                {
                    max = cur;
                }
            }

            return max;
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

        public void Insert(int id, string name, string andress, string phoneNum, string eMail)
        {
            throw new NotImplementedException();
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

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Makes a customer entity for adding a customer.
        /// </summary>
        /// <param name="id">The id of the customer.</param>
        /// <param name="name">Name of the new customer.</param>
        /// <param name="adress">Adress of the new customer.</param>
        /// <param name="phoneNum">The phone number of the new customer.</param>
        /// <param name="e_mail">The e-mail adress of the new customer.</param>
        /// <returns>A customer entity.</returns>
        public CUSTOMER ToCustomer(int id, string name, string adress, string phoneNum, string e_mail)
        {
            return new CUSTOMER
            {
                CUSTOMER_ID = id,
                CNAME = name,
                CADRESS = adress,
                CPHONE_NUM = phoneNum,
                CE_MAIL = e_mail
            };
        }

        /// <summary>
        /// Makes a customer entity for searching and removeing.
        /// </summary>
        /// <param name="name">Name of the customer.</param>
        /// <param name="adress">Adress of the customer.</param>
        /// <returns>A customer entity</returns>
        public CUSTOMER ToCustomer(string name, string adress)
        {
            return new CUSTOMER
            {
                CNAME = name,
                CADRESS = adress
            };
        }

        List<string[]> IRepository<CUSTOMER>.GetTable()
        {
            throw new NotImplementedException();
        }
    }
}
