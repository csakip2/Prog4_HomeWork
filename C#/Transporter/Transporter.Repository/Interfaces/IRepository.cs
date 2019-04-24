// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Transporter.Repository
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Generic interface for repositories.
    /// Contains all needed CRUD methods.
    /// </summary>
    /// <typeparam name="TEntity">Generic TEntity for all enttities.</typeparam>
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Returns all elements of a table in a string array list.
        /// </summary>
        /// <returns>All rows in a string array and the table in a list.</returns>
        List<string[]> GetTable();

        /// <summary>
        /// Removes a given entity from a table.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        void Remove(int id);

        /// <summary>
        /// Gets the id of an entity from a table.
        /// </summary>
        /// <param name="param1">Parameter1 (name, senderid) for geting the id.</param>
        /// <param name="param2">Parameter2 (adress, reciverid) for geting the id.</param>
        /// <returns>The id of the entity.</returns>
        int GetId(object param1, object param2);

        /// <summary>
        /// Gets the last used id in the table.
        /// </summary>
        /// <returns>The last used id.</returns>
        int GetLastId();
    }
}
