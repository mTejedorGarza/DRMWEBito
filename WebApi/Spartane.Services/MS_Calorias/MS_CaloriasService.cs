using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_Calorias;
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
        private readonly IRepository<Spartane.Core.Classes.MS_Calorias.MS_Calorias> _MS_CaloriasRepository;
        #endregion

        #region Ctor
        public MS_CaloriasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_Calorias.MS_Calorias> MS_CaloriasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_CaloriasRepository = MS_CaloriasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_CaloriasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_Calorias.MS_Calorias> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Calorias.MS_Calorias>("sp_SelAllMS_Calorias");
        }

        public IList<Core.Classes.MS_Calorias.MS_Calorias> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_Calorias_Complete>("sp_SelAllComplete_MS_Calorias");
            return data.Select(m => new Core.Classes.MS_Calorias.MS_Calorias
            {
                Folio = m.Folio
                ,Folio_Platillo = m.Folio_Platillo
                ,Calorias_Calorias = new Core.Classes.Calorias.Calorias() { Clave = m.Calorias.GetValueOrDefault(), Cantidad = m.Calorias_Cantidad }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_Calorias>("sp_ListSelCount_MS_Calorias", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_Calorias.MS_Calorias> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Calorias>("sp_ListSelAll_MS_Calorias", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_Calorias.MS_Calorias
                {
                    Folio = m.MS_Calorias_Folio,
                    Folio_Platillo = m.MS_Calorias_Folio_Platillo,
                    Calorias = m.MS_Calorias_Calorias,

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

        public IList<Spartane.Core.Classes.MS_Calorias.MS_Calorias> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_CaloriasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_Calorias.MS_Calorias> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_CaloriasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Calorias.MS_CaloriasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Calorias>("sp_ListSelAll_MS_Calorias", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_CaloriasPagingModel result = null;

            if (data != null)
            {
                result = new MS_CaloriasPagingModel
                {
                    MS_Caloriass =
                        data.Select(m => new Spartane.Core.Classes.MS_Calorias.MS_Calorias
                {
                    Folio = m.MS_Calorias_Folio
                    ,Folio_Platillo = m.MS_Calorias_Folio_Platillo
                    ,Calorias = m.MS_Calorias_Calorias
                    ,Calorias_Calorias = new Core.Classes.Calorias.Calorias() { Clave = m.MS_Calorias_Calorias.GetValueOrDefault(), Cantidad = m.MS_Calorias_Calorias_Cantidad }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_Calorias.MS_Calorias> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_CaloriasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Calorias.MS_Calorias GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Calorias.MS_Calorias>("sp_GetMS_Calorias", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_Calorias>("sp_DelMS_Calorias", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_Calorias.MS_Calorias entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Platillo = _dataProvider.GetParameter();
                padreFolio_Platillo.ParameterName = "Folio_Platillo";
                padreFolio_Platillo.DbType = DbType.Int32;
                padreFolio_Platillo.Value = (object)entity.Folio_Platillo ?? DBNull.Value;
                var padreCalorias = _dataProvider.GetParameter();
                padreCalorias.ParameterName = "Calorias";
                padreCalorias.DbType = DbType.Int32;
                padreCalorias.Value = (object)entity.Calorias ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_Calorias>("sp_InsMS_Calorias" , padreFolio_Platillo
, padreCalorias
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

        public int Update(Spartane.Core.Classes.MS_Calorias.MS_Calorias entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Platillo = _dataProvider.GetParameter();
                paramUpdFolio_Platillo.ParameterName = "Folio_Platillo";
                paramUpdFolio_Platillo.DbType = DbType.Int32;
                paramUpdFolio_Platillo.Value = (object)entity.Folio_Platillo ?? DBNull.Value;
                var paramUpdCalorias = _dataProvider.GetParameter();
                paramUpdCalorias.ParameterName = "Calorias";
                paramUpdCalorias.DbType = DbType.Int32;
                paramUpdCalorias.Value = (object)entity.Calorias ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Calorias>("sp_UpdMS_Calorias" , paramUpdFolio , paramUpdFolio_Platillo , paramUpdCalorias ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_Calorias.MS_Calorias entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_Calorias.MS_Calorias MS_CaloriasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Platillo = _dataProvider.GetParameter();
                paramUpdFolio_Platillo.ParameterName = "Folio_Platillo";
                paramUpdFolio_Platillo.DbType = DbType.Int32;
                paramUpdFolio_Platillo.Value = (object)entity.Folio_Platillo ?? DBNull.Value;
		var paramUpdCalorias = _dataProvider.GetParameter();
                paramUpdCalorias.ParameterName = "Calorias";
                paramUpdCalorias.DbType = DbType.Int32;
                paramUpdCalorias.Value = (object)entity.Calorias ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Calorias>("sp_UpdMS_Calorias" , paramUpdFolio , paramUpdFolio_Platillo , paramUpdCalorias ).FirstOrDefault();

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

