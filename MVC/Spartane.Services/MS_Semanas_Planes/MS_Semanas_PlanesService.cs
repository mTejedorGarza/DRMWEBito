using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MS_Semanas_Planes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Semanas_Planes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Semanas_PlanesService : IMS_Semanas_PlanesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MS_Semanas_Planes.MS_Semanas_Planes> _MS_Semanas_PlanesRepository;
        #endregion

        #region Ctor
        public MS_Semanas_PlanesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MS_Semanas_Planes.MS_Semanas_Planes> MS_Semanas_PlanesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Semanas_PlanesRepository = MS_Semanas_PlanesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MS_Semanas_Planes.MS_Semanas_Planes> SelAll(bool ConRelaciones)
        {
            return this._MS_Semanas_PlanesRepository.Table.ToList();
        }

        public IList<Core.Domain.MS_Semanas_Planes.MS_Semanas_Planes> SelAllComplete(bool ConRelaciones)
        {
            return this._MS_Semanas_PlanesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MS_Semanas_Planes.MS_Semanas_Planes> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Semanas_PlanesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Semanas_Planes.MS_Semanas_Planes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Semanas_PlanesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Semanas_Planes.MS_Semanas_Planes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Semanas_PlanesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Semanas_Planes.MS_Semanas_PlanesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MS_Semanas_PlanesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MS_Semanas_Planes.MS_Semanas_Planes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Semanas_PlanesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Semanas_Planes.MS_Semanas_Planes GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MS_Semanas_Planes.MS_Semanas_Planes result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MS_Semanas_PlanesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MS_Semanas_Planes.MS_Semanas_Planes entity, Spartane.Core.Domain.User.GlobalData MS_Semanas_PlanesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MS_Semanas_Planes.MS_Semanas_Planes entity, Spartane.Core.Domain.User.GlobalData MS_Semanas_PlanesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

