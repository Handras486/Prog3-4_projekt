// <copyright file="LigaRepository.cs" company="PlaceholderCompany">
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
    /// Repository of table Liga.
    /// </summary>
    public class LigaRepository : TableRepository<Liga>
    {
        /// <inheritdoc/>
        public override void CreateElement(List<object> elementList)
        {
            Liga liga = new Liga();
            liga.Liga_nev = (string)elementList[0];
            liga.Regio = (string)elementList[1];
            liga.Studio_hely = (string)elementList[2];
            liga.Szezon_kezdet = (DateTime?)elementList[3];
            liga.Szezon_vege = (DateTime?)elementList[4];
            liga.Csapatok_szama = (int)elementList[5];
            this.DbEntity.Liga.Add(liga);
            this.DbEntity.SaveChanges();
        }

        /// <inheritdoc/>
        public override StringBuilder GetTableData(List<Liga> templist)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var x in templist)
            {
                sb.AppendLine("Liganév: " + x.Liga_nev + ", Régió: " + x.Regio + ", Stúdió helye: " + x.Studio_hely + ", Szezon kezdete: " + x.Szezon_kezdet + ", Szezon vége: " + x.Szezon_vege + ", Csapatok száma: " + x.Csapatok_szama);
            }

            return sb;
        }

        /// <summary>
        /// Deletes an existing Liga Element.
        /// </summary>
        /// <param name="liganev">league name.</param>
        public override void DeleteElement(string liganev)
        {
            Liga liga = this.GetTableElement(liganev);
            this.DbEntity.Liga.Remove(liga);
            this.DbEntity.SaveChanges();
        }

        /// <inheritdoc/>
        public override void UpdateElement(List<object> elementList)
        {
            Liga liga = this.GetTableElement((string)elementList[0]);
            liga.Regio = (string)elementList[1];
            liga.Studio_hely = (string)elementList[2];
            liga.Szezon_kezdet = (DateTime?)elementList[3];
            liga.Szezon_vege = (DateTime?)elementList[4];
            liga.Csapatok_szama = (int)elementList[5];
            this.DbEntity.SaveChanges();
        }

        /// <inheritdoc/>
        public override Liga GetTableElement(string liganev)
        {
            return this.DbEntity.Liga.Find(liganev);
        }

        /// <inheritdoc/>
        public override StringBuilder GetSingleTableData(Liga liga)
        {
            StringBuilder sb = new StringBuilder();

            if (liga != null)
            {
                sb.AppendLine("Liganév: " + liga.Liga_nev + ", Régió: " + liga.Regio + ", Stúdió helye: " + liga.Studio_hely + ", Szezon kezdete: " + liga.Szezon_kezdet + ", Szezon vége: " + liga.Szezon_vege + ", Csapatok száma: " + liga.Csapatok_szama);
            }
            else
            {
                sb.AppendLine("A név nincs az adatbázisban");
            }

            return sb;
        }
    }
}
