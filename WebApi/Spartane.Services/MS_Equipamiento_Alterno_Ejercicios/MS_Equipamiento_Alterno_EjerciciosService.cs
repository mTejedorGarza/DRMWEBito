using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Equipamiento_Alterno_Ejercicios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Equipamiento_Alterno_EjerciciosService : IMS_Equipamiento_Alterno_EjerciciosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios> _MS_Equipamiento_Alterno_EjerciciosRepository;
        #endregion

        #region Ctor
        public MS_Equipamiento_Alterno_EjerciciosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios> MS_Equipamiento_Alterno_EjerciciosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Equipamiento_Alterno_EjerciciosRepository = MS_Equipamiento_Alterno_EjerciciosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_Equipamiento_Alterno_EjerciciosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>("sp_SelAllMS_Equipamiento_Alterno_Ejercicios");
        }

        public IList<Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_Equipamiento_Alterno_Ejercicios_Complete>("sp_SelAllComplete_MS_Equipamiento_Alterno_Ejercicios");
            return data.Select(m => new Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios
            {
                Folio = m.Folio
                ,Folio_Ejercicios = m.Folio_Ejercicios
                ,Equipamiento_Alterno_Equipamiento_Alterno_para_Ejercicios = new Core.Classes.Equipamiento_Alterno_para_Ejercicios.Equipamiento_Alterno_para_Ejercicios() { Folio = m.Equipamiento_Alterno.GetValueOrDefault(), Descripcion = m.Equipamiento_Alterno_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_Equipamiento_Alterno_Ejercicios>("sp_ListSelCount_MS_Equipamiento_Alterno_Ejercicios", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Equipamiento_Alterno_Ejercicios>("sp_ListSelAll_MS_Equipamiento_Alterno_Ejercicios", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios
                {
                    Folio = m.MS_Equipamiento_Alterno_Ejercicios_Folio,
                    Folio_Ejercicios = m.MS_Equipamiento_Alterno_Ejercicios_Folio_Ejercicios,
                    Equipamiento_Alterno = m.MS_Equipamiento_Alterno_Ejercicios_Equipamiento_Alterno,

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

        public IList<Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Equipamiento_Alterno_EjerciciosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Equipamiento_Alterno_EjerciciosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_EjerciciosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Equipamiento_Alterno_Ejercicios>("sp_ListSelAll_MS_Equipamiento_Alterno_Ejercicios", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_Equipamiento_Alterno_EjerciciosPagingModel result = null;

            if (data != null)
            {
                result = new MS_Equipamiento_Alterno_EjerciciosPagingModel
                {
                    MS_Equipamiento_Alterno_Ejercicioss =
                        data.Select(m => new Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios
                {
                    Folio = m.MS_Equipamiento_Alterno_Ejercicios_Folio
                    ,Folio_Ejercicios = m.MS_Equipamiento_Alterno_Ejercicios_Folio_Ejercicios
                    ,Equipamiento_Alterno = m.MS_Equipamiento_Alterno_Ejercicios_Equipamiento_Alterno
                    ,Equipamiento_Alterno_Equipamiento_Alterno_para_Ejercicios = new Core.Classes.Equipamiento_Alterno_para_Ejercicios.Equipamiento_Alterno_para_Ejercicios() { Folio = m.MS_Equipamiento_Alterno_Ejercicios_Equipamiento_Alterno.GetValueOrDefault(), Descripcion = m.MS_Equipamiento_Alterno_Ejercicios_Equipamiento_Alterno_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Equipamiento_Alterno_EjerciciosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios>("sp_GetMS_Equipamiento_Alterno_Ejercicios", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_Equipamiento_Alterno_Ejercicios>("sp_DelMS_Equipamiento_Alterno_Ejercicios", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios entity)
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
                var padreEquipamiento_Alterno = _dataProvider.GetParameter();
                padreEquipamiento_Alterno.ParameterName = "Equipamiento_Alterno";
                padreEquipamiento_Alterno.DbType = DbType.Int32;
                padreEquipamiento_Alterno.Value = (object)entity.Equipamiento_Alterno ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_Equipamiento_Alterno_Ejercicios>("sp_InsMS_Equipamiento_Alterno_Ejercicios" , padreFolio_Ejercicios
, padreEquipamiento_Alterno
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

        public int Update(Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios entity)
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
                var paramUpdEquipamiento_Alterno = _dataProvider.GetParameter();
                paramUpdEquipamiento_Alterno.ParameterName = "Equipamiento_Alterno";
                paramUpdEquipamiento_Alterno.DbType = DbType.Int32;
                paramUpdEquipamiento_Alterno.Value = (object)entity.Equipamiento_Alterno ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Equipamiento_Alterno_Ejercicios>("sp_UpdMS_Equipamiento_Alterno_Ejercicios" , paramUpdFolio , paramUpdFolio_Ejercicios , paramUpdEquipamiento_Alterno ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_Equipamiento_Alterno_Ejercicios.MS_Equipamiento_Alterno_Ejercicios MS_Equipamiento_Alterno_EjerciciosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Ejercicios = _dataProvider.GetParameter();
                paramUpdFolio_Ejercicios.ParameterName = "Folio_Ejercicios";
                paramUpdFolio_Ejercicios.DbType = DbType.Int32;
                paramUpdFolio_Ejercicios.Value = (object)entity.Folio_Ejercicios ?? DBNull.Value;
		var paramUpdEquipamiento_Alterno = _dataProvider.GetParameter();
                paramUpdEquipamiento_Alterno.ParameterName = "Equipamiento_Alterno";
                paramUpdEquipamiento_Alterno.DbType = DbType.Int32;
                paramUpdEquipamiento_Alterno.Value = (object)entity.Equipamiento_Alterno ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Equipamiento_Alterno_Ejercicios>("sp_UpdMS_Equipamiento_Alterno_Ejercicios" , paramUpdFolio , paramUpdFolio_Ejercicios , paramUpdEquipamiento_Alterno ).FirstOrDefault();

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

