using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;
using Openpay;
using Openpay.Entities.Request;
using System.Configuration;
using System.Linq.Expressions;
using Openpay.Entities;

namespace Spartane.Services.Detalle_Pagos_Pacientes_OpenPay
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Pagos_Pacientes_OpenPayService : IDetalle_Pagos_Pacientes_OpenPayService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> _Detalle_Pagos_Pacientes_OpenPayRepository;
        #endregion

        #region Ctor
        public Detalle_Pagos_Pacientes_OpenPayService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> Detalle_Pagos_Pacientes_OpenPayRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Pagos_Pacientes_OpenPayRepository = Detalle_Pagos_Pacientes_OpenPayRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Pagos_Pacientes_OpenPayRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay>("sp_SelAllDetalle_Pagos_Pacientes_OpenPay");
        }

        public IList<Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Pagos_Pacientes_OpenPay_Complete>("sp_SelAllComplete_Detalle_Pagos_Pacientes_OpenPay");
            return data.Select(m => new Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay
            {
                Folio = m.Folio
                ,FolioPacientes = m.FolioPacientes
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Fecha_de_Pago = m.Fecha_de_Pago
                ,Hora_de_Pago = m.Hora_de_Pago
                ,TokenID = m.TokenID
                ,Importe = m.Importe
                ,Concepto = m.Concepto
                ,Forma_de_pago_Formas_de_Pago = new Core.Classes.Formas_de_Pago.Formas_de_Pago() { Clave = m.Forma_de_pago.GetValueOrDefault(), Nombre = m.Forma_de_pago_Nombre }
                ,Autorizacion = m.Autorizacion
                ,Nombre = m.Nombre
                ,Apellidos = m.Apellidos
                ,Telefono = m.Telefono
                ,Email = m.Email
                ,DeviceID = m.DeviceID
                ,UsaPuntos = m.UsaPuntos.GetValueOrDefault()
                ,PuntosID = m.PuntosID
                ,Estatus_Estatus_de_Pago = new Core.Classes.Estatus_de_Pago.Estatus_de_Pago() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Pagos_Pacientes_OpenPay>("sp_ListSelCount_Detalle_Pagos_Pacientes_OpenPay", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Pagos_Pacientes_OpenPay>("sp_ListSelAll_Detalle_Pagos_Pacientes_OpenPay", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay
                {
                    Folio = m.Detalle_Pagos_Pacientes_OpenPay_Folio,
                    FolioPacientes = m.Detalle_Pagos_Pacientes_OpenPay_FolioPacientes,
                    Usuario_que_Registra = m.Detalle_Pagos_Pacientes_OpenPay_Usuario_que_Registra,
                    Fecha_de_Pago = m.Detalle_Pagos_Pacientes_OpenPay_Fecha_de_Pago,
                    Hora_de_Pago = m.Detalle_Pagos_Pacientes_OpenPay_Hora_de_Pago,
                    TokenID = m.Detalle_Pagos_Pacientes_OpenPay_TokenID,
                    Importe = m.Detalle_Pagos_Pacientes_OpenPay_Importe,
                    Concepto = m.Detalle_Pagos_Pacientes_OpenPay_Concepto,
                    Forma_de_pago = m.Detalle_Pagos_Pacientes_OpenPay_Forma_de_pago,
                    Autorizacion = m.Detalle_Pagos_Pacientes_OpenPay_Autorizacion,
                    Nombre = m.Detalle_Pagos_Pacientes_OpenPay_Nombre,
                    Apellidos = m.Detalle_Pagos_Pacientes_OpenPay_Apellidos,
                    Telefono = m.Detalle_Pagos_Pacientes_OpenPay_Telefono,
                    Email = m.Detalle_Pagos_Pacientes_OpenPay_Email,
                    DeviceID = m.Detalle_Pagos_Pacientes_OpenPay_DeviceID,
                    UsaPuntos = m.Detalle_Pagos_Pacientes_OpenPay_UsaPuntos ?? false,
                    PuntosID = m.Detalle_Pagos_Pacientes_OpenPay_PuntosID,
                    Estatus = m.Detalle_Pagos_Pacientes_OpenPay_Estatus,

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

        public IList<Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Pagos_Pacientes_OpenPayRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Pagos_Pacientes_OpenPayRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPayPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Pagos_Pacientes_OpenPay>("sp_ListSelAll_Detalle_Pagos_Pacientes_OpenPay", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Pagos_Pacientes_OpenPayPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Pagos_Pacientes_OpenPayPagingModel
                {
                    Detalle_Pagos_Pacientes_OpenPays =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay
                {
                    Folio = m.Detalle_Pagos_Pacientes_OpenPay_Folio
                    ,FolioPacientes = m.Detalle_Pagos_Pacientes_OpenPay_FolioPacientes
                    ,Usuario_que_Registra = m.Detalle_Pagos_Pacientes_OpenPay_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Detalle_Pagos_Pacientes_OpenPay_Usuario_que_Registra.GetValueOrDefault(), Name = m.Detalle_Pagos_Pacientes_OpenPay_Usuario_que_Registra_Name }
                    ,Fecha_de_Pago = m.Detalle_Pagos_Pacientes_OpenPay_Fecha_de_Pago
                    ,Hora_de_Pago = m.Detalle_Pagos_Pacientes_OpenPay_Hora_de_Pago
                    ,TokenID = m.Detalle_Pagos_Pacientes_OpenPay_TokenID
                    ,Importe = m.Detalle_Pagos_Pacientes_OpenPay_Importe
                    ,Concepto = m.Detalle_Pagos_Pacientes_OpenPay_Concepto
                    ,Forma_de_pago = m.Detalle_Pagos_Pacientes_OpenPay_Forma_de_pago
                    ,Forma_de_pago_Formas_de_Pago = new Core.Classes.Formas_de_Pago.Formas_de_Pago() { Clave = m.Detalle_Pagos_Pacientes_OpenPay_Forma_de_pago.GetValueOrDefault(), Nombre = m.Detalle_Pagos_Pacientes_OpenPay_Forma_de_pago_Nombre }
                    ,Autorizacion = m.Detalle_Pagos_Pacientes_OpenPay_Autorizacion
                    ,Nombre = m.Detalle_Pagos_Pacientes_OpenPay_Nombre
                    ,Apellidos = m.Detalle_Pagos_Pacientes_OpenPay_Apellidos
                    ,Telefono = m.Detalle_Pagos_Pacientes_OpenPay_Telefono
                    ,Email = m.Detalle_Pagos_Pacientes_OpenPay_Email
                    ,DeviceID = m.Detalle_Pagos_Pacientes_OpenPay_DeviceID
                    ,UsaPuntos = m.Detalle_Pagos_Pacientes_OpenPay_UsaPuntos ?? false
                    ,PuntosID = m.Detalle_Pagos_Pacientes_OpenPay_PuntosID
                    ,Estatus = m.Detalle_Pagos_Pacientes_OpenPay_Estatus
                    ,Estatus_Estatus_de_Pago = new Core.Classes.Estatus_de_Pago.Estatus_de_Pago() { Clave = m.Detalle_Pagos_Pacientes_OpenPay_Estatus.GetValueOrDefault(), Descripcion = m.Detalle_Pagos_Pacientes_OpenPay_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Pagos_Pacientes_OpenPayRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay>("sp_GetDetalle_Pagos_Pacientes_OpenPay", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Pagos_Pacientes_OpenPay>("sp_DelDetalle_Pagos_Pacientes_OpenPay", padreKey).FirstOrDefault();
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

        /*CODMANINI-ADD*/
        public string PagarOpenPay(Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay entity)
        {
            string sReturnValue = string.Empty;
            try
            {
                string apiKey = ConfigurationManager.AppSettings["openpay_apikey_private"];
                string merchantId = ConfigurationManager.AppSettings["openpay_id"];
                bool production = ConfigurationManager.AppSettings["openpay_env"] == "production";
                OpenpayAPI openpayAPI = new OpenpayAPI(apiKey, merchantId, production);

                Customer customer = new Customer();
                customer.Name = entity.Nombre;
                customer.LastName = entity.Apellidos;
                customer.PhoneNumber = entity.Telefono;
                customer.Email = entity.Email;

                ChargeRequest request = new ChargeRequest();
                request.Method = "card";
                request.SourceId = entity.TokenID;
                request.Description = entity.Concepto;
                request.Amount = Convert.ToDecimal(entity.Importe);
                request.DeviceSessionId = entity.DeviceID;
                request.Customer = customer;

                Charge charge = openpayAPI.ChargeService.Create(request);
                sReturnValue = charge.Authorization;
            }
            catch (Exception ex)
            {
                sReturnValue = "-1";

            }
            return sReturnValue;
        }
        /*CODMANFIN-ADD*/


        public int Insert(Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay entity)
        {
            int rta;
            try
            {
                /*CODMANINI-ADD*/
                if ((entity.Forma_de_pago == 1 || entity.Forma_de_pago == 2) && entity.Estatus == 2 && entity.Importe > 0)
                {
                    entity.Autorizacion = PagarOpenPay(entity);
                    if (entity.Autorizacion.Equals("-1"))
                    {
                        entity.Estatus = 4;
                    }
                    else
                    {
                        if (!entity.Autorizacion.Equals("0"))
                            entity.Estatus = 1;
                    }
                }
                /*CODMANFIN-ADD*/
                var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolioPacientes = _dataProvider.GetParameter();
                padreFolioPacientes.ParameterName = "FolioPacientes";
                padreFolioPacientes.DbType = DbType.Int32;
                padreFolioPacientes.Value = (object)entity.FolioPacientes ?? DBNull.Value;
                var padreUsuario_que_Registra = _dataProvider.GetParameter();
                padreUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                padreUsuario_que_Registra.DbType = DbType.Int32;
                padreUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var padreFecha_de_Pago = _dataProvider.GetParameter();
                padreFecha_de_Pago.ParameterName = "Fecha_de_Pago";
                padreFecha_de_Pago.DbType = DbType.DateTime;
                padreFecha_de_Pago.Value = (object)entity.Fecha_de_Pago ?? DBNull.Value;

                var padreHora_de_Pago = _dataProvider.GetParameter();
                padreHora_de_Pago.ParameterName = "Hora_de_Pago";
                padreHora_de_Pago.DbType = DbType.String;
                padreHora_de_Pago.Value = (object)entity.Hora_de_Pago ?? DBNull.Value;
                var padreTokenID = _dataProvider.GetParameter();
                padreTokenID.ParameterName = "TokenID";
                padreTokenID.DbType = DbType.String;
                padreTokenID.Value = (object)entity.TokenID ?? DBNull.Value;
                var padreImporte = _dataProvider.GetParameter();
                padreImporte.ParameterName = "Importe";
                padreImporte.DbType = DbType.Decimal;
                padreImporte.Value = (object)entity.Importe ?? DBNull.Value;

                var padreConcepto = _dataProvider.GetParameter();
                padreConcepto.ParameterName = "Concepto";
                padreConcepto.DbType = DbType.String;
                padreConcepto.Value = (object)entity.Concepto ?? DBNull.Value;
                var padreForma_de_pago = _dataProvider.GetParameter();
                padreForma_de_pago.ParameterName = "Forma_de_pago";
                padreForma_de_pago.DbType = DbType.Int32;
                padreForma_de_pago.Value = (object)entity.Forma_de_pago ?? DBNull.Value;

                var padreAutorizacion = _dataProvider.GetParameter();
                padreAutorizacion.ParameterName = "Autorizacion";
                padreAutorizacion.DbType = DbType.String;
                padreAutorizacion.Value = (object)entity.Autorizacion ?? DBNull.Value;
                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.String;
                padreNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var padreApellidos = _dataProvider.GetParameter();
                padreApellidos.ParameterName = "Apellidos";
                padreApellidos.DbType = DbType.String;
                padreApellidos.Value = (object)entity.Apellidos ?? DBNull.Value;
                var padreTelefono = _dataProvider.GetParameter();
                padreTelefono.ParameterName = "Telefono";
                padreTelefono.DbType = DbType.String;
                padreTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var padreEmail = _dataProvider.GetParameter();
                padreEmail.ParameterName = "Email";
                padreEmail.DbType = DbType.String;
                padreEmail.Value = (object)entity.Email ?? DBNull.Value;
                var padreDeviceID = _dataProvider.GetParameter();
                padreDeviceID.ParameterName = "DeviceID";
                padreDeviceID.DbType = DbType.String;
                padreDeviceID.Value = (object)entity.DeviceID ?? DBNull.Value;
                var padreUsaPuntos = _dataProvider.GetParameter();
                padreUsaPuntos.ParameterName = "UsaPuntos";
                padreUsaPuntos.DbType = DbType.Boolean;
                padreUsaPuntos.Value = (object)entity.UsaPuntos ?? DBNull.Value;
                var padrePuntosID = _dataProvider.GetParameter();
                padrePuntosID.ParameterName = "PuntosID";
                padrePuntosID.DbType = DbType.String;
                padrePuntosID.Value = (object)entity.PuntosID ?? DBNull.Value;
                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Pagos_Pacientes_OpenPay>("sp_InsDetalle_Pagos_Pacientes_OpenPay" , padreFolioPacientes
, padreUsuario_que_Registra
, padreFecha_de_Pago
, padreHora_de_Pago
, padreTokenID
, padreImporte
, padreConcepto
, padreForma_de_pago
, padreAutorizacion
, padreNombre
, padreApellidos
, padreTelefono
, padreEmail
, padreDeviceID
, padreUsaPuntos
, padrePuntosID
, padreEstatus
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

        public int Update(Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolioPacientes = _dataProvider.GetParameter();
                paramUpdFolioPacientes.ParameterName = "FolioPacientes";
                paramUpdFolioPacientes.DbType = DbType.Int32;
                paramUpdFolioPacientes.Value = (object)entity.FolioPacientes ?? DBNull.Value;
                var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var paramUpdFecha_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_de_Pago.ParameterName = "Fecha_de_Pago";
                paramUpdFecha_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_de_Pago.Value = (object)entity.Fecha_de_Pago ?? DBNull.Value;

                var paramUpdHora_de_Pago = _dataProvider.GetParameter();
                paramUpdHora_de_Pago.ParameterName = "Hora_de_Pago";
                paramUpdHora_de_Pago.DbType = DbType.String;
                paramUpdHora_de_Pago.Value = (object)entity.Hora_de_Pago ?? DBNull.Value;
                var paramUpdTokenID = _dataProvider.GetParameter();
                paramUpdTokenID.ParameterName = "TokenID";
                paramUpdTokenID.DbType = DbType.String;
                paramUpdTokenID.Value = (object)entity.TokenID ?? DBNull.Value;
                var paramUpdImporte = _dataProvider.GetParameter();
                paramUpdImporte.ParameterName = "Importe";
                paramUpdImporte.DbType = DbType.Decimal;
                paramUpdImporte.Value = (object)entity.Importe ?? DBNull.Value;

                var paramUpdConcepto = _dataProvider.GetParameter();
                paramUpdConcepto.ParameterName = "Concepto";
                paramUpdConcepto.DbType = DbType.String;
                paramUpdConcepto.Value = (object)entity.Concepto ?? DBNull.Value;
                var paramUpdForma_de_pago = _dataProvider.GetParameter();
                paramUpdForma_de_pago.ParameterName = "Forma_de_pago";
                paramUpdForma_de_pago.DbType = DbType.Int32;
                paramUpdForma_de_pago.Value = (object)entity.Forma_de_pago ?? DBNull.Value;

                var paramUpdAutorizacion = _dataProvider.GetParameter();
                paramUpdAutorizacion.ParameterName = "Autorizacion";
                paramUpdAutorizacion.DbType = DbType.String;
                paramUpdAutorizacion.Value = (object)entity.Autorizacion ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdApellidos = _dataProvider.GetParameter();
                paramUpdApellidos.ParameterName = "Apellidos";
                paramUpdApellidos.DbType = DbType.String;
                paramUpdApellidos.Value = (object)entity.Apellidos ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)entity.Email ?? DBNull.Value;
                var paramUpdDeviceID = _dataProvider.GetParameter();
                paramUpdDeviceID.ParameterName = "DeviceID";
                paramUpdDeviceID.DbType = DbType.String;
                paramUpdDeviceID.Value = (object)entity.DeviceID ?? DBNull.Value;
                var paramUpdUsaPuntos = _dataProvider.GetParameter();
                paramUpdUsaPuntos.ParameterName = "UsaPuntos";
                paramUpdUsaPuntos.DbType = DbType.Boolean;
                paramUpdUsaPuntos.Value = (object)entity.UsaPuntos ?? DBNull.Value;
                var paramUpdPuntosID = _dataProvider.GetParameter();
                paramUpdPuntosID.ParameterName = "PuntosID";
                paramUpdPuntosID.DbType = DbType.String;
                paramUpdPuntosID.Value = (object)entity.PuntosID ?? DBNull.Value;
                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Pagos_Pacientes_OpenPay>("sp_UpdDetalle_Pagos_Pacientes_OpenPay" , paramUpdFolio , paramUpdFolioPacientes , paramUpdUsuario_que_Registra , paramUpdFecha_de_Pago , paramUpdHora_de_Pago , paramUpdTokenID , paramUpdImporte , paramUpdConcepto , paramUpdForma_de_pago , paramUpdAutorizacion , paramUpdNombre , paramUpdApellidos , paramUpdTelefono , paramUpdEmail , paramUpdDeviceID , paramUpdUsaPuntos , paramUpdPuntosID , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Pagos_Pacientes_OpenPay.Detalle_Pagos_Pacientes_OpenPay Detalle_Pagos_Pacientes_OpenPayDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolioPacientes = _dataProvider.GetParameter();
                paramUpdFolioPacientes.ParameterName = "FolioPacientes";
                paramUpdFolioPacientes.DbType = DbType.Int32;
                paramUpdFolioPacientes.Value = (object)entity.FolioPacientes ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdFecha_de_Pago = _dataProvider.GetParameter();
                paramUpdFecha_de_Pago.ParameterName = "Fecha_de_Pago";
                paramUpdFecha_de_Pago.DbType = DbType.DateTime;
                paramUpdFecha_de_Pago.Value = (object)entity.Fecha_de_Pago ?? DBNull.Value;
                var paramUpdHora_de_Pago = _dataProvider.GetParameter();
                paramUpdHora_de_Pago.ParameterName = "Hora_de_Pago";
                paramUpdHora_de_Pago.DbType = DbType.String;
                paramUpdHora_de_Pago.Value = (object)entity.Hora_de_Pago ?? DBNull.Value;
                var paramUpdTokenID = _dataProvider.GetParameter();
                paramUpdTokenID.ParameterName = "TokenID";
                paramUpdTokenID.DbType = DbType.String;
                paramUpdTokenID.Value = (object)entity.TokenID ?? DBNull.Value;
                var paramUpdImporte = _dataProvider.GetParameter();
                paramUpdImporte.ParameterName = "Importe";
                paramUpdImporte.DbType = DbType.Decimal;
                paramUpdImporte.Value = (object)entity.Importe ?? DBNull.Value;
                var paramUpdConcepto = _dataProvider.GetParameter();
                paramUpdConcepto.ParameterName = "Concepto";
                paramUpdConcepto.DbType = DbType.String;
                paramUpdConcepto.Value = (object)entity.Concepto ?? DBNull.Value;
		var paramUpdForma_de_pago = _dataProvider.GetParameter();
                paramUpdForma_de_pago.ParameterName = "Forma_de_pago";
                paramUpdForma_de_pago.DbType = DbType.Int32;
                paramUpdForma_de_pago.Value = (object)entity.Forma_de_pago ?? DBNull.Value;
                var paramUpdAutorizacion = _dataProvider.GetParameter();
                paramUpdAutorizacion.ParameterName = "Autorizacion";
                paramUpdAutorizacion.DbType = DbType.String;
                paramUpdAutorizacion.Value = (object)entity.Autorizacion ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdApellidos = _dataProvider.GetParameter();
                paramUpdApellidos.ParameterName = "Apellidos";
                paramUpdApellidos.DbType = DbType.String;
                paramUpdApellidos.Value = (object)entity.Apellidos ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)entity.Email ?? DBNull.Value;
                var paramUpdDeviceID = _dataProvider.GetParameter();
                paramUpdDeviceID.ParameterName = "DeviceID";
                paramUpdDeviceID.DbType = DbType.String;
                paramUpdDeviceID.Value = (object)entity.DeviceID ?? DBNull.Value;
                var paramUpdUsaPuntos = _dataProvider.GetParameter();
                paramUpdUsaPuntos.ParameterName = "UsaPuntos";
                paramUpdUsaPuntos.DbType = DbType.Boolean;
                paramUpdUsaPuntos.Value = (object)entity.UsaPuntos ?? DBNull.Value;
                var paramUpdPuntosID = _dataProvider.GetParameter();
                paramUpdPuntosID.ParameterName = "PuntosID";
                paramUpdPuntosID.DbType = DbType.String;
                paramUpdPuntosID.Value = (object)entity.PuntosID ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Pagos_Pacientes_OpenPay>("sp_UpdDetalle_Pagos_Pacientes_OpenPay" , paramUpdFolio , paramUpdFolioPacientes , paramUpdUsuario_que_Registra , paramUpdFecha_de_Pago , paramUpdHora_de_Pago , paramUpdTokenID , paramUpdImporte , paramUpdConcepto , paramUpdForma_de_pago , paramUpdAutorizacion , paramUpdNombre , paramUpdApellidos , paramUpdTelefono , paramUpdEmail , paramUpdDeviceID , paramUpdUsaPuntos , paramUpdPuntosID , paramUpdEstatus ).FirstOrDefault();

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

