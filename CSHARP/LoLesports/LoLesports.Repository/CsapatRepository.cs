// <copyright file="CsapatRepository.cs" company="PlaceholderCompany">
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
    /// Repository of table Csapat.
    /// </summary>
    public class CsapatRepository : TableRepository<Csapat>
    {
        /// <inheritdoc/>
        public override StringBuilder GetTableData(List<Csapat> templist)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var x in templist)
            {
                sb.AppendLine("Csapatnév: " + x.Csapatnev + ", Liganév: " + x.Liga_nev + ", Csapat rövidítés: " + x.Csapat_rovidites + ", Organizáció székhely: " + x.Org_szekhely + ", Alapítás dátuma: " + x.Alapitas_datum + ", Főedző: " + x.Fo_edzo + ", Bajnokság részvétel: " + x.Bajnoksag_reszvetel);
            }

            return sb;
        }

        /// <inheritdoc/>
        public override void DeleteElement(string csapatnev)
        {
            Csapat csapat = this.GetTableElement(csapatnev);
            this.DbEntity.Csapat.Remove(csapat);
            this.DbEntity.SaveChanges();
        }

        /// <inheritdoc/>
        public override Csapat GetTableElement(string csapatnev)
        {
            return this.DbEntity.Csapat.Find(csapatnev);
        }

        /// <inheritdoc/>
        public override void CreateElement(List<object> elementList)
        {
            Csapat csapat = new Csapat();
            csapat.Csapatnev = (string)elementList[0];
            csapat.Liga_nev = (string)elementList[1];
            csapat.Csapat_rovidites = (string)elementList[2];
            csapat.Org_szekhely = (string)elementList[3];
            csapat.Alapitas_datum = (DateTime?)elementList[4];
            csapat.Fo_edzo = (string)elementList[5];
            csapat.Bajnoksag_reszvetel = (bool)elementList[6];
            this.DbEntity.Csapat.Add(csapat);
            this.DbEntity.SaveChanges();
        }

        /// <inheritdoc/>
        public override void UpdateElement(List<object> elementList)
        {
            Csapat csapat = this.GetTableElement((string)elementList[0]);
            csapat.Liga_nev = (string)elementList[1];
            csapat.Csapat_rovidites = (string)elementList[2];
            csapat.Org_szekhely = (string)elementList[3];
            csapat.Alapitas_datum = (DateTime?)elementList[4];
            csapat.Fo_edzo = (string)elementList[5];
            csapat.Bajnoksag_reszvetel = (bool)elementList[6];
            this.DbEntity.SaveChanges();
        }

        /// <inheritdoc/>
        public override StringBuilder GetSingleTableData(Csapat csapat)
        {
            StringBuilder sb = new StringBuilder();

            if (csapat != null)
            {
                sb.AppendLine("Csapatnév: " + csapat.Csapatnev + ", Liganév: " + csapat.Liga_nev + ", Csapat rövidítés: " + csapat.Csapat_rovidites + ", Organizáció székhely: " + csapat.Org_szekhely + ", Alapítás dátuma: " + csapat.Alapitas_datum + ", Főedző: " + csapat.Fo_edzo + ", Bajnokság részvétel: " + csapat.Bajnoksag_reszvetel);
            }
            else
            {
                sb.AppendLine("A név nincs az adatbázisban");
            }

            return sb;
        }
    }
}
