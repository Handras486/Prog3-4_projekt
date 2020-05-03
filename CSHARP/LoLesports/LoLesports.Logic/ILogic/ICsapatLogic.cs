// <copyright file="ICsapatLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LoLesports.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LoLesports.Data;

    /// <summary>
    /// Interface of CsapatLogic.
    /// </summary>
    public interface ICsapatLogic
    {
        /// <summary>
        /// Updates an existing Csapat Element.
        /// </summary>
        /// <param name="csapatlist">Team parameters.</param>
        /// <returns>True/False.</returns>
        bool UpdateCsapatElement(List<object> csapatlist);

        /// <summary>
        /// Creates a new Csapat Element.
        /// </summary>
        /// <param name="csapatlist">Team parameters.</param>
        /// <returns>True/False.</returns>
        bool CreateCsapatElement(List<object> csapatlist);

        /// <summary>
        /// Deletes an existing Csapat Element.
        /// </summary>
        /// <param name="csapatnev">league name.</param>
        /// <returns>True/False.</returns>
        bool DeleteCsapatElement(string csapatnev);

        /// <summary>
        /// Stores Csapat data as string.
        /// </summary>
        /// <returns>Stringbuilder.</returns>
        StringBuilder GetCsapatData();

        /// <summary>
        /// Stores an element of Csapat as string.
        /// </summary>
        /// <param name="csapatnev">team name.</param>
        /// <returns>Stringbuilder.</returns>
        StringBuilder GetSingleCsapatData(string csapatnev);

        /// <summary>
        /// Gets an opponent, creates match, decides outcome.
        /// </summary>
        /// <param name="csapat1">input team.</param>
        /// <returns>match outcome.</returns>
        IEnumerable<string> MatchCreator(string csapat1);
    }
}
