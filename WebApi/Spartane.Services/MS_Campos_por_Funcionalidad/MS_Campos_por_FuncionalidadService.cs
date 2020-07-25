using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_Campos_por_Funcionalidad;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Campos_por_Funcionalidad
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Campos_por_FuncionalidadService : IMS_Campos_por_FuncionalidadService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> _MS_Campos_por_FuncionalidadRepository;
        #endregion

        #region Ctor
        public MS_Campos_por_FuncionalidadService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> MS_Campos_por_FuncionalidadRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Campos_por_FuncionalidadRepository = MS_Campos_por_FuncionalidadRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_Campos_por_FuncionalidadRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>("sp_SelAllMS_Campos_por_Funcionalidad");
        }

        public IList<Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_Campos_por_Funcionalidad_Complete>("sp_SelAllComplete_MS_Campos_por_Funcionalidad");
            return data.Select(m => new Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad
            {
                Folio = m.Folio
                ,Folio_Funcionalidades_Notificacion = m.Folio_Funcionalidades_Notificacion
                ,Campo_Nombre_del_campo_en_MS = new Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS() { Clave = m.Campo.GetValueOrDefault(), Descripcion = m.Campo_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_Campos_por_Funcionalidad>("sp_ListSelCount_MS_Campos_por_Funcionalidad", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Campos_por_Funcionalidad>("sp_ListSelAll_MS_Campos_por_Funcionalidad", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad
                {
                    Folio = m.MS_Campos_por_Funcionalidad_Folio,
                    Folio_Funcionalidades_Notificacion = m.MS_Campos_por_Funcionalidad_Folio_Funcionalidades_Notificacion,
                    Campo = m.MS_Campos_por_Funcionalidad_Campo,

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

        public IList<Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Campos_por_FuncionalidadRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Campos_por_FuncionalidadRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_FuncionalidadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Campos_por_Funcionalidad>("sp_ListSelAll_MS_Campos_por_Funcionalidad", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_Campos_por_FuncionalidadPagingModel result = null;

            if (data != null)
            {
                result = new MS_Campos_por_FuncionalidadPagingModel
                {
                    MS_Campos_por_Funcionalidads =
                        data.Select(m => new Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad
                {
                    Folio = m.MS_Campos_por_Funcionalidad_Folio
                    ,Folio_Funcionalidades_Notificacion = m.MS_Campos_por_Funcionalidad_Folio_Funcionalidades_Notificacion
                    ,Campo = m.MS_Campos_por_Funcionalidad_Campo
                    ,Campo_Nombre_del_campo_en_MS = new Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS() { Clave = m.MS_Campos_por_Funcionalidad_Campo.GetValueOrDefault(), Descripcion = m.MS_Campos_por_Funcionalidad_Campo_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Campos_por_FuncionalidadRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad>("sp_GetMS_Campos_por_Funcionalidad", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_Campos_por_Funcionalidad>("sp_DelMS_Campos_por_Funcionalidad", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Funcionalidades_Notificacion = _dataProvider.GetParameter();
                padreFolio_Funcionalidades_Notificacion.ParameterName = "Folio_Funcionalidades_Notificacion";
                padreFolio_Funcionalidades_Notificacion.DbType = DbType.Int32;
                padreFolio_Funcionalidades_Notificacion.Value = (object)entity.Folio_Funcionalidades_Notificacion ?? DBNull.Value;
                var padreCampo = _dataProvider.GetParameter();
                padreCampo.ParameterName = "Campo";
                padreCampo.DbType = DbType.Int32;
                padreCampo.Value = (object)entity.Campo ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_Campos_por_Funcionalidad>("sp_InsMS_Campos_por_Funcionalidad" , padreFolio_Funcionalidades_Notificacion
, padreCampo
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

        public int Update(Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Funcionalidades_Notificacion = _dataProvider.GetParameter();
                paramUpdFolio_Funcionalidades_Notificacion.ParameterName = "Folio_Funcionalidades_Notificacion";
                paramUpdFolio_Funcionalidades_Notificacion.DbType = DbType.Int32;
                paramUpdFolio_Funcionalidades_Notificacion.Value = (object)entity.Folio_Funcionalidades_Notificacion ?? DBNull.Value;
                var paramUpdCampo = _dataProvider.GetParameter();
                paramUpdCampo.ParameterName = "Campo";
                paramUpdCampo.DbType = DbType.Int32;
                paramUpdCampo.Value = (object)entity.Campo ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Campos_por_Funcionalidad>("sp_UpdMS_Campos_por_Funcionalidad" , paramUpdFolio , paramUpdFolio_Funcionalidades_Notificacion , paramUpdCampo ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_Campos_por_Funcionalidad.MS_Campos_por_Funcionalidad MS_Campos_por_FuncionalidadDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Funcionalidades_Notificacion = _dataProvider.GetParameter();
                paramUpdFolio_Funcionalidades_Notificacion.ParameterName = "Folio_Funcionalidades_Notificacion";
                paramUpdFolio_Funcionalidades_Notificacion.DbType = DbType.Int32;
                paramUpdFolio_Funcionalidades_Notificacion.Value = (object)entity.Folio_Funcionalidades_Notificacion ?? DBNull.Value;
		var paramUpdCampo = _dataProvider.GetParameter();
                paramUpdCampo.ParameterName = "Campo";
                paramUpdCampo.DbType = DbType.Int32;
                paramUpdCampo.Value = (object)entity.Campo ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Campos_por_Funcionalidad>("sp_UpdMS_Campos_por_Funcionalidad" , paramUpdFolio , paramUpdFolio_Funcionalidades_Notificacion , paramUpdCampo ).FirstOrDefault();

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

