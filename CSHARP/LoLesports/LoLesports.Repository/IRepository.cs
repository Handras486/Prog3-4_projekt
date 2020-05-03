// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LoLesports.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Generic interface for repositories.
    /// </summary>
    /// <typeparam name="T">Any table from DB.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Returns all elements of a table.
        /// </summary>
        /// <returns>Generic type query.</returns>
        IQueryable<T> GetTableElements();

        /// <summary>
        /// Searches for a single Element in a table.
        /// </summary>
        /// <param name="name">primary key of Element.</param>
        /// <returns>T Generic Element.</returns>
        T GetTableElement(string name);

        /// <summary>
        /// Read functionality from CRUD.
        /// </summary>
        /// <param name="list">List of table data.</param>
        /// <returns>Stringbuilder.</returns>
        StringBuilder GetTableData(List<T> list);

        /// <summary>
        /// Returns an element of a table as string.
        /// </summary>
        /// <param name="name">Returns an element by name.</param>
        /// <returns>Stringbuilder.</returns>
        StringBuilder GetSingleTableData(T name);

        /// <summary>
        /// Delete functionality from CRUD.
        /// </summary>
        /// <param name="name">Deletes element by name.</param>
        void DeleteElement(string name);

        /// <summary>
        /// Create functionality from CRUD.
        /// </summary>
        /// <param name="elementlist">List of new Element's properties.</param>
        void CreateElement(List<object> elementlist);

        /// <summary>
        /// Update functionality from CRUD.
        /// </summary>
        /// <param name="elementlist">List of new properties for an existing Element.</param>
        void UpdateElement(List<object> elementlist);
    }
}
