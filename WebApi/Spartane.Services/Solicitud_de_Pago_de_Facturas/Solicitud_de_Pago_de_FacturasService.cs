using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Solicitud_de_Pago_de_Facturas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Solicitud_de_Pago_de_FacturasService : ISolicitud_de_Pago_de_FacturasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> _Solicitud_de_Pago_de_FacturasRepository;
        #endregion

        #region Ctor
        public Solicitud_de_Pago_de_FacturasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> Solicitud_de_Pago_de_FacturasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Solicitud_de_Pago_de_FacturasRepository = Solicitud_de_Pago_de_FacturasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Solicitud_de_Pago_de_FacturasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>("sp_SelAllSolicitud_de_Pago_de_Facturas");
        }

        public IList<Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSolicitud_de_Pago_de_Facturas_Complete>("sp_SelAllComplete_Solicitud_de_Pago_de_Facturas");
            return data.Select(m => new Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Mes_Facturado_Meses = new Core.Classes.Meses.Meses() { Clave = m.Mes_Facturado.GetValueOrDefault(), Nombre = m.Mes_Facturado_Nombre }
                ,Fecha_inicio_del_periodo_facturado = m.Fecha_inicio_del_periodo_facturado
                ,Fecha_fin_del_periodo_facturado = m.Fecha_fin_del_periodo_facturado
                ,Archivo_XML = m.Archivo_XML
                ,Archivo_PDF = m.Archivo_PDF
                ,Recibo_de_Solicitud_de_Pago = m.Recibo_de_Solicitud_de_Pago
                ,Total = m.Total
                ,Estatus_Estatus_Facturas = new Core.Classes.Estatus_Facturas.Estatus_Facturas() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }
                ,Fecha_de_autorizacion = m.Fecha_de_autorizacion
                ,Hora_de_autorizacion = m.Hora_de_autorizacion
                ,Usuario_que_autoriza_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_autoriza.GetValueOrDefault(), Name = m.Usuario_que_autoriza_Name }
                ,Resultado_de_la_Revision_Resultados_de_Revision = new Core.Classes.Resultados_de_Revision.Resultados_de_Revision() { Folio = m.Resultado_de_la_Revision.GetValueOrDefault(), Nombre = m.Resultado_de_la_Revision_Nombre }
                ,Observaciones = m.Observaciones
                ,Fecha_de_programacion = m.Fecha_de_programacion
                ,Hora_de_programacion = m.Hora_de_programacion
                ,Usuario_que_programa_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_programa.GetValueOrDefault(), Name = m.Usuario_que_programa_Name }
                ,Fecha_programada_de_Pago = m.Fecha_programada_de_Pago
                ,Estatus_de_Pago_Estatus_de_Pago_de_Facturas = new Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas() { Folio = m.Estatus_de_Pago.GetValueOrDefault(), Nombre = m.Estatus_de_Pago_Nombre }
                ,Fecha_de_actualizacion = m.Fecha_de_actualizacion
                ,Hora_de_actualizacion = m.Hora_de_actualizacion
                ,Usuario_que_actualiza_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_actualiza.GetValueOrDefault(), Name = m.Usuario_que_actualiza_Name }
                ,Fecha_de_Pago = m.Fecha_de_Pago


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Solicitud_de_Pago_de_Facturas>("sp_ListSelCount_Solicitud_de_Pago_de_Facturas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSolicitud_de_Pago_de_Facturas>("sp_ListSelAll_Solicitud_de_Pago_de_Facturas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas
                {
                    Folio = m.Solicitud_de_Pago_de_Facturas_Folio,
                    Fecha_de_Registro = m.Solicitud_de_Pago_de_Facturas_Fecha_de_Registro,
                    Hora_de_Registro = m.Solicitud_de_Pago_de_Facturas_Hora_de_Registro,
                    Usuario_que_Registra = m.Solicitud_de_Pago_de_Facturas_Usuario_que_Registra,
                    Mes_Facturado = m.Solicitud_de_Pago_de_Facturas_Mes_Facturado,
                    Fecha_inicio_del_periodo_facturado = m.Solicitud_de_Pago_de_Facturas_Fecha_inicio_del_periodo_facturado,
                    Fecha_fin_del_periodo_facturado = m.Solicitud_de_Pago_de_Facturas_Fecha_fin_del_periodo_facturado,
                    Archivo_XML = m.Solicitud_de_Pago_de_Facturas_Archivo_XML,
                    Archivo_PDF = m.Solicitud_de_Pago_de_Facturas_Archivo_PDF,
                    Recibo_de_Solicitud_de_Pago = m.Solicitud_de_Pago_de_Facturas_Recibo_de_Solicitud_de_Pago,
                    Total = m.Solicitud_de_Pago_de_Facturas_Total,
                    Estatus = m.Solicitud_de_Pago_de_Facturas_Estatus,
                    Fecha_de_autorizacion = m.Solicitud_de_Pago_de_Facturas_Fecha_de_autorizacion,
                    Hora_de_autorizacion = m.Solicitud_de_Pago_de_Facturas_Hora_de_autorizacion,
                    Usuario_que_autoriza = m.Solicitud_de_Pago_de_Facturas_Usuario_que_autoriza,
                    Resultado_de_la_Revision = m.Solicitud_de_Pago_de_Facturas_Resultado_de_la_Revision,
                    Observaciones = m.Solicitud_de_Pago_de_Facturas_Observaciones,
                    Fecha_de_programacion = m.Solicitud_de_Pago_de_Facturas_Fecha_de_programacion,
                    Hora_de_programacion = m.Solicitud_de_Pago_de_Facturas_Hora_de_programacion,
                    Usuario_que_programa = m.Solicitud_de_Pago_de_Facturas_Usuario_que_programa,
                    Fecha_programada_de_Pago = m.Solicitud_de_Pago_de_Facturas_Fecha_programada_de_Pago,
                    Estatus_de_Pago = m.Solicitud_de_Pago_de_Facturas_Estatus_de_Pago,
                    Fecha_de_actualizacion = m.Solicitud_de_Pago_de_Facturas_Fecha_de_actualizacion,
                    Hora_de_actualizacion = m.Solicitud_de_Pago_de_Facturas_Hora_de_actualizacion,
                    Usuario_que_actualiza = m.Solicitud_de_Pago_de_Facturas_Usuario_que_actualiza,
                    Fecha_de_Pago = m.Solicitud_de_Pago_de_Facturas_Fecha_de_Pago,

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

        public IList<Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Solicitud_de_Pago_de_FacturasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Solicitud_de_Pago_de_FacturasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_FacturasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSolicitud_de_Pago_de_Facturas>("sp_ListSelAll_Solicitud_de_Pago_de_Facturas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Solicitud_de_Pago_de_FacturasPagingModel result = null;

            if (data != null)
            {
                result = new Solicitud_de_Pago_de_FacturasPagingModel
                {
                    Solicitud_de_Pago_de_Facturass =
                        data.Select(m => new Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas
                {
                    Folio = m.Solicitud_de_Pago_de_Facturas_Folio
                    ,Fecha_de_Registro = m.Solicitud_de_Pago_de_Facturas_Fecha_de_Registro
                    ,Hora_de_Registro = m.Solicitud_de_Pago_de_Facturas_Hora_de_Registro
                    ,Usuario_que_Registra = m.Solicitud_de_Pago_de_Facturas_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Solicitud_de_Pago_de_Facturas_Usuario_que_Registra.GetValueOrDefault(), Name = m.Solicitud_de_Pago_de_Facturas_Usuario_que_Registra_Name }
                    ,Mes_Facturado = m.Solicitud_de_Pago_de_Facturas_Mes_Facturado
                    ,Mes_Facturado_Meses = new Core.Classes.Meses.Meses() { Clave = m.Solicitud_de_Pago_de_Facturas_Mes_Facturado.GetValueOrDefault(), Nombre = m.Solicitud_de_Pago_de_Facturas_Mes_Facturado_Nombre }
                    ,Fecha_inicio_del_periodo_facturado = m.Solicitud_de_Pago_de_Facturas_Fecha_inicio_del_periodo_facturado
                    ,Fecha_fin_del_periodo_facturado = m.Solicitud_de_Pago_de_Facturas_Fecha_fin_del_periodo_facturado
                    ,Archivo_XML = m.Solicitud_de_Pago_de_Facturas_Archivo_XML
                    ,Archivo_PDF = m.Solicitud_de_Pago_de_Facturas_Archivo_PDF
                    ,Recibo_de_Solicitud_de_Pago = m.Solicitud_de_Pago_de_Facturas_Recibo_de_Solicitud_de_Pago
                    ,Total = m.Solicitud_de_Pago_de_Facturas_Total
                    ,Estatus = m.Solicitud_de_Pago_de_Facturas_Estatus
                    ,Estatus_Estatus_Facturas = new Core.Classes.Estatus_Facturas.Estatus_Facturas() { Clave = m.Solicitud_de_Pago_de_Facturas_Estatus.GetValueOrDefault(), Descripcion = m.Solicitud_de_Pago_de_Facturas_Estatus_Descripcion }
                    ,Fecha_de_autorizacion = m.Solicitud_de_Pago_de_Facturas_Fecha_de_autorizacion
                    ,Hora_de_autorizacion = m.Solicitud_de_Pago_de_Facturas_Hora_de_autorizacion
                    ,Usuario_que_autoriza = m.Solicitud_de_Pago_de_Facturas_Usuario_que_autoriza
                    ,Usuario_que_autoriza_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Solicitud_de_Pago_de_Facturas_Usuario_que_autoriza.GetValueOrDefault(), Name = m.Solicitud_de_Pago_de_Facturas_Usuario_que_autoriza_Name }
                    ,Resultado_de_la_Revision = m.Solicitud_de_Pago_de_Facturas_Resultado_de_la_Revision
                    ,Resultado_de_la_Revision_Resultados_de_Revision = new Core.Classes.Resultados_de_Revision.Resultados_de_Revision() { Folio = m.Solicitud_de_Pago_de_Facturas_Resultado_de_la_Revision.GetValueOrDefault(), Nombre = m.Solicitud_de_Pago_de_Facturas_Resultado_de_la_Revision_Nombre }
                    ,Observaciones = m.Solicitud_de_Pago_de_Facturas_Observaciones
                    ,Fecha_de_programacion = m.Solicitud_de_Pago_de_Facturas_Fecha_de_programacion
                    ,Hora_de_programacion = m.Solicitud_de_Pago_de_Facturas_Hora_de_programacion
                    ,Usuario_que_programa = m.Solicitud_de_Pago_de_Facturas_Usuario_que_programa
                    ,Usuario_que_programa_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Solicitud_de_Pago_de_Facturas_Usuario_que_programa.GetValueOrDefault(), Name = m.Solicitud_de_Pago_de_Facturas_Usuario_que_programa_Name }
                    ,Fecha_programada_de_Pago = m.Solicitud_de_Pago_de_Facturas_Fecha_programada_de_Pago
                    ,Estatus_de_Pago = m.Solicitud_de_Pago_de_Facturas_Estatus_de_Pago
                    ,Estatus_de_Pago_Estatus_de_Pago_de_Facturas = new Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas() { Folio = m.Solicitud_de_Pago_de_Facturas_Estatus_de_Pago.GetValueOrDefault(), Nombre = m.Solicitud_de_Pago_de_Facturas_Estatus_de_Pago_Nombre }
                    ,Fecha_de_actualizacion = m.Solicitud_de_Pago_de_Facturas_Fecha_de_actualizacion
                    ,Hora_de_actualizacion = m.Solicitud_de_Pago_de_Facturas_Hora_de_actualizacion
                    ,Usuario_que_actualiza = m.Solicitud_de_Pago_de_Facturas_Usuario_que_actualiza
                    ,Usuario_que_actualiza_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Solicitud_de_Pago_de_Facturas_Usuario_que_actualiza.GetValueOrDefault(), Name = m.Solicitud_de_Pago_de_Facturas_Usuario_que_actualiza_Name }
                    ,Fecha_de_Pago = m.Solicitud_de_Pago_de_Facturas_Fecha_de_Pago

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Solicitud_de_Pago_de_FacturasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas>("sp_GetSolicitud_de_Pago_de_Facturas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSolicitud_de_Pago_de_Facturas>("sp_DelSolicitud_de_Pago_de_Facturas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity)
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

                var padreMes_Facturado = _dataProvider.GetParameter();
                padreMes_Facturado.ParameterName = "Mes_Facturado";
                padreMes_Facturado.DbType = DbType.Int32;
                padreMes_Facturado.Value = (object)entity.Mes_Facturado ?? DBNull.Value;

                var padreFecha_inicio_del_periodo_facturado = _dataProvider.GetParameter();
                padreFecha_inicio_del_periodo_facturado.ParameterName = "Fecha_inicio_del_periodo_facturado";
                padreFecha_inicio_del_periodo_facturado.DbType = DbType.DateTime;
                padreFecha_inicio_del_periodo_facturado.Value = (object)entity.Fecha_inicio_del_periodo_facturado ?? DBNull.Value;

                var padreFecha_fin_del_periodo_facturado = _dataProvider.GetParameter();
                padreFecha_fin_del_periodo_facturado.ParameterName = "Fecha_fin_del_periodo_facturado";
                padreFecha_fin_del_periodo_facturado.DbType = DbType.DateTime;
                padreFecha_fin_del_periodo_facturado.Value = (object)entity.Fecha_fin_del_periodo_facturado ?? DBNull.Value;

                var padreArchivo_XML = _dataProvider.GetParameter();
                padreArchivo_XML.ParameterName = "Archivo_XML";
                padreArchivo_XML.DbType = DbType.Int32;
                padreArchivo_XML.Value = (object)entity.Archivo_XML ?? DBNull.Value;

                var padreArchivo_PDF = _dataProvider.GetParameter();
                padreArchivo_PDF.ParameterName = "Archivo_PDF";
                padreArchivo_PDF.DbType = DbType.Int32;
                padreArchivo_PDF.Value = (object)entity.Archivo_PDF ?? DBNull.Value;

                var padreRecibo_de_Solicitud_de_Pago = _dataProvider.GetParameter();
                padreRecibo_de_Solicitud_de_Pago.ParameterName = "Recibo_de_Solicitud_de_Pago";
                padreRecibo_de_Solicitud_de_Pago.DbType = DbType.Int32;
                padreRecibo_de_Solicitud_de_Pago.Value = (object)entity.Recibo_de_Solicitud_de_Pago ?? DBNull.Value;

                var padreTotal = _dataProvider.GetParameter();
                padreTotal.ParameterName = "Total";
                padreTotal.DbType = DbType.Decimal;
                padreTotal.Value = (object)entity.Total ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var padreFecha_de_autorizacion = _dataProvider.GetParameter();
                padreFecha_de_autorizacion.ParameterName = "Fecha_de_autorizacion";
                padreFecha_de_autorizacion.DbType = DbType.DateTime;
                padreFecha_de_autorizacion.Value = (object)entity.Fecha_de_autorizacion ?? DBNull.Value;

                var padreHora_de_autorizacion = _dataProvider.GetParameter();
                padreHora_de_autorizacion.ParameterName = "Hora_de_autorizacion";
                padreHora_de_autorizacion.DbType = DbType.String;
                padreHora_de_autorizacion.Value = (object)entity.Hora_de_autorizacion ?? DBNull.Value;
                var padreUsuario_que_autoriza = _dataProvider.GetParameter();
                padreUsuario_que_autoriza.ParameterName = "Usuario_que_autoriza";
                padreUsuario_que_autoriza.DbType = DbType.Int32;
                padreUsuario_que_autoriza.Value = (object)entity.Usuario_que_autoriza ?? DBNull.Value;

                var padreResultado_de_la_Revision = _dataProvider.GetParameter();
                padreResultado_de_la_Revision.ParameterName = "Resultado_de_la_Revision";
                padreResultado_de_la_Revision.DbType = DbType.Int32;
                padreResultado_de_la_Revision.Value = (object)entity.Resultado_de_la_Revision ?? DBNull.Value;

                var padreObservaciones = _dataProvider.GetParameter();
                padreObservaciones.ParameterName = "Observaciones";
                padreObservaciones.DbType = DbType.String;
                padreObservaciones.Value = (object)entity.Observaciones ?? DBNull.Value;
                var padreFecha_de_programacion = _dataProvider.GetParameter();
                padreFecha_de_programacion.ParameterName = "Fecha_de_programacion";
                padreFecha_de_programacion.DbType = DbType.DateTime;
                padreFecha_de_programacion.Value = (object)entity.Fecha_de_programacion ?? DBNull.Value;

                var padreHora_de_programacion = _dataProvider.GetParameter();
                padreHora_de_programacion.ParameterName = "Hora_de_programacion";
                padreHora_de_programacion.DbType = DbType.String;
                padreHora_de_programacion.Value = (object)entity.Hora_de_programacion ?? DBNull.Value;
                var padreUsuario_que_programa = _dataProvider.GetParameter();
                padreUsuario_que_programa.ParameterName = "Usuario_que_programa";
                padreUsuario_que_programa.DbType = DbType.Int32;
                padreUsuario_que_programa.Value = (object)entity.Usuario_que_programa ?? DBNull.Value;

                var padreFecha_programada_de_Pago = _dataProvider.GetParameter();
                padreFecha_programada_de_Pago.ParameterName = "Fecha_programada_de_Pago";
                padreFecha_programada_de_Pago.DbType = DbType.DateTime;
                padreFecha_programada_de_Pago.Value = (object)entity.Fecha_programada_de_Pago ?? DBNull.Value;

                var padreEstatus_de_Pago = _dataProvider.GetParameter();
                padreEstatus_de_Pago.ParameterName = "Estatus_de_Pago";
                padreEstatus_de_Pago.DbType = DbType.Int32;
                padreEstatus_de_Pago.Value = (object)entity.Estatus_de_Pago ?? DBNull.Value;

                var padreFecha_de_actualizacion = _dataProvider.GetParameter();
                padreFecha_de_actualizacion.ParameterName = "Fecha_de_actualizacion";
                padreFecha_de_actualizacion.DbType = DbType.DateTime;
                padreFecha_de_actualizacion.Value = (object)entity.Fecha_de_actualizacion ?? DBNull.Value;

                var padreHora_de_actualizacion = _dataProvider.GetParameter();
                padreHora_de_actualizacion.ParameterName = "Hora_de_actualizacion";
                padreHora_de_actualizacion.DbType = DbType.String;
                padreHora_de_actualizacion.Value = (object)entity.Hora_de_actualizacion ?? DBNull.Value;
                var padreUsuario_que_actualiza = _dataProvider.GetParameter();
                padreUsuario_que_actualiza.ParameterName = "Usuario_que_actualiza";
                padreUsuario_que_actualiza.DbType = DbType.Int32;
                padreUsuario_que_actualiza.Value = (object)entity.Usuario_que_actualiza ?? DBNull.Value;

                var padreFecha_de_Pago = _dataProvider.GetParameter();
                padreFecha_de_Pago.ParameterName = "Fecha_de_Pago";
                padreFecha_de_Pago.DbType = DbType.DateTime;
                padreFecha_de_Pago.Value = (object)entity.Fecha_de_Pago ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSolicitud_de_Pago_de_Facturas>("sp_InsSolicitud_de_Pago_de_Facturas" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreMes_Facturado
, padreFecha_inicio_del_periodo_facturado
, padreFecha_fin_del_periodo_facturado
, padreArchivo_XML
, padreArchivo_PDF
, padreRecibo_de_Solicitud_de_Pago
, padreTotal
, padreEstatus
, padreFecha_de_autorizacion
, padreHora_de_autorizacion
, padreUsuario_que_autoriza
, padreResultado_de_la_Revision
, padreObservaciones
, padreFecha_de_programacion
, padreHora_de_programacion
, padreUsuario_que_programa
, padreFecha_programada_de_Pago
, padreEstatus_de_Pago
, padreFecha_de_actualizacion
, padreHora_de_actualizacion
, padreUsuario_que_actualiza
, padreFecha_de_Pago
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

        public int Update(Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity)
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

                var paramUpdMes_Facturado = _dataProvider.GetParameter();
                paramUpdMes_Facturado.ParameterName = "Mes_Facturado";
                paramUpdMes_Facturado.DbType = DbType.Int32;
                paramUpdMes_Facturado.Value = (object)entity.Mes_Facturado ?? DBNull.Value;

                var paramUpdFecha_inicio_del_periodo_facturado = _dataProvider.GetParameter();
                paramUpdFecha_inicio_del_periodo_facturado.ParameterName = "Fecha_inicio_del_periodo_facturado";
                paramUpdFecha_inicio_del_periodo_facturado.DbType = DbType.DateTime;
                paramUpdFecha_inicio_del_periodo_facturado.Value = (object)entity.Fecha_inicio_del_periodo_facturado ?? DBNull.Value;

                var paramUpdFecha_fin_del_periodo_facturado = _dataProvider.GetParameter();
                paramUpdFecha_fin_del_periodo_facturado.ParameterName = "Fecha_fin_del_periodo_facturado";
                paramUpdFecha_fin_del_periodo_facturado.DbType = DbType.DateTime;
                paramUpdFecha_fin_del_periodo_facturado.Value = (object)entity.Fecha_fin_del_periodo_facturado ?? DBNull.Value;

                var paramUpdArchivo_XML = _dataProvider.GetParameter();
                paramUpdArchivo_XML.ParameterName = "Archivo_XML";
                paramUpdArchivo_XML.DbType = DbType.Int32;
                paramUpdArchivo_XML.Value = (object)entity.Archivo_XML ?? DBNull.Value;

                var paramUpdArchivo_PDF = _dataProvider.GetParameter();
                paramUpdArchivo_PDF.ParameterName = "Archivo_PDF";
                paramUpdArchivo_PDF.DbType = DbType.Int32;
                paramUpdArchivo_PDF.Value = (object)entity.Archivo_PDF ?? DBNull.Value;

                var paramUpdRecibo_de_Solicitud_de_Pago = _dataProvider.GetParameter();
                paramUpdRecibo_de_Solicitud_de_Pago.ParameterName = "Recibo_de_Solicitud_de_Pago";
                paramUpdRecibo_de_Solicitud_de_Pago.DbType = DbType.Int32;
                paramUpdRecibo_de_Solicitud_de_Pago.Value = (object)entity.Recibo_de_Solicitud_de_Pago ?? DBNull.Value;

                var paramUpdTotal = _dataProvider.GetParameter();
                paramUpdTotal.ParameterName = "Total";
                paramUpdTotal.DbType = DbType.Decimal;
                paramUpdTotal.Value = (object)entity.Total ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var paramUpdFecha_de_autorizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_autorizacion.ParameterName = "Fecha_de_autorizacion";
                paramUpdFecha_de_autorizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_autorizacion.Value = (object)entity.Fecha_de_autorizacion ?? DBNull.Value;

                var paramUpdHora_de_autorizacion = _dataProvider.GetParameter();
                paramUpdHora_de_autorizacion.ParameterName = "Hora_de_autorizacion";
                paramUpdHora_de_autorizacion.DbType = DbType.String;
                paramUpdHora_de_autorizacion.Value = (object)entity.Hora_de_autorizacion ?? DBNull.Value;
                var paramUpdUsuario_que_autoriza = _dataProvider.GetParameter();
                paramUpdUsuario_que_autoriza.ParameterName = "Usuario_que_autoriza";
                paramUpdUsuario_que_autoriza.DbType = DbType.Int32;
                paramUpdUsuario_que_autoriza.Value = (object)entity.Usuario_que_autoriza ?? DBNull.Value;

                var paramUpdResultado_de_la_Revision = _dataProvider.GetParameter();
                paramUpdResultado_de_la_Revision.ParameterName = "Resultado_de_la_Revision";
                paramUpdResultado_de_la_Revision.DbType = DbType.Int32;
                paramUpdResultado_de_la_Revision.Value = (object)entity.Resultado_de_la_Revision ?? DBNull.Value;

                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)entity.Observaciones ?? DBNull.Value;
                var paramUpdFecha_de_programacion = _dataProvider.GetParameter();
                paramUpdFecha_de_programacion.ParameterName = "Fecha_de_programacion";
                paramUpdFecha_de_programacion.DbType = DbType.DateTime;
                paramUpdFecha_de_programacion.Value = (object)entity.Fecha_de_programacion ?? DBNull.Value;

                var paramUpdHora_de_programacion = _dataProvider.GetParameter();
                paramUpdHora_de_programacion.ParameterName = "Hora_de_programacion";
                paramUpdHora_de_programacion.DbType = DbType.String;
                paramUpdHora_de_programacion.Value = (object)entity.Hora_de_programacion ?? DBNull.Value;
                var paramUpdUsuario_que_programa = _dataProvider.GetParameter();
                paramUpdUsuario_que_programa.ParameterName = "Usuario_que_programa";
                paramUpdUsuario_que_programa.DbType = DbType.Int32;
                paramUpdUsuario_que_programa.Value = (object)entity.Usuario_que_programa ?? DBNull.Value;

                var paramUpdFecha_programada_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_programada_de_Pago.ParameterName = "Fecha_programada_de_Pago";
                paramUpdFecha_programada_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_programada_de_Pago.Value = (object)entity.Fecha_programada_de_Pago ?? DBNull.Value;

                var paramUpdEstatus_de_Pago = _dataProvider.GetParameter();
                paramUpdEstatus_de_Pago.ParameterName = "Estatus_de_Pago";
                paramUpdEstatus_de_Pago.DbType = DbType.Int32;
                paramUpdEstatus_de_Pago.Value = (object)entity.Estatus_de_Pago ?? DBNull.Value;

                var paramUpdFecha_de_actualizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_actualizacion.ParameterName = "Fecha_de_actualizacion";
                paramUpdFecha_de_actualizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_actualizacion.Value = (object)entity.Fecha_de_actualizacion ?? DBNull.Value;

                var paramUpdHora_de_actualizacion = _dataProvider.GetParameter();
                paramUpdHora_de_actualizacion.ParameterName = "Hora_de_actualizacion";
                paramUpdHora_de_actualizacion.DbType = DbType.String;
                paramUpdHora_de_actualizacion.Value = (object)entity.Hora_de_actualizacion ?? DBNull.Value;
                var paramUpdUsuario_que_actualiza = _dataProvider.GetParameter();
                paramUpdUsuario_que_actualiza.ParameterName = "Usuario_que_actualiza";
                paramUpdUsuario_que_actualiza.DbType = DbType.Int32;
                paramUpdUsuario_que_actualiza.Value = (object)entity.Usuario_que_actualiza ?? DBNull.Value;

                var paramUpdFecha_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_de_Pago.ParameterName = "Fecha_de_Pago";
                paramUpdFecha_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_de_Pago.Value = (object)entity.Fecha_de_Pago ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSolicitud_de_Pago_de_Facturas>("sp_UpdSolicitud_de_Pago_de_Facturas" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdMes_Facturado , paramUpdFecha_inicio_del_periodo_facturado , paramUpdFecha_fin_del_periodo_facturado , paramUpdArchivo_XML , paramUpdArchivo_PDF , paramUpdRecibo_de_Solicitud_de_Pago , paramUpdTotal , paramUpdEstatus , paramUpdFecha_de_autorizacion , paramUpdHora_de_autorizacion , paramUpdUsuario_que_autoriza , paramUpdResultado_de_la_Revision , paramUpdObservaciones , paramUpdFecha_de_programacion , paramUpdHora_de_programacion , paramUpdUsuario_que_programa , paramUpdFecha_programada_de_Pago , paramUpdEstatus_de_Pago , paramUpdFecha_de_actualizacion , paramUpdHora_de_actualizacion , paramUpdUsuario_que_actualiza , paramUpdFecha_de_Pago ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas Solicitud_de_Pago_de_FacturasDB = GetByKey(entity.Folio, false);
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
		var paramUpdMes_Facturado = _dataProvider.GetParameter();
                paramUpdMes_Facturado.ParameterName = "Mes_Facturado";
                paramUpdMes_Facturado.DbType = DbType.Int32;
                paramUpdMes_Facturado.Value = (object)entity.Mes_Facturado ?? DBNull.Value;
                var paramUpdFecha_inicio_del_periodo_facturado = _dataProvider.GetParameter();
                paramUpdFecha_inicio_del_periodo_facturado.ParameterName = "Fecha_inicio_del_periodo_facturado";
                paramUpdFecha_inicio_del_periodo_facturado.DbType = DbType.DateTime;
                paramUpdFecha_inicio_del_periodo_facturado.Value = (object)entity.Fecha_inicio_del_periodo_facturado ?? DBNull.Value;
                var paramUpdFecha_fin_del_periodo_facturado = _dataProvider.GetParameter();
                paramUpdFecha_fin_del_periodo_facturado.ParameterName = "Fecha_fin_del_periodo_facturado";
                paramUpdFecha_fin_del_periodo_facturado.DbType = DbType.DateTime;
                paramUpdFecha_fin_del_periodo_facturado.Value = (object)entity.Fecha_fin_del_periodo_facturado ?? DBNull.Value;
                var paramUpdArchivo_XML = _dataProvider.GetParameter();
                paramUpdArchivo_XML.ParameterName = "Archivo_XML";
                paramUpdArchivo_XML.DbType = DbType.Int32;
                paramUpdArchivo_XML.Value = (object)entity.Archivo_XML ?? DBNull.Value;
                var paramUpdArchivo_PDF = _dataProvider.GetParameter();
                paramUpdArchivo_PDF.ParameterName = "Archivo_PDF";
                paramUpdArchivo_PDF.DbType = DbType.Int32;
                paramUpdArchivo_PDF.Value = (object)entity.Archivo_PDF ?? DBNull.Value;
                var paramUpdRecibo_de_Solicitud_de_Pago = _dataProvider.GetParameter();
                paramUpdRecibo_de_Solicitud_de_Pago.ParameterName = "Recibo_de_Solicitud_de_Pago";
                paramUpdRecibo_de_Solicitud_de_Pago.DbType = DbType.Int32;
                paramUpdRecibo_de_Solicitud_de_Pago.Value = (object)entity.Recibo_de_Solicitud_de_Pago ?? DBNull.Value;
                var paramUpdTotal = _dataProvider.GetParameter();
                paramUpdTotal.ParameterName = "Total";
                paramUpdTotal.DbType = DbType.Decimal;
                paramUpdTotal.Value = (object)entity.Total ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;
                var paramUpdFecha_de_autorizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_autorizacion.ParameterName = "Fecha_de_autorizacion";
                paramUpdFecha_de_autorizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_autorizacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_de_autorizacion ?? DBNull.Value;
                var paramUpdHora_de_autorizacion = _dataProvider.GetParameter();
                paramUpdHora_de_autorizacion.ParameterName = "Hora_de_autorizacion";
                paramUpdHora_de_autorizacion.DbType = DbType.String;
                paramUpdHora_de_autorizacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Hora_de_autorizacion ?? DBNull.Value;
		var paramUpdUsuario_que_autoriza = _dataProvider.GetParameter();
                paramUpdUsuario_que_autoriza.ParameterName = "Usuario_que_autoriza";
                paramUpdUsuario_que_autoriza.DbType = DbType.Int32;
                paramUpdUsuario_que_autoriza.Value = (object)Solicitud_de_Pago_de_FacturasDB.Usuario_que_autoriza ?? DBNull.Value;
		var paramUpdResultado_de_la_Revision = _dataProvider.GetParameter();
                paramUpdResultado_de_la_Revision.ParameterName = "Resultado_de_la_Revision";
                paramUpdResultado_de_la_Revision.DbType = DbType.Int32;
                paramUpdResultado_de_la_Revision.Value = (object)Solicitud_de_Pago_de_FacturasDB.Resultado_de_la_Revision ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)Solicitud_de_Pago_de_FacturasDB.Observaciones ?? DBNull.Value;
                var paramUpdFecha_de_programacion = _dataProvider.GetParameter();
                paramUpdFecha_de_programacion.ParameterName = "Fecha_de_programacion";
                paramUpdFecha_de_programacion.DbType = DbType.DateTime;
                paramUpdFecha_de_programacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_de_programacion ?? DBNull.Value;
                var paramUpdHora_de_programacion = _dataProvider.GetParameter();
                paramUpdHora_de_programacion.ParameterName = "Hora_de_programacion";
                paramUpdHora_de_programacion.DbType = DbType.String;
                paramUpdHora_de_programacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Hora_de_programacion ?? DBNull.Value;
		var paramUpdUsuario_que_programa = _dataProvider.GetParameter();
                paramUpdUsuario_que_programa.ParameterName = "Usuario_que_programa";
                paramUpdUsuario_que_programa.DbType = DbType.Int32;
                paramUpdUsuario_que_programa.Value = (object)Solicitud_de_Pago_de_FacturasDB.Usuario_que_programa ?? DBNull.Value;
                var paramUpdFecha_programada_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_programada_de_Pago.ParameterName = "Fecha_programada_de_Pago";
                paramUpdFecha_programada_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_programada_de_Pago.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_programada_de_Pago ?? DBNull.Value;
		var paramUpdEstatus_de_Pago = _dataProvider.GetParameter();
                paramUpdEstatus_de_Pago.ParameterName = "Estatus_de_Pago";
                paramUpdEstatus_de_Pago.DbType = DbType.Int32;
                paramUpdEstatus_de_Pago.Value = (object)Solicitud_de_Pago_de_FacturasDB.Estatus_de_Pago ?? DBNull.Value;
                var paramUpdFecha_de_actualizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_actualizacion.ParameterName = "Fecha_de_actualizacion";
                paramUpdFecha_de_actualizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_actualizacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_de_actualizacion ?? DBNull.Value;
                var paramUpdHora_de_actualizacion = _dataProvider.GetParameter();
                paramUpdHora_de_actualizacion.ParameterName = "Hora_de_actualizacion";
                paramUpdHora_de_actualizacion.DbType = DbType.String;
                paramUpdHora_de_actualizacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Hora_de_actualizacion ?? DBNull.Value;
		var paramUpdUsuario_que_actualiza = _dataProvider.GetParameter();
                paramUpdUsuario_que_actualiza.ParameterName = "Usuario_que_actualiza";
                paramUpdUsuario_que_actualiza.DbType = DbType.Int32;
                paramUpdUsuario_que_actualiza.Value = (object)Solicitud_de_Pago_de_FacturasDB.Usuario_que_actualiza ?? DBNull.Value;
                var paramUpdFecha_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_de_Pago.ParameterName = "Fecha_de_Pago";
                paramUpdFecha_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_de_Pago.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_de_Pago ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSolicitud_de_Pago_de_Facturas>("sp_UpdSolicitud_de_Pago_de_Facturas" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdMes_Facturado , paramUpdFecha_inicio_del_periodo_facturado , paramUpdFecha_fin_del_periodo_facturado , paramUpdArchivo_XML , paramUpdArchivo_PDF , paramUpdRecibo_de_Solicitud_de_Pago , paramUpdTotal , paramUpdEstatus , paramUpdFecha_de_autorizacion , paramUpdHora_de_autorizacion , paramUpdUsuario_que_autoriza , paramUpdResultado_de_la_Revision , paramUpdObservaciones , paramUpdFecha_de_programacion , paramUpdHora_de_programacion , paramUpdUsuario_que_programa , paramUpdFecha_programada_de_Pago , paramUpdEstatus_de_Pago , paramUpdFecha_de_actualizacion , paramUpdHora_de_actualizacion , paramUpdUsuario_que_actualiza , paramUpdFecha_de_Pago ).FirstOrDefault();

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

		public int Update_Autorizacion(Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas Solicitud_de_Pago_de_FacturasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)Solicitud_de_Pago_de_FacturasDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)Solicitud_de_Pago_de_FacturasDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)Solicitud_de_Pago_de_FacturasDB.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdMes_Facturado = _dataProvider.GetParameter();
                paramUpdMes_Facturado.ParameterName = "Mes_Facturado";
                paramUpdMes_Facturado.DbType = DbType.Int32;
                paramUpdMes_Facturado.Value = (object)Solicitud_de_Pago_de_FacturasDB.Mes_Facturado ?? DBNull.Value;
                var paramUpdFecha_inicio_del_periodo_facturado = _dataProvider.GetParameter();
                paramUpdFecha_inicio_del_periodo_facturado.ParameterName = "Fecha_inicio_del_periodo_facturado";
                paramUpdFecha_inicio_del_periodo_facturado.DbType = DbType.DateTime;
                paramUpdFecha_inicio_del_periodo_facturado.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_inicio_del_periodo_facturado ?? DBNull.Value;
                var paramUpdFecha_fin_del_periodo_facturado = _dataProvider.GetParameter();
                paramUpdFecha_fin_del_periodo_facturado.ParameterName = "Fecha_fin_del_periodo_facturado";
                paramUpdFecha_fin_del_periodo_facturado.DbType = DbType.DateTime;
                paramUpdFecha_fin_del_periodo_facturado.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_fin_del_periodo_facturado ?? DBNull.Value;
                var paramUpdArchivo_XML = _dataProvider.GetParameter();
                paramUpdArchivo_XML.ParameterName = "Archivo_XML";
                paramUpdArchivo_XML.DbType = DbType.Int32;
                paramUpdArchivo_XML.Value = (object)Solicitud_de_Pago_de_FacturasDB.Archivo_XML ?? DBNull.Value;
                var paramUpdArchivo_PDF = _dataProvider.GetParameter();
                paramUpdArchivo_PDF.ParameterName = "Archivo_PDF";
                paramUpdArchivo_PDF.DbType = DbType.Int32;
                paramUpdArchivo_PDF.Value = (object)Solicitud_de_Pago_de_FacturasDB.Archivo_PDF ?? DBNull.Value;
                var paramUpdRecibo_de_Solicitud_de_Pago = _dataProvider.GetParameter();
                paramUpdRecibo_de_Solicitud_de_Pago.ParameterName = "Recibo_de_Solicitud_de_Pago";
                paramUpdRecibo_de_Solicitud_de_Pago.DbType = DbType.Int32;
                paramUpdRecibo_de_Solicitud_de_Pago.Value = (object)Solicitud_de_Pago_de_FacturasDB.Recibo_de_Solicitud_de_Pago ?? DBNull.Value;
                var paramUpdTotal = _dataProvider.GetParameter();
                paramUpdTotal.ParameterName = "Total";
                paramUpdTotal.DbType = DbType.Decimal;
                paramUpdTotal.Value = (object)Solicitud_de_Pago_de_FacturasDB.Total ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)Solicitud_de_Pago_de_FacturasDB.Estatus ?? DBNull.Value;
                var paramUpdFecha_de_autorizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_autorizacion.ParameterName = "Fecha_de_autorizacion";
                paramUpdFecha_de_autorizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_autorizacion.Value = (object)entity.Fecha_de_autorizacion ?? DBNull.Value;
                var paramUpdHora_de_autorizacion = _dataProvider.GetParameter();
                paramUpdHora_de_autorizacion.ParameterName = "Hora_de_autorizacion";
                paramUpdHora_de_autorizacion.DbType = DbType.String;
                paramUpdHora_de_autorizacion.Value = (object)entity.Hora_de_autorizacion ?? DBNull.Value;
		var paramUpdUsuario_que_autoriza = _dataProvider.GetParameter();
                paramUpdUsuario_que_autoriza.ParameterName = "Usuario_que_autoriza";
                paramUpdUsuario_que_autoriza.DbType = DbType.Int32;
                paramUpdUsuario_que_autoriza.Value = (object)entity.Usuario_que_autoriza ?? DBNull.Value;
		var paramUpdResultado_de_la_Revision = _dataProvider.GetParameter();
                paramUpdResultado_de_la_Revision.ParameterName = "Resultado_de_la_Revision";
                paramUpdResultado_de_la_Revision.DbType = DbType.Int32;
                paramUpdResultado_de_la_Revision.Value = (object)entity.Resultado_de_la_Revision ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)entity.Observaciones ?? DBNull.Value;
                var paramUpdFecha_de_programacion = _dataProvider.GetParameter();
                paramUpdFecha_de_programacion.ParameterName = "Fecha_de_programacion";
                paramUpdFecha_de_programacion.DbType = DbType.DateTime;
                paramUpdFecha_de_programacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_de_programacion ?? DBNull.Value;
                var paramUpdHora_de_programacion = _dataProvider.GetParameter();
                paramUpdHora_de_programacion.ParameterName = "Hora_de_programacion";
                paramUpdHora_de_programacion.DbType = DbType.String;
                paramUpdHora_de_programacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Hora_de_programacion ?? DBNull.Value;
		var paramUpdUsuario_que_programa = _dataProvider.GetParameter();
                paramUpdUsuario_que_programa.ParameterName = "Usuario_que_programa";
                paramUpdUsuario_que_programa.DbType = DbType.Int32;
                paramUpdUsuario_que_programa.Value = (object)Solicitud_de_Pago_de_FacturasDB.Usuario_que_programa ?? DBNull.Value;
                var paramUpdFecha_programada_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_programada_de_Pago.ParameterName = "Fecha_programada_de_Pago";
                paramUpdFecha_programada_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_programada_de_Pago.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_programada_de_Pago ?? DBNull.Value;
		var paramUpdEstatus_de_Pago = _dataProvider.GetParameter();
                paramUpdEstatus_de_Pago.ParameterName = "Estatus_de_Pago";
                paramUpdEstatus_de_Pago.DbType = DbType.Int32;
                paramUpdEstatus_de_Pago.Value = (object)Solicitud_de_Pago_de_FacturasDB.Estatus_de_Pago ?? DBNull.Value;
                var paramUpdFecha_de_actualizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_actualizacion.ParameterName = "Fecha_de_actualizacion";
                paramUpdFecha_de_actualizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_actualizacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_de_actualizacion ?? DBNull.Value;
                var paramUpdHora_de_actualizacion = _dataProvider.GetParameter();
                paramUpdHora_de_actualizacion.ParameterName = "Hora_de_actualizacion";
                paramUpdHora_de_actualizacion.DbType = DbType.String;
                paramUpdHora_de_actualizacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Hora_de_actualizacion ?? DBNull.Value;
		var paramUpdUsuario_que_actualiza = _dataProvider.GetParameter();
                paramUpdUsuario_que_actualiza.ParameterName = "Usuario_que_actualiza";
                paramUpdUsuario_que_actualiza.DbType = DbType.Int32;
                paramUpdUsuario_que_actualiza.Value = (object)Solicitud_de_Pago_de_FacturasDB.Usuario_que_actualiza ?? DBNull.Value;
                var paramUpdFecha_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_de_Pago.ParameterName = "Fecha_de_Pago";
                paramUpdFecha_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_de_Pago.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_de_Pago ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSolicitud_de_Pago_de_Facturas>("sp_UpdSolicitud_de_Pago_de_Facturas" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdMes_Facturado , paramUpdFecha_inicio_del_periodo_facturado , paramUpdFecha_fin_del_periodo_facturado , paramUpdArchivo_XML , paramUpdArchivo_PDF , paramUpdRecibo_de_Solicitud_de_Pago , paramUpdTotal , paramUpdEstatus , paramUpdFecha_de_autorizacion , paramUpdHora_de_autorizacion , paramUpdUsuario_que_autoriza , paramUpdResultado_de_la_Revision , paramUpdObservaciones , paramUpdFecha_de_programacion , paramUpdHora_de_programacion , paramUpdUsuario_que_programa , paramUpdFecha_programada_de_Pago , paramUpdEstatus_de_Pago , paramUpdFecha_de_actualizacion , paramUpdHora_de_actualizacion , paramUpdUsuario_que_actualiza , paramUpdFecha_de_Pago ).FirstOrDefault();

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

		public int Update_Programacion_de_Pago(Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas Solicitud_de_Pago_de_FacturasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)Solicitud_de_Pago_de_FacturasDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)Solicitud_de_Pago_de_FacturasDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)Solicitud_de_Pago_de_FacturasDB.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdMes_Facturado = _dataProvider.GetParameter();
                paramUpdMes_Facturado.ParameterName = "Mes_Facturado";
                paramUpdMes_Facturado.DbType = DbType.Int32;
                paramUpdMes_Facturado.Value = (object)Solicitud_de_Pago_de_FacturasDB.Mes_Facturado ?? DBNull.Value;
                var paramUpdFecha_inicio_del_periodo_facturado = _dataProvider.GetParameter();
                paramUpdFecha_inicio_del_periodo_facturado.ParameterName = "Fecha_inicio_del_periodo_facturado";
                paramUpdFecha_inicio_del_periodo_facturado.DbType = DbType.DateTime;
                paramUpdFecha_inicio_del_periodo_facturado.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_inicio_del_periodo_facturado ?? DBNull.Value;
                var paramUpdFecha_fin_del_periodo_facturado = _dataProvider.GetParameter();
                paramUpdFecha_fin_del_periodo_facturado.ParameterName = "Fecha_fin_del_periodo_facturado";
                paramUpdFecha_fin_del_periodo_facturado.DbType = DbType.DateTime;
                paramUpdFecha_fin_del_periodo_facturado.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_fin_del_periodo_facturado ?? DBNull.Value;
                var paramUpdArchivo_XML = _dataProvider.GetParameter();
                paramUpdArchivo_XML.ParameterName = "Archivo_XML";
                paramUpdArchivo_XML.DbType = DbType.Int32;
                paramUpdArchivo_XML.Value = (object)Solicitud_de_Pago_de_FacturasDB.Archivo_XML ?? DBNull.Value;
                var paramUpdArchivo_PDF = _dataProvider.GetParameter();
                paramUpdArchivo_PDF.ParameterName = "Archivo_PDF";
                paramUpdArchivo_PDF.DbType = DbType.Int32;
                paramUpdArchivo_PDF.Value = (object)Solicitud_de_Pago_de_FacturasDB.Archivo_PDF ?? DBNull.Value;
                var paramUpdRecibo_de_Solicitud_de_Pago = _dataProvider.GetParameter();
                paramUpdRecibo_de_Solicitud_de_Pago.ParameterName = "Recibo_de_Solicitud_de_Pago";
                paramUpdRecibo_de_Solicitud_de_Pago.DbType = DbType.Int32;
                paramUpdRecibo_de_Solicitud_de_Pago.Value = (object)Solicitud_de_Pago_de_FacturasDB.Recibo_de_Solicitud_de_Pago ?? DBNull.Value;
                var paramUpdTotal = _dataProvider.GetParameter();
                paramUpdTotal.ParameterName = "Total";
                paramUpdTotal.DbType = DbType.Decimal;
                paramUpdTotal.Value = (object)Solicitud_de_Pago_de_FacturasDB.Total ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)Solicitud_de_Pago_de_FacturasDB.Estatus ?? DBNull.Value;
                var paramUpdFecha_de_autorizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_autorizacion.ParameterName = "Fecha_de_autorizacion";
                paramUpdFecha_de_autorizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_autorizacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_de_autorizacion ?? DBNull.Value;
                var paramUpdHora_de_autorizacion = _dataProvider.GetParameter();
                paramUpdHora_de_autorizacion.ParameterName = "Hora_de_autorizacion";
                paramUpdHora_de_autorizacion.DbType = DbType.String;
                paramUpdHora_de_autorizacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Hora_de_autorizacion ?? DBNull.Value;
		var paramUpdUsuario_que_autoriza = _dataProvider.GetParameter();
                paramUpdUsuario_que_autoriza.ParameterName = "Usuario_que_autoriza";
                paramUpdUsuario_que_autoriza.DbType = DbType.Int32;
                paramUpdUsuario_que_autoriza.Value = (object)Solicitud_de_Pago_de_FacturasDB.Usuario_que_autoriza ?? DBNull.Value;
		var paramUpdResultado_de_la_Revision = _dataProvider.GetParameter();
                paramUpdResultado_de_la_Revision.ParameterName = "Resultado_de_la_Revision";
                paramUpdResultado_de_la_Revision.DbType = DbType.Int32;
                paramUpdResultado_de_la_Revision.Value = (object)Solicitud_de_Pago_de_FacturasDB.Resultado_de_la_Revision ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)Solicitud_de_Pago_de_FacturasDB.Observaciones ?? DBNull.Value;
                var paramUpdFecha_de_programacion = _dataProvider.GetParameter();
                paramUpdFecha_de_programacion.ParameterName = "Fecha_de_programacion";
                paramUpdFecha_de_programacion.DbType = DbType.DateTime;
                paramUpdFecha_de_programacion.Value = (object)entity.Fecha_de_programacion ?? DBNull.Value;
                var paramUpdHora_de_programacion = _dataProvider.GetParameter();
                paramUpdHora_de_programacion.ParameterName = "Hora_de_programacion";
                paramUpdHora_de_programacion.DbType = DbType.String;
                paramUpdHora_de_programacion.Value = (object)entity.Hora_de_programacion ?? DBNull.Value;
		var paramUpdUsuario_que_programa = _dataProvider.GetParameter();
                paramUpdUsuario_que_programa.ParameterName = "Usuario_que_programa";
                paramUpdUsuario_que_programa.DbType = DbType.Int32;
                paramUpdUsuario_que_programa.Value = (object)entity.Usuario_que_programa ?? DBNull.Value;
                var paramUpdFecha_programada_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_programada_de_Pago.ParameterName = "Fecha_programada_de_Pago";
                paramUpdFecha_programada_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_programada_de_Pago.Value = (object)entity.Fecha_programada_de_Pago ?? DBNull.Value;
		var paramUpdEstatus_de_Pago = _dataProvider.GetParameter();
                paramUpdEstatus_de_Pago.ParameterName = "Estatus_de_Pago";
                paramUpdEstatus_de_Pago.DbType = DbType.Int32;
                paramUpdEstatus_de_Pago.Value = (object)entity.Estatus_de_Pago ?? DBNull.Value;
                var paramUpdFecha_de_actualizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_actualizacion.ParameterName = "Fecha_de_actualizacion";
                paramUpdFecha_de_actualizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_actualizacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_de_actualizacion ?? DBNull.Value;
                var paramUpdHora_de_actualizacion = _dataProvider.GetParameter();
                paramUpdHora_de_actualizacion.ParameterName = "Hora_de_actualizacion";
                paramUpdHora_de_actualizacion.DbType = DbType.String;
                paramUpdHora_de_actualizacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Hora_de_actualizacion ?? DBNull.Value;
		var paramUpdUsuario_que_actualiza = _dataProvider.GetParameter();
                paramUpdUsuario_que_actualiza.ParameterName = "Usuario_que_actualiza";
                paramUpdUsuario_que_actualiza.DbType = DbType.Int32;
                paramUpdUsuario_que_actualiza.Value = (object)Solicitud_de_Pago_de_FacturasDB.Usuario_que_actualiza ?? DBNull.Value;
                var paramUpdFecha_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_de_Pago.ParameterName = "Fecha_de_Pago";
                paramUpdFecha_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_de_Pago.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_de_Pago ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSolicitud_de_Pago_de_Facturas>("sp_UpdSolicitud_de_Pago_de_Facturas" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdMes_Facturado , paramUpdFecha_inicio_del_periodo_facturado , paramUpdFecha_fin_del_periodo_facturado , paramUpdArchivo_XML , paramUpdArchivo_PDF , paramUpdRecibo_de_Solicitud_de_Pago , paramUpdTotal , paramUpdEstatus , paramUpdFecha_de_autorizacion , paramUpdHora_de_autorizacion , paramUpdUsuario_que_autoriza , paramUpdResultado_de_la_Revision , paramUpdObservaciones , paramUpdFecha_de_programacion , paramUpdHora_de_programacion , paramUpdUsuario_que_programa , paramUpdFecha_programada_de_Pago , paramUpdEstatus_de_Pago , paramUpdFecha_de_actualizacion , paramUpdHora_de_actualizacion , paramUpdUsuario_que_actualiza , paramUpdFecha_de_Pago ).FirstOrDefault();

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

		public int Update_Pago(Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Solicitud_de_Pago_de_Facturas.Solicitud_de_Pago_de_Facturas Solicitud_de_Pago_de_FacturasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)Solicitud_de_Pago_de_FacturasDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)Solicitud_de_Pago_de_FacturasDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)Solicitud_de_Pago_de_FacturasDB.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdMes_Facturado = _dataProvider.GetParameter();
                paramUpdMes_Facturado.ParameterName = "Mes_Facturado";
                paramUpdMes_Facturado.DbType = DbType.Int32;
                paramUpdMes_Facturado.Value = (object)Solicitud_de_Pago_de_FacturasDB.Mes_Facturado ?? DBNull.Value;
                var paramUpdFecha_inicio_del_periodo_facturado = _dataProvider.GetParameter();
                paramUpdFecha_inicio_del_periodo_facturado.ParameterName = "Fecha_inicio_del_periodo_facturado";
                paramUpdFecha_inicio_del_periodo_facturado.DbType = DbType.DateTime;
                paramUpdFecha_inicio_del_periodo_facturado.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_inicio_del_periodo_facturado ?? DBNull.Value;
                var paramUpdFecha_fin_del_periodo_facturado = _dataProvider.GetParameter();
                paramUpdFecha_fin_del_periodo_facturado.ParameterName = "Fecha_fin_del_periodo_facturado";
                paramUpdFecha_fin_del_periodo_facturado.DbType = DbType.DateTime;
                paramUpdFecha_fin_del_periodo_facturado.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_fin_del_periodo_facturado ?? DBNull.Value;
                var paramUpdArchivo_XML = _dataProvider.GetParameter();
                paramUpdArchivo_XML.ParameterName = "Archivo_XML";
                paramUpdArchivo_XML.DbType = DbType.Int32;
                paramUpdArchivo_XML.Value = (object)Solicitud_de_Pago_de_FacturasDB.Archivo_XML ?? DBNull.Value;
                var paramUpdArchivo_PDF = _dataProvider.GetParameter();
                paramUpdArchivo_PDF.ParameterName = "Archivo_PDF";
                paramUpdArchivo_PDF.DbType = DbType.Int32;
                paramUpdArchivo_PDF.Value = (object)Solicitud_de_Pago_de_FacturasDB.Archivo_PDF ?? DBNull.Value;
                var paramUpdRecibo_de_Solicitud_de_Pago = _dataProvider.GetParameter();
                paramUpdRecibo_de_Solicitud_de_Pago.ParameterName = "Recibo_de_Solicitud_de_Pago";
                paramUpdRecibo_de_Solicitud_de_Pago.DbType = DbType.Int32;
                paramUpdRecibo_de_Solicitud_de_Pago.Value = (object)Solicitud_de_Pago_de_FacturasDB.Recibo_de_Solicitud_de_Pago ?? DBNull.Value;
                var paramUpdTotal = _dataProvider.GetParameter();
                paramUpdTotal.ParameterName = "Total";
                paramUpdTotal.DbType = DbType.Decimal;
                paramUpdTotal.Value = (object)Solicitud_de_Pago_de_FacturasDB.Total ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)Solicitud_de_Pago_de_FacturasDB.Estatus ?? DBNull.Value;
                var paramUpdFecha_de_autorizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_autorizacion.ParameterName = "Fecha_de_autorizacion";
                paramUpdFecha_de_autorizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_autorizacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_de_autorizacion ?? DBNull.Value;
                var paramUpdHora_de_autorizacion = _dataProvider.GetParameter();
                paramUpdHora_de_autorizacion.ParameterName = "Hora_de_autorizacion";
                paramUpdHora_de_autorizacion.DbType = DbType.String;
                paramUpdHora_de_autorizacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Hora_de_autorizacion ?? DBNull.Value;
		var paramUpdUsuario_que_autoriza = _dataProvider.GetParameter();
                paramUpdUsuario_que_autoriza.ParameterName = "Usuario_que_autoriza";
                paramUpdUsuario_que_autoriza.DbType = DbType.Int32;
                paramUpdUsuario_que_autoriza.Value = (object)Solicitud_de_Pago_de_FacturasDB.Usuario_que_autoriza ?? DBNull.Value;
		var paramUpdResultado_de_la_Revision = _dataProvider.GetParameter();
                paramUpdResultado_de_la_Revision.ParameterName = "Resultado_de_la_Revision";
                paramUpdResultado_de_la_Revision.DbType = DbType.Int32;
                paramUpdResultado_de_la_Revision.Value = (object)Solicitud_de_Pago_de_FacturasDB.Resultado_de_la_Revision ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)Solicitud_de_Pago_de_FacturasDB.Observaciones ?? DBNull.Value;
                var paramUpdFecha_de_programacion = _dataProvider.GetParameter();
                paramUpdFecha_de_programacion.ParameterName = "Fecha_de_programacion";
                paramUpdFecha_de_programacion.DbType = DbType.DateTime;
                paramUpdFecha_de_programacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_de_programacion ?? DBNull.Value;
                var paramUpdHora_de_programacion = _dataProvider.GetParameter();
                paramUpdHora_de_programacion.ParameterName = "Hora_de_programacion";
                paramUpdHora_de_programacion.DbType = DbType.String;
                paramUpdHora_de_programacion.Value = (object)Solicitud_de_Pago_de_FacturasDB.Hora_de_programacion ?? DBNull.Value;
		var paramUpdUsuario_que_programa = _dataProvider.GetParameter();
                paramUpdUsuario_que_programa.ParameterName = "Usuario_que_programa";
                paramUpdUsuario_que_programa.DbType = DbType.Int32;
                paramUpdUsuario_que_programa.Value = (object)Solicitud_de_Pago_de_FacturasDB.Usuario_que_programa ?? DBNull.Value;
                var paramUpdFecha_programada_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_programada_de_Pago.ParameterName = "Fecha_programada_de_Pago";
                paramUpdFecha_programada_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_programada_de_Pago.Value = (object)Solicitud_de_Pago_de_FacturasDB.Fecha_programada_de_Pago ?? DBNull.Value;
		var paramUpdEstatus_de_Pago = _dataProvider.GetParameter();
                paramUpdEstatus_de_Pago.ParameterName = "Estatus_de_Pago";
                paramUpdEstatus_de_Pago.DbType = DbType.Int32;
                paramUpdEstatus_de_Pago.Value = (object)Solicitud_de_Pago_de_FacturasDB.Estatus_de_Pago ?? DBNull.Value;
                var paramUpdFecha_de_actualizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_actualizacion.ParameterName = "Fecha_de_actualizacion";
                paramUpdFecha_de_actualizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_actualizacion.Value = (object)entity.Fecha_de_actualizacion ?? DBNull.Value;
                var paramUpdHora_de_actualizacion = _dataProvider.GetParameter();
                paramUpdHora_de_actualizacion.ParameterName = "Hora_de_actualizacion";
                paramUpdHora_de_actualizacion.DbType = DbType.String;
                paramUpdHora_de_actualizacion.Value = (object)entity.Hora_de_actualizacion ?? DBNull.Value;
		var paramUpdUsuario_que_actualiza = _dataProvider.GetParameter();
                paramUpdUsuario_que_actualiza.ParameterName = "Usuario_que_actualiza";
                paramUpdUsuario_que_actualiza.DbType = DbType.Int32;
                paramUpdUsuario_que_actualiza.Value = (object)entity.Usuario_que_actualiza ?? DBNull.Value;
                var paramUpdFecha_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_de_Pago.ParameterName = "Fecha_de_Pago";
                paramUpdFecha_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_de_Pago.Value = (object)entity.Fecha_de_Pago ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSolicitud_de_Pago_de_Facturas>("sp_UpdSolicitud_de_Pago_de_Facturas" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdMes_Facturado , paramUpdFecha_inicio_del_periodo_facturado , paramUpdFecha_fin_del_periodo_facturado , paramUpdArchivo_XML , paramUpdArchivo_PDF , paramUpdRecibo_de_Solicitud_de_Pago , paramUpdTotal , paramUpdEstatus , paramUpdFecha_de_autorizacion , paramUpdHora_de_autorizacion , paramUpdUsuario_que_autoriza , paramUpdResultado_de_la_Revision , paramUpdObservaciones , paramUpdFecha_de_programacion , paramUpdHora_de_programacion , paramUpdUsuario_que_programa , paramUpdFecha_programada_de_Pago , paramUpdEstatus_de_Pago , paramUpdFecha_de_actualizacion , paramUpdHora_de_actualizacion , paramUpdUsuario_que_actualiza , paramUpdFecha_de_Pago ).FirstOrDefault();

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

