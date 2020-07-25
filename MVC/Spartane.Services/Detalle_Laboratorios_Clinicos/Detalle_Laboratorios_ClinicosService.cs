using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Laboratorios_Clinicos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Laboratorios_Clinicos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Laboratorios_ClinicosService : IDetalle_Laboratorios_ClinicosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> _Detalle_Laboratorios_ClinicosRepository;
        #endregion

        #region Ctor
        public Detalle_Laboratorios_ClinicosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> Detalle_Laboratorios_ClinicosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Laboratorios_ClinicosRepository = Detalle_Laboratorios_ClinicosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Laboratorios_ClinicosRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Laboratorios_ClinicosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Laboratorios_ClinicosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Laboratorios_ClinicosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Laboratorios_ClinicosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_ClinicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Laboratorios_ClinicosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Laboratorios_ClinicosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Laboratorios_ClinicosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos entity, Spartane.Core.Domain.User.GlobalData Detalle_Laboratorios_ClinicosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos entity, Spartane.Core.Domain.User.GlobalData Detalle_Laboratorios_ClinicosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

