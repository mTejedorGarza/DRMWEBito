using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MR_Tarjetas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MR_Tarjetas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MR_TarjetasService : IMR_TarjetasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MR_Tarjetas.MR_Tarjetas> _MR_TarjetasRepository;
        #endregion

        #region Ctor
        public MR_TarjetasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MR_Tarjetas.MR_Tarjetas> MR_TarjetasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MR_TarjetasRepository = MR_TarjetasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MR_Tarjetas.MR_Tarjetas> SelAll(bool ConRelaciones)
        {
            return this._MR_TarjetasRepository.Table.ToList();
        }

        public IList<Core.Domain.MR_Tarjetas.MR_Tarjetas> SelAllComplete(bool ConRelaciones)
        {
            return this._MR_TarjetasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MR_Tarjetas.MR_Tarjetas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MR_TarjetasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MR_Tarjetas.MR_Tarjetas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MR_TarjetasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MR_Tarjetas.MR_Tarjetas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MR_TarjetasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MR_Tarjetas.MR_TarjetasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MR_TarjetasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MR_Tarjetas.MR_Tarjetas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MR_TarjetasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MR_Tarjetas.MR_Tarjetas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MR_Tarjetas.MR_Tarjetas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MR_TarjetasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MR_Tarjetas.MR_Tarjetas entity, Spartane.Core.Domain.User.GlobalData MR_TarjetasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MR_Tarjetas.MR_Tarjetas entity, Spartane.Core.Domain.User.GlobalData MR_TarjetasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

