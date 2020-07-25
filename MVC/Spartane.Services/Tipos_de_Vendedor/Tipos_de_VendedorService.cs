using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Tipos_de_Vendedor;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tipos_de_Vendedor
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tipos_de_VendedorService : ITipos_de_VendedorService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Tipos_de_Vendedor.Tipos_de_Vendedor> _Tipos_de_VendedorRepository;
        #endregion

        #region Ctor
        public Tipos_de_VendedorService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Tipos_de_Vendedor.Tipos_de_Vendedor> Tipos_de_VendedorRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tipos_de_VendedorRepository = Tipos_de_VendedorRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Tipos_de_Vendedor.Tipos_de_Vendedor> SelAll(bool ConRelaciones)
        {
            return this._Tipos_de_VendedorRepository.Table.ToList();
        }

        public IList<Core.Domain.Tipos_de_Vendedor.Tipos_de_Vendedor> SelAllComplete(bool ConRelaciones)
        {
            return this._Tipos_de_VendedorRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Tipos_de_Vendedor.Tipos_de_Vendedor> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipos_de_VendedorRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Tipos_de_Vendedor.Tipos_de_Vendedor> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tipos_de_VendedorRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Tipos_de_Vendedor.Tipos_de_Vendedor> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipos_de_VendedorRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Tipos_de_Vendedor.Tipos_de_VendedorPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Tipos_de_VendedorPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Tipos_de_Vendedor.Tipos_de_Vendedor> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tipos_de_VendedorRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Tipos_de_Vendedor.Tipos_de_Vendedor GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Tipos_de_Vendedor.Tipos_de_Vendedor result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Tipos_de_VendedorInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Tipos_de_Vendedor.Tipos_de_Vendedor entity, Spartane.Core.Domain.User.GlobalData Tipos_de_VendedorInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Tipos_de_Vendedor.Tipos_de_Vendedor entity, Spartane.Core.Domain.User.GlobalData Tipos_de_VendedorInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

