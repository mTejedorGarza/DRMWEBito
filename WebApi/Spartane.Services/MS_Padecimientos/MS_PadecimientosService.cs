using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_Padecimientos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Padecimientos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_PadecimientosService : IMS_PadecimientosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos> _MS_PadecimientosRepository;
        #endregion

        #region Ctor
        public MS_PadecimientosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos> MS_PadecimientosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_PadecimientosRepository = MS_PadecimientosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_PadecimientosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos>("sp_SelAllMS_Padecimientos");
        }

        public IList<Core.Classes.MS_Padecimientos.MS_Padecimientos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_Padecimientos_Complete>("sp_SelAllComplete_MS_Padecimientos");
            return data.Select(m => new Core.Classes.MS_Padecimientos.MS_Padecimientos
            {
                Folio = m.Folio
                ,Folio_Platillos = m.Folio_Platillos
                ,Categoria_Categorias_de_platillos = new Core.Classes.Categorias_de_platillos.Categorias_de_platillos() { Clave = m.Categoria.GetValueOrDefault(), Categoria = m.Categoria_Categoria }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_Padecimientos>("sp_ListSelCount_MS_Padecimientos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Padecimientos>("sp_ListSelAll_MS_Padecimientos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos
                {
                    Folio = m.MS_Padecimientos_Folio,
                    Folio_Platillos = m.MS_Padecimientos_Folio_Platillos,
                    Categoria = m.MS_Padecimientos_Categoria,

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

        public IList<Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_PadecimientosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_PadecimientosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Padecimientos.MS_PadecimientosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Padecimientos>("sp_ListSelAll_MS_Padecimientos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_PadecimientosPagingModel result = null;

            if (data != null)
            {
                result = new MS_PadecimientosPagingModel
                {
                    MS_Padecimientoss =
                        data.Select(m => new Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos
                {
                    Folio = m.MS_Padecimientos_Folio
                    ,Folio_Platillos = m.MS_Padecimientos_Folio_Platillos
                    ,Categoria = m.MS_Padecimientos_Categoria
                    ,Categoria_Categorias_de_platillos = new Core.Classes.Categorias_de_platillos.Categorias_de_platillos() { Clave = m.MS_Padecimientos_Categoria.GetValueOrDefault(), Categoria = m.MS_Padecimientos_Categoria_Categoria }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_PadecimientosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos>("sp_GetMS_Padecimientos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_Padecimientos>("sp_DelMS_Padecimientos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Platillos = _dataProvider.GetParameter();
                padreFolio_Platillos.ParameterName = "Folio_Platillos";
                padreFolio_Platillos.DbType = DbType.Int32;
                padreFolio_Platillos.Value = (object)entity.Folio_Platillos ?? DBNull.Value;
                var padreCategoria = _dataProvider.GetParameter();
                padreCategoria.ParameterName = "Categoria";
                padreCategoria.DbType = DbType.Int32;
                padreCategoria.Value = (object)entity.Categoria ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_Padecimientos>("sp_InsMS_Padecimientos" , padreFolio_Platillos
, padreCategoria
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

        public int Update(Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Platillos = _dataProvider.GetParameter();
                paramUpdFolio_Platillos.ParameterName = "Folio_Platillos";
                paramUpdFolio_Platillos.DbType = DbType.Int32;
                paramUpdFolio_Platillos.Value = (object)entity.Folio_Platillos ?? DBNull.Value;
                var paramUpdCategoria = _dataProvider.GetParameter();
                paramUpdCategoria.ParameterName = "Categoria";
                paramUpdCategoria.DbType = DbType.Int32;
                paramUpdCategoria.Value = (object)entity.Categoria ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Padecimientos>("sp_UpdMS_Padecimientos" , paramUpdFolio , paramUpdFolio_Platillos , paramUpdCategoria ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_Padecimientos.MS_Padecimientos MS_PadecimientosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Platillos = _dataProvider.GetParameter();
                paramUpdFolio_Platillos.ParameterName = "Folio_Platillos";
                paramUpdFolio_Platillos.DbType = DbType.Int32;
                paramUpdFolio_Platillos.Value = (object)entity.Folio_Platillos ?? DBNull.Value;
		var paramUpdCategoria = _dataProvider.GetParameter();
                paramUpdCategoria.ParameterName = "Categoria";
                paramUpdCategoria.DbType = DbType.Int32;
                paramUpdCategoria.Value = (object)entity.Categoria ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Padecimientos>("sp_UpdMS_Padecimientos" , paramUpdFolio , paramUpdFolio_Platillos , paramUpdCategoria ).FirstOrDefault();

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

