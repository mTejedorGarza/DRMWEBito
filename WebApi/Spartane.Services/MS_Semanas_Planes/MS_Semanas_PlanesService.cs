using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_Semanas_Planes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Semanas_Planes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Semanas_PlanesService : IMS_Semanas_PlanesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes> _MS_Semanas_PlanesRepository;
        #endregion

        #region Ctor
        public MS_Semanas_PlanesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes> MS_Semanas_PlanesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Semanas_PlanesRepository = MS_Semanas_PlanesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_Semanas_PlanesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes>("sp_SelAllMS_Semanas_Planes");
        }

        public IList<Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_Semanas_Planes_Complete>("sp_SelAllComplete_MS_Semanas_Planes");
            return data.Select(m => new Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes
            {
                Folio = m.Folio
                ,Folio_Planes_de_Suscripcion = m.Folio_Planes_de_Suscripcion
                ,Semanas_Semanas_Planes = new Core.Classes.Semanas_Planes.Semanas_Planes() { Folio = m.Semanas.GetValueOrDefault(), Semana = m.Semanas_Semana }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_Semanas_Planes>("sp_ListSelCount_MS_Semanas_Planes", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Semanas_Planes>("sp_ListSelAll_MS_Semanas_Planes", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes
                {
                    Folio = m.MS_Semanas_Planes_Folio,
                    Folio_Planes_de_Suscripcion = m.MS_Semanas_Planes_Folio_Planes_de_Suscripcion,
                    Semanas = m.MS_Semanas_Planes_Semanas,

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

        public IList<Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Semanas_PlanesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Semanas_PlanesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_PlanesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Semanas_Planes>("sp_ListSelAll_MS_Semanas_Planes", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_Semanas_PlanesPagingModel result = null;

            if (data != null)
            {
                result = new MS_Semanas_PlanesPagingModel
                {
                    MS_Semanas_Planess =
                        data.Select(m => new Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes
                {
                    Folio = m.MS_Semanas_Planes_Folio
                    ,Folio_Planes_de_Suscripcion = m.MS_Semanas_Planes_Folio_Planes_de_Suscripcion
                    ,Semanas = m.MS_Semanas_Planes_Semanas
                    ,Semanas_Semanas_Planes = new Core.Classes.Semanas_Planes.Semanas_Planes() { Folio = m.MS_Semanas_Planes_Semanas.GetValueOrDefault(), Semana = m.MS_Semanas_Planes_Semanas_Semana }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Semanas_PlanesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes>("sp_GetMS_Semanas_Planes", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_Semanas_Planes>("sp_DelMS_Semanas_Planes", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Planes_de_Suscripcion = _dataProvider.GetParameter();
                padreFolio_Planes_de_Suscripcion.ParameterName = "Folio_Planes_de_Suscripcion";
                padreFolio_Planes_de_Suscripcion.DbType = DbType.Int32;
                padreFolio_Planes_de_Suscripcion.Value = (object)entity.Folio_Planes_de_Suscripcion ?? DBNull.Value;
                var padreSemanas = _dataProvider.GetParameter();
                padreSemanas.ParameterName = "Semanas";
                padreSemanas.DbType = DbType.Int32;
                padreSemanas.Value = (object)entity.Semanas ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_Semanas_Planes>("sp_InsMS_Semanas_Planes" , padreFolio_Planes_de_Suscripcion
, padreSemanas
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

        public int Update(Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Planes_de_Suscripcion = _dataProvider.GetParameter();
                paramUpdFolio_Planes_de_Suscripcion.ParameterName = "Folio_Planes_de_Suscripcion";
                paramUpdFolio_Planes_de_Suscripcion.DbType = DbType.Int32;
                paramUpdFolio_Planes_de_Suscripcion.Value = (object)entity.Folio_Planes_de_Suscripcion ?? DBNull.Value;
                var paramUpdSemanas = _dataProvider.GetParameter();
                paramUpdSemanas.ParameterName = "Semanas";
                paramUpdSemanas.DbType = DbType.Int32;
                paramUpdSemanas.Value = (object)entity.Semanas ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Semanas_Planes>("sp_UpdMS_Semanas_Planes" , paramUpdFolio , paramUpdFolio_Planes_de_Suscripcion , paramUpdSemanas ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_Semanas_Planes.MS_Semanas_Planes MS_Semanas_PlanesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Planes_de_Suscripcion = _dataProvider.GetParameter();
                paramUpdFolio_Planes_de_Suscripcion.ParameterName = "Folio_Planes_de_Suscripcion";
                paramUpdFolio_Planes_de_Suscripcion.DbType = DbType.Int32;
                paramUpdFolio_Planes_de_Suscripcion.Value = (object)entity.Folio_Planes_de_Suscripcion ?? DBNull.Value;
		var paramUpdSemanas = _dataProvider.GetParameter();
                paramUpdSemanas.ParameterName = "Semanas";
                paramUpdSemanas.DbType = DbType.Int32;
                paramUpdSemanas.Value = (object)entity.Semanas ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Semanas_Planes>("sp_UpdMS_Semanas_Planes" , paramUpdFolio , paramUpdFolio_Planes_de_Suscripcion , paramUpdSemanas ).FirstOrDefault();

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

