// <copyright file="DriverRepository.cs" company="PlaceholderCompany">
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
    /// Repository for the driver table.
    /// </summary>
    class DriverRepository : IDriverRepository
    {
        public void ChangeAdress(int id, string newAdress)
        {
            throw new NotImplementedException();
        }

        public void ChangeLicPlate(int id, string newLicPlate)
        {
            throw new NotImplementedException();
        }

        public void ChangePhoneNum(int id, string newPhoneNum)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DRIVER> GetTable()
        {
            throw new NotImplementedException();
        }

        public void Insert(DRIVER entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(DRIVER entity)
        {
            throw new NotImplementedException();
        }
    }
}
