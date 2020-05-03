// <copyright file="TableRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LoLesports.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LoLesports.Data;

    /// <summary>
    /// Generic Repository.
    /// </summary>
    /// <typeparam name="T">Any repository.</typeparam>
    public abstract class TableRepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableRepository{T}"/> class.
        /// Initializes a new instance of <see cref="LoLesportsDBEntities1"/> if its null.
        /// </summary>
        public TableRepository()
        {
            if (this.DbEntity == null)
            {
                this.DbEntity = new LoLesportsDBEntities1();
            }
        }

        /// <summary>
        /// Gets or Sets DbEntity property.
        /// </summary>
        private protected LoLesportsDBEntities1 DbEntity { get; set; }

        /// <summary>
        /// Stores table data as string.
        /// </summary>
        /// <param name="list">List of table data.</param>
        /// <returns>Stringbuilder.</returns>
        public abstract StringBuilder GetTableData(List<T> list);

        /// <summary>
        /// Returns all elements of a table.
        /// </summary>
        /// <returns>Generic type query.</returns>
        public IQueryable<T> GetTableElements()
        {
            return this.DbEntity.Set<T>();
        }

        /// <summary>
        /// Searches for a single Element of a table.
        /// </summary>
        /// <param name="name">primary key of Element.</param>
        /// <returns>T Generic Element.</returns>
        public abstract T GetTableElement(string name);

        /// <summary>
        /// Create functionality from CRUD.
        /// </summary>
        /// <param name="elementList">List of new Element's properties.</param>
        public abstract void CreateElement(List<object> elementList);

        /// <summary>
        /// Update functionality from CRUD.
        /// </summary>
        /// <param name="elementList">List of new properties for an existing Element.</param>
        public abstract void UpdateElement(List<object> elementList);

        /// <summary>
        /// Delete functionality from CRUD.
        /// </summary>
        /// <param name="name">Deletes element by name.</param>
        public abstract void DeleteElement(string name);

        /// <inheritdoc/>
        public abstract StringBuilder GetSingleTableData(T name);
    }
}
