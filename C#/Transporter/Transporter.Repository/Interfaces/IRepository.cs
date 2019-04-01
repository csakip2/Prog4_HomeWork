// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Transporter.Repository
{
    using System.Linq;

    /// <summary>
    /// Generic interface for repositories.
    /// Contains all needed CRUD methods.
    /// </summary>
    /// <typeparam name="TEntity">Generic TEntity for all enttities.</typeparam>
    internal interface IRepository<TEntity>
    {
        /// <summary>
        /// Returns all elements of a table as IQueryable.
        /// </summary>
        /// <returns>All element as IQueryable.</returns>
        IQueryable<TEntity> GetTable();

        /// <summary>
        /// Inserts an Entity into the table.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Removes the given entity.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        void Remove(TEntity entity);
    }
}
