// <copyright file="IJatekosLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LoLesports.Logic
{
    using LoLesports.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface of JatekosLogic.
    /// </summary>
    public interface IJatekosLogic
    {
        /// <summary>
        /// Updates an existing Jatekos Element.
        /// </summary>
        /// <param name="jatekoslist">Player parameters.</param>
        /// <returns>True/False.</returns>
        bool UpdateJatekosElement(List<object> jatekoslist);

        /// <summary>
        /// Creates a new Jatekos Element.
        /// </summary>
        /// <param name="jatekoslist">Player parameters.</param>
        /// <returns>True/False.</returns>
        bool CreateJatekosElement(List<object> jatekoslist);

        /// <summary>
        /// Deletes an existing Jatekos Element.
        /// </summary>
        /// <param name="felhasznalonev">username.</param>
        /// <returns>True/False.</returns>
        bool DeleteJatekosElement(string felhasznalonev);

        /// <summary>
        /// Stores Jatekos data as string.
        /// </summary>
        /// <returns>Stringbuilder.</returns>
        StringBuilder GetJatekosData();

        /// <summary>
        /// Stores an element of Jatekos as string.
        /// </summary>
        /// <param name="felhasznalonev">username.</param>
        /// <returns>Stringbuilder.</returns>
        StringBuilder GetSingleJatekosData(string felhasznalonev);

        /// <summary>
        /// Gets detailed information of player.
        /// </summary>
        /// <param name="felhasznalonev">username.</param>
        /// <returns>Stringbuilder.</returns>
        StringBuilder GetFullInfo(string felhasznalonev);

        /// <summary>
        /// Returns number of players by country.
        /// </summary>
        /// <returns>Stringbuilder.</returns>
        StringBuilder GetPlayersByCountry();

        /// <summary>
        /// Receives a randomised player from  a Java endpoint.
        /// </summary>
        /// <param name="name">username.</param>
        /// <returns>Stringbuilder.</returns>
        StringBuilder JavaVegpont(string name);

        /// <summary>
        /// Returns table data as a List.
        /// </summary>
        /// <returns>List.</returns>
        List<Jatekos> GetAll();

        /// <summary>
        /// Returns a Jatekos element.
        /// </summary>
        /// <returns>Jatekos.</returns>
        Jatekos GetOne(string felhasznalonev);
    }
}
