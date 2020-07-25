using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MS_Padecimientos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Padecimientos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_PadecimientosService : IMS_PadecimientosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos> _MS_PadecimientosRepository;
        #endregion

        #region Ctor
        public MS_PadecimientosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos> MS_PadecimientosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_PadecimientosRepository = MS_PadecimientosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos> SelAll(bool ConRelaciones)
        {
            return this._MS_PadecimientosRepository.Table.ToList();
        }

        public IList<Core.Domain.MS_Padecimientos.MS_Padecimientos> SelAllComplete(bool ConRelaciones)
        {
            return this._MS_PadecimientosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_PadecimientosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_PadecimientosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_PadecimientosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Padecimientos.MS_PadecimientosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MS_PadecimientosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_PadecimientosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MS_PadecimientosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos entity, Spartane.Core.Domain.User.GlobalData MS_PadecimientosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MS_Padecimientos.MS_Padecimientos entity, Spartane.Core.Domain.User.GlobalData MS_PadecimientosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

