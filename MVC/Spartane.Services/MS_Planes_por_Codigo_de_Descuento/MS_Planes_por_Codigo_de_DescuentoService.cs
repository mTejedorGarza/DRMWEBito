using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MS_Planes_por_Codigo_de_Descuento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Planes_por_Codigo_de_Descuento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Planes_por_Codigo_de_DescuentoService : IMS_Planes_por_Codigo_de_DescuentoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento> _MS_Planes_por_Codigo_de_DescuentoRepository;
        #endregion

        #region Ctor
        public MS_Planes_por_Codigo_de_DescuentoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento> MS_Planes_por_Codigo_de_DescuentoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Planes_por_Codigo_de_DescuentoRepository = MS_Planes_por_Codigo_de_DescuentoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento> SelAll(bool ConRelaciones)
        {
            return this._MS_Planes_por_Codigo_de_DescuentoRepository.Table.ToList();
        }

        public IList<Core.Domain.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento> SelAllComplete(bool ConRelaciones)
        {
            return this._MS_Planes_por_Codigo_de_DescuentoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Planes_por_Codigo_de_DescuentoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Planes_por_Codigo_de_DescuentoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Planes_por_Codigo_de_DescuentoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_DescuentoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MS_Planes_por_Codigo_de_DescuentoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Planes_por_Codigo_de_DescuentoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MS_Planes_por_Codigo_de_DescuentoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento entity, Spartane.Core.Domain.User.GlobalData MS_Planes_por_Codigo_de_DescuentoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento entity, Spartane.Core.Domain.User.GlobalData MS_Planes_por_Codigo_de_DescuentoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

