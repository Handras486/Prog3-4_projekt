// <copyright file="CsapatLogic.cs" company="PlaceholderCompany">
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
    using LoLesports.Repository;

    /// <summary>
    /// Interface of CsapatLogic.
    /// </summary>
    public class CsapatLogic : ICsapatLogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CsapatLogic"/> class.
        /// </summary>
        public CsapatLogic()
        {
            this.CsapatRepository = new CsapatRepository() as IRepository<Csapat>;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CsapatLogic"/> class.
        /// </summary>
        /// <param name="csapatRepository">Repo for mocking.</param>
        public CsapatLogic(IRepository<Csapat> csapatRepository)
        {
            this.CsapatRepository = csapatRepository;
        }

        private IRepository<Csapat> CsapatRepository { get; set; }

        /// <inheritdoc/>
        public bool CreateCsapatElement(List<object> csapatlist)
        {
            if (this.CsapatRepository.GetTableElement((string)csapatlist[0]) == null)
            {
                this.CsapatRepository.CreateElement(csapatlist);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateCsapatElement(List<object> csapatlist)
        {
            if (this.CsapatRepository.GetTableElement((string)csapatlist[0]) != null)
            {
                this.CsapatRepository.UpdateElement(csapatlist);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool DeleteCsapatElement(string csapatnev)
        {
            if (this.CsapatRepository.GetTableElement(csapatnev) != null)
            {
                this.CsapatRepository.DeleteElement(csapatnev);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public StringBuilder GetCsapatData()
        {
            List<Csapat> templist = this.CsapatRepository.GetTableElements().ToList();
            return this.CsapatRepository.GetTableData(templist);
        }

        /// <inheritdoc/>
        public StringBuilder GetSingleCsapatData(string csapatnev)
        {
            Csapat temp = this.CsapatRepository.GetTableElement(csapatnev);
            return this.CsapatRepository.GetSingleTableData(temp);
        }

        /// <inheritdoc/>
        public IEnumerable<string> MatchCreator(string csapat1)
        {
            if (this.CsapatRepository.GetTableElement(csapat1) != null)
            {
                var ellenfelek = from csapat in this.CsapatRepository.GetTableElements().AsEnumerable()
                            where csapat.Bajnoksag_reszvetel == true && csapat.Csapatnev != csapat1
                            select csapat.Csapatnev;
                return ellenfelek;
            }
            else
            {
                return null;
            }
        }
    }
}
