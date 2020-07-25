using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Laboratorios_Clinicos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Laboratorios_Clinicos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Laboratorios_ClinicosService : IDetalle_Laboratorios_ClinicosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> _Detalle_Laboratorios_ClinicosRepository;
        #endregion

        #region Ctor
        public Detalle_Laboratorios_ClinicosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> Detalle_Laboratorios_ClinicosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Laboratorios_ClinicosRepository = Detalle_Laboratorios_ClinicosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Laboratorios_ClinicosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos>("sp_SelAllDetalle_Laboratorios_Clinicos");
        }

        public IList<Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Laboratorios_Clinicos_Complete>("sp_SelAllComplete_Detalle_Laboratorios_Clinicos");
            return data.Select(m => new Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos
            {
                Folio = m.Folio
                ,Folio_Actividades_del_Evento = m.Folio_Actividades_del_Evento
                ,Numero_de_Empleado_Titular = m.Numero_de_Empleado_Titular
                ,Nombre_Completo = m.Nombre_Completo
                ,Familiar_del_Empleado = m.Familiar_del_Empleado.GetValueOrDefault()
                ,Numero_de_Empleado_Beneficiario = m.Numero_de_Empleado_Beneficiario
                ,Indicador_Indicadores_Laboratorio = new Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio() { Folio = m.Indicador.GetValueOrDefault(), Indicador = m.Indicador_Indicador }
                ,Resultado = m.Resultado
                ,Unidad = m.Unidad
                ,Intervalo_de_referencia = m.Intervalo_de_referencia
                ,Fecha_de_Resultado = m.Fecha_de_Resultado
                ,Estatus_Indicador = m.Estatus_Indicador


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Laboratorios_Clinicos>("sp_ListSelCount_Detalle_Laboratorios_Clinicos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Laboratorios_Clinicos>("sp_ListSelAll_Detalle_Laboratorios_Clinicos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos
                {
                    Folio = m.Detalle_Laboratorios_Clinicos_Folio,
                    Folio_Actividades_del_Evento = m.Detalle_Laboratorios_Clinicos_Folio_Actividades_del_Evento,
                    Numero_de_Empleado_Titular = m.Detalle_Laboratorios_Clinicos_Numero_de_Empleado_Titular,
                    Nombre_Completo = m.Detalle_Laboratorios_Clinicos_Nombre_Completo,
                    Familiar_del_Empleado = m.Detalle_Laboratorios_Clinicos_Familiar_del_Empleado ?? false,
                    Numero_de_Empleado_Beneficiario = m.Detalle_Laboratorios_Clinicos_Numero_de_Empleado_Beneficiario,
                    Indicador = m.Detalle_Laboratorios_Clinicos_Indicador,
                    Resultado = m.Detalle_Laboratorios_Clinicos_Resultado,
                    Unidad = m.Detalle_Laboratorios_Clinicos_Unidad,
                    Intervalo_de_referencia = m.Detalle_Laboratorios_Clinicos_Intervalo_de_referencia,
                    Fecha_de_Resultado = m.Detalle_Laboratorios_Clinicos_Fecha_de_Resultado,
                    Estatus_Indicador = m.Detalle_Laboratorios_Clinicos_Estatus_Indicador,

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

        public IList<Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Laboratorios_ClinicosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Laboratorios_ClinicosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_ClinicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Laboratorios_Clinicos>("sp_ListSelAll_Detalle_Laboratorios_Clinicos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Laboratorios_ClinicosPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Laboratorios_ClinicosPagingModel
                {
                    Detalle_Laboratorios_Clinicoss =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos
                {
                    Folio = m.Detalle_Laboratorios_Clinicos_Folio
                    ,Folio_Actividades_del_Evento = m.Detalle_Laboratorios_Clinicos_Folio_Actividades_del_Evento
                    ,Numero_de_Empleado_Titular = m.Detalle_Laboratorios_Clinicos_Numero_de_Empleado_Titular
                    ,Nombre_Completo = m.Detalle_Laboratorios_Clinicos_Nombre_Completo
                    ,Familiar_del_Empleado = m.Detalle_Laboratorios_Clinicos_Familiar_del_Empleado ?? false
                    ,Numero_de_Empleado_Beneficiario = m.Detalle_Laboratorios_Clinicos_Numero_de_Empleado_Beneficiario
                    ,Indicador = m.Detalle_Laboratorios_Clinicos_Indicador
                    ,Indicador_Indicadores_Laboratorio = new Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio() { Folio = m.Detalle_Laboratorios_Clinicos_Indicador.GetValueOrDefault(), Indicador = m.Detalle_Laboratorios_Clinicos_Indicador_Indicador }
                    ,Resultado = m.Detalle_Laboratorios_Clinicos_Resultado
                    ,Unidad = m.Detalle_Laboratorios_Clinicos_Unidad
                    ,Intervalo_de_referencia = m.Detalle_Laboratorios_Clinicos_Intervalo_de_referencia
                    ,Fecha_de_Resultado = m.Detalle_Laboratorios_Clinicos_Fecha_de_Resultado
                    ,Estatus_Indicador = m.Detalle_Laboratorios_Clinicos_Estatus_Indicador

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Laboratorios_ClinicosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos>("sp_GetDetalle_Laboratorios_Clinicos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Laboratorios_Clinicos>("sp_DelDetalle_Laboratorios_Clinicos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Actividades_del_Evento = _dataProvider.GetParameter();
                padreFolio_Actividades_del_Evento.ParameterName = "Folio_Actividades_del_Evento";
                padreFolio_Actividades_del_Evento.DbType = DbType.Int32;
                padreFolio_Actividades_del_Evento.Value = (object)entity.Folio_Actividades_del_Evento ?? DBNull.Value;
                var padreNumero_de_Empleado_Titular = _dataProvider.GetParameter();
                padreNumero_de_Empleado_Titular.ParameterName = "Numero_de_Empleado_Titular";
                padreNumero_de_Empleado_Titular.DbType = DbType.String;
                padreNumero_de_Empleado_Titular.Value = (object)entity.Numero_de_Empleado_Titular ?? DBNull.Value;
                var padreNombre_Completo = _dataProvider.GetParameter();
                padreNombre_Completo.ParameterName = "Nombre_Completo";
                padreNombre_Completo.DbType = DbType.String;
                padreNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var padreFamiliar_del_Empleado = _dataProvider.GetParameter();
                padreFamiliar_del_Empleado.ParameterName = "Familiar_del_Empleado";
                padreFamiliar_del_Empleado.DbType = DbType.Boolean;
                padreFamiliar_del_Empleado.Value = (object)entity.Familiar_del_Empleado ?? DBNull.Value;
                var padreNumero_de_Empleado_Beneficiario = _dataProvider.GetParameter();
                padreNumero_de_Empleado_Beneficiario.ParameterName = "Numero_de_Empleado_Beneficiario";
                padreNumero_de_Empleado_Beneficiario.DbType = DbType.String;
                padreNumero_de_Empleado_Beneficiario.Value = (object)entity.Numero_de_Empleado_Beneficiario ?? DBNull.Value;
                var padreIndicador = _dataProvider.GetParameter();
                padreIndicador.ParameterName = "Indicador";
                padreIndicador.DbType = DbType.Int32;
                padreIndicador.Value = (object)entity.Indicador ?? DBNull.Value;

                var padreResultado = _dataProvider.GetParameter();
                padreResultado.ParameterName = "Resultado";
                padreResultado.DbType = DbType.Int32;
                padreResultado.Value = (object)entity.Resultado ?? DBNull.Value;

                var padreUnidad = _dataProvider.GetParameter();
                padreUnidad.ParameterName = "Unidad";
                padreUnidad.DbType = DbType.String;
                padreUnidad.Value = (object)entity.Unidad ?? DBNull.Value;
                var padreIntervalo_de_referencia = _dataProvider.GetParameter();
                padreIntervalo_de_referencia.ParameterName = "Intervalo_de_referencia";
                padreIntervalo_de_referencia.DbType = DbType.String;
                padreIntervalo_de_referencia.Value = (object)entity.Intervalo_de_referencia ?? DBNull.Value;
                var padreFecha_de_Resultado = _dataProvider.GetParameter();
                padreFecha_de_Resultado.ParameterName = "Fecha_de_Resultado";
                padreFecha_de_Resultado.DbType = DbType.DateTime;
                padreFecha_de_Resultado.Value = (object)entity.Fecha_de_Resultado ?? DBNull.Value;

                var padreEstatus_Indicador = _dataProvider.GetParameter();
                padreEstatus_Indicador.ParameterName = "Estatus_Indicador";
                padreEstatus_Indicador.DbType = DbType.String;
                padreEstatus_Indicador.Value = (object)entity.Estatus_Indicador ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Laboratorios_Clinicos>("sp_InsDetalle_Laboratorios_Clinicos" , padreFolio_Actividades_del_Evento
, padreNumero_de_Empleado_Titular
, padreNombre_Completo
, padreFamiliar_del_Empleado
, padreNumero_de_Empleado_Beneficiario
, padreIndicador
, padreResultado
, padreUnidad
, padreIntervalo_de_referencia
, padreFecha_de_Resultado
, padreEstatus_Indicador
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

        public int Update(Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Actividades_del_Evento = _dataProvider.GetParameter();
                paramUpdFolio_Actividades_del_Evento.ParameterName = "Folio_Actividades_del_Evento";
                paramUpdFolio_Actividades_del_Evento.DbType = DbType.Int32;
                paramUpdFolio_Actividades_del_Evento.Value = (object)entity.Folio_Actividades_del_Evento ?? DBNull.Value;
                var paramUpdNumero_de_Empleado_Titular = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado_Titular.ParameterName = "Numero_de_Empleado_Titular";
                paramUpdNumero_de_Empleado_Titular.DbType = DbType.String;
                paramUpdNumero_de_Empleado_Titular.Value = (object)entity.Numero_de_Empleado_Titular ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var paramUpdFamiliar_del_Empleado = _dataProvider.GetParameter();
                paramUpdFamiliar_del_Empleado.ParameterName = "Familiar_del_Empleado";
                paramUpdFamiliar_del_Empleado.DbType = DbType.Boolean;
                paramUpdFamiliar_del_Empleado.Value = (object)entity.Familiar_del_Empleado ?? DBNull.Value;
                var paramUpdNumero_de_Empleado_Beneficiario = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado_Beneficiario.ParameterName = "Numero_de_Empleado_Beneficiario";
                paramUpdNumero_de_Empleado_Beneficiario.DbType = DbType.String;
                paramUpdNumero_de_Empleado_Beneficiario.Value = (object)entity.Numero_de_Empleado_Beneficiario ?? DBNull.Value;
                var paramUpdIndicador = _dataProvider.GetParameter();
                paramUpdIndicador.ParameterName = "Indicador";
                paramUpdIndicador.DbType = DbType.Int32;
                paramUpdIndicador.Value = (object)entity.Indicador ?? DBNull.Value;

                var paramUpdResultado = _dataProvider.GetParameter();
                paramUpdResultado.ParameterName = "Resultado";
                paramUpdResultado.DbType = DbType.Int32;
                paramUpdResultado.Value = (object)entity.Resultado ?? DBNull.Value;

                var paramUpdUnidad = _dataProvider.GetParameter();
                paramUpdUnidad.ParameterName = "Unidad";
                paramUpdUnidad.DbType = DbType.String;
                paramUpdUnidad.Value = (object)entity.Unidad ?? DBNull.Value;
                var paramUpdIntervalo_de_referencia = _dataProvider.GetParameter();
                paramUpdIntervalo_de_referencia.ParameterName = "Intervalo_de_referencia";
                paramUpdIntervalo_de_referencia.DbType = DbType.String;
                paramUpdIntervalo_de_referencia.Value = (object)entity.Intervalo_de_referencia ?? DBNull.Value;
                var paramUpdFecha_de_Resultado = _dataProvider.GetParameter();
                paramUpdFecha_de_Resultado.ParameterName = "Fecha_de_Resultado";
                paramUpdFecha_de_Resultado.DbType = DbType.DateTime;
                paramUpdFecha_de_Resultado.Value = (object)entity.Fecha_de_Resultado ?? DBNull.Value;

                var paramUpdEstatus_Indicador = _dataProvider.GetParameter();
                paramUpdEstatus_Indicador.ParameterName = "Estatus_Indicador";
                paramUpdEstatus_Indicador.DbType = DbType.String;
                paramUpdEstatus_Indicador.Value = (object)entity.Estatus_Indicador ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Laboratorios_Clinicos>("sp_UpdDetalle_Laboratorios_Clinicos" , paramUpdFolio , paramUpdFolio_Actividades_del_Evento , paramUpdNumero_de_Empleado_Titular , paramUpdNombre_Completo , paramUpdFamiliar_del_Empleado , paramUpdNumero_de_Empleado_Beneficiario , paramUpdIndicador , paramUpdResultado , paramUpdUnidad , paramUpdIntervalo_de_referencia , paramUpdFecha_de_Resultado , paramUpdEstatus_Indicador ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Laboratorios_Clinicos.Detalle_Laboratorios_Clinicos Detalle_Laboratorios_ClinicosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Actividades_del_Evento = _dataProvider.GetParameter();
                paramUpdFolio_Actividades_del_Evento.ParameterName = "Folio_Actividades_del_Evento";
                paramUpdFolio_Actividades_del_Evento.DbType = DbType.Int32;
                paramUpdFolio_Actividades_del_Evento.Value = (object)entity.Folio_Actividades_del_Evento ?? DBNull.Value;
                var paramUpdNumero_de_Empleado_Titular = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado_Titular.ParameterName = "Numero_de_Empleado_Titular";
                paramUpdNumero_de_Empleado_Titular.DbType = DbType.String;
                paramUpdNumero_de_Empleado_Titular.Value = (object)entity.Numero_de_Empleado_Titular ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var paramUpdFamiliar_del_Empleado = _dataProvider.GetParameter();
                paramUpdFamiliar_del_Empleado.ParameterName = "Familiar_del_Empleado";
                paramUpdFamiliar_del_Empleado.DbType = DbType.Boolean;
                paramUpdFamiliar_del_Empleado.Value = (object)entity.Familiar_del_Empleado ?? DBNull.Value;
                var paramUpdNumero_de_Empleado_Beneficiario = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado_Beneficiario.ParameterName = "Numero_de_Empleado_Beneficiario";
                paramUpdNumero_de_Empleado_Beneficiario.DbType = DbType.String;
                paramUpdNumero_de_Empleado_Beneficiario.Value = (object)entity.Numero_de_Empleado_Beneficiario ?? DBNull.Value;
		var paramUpdIndicador = _dataProvider.GetParameter();
                paramUpdIndicador.ParameterName = "Indicador";
                paramUpdIndicador.DbType = DbType.Int32;
                paramUpdIndicador.Value = (object)entity.Indicador ?? DBNull.Value;
                var paramUpdResultado = _dataProvider.GetParameter();
                paramUpdResultado.ParameterName = "Resultado";
                paramUpdResultado.DbType = DbType.Int32;
                paramUpdResultado.Value = (object)entity.Resultado ?? DBNull.Value;
                var paramUpdUnidad = _dataProvider.GetParameter();
                paramUpdUnidad.ParameterName = "Unidad";
                paramUpdUnidad.DbType = DbType.String;
                paramUpdUnidad.Value = (object)entity.Unidad ?? DBNull.Value;
                var paramUpdIntervalo_de_referencia = _dataProvider.GetParameter();
                paramUpdIntervalo_de_referencia.ParameterName = "Intervalo_de_referencia";
                paramUpdIntervalo_de_referencia.DbType = DbType.String;
                paramUpdIntervalo_de_referencia.Value = (object)entity.Intervalo_de_referencia ?? DBNull.Value;
                var paramUpdFecha_de_Resultado = _dataProvider.GetParameter();
                paramUpdFecha_de_Resultado.ParameterName = "Fecha_de_Resultado";
                paramUpdFecha_de_Resultado.DbType = DbType.DateTime;
                paramUpdFecha_de_Resultado.Value = (object)entity.Fecha_de_Resultado ?? DBNull.Value;
                var paramUpdEstatus_Indicador = _dataProvider.GetParameter();
                paramUpdEstatus_Indicador.ParameterName = "Estatus_Indicador";
                paramUpdEstatus_Indicador.DbType = DbType.String;
                paramUpdEstatus_Indicador.Value = (object)entity.Estatus_Indicador ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Laboratorios_Clinicos>("sp_UpdDetalle_Laboratorios_Clinicos" , paramUpdFolio , paramUpdFolio_Actividades_del_Evento , paramUpdNumero_de_Empleado_Titular , paramUpdNombre_Completo , paramUpdFamiliar_del_Empleado , paramUpdNumero_de_Empleado_Beneficiario , paramUpdIndicador , paramUpdResultado , paramUpdUnidad , paramUpdIntervalo_de_referencia , paramUpdFecha_de_Resultado , paramUpdEstatus_Indicador ).FirstOrDefault();

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

