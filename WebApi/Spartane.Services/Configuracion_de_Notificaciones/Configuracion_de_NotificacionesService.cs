using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Configuracion_de_Notificaciones;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Configuracion_de_Notificaciones
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Configuracion_de_NotificacionesService : IConfiguracion_de_NotificacionesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> _Configuracion_de_NotificacionesRepository;
        #endregion

        #region Ctor
        public Configuracion_de_NotificacionesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> Configuracion_de_NotificacionesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Configuracion_de_NotificacionesRepository = Configuracion_de_NotificacionesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Configuracion_de_NotificacionesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>("sp_SelAllConfiguracion_de_Notificaciones");
        }

        public IList<Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallConfiguracion_de_Notificaciones_Complete>("sp_SelAllComplete_Configuracion_de_Notificaciones");
            return data.Select(m => new Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Nombre_de_la_Notificacion = m.Nombre_de_la_Notificacion
                ,Es_permanente = m.Es_permanente.GetValueOrDefault()
                ,Funcionalidad_Funcionalidades_para_Notificacion = new Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion() { Folio = m.Funcionalidad.GetValueOrDefault(), Funcionalidad = m.Funcionalidad_Funcionalidad }
                ,Tipo_de_Notificacion_Tipo_de_Notificacion = new Core.Classes.Tipo_de_Notificacion.Tipo_de_Notificacion() { Clave = m.Tipo_de_Notificacion.GetValueOrDefault(), Descripcion = m.Tipo_de_Notificacion_Descripcion }
                ,Tipo_de_Accion_Tipo_de_Accion_Notificacion = new Core.Classes.Tipo_de_Accion_Notificacion.Tipo_de_Accion_Notificacion() { Clave = m.Tipo_de_Accion.GetValueOrDefault(), Descripcion = m.Tipo_de_Accion_Descripcion }
                ,Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion = new Core.Classes.Tipo_de_Recordatorio_Notificacion.Tipo_de_Recordatorio_Notificacion() { Clave = m.Tipo_de_Recordatorio.GetValueOrDefault(), Descripcion = m.Tipo_de_Recordatorio_Descripcion }
                ,Fecha_inicio = m.Fecha_inicio
                ,Tiene_fecha_de_finalizacion_definida = m.Tiene_fecha_de_finalizacion_definida.GetValueOrDefault()
                ,Cantidad_de_dias_a_validar = m.Cantidad_de_dias_a_validar
                ,Fecha_a_validar_Nombre_del_campo_en_MS = new Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS() { Clave = m.Fecha_a_validar.GetValueOrDefault(), Descripcion = m.Fecha_a_validar_Descripcion }
                ,Fecha_fin = m.Fecha_fin
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }
                ,Notificar_por_correo = m.Notificar_por_correo.GetValueOrDefault()
                ,Texto_que_llevara_el_correo = m.Texto_que_llevara_el_correo
                ,Notificacion_push = m.Notificacion_push.GetValueOrDefault()
                ,Texto_a_mostrar_en_la_notificacion_Push = m.Texto_a_mostrar_en_la_notificacion_Push


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Configuracion_de_Notificaciones>("sp_ListSelCount_Configuracion_de_Notificaciones", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllConfiguracion_de_Notificaciones>("sp_ListSelAll_Configuracion_de_Notificaciones", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones
                {
                    Folio = m.Configuracion_de_Notificaciones_Folio,
                    Fecha_de_Registro = m.Configuracion_de_Notificaciones_Fecha_de_Registro,
                    Hora_de_Registro = m.Configuracion_de_Notificaciones_Hora_de_Registro,
                    Usuario_que_Registra = m.Configuracion_de_Notificaciones_Usuario_que_Registra,
                    Nombre_de_la_Notificacion = m.Configuracion_de_Notificaciones_Nombre_de_la_Notificacion,
                    Es_permanente = m.Configuracion_de_Notificaciones_Es_permanente ?? false,
                    Funcionalidad = m.Configuracion_de_Notificaciones_Funcionalidad,
                    Tipo_de_Notificacion = m.Configuracion_de_Notificaciones_Tipo_de_Notificacion,
                    Tipo_de_Accion = m.Configuracion_de_Notificaciones_Tipo_de_Accion,
                    Tipo_de_Recordatorio = m.Configuracion_de_Notificaciones_Tipo_de_Recordatorio,
                    Fecha_inicio = m.Configuracion_de_Notificaciones_Fecha_inicio,
                    Tiene_fecha_de_finalizacion_definida = m.Configuracion_de_Notificaciones_Tiene_fecha_de_finalizacion_definida ?? false,
                    Cantidad_de_dias_a_validar = m.Configuracion_de_Notificaciones_Cantidad_de_dias_a_validar,
                    Fecha_a_validar = m.Configuracion_de_Notificaciones_Fecha_a_validar,
                    Fecha_fin = m.Configuracion_de_Notificaciones_Fecha_fin,
                    Estatus = m.Configuracion_de_Notificaciones_Estatus,
                    Notificar_por_correo = m.Configuracion_de_Notificaciones_Notificar_por_correo ?? false,
                    Texto_que_llevara_el_correo = m.Configuracion_de_Notificaciones_Texto_que_llevara_el_correo,
                    Notificacion_push = m.Configuracion_de_Notificaciones_Notificacion_push ?? false,
                    Texto_a_mostrar_en_la_notificacion_Push = m.Configuracion_de_Notificaciones_Texto_a_mostrar_en_la_notificacion_Push,

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

        public IList<Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Configuracion_de_NotificacionesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Configuracion_de_NotificacionesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_NotificacionesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllConfiguracion_de_Notificaciones>("sp_ListSelAll_Configuracion_de_Notificaciones", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Configuracion_de_NotificacionesPagingModel result = null;

            if (data != null)
            {
                result = new Configuracion_de_NotificacionesPagingModel
                {
                    Configuracion_de_Notificacioness =
                        data.Select(m => new Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones
                {
                    Folio = m.Configuracion_de_Notificaciones_Folio
                    ,Fecha_de_Registro = m.Configuracion_de_Notificaciones_Fecha_de_Registro
                    ,Hora_de_Registro = m.Configuracion_de_Notificaciones_Hora_de_Registro
                    ,Usuario_que_Registra = m.Configuracion_de_Notificaciones_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Configuracion_de_Notificaciones_Usuario_que_Registra.GetValueOrDefault(), Name = m.Configuracion_de_Notificaciones_Usuario_que_Registra_Name }
                    ,Nombre_de_la_Notificacion = m.Configuracion_de_Notificaciones_Nombre_de_la_Notificacion
                    ,Es_permanente = m.Configuracion_de_Notificaciones_Es_permanente ?? false
                    ,Funcionalidad = m.Configuracion_de_Notificaciones_Funcionalidad
                    ,Funcionalidad_Funcionalidades_para_Notificacion = new Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion() { Folio = m.Configuracion_de_Notificaciones_Funcionalidad.GetValueOrDefault(), Funcionalidad = m.Configuracion_de_Notificaciones_Funcionalidad_Funcionalidad }
                    ,Tipo_de_Notificacion = m.Configuracion_de_Notificaciones_Tipo_de_Notificacion
                    ,Tipo_de_Notificacion_Tipo_de_Notificacion = new Core.Classes.Tipo_de_Notificacion.Tipo_de_Notificacion() { Clave = m.Configuracion_de_Notificaciones_Tipo_de_Notificacion.GetValueOrDefault(), Descripcion = m.Configuracion_de_Notificaciones_Tipo_de_Notificacion_Descripcion }
                    ,Tipo_de_Accion = m.Configuracion_de_Notificaciones_Tipo_de_Accion
                    ,Tipo_de_Accion_Tipo_de_Accion_Notificacion = new Core.Classes.Tipo_de_Accion_Notificacion.Tipo_de_Accion_Notificacion() { Clave = m.Configuracion_de_Notificaciones_Tipo_de_Accion.GetValueOrDefault(), Descripcion = m.Configuracion_de_Notificaciones_Tipo_de_Accion_Descripcion }
                    ,Tipo_de_Recordatorio = m.Configuracion_de_Notificaciones_Tipo_de_Recordatorio
                    ,Tipo_de_Recordatorio_Tipo_de_Recordatorio_Notificacion = new Core.Classes.Tipo_de_Recordatorio_Notificacion.Tipo_de_Recordatorio_Notificacion() { Clave = m.Configuracion_de_Notificaciones_Tipo_de_Recordatorio.GetValueOrDefault(), Descripcion = m.Configuracion_de_Notificaciones_Tipo_de_Recordatorio_Descripcion }
                    ,Fecha_inicio = m.Configuracion_de_Notificaciones_Fecha_inicio
                    ,Tiene_fecha_de_finalizacion_definida = m.Configuracion_de_Notificaciones_Tiene_fecha_de_finalizacion_definida ?? false
                    ,Cantidad_de_dias_a_validar = m.Configuracion_de_Notificaciones_Cantidad_de_dias_a_validar
                    ,Fecha_a_validar = m.Configuracion_de_Notificaciones_Fecha_a_validar
                    ,Fecha_a_validar_Nombre_del_campo_en_MS = new Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS() { Clave = m.Configuracion_de_Notificaciones_Fecha_a_validar.GetValueOrDefault(), Descripcion = m.Configuracion_de_Notificaciones_Fecha_a_validar_Descripcion }
                    ,Fecha_fin = m.Configuracion_de_Notificaciones_Fecha_fin
                    ,Estatus = m.Configuracion_de_Notificaciones_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Configuracion_de_Notificaciones_Estatus.GetValueOrDefault(), Descripcion = m.Configuracion_de_Notificaciones_Estatus_Descripcion }
                    ,Notificar_por_correo = m.Configuracion_de_Notificaciones_Notificar_por_correo ?? false
                    ,Texto_que_llevara_el_correo = m.Configuracion_de_Notificaciones_Texto_que_llevara_el_correo
                    ,Notificacion_push = m.Configuracion_de_Notificaciones_Notificacion_push ?? false
                    ,Texto_a_mostrar_en_la_notificacion_Push = m.Configuracion_de_Notificaciones_Texto_a_mostrar_en_la_notificacion_Push

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Configuracion_de_NotificacionesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones>("sp_GetConfiguracion_de_Notificaciones", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelConfiguracion_de_Notificaciones>("sp_DelConfiguracion_de_Notificaciones", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFecha_de_Registro = _dataProvider.GetParameter();
                padreFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                padreFecha_de_Registro.DbType = DbType.DateTime;
                padreFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var padreHora_de_Registro = _dataProvider.GetParameter();
                padreHora_de_Registro.ParameterName = "Hora_de_Registro";
                padreHora_de_Registro.DbType = DbType.String;
                padreHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var padreUsuario_que_Registra = _dataProvider.GetParameter();
                padreUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                padreUsuario_que_Registra.DbType = DbType.Int32;
                padreUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var padreNombre_de_la_Notificacion = _dataProvider.GetParameter();
                padreNombre_de_la_Notificacion.ParameterName = "Nombre_de_la_Notificacion";
                padreNombre_de_la_Notificacion.DbType = DbType.String;
                padreNombre_de_la_Notificacion.Value = (object)entity.Nombre_de_la_Notificacion ?? DBNull.Value;
                var padreEs_permanente = _dataProvider.GetParameter();
                padreEs_permanente.ParameterName = "Es_permanente";
                padreEs_permanente.DbType = DbType.Boolean;
                padreEs_permanente.Value = (object)entity.Es_permanente ?? DBNull.Value;
                var padreFuncionalidad = _dataProvider.GetParameter();
                padreFuncionalidad.ParameterName = "Funcionalidad";
                padreFuncionalidad.DbType = DbType.Int32;
                padreFuncionalidad.Value = (object)entity.Funcionalidad ?? DBNull.Value;

                var padreTipo_de_Notificacion = _dataProvider.GetParameter();
                padreTipo_de_Notificacion.ParameterName = "Tipo_de_Notificacion";
                padreTipo_de_Notificacion.DbType = DbType.Int32;
                padreTipo_de_Notificacion.Value = (object)entity.Tipo_de_Notificacion ?? DBNull.Value;

                var padreTipo_de_Accion = _dataProvider.GetParameter();
                padreTipo_de_Accion.ParameterName = "Tipo_de_Accion";
                padreTipo_de_Accion.DbType = DbType.Int32;
                padreTipo_de_Accion.Value = (object)entity.Tipo_de_Accion ?? DBNull.Value;

                var padreTipo_de_Recordatorio = _dataProvider.GetParameter();
                padreTipo_de_Recordatorio.ParameterName = "Tipo_de_Recordatorio";
                padreTipo_de_Recordatorio.DbType = DbType.Int32;
                padreTipo_de_Recordatorio.Value = (object)entity.Tipo_de_Recordatorio ?? DBNull.Value;

                var padreFecha_inicio = _dataProvider.GetParameter();
                padreFecha_inicio.ParameterName = "Fecha_inicio";
                padreFecha_inicio.DbType = DbType.DateTime;
                padreFecha_inicio.Value = (object)entity.Fecha_inicio ?? DBNull.Value;

                var padreTiene_fecha_de_finalizacion_definida = _dataProvider.GetParameter();
                padreTiene_fecha_de_finalizacion_definida.ParameterName = "Tiene_fecha_de_finalizacion_definida";
                padreTiene_fecha_de_finalizacion_definida.DbType = DbType.Boolean;
                padreTiene_fecha_de_finalizacion_definida.Value = (object)entity.Tiene_fecha_de_finalizacion_definida ?? DBNull.Value;
                var padreCantidad_de_dias_a_validar = _dataProvider.GetParameter();
                padreCantidad_de_dias_a_validar.ParameterName = "Cantidad_de_dias_a_validar";
                padreCantidad_de_dias_a_validar.DbType = DbType.Int32;
                padreCantidad_de_dias_a_validar.Value = (object)entity.Cantidad_de_dias_a_validar ?? DBNull.Value;

                var padreFecha_a_validar = _dataProvider.GetParameter();
                padreFecha_a_validar.ParameterName = "Fecha_a_validar";
                padreFecha_a_validar.DbType = DbType.Int32;
                padreFecha_a_validar.Value = (object)entity.Fecha_a_validar ?? DBNull.Value;

                var padreFecha_fin = _dataProvider.GetParameter();
                padreFecha_fin.ParameterName = "Fecha_fin";
                padreFecha_fin.DbType = DbType.DateTime;
                padreFecha_fin.Value = (object)entity.Fecha_fin ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var padreNotificar_por_correo = _dataProvider.GetParameter();
                padreNotificar_por_correo.ParameterName = "Notificar_por_correo";
                padreNotificar_por_correo.DbType = DbType.Boolean;
                padreNotificar_por_correo.Value = (object)entity.Notificar_por_correo ?? DBNull.Value;
                var padreTexto_que_llevara_el_correo = _dataProvider.GetParameter();
                padreTexto_que_llevara_el_correo.ParameterName = "Texto_que_llevara_el_correo";
                padreTexto_que_llevara_el_correo.DbType = DbType.String;
                padreTexto_que_llevara_el_correo.Value = (object)entity.Texto_que_llevara_el_correo ?? DBNull.Value;
                var padreNotificacion_push = _dataProvider.GetParameter();
                padreNotificacion_push.ParameterName = "Notificacion_push";
                padreNotificacion_push.DbType = DbType.Boolean;
                padreNotificacion_push.Value = (object)entity.Notificacion_push ?? DBNull.Value;
                var padreTexto_a_mostrar_en_la_notificacion_Push = _dataProvider.GetParameter();
                padreTexto_a_mostrar_en_la_notificacion_Push.ParameterName = "Texto_a_mostrar_en_la_notificacion_Push";
                padreTexto_a_mostrar_en_la_notificacion_Push.DbType = DbType.String;
                padreTexto_a_mostrar_en_la_notificacion_Push.Value = (object)entity.Texto_a_mostrar_en_la_notificacion_Push ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsConfiguracion_de_Notificaciones>("sp_InsConfiguracion_de_Notificaciones" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreNombre_de_la_Notificacion
, padreEs_permanente
, padreFuncionalidad
, padreTipo_de_Notificacion
, padreTipo_de_Accion
, padreTipo_de_Recordatorio
, padreFecha_inicio
, padreTiene_fecha_de_finalizacion_definida
, padreCantidad_de_dias_a_validar
, padreFecha_a_validar
, padreFecha_fin
, padreEstatus
, padreNotificar_por_correo
, padreTexto_que_llevara_el_correo
, padreNotificacion_push
, padreTexto_a_mostrar_en_la_notificacion_Push
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

        public int Update(Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var paramUpdNombre_de_la_Notificacion = _dataProvider.GetParameter();
                paramUpdNombre_de_la_Notificacion.ParameterName = "Nombre_de_la_Notificacion";
                paramUpdNombre_de_la_Notificacion.DbType = DbType.String;
                paramUpdNombre_de_la_Notificacion.Value = (object)entity.Nombre_de_la_Notificacion ?? DBNull.Value;
                var paramUpdEs_permanente = _dataProvider.GetParameter();
                paramUpdEs_permanente.ParameterName = "Es_permanente";
                paramUpdEs_permanente.DbType = DbType.Boolean;
                paramUpdEs_permanente.Value = (object)entity.Es_permanente ?? DBNull.Value;
                var paramUpdFuncionalidad = _dataProvider.GetParameter();
                paramUpdFuncionalidad.ParameterName = "Funcionalidad";
                paramUpdFuncionalidad.DbType = DbType.Int32;
                paramUpdFuncionalidad.Value = (object)entity.Funcionalidad ?? DBNull.Value;

                var paramUpdTipo_de_Notificacion = _dataProvider.GetParameter();
                paramUpdTipo_de_Notificacion.ParameterName = "Tipo_de_Notificacion";
                paramUpdTipo_de_Notificacion.DbType = DbType.Int32;
                paramUpdTipo_de_Notificacion.Value = (object)entity.Tipo_de_Notificacion ?? DBNull.Value;

                var paramUpdTipo_de_Accion = _dataProvider.GetParameter();
                paramUpdTipo_de_Accion.ParameterName = "Tipo_de_Accion";
                paramUpdTipo_de_Accion.DbType = DbType.Int32;
                paramUpdTipo_de_Accion.Value = (object)entity.Tipo_de_Accion ?? DBNull.Value;

                var paramUpdTipo_de_Recordatorio = _dataProvider.GetParameter();
                paramUpdTipo_de_Recordatorio.ParameterName = "Tipo_de_Recordatorio";
                paramUpdTipo_de_Recordatorio.DbType = DbType.Int32;
                paramUpdTipo_de_Recordatorio.Value = (object)entity.Tipo_de_Recordatorio ?? DBNull.Value;

                var paramUpdFecha_inicio = _dataProvider.GetParameter();
                paramUpdFecha_inicio.ParameterName = "Fecha_inicio";
                paramUpdFecha_inicio.DbType = DbType.DateTime;
                paramUpdFecha_inicio.Value = (object)entity.Fecha_inicio ?? DBNull.Value;

                var paramUpdTiene_fecha_de_finalizacion_definida = _dataProvider.GetParameter();
                paramUpdTiene_fecha_de_finalizacion_definida.ParameterName = "Tiene_fecha_de_finalizacion_definida";
                paramUpdTiene_fecha_de_finalizacion_definida.DbType = DbType.Boolean;
                paramUpdTiene_fecha_de_finalizacion_definida.Value = (object)entity.Tiene_fecha_de_finalizacion_definida ?? DBNull.Value;
                var paramUpdCantidad_de_dias_a_validar = _dataProvider.GetParameter();
                paramUpdCantidad_de_dias_a_validar.ParameterName = "Cantidad_de_dias_a_validar";
                paramUpdCantidad_de_dias_a_validar.DbType = DbType.Int32;
                paramUpdCantidad_de_dias_a_validar.Value = (object)entity.Cantidad_de_dias_a_validar ?? DBNull.Value;

                var paramUpdFecha_a_validar = _dataProvider.GetParameter();
                paramUpdFecha_a_validar.ParameterName = "Fecha_a_validar";
                paramUpdFecha_a_validar.DbType = DbType.Int32;
                paramUpdFecha_a_validar.Value = (object)entity.Fecha_a_validar ?? DBNull.Value;

                var paramUpdFecha_fin = _dataProvider.GetParameter();
                paramUpdFecha_fin.ParameterName = "Fecha_fin";
                paramUpdFecha_fin.DbType = DbType.DateTime;
                paramUpdFecha_fin.Value = (object)entity.Fecha_fin ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var paramUpdNotificar_por_correo = _dataProvider.GetParameter();
                paramUpdNotificar_por_correo.ParameterName = "Notificar_por_correo";
                paramUpdNotificar_por_correo.DbType = DbType.Boolean;
                paramUpdNotificar_por_correo.Value = (object)entity.Notificar_por_correo ?? DBNull.Value;
                var paramUpdTexto_que_llevara_el_correo = _dataProvider.GetParameter();
                paramUpdTexto_que_llevara_el_correo.ParameterName = "Texto_que_llevara_el_correo";
                paramUpdTexto_que_llevara_el_correo.DbType = DbType.String;
                paramUpdTexto_que_llevara_el_correo.Value = (object)entity.Texto_que_llevara_el_correo ?? DBNull.Value;
                var paramUpdNotificacion_push = _dataProvider.GetParameter();
                paramUpdNotificacion_push.ParameterName = "Notificacion_push";
                paramUpdNotificacion_push.DbType = DbType.Boolean;
                paramUpdNotificacion_push.Value = (object)entity.Notificacion_push ?? DBNull.Value;
                var paramUpdTexto_a_mostrar_en_la_notificacion_Push = _dataProvider.GetParameter();
                paramUpdTexto_a_mostrar_en_la_notificacion_Push.ParameterName = "Texto_a_mostrar_en_la_notificacion_Push";
                paramUpdTexto_a_mostrar_en_la_notificacion_Push.DbType = DbType.String;
                paramUpdTexto_a_mostrar_en_la_notificacion_Push.Value = (object)entity.Texto_a_mostrar_en_la_notificacion_Push ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdConfiguracion_de_Notificaciones>("sp_UpdConfiguracion_de_Notificaciones" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_de_la_Notificacion , paramUpdEs_permanente , paramUpdFuncionalidad , paramUpdTipo_de_Notificacion , paramUpdTipo_de_Accion , paramUpdTipo_de_Recordatorio , paramUpdFecha_inicio , paramUpdTiene_fecha_de_finalizacion_definida , paramUpdCantidad_de_dias_a_validar , paramUpdFecha_a_validar , paramUpdFecha_fin , paramUpdEstatus , paramUpdNotificar_por_correo , paramUpdTexto_que_llevara_el_correo , paramUpdNotificacion_push , paramUpdTexto_a_mostrar_en_la_notificacion_Push ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones Configuracion_de_NotificacionesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdNombre_de_la_Notificacion = _dataProvider.GetParameter();
                paramUpdNombre_de_la_Notificacion.ParameterName = "Nombre_de_la_Notificacion";
                paramUpdNombre_de_la_Notificacion.DbType = DbType.String;
                paramUpdNombre_de_la_Notificacion.Value = (object)entity.Nombre_de_la_Notificacion ?? DBNull.Value;
                var paramUpdEs_permanente = _dataProvider.GetParameter();
                paramUpdEs_permanente.ParameterName = "Es_permanente";
                paramUpdEs_permanente.DbType = DbType.Boolean;
                paramUpdEs_permanente.Value = (object)entity.Es_permanente ?? DBNull.Value;
		var paramUpdFuncionalidad = _dataProvider.GetParameter();
                paramUpdFuncionalidad.ParameterName = "Funcionalidad";
                paramUpdFuncionalidad.DbType = DbType.Int32;
                paramUpdFuncionalidad.Value = (object)entity.Funcionalidad ?? DBNull.Value;
		var paramUpdTipo_de_Notificacion = _dataProvider.GetParameter();
                paramUpdTipo_de_Notificacion.ParameterName = "Tipo_de_Notificacion";
                paramUpdTipo_de_Notificacion.DbType = DbType.Int32;
                paramUpdTipo_de_Notificacion.Value = (object)entity.Tipo_de_Notificacion ?? DBNull.Value;
		var paramUpdTipo_de_Accion = _dataProvider.GetParameter();
                paramUpdTipo_de_Accion.ParameterName = "Tipo_de_Accion";
                paramUpdTipo_de_Accion.DbType = DbType.Int32;
                paramUpdTipo_de_Accion.Value = (object)entity.Tipo_de_Accion ?? DBNull.Value;
		var paramUpdTipo_de_Recordatorio = _dataProvider.GetParameter();
                paramUpdTipo_de_Recordatorio.ParameterName = "Tipo_de_Recordatorio";
                paramUpdTipo_de_Recordatorio.DbType = DbType.Int32;
                paramUpdTipo_de_Recordatorio.Value = (object)entity.Tipo_de_Recordatorio ?? DBNull.Value;
                var paramUpdFecha_inicio = _dataProvider.GetParameter();
                paramUpdFecha_inicio.ParameterName = "Fecha_inicio";
                paramUpdFecha_inicio.DbType = DbType.DateTime;
                paramUpdFecha_inicio.Value = (object)entity.Fecha_inicio ?? DBNull.Value;
                var paramUpdTiene_fecha_de_finalizacion_definida = _dataProvider.GetParameter();
                paramUpdTiene_fecha_de_finalizacion_definida.ParameterName = "Tiene_fecha_de_finalizacion_definida";
                paramUpdTiene_fecha_de_finalizacion_definida.DbType = DbType.Boolean;
                paramUpdTiene_fecha_de_finalizacion_definida.Value = (object)entity.Tiene_fecha_de_finalizacion_definida ?? DBNull.Value;
                var paramUpdCantidad_de_dias_a_validar = _dataProvider.GetParameter();
                paramUpdCantidad_de_dias_a_validar.ParameterName = "Cantidad_de_dias_a_validar";
                paramUpdCantidad_de_dias_a_validar.DbType = DbType.Int32;
                paramUpdCantidad_de_dias_a_validar.Value = (object)entity.Cantidad_de_dias_a_validar ?? DBNull.Value;
		var paramUpdFecha_a_validar = _dataProvider.GetParameter();
                paramUpdFecha_a_validar.ParameterName = "Fecha_a_validar";
                paramUpdFecha_a_validar.DbType = DbType.Int32;
                paramUpdFecha_a_validar.Value = (object)entity.Fecha_a_validar ?? DBNull.Value;
                var paramUpdFecha_fin = _dataProvider.GetParameter();
                paramUpdFecha_fin.ParameterName = "Fecha_fin";
                paramUpdFecha_fin.DbType = DbType.DateTime;
                paramUpdFecha_fin.Value = (object)entity.Fecha_fin ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;
                var paramUpdNotificar_por_correo = _dataProvider.GetParameter();
                paramUpdNotificar_por_correo.ParameterName = "Notificar_por_correo";
                paramUpdNotificar_por_correo.DbType = DbType.Boolean;
                paramUpdNotificar_por_correo.Value = (object)entity.Notificar_por_correo ?? DBNull.Value;
                var paramUpdTexto_que_llevara_el_correo = _dataProvider.GetParameter();
                paramUpdTexto_que_llevara_el_correo.ParameterName = "Texto_que_llevara_el_correo";
                paramUpdTexto_que_llevara_el_correo.DbType = DbType.String;
                paramUpdTexto_que_llevara_el_correo.Value = (object)entity.Texto_que_llevara_el_correo ?? DBNull.Value;
                var paramUpdNotificacion_push = _dataProvider.GetParameter();
                paramUpdNotificacion_push.ParameterName = "Notificacion_push";
                paramUpdNotificacion_push.DbType = DbType.Boolean;
                paramUpdNotificacion_push.Value = (object)entity.Notificacion_push ?? DBNull.Value;
                var paramUpdTexto_a_mostrar_en_la_notificacion_Push = _dataProvider.GetParameter();
                paramUpdTexto_a_mostrar_en_la_notificacion_Push.ParameterName = "Texto_a_mostrar_en_la_notificacion_Push";
                paramUpdTexto_a_mostrar_en_la_notificacion_Push.DbType = DbType.String;
                paramUpdTexto_a_mostrar_en_la_notificacion_Push.Value = (object)entity.Texto_a_mostrar_en_la_notificacion_Push ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdConfiguracion_de_Notificaciones>("sp_UpdConfiguracion_de_Notificaciones" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombre_de_la_Notificacion , paramUpdEs_permanente , paramUpdFuncionalidad , paramUpdTipo_de_Notificacion , paramUpdTipo_de_Accion , paramUpdTipo_de_Recordatorio , paramUpdFecha_inicio , paramUpdTiene_fecha_de_finalizacion_definida , paramUpdCantidad_de_dias_a_validar , paramUpdFecha_a_validar , paramUpdFecha_fin , paramUpdEstatus , paramUpdNotificar_por_correo , paramUpdTexto_que_llevara_el_correo , paramUpdNotificacion_push , paramUpdTexto_a_mostrar_en_la_notificacion_Push ).FirstOrDefault();

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

