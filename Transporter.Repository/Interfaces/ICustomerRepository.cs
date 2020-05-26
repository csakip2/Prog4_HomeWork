// <copyright file="ICustomerRepository.cs" company="PlaceholderCompany">
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
    /// Repository interface for the customer specific methods.
    /// </summary>
    public interface ICustomerRepository : IRepository<CUSTOMER>
    {
        /// <summary>
        /// Gets the last id of the table.
        /// </summary>
        int LastId { get; }

        /// <summary>
        /// Changes a customers adress.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <param name="newAdress">The customers new adress.</param>
        void ChangeAdress(int id, string newAdress);

        /// <summary>
        /// Changes the customers phone number.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <param name="newPhoneNum">The new phone number of the customer.</param>
        void ChangePhoneNum(int id, string newPhoneNum);

        /// <summary>
        /// Changes the customers e-mail adress.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <param name="newEmail">The new e-mail adress.</param>
        void ChangeEmail(int id, string newEmail);

        /// <summary>
        /// Inserts an customer into the table.
        /// </summary>
        /// <param name="id">The customers id.</param>
        /// <param name="name">The customers name.</param>
        /// <param name="andress">The customers adress.</param>
        /// <param name="phoneNum">The customers phone number.</param>
        /// <param name="eMail">The customers e-mail adress.</param>
        void Insert(int id, string name, string andress, string phoneNum, string eMail);

        /// <summary>
        /// Returns the customers id.
        /// </summary>
        /// <param name="name">The customers name.</param>
        /// <param name="adress">The customers adress.</param>
        /// <returns>The customers id.</returns>
        int GetId(string name, string adress);

        /// <summary>
        /// Removes a given entity from a table.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        void Remove(int id);

        /// <summary>
        /// Returns all elements of a table in a string array list.
        /// </summary>
        /// <returns>All rows in a string array and the table in a list.</returns>
        List<string[]> GetTable();

        /// <summary>
        /// Afgasgsfg
        /// </summary>
        /// <returns>List.</returns>
        List<CUSTOMER> GetTableList();

        CUSTOMER GetOneCustomer(int id);
    }
}
