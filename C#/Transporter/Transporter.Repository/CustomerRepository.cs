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
        /// Retturns all customers in a list.
        /// </summary>
        /// <returns>Everything from the Customer table.</returns>
        public List<string[]> GetTable()
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
        /// <param name="id">The id of the customer to remove.</param>
        public void Remove(int id)
        {
            this.tde.CUSTOMER.Remove(this.tde.CUSTOMER.Where(x => x.CUSTOMER_ID.Equals(id)).Single());
            this.tde.SaveChanges();
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
    }
}
