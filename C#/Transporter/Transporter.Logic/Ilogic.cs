// <copyright file="Ilogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Transporter.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Logic interface.
    /// </summary>
    internal interface ILogic
    {
        /// <summary>
        /// Retrives the customer table.
        /// </summary>
        /// <returns>All elements in a tring array.</returns>
        string[] RetriveCustomers();

        /// <summary>
        /// Retrives the pakage table.
        /// </summary>
        /// <returns>All elements in a tring array.</returns>
        string[] RetrivePakages();

        /// <summary>
        /// Retrives the driver table.
        /// </summary>
        /// <returns>All elements in a tring array.</returns>
        string[] RetriveDrivers();
    }
}
