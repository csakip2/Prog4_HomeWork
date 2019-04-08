// <copyright file="PakageRepository.cs" company="PlaceholderCompany">
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
    /// Repository for Pakages table.
    /// </summary>
    internal class PakageRepository : IPakageRepository
    {
        public void ChangeDriver(int id, int newDriverId)
        {
            throw new NotImplementedException();
        }

        public DRIVER GetDriver(int id)
        {
            throw new NotImplementedException();
        }

        public string[] GetRoute(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PAKAGE> GetTable()
        {
            throw new NotImplementedException();
        }

        public void Insert(PAKAGE entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(PAKAGE entity)
        {
            throw new NotImplementedException();
        }
    }
}
