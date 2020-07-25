using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_Uso_del_Ejercicio;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Uso_del_Ejercicio
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Uso_del_EjercicioService : IMS_Uso_del_EjercicioService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> _MS_Uso_del_EjercicioRepository;
        #endregion

        #region Ctor
        public MS_Uso_del_EjercicioService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> MS_Uso_del_EjercicioRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Uso_del_EjercicioRepository = MS_Uso_del_EjercicioRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_Uso_del_EjercicioRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio>("sp_SelAllMS_Uso_del_Ejercicio");
        }

        public IList<Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_Uso_del_Ejercicio_Complete>("sp_SelAllComplete_MS_Uso_del_Ejercicio");
            return data.Select(m => new Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio
            {
                Folio = m.Folio
                ,Folio_Ejercicios = m.Folio_Ejercicios
                ,Uso_del_Ejercicio_Tipo_de_Ejercicio_Rutina = new Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina() { Folio = m.Uso_del_Ejercicio.GetValueOrDefault(), Descripcion = m.Uso_del_Ejercicio_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_Uso_del_Ejercicio>("sp_ListSelCount_MS_Uso_del_Ejercicio", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Uso_del_Ejercicio>("sp_ListSelAll_MS_Uso_del_Ejercicio", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio
                {
                    Folio = m.MS_Uso_del_Ejercicio_Folio,
                    Folio_Ejercicios = m.MS_Uso_del_Ejercicio_Folio_Ejercicios,
                    Uso_del_Ejercicio = m.MS_Uso_del_Ejercicio_Uso_del_Ejercicio,

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

        public IList<Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Uso_del_EjercicioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Uso_del_EjercicioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_EjercicioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Uso_del_Ejercicio>("sp_ListSelAll_MS_Uso_del_Ejercicio", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_Uso_del_EjercicioPagingModel result = null;

            if (data != null)
            {
                result = new MS_Uso_del_EjercicioPagingModel
                {
                    MS_Uso_del_Ejercicios =
                        data.Select(m => new Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio
                {
                    Folio = m.MS_Uso_del_Ejercicio_Folio
                    ,Folio_Ejercicios = m.MS_Uso_del_Ejercicio_Folio_Ejercicios
                    ,Uso_del_Ejercicio = m.MS_Uso_del_Ejercicio_Uso_del_Ejercicio
                    ,Uso_del_Ejercicio_Tipo_de_Ejercicio_Rutina = new Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina() { Folio = m.MS_Uso_del_Ejercicio_Uso_del_Ejercicio.GetValueOrDefault(), Descripcion = m.MS_Uso_del_Ejercicio_Uso_del_Ejercicio_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Uso_del_EjercicioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio>("sp_GetMS_Uso_del_Ejercicio", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_Uso_del_Ejercicio>("sp_DelMS_Uso_del_Ejercicio", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Ejercicios = _dataProvider.GetParameter();
                padreFolio_Ejercicios.ParameterName = "Folio_Ejercicios";
                padreFolio_Ejercicios.DbType = DbType.Int32;
                padreFolio_Ejercicios.Value = (object)entity.Folio_Ejercicios ?? DBNull.Value;
                var padreUso_del_Ejercicio = _dataProvider.GetParameter();
                padreUso_del_Ejercicio.ParameterName = "Uso_del_Ejercicio";
                padreUso_del_Ejercicio.DbType = DbType.Int32;
                padreUso_del_Ejercicio.Value = (object)entity.Uso_del_Ejercicio ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_Uso_del_Ejercicio>("sp_InsMS_Uso_del_Ejercicio" , padreFolio_Ejercicios
, padreUso_del_Ejercicio
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

        public int Update(Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Ejercicios = _dataProvider.GetParameter();
                paramUpdFolio_Ejercicios.ParameterName = "Folio_Ejercicios";
                paramUpdFolio_Ejercicios.DbType = DbType.Int32;
                paramUpdFolio_Ejercicios.Value = (object)entity.Folio_Ejercicios ?? DBNull.Value;
                var paramUpdUso_del_Ejercicio = _dataProvider.GetParameter();
                paramUpdUso_del_Ejercicio.ParameterName = "Uso_del_Ejercicio";
                paramUpdUso_del_Ejercicio.DbType = DbType.Int32;
                paramUpdUso_del_Ejercicio.Value = (object)entity.Uso_del_Ejercicio ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Uso_del_Ejercicio>("sp_UpdMS_Uso_del_Ejercicio" , paramUpdFolio , paramUpdFolio_Ejercicios , paramUpdUso_del_Ejercicio ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio MS_Uso_del_EjercicioDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Ejercicios = _dataProvider.GetParameter();
                paramUpdFolio_Ejercicios.ParameterName = "Folio_Ejercicios";
                paramUpdFolio_Ejercicios.DbType = DbType.Int32;
                paramUpdFolio_Ejercicios.Value = (object)entity.Folio_Ejercicios ?? DBNull.Value;
		var paramUpdUso_del_Ejercicio = _dataProvider.GetParameter();
                paramUpdUso_del_Ejercicio.ParameterName = "Uso_del_Ejercicio";
                paramUpdUso_del_Ejercicio.DbType = DbType.Int32;
                paramUpdUso_del_Ejercicio.Value = (object)entity.Uso_del_Ejercicio ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Uso_del_Ejercicio>("sp_UpdMS_Uso_del_Ejercicio" , paramUpdFolio , paramUpdFolio_Ejercicios , paramUpdUso_del_Ejercicio ).FirstOrDefault();

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

