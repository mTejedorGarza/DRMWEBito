using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Estatus_Workflow_Especialistas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_Workflow_Especialistas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_Workflow_EspecialistasService : IEstatus_Workflow_EspecialistasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas> _Estatus_Workflow_EspecialistasRepository;
        #endregion

        #region Ctor
        public Estatus_Workflow_EspecialistasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas> Estatus_Workflow_EspecialistasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_Workflow_EspecialistasRepository = Estatus_Workflow_EspecialistasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas> SelAll(bool ConRelaciones)
        {
            return this._Estatus_Workflow_EspecialistasRepository.Table.ToList();
        }

        public IList<Core.Domain.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas> SelAllComplete(bool ConRelaciones)
        {
            return this._Estatus_Workflow_EspecialistasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_Workflow_EspecialistasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_Workflow_EspecialistasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_Workflow_EspecialistasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_Workflow_Especialistas.Estatus_Workflow_EspecialistasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Estatus_Workflow_EspecialistasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_Workflow_EspecialistasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Estatus_Workflow_EspecialistasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas entity, Spartane.Core.Domain.User.GlobalData Estatus_Workflow_EspecialistasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas entity, Spartane.Core.Domain.User.GlobalData Estatus_Workflow_EspecialistasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

