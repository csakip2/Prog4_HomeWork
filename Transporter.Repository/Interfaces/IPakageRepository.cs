﻿// <copyright file="IPakageRepository.cs" company="PlaceholderCompany">
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
    /// Repository interface for pakage specific methods.
    /// </summary>
    public interface IPakageRepository : IRepository<PAKAGE>
    {
        /// <summary>
        /// Gets the last id of the table.
        /// </summary>
        int LastId { get; }

        /// <summary>
        /// Changes the pakages driver.
        /// </summary>
        /// <param name="id">Pakages id.</param>
        /// <param name="newDriverId">ID of the new driver.</param>
        void ChangeDriver(int id, int newDriverId);

        /// <summary>
        /// Returns the driver of the pakage.
        /// </summary>
        /// <param name="id">The id of the pakage.</param>
        /// <returns>Returns the drivers data in a string array.</returns>
        string[] GetDriver(int id);

        /// <summary>
        /// Returns the route of the pakage.
        /// </summary>
        /// <param name="id">The id of the pakage.</param>
        /// <returns>The route in "[0]from, [1](through driver), [2]to" string array.</returns>
        string[] GetRoute(int id);

        /// <summary>
        /// Inserts an Entity into the table.
        /// </summary>
        /// <param name="id">The pakages id.</param>
        /// <param name="senderId">The senders id.</param>
        /// <param name="receiverId">The recivers id.</param>
        /// <param name="weight">The pakages weight.</param>
        /// <param name="size">The pakages size.</param>
        /// <param name="driverId">The drivers id.</param>
        void Insert(int id, int senderId, int receiverId, int weight, string size, int driverId);

        /// <summary>
        /// Returns the pakages id.
        /// </summary>
        /// <param name="senderId">The sender id.</param>
        /// <param name="reciverId">The reciver id.</param>
        /// <returns>The pakages id.</returns>
        int GetId(int senderId, int reciverId);

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
    }
}
