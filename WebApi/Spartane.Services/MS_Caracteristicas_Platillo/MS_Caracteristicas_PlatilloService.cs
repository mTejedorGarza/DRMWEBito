using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_Caracteristicas_Platillo;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Caracteristicas_Platillo
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Caracteristicas_PlatilloService : IMS_Caracteristicas_PlatilloService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> _MS_Caracteristicas_PlatilloRepository;
        #endregion

        #region Ctor
        public MS_Caracteristicas_PlatilloService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> MS_Caracteristicas_PlatilloRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Caracteristicas_PlatilloRepository = MS_Caracteristicas_PlatilloRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_Caracteristicas_PlatilloRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo>("sp_SelAllMS_Caracteristicas_Platillo");
        }

        public IList<Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_Caracteristicas_Platillo_Complete>("sp_SelAllComplete_MS_Caracteristicas_Platillo");
            return data.Select(m => new Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo
            {
                Folio = m.Folio
                ,Folio_Platillos = m.Folio_Platillos
                ,Caracteristicas_Caracteristicas_platillo = new Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo() { Folio = m.Caracteristicas.GetValueOrDefault(), Caracteristicas = m.Caracteristicas_Caracteristicas }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_Caracteristicas_Platillo>("sp_ListSelCount_MS_Caracteristicas_Platillo", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Caracteristicas_Platillo>("sp_ListSelAll_MS_Caracteristicas_Platillo", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo
                {
                    Folio = m.MS_Caracteristicas_Platillo_Folio,
                    Folio_Platillos = m.MS_Caracteristicas_Platillo_Folio_Platillos,
                    Caracteristicas = m.MS_Caracteristicas_Platillo_Caracteristicas,

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

        public IList<Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Caracteristicas_PlatilloRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Caracteristicas_PlatilloRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_PlatilloPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Caracteristicas_Platillo>("sp_ListSelAll_MS_Caracteristicas_Platillo", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_Caracteristicas_PlatilloPagingModel result = null;

            if (data != null)
            {
                result = new MS_Caracteristicas_PlatilloPagingModel
                {
                    MS_Caracteristicas_Platillos =
                        data.Select(m => new Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo
                {
                    Folio = m.MS_Caracteristicas_Platillo_Folio
                    ,Folio_Platillos = m.MS_Caracteristicas_Platillo_Folio_Platillos
                    ,Caracteristicas = m.MS_Caracteristicas_Platillo_Caracteristicas
                    ,Caracteristicas_Caracteristicas_platillo = new Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo() { Folio = m.MS_Caracteristicas_Platillo_Caracteristicas.GetValueOrDefault(), Caracteristicas = m.MS_Caracteristicas_Platillo_Caracteristicas_Caracteristicas }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Caracteristicas_PlatilloRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo>("sp_GetMS_Caracteristicas_Platillo", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_Caracteristicas_Platillo>("sp_DelMS_Caracteristicas_Platillo", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo entity)
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
                var padreCaracteristicas = _dataProvider.GetParameter();
                padreCaracteristicas.ParameterName = "Caracteristicas";
                padreCaracteristicas.DbType = DbType.Int32;
                padreCaracteristicas.Value = (object)entity.Caracteristicas ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_Caracteristicas_Platillo>("sp_InsMS_Caracteristicas_Platillo" , padreFolio_Platillos
, padreCaracteristicas
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

        public int Update(Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo entity)
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
                var paramUpdCaracteristicas = _dataProvider.GetParameter();
                paramUpdCaracteristicas.ParameterName = "Caracteristicas";
                paramUpdCaracteristicas.DbType = DbType.Int32;
                paramUpdCaracteristicas.Value = (object)entity.Caracteristicas ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Caracteristicas_Platillo>("sp_UpdMS_Caracteristicas_Platillo" , paramUpdFolio , paramUpdFolio_Platillos , paramUpdCaracteristicas ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_Caracteristicas_Platillo.MS_Caracteristicas_Platillo MS_Caracteristicas_PlatilloDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Platillos = _dataProvider.GetParameter();
                paramUpdFolio_Platillos.ParameterName = "Folio_Platillos";
                paramUpdFolio_Platillos.DbType = DbType.Int32;
                paramUpdFolio_Platillos.Value = (object)entity.Folio_Platillos ?? DBNull.Value;
		var paramUpdCaracteristicas = _dataProvider.GetParameter();
                paramUpdCaracteristicas.ParameterName = "Caracteristicas";
                paramUpdCaracteristicas.DbType = DbType.Int32;
                paramUpdCaracteristicas.Value = (object)entity.Caracteristicas ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Caracteristicas_Platillo>("sp_UpdMS_Caracteristicas_Platillo" , paramUpdFolio , paramUpdFolio_Platillos , paramUpdCaracteristicas ).FirstOrDefault();

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

