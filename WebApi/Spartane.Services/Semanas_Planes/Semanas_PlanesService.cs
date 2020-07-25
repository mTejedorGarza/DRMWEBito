using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Semanas_Planes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Semanas_Planes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Semanas_PlanesService : ISemanas_PlanesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Semanas_Planes.Semanas_Planes> _Semanas_PlanesRepository;
        #endregion

        #region Ctor
        public Semanas_PlanesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Semanas_Planes.Semanas_Planes> Semanas_PlanesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Semanas_PlanesRepository = Semanas_PlanesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Semanas_PlanesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Semanas_Planes.Semanas_Planes> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Semanas_Planes.Semanas_Planes>("sp_SelAllSemanas_Planes");
        }

        public IList<Core.Classes.Semanas_Planes.Semanas_Planes> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSemanas_Planes_Complete>("sp_SelAllComplete_Semanas_Planes");
            return data.Select(m => new Core.Classes.Semanas_Planes.Semanas_Planes
            {
                Folio = m.Folio
                ,Semana = m.Semana
                ,Semanas_del_mes = m.Semanas_del_mes


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Semanas_Planes>("sp_ListSelCount_Semanas_Planes", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Semanas_Planes.Semanas_Planes> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSemanas_Planes>("sp_ListSelAll_Semanas_Planes", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Semanas_Planes.Semanas_Planes
                {
                    Folio = m.Semanas_Planes_Folio,
                    Semana = m.Semanas_Planes_Semana,
                    Semanas_del_mes = m.Semanas_Planes_Semanas_del_mes,

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

        public IList<Spartane.Core.Classes.Semanas_Planes.Semanas_Planes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Semanas_PlanesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Semanas_Planes.Semanas_Planes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Semanas_PlanesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Semanas_Planes.Semanas_PlanesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSemanas_Planes>("sp_ListSelAll_Semanas_Planes", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Semanas_PlanesPagingModel result = null;

            if (data != null)
            {
                result = new Semanas_PlanesPagingModel
                {
                    Semanas_Planess =
                        data.Select(m => new Spartane.Core.Classes.Semanas_Planes.Semanas_Planes
                {
                    Folio = m.Semanas_Planes_Folio
                    ,Semana = m.Semanas_Planes_Semana
                    ,Semanas_del_mes = m.Semanas_Planes_Semanas_del_mes

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Semanas_Planes.Semanas_Planes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Semanas_PlanesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Semanas_Planes.Semanas_Planes GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Semanas_Planes.Semanas_Planes>("sp_GetSemanas_Planes", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSemanas_Planes>("sp_DelSemanas_Planes", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Semanas_Planes.Semanas_Planes entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreSemana = _dataProvider.GetParameter();
                padreSemana.ParameterName = "Semana";
                padreSemana.DbType = DbType.String;
                padreSemana.Value = (object)entity.Semana ?? DBNull.Value;
                var padreSemanas_del_mes = _dataProvider.GetParameter();
                padreSemanas_del_mes.ParameterName = "Semanas_del_mes";
                padreSemanas_del_mes.DbType = DbType.Int32;
                padreSemanas_del_mes.Value = (object)entity.Semanas_del_mes ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSemanas_Planes>("sp_InsSemanas_Planes" , padreSemana
, padreSemanas_del_mes
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

        public int Update(Spartane.Core.Classes.Semanas_Planes.Semanas_Planes entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdSemana = _dataProvider.GetParameter();
                paramUpdSemana.ParameterName = "Semana";
                paramUpdSemana.DbType = DbType.String;
                paramUpdSemana.Value = (object)entity.Semana ?? DBNull.Value;
                var paramUpdSemanas_del_mes = _dataProvider.GetParameter();
                paramUpdSemanas_del_mes.ParameterName = "Semanas_del_mes";
                paramUpdSemanas_del_mes.DbType = DbType.Int32;
                paramUpdSemanas_del_mes.Value = (object)entity.Semanas_del_mes ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSemanas_Planes>("sp_UpdSemanas_Planes" , paramUpdFolio , paramUpdSemana , paramUpdSemanas_del_mes ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Semanas_Planes.Semanas_Planes entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Semanas_Planes.Semanas_Planes Semanas_PlanesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdSemana = _dataProvider.GetParameter();
                paramUpdSemana.ParameterName = "Semana";
                paramUpdSemana.DbType = DbType.String;
                paramUpdSemana.Value = (object)entity.Semana ?? DBNull.Value;
                var paramUpdSemanas_del_mes = _dataProvider.GetParameter();
                paramUpdSemanas_del_mes.ParameterName = "Semanas_del_mes";
                paramUpdSemanas_del_mes.DbType = DbType.Int32;
                paramUpdSemanas_del_mes.Value = (object)entity.Semanas_del_mes ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSemanas_Planes>("sp_UpdSemanas_Planes" , paramUpdFolio , paramUpdSemana , paramUpdSemanas_del_mes ).FirstOrDefault();

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

