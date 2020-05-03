// <copyright file="LigaLogic.cs" company="PlaceholderCompany">
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
    using LoLesports.Data;
    using LoLesports.Repository;

    /// <summary>
    /// Interface of LigaLogic.
    /// </summary>
    public class LigaLogic : ILigaLogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LigaLogic"/> class.
        /// </summary>
        public LigaLogic()
        {
            this.LigaRepository = new LigaRepository() as IRepository<Liga>;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LigaLogic"/> class.
        /// </summary>
        /// <param name="ligaRepository">Repo only for mocking.</param>
        public LigaLogic(IRepository<Liga> ligaRepository)
        {
            this.LigaRepository = ligaRepository;
        }

        private IRepository<Liga> LigaRepository { get; set; }

        /// <inheritdoc/>
        public bool CreateLigaElement(List<object> ligalist)
        {
            if (this.LigaRepository.GetTableElement((string)ligalist[0]) == null)
            {
                this.LigaRepository.CreateElement(ligalist);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateLigaElement(List<object> ligalist)
        {
            if (this.LigaRepository.GetTableElement((string)ligalist[0]) != null)
            {
                this.LigaRepository.UpdateElement(ligalist);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool DeleteLigaElement(string liganev)
        {
            if (this.LigaRepository.GetTableElement(liganev) != null)
            {
                this.LigaRepository.DeleteElement(liganev);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public StringBuilder GetLigaData()
        {
            List<Liga> templist = this.LigaRepository.GetTableElements().ToList();
            return this.LigaRepository.GetTableData(templist);
        }

        /// <inheritdoc/>
        public StringBuilder GetSingleLigaData(string liganev)
        {
            Liga temp = this.LigaRepository.GetTableElement(liganev);
            return this.LigaRepository.GetSingleTableData(temp);
        }
    }
}
