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
        public void ChangeAdress(int id, string newAdress)
        {
            throw new NotImplementedException();
        }

        public void ChangeEmail(int id, string newEmail)
        {
            throw new NotImplementedException();
        }

        public void ChangePhoneNum(int id, string newPhoneNum)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CUSTOMER> GetTable()
        {
            throw new NotImplementedException();
        }

        public void Insert(CUSTOMER entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(CUSTOMER entity)
        {
            throw new NotImplementedException();
        }
    }
}
