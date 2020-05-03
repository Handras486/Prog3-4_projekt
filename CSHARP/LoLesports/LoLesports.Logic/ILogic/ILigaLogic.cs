// <copyright file="ILigaLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LoLesports.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface of LigaLogic.
    /// </summary>
    public interface ILigaLogic
    {
        /// <summary>
        /// Updates an existing Liga Element.
        /// </summary>
        /// <param name="ligalist">League parameters.</param>
        /// <returns>True/False.</returns>
        bool UpdateLigaElement(List<object> ligalist);

        /// <summary>
        /// Creates a new Liga Element.
        /// </summary>
        /// <param name="ligalist">League parameters.</param>
        /// <returns>True/False.</returns>
        bool CreateLigaElement(List<object> ligalist);

        /// <summary>
        /// Deletes an existing Liga Element.
        /// </summary>
        /// <param name="liganev">league name.</param>
        /// <returns>True/False.</returns>
        bool DeleteLigaElement(string liganev);

        /// <summary>
        /// Stores Liga data as string.
        /// </summary>
        /// <returns>Stringbuilder.</returns>
        StringBuilder GetLigaData();

        /// <summary>
        /// Stores an element of Liga as string.
        /// </summary>
        /// <param name="liganev">league name.</param>
        /// <returns>Stringbuilder.</returns>
        StringBuilder GetSingleLigaData(string liganev);
    }
}
