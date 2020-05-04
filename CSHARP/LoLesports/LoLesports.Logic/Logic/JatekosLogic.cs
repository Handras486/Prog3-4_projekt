// <copyright file="JatekosLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LoLesports.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using LoLesports.Data;
    using LoLesports.Repository;

    /// <summary>
    /// Logic class of table Jatekos.
    /// </summary>
    public class JatekosLogic : IJatekosLogic
    {
        private readonly StringBuilder sb = new StringBuilder();

        /// <summary>
        /// Initializes a new instance of the <see cref="JatekosLogic"/> class.
        /// </summary>
        public JatekosLogic()
        {
            this.JatekosRepository = new JatekosRepository() as IRepository<Jatekos>;
            this.CsapatRepository = new CsapatRepository() as IRepository<Csapat>;
            this.LigaRepository = new LigaRepository() as IRepository<Liga>;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JatekosLogic"/> class.
        /// </summary>
        /// <param name="jatekosRepository">Jatekosrepo for mocking.</param>
        /// <param name="csapatRepository">Csapatrepo for mocking.</param>
        /// <param name="ligaRepository">Ligarepo for mocking.</param>
        public JatekosLogic(IRepository<Jatekos> jatekosRepository, IRepository<Csapat> csapatRepository, IRepository<Liga> ligaRepository)
        {
            this.JatekosRepository = jatekosRepository;
            this.CsapatRepository = csapatRepository;
            this.LigaRepository = ligaRepository;
        }

        private IRepository<Jatekos> JatekosRepository { get; set; }

        private IRepository<Csapat> CsapatRepository { get; set; }

        private IRepository<Liga> LigaRepository { get; set; }

        /// <inheritdoc/>
        public bool CreateJatekosElement(List<object> jatekoslist)
        {
            if (this.JatekosRepository.GetTableElement((string)jatekoslist[0]) == null)
            {
                this.JatekosRepository.CreateElement(jatekoslist);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateJatekosElement(List<object> jatekoslist)
        {
            if (this.JatekosRepository.GetTableElement((string)jatekoslist[0]) != null)
            {
                this.JatekosRepository.UpdateElement(jatekoslist);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool DeleteJatekosElement(string felhasznalonev)
        {
            if (this.JatekosRepository.GetTableElement(felhasznalonev) != null)
            {
                this.JatekosRepository.DeleteElement(felhasznalonev);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public StringBuilder GetJatekosData()
        {
            List<Jatekos> templist = this.JatekosRepository.GetTableElements().ToList();
            return this.JatekosRepository.GetTableData(templist);
        }

        /// <inheritdoc/>
        public List<Jatekos> GetAll()
        {
            return this.JatekosRepository.GetTableElements().ToList();
        }

        /// <inheritdoc/>
        public StringBuilder GetSingleJatekosData(string felhasznalonev)
        {
            Jatekos temp = this.JatekosRepository.GetTableElement(felhasznalonev);
            return this.JatekosRepository.GetSingleTableData(temp);
        }

        /// <inheritdoc/>
        public Jatekos GetOne(string felhasznalonev)
        {
            return this.JatekosRepository.GetTableElement(felhasznalonev);
        }

        /// <inheritdoc/>
        public StringBuilder GetFullInfo(string felhasznalonev)
        {
            StringBuilder sb = new StringBuilder();
            if (this.JatekosRepository.GetTableElement(felhasznalonev) != null)
            {
                var query1 = from jatekos in this.JatekosRepository.GetTableElements().AsEnumerable()
                             join csapat in this.CsapatRepository.GetTableElements().AsEnumerable() on jatekos.Csapatnev equals csapat.Csapatnev
                             join liga in this.LigaRepository.GetTableElements().AsEnumerable() on csapat.Liga_nev equals liga.Liga_nev
                             where jatekos.Felhasznalonev == felhasznalonev
                             select new { jatekos.Felhasznalonev, csapat.Csapatnev, liga.Liga_nev };

                var query2 = from jatekos in this.JatekosRepository.GetTableElements().AsEnumerable()
                             where jatekos.Csapatnev == this.JatekosRepository.GetTableElement(felhasznalonev).Csapatnev
                             group jatekos by jatekos.Csapatnev into g
                             orderby g.Count()
                             select g.Count();

                foreach (var q in query1)
                {
                    sb.Append("Felhasználónév: " + q.Felhasznalonev + ", Csapatnév: " + q.Csapatnev + ", Liganév: " + q.Liga_nev);
                }

                foreach (var q in query2)
                {
                    sb.Append(", Csapat játékosainak száma: " + q);
                }
            }
            else
            {
                sb.AppendLine("A játékos nem létezik");
            }

            return sb;
        }

        /// <inheritdoc/>
        public StringBuilder GetPlayersByCountry()
        {
            StringBuilder sb = new StringBuilder();

            var query1 =
            from jatekos in this.JatekosRepository.GetTableElements().AsEnumerable()
            group jatekos by jatekos.Nemzetiseg into g
            orderby g.Count() descending
            select new { Nemzetiség = g.Key, Játékosok_száma = g.Count() };

            foreach (var item in query1)
            {
                sb.AppendLine("Nemzetiség: " + item.Nemzetiség + ", Játékosok száma: " + item.Játékosok_száma + " .");
            }

            return sb;
        }

        /// <inheritdoc/>
        public StringBuilder JavaVegpont(string name)
        {
            StringBuilder sb = new StringBuilder();

            string nev = name;
            XDocument xDoc = XDocument.Load($"http://localhost:8080/LoLesports.Java/Jatekos?nev={nev}");

            sb.Append("Játékos neve: ");
            var q1 = xDoc.Descendants("nev").First().Value;
            sb.AppendLine(q1);
            sb.Append("Csapata : ");
            var q2 = xDoc.Descendants("csapatrov").First().Value;
            sb.AppendLine(q2);
            sb.Append("Életkora : ");
            var q3 = xDoc.Descendants("eletkor").First().Value;
            sb.AppendLine(q3);
            sb.Append("Pozíciója : ");
            var q4 = xDoc.Descendants("pozicio").First().Value;
            sb.AppendLine(q4);
            sb.Append("Nemzetisége : ");
            var q5 = xDoc.Descendants("nemzetiseg").First().Value;
            sb.AppendLine(q5);

            return sb;
        }

        /// <summary>
        /// Checks internet connection.
        /// If True, opens online Database.
        /// </summary>
        /// <returns>ping info, website.</returns>
        public StringBuilder OnlineDB()
        {
            string internetcheck = "google.com";
            string website = "https://docs.google.com/spreadsheets/d/1Y7k5kQ2AegbuyiGwEPsa62e883FYVtHqr6UVut9RC4o/pubhtml#";

            Process process = Process.Start(new ProcessStartInfo("ping", internetcheck)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            });
            process.EnableRaisingEvents = true;
            process.Exited += this.Process_Exited;

            if (!process.HasExited)
            {
                process.WaitForExit();
            }

            _ = Process.Start(website);

            return this.sb;
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            this.sb.AppendLine("Process neve: " + (sender as Process)?.Id + " befejeződött " + DateTime.Now);
            this.sb.AppendLine((sender as Process)?.StandardOutput.ReadToEnd());
            this.sb.AppendLine("Van internetelérés!");
            this.sb.AppendLine();
            this.sb.AppendLine("Csatlakozás az online adatbázishoz.");
        }
    }
}
