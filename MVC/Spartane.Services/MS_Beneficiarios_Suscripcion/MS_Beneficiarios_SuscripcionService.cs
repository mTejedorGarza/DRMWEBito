using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MS_Beneficiarios_Suscripcion;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Beneficiarios_Suscripcion
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Beneficiarios_SuscripcionService : IMS_Beneficiarios_SuscripcionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> _MS_Beneficiarios_SuscripcionRepository;
        #endregion

        #region Ctor
        public MS_Beneficiarios_SuscripcionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> MS_Beneficiarios_SuscripcionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Beneficiarios_SuscripcionRepository = MS_Beneficiarios_SuscripcionRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> SelAll(bool ConRelaciones)
        {
            return this._MS_Beneficiarios_SuscripcionRepository.Table.ToList();
        }

        public IList<Core.Domain.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> SelAllComplete(bool ConRelaciones)
        {
            return this._MS_Beneficiarios_SuscripcionRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Beneficiarios_SuscripcionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Beneficiarios_SuscripcionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Beneficiarios_SuscripcionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_SuscripcionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MS_Beneficiarios_SuscripcionPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Beneficiarios_SuscripcionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MS_Beneficiarios_SuscripcionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion entity, Spartane.Core.Domain.User.GlobalData MS_Beneficiarios_SuscripcionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion entity, Spartane.Core.Domain.User.GlobalData MS_Beneficiarios_SuscripcionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

