using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Pagos_Pacientes_OpenPay
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Pagos_Pacientes_OpenPayService : IDetalle_Pagos_Pacientes_OpenPayService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> _Detalle_Pagos_Pacientes_OpenPayRepository;
        #endregion

        #region Ctor
        public Detalle_Pagos_Pacientes_OpenPayService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> Detalle_Pagos_Pacientes_OpenPayRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Pagos_Pacientes_OpenPayRepository = Detalle_Pagos_Pacientes_OpenPayRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Pagos_Pacientes_OpenPayRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Pagos_Pacientes_OpenPayRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Pagos_Pacientes_OpenPayRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Pagos_Pacientes_OpenPayRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Pagos_Pacientes_OpenPayRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPayPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Pagos_Pacientes_OpenPayPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Pagos_Pacientes_OpenPayRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Pagos_Pacientes_OpenPayInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay entity, Spartane.Core.Domain.User.GlobalData Detalle_Pagos_Pacientes_OpenPayInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay entity, Spartane.Core.Domain.User.GlobalData Detalle_Pagos_Pacientes_OpenPayInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

