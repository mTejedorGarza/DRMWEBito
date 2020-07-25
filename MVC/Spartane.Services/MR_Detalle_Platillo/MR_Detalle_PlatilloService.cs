using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MR_Detalle_Platillo;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MR_Detalle_Platillo
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MR_Detalle_PlatilloService : IMR_Detalle_PlatilloService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo> _MR_Detalle_PlatilloRepository;
        #endregion

        #region Ctor
        public MR_Detalle_PlatilloService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo> MR_Detalle_PlatilloRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MR_Detalle_PlatilloRepository = MR_Detalle_PlatilloRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo> SelAll(bool ConRelaciones)
        {
            return this._MR_Detalle_PlatilloRepository.Table.ToList();
        }

        public IList<Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo> SelAllComplete(bool ConRelaciones)
        {
            return this._MR_Detalle_PlatilloRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MR_Detalle_PlatilloRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MR_Detalle_PlatilloRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MR_Detalle_PlatilloRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_PlatilloPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MR_Detalle_PlatilloPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MR_Detalle_PlatilloRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MR_Detalle_PlatilloInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo entity, Spartane.Core.Domain.User.GlobalData MR_Detalle_PlatilloInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MR_Detalle_Platillo.MR_Detalle_Platillo entity, Spartane.Core.Domain.User.GlobalData MR_Detalle_PlatilloInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

