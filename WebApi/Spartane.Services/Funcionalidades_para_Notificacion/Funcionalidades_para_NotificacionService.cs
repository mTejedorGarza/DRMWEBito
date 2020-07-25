using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Funcionalidades_para_Notificacion;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Funcionalidades_para_Notificacion
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Funcionalidades_para_NotificacionService : IFuncionalidades_para_NotificacionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion> _Funcionalidades_para_NotificacionRepository;
        #endregion

        #region Ctor
        public Funcionalidades_para_NotificacionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion> Funcionalidades_para_NotificacionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Funcionalidades_para_NotificacionRepository = Funcionalidades_para_NotificacionRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Funcionalidades_para_NotificacionRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion>("sp_SelAllFuncionalidades_para_Notificacion");
        }

        public IList<Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallFuncionalidades_para_Notificacion_Complete>("sp_SelAllComplete_Funcionalidades_para_Notificacion");
            return data.Select(m => new Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion
            {
                Folio = m.Folio
                ,Funcionalidad = m.Funcionalidad
                ,Nombre_de_la_Tabla = m.Nombre_de_la_Tabla
                ,Campos_de_Estatus_Estatus_de_Funcionalidad_para_Notificacion = new Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion() { Folio = m.Campos_de_Estatus.GetValueOrDefault(), Campo_para_Estatus = m.Campos_de_Estatus_Campo_para_Estatus }
                ,Validacion_Obligatoria = m.Validacion_Obligatoria


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Funcionalidades_para_Notificacion>("sp_ListSelCount_Funcionalidades_para_Notificacion", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllFuncionalidades_para_Notificacion>("sp_ListSelAll_Funcionalidades_para_Notificacion", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion
                {
                    Folio = m.Funcionalidades_para_Notificacion_Folio,
                    Funcionalidad = m.Funcionalidades_para_Notificacion_Funcionalidad,
                    Nombre_de_la_Tabla = m.Funcionalidades_para_Notificacion_Nombre_de_la_Tabla,
                    Campos_de_Estatus = m.Funcionalidades_para_Notificacion_Campos_de_Estatus,
                    Validacion_Obligatoria = m.Funcionalidades_para_Notificacion_Validacion_Obligatoria,

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

        public IList<Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Funcionalidades_para_NotificacionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Funcionalidades_para_NotificacionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_NotificacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllFuncionalidades_para_Notificacion>("sp_ListSelAll_Funcionalidades_para_Notificacion", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Funcionalidades_para_NotificacionPagingModel result = null;

            if (data != null)
            {
                result = new Funcionalidades_para_NotificacionPagingModel
                {
                    Funcionalidades_para_Notificacions =
                        data.Select(m => new Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion
                {
                    Folio = m.Funcionalidades_para_Notificacion_Folio
                    ,Funcionalidad = m.Funcionalidades_para_Notificacion_Funcionalidad
                    ,Nombre_de_la_Tabla = m.Funcionalidades_para_Notificacion_Nombre_de_la_Tabla
                    ,Campos_de_Estatus = m.Funcionalidades_para_Notificacion_Campos_de_Estatus
                    ,Campos_de_Estatus_Estatus_de_Funcionalidad_para_Notificacion = new Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion() { Folio = m.Funcionalidades_para_Notificacion_Campos_de_Estatus.GetValueOrDefault(), Campo_para_Estatus = m.Funcionalidades_para_Notificacion_Campos_de_Estatus_Campo_para_Estatus }
                    ,Validacion_Obligatoria = m.Funcionalidades_para_Notificacion_Validacion_Obligatoria

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Funcionalidades_para_NotificacionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion>("sp_GetFuncionalidades_para_Notificacion", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelFuncionalidades_para_Notificacion>("sp_DelFuncionalidades_para_Notificacion", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFuncionalidad = _dataProvider.GetParameter();
                padreFuncionalidad.ParameterName = "Funcionalidad";
                padreFuncionalidad.DbType = DbType.String;
                padreFuncionalidad.Value = (object)entity.Funcionalidad ?? DBNull.Value;
                var padreNombre_de_la_Tabla = _dataProvider.GetParameter();
                padreNombre_de_la_Tabla.ParameterName = "Nombre_de_la_Tabla";
                padreNombre_de_la_Tabla.DbType = DbType.String;
                padreNombre_de_la_Tabla.Value = (object)entity.Nombre_de_la_Tabla ?? DBNull.Value;
                var padreCampos_de_Estatus = _dataProvider.GetParameter();
                padreCampos_de_Estatus.ParameterName = "Campos_de_Estatus";
                padreCampos_de_Estatus.DbType = DbType.Int32;
                padreCampos_de_Estatus.Value = (object)entity.Campos_de_Estatus ?? DBNull.Value;

                var padreValidacion_Obligatoria = _dataProvider.GetParameter();
                padreValidacion_Obligatoria.ParameterName = "Validacion_Obligatoria";
                padreValidacion_Obligatoria.DbType = DbType.String;
                padreValidacion_Obligatoria.Value = (object)entity.Validacion_Obligatoria ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsFuncionalidades_para_Notificacion>("sp_InsFuncionalidades_para_Notificacion" , padreFuncionalidad
, padreNombre_de_la_Tabla
, padreCampos_de_Estatus
, padreValidacion_Obligatoria
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

        public int Update(Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFuncionalidad = _dataProvider.GetParameter();
                paramUpdFuncionalidad.ParameterName = "Funcionalidad";
                paramUpdFuncionalidad.DbType = DbType.String;
                paramUpdFuncionalidad.Value = (object)entity.Funcionalidad ?? DBNull.Value;
                var paramUpdNombre_de_la_Tabla = _dataProvider.GetParameter();
                paramUpdNombre_de_la_Tabla.ParameterName = "Nombre_de_la_Tabla";
                paramUpdNombre_de_la_Tabla.DbType = DbType.String;
                paramUpdNombre_de_la_Tabla.Value = (object)entity.Nombre_de_la_Tabla ?? DBNull.Value;
                var paramUpdCampos_de_Estatus = _dataProvider.GetParameter();
                paramUpdCampos_de_Estatus.ParameterName = "Campos_de_Estatus";
                paramUpdCampos_de_Estatus.DbType = DbType.Int32;
                paramUpdCampos_de_Estatus.Value = (object)entity.Campos_de_Estatus ?? DBNull.Value;

                var paramUpdValidacion_Obligatoria = _dataProvider.GetParameter();
                paramUpdValidacion_Obligatoria.ParameterName = "Validacion_Obligatoria";
                paramUpdValidacion_Obligatoria.DbType = DbType.String;
                paramUpdValidacion_Obligatoria.Value = (object)entity.Validacion_Obligatoria ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdFuncionalidades_para_Notificacion>("sp_UpdFuncionalidades_para_Notificacion" , paramUpdFolio , paramUpdFuncionalidad , paramUpdNombre_de_la_Tabla , paramUpdCampos_de_Estatus , paramUpdValidacion_Obligatoria ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion Funcionalidades_para_NotificacionDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFuncionalidad = _dataProvider.GetParameter();
                paramUpdFuncionalidad.ParameterName = "Funcionalidad";
                paramUpdFuncionalidad.DbType = DbType.String;
                paramUpdFuncionalidad.Value = (object)entity.Funcionalidad ?? DBNull.Value;
                var paramUpdNombre_de_la_Tabla = _dataProvider.GetParameter();
                paramUpdNombre_de_la_Tabla.ParameterName = "Nombre_de_la_Tabla";
                paramUpdNombre_de_la_Tabla.DbType = DbType.String;
                paramUpdNombre_de_la_Tabla.Value = (object)entity.Nombre_de_la_Tabla ?? DBNull.Value;
		var paramUpdCampos_de_Estatus = _dataProvider.GetParameter();
                paramUpdCampos_de_Estatus.ParameterName = "Campos_de_Estatus";
                paramUpdCampos_de_Estatus.DbType = DbType.Int32;
                paramUpdCampos_de_Estatus.Value = (object)entity.Campos_de_Estatus ?? DBNull.Value;
                var paramUpdValidacion_Obligatoria = _dataProvider.GetParameter();
                paramUpdValidacion_Obligatoria.ParameterName = "Validacion_Obligatoria";
                paramUpdValidacion_Obligatoria.DbType = DbType.String;
                paramUpdValidacion_Obligatoria.Value = (object)entity.Validacion_Obligatoria ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdFuncionalidades_para_Notificacion>("sp_UpdFuncionalidades_para_Notificacion" , paramUpdFolio , paramUpdFuncionalidad , paramUpdNombre_de_la_Tabla , paramUpdCampos_de_Estatus , paramUpdValidacion_Obligatoria ).FirstOrDefault();

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

