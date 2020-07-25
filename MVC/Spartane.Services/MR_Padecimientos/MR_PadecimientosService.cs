using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MR_Padecimientos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MR_Padecimientos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MR_PadecimientosService : IMR_PadecimientosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MR_Padecimientos.MR_Padecimientos> _MR_PadecimientosRepository;
        #endregion

        #region Ctor
        public MR_PadecimientosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MR_Padecimientos.MR_Padecimientos> MR_PadecimientosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MR_PadecimientosRepository = MR_PadecimientosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MR_Padecimientos.MR_Padecimientos> SelAll(bool ConRelaciones)
        {
            return this._MR_PadecimientosRepository.Table.ToList();
        }

        public IList<Core.Domain.MR_Padecimientos.MR_Padecimientos> SelAllComplete(bool ConRelaciones)
        {
            return this._MR_PadecimientosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MR_Padecimientos.MR_Padecimientos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MR_PadecimientosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MR_Padecimientos.MR_Padecimientos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MR_PadecimientosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MR_Padecimientos.MR_Padecimientos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MR_PadecimientosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MR_Padecimientos.MR_PadecimientosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MR_PadecimientosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MR_Padecimientos.MR_Padecimientos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MR_PadecimientosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MR_Padecimientos.MR_Padecimientos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MR_Padecimientos.MR_Padecimientos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MR_PadecimientosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MR_Padecimientos.MR_Padecimientos entity, Spartane.Core.Domain.User.GlobalData MR_PadecimientosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MR_Padecimientos.MR_Padecimientos entity, Spartane.Core.Domain.User.GlobalData MR_PadecimientosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

