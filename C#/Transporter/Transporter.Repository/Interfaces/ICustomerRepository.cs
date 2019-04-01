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

    /// <summary>
    /// Repository interface for the customer specific methods.
    /// </summary>
    internal interface ICustomerRepository : IRepository<Data.CUSTOMER>
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
    }
}
