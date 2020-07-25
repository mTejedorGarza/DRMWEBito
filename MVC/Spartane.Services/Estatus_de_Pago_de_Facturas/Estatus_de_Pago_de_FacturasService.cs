using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Estatus_de_Pago_de_Facturas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_de_Pago_de_Facturas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_de_Pago_de_FacturasService : IEstatus_de_Pago_de_FacturasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas> _Estatus_de_Pago_de_FacturasRepository;
        #endregion

        #region Ctor
        public Estatus_de_Pago_de_FacturasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas> Estatus_de_Pago_de_FacturasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_de_Pago_de_FacturasRepository = Estatus_de_Pago_de_FacturasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas> SelAll(bool ConRelaciones)
        {
            return this._Estatus_de_Pago_de_FacturasRepository.Table.ToList();
        }

        public IList<Core.Domain.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas> SelAllComplete(bool ConRelaciones)
        {
            return this._Estatus_de_Pago_de_FacturasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_de_Pago_de_FacturasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_de_Pago_de_FacturasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_de_Pago_de_FacturasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_FacturasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Estatus_de_Pago_de_FacturasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_de_Pago_de_FacturasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Estatus_de_Pago_de_FacturasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas entity, Spartane.Core.Domain.User.GlobalData Estatus_de_Pago_de_FacturasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas entity, Spartane.Core.Domain.User.GlobalData Estatus_de_Pago_de_FacturasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

