using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_de_Funcionalidad_para_Notificacion
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_de_Funcionalidad_para_NotificacionService : IEstatus_de_Funcionalidad_para_NotificacionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion> _Estatus_de_Funcionalidad_para_NotificacionRepository;
        #endregion

        #region Ctor
        public Estatus_de_Funcionalidad_para_NotificacionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion> Estatus_de_Funcionalidad_para_NotificacionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_de_Funcionalidad_para_NotificacionRepository = Estatus_de_Funcionalidad_para_NotificacionRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Estatus_de_Funcionalidad_para_NotificacionRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion>("sp_SelAllEstatus_de_Funcionalidad_para_Notificacion");
        }

        public IList<Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEstatus_de_Funcionalidad_para_Notificacion_Complete>("sp_SelAllComplete_Estatus_de_Funcionalidad_para_Notificacion");
            return data.Select(m => new Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion
            {
                Folio = m.Folio
                ,Campo_para_Estatus = m.Campo_para_Estatus
                ,Nombre_Fisico_del_Campo = m.Nombre_Fisico_del_Campo
                ,Nombre_Fisico_de_la_Tabla = m.Nombre_Fisico_de_la_Tabla


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Estatus_de_Funcionalidad_para_Notificacion>("sp_ListSelCount_Estatus_de_Funcionalidad_para_Notificacion", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_de_Funcionalidad_para_Notificacion>("sp_ListSelAll_Estatus_de_Funcionalidad_para_Notificacion", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion
                {
                    Folio = m.Estatus_de_Funcionalidad_para_Notificacion_Folio,
                    Campo_para_Estatus = m.Estatus_de_Funcionalidad_para_Notificacion_Campo_para_Estatus,
                    Nombre_Fisico_del_Campo = m.Estatus_de_Funcionalidad_para_Notificacion_Nombre_Fisico_del_Campo,
                    Nombre_Fisico_de_la_Tabla = m.Estatus_de_Funcionalidad_para_Notificacion_Nombre_Fisico_de_la_Tabla,

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

        public IList<Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_de_Funcionalidad_para_NotificacionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_de_Funcionalidad_para_NotificacionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_NotificacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_de_Funcionalidad_para_Notificacion>("sp_ListSelAll_Estatus_de_Funcionalidad_para_Notificacion", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Estatus_de_Funcionalidad_para_NotificacionPagingModel result = null;

            if (data != null)
            {
                result = new Estatus_de_Funcionalidad_para_NotificacionPagingModel
                {
                    Estatus_de_Funcionalidad_para_Notificacions =
                        data.Select(m => new Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion
                {
                    Folio = m.Estatus_de_Funcionalidad_para_Notificacion_Folio
                    ,Campo_para_Estatus = m.Estatus_de_Funcionalidad_para_Notificacion_Campo_para_Estatus
                    ,Nombre_Fisico_del_Campo = m.Estatus_de_Funcionalidad_para_Notificacion_Nombre_Fisico_del_Campo
                    ,Nombre_Fisico_de_la_Tabla = m.Estatus_de_Funcionalidad_para_Notificacion_Nombre_Fisico_de_la_Tabla

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_de_Funcionalidad_para_NotificacionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion>("sp_GetEstatus_de_Funcionalidad_para_Notificacion", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEstatus_de_Funcionalidad_para_Notificacion>("sp_DelEstatus_de_Funcionalidad_para_Notificacion", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreCampo_para_Estatus = _dataProvider.GetParameter();
                padreCampo_para_Estatus.ParameterName = "Campo_para_Estatus";
                padreCampo_para_Estatus.DbType = DbType.String;
                padreCampo_para_Estatus.Value = (object)entity.Campo_para_Estatus ?? DBNull.Value;
                var padreNombre_Fisico_del_Campo = _dataProvider.GetParameter();
                padreNombre_Fisico_del_Campo.ParameterName = "Nombre_Fisico_del_Campo";
                padreNombre_Fisico_del_Campo.DbType = DbType.String;
                padreNombre_Fisico_del_Campo.Value = (object)entity.Nombre_Fisico_del_Campo ?? DBNull.Value;
                var padreNombre_Fisico_de_la_Tabla = _dataProvider.GetParameter();
                padreNombre_Fisico_de_la_Tabla.ParameterName = "Nombre_Fisico_de_la_Tabla";
                padreNombre_Fisico_de_la_Tabla.DbType = DbType.String;
                padreNombre_Fisico_de_la_Tabla.Value = (object)entity.Nombre_Fisico_de_la_Tabla ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEstatus_de_Funcionalidad_para_Notificacion>("sp_InsEstatus_de_Funcionalidad_para_Notificacion" , padreCampo_para_Estatus
, padreNombre_Fisico_del_Campo
, padreNombre_Fisico_de_la_Tabla
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

        public int Update(Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdCampo_para_Estatus = _dataProvider.GetParameter();
                paramUpdCampo_para_Estatus.ParameterName = "Campo_para_Estatus";
                paramUpdCampo_para_Estatus.DbType = DbType.String;
                paramUpdCampo_para_Estatus.Value = (object)entity.Campo_para_Estatus ?? DBNull.Value;
                var paramUpdNombre_Fisico_del_Campo = _dataProvider.GetParameter();
                paramUpdNombre_Fisico_del_Campo.ParameterName = "Nombre_Fisico_del_Campo";
                paramUpdNombre_Fisico_del_Campo.DbType = DbType.String;
                paramUpdNombre_Fisico_del_Campo.Value = (object)entity.Nombre_Fisico_del_Campo ?? DBNull.Value;
                var paramUpdNombre_Fisico_de_la_Tabla = _dataProvider.GetParameter();
                paramUpdNombre_Fisico_de_la_Tabla.ParameterName = "Nombre_Fisico_de_la_Tabla";
                paramUpdNombre_Fisico_de_la_Tabla.DbType = DbType.String;
                paramUpdNombre_Fisico_de_la_Tabla.Value = (object)entity.Nombre_Fisico_de_la_Tabla ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_de_Funcionalidad_para_Notificacion>("sp_UpdEstatus_de_Funcionalidad_para_Notificacion" , paramUpdFolio , paramUpdCampo_para_Estatus , paramUpdNombre_Fisico_del_Campo , paramUpdNombre_Fisico_de_la_Tabla ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Estatus_de_Funcionalidad_para_Notificacion.Estatus_de_Funcionalidad_para_Notificacion Estatus_de_Funcionalidad_para_NotificacionDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdCampo_para_Estatus = _dataProvider.GetParameter();
                paramUpdCampo_para_Estatus.ParameterName = "Campo_para_Estatus";
                paramUpdCampo_para_Estatus.DbType = DbType.String;
                paramUpdCampo_para_Estatus.Value = (object)entity.Campo_para_Estatus ?? DBNull.Value;
                var paramUpdNombre_Fisico_del_Campo = _dataProvider.GetParameter();
                paramUpdNombre_Fisico_del_Campo.ParameterName = "Nombre_Fisico_del_Campo";
                paramUpdNombre_Fisico_del_Campo.DbType = DbType.String;
                paramUpdNombre_Fisico_del_Campo.Value = (object)entity.Nombre_Fisico_del_Campo ?? DBNull.Value;
                var paramUpdNombre_Fisico_de_la_Tabla = _dataProvider.GetParameter();
                paramUpdNombre_Fisico_de_la_Tabla.ParameterName = "Nombre_Fisico_de_la_Tabla";
                paramUpdNombre_Fisico_de_la_Tabla.DbType = DbType.String;
                paramUpdNombre_Fisico_de_la_Tabla.Value = (object)entity.Nombre_Fisico_de_la_Tabla ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_de_Funcionalidad_para_Notificacion>("sp_UpdEstatus_de_Funcionalidad_para_Notificacion" , paramUpdFolio , paramUpdCampo_para_Estatus , paramUpdNombre_Fisico_del_Campo , paramUpdNombre_Fisico_de_la_Tabla ).FirstOrDefault();

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

