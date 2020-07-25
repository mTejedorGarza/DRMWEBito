using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Subgrupos_Ingredientes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Subgrupos_Ingredientes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Subgrupos_IngredientesService : ISubgrupos_IngredientesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Subgrupos_Ingredientes.Subgrupos_Ingredientes> _Subgrupos_IngredientesRepository;
        #endregion

        #region Ctor
        public Subgrupos_IngredientesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Subgrupos_Ingredientes.Subgrupos_Ingredientes> Subgrupos_IngredientesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Subgrupos_IngredientesRepository = Subgrupos_IngredientesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Subgrupos_Ingredientes.Subgrupos_Ingredientes> SelAll(bool ConRelaciones)
        {
            return this._Subgrupos_IngredientesRepository.Table.ToList();
        }

        public IList<Core.Domain.Subgrupos_Ingredientes.Subgrupos_Ingredientes> SelAllComplete(bool ConRelaciones)
        {
            return this._Subgrupos_IngredientesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Subgrupos_Ingredientes.Subgrupos_Ingredientes> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Subgrupos_IngredientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Subgrupos_Ingredientes.Subgrupos_Ingredientes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Subgrupos_IngredientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Subgrupos_Ingredientes.Subgrupos_Ingredientes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Subgrupos_IngredientesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Subgrupos_Ingredientes.Subgrupos_IngredientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Subgrupos_IngredientesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Subgrupos_Ingredientes.Subgrupos_Ingredientes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Subgrupos_IngredientesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Subgrupos_Ingredientes.Subgrupos_Ingredientes GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Subgrupos_Ingredientes.Subgrupos_Ingredientes result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Subgrupos_IngredientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Subgrupos_Ingredientes.Subgrupos_Ingredientes entity, Spartane.Core.Domain.User.GlobalData Subgrupos_IngredientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Subgrupos_Ingredientes.Subgrupos_Ingredientes entity, Spartane.Core.Domain.User.GlobalData Subgrupos_IngredientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

