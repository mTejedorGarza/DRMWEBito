using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Registro_Beneficiarios_Titulares_Empresa
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Registro_Beneficiarios_Titulares_EmpresaService : IDetalle_Registro_Beneficiarios_Titulares_EmpresaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa> _Detalle_Registro_Beneficiarios_Titulares_EmpresaRepository;
        #endregion

        #region Ctor
        public Detalle_Registro_Beneficiarios_Titulares_EmpresaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa> Detalle_Registro_Beneficiarios_Titulares_EmpresaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Registro_Beneficiarios_Titulares_EmpresaRepository = Detalle_Registro_Beneficiarios_Titulares_EmpresaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Registro_Beneficiarios_Titulares_EmpresaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa>("sp_SelAllDetalle_Registro_Beneficiarios_Titulares_Empresa");
        }

        public IList<Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Registro_Beneficiarios_Titulares_Empresa_Complete>("sp_SelAllComplete_Detalle_Registro_Beneficiarios_Titulares_Empresa");
            return data.Select(m => new Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa
            {
                Folio = m.Folio
                ,Folio_Empresa = m.Folio_Empresa
                ,Numero_de_Empleado_Titular = m.Numero_de_Empleado_Titular
                ,Usuario_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario.GetValueOrDefault(), Name = m.Usuario_Name }
                ,Nombres = m.Nombres
                ,Apellido_Paterno = m.Apellido_Paterno
                ,Apellido_Materno = m.Apellido_Materno
                ,Nombre_Completo = m.Nombre_Completo
                ,Email = m.Email
                ,Activo = m.Activo.GetValueOrDefault()
                ,Suscripcion_Planes_de_Suscripcion = new Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion() { Folio = m.Suscripcion.GetValueOrDefault(), Nombre_del_Plan = m.Suscripcion_Nombre_del_Plan }
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Registro_Beneficiarios_Titulares_Empresa>("sp_ListSelCount_Detalle_Registro_Beneficiarios_Titulares_Empresa", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Registro_Beneficiarios_Titulares_Empresa>("sp_ListSelAll_Detalle_Registro_Beneficiarios_Titulares_Empresa", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa
                {
                    Folio = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Folio,
                    Folio_Empresa = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Folio_Empresa,
                    Numero_de_Empleado_Titular = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Numero_de_Empleado_Titular,
                    Usuario = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Usuario,
                    Nombres = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Nombres,
                    Apellido_Paterno = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Apellido_Paterno,
                    Apellido_Materno = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Apellido_Materno,
                    Nombre_Completo = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Nombre_Completo,
                    Email = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Email,
                    Activo = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Activo ?? false,
                    Suscripcion = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Suscripcion,
                    Estatus = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Estatus,

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

        public IList<Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Registro_Beneficiarios_Titulares_EmpresaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Registro_Beneficiarios_Titulares_EmpresaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_EmpresaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Registro_Beneficiarios_Titulares_Empresa>("sp_ListSelAll_Detalle_Registro_Beneficiarios_Titulares_Empresa", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Registro_Beneficiarios_Titulares_EmpresaPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Registro_Beneficiarios_Titulares_EmpresaPagingModel
                {
                    Detalle_Registro_Beneficiarios_Titulares_Empresas =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa
                {
                    Folio = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Folio
                    ,Folio_Empresa = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Folio_Empresa
                    ,Numero_de_Empleado_Titular = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Numero_de_Empleado_Titular
                    ,Usuario = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Usuario
                    ,Usuario_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Usuario.GetValueOrDefault(), Name = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Usuario_Name }
                    ,Nombres = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Nombres
                    ,Apellido_Paterno = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Apellido_Paterno
                    ,Apellido_Materno = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Apellido_Materno
                    ,Nombre_Completo = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Nombre_Completo
                    ,Email = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Email
                    ,Activo = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Activo ?? false
                    ,Suscripcion = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Suscripcion
                    ,Suscripcion_Planes_de_Suscripcion = new Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion() { Folio = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Suscripcion.GetValueOrDefault(), Nombre_del_Plan = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Suscripcion_Nombre_del_Plan }
                    ,Estatus = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Estatus.GetValueOrDefault(), Descripcion = m.Detalle_Registro_Beneficiarios_Titulares_Empresa_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Registro_Beneficiarios_Titulares_EmpresaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa>("sp_GetDetalle_Registro_Beneficiarios_Titulares_Empresa", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Registro_Beneficiarios_Titulares_Empresa>("sp_DelDetalle_Registro_Beneficiarios_Titulares_Empresa", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Empresa = _dataProvider.GetParameter();
                padreFolio_Empresa.ParameterName = "Folio_Empresa";
                padreFolio_Empresa.DbType = DbType.Int32;
                padreFolio_Empresa.Value = (object)entity.Folio_Empresa ?? DBNull.Value;
                var padreNumero_de_Empleado_Titular = _dataProvider.GetParameter();
                padreNumero_de_Empleado_Titular.ParameterName = "Numero_de_Empleado_Titular";
                padreNumero_de_Empleado_Titular.DbType = DbType.String;
                padreNumero_de_Empleado_Titular.Value = (object)entity.Numero_de_Empleado_Titular ?? DBNull.Value;
                var padreUsuario = _dataProvider.GetParameter();
                padreUsuario.ParameterName = "Usuario";
                padreUsuario.DbType = DbType.Int32;
                padreUsuario.Value = (object)entity.Usuario ?? DBNull.Value;

                var padreNombres = _dataProvider.GetParameter();
                padreNombres.ParameterName = "Nombres";
                padreNombres.DbType = DbType.String;
                padreNombres.Value = (object)entity.Nombres ?? DBNull.Value;
                var padreApellido_Paterno = _dataProvider.GetParameter();
                padreApellido_Paterno.ParameterName = "Apellido_Paterno";
                padreApellido_Paterno.DbType = DbType.String;
                padreApellido_Paterno.Value = (object)entity.Apellido_Paterno ?? DBNull.Value;
                var padreApellido_Materno = _dataProvider.GetParameter();
                padreApellido_Materno.ParameterName = "Apellido_Materno";
                padreApellido_Materno.DbType = DbType.String;
                padreApellido_Materno.Value = (object)entity.Apellido_Materno ?? DBNull.Value;
                var padreNombre_Completo = _dataProvider.GetParameter();
                padreNombre_Completo.ParameterName = "Nombre_Completo";
                padreNombre_Completo.DbType = DbType.String;
                padreNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var padreEmail = _dataProvider.GetParameter();
                padreEmail.ParameterName = "Email";
                padreEmail.DbType = DbType.String;
                padreEmail.Value = (object)entity.Email ?? DBNull.Value;
                var padreActivo = _dataProvider.GetParameter();
                padreActivo.ParameterName = "Activo";
                padreActivo.DbType = DbType.Boolean;
                padreActivo.Value = (object)entity.Activo ?? DBNull.Value;
                var padreSuscripcion = _dataProvider.GetParameter();
                padreSuscripcion.ParameterName = "Suscripcion";
                padreSuscripcion.DbType = DbType.Int32;
                padreSuscripcion.Value = (object)entity.Suscripcion ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Registro_Beneficiarios_Titulares_Empresa>("sp_InsDetalle_Registro_Beneficiarios_Titulares_Empresa" , padreFolio_Empresa
, padreNumero_de_Empleado_Titular
, padreUsuario
, padreNombres
, padreApellido_Paterno
, padreApellido_Materno
, padreNombre_Completo
, padreEmail
, padreActivo
, padreSuscripcion
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

        public int Update(Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Empresa = _dataProvider.GetParameter();
                paramUpdFolio_Empresa.ParameterName = "Folio_Empresa";
                paramUpdFolio_Empresa.DbType = DbType.Int32;
                paramUpdFolio_Empresa.Value = (object)entity.Folio_Empresa ?? DBNull.Value;
                var paramUpdNumero_de_Empleado_Titular = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado_Titular.ParameterName = "Numero_de_Empleado_Titular";
                paramUpdNumero_de_Empleado_Titular.DbType = DbType.String;
                paramUpdNumero_de_Empleado_Titular.Value = (object)entity.Numero_de_Empleado_Titular ?? DBNull.Value;
                var paramUpdUsuario = _dataProvider.GetParameter();
                paramUpdUsuario.ParameterName = "Usuario";
                paramUpdUsuario.DbType = DbType.Int32;
                paramUpdUsuario.Value = (object)entity.Usuario ?? DBNull.Value;

                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)entity.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)entity.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)entity.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)entity.Email ?? DBNull.Value;
                var paramUpdActivo = _dataProvider.GetParameter();
                paramUpdActivo.ParameterName = "Activo";
                paramUpdActivo.DbType = DbType.Boolean;
                paramUpdActivo.Value = (object)entity.Activo ?? DBNull.Value;
                var paramUpdSuscripcion = _dataProvider.GetParameter();
                paramUpdSuscripcion.ParameterName = "Suscripcion";
                paramUpdSuscripcion.DbType = DbType.Int32;
                paramUpdSuscripcion.Value = (object)entity.Suscripcion ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Registro_Beneficiarios_Titulares_Empresa>("sp_UpdDetalle_Registro_Beneficiarios_Titulares_Empresa" , paramUpdFolio , paramUpdFolio_Empresa , paramUpdNumero_de_Empleado_Titular , paramUpdUsuario , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdEmail , paramUpdActivo , paramUpdSuscripcion , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Titulares_Empresa.Detalle_Registro_Beneficiarios_Titulares_Empresa Detalle_Registro_Beneficiarios_Titulares_EmpresaDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Empresa = _dataProvider.GetParameter();
                paramUpdFolio_Empresa.ParameterName = "Folio_Empresa";
                paramUpdFolio_Empresa.DbType = DbType.Int32;
                paramUpdFolio_Empresa.Value = (object)entity.Folio_Empresa ?? DBNull.Value;
                var paramUpdNumero_de_Empleado_Titular = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado_Titular.ParameterName = "Numero_de_Empleado_Titular";
                paramUpdNumero_de_Empleado_Titular.DbType = DbType.String;
                paramUpdNumero_de_Empleado_Titular.Value = (object)entity.Numero_de_Empleado_Titular ?? DBNull.Value;
		var paramUpdUsuario = _dataProvider.GetParameter();
                paramUpdUsuario.ParameterName = "Usuario";
                paramUpdUsuario.DbType = DbType.Int32;
                paramUpdUsuario.Value = (object)entity.Usuario ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)entity.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)entity.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)entity.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)entity.Email ?? DBNull.Value;
                var paramUpdActivo = _dataProvider.GetParameter();
                paramUpdActivo.ParameterName = "Activo";
                paramUpdActivo.DbType = DbType.Boolean;
                paramUpdActivo.Value = (object)entity.Activo ?? DBNull.Value;
		var paramUpdSuscripcion = _dataProvider.GetParameter();
                paramUpdSuscripcion.ParameterName = "Suscripcion";
                paramUpdSuscripcion.DbType = DbType.Int32;
                paramUpdSuscripcion.Value = (object)entity.Suscripcion ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Registro_Beneficiarios_Titulares_Empresa>("sp_UpdDetalle_Registro_Beneficiarios_Titulares_Empresa" , paramUpdFolio , paramUpdFolio_Empresa , paramUpdNumero_de_Empleado_Titular , paramUpdUsuario , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdEmail , paramUpdActivo , paramUpdSuscripcion , paramUpdEstatus ).FirstOrDefault();

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

