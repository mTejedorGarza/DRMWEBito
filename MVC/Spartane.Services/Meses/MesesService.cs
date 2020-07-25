using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Meses;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Meses
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MesesService : IMesesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Meses.Meses> _MesesRepository;
        #endregion

        #region Ctor
        public MesesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Meses.Meses> MesesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MesesRepository = MesesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Meses.Meses> SelAll(bool ConRelaciones)
        {
            return this._MesesRepository.Table.ToList();
        }

        public IList<Core.Domain.Meses.Meses> SelAllComplete(bool ConRelaciones)
        {
            return this._MesesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Meses.Meses> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MesesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Meses.Meses> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MesesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Meses.Meses> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MesesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Meses.MesesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MesesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Meses.Meses> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MesesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Meses.Meses GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Meses.Meses result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MesesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Meses.Meses entity, Spartane.Core.Domain.User.GlobalData MesesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Meses.Meses entity, Spartane.Core.Domain.User.GlobalData MesesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

