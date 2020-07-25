using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Nombre_del_campo_en_MS;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Nombre_del_campo_en_MS
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Nombre_del_campo_en_MSService : INombre_del_campo_en_MSService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> _Nombre_del_campo_en_MSRepository;
        #endregion

        #region Ctor
        public Nombre_del_campo_en_MSService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> Nombre_del_campo_en_MSRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Nombre_del_campo_en_MSRepository = Nombre_del_campo_en_MSRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> SelAll(bool ConRelaciones)
        {
            return this._Nombre_del_campo_en_MSRepository.Table.ToList();
        }

        public IList<Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> SelAllComplete(bool ConRelaciones)
        {
            return this._Nombre_del_campo_en_MSRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Nombre_del_campo_en_MSRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Nombre_del_campo_en_MSRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Nombre_del_campo_en_MSRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MSPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Nombre_del_campo_en_MSPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Nombre_del_campo_en_MSRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Nombre_del_campo_en_MSInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS entity, Spartane.Core.Domain.User.GlobalData Nombre_del_campo_en_MSInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS entity, Spartane.Core.Domain.User.GlobalData Nombre_del_campo_en_MSInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

