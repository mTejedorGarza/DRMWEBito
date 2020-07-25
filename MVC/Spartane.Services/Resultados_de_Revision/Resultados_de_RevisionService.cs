using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Resultados_de_Revision;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Resultados_de_Revision
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Resultados_de_RevisionService : IResultados_de_RevisionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision> _Resultados_de_RevisionRepository;
        #endregion

        #region Ctor
        public Resultados_de_RevisionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision> Resultados_de_RevisionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Resultados_de_RevisionRepository = Resultados_de_RevisionRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision> SelAll(bool ConRelaciones)
        {
            return this._Resultados_de_RevisionRepository.Table.ToList();
        }

        public IList<Core.Domain.Resultados_de_Revision.Resultados_de_Revision> SelAllComplete(bool ConRelaciones)
        {
            return this._Resultados_de_RevisionRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Resultados_de_RevisionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Resultados_de_RevisionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Resultados_de_RevisionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_RevisionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Resultados_de_RevisionPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Resultados_de_RevisionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Resultados_de_RevisionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision entity, Spartane.Core.Domain.User.GlobalData Resultados_de_RevisionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Resultados_de_Revision.Resultados_de_Revision entity, Spartane.Core.Domain.User.GlobalData Resultados_de_RevisionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

