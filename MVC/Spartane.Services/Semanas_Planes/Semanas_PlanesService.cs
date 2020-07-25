using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Semanas_Planes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Semanas_Planes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Semanas_PlanesService : ISemanas_PlanesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Semanas_Planes.Semanas_Planes> _Semanas_PlanesRepository;
        #endregion

        #region Ctor
        public Semanas_PlanesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Semanas_Planes.Semanas_Planes> Semanas_PlanesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Semanas_PlanesRepository = Semanas_PlanesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Semanas_Planes.Semanas_Planes> SelAll(bool ConRelaciones)
        {
            return this._Semanas_PlanesRepository.Table.ToList();
        }

        public IList<Core.Domain.Semanas_Planes.Semanas_Planes> SelAllComplete(bool ConRelaciones)
        {
            return this._Semanas_PlanesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Semanas_Planes.Semanas_Planes> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Semanas_PlanesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Semanas_Planes.Semanas_Planes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Semanas_PlanesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Semanas_Planes.Semanas_Planes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Semanas_PlanesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Semanas_Planes.Semanas_PlanesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Semanas_PlanesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Semanas_Planes.Semanas_Planes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Semanas_PlanesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Semanas_Planes.Semanas_Planes GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Semanas_Planes.Semanas_Planes result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Semanas_PlanesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Semanas_Planes.Semanas_Planes entity, Spartane.Core.Domain.User.GlobalData Semanas_PlanesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Semanas_Planes.Semanas_Planes entity, Spartane.Core.Domain.User.GlobalData Semanas_PlanesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

