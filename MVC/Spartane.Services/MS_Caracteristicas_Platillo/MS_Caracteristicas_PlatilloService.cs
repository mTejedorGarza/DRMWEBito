using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MS_Caracteristicas_Platillo;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Caracteristicas_Platillo
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Caracteristicas_PlatilloService : IMS_Caracteristicas_PlatilloService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> _MS_Caracteristicas_PlatilloRepository;
        #endregion

        #region Ctor
        public MS_Caracteristicas_PlatilloService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> MS_Caracteristicas_PlatilloRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Caracteristicas_PlatilloRepository = MS_Caracteristicas_PlatilloRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> SelAll(bool ConRelaciones)
        {
            return this._MS_Caracteristicas_PlatilloRepository.Table.ToList();
        }

        public IList<Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> SelAllComplete(bool ConRelaciones)
        {
            return this._MS_Caracteristicas_PlatilloRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Caracteristicas_PlatilloRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Caracteristicas_PlatilloRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Caracteristicas_PlatilloRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_PlatilloPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MS_Caracteristicas_PlatilloPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Caracteristicas_PlatilloRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MS_Caracteristicas_PlatilloInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo entity, Spartane.Core.Domain.User.GlobalData MS_Caracteristicas_PlatilloInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo entity, Spartane.Core.Domain.User.GlobalData MS_Caracteristicas_PlatilloInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

