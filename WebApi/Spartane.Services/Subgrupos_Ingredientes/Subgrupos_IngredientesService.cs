using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Subgrupos_Ingredientes;
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
        private readonly IRepository<Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes> _Subgrupos_IngredientesRepository;
        #endregion

        #region Ctor
        public Subgrupos_IngredientesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes> Subgrupos_IngredientesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Subgrupos_IngredientesRepository = Subgrupos_IngredientesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Subgrupos_IngredientesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes>("sp_SelAllSubgrupos_Ingredientes");
        }

        public IList<Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSubgrupos_Ingredientes_Complete>("sp_SelAllComplete_Subgrupos_Ingredientes");
            return data.Select(m => new Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes
            {
                Folio = m.Folio
                ,Nombre = m.Nombre
                ,Clasificacion_Clasificacion_Ingredientes = new Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes() { Clave = m.Clasificacion.GetValueOrDefault(), Descripcion = m.Clasificacion_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Subgrupos_Ingredientes>("sp_ListSelCount_Subgrupos_Ingredientes", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes> SelAll(bool ConRelaciones, string Where, string Order)
        {
            try
            {
                var padreWhere = _dataProvider.GetParameter();
                padreWhere.ParameterName = "Where";
                padreWhere.DbType = DbType.String;

                padreWhere.Value = Where;

                var padreOrderBy = _dataProvider.GetParameter();
                padreOrderBy.ParameterName = "Order";
                padreOrderBy.DbType = DbType.String;
                padreOrderBy.Value = Order;


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSubgrupos_Ingredientes>("sp_ListSelAll_Subgrupos_Ingredientes", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes
                {
                    Folio = m.Subgrupos_Ingredientes_Folio,
                    Nombre = m.Subgrupos_Ingredientes_Nombre,
                    Clasificacion = m.Subgrupos_Ingredientes_Clasificacion,

                    //Id = m.Id,
                }).ToList();
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

        }

        public IList<Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Subgrupos_IngredientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Subgrupos_IngredientesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_IngredientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            var padstartRowIndex = _dataProvider.GetParameter();
            padstartRowIndex.ParameterName = "startRowIndex";
            padstartRowIndex.DbType = DbType.Int32;
            padstartRowIndex.Value = startRowIndex;

            var padmaximumRows = _dataProvider.GetParameter();
            padmaximumRows.ParameterName = "maximumRows";
            padmaximumRows.DbType = DbType.Int32;
            padmaximumRows.Value = maximumRows;

            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var padOrder = _dataProvider.GetParameter();
            padOrder.ParameterName = "Order";
            padOrder.DbType = DbType.String;
            padOrder.Value = Order;

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSubgrupos_Ingredientes>("sp_ListSelAll_Subgrupos_Ingredientes", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Subgrupos_IngredientesPagingModel result = null;

            if (data != null)
            {
                result = new Subgrupos_IngredientesPagingModel
                {
                    Subgrupos_Ingredientess =
                        data.Select(m => new Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes
                {
                    Folio = m.Subgrupos_Ingredientes_Folio
                    ,Nombre = m.Subgrupos_Ingredientes_Nombre
                    ,Clasificacion = m.Subgrupos_Ingredientes_Clasificacion
                    ,Clasificacion_Clasificacion_Ingredientes = new Core.Classes.Clasificacion_Ingredientes.Clasificacion_Ingredientes() { Clave = m.Subgrupos_Ingredientes_Clasificacion.GetValueOrDefault(), Descripcion = m.Subgrupos_Ingredientes_Clasificacion_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Subgrupos_IngredientesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes>("sp_GetSubgrupos_Ingredientes", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Folio";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSubgrupos_Ingredientes>("sp_DelSubgrupos_Ingredientes", padreKey).FirstOrDefault();
                if (padreResult != null)
                    rta = padreResult.Result.ToString() == "1";
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Insert(Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.String;
                padreNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var padreClasificacion = _dataProvider.GetParameter();
                padreClasificacion.ParameterName = "Clasificacion";
                padreClasificacion.DbType = DbType.Int32;
                padreClasificacion.Value = (object)entity.Clasificacion ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSubgrupos_Ingredientes>("sp_InsSubgrupos_Ingredientes" , padreNombre
, padreClasificacion
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);

            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Update(Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdClasificacion = _dataProvider.GetParameter();
                paramUpdClasificacion.ParameterName = "Clasificacion";
                paramUpdClasificacion.DbType = DbType.Int32;
                paramUpdClasificacion.Value = (object)entity.Clasificacion ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSubgrupos_Ingredientes>("sp_UpdSubgrupos_Ingredientes" , paramUpdFolio , paramUpdNombre , paramUpdClasificacion ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }
		public int Update_Datos_Generales(Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Subgrupos_Ingredientes.Subgrupos_Ingredientes Subgrupos_IngredientesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
		var paramUpdClasificacion = _dataProvider.GetParameter();
                paramUpdClasificacion.ParameterName = "Clasificacion";
                paramUpdClasificacion.DbType = DbType.Int32;
                paramUpdClasificacion.Value = (object)entity.Clasificacion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSubgrupos_Ingredientes>("sp_UpdSubgrupos_Ingredientes" , paramUpdFolio , paramUpdNombre , paramUpdClasificacion ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }


        #endregion
    }
}

