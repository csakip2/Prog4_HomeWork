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
    internal interface ICustomerRepository : IRepository<CUSTOMER>
    {
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
<<<<<<< HEAD
        /// Inserts an Entity into the table.
        /// </summary>
        /// <param name="id">The customers id.</param>
        /// <param name="name">The customers name.</param>
        /// <param name="andress">The customers adress.</param>
        /// <param name="phoneNum">The customers phone number.</param>
        /// <param name="eMail">The customers e-mail adress.</param>
        void Insert(int id, string name, string andress, string phoneNum, string eMail);

=======
        /// Makes a customer entity for adding a customer.
        /// </summary>
        /// <param name="id">The id of the customer.</param>
        /// <param name="name">Name of the new customer.</param>
        /// <param name="adress">Adress of the new customer.</param>
        /// <param name="phoneNum">The phone number of the new customer.</param>
        /// <param name="e_mail">The e-mail adress of the new customer.</param>
        /// <returns>A customer entity.</returns>
        CUSTOMER ToCustomer(int id, string name, string adress, string phoneNum, string e_mail);

        /// <summary>
        /// Makes a customer entity for searching and removeing.
        /// </summary>
        /// <param name="name">Name of the customer.</param>
        /// <param name="adress">Adress of the customer.</param>
        /// <returns>A customer entity</returns>
        CUSTOMER ToCustomer(string name, string adress);
>>>>>>> 8bcad6facdfd970043b969a09e216289604abee9
    }
}
