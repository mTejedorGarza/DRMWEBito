using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MS_Calorias;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Calorias
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_CaloriasService : IMS_CaloriasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MS_Calorias.MS_Calorias> _MS_CaloriasRepository;
        #endregion

        #region Ctor
        public MS_CaloriasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MS_Calorias.MS_Calorias> MS_CaloriasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_CaloriasRepository = MS_CaloriasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MS_Calorias.MS_Calorias> SelAll(bool ConRelaciones)
        {
            return this._MS_CaloriasRepository.Table.ToList();
        }

        public IList<Core.Domain.MS_Calorias.MS_Calorias> SelAllComplete(bool ConRelaciones)
        {
            return this._MS_CaloriasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MS_Calorias.MS_Calorias> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_CaloriasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Calorias.MS_Calorias> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_CaloriasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Calorias.MS_Calorias> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_CaloriasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Calorias.MS_CaloriasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MS_CaloriasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MS_Calorias.MS_Calorias> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_CaloriasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Calorias.MS_Calorias GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MS_Calorias.MS_Calorias result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MS_CaloriasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MS_Calorias.MS_Calorias entity, Spartane.Core.Domain.User.GlobalData MS_CaloriasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MS_Calorias.MS_Calorias entity, Spartane.Core.Domain.User.GlobalData MS_CaloriasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

