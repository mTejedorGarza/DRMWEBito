using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MR_Referenciados_Codigo_de_Descuento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MR_Referenciados_Codigo_de_DescuentoService : IMR_Referenciados_Codigo_de_DescuentoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> _MR_Referenciados_Codigo_de_DescuentoRepository;
        #endregion

        #region Ctor
        public MR_Referenciados_Codigo_de_DescuentoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> MR_Referenciados_Codigo_de_DescuentoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MR_Referenciados_Codigo_de_DescuentoRepository = MR_Referenciados_Codigo_de_DescuentoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> SelAll(bool ConRelaciones)
        {
            return this._MR_Referenciados_Codigo_de_DescuentoRepository.Table.ToList();
        }

        public IList<Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> SelAllComplete(bool ConRelaciones)
        {
            return this._MR_Referenciados_Codigo_de_DescuentoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MR_Referenciados_Codigo_de_DescuentoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MR_Referenciados_Codigo_de_DescuentoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MR_Referenciados_Codigo_de_DescuentoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_DescuentoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MR_Referenciados_Codigo_de_DescuentoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MR_Referenciados_Codigo_de_DescuentoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MR_Referenciados_Codigo_de_DescuentoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento entity, Spartane.Core.Domain.User.GlobalData MR_Referenciados_Codigo_de_DescuentoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento entity, Spartane.Core.Domain.User.GlobalData MR_Referenciados_Codigo_de_DescuentoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

