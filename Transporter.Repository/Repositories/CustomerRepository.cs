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
        /// Gets the last id of the table.
        /// </summary>
        public int LastId => this.GetLastId();

        /// <summary>
        /// Changes the customers adress.
        /// </summary>
        /// <param name="id">The customers id.</param>
        /// <param name="newAdress">The customers new adress.</param>
        public void ChangeAdress(int id, string newAdress)
        {
            this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID.ToString().Equals(id.ToString())).Single().CADRESS = newAdress;
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Changes the customers e-mail adress.
        /// </summary>
        /// <param name="id">The customers id.</param>
        /// <param name="newEmail">The customers new e-mail adress.</param>
        public void ChangeEmail(int id, string newEmail)
        {
            this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID.ToString().Equals(id.ToString())).Single().CE_MAIL = newEmail;
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Changes the customers phone number.
        /// </summary>
        /// <param name="id">The customers id.</param>
        /// <param name="newPhoneNum">The customers new phone number.</param>
        public void ChangePhoneNum(int id, string newPhoneNum)
        {
            this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID.ToString().Equals(id.ToString())).Single().CPHONE_NUM = newPhoneNum;
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Returns the customers id.
        /// </summary>
        /// <param name="name">The customers name.</param>
        /// <param name="adress">The customers adress.</param>
        /// <returns>The customers id.</returns>
        public int GetId(string name, string adress)
        {
            return this.GetIdGen(name, adress);
        }

        /// <summary>
        /// Returns the ID of the customer from its name and adress.
        /// </summary>
        /// <param name="param1">The customers name.</param>
        /// <param name="param2">The customers adress.</param>
        /// <returns>The ID of the customer.</returns>
        public int GetIdGen(object param1, object param2)
        {
            return (int)this.tde.CUSTOMER.Where(x => x.CNAME.ToString().Equals(param1.ToString()) && x.CADRESS.ToString().Equals(param2.ToString())).Single().CUSTOMER_ID;
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
        /// Gets the whole customer table.
        /// </summary>
        /// <returns>The customer table.</returns>
        public List<string[]> GetTable()
        {
            return this.GetTableGen();
        }

        /// <summary>
        /// Gets the whole customer table.
        /// </summary>
        /// <returns>The customer table.</returns>
        public List<CUSTOMER> GetTableList()
        {
            return this.tde.CUSTOMER.ToList();
        }

        /// <summary>
        /// Retturns all customers in a list.
        /// </summary>
        /// <returns>Everything from the Customer table.</returns>
        public List<string[]> GetTableGen()
        {
            List<string[]> table = new List<string[]>();

            foreach (var item in this.tde.CUSTOMER)
            {
                string[] row = new string[5];

                row[0] = item.CUSTOMER_ID.ToString();
                row[1] = item.CNAME.ToString();
                row[2] = item.CADRESS.ToString();
                row[3] = item.CE_MAIL.ToString();
                row[4] = item.CPHONE_NUM.ToString();

                table.Add(row);
            }

            return table;
        }

        /// <summary>
        /// Inserts an customer into the table.
        /// </summary>
        /// <param name="id">The customers id.</param>
        /// <param name="name">The customers name.</param>
        /// <param name="andress">The customers adress.</param>
        /// <param name="phoneNum">The customers phone number.</param>
        /// <param name="eMail">The customers e-mail adress.</param>
        public void Insert(int id, string name, string andress, string phoneNum, string eMail)
        {
            this.tde.CUSTOMER.Add(new CUSTOMER
            {
                CUSTOMER_ID = id,
                CNAME = name,
                CADRESS = andress,
                CPHONE_NUM = phoneNum,
                CE_MAIL = eMail
            });
            this.tde.SaveChanges();
        }

        /// <summary>
        /// Removes a customer from the table.
        /// </summary>
        /// <param name="id">The customers id.</param>
        public void Remove(int id)
        {
            this.RemoveGen(id);
        }

        /// <summary>
        /// Removes a customer from the table.
        /// </summary>
        /// <param name="id">The id of the customer to remove.</param>
        public void RemoveGen(int id)
        {
            this.tde.CUSTOMER.Remove(this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID.ToString().Equals(id.ToString())).Single());
            this.tde.SaveChanges();
        }

        public CUSTOMER GetOneCustomer(int id)
        {
            return this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID.ToString().Equals(id.ToString())).Single();
        }
    }
}
