using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Frecuencia_Notificaciones
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Frecuencia_NotificacionesService : IDetalle_Frecuencia_NotificacionesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones> _Detalle_Frecuencia_NotificacionesRepository;
        #endregion

        #region Ctor
        public Detalle_Frecuencia_NotificacionesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones> Detalle_Frecuencia_NotificacionesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Frecuencia_NotificacionesRepository = Detalle_Frecuencia_NotificacionesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Frecuencia_NotificacionesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones>("sp_SelAllDetalle_Frecuencia_Notificaciones");
        }

        public IList<Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Frecuencia_Notificaciones_Complete>("sp_SelAllComplete_Detalle_Frecuencia_Notificaciones");
            return data.Select(m => new Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones
            {
                Folio = m.Folio
                ,FolioNotificacion = m.FolioNotificacion
                ,Frecuencia_Tipo_Frecuencia_Notificacion = new Core.Classes.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion() { Clave = m.Frecuencia.GetValueOrDefault(), Descripcion = m.Frecuencia_Descripcion }
                ,Dia_Tipo_Dia_Notificacion = new Core.Classes.Tipo_Dia_Notificacion.Tipo_Dia_Notificacion() { Clave = m.Dia.GetValueOrDefault(), Descripcion = m.Dia_Descripcion }
                ,Hora = m.Hora


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Frecuencia_Notificaciones>("sp_ListSelCount_Detalle_Frecuencia_Notificaciones", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Frecuencia_Notificaciones>("sp_ListSelAll_Detalle_Frecuencia_Notificaciones", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones
                {
                    Folio = m.Detalle_Frecuencia_Notificaciones_Folio,
                    FolioNotificacion = m.Detalle_Frecuencia_Notificaciones_FolioNotificacion,
                    Frecuencia = m.Detalle_Frecuencia_Notificaciones_Frecuencia,
                    Dia = m.Detalle_Frecuencia_Notificaciones_Dia,
                    Hora = m.Detalle_Frecuencia_Notificaciones_Hora,

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

        public IList<Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Frecuencia_NotificacionesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Frecuencia_NotificacionesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_NotificacionesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Frecuencia_Notificaciones>("sp_ListSelAll_Detalle_Frecuencia_Notificaciones", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Frecuencia_NotificacionesPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Frecuencia_NotificacionesPagingModel
                {
                    Detalle_Frecuencia_Notificacioness =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones
                {
                    Folio = m.Detalle_Frecuencia_Notificaciones_Folio
                    ,FolioNotificacion = m.Detalle_Frecuencia_Notificaciones_FolioNotificacion
                    ,Frecuencia = m.Detalle_Frecuencia_Notificaciones_Frecuencia
                    ,Frecuencia_Tipo_Frecuencia_Notificacion = new Core.Classes.Tipo_Frecuencia_Notificacion.Tipo_Frecuencia_Notificacion() { Clave = m.Detalle_Frecuencia_Notificaciones_Frecuencia.GetValueOrDefault(), Descripcion = m.Detalle_Frecuencia_Notificaciones_Frecuencia_Descripcion }
                    ,Dia = m.Detalle_Frecuencia_Notificaciones_Dia
                    ,Dia_Tipo_Dia_Notificacion = new Core.Classes.Tipo_Dia_Notificacion.Tipo_Dia_Notificacion() { Clave = m.Detalle_Frecuencia_Notificaciones_Dia.GetValueOrDefault(), Descripcion = m.Detalle_Frecuencia_Notificaciones_Dia_Descripcion }
                    ,Hora = m.Detalle_Frecuencia_Notificaciones_Hora

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Frecuencia_NotificacionesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones>("sp_GetDetalle_Frecuencia_Notificaciones", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Frecuencia_Notificaciones>("sp_DelDetalle_Frecuencia_Notificaciones", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolioNotificacion = _dataProvider.GetParameter();
                padreFolioNotificacion.ParameterName = "FolioNotificacion";
                padreFolioNotificacion.DbType = DbType.Int32;
                padreFolioNotificacion.Value = (object)entity.FolioNotificacion ?? DBNull.Value;
                var padreFrecuencia = _dataProvider.GetParameter();
                padreFrecuencia.ParameterName = "Frecuencia";
                padreFrecuencia.DbType = DbType.Int32;
                padreFrecuencia.Value = (object)entity.Frecuencia ?? DBNull.Value;

                var padreDia = _dataProvider.GetParameter();
                padreDia.ParameterName = "Dia";
                padreDia.DbType = DbType.Int32;
                padreDia.Value = (object)entity.Dia ?? DBNull.Value;

                var padreHora = _dataProvider.GetParameter();
                padreHora.ParameterName = "Hora";
                padreHora.DbType = DbType.String;
                padreHora.Value = (object)entity.Hora ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Frecuencia_Notificaciones>("sp_InsDetalle_Frecuencia_Notificaciones" , padreFolioNotificacion
, padreFrecuencia
, padreDia
, padreHora
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

        public int Update(Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolioNotificacion = _dataProvider.GetParameter();
                paramUpdFolioNotificacion.ParameterName = "FolioNotificacion";
                paramUpdFolioNotificacion.DbType = DbType.Int32;
                paramUpdFolioNotificacion.Value = (object)entity.FolioNotificacion ?? DBNull.Value;
                var paramUpdFrecuencia = _dataProvider.GetParameter();
                paramUpdFrecuencia.ParameterName = "Frecuencia";
                paramUpdFrecuencia.DbType = DbType.Int32;
                paramUpdFrecuencia.Value = (object)entity.Frecuencia ?? DBNull.Value;

                var paramUpdDia = _dataProvider.GetParameter();
                paramUpdDia.ParameterName = "Dia";
                paramUpdDia.DbType = DbType.Int32;
                paramUpdDia.Value = (object)entity.Dia ?? DBNull.Value;

                var paramUpdHora = _dataProvider.GetParameter();
                paramUpdHora.ParameterName = "Hora";
                paramUpdHora.DbType = DbType.String;
                paramUpdHora.Value = (object)entity.Hora ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Frecuencia_Notificaciones>("sp_UpdDetalle_Frecuencia_Notificaciones" , paramUpdFolio , paramUpdFolioNotificacion , paramUpdFrecuencia , paramUpdDia , paramUpdHora ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Frecuencia_Notificaciones.Detalle_Frecuencia_Notificaciones Detalle_Frecuencia_NotificacionesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolioNotificacion = _dataProvider.GetParameter();
                paramUpdFolioNotificacion.ParameterName = "FolioNotificacion";
                paramUpdFolioNotificacion.DbType = DbType.Int32;
                paramUpdFolioNotificacion.Value = (object)entity.FolioNotificacion ?? DBNull.Value;
		var paramUpdFrecuencia = _dataProvider.GetParameter();
                paramUpdFrecuencia.ParameterName = "Frecuencia";
                paramUpdFrecuencia.DbType = DbType.Int32;
                paramUpdFrecuencia.Value = (object)entity.Frecuencia ?? DBNull.Value;
		var paramUpdDia = _dataProvider.GetParameter();
                paramUpdDia.ParameterName = "Dia";
                paramUpdDia.DbType = DbType.Int32;
                paramUpdDia.Value = (object)entity.Dia ?? DBNull.Value;
                var paramUpdHora = _dataProvider.GetParameter();
                paramUpdHora.ParameterName = "Hora";
                paramUpdHora.DbType = DbType.String;
                paramUpdHora.Value = (object)entity.Hora ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Frecuencia_Notificaciones>("sp_UpdDetalle_Frecuencia_Notificaciones" , paramUpdFolio , paramUpdFolioNotificacion , paramUpdFrecuencia , paramUpdDia , paramUpdHora ).FirstOrDefault();

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

