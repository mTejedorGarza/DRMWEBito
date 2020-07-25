using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Estatus_Ingredientes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_Ingredientes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_IngredientesService : IEstatus_IngredientesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Estatus_Ingredientes.Estatus_Ingredientes> _Estatus_IngredientesRepository;
        #endregion

        #region Ctor
        public Estatus_IngredientesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Estatus_Ingredientes.Estatus_Ingredientes> Estatus_IngredientesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_IngredientesRepository = Estatus_IngredientesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Estatus_Ingredientes.Estatus_Ingredientes> SelAll(bool ConRelaciones)
        {
            return this._Estatus_IngredientesRepository.Table.ToList();
        }

        public IList<Core.Domain.Estatus_Ingredientes.Estatus_Ingredientes> SelAllComplete(bool ConRelaciones)
        {
            return this._Estatus_IngredientesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Estatus_Ingredientes.Estatus_Ingredientes> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_IngredientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_Ingredientes.Estatus_Ingredientes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_IngredientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_Ingredientes.Estatus_Ingredientes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_IngredientesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_Ingredientes.Estatus_IngredientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Estatus_IngredientesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Estatus_Ingredientes.Estatus_Ingredientes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_IngredientesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_Ingredientes.Estatus_Ingredientes GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Estatus_Ingredientes.Estatus_Ingredientes result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Estatus_IngredientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Estatus_Ingredientes.Estatus_Ingredientes entity, Spartane.Core.Domain.User.GlobalData Estatus_IngredientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Estatus_Ingredientes.Estatus_Ingredientes entity, Spartane.Core.Domain.User.GlobalData Estatus_IngredientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

