using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Roles_de_Usuario_Notificacion
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Roles_de_Usuario_NotificacionService : IMS_Roles_de_Usuario_NotificacionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion> _MS_Roles_de_Usuario_NotificacionRepository;
        #endregion

        #region Ctor
        public MS_Roles_de_Usuario_NotificacionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion> MS_Roles_de_Usuario_NotificacionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Roles_de_Usuario_NotificacionRepository = MS_Roles_de_Usuario_NotificacionRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_Roles_de_Usuario_NotificacionRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion>("sp_SelAllMS_Roles_de_Usuario_Notificacion");
        }

        public IList<Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_Roles_de_Usuario_Notificacion_Complete>("sp_SelAllComplete_MS_Roles_de_Usuario_Notificacion");
            return data.Select(m => new Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion
            {
                Folio = m.Folio
                ,Folio_Configuracion_Notificaciones = m.Folio_Configuracion_Notificaciones
                ,Nombre_del_Campo_Nombre_del_campo_en_MS = new Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS() { Clave = m.Nombre_del_Campo.GetValueOrDefault(), Descripcion = m.Nombre_del_Campo_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_Roles_de_Usuario_Notificacion>("sp_ListSelCount_MS_Roles_de_Usuario_Notificacion", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Roles_de_Usuario_Notificacion>("sp_ListSelAll_MS_Roles_de_Usuario_Notificacion", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion
                {
                    Folio = m.MS_Roles_de_Usuario_Notificacion_Folio,
                    Folio_Configuracion_Notificaciones = m.MS_Roles_de_Usuario_Notificacion_Folio_Configuracion_Notificaciones,
                    Nombre_del_Campo = m.MS_Roles_de_Usuario_Notificacion_Nombre_del_Campo,

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

        public IList<Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Roles_de_Usuario_NotificacionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Roles_de_Usuario_NotificacionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_NotificacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Roles_de_Usuario_Notificacion>("sp_ListSelAll_MS_Roles_de_Usuario_Notificacion", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_Roles_de_Usuario_NotificacionPagingModel result = null;

            if (data != null)
            {
                result = new MS_Roles_de_Usuario_NotificacionPagingModel
                {
                    MS_Roles_de_Usuario_Notificacions =
                        data.Select(m => new Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion
                {
                    Folio = m.MS_Roles_de_Usuario_Notificacion_Folio
                    ,Folio_Configuracion_Notificaciones = m.MS_Roles_de_Usuario_Notificacion_Folio_Configuracion_Notificaciones
                    ,Nombre_del_Campo = m.MS_Roles_de_Usuario_Notificacion_Nombre_del_Campo
                    ,Nombre_del_Campo_Nombre_del_campo_en_MS = new Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS() { Clave = m.MS_Roles_de_Usuario_Notificacion_Nombre_del_Campo.GetValueOrDefault(), Descripcion = m.MS_Roles_de_Usuario_Notificacion_Nombre_del_Campo_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Roles_de_Usuario_NotificacionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion>("sp_GetMS_Roles_de_Usuario_Notificacion", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_Roles_de_Usuario_Notificacion>("sp_DelMS_Roles_de_Usuario_Notificacion", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Configuracion_Notificaciones = _dataProvider.GetParameter();
                padreFolio_Configuracion_Notificaciones.ParameterName = "Folio_Configuracion_Notificaciones";
                padreFolio_Configuracion_Notificaciones.DbType = DbType.Int32;
                padreFolio_Configuracion_Notificaciones.Value = (object)entity.Folio_Configuracion_Notificaciones ?? DBNull.Value;
                var padreNombre_del_Campo = _dataProvider.GetParameter();
                padreNombre_del_Campo.ParameterName = "Nombre_del_Campo";
                padreNombre_del_Campo.DbType = DbType.Int32;
                padreNombre_del_Campo.Value = (object)entity.Nombre_del_Campo ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_Roles_de_Usuario_Notificacion>("sp_InsMS_Roles_de_Usuario_Notificacion" , padreFolio_Configuracion_Notificaciones
, padreNombre_del_Campo
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

        public int Update(Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Configuracion_Notificaciones = _dataProvider.GetParameter();
                paramUpdFolio_Configuracion_Notificaciones.ParameterName = "Folio_Configuracion_Notificaciones";
                paramUpdFolio_Configuracion_Notificaciones.DbType = DbType.Int32;
                paramUpdFolio_Configuracion_Notificaciones.Value = (object)entity.Folio_Configuracion_Notificaciones ?? DBNull.Value;
                var paramUpdNombre_del_Campo = _dataProvider.GetParameter();
                paramUpdNombre_del_Campo.ParameterName = "Nombre_del_Campo";
                paramUpdNombre_del_Campo.DbType = DbType.Int32;
                paramUpdNombre_del_Campo.Value = (object)entity.Nombre_del_Campo ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Roles_de_Usuario_Notificacion>("sp_UpdMS_Roles_de_Usuario_Notificacion" , paramUpdFolio , paramUpdFolio_Configuracion_Notificaciones , paramUpdNombre_del_Campo ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_Roles_de_Usuario_Notificacion.MS_Roles_de_Usuario_Notificacion MS_Roles_de_Usuario_NotificacionDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Configuracion_Notificaciones = _dataProvider.GetParameter();
                paramUpdFolio_Configuracion_Notificaciones.ParameterName = "Folio_Configuracion_Notificaciones";
                paramUpdFolio_Configuracion_Notificaciones.DbType = DbType.Int32;
                paramUpdFolio_Configuracion_Notificaciones.Value = (object)entity.Folio_Configuracion_Notificaciones ?? DBNull.Value;
		var paramUpdNombre_del_Campo = _dataProvider.GetParameter();
                paramUpdNombre_del_Campo.ParameterName = "Nombre_del_Campo";
                paramUpdNombre_del_Campo.DbType = DbType.Int32;
                paramUpdNombre_del_Campo.Value = (object)entity.Nombre_del_Campo ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Roles_de_Usuario_Notificacion>("sp_UpdMS_Roles_de_Usuario_Notificacion" , paramUpdFolio , paramUpdFolio_Configuracion_Notificaciones , paramUpdNombre_del_Campo ).FirstOrDefault();

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

