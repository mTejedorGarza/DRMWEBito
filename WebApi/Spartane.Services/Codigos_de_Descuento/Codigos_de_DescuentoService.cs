using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Codigos_de_Descuento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Codigos_de_Descuento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Codigos_de_DescuentoService : ICodigos_de_DescuentoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento> _Codigos_de_DescuentoRepository;
        #endregion

        #region Ctor
        public Codigos_de_DescuentoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento> Codigos_de_DescuentoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Codigos_de_DescuentoRepository = Codigos_de_DescuentoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Codigos_de_DescuentoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento>("sp_SelAllCodigos_de_Descuento");
        }

        public IList<Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallCodigos_de_Descuento_Complete>("sp_SelAllComplete_Codigos_de_Descuento");
            return data.Select(m => new Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Tipo_de_Vendedor_Tipos_de_Vendedor = new Core.Classes.Tipos_de_Vendedor.Tipos_de_Vendedor() { Clave = m.Tipo_de_Vendedor.GetValueOrDefault(), Descripcion = m.Tipo_de_Vendedor_Descripcion }
                ,Vendedor_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Vendedor.GetValueOrDefault(), Name = m.Vendedor_Name }
                ,Tipo_de_Descuento_Tipos_de_Descuento = new Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento() { Clave = m.Tipo_de_Descuento.GetValueOrDefault(), Nombre = m.Tipo_de_Descuento_Nombre }
                ,Descuento = m.Descuento
                ,Texto_promocional = m.Texto_promocional
                ,Fecha_inicio_vigencia = m.Fecha_inicio_vigencia
                ,Fecha_fin_vigencia = m.Fecha_fin_vigencia
                ,Cantidad_maxima_de_referenciados = m.Cantidad_maxima_de_referenciados
                ,Codigo_de_descuento = m.Codigo_de_descuento
                ,Estatus_Estatus_de_Codigos_de_Descuento = new Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento() { Folio = m.Estatus.GetValueOrDefault(), Nombre = m.Estatus_Nombre }
                ,Fecha_de_autorizacion = m.Fecha_de_autorizacion
                ,Hora_de_autorizacion = m.Hora_de_autorizacion
                ,Usuario_que_autoriza_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_autoriza.GetValueOrDefault(), Name = m.Usuario_que_autoriza_Name }
                ,Observaciones = m.Observaciones
                ,Resultado_Resultado_de_Autorizacion = new Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion() { Folio = m.Resultado.GetValueOrDefault(), Nombre = m.Resultado_Nombre }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Codigos_de_Descuento>("sp_ListSelCount_Codigos_de_Descuento", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCodigos_de_Descuento>("sp_ListSelAll_Codigos_de_Descuento", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento
                {
                    Folio = m.Codigos_de_Descuento_Folio,
                    Fecha_de_Registro = m.Codigos_de_Descuento_Fecha_de_Registro,
                    Hora_de_Registro = m.Codigos_de_Descuento_Hora_de_Registro,
                    Usuario_que_Registra = m.Codigos_de_Descuento_Usuario_que_Registra,
                    Tipo_de_Vendedor = m.Codigos_de_Descuento_Tipo_de_Vendedor,
                    Vendedor = m.Codigos_de_Descuento_Vendedor,
                    Tipo_de_Descuento = m.Codigos_de_Descuento_Tipo_de_Descuento,
                    Descuento = m.Codigos_de_Descuento_Descuento,
                    Texto_promocional = m.Codigos_de_Descuento_Texto_promocional,
                    Fecha_inicio_vigencia = m.Codigos_de_Descuento_Fecha_inicio_vigencia,
                    Fecha_fin_vigencia = m.Codigos_de_Descuento_Fecha_fin_vigencia,
                    Cantidad_maxima_de_referenciados = m.Codigos_de_Descuento_Cantidad_maxima_de_referenciados,
                    Codigo_de_descuento = m.Codigos_de_Descuento_Codigo_de_descuento,
                    Estatus = m.Codigos_de_Descuento_Estatus,
                    Fecha_de_autorizacion = m.Codigos_de_Descuento_Fecha_de_autorizacion,
                    Hora_de_autorizacion = m.Codigos_de_Descuento_Hora_de_autorizacion,
                    Usuario_que_autoriza = m.Codigos_de_Descuento_Usuario_que_autoriza,
                    Observaciones = m.Codigos_de_Descuento_Observaciones,
                    Resultado = m.Codigos_de_Descuento_Resultado,

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

        public IList<Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Codigos_de_DescuentoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Codigos_de_DescuentoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_DescuentoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCodigos_de_Descuento>("sp_ListSelAll_Codigos_de_Descuento", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Codigos_de_DescuentoPagingModel result = null;

            if (data != null)
            {
                result = new Codigos_de_DescuentoPagingModel
                {
                    Codigos_de_Descuentos =
                        data.Select(m => new Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento
                {
                    Folio = m.Codigos_de_Descuento_Folio
                    ,Fecha_de_Registro = m.Codigos_de_Descuento_Fecha_de_Registro
                    ,Hora_de_Registro = m.Codigos_de_Descuento_Hora_de_Registro
                    ,Usuario_que_Registra = m.Codigos_de_Descuento_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Codigos_de_Descuento_Usuario_que_Registra.GetValueOrDefault(), Name = m.Codigos_de_Descuento_Usuario_que_Registra_Name }
                    ,Tipo_de_Vendedor = m.Codigos_de_Descuento_Tipo_de_Vendedor
                    ,Tipo_de_Vendedor_Tipos_de_Vendedor = new Core.Classes.Tipos_de_Vendedor.Tipos_de_Vendedor() { Clave = m.Codigos_de_Descuento_Tipo_de_Vendedor.GetValueOrDefault(), Descripcion = m.Codigos_de_Descuento_Tipo_de_Vendedor_Descripcion }
                    ,Vendedor = m.Codigos_de_Descuento_Vendedor
                    ,Vendedor_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Codigos_de_Descuento_Vendedor.GetValueOrDefault(), Name = m.Codigos_de_Descuento_Vendedor_Name }
                    ,Tipo_de_Descuento = m.Codigos_de_Descuento_Tipo_de_Descuento
                    ,Tipo_de_Descuento_Tipos_de_Descuento = new Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento() { Clave = m.Codigos_de_Descuento_Tipo_de_Descuento.GetValueOrDefault(), Nombre = m.Codigos_de_Descuento_Tipo_de_Descuento_Nombre }
                    ,Descuento = m.Codigos_de_Descuento_Descuento
                    ,Texto_promocional = m.Codigos_de_Descuento_Texto_promocional
                    ,Fecha_inicio_vigencia = m.Codigos_de_Descuento_Fecha_inicio_vigencia
                    ,Fecha_fin_vigencia = m.Codigos_de_Descuento_Fecha_fin_vigencia
                    ,Cantidad_maxima_de_referenciados = m.Codigos_de_Descuento_Cantidad_maxima_de_referenciados
                    ,Codigo_de_descuento = m.Codigos_de_Descuento_Codigo_de_descuento
                    ,Estatus = m.Codigos_de_Descuento_Estatus
                    ,Estatus_Estatus_de_Codigos_de_Descuento = new Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento() { Folio = m.Codigos_de_Descuento_Estatus.GetValueOrDefault(), Nombre = m.Codigos_de_Descuento_Estatus_Nombre }
                    ,Fecha_de_autorizacion = m.Codigos_de_Descuento_Fecha_de_autorizacion
                    ,Hora_de_autorizacion = m.Codigos_de_Descuento_Hora_de_autorizacion
                    ,Usuario_que_autoriza = m.Codigos_de_Descuento_Usuario_que_autoriza
                    ,Usuario_que_autoriza_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Codigos_de_Descuento_Usuario_que_autoriza.GetValueOrDefault(), Name = m.Codigos_de_Descuento_Usuario_que_autoriza_Name }
                    ,Observaciones = m.Codigos_de_Descuento_Observaciones
                    ,Resultado = m.Codigos_de_Descuento_Resultado
                    ,Resultado_Resultado_de_Autorizacion = new Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion() { Folio = m.Codigos_de_Descuento_Resultado.GetValueOrDefault(), Nombre = m.Codigos_de_Descuento_Resultado_Nombre }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Codigos_de_DescuentoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento>("sp_GetCodigos_de_Descuento", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelCodigos_de_Descuento>("sp_DelCodigos_de_Descuento", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento entity)
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

                var padreTipo_de_Vendedor = _dataProvider.GetParameter();
                padreTipo_de_Vendedor.ParameterName = "Tipo_de_Vendedor";
                padreTipo_de_Vendedor.DbType = DbType.Int32;
                padreTipo_de_Vendedor.Value = (object)entity.Tipo_de_Vendedor ?? DBNull.Value;

                var padreVendedor = _dataProvider.GetParameter();
                padreVendedor.ParameterName = "Vendedor";
                padreVendedor.DbType = DbType.Int32;
                padreVendedor.Value = (object)entity.Vendedor ?? DBNull.Value;

                var padreTipo_de_Descuento = _dataProvider.GetParameter();
                padreTipo_de_Descuento.ParameterName = "Tipo_de_Descuento";
                padreTipo_de_Descuento.DbType = DbType.Int32;
                padreTipo_de_Descuento.Value = (object)entity.Tipo_de_Descuento ?? DBNull.Value;

                var padreDescuento = _dataProvider.GetParameter();
                padreDescuento.ParameterName = "Descuento";
                padreDescuento.DbType = DbType.Decimal;
                padreDescuento.Value = (object)entity.Descuento ?? DBNull.Value;

                var padreTexto_promocional = _dataProvider.GetParameter();
                padreTexto_promocional.ParameterName = "Texto_promocional";
                padreTexto_promocional.DbType = DbType.String;
                padreTexto_promocional.Value = (object)entity.Texto_promocional ?? DBNull.Value;
                var padreFecha_inicio_vigencia = _dataProvider.GetParameter();
                padreFecha_inicio_vigencia.ParameterName = "Fecha_inicio_vigencia";
                padreFecha_inicio_vigencia.DbType = DbType.DateTime;
                padreFecha_inicio_vigencia.Value = (object)entity.Fecha_inicio_vigencia ?? DBNull.Value;

                var padreFecha_fin_vigencia = _dataProvider.GetParameter();
                padreFecha_fin_vigencia.ParameterName = "Fecha_fin_vigencia";
                padreFecha_fin_vigencia.DbType = DbType.DateTime;
                padreFecha_fin_vigencia.Value = (object)entity.Fecha_fin_vigencia ?? DBNull.Value;

                var padreCantidad_maxima_de_referenciados = _dataProvider.GetParameter();
                padreCantidad_maxima_de_referenciados.ParameterName = "Cantidad_maxima_de_referenciados";
                padreCantidad_maxima_de_referenciados.DbType = DbType.Int32;
                padreCantidad_maxima_de_referenciados.Value = (object)entity.Cantidad_maxima_de_referenciados ?? DBNull.Value;

                var padreCodigo_de_descuento = _dataProvider.GetParameter();
                padreCodigo_de_descuento.ParameterName = "Codigo_de_descuento";
                padreCodigo_de_descuento.DbType = DbType.String;
                padreCodigo_de_descuento.Value = (object)entity.Codigo_de_descuento ?? DBNull.Value;
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

                var padreObservaciones = _dataProvider.GetParameter();
                padreObservaciones.ParameterName = "Observaciones";
                padreObservaciones.DbType = DbType.String;
                padreObservaciones.Value = (object)entity.Observaciones ?? DBNull.Value;
                var padreResultado = _dataProvider.GetParameter();
                padreResultado.ParameterName = "Resultado";
                padreResultado.DbType = DbType.Int32;
                padreResultado.Value = (object)entity.Resultado ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsCodigos_de_Descuento>("sp_InsCodigos_de_Descuento" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreTipo_de_Vendedor
, padreVendedor
, padreTipo_de_Descuento
, padreDescuento
, padreTexto_promocional
, padreFecha_inicio_vigencia
, padreFecha_fin_vigencia
, padreCantidad_maxima_de_referenciados
, padreCodigo_de_descuento
, padreEstatus
, padreFecha_de_autorizacion
, padreHora_de_autorizacion
, padreUsuario_que_autoriza
, padreObservaciones
, padreResultado
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

        public int Update(Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento entity)
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

                var paramUpdTipo_de_Vendedor = _dataProvider.GetParameter();
                paramUpdTipo_de_Vendedor.ParameterName = "Tipo_de_Vendedor";
                paramUpdTipo_de_Vendedor.DbType = DbType.Int32;
                paramUpdTipo_de_Vendedor.Value = (object)entity.Tipo_de_Vendedor ?? DBNull.Value;

                var paramUpdVendedor = _dataProvider.GetParameter();
                paramUpdVendedor.ParameterName = "Vendedor";
                paramUpdVendedor.DbType = DbType.Int32;
                paramUpdVendedor.Value = (object)entity.Vendedor ?? DBNull.Value;

                var paramUpdTipo_de_Descuento = _dataProvider.GetParameter();
                paramUpdTipo_de_Descuento.ParameterName = "Tipo_de_Descuento";
                paramUpdTipo_de_Descuento.DbType = DbType.Int32;
                paramUpdTipo_de_Descuento.Value = (object)entity.Tipo_de_Descuento ?? DBNull.Value;

                var paramUpdDescuento = _dataProvider.GetParameter();
                paramUpdDescuento.ParameterName = "Descuento";
                paramUpdDescuento.DbType = DbType.Decimal;
                paramUpdDescuento.Value = (object)entity.Descuento ?? DBNull.Value;

                var paramUpdTexto_promocional = _dataProvider.GetParameter();
                paramUpdTexto_promocional.ParameterName = "Texto_promocional";
                paramUpdTexto_promocional.DbType = DbType.String;
                paramUpdTexto_promocional.Value = (object)entity.Texto_promocional ?? DBNull.Value;
                var paramUpdFecha_inicio_vigencia = _dataProvider.GetParameter();
                paramUpdFecha_inicio_vigencia.ParameterName = "Fecha_inicio_vigencia";
                paramUpdFecha_inicio_vigencia.DbType = DbType.DateTime;
                paramUpdFecha_inicio_vigencia.Value = (object)entity.Fecha_inicio_vigencia ?? DBNull.Value;

                var paramUpdFecha_fin_vigencia = _dataProvider.GetParameter();
                paramUpdFecha_fin_vigencia.ParameterName = "Fecha_fin_vigencia";
                paramUpdFecha_fin_vigencia.DbType = DbType.DateTime;
                paramUpdFecha_fin_vigencia.Value = (object)entity.Fecha_fin_vigencia ?? DBNull.Value;

                var paramUpdCantidad_maxima_de_referenciados = _dataProvider.GetParameter();
                paramUpdCantidad_maxima_de_referenciados.ParameterName = "Cantidad_maxima_de_referenciados";
                paramUpdCantidad_maxima_de_referenciados.DbType = DbType.Int32;
                paramUpdCantidad_maxima_de_referenciados.Value = (object)entity.Cantidad_maxima_de_referenciados ?? DBNull.Value;

                var paramUpdCodigo_de_descuento = _dataProvider.GetParameter();
                paramUpdCodigo_de_descuento.ParameterName = "Codigo_de_descuento";
                paramUpdCodigo_de_descuento.DbType = DbType.String;
                paramUpdCodigo_de_descuento.Value = (object)entity.Codigo_de_descuento ?? DBNull.Value;
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

                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)entity.Observaciones ?? DBNull.Value;
                var paramUpdResultado = _dataProvider.GetParameter();
                paramUpdResultado.ParameterName = "Resultado";
                paramUpdResultado.DbType = DbType.Int32;
                paramUpdResultado.Value = (object)entity.Resultado ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCodigos_de_Descuento>("sp_UpdCodigos_de_Descuento" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Vendedor , paramUpdVendedor , paramUpdTipo_de_Descuento , paramUpdDescuento , paramUpdTexto_promocional , paramUpdFecha_inicio_vigencia , paramUpdFecha_fin_vigencia , paramUpdCantidad_maxima_de_referenciados , paramUpdCodigo_de_descuento , paramUpdEstatus , paramUpdFecha_de_autorizacion , paramUpdHora_de_autorizacion , paramUpdUsuario_que_autoriza , paramUpdObservaciones , paramUpdResultado ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento Codigos_de_DescuentoDB = GetByKey(entity.Folio, false);
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
		var paramUpdTipo_de_Vendedor = _dataProvider.GetParameter();
                paramUpdTipo_de_Vendedor.ParameterName = "Tipo_de_Vendedor";
                paramUpdTipo_de_Vendedor.DbType = DbType.Int32;
                paramUpdTipo_de_Vendedor.Value = (object)entity.Tipo_de_Vendedor ?? DBNull.Value;
		var paramUpdVendedor = _dataProvider.GetParameter();
                paramUpdVendedor.ParameterName = "Vendedor";
                paramUpdVendedor.DbType = DbType.Int32;
                paramUpdVendedor.Value = (object)entity.Vendedor ?? DBNull.Value;
		var paramUpdTipo_de_Descuento = _dataProvider.GetParameter();
                paramUpdTipo_de_Descuento.ParameterName = "Tipo_de_Descuento";
                paramUpdTipo_de_Descuento.DbType = DbType.Int32;
                paramUpdTipo_de_Descuento.Value = (object)entity.Tipo_de_Descuento ?? DBNull.Value;
                var paramUpdDescuento = _dataProvider.GetParameter();
                paramUpdDescuento.ParameterName = "Descuento";
                paramUpdDescuento.DbType = DbType.Decimal;
                paramUpdDescuento.Value = (object)entity.Descuento ?? DBNull.Value;
                var paramUpdTexto_promocional = _dataProvider.GetParameter();
                paramUpdTexto_promocional.ParameterName = "Texto_promocional";
                paramUpdTexto_promocional.DbType = DbType.String;
                paramUpdTexto_promocional.Value = (object)entity.Texto_promocional ?? DBNull.Value;
                var paramUpdFecha_inicio_vigencia = _dataProvider.GetParameter();
                paramUpdFecha_inicio_vigencia.ParameterName = "Fecha_inicio_vigencia";
                paramUpdFecha_inicio_vigencia.DbType = DbType.DateTime;
                paramUpdFecha_inicio_vigencia.Value = (object)entity.Fecha_inicio_vigencia ?? DBNull.Value;
                var paramUpdFecha_fin_vigencia = _dataProvider.GetParameter();
                paramUpdFecha_fin_vigencia.ParameterName = "Fecha_fin_vigencia";
                paramUpdFecha_fin_vigencia.DbType = DbType.DateTime;
                paramUpdFecha_fin_vigencia.Value = (object)entity.Fecha_fin_vigencia ?? DBNull.Value;
                var paramUpdCantidad_maxima_de_referenciados = _dataProvider.GetParameter();
                paramUpdCantidad_maxima_de_referenciados.ParameterName = "Cantidad_maxima_de_referenciados";
                paramUpdCantidad_maxima_de_referenciados.DbType = DbType.Int32;
                paramUpdCantidad_maxima_de_referenciados.Value = (object)entity.Cantidad_maxima_de_referenciados ?? DBNull.Value;
                var paramUpdCodigo_de_descuento = _dataProvider.GetParameter();
                paramUpdCodigo_de_descuento.ParameterName = "Codigo_de_descuento";
                paramUpdCodigo_de_descuento.DbType = DbType.String;
                paramUpdCodigo_de_descuento.Value = (object)entity.Codigo_de_descuento ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;
                var paramUpdFecha_de_autorizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_autorizacion.ParameterName = "Fecha_de_autorizacion";
                paramUpdFecha_de_autorizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_autorizacion.Value = (object)Codigos_de_DescuentoDB.Fecha_de_autorizacion ?? DBNull.Value;
                var paramUpdHora_de_autorizacion = _dataProvider.GetParameter();
                paramUpdHora_de_autorizacion.ParameterName = "Hora_de_autorizacion";
                paramUpdHora_de_autorizacion.DbType = DbType.String;
                paramUpdHora_de_autorizacion.Value = (object)Codigos_de_DescuentoDB.Hora_de_autorizacion ?? DBNull.Value;
		var paramUpdUsuario_que_autoriza = _dataProvider.GetParameter();
                paramUpdUsuario_que_autoriza.ParameterName = "Usuario_que_autoriza";
                paramUpdUsuario_que_autoriza.DbType = DbType.Int32;
                paramUpdUsuario_que_autoriza.Value = (object)Codigos_de_DescuentoDB.Usuario_que_autoriza ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)Codigos_de_DescuentoDB.Observaciones ?? DBNull.Value;
		var paramUpdResultado = _dataProvider.GetParameter();
                paramUpdResultado.ParameterName = "Resultado";
                paramUpdResultado.DbType = DbType.Int32;
                paramUpdResultado.Value = (object)Codigos_de_DescuentoDB.Resultado ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCodigos_de_Descuento>("sp_UpdCodigos_de_Descuento" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Vendedor , paramUpdVendedor , paramUpdTipo_de_Descuento , paramUpdDescuento , paramUpdTexto_promocional , paramUpdFecha_inicio_vigencia , paramUpdFecha_fin_vigencia , paramUpdCantidad_maxima_de_referenciados , paramUpdCodigo_de_descuento , paramUpdEstatus , paramUpdFecha_de_autorizacion , paramUpdHora_de_autorizacion , paramUpdUsuario_que_autoriza , paramUpdObservaciones , paramUpdResultado ).FirstOrDefault();

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

		public int Update_Autorizacion(Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento Codigos_de_DescuentoDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)Codigos_de_DescuentoDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)Codigos_de_DescuentoDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)Codigos_de_DescuentoDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)Codigos_de_DescuentoDB.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdTipo_de_Vendedor = _dataProvider.GetParameter();
                paramUpdTipo_de_Vendedor.ParameterName = "Tipo_de_Vendedor";
                paramUpdTipo_de_Vendedor.DbType = DbType.Int32;
                paramUpdTipo_de_Vendedor.Value = (object)Codigos_de_DescuentoDB.Tipo_de_Vendedor ?? DBNull.Value;
		var paramUpdVendedor = _dataProvider.GetParameter();
                paramUpdVendedor.ParameterName = "Vendedor";
                paramUpdVendedor.DbType = DbType.Int32;
                paramUpdVendedor.Value = (object)Codigos_de_DescuentoDB.Vendedor ?? DBNull.Value;
		var paramUpdTipo_de_Descuento = _dataProvider.GetParameter();
                paramUpdTipo_de_Descuento.ParameterName = "Tipo_de_Descuento";
                paramUpdTipo_de_Descuento.DbType = DbType.Int32;
                paramUpdTipo_de_Descuento.Value = (object)Codigos_de_DescuentoDB.Tipo_de_Descuento ?? DBNull.Value;
                var paramUpdDescuento = _dataProvider.GetParameter();
                paramUpdDescuento.ParameterName = "Descuento";
                paramUpdDescuento.DbType = DbType.Decimal;
                paramUpdDescuento.Value = (object)Codigos_de_DescuentoDB.Descuento ?? DBNull.Value;
                var paramUpdTexto_promocional = _dataProvider.GetParameter();
                paramUpdTexto_promocional.ParameterName = "Texto_promocional";
                paramUpdTexto_promocional.DbType = DbType.String;
                paramUpdTexto_promocional.Value = (object)Codigos_de_DescuentoDB.Texto_promocional ?? DBNull.Value;
                var paramUpdFecha_inicio_vigencia = _dataProvider.GetParameter();
                paramUpdFecha_inicio_vigencia.ParameterName = "Fecha_inicio_vigencia";
                paramUpdFecha_inicio_vigencia.DbType = DbType.DateTime;
                paramUpdFecha_inicio_vigencia.Value = (object)Codigos_de_DescuentoDB.Fecha_inicio_vigencia ?? DBNull.Value;
                var paramUpdFecha_fin_vigencia = _dataProvider.GetParameter();
                paramUpdFecha_fin_vigencia.ParameterName = "Fecha_fin_vigencia";
                paramUpdFecha_fin_vigencia.DbType = DbType.DateTime;
                paramUpdFecha_fin_vigencia.Value = (object)Codigos_de_DescuentoDB.Fecha_fin_vigencia ?? DBNull.Value;
                var paramUpdCantidad_maxima_de_referenciados = _dataProvider.GetParameter();
                paramUpdCantidad_maxima_de_referenciados.ParameterName = "Cantidad_maxima_de_referenciados";
                paramUpdCantidad_maxima_de_referenciados.DbType = DbType.Int32;
                paramUpdCantidad_maxima_de_referenciados.Value = (object)Codigos_de_DescuentoDB.Cantidad_maxima_de_referenciados ?? DBNull.Value;
                var paramUpdCodigo_de_descuento = _dataProvider.GetParameter();
                paramUpdCodigo_de_descuento.ParameterName = "Codigo_de_descuento";
                paramUpdCodigo_de_descuento.DbType = DbType.String;
                paramUpdCodigo_de_descuento.Value = (object)Codigos_de_DescuentoDB.Codigo_de_descuento ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)Codigos_de_DescuentoDB.Estatus ?? DBNull.Value;
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
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)entity.Observaciones ?? DBNull.Value;
		var paramUpdResultado = _dataProvider.GetParameter();
                paramUpdResultado.ParameterName = "Resultado";
                paramUpdResultado.DbType = DbType.Int32;
                paramUpdResultado.Value = (object)entity.Resultado ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCodigos_de_Descuento>("sp_UpdCodigos_de_Descuento" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Vendedor , paramUpdVendedor , paramUpdTipo_de_Descuento , paramUpdDescuento , paramUpdTexto_promocional , paramUpdFecha_inicio_vigencia , paramUpdFecha_fin_vigencia , paramUpdCantidad_maxima_de_referenciados , paramUpdCodigo_de_descuento , paramUpdEstatus , paramUpdFecha_de_autorizacion , paramUpdHora_de_autorizacion , paramUpdUsuario_que_autoriza , paramUpdObservaciones , paramUpdResultado ).FirstOrDefault();

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

		public int Update_Referenciados(Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Codigos_de_Descuento.Codigos_de_Descuento Codigos_de_DescuentoDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)Codigos_de_DescuentoDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)Codigos_de_DescuentoDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)Codigos_de_DescuentoDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)Codigos_de_DescuentoDB.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdTipo_de_Vendedor = _dataProvider.GetParameter();
                paramUpdTipo_de_Vendedor.ParameterName = "Tipo_de_Vendedor";
                paramUpdTipo_de_Vendedor.DbType = DbType.Int32;
                paramUpdTipo_de_Vendedor.Value = (object)Codigos_de_DescuentoDB.Tipo_de_Vendedor ?? DBNull.Value;
		var paramUpdVendedor = _dataProvider.GetParameter();
                paramUpdVendedor.ParameterName = "Vendedor";
                paramUpdVendedor.DbType = DbType.Int32;
                paramUpdVendedor.Value = (object)Codigos_de_DescuentoDB.Vendedor ?? DBNull.Value;
		var paramUpdTipo_de_Descuento = _dataProvider.GetParameter();
                paramUpdTipo_de_Descuento.ParameterName = "Tipo_de_Descuento";
                paramUpdTipo_de_Descuento.DbType = DbType.Int32;
                paramUpdTipo_de_Descuento.Value = (object)Codigos_de_DescuentoDB.Tipo_de_Descuento ?? DBNull.Value;
                var paramUpdDescuento = _dataProvider.GetParameter();
                paramUpdDescuento.ParameterName = "Descuento";
                paramUpdDescuento.DbType = DbType.Decimal;
                paramUpdDescuento.Value = (object)Codigos_de_DescuentoDB.Descuento ?? DBNull.Value;
                var paramUpdTexto_promocional = _dataProvider.GetParameter();
                paramUpdTexto_promocional.ParameterName = "Texto_promocional";
                paramUpdTexto_promocional.DbType = DbType.String;
                paramUpdTexto_promocional.Value = (object)Codigos_de_DescuentoDB.Texto_promocional ?? DBNull.Value;
                var paramUpdFecha_inicio_vigencia = _dataProvider.GetParameter();
                paramUpdFecha_inicio_vigencia.ParameterName = "Fecha_inicio_vigencia";
                paramUpdFecha_inicio_vigencia.DbType = DbType.DateTime;
                paramUpdFecha_inicio_vigencia.Value = (object)Codigos_de_DescuentoDB.Fecha_inicio_vigencia ?? DBNull.Value;
                var paramUpdFecha_fin_vigencia = _dataProvider.GetParameter();
                paramUpdFecha_fin_vigencia.ParameterName = "Fecha_fin_vigencia";
                paramUpdFecha_fin_vigencia.DbType = DbType.DateTime;
                paramUpdFecha_fin_vigencia.Value = (object)Codigos_de_DescuentoDB.Fecha_fin_vigencia ?? DBNull.Value;
                var paramUpdCantidad_maxima_de_referenciados = _dataProvider.GetParameter();
                paramUpdCantidad_maxima_de_referenciados.ParameterName = "Cantidad_maxima_de_referenciados";
                paramUpdCantidad_maxima_de_referenciados.DbType = DbType.Int32;
                paramUpdCantidad_maxima_de_referenciados.Value = (object)Codigos_de_DescuentoDB.Cantidad_maxima_de_referenciados ?? DBNull.Value;
                var paramUpdCodigo_de_descuento = _dataProvider.GetParameter();
                paramUpdCodigo_de_descuento.ParameterName = "Codigo_de_descuento";
                paramUpdCodigo_de_descuento.DbType = DbType.String;
                paramUpdCodigo_de_descuento.Value = (object)Codigos_de_DescuentoDB.Codigo_de_descuento ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)Codigos_de_DescuentoDB.Estatus ?? DBNull.Value;
                var paramUpdFecha_de_autorizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_autorizacion.ParameterName = "Fecha_de_autorizacion";
                paramUpdFecha_de_autorizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_autorizacion.Value = (object)Codigos_de_DescuentoDB.Fecha_de_autorizacion ?? DBNull.Value;
                var paramUpdHora_de_autorizacion = _dataProvider.GetParameter();
                paramUpdHora_de_autorizacion.ParameterName = "Hora_de_autorizacion";
                paramUpdHora_de_autorizacion.DbType = DbType.String;
                paramUpdHora_de_autorizacion.Value = (object)Codigos_de_DescuentoDB.Hora_de_autorizacion ?? DBNull.Value;
		var paramUpdUsuario_que_autoriza = _dataProvider.GetParameter();
                paramUpdUsuario_que_autoriza.ParameterName = "Usuario_que_autoriza";
                paramUpdUsuario_que_autoriza.DbType = DbType.Int32;
                paramUpdUsuario_que_autoriza.Value = (object)Codigos_de_DescuentoDB.Usuario_que_autoriza ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)Codigos_de_DescuentoDB.Observaciones ?? DBNull.Value;
		var paramUpdResultado = _dataProvider.GetParameter();
                paramUpdResultado.ParameterName = "Resultado";
                paramUpdResultado.DbType = DbType.Int32;
                paramUpdResultado.Value = (object)Codigos_de_DescuentoDB.Resultado ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCodigos_de_Descuento>("sp_UpdCodigos_de_Descuento" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Vendedor , paramUpdVendedor , paramUpdTipo_de_Descuento , paramUpdDescuento , paramUpdTexto_promocional , paramUpdFecha_inicio_vigencia , paramUpdFecha_fin_vigencia , paramUpdCantidad_maxima_de_referenciados , paramUpdCodigo_de_descuento , paramUpdEstatus , paramUpdFecha_de_autorizacion , paramUpdHora_de_autorizacion , paramUpdUsuario_que_autoriza , paramUpdObservaciones , paramUpdResultado ).FirstOrDefault();

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

