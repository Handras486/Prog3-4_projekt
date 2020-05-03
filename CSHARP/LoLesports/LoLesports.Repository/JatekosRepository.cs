// <copyright file="JatekosRepository.cs" company="PlaceholderCompany">
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
    /// Repository of table Jatekos.
    /// </summary>
    public class JatekosRepository : TableRepository<Jatekos>
    {
        /// <inheritdoc/>
        public override void CreateElement(List<object> elementList)
        {
            Jatekos jatekos = new Jatekos();
            jatekos.Felhasznalonev = (string)elementList[0];
            jatekos.Vezeteknev = (string)elementList[1];
            jatekos.Keresztnev = (string)elementList[2];
            jatekos.Eletkor = (int?)elementList[3];
            jatekos.Pozicio = (string)elementList[4];
            jatekos.Nemzetiseg = (string)elementList[5];
            jatekos.Csapatnev = (string)elementList[6];
            this.DbEntity.Jatekos.Add(jatekos);
            this.DbEntity.SaveChanges();
        }

        /// <inheritdoc/>
        public override StringBuilder GetTableData(List<Jatekos> templist)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var x in templist)
            {
                sb.AppendLine("Felhasználónév: " + x.Felhasznalonev + ", Vezetéknév: " + x.Vezeteknev + ", Keresztnév: " + x.Keresztnev + ", Életkor: " + x.Eletkor + ", Pozíció: " + x.Pozicio + ", Nemzetiség: " + x.Nemzetiseg + ", Csapat: " + x.Csapatnev);
            }

            return sb;
        }

        /// <summary>
        /// Deletes an existing Jatekos Element.
        /// </summary>
        /// <param name="felhasznalonev">username.</param>
        public override void DeleteElement(string felhasznalonev)
        {
            Jatekos jatekos = this.GetTableElement(felhasznalonev);
            this.DbEntity.Jatekos.Remove(jatekos);
            this.DbEntity.SaveChanges();
        }

        /// <inheritdoc/>
        public override void UpdateElement(List<object> elementList)
        {
            Jatekos jatekos = this.GetTableElement((string)elementList[0]);
            jatekos.Vezeteknev = (string)elementList[1];
            jatekos.Keresztnev = (string)elementList[2];
            jatekos.Eletkor = (int?)elementList[3];
            jatekos.Pozicio = (string)elementList[4];
            jatekos.Nemzetiseg = (string)elementList[5];
            jatekos.Csapatnev = (string)elementList[6];
            this.DbEntity.SaveChanges();
        }

        /// <summary>
        /// Searches for a single Element of table Jatekos.
        /// </summary>
        /// <param name="felhasznalonev">username.</param>
        /// <returns>Jatekos Element.</returns>
        public override Jatekos GetTableElement(string felhasznalonev)
        {
            return this.DbEntity.Jatekos.Find(felhasznalonev);
        }

        /// <inheritdoc/>
        public override StringBuilder GetSingleTableData(Jatekos jatekos)
        {
            StringBuilder sb = new StringBuilder();

            if (jatekos != null)
            {
                sb.AppendLine("Felhasználónév: " + jatekos.Felhasznalonev + ", Vezetéknév: " + jatekos.Vezeteknev + ", Keresztnév: " + jatekos.Keresztnev + ", Életkor: " + jatekos.Eletkor + ", Pozíció: " + jatekos.Pozicio + ", Nemzetiség: " + jatekos.Nemzetiseg + ", Csapat: " + jatekos.Csapatnev);
            }
            else
            {
                sb.AppendLine("A név nincs az adatbázisban");
            }

            return sb;
        }
    }
}
