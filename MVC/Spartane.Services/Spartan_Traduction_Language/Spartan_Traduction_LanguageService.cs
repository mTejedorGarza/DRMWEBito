﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_Traduction_Language;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Traduction_Language
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Traduction_LanguageService : ISpartan_Traduction_LanguageService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language> _Spartan_Traduction_LanguageRepository;
        #endregion

        #region Ctor
        public Spartan_Traduction_LanguageService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language> Spartan_Traduction_LanguageRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Traduction_LanguageRepository = Spartan_Traduction_LanguageRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language> SelAll(bool ConRelaciones)
        {
            return this._Spartan_Traduction_LanguageRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_Traduction_LanguageRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Traduction_LanguageRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Traduction_LanguageRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Traduction_LanguageRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_LanguagePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_Traduction_LanguagePagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Traduction_LanguageRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Traduction_LanguageInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language entity, Spartane.Core.Domain.User.GlobalData Spartan_Traduction_LanguageInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_Traduction_Language.Spartan_Traduction_Language entity, Spartane.Core.Domain.User.GlobalData Spartan_Traduction_LanguageInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

