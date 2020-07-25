using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MS_Campos_por_Funcionalidad;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Campos_por_Funcionalidad
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Campos_por_FuncionalidadService : IMS_Campos_por_FuncionalidadService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> _MS_Campos_por_FuncionalidadRepository;
        #endregion

        #region Ctor
        public MS_Campos_por_FuncionalidadService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> MS_Campos_por_FuncionalidadRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Campos_por_FuncionalidadRepository = MS_Campos_por_FuncionalidadRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> SelAll(bool ConRelaciones)
        {
            return this._MS_Campos_por_FuncionalidadRepository.Table.ToList();
        }

        public IList<Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> SelAllComplete(bool ConRelaciones)
        {
            return this._MS_Campos_por_FuncionalidadRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Campos_por_FuncionalidadRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Campos_por_FuncionalidadRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Campos_por_FuncionalidadRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_FuncionalidadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MS_Campos_por_FuncionalidadPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Campos_por_FuncionalidadRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MS_Campos_por_FuncionalidadInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad entity, Spartane.Core.Domain.User.GlobalData MS_Campos_por_FuncionalidadInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad entity, Spartane.Core.Domain.User.GlobalData MS_Campos_por_FuncionalidadInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

