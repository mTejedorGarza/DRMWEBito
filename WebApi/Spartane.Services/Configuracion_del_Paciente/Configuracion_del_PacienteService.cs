using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Configuracion_del_Paciente;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Configuracion_del_Paciente
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Configuracion_del_PacienteService : IConfiguracion_del_PacienteService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente> _Configuracion_del_PacienteRepository;
        #endregion

        #region Ctor
        public Configuracion_del_PacienteService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente> Configuracion_del_PacienteRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Configuracion_del_PacienteRepository = Configuracion_del_PacienteRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Configuracion_del_PacienteRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente>("sp_SelAllConfiguracion_del_Paciente");
        }

        public IList<Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallConfiguracion_del_Paciente_Complete>("sp_SelAllComplete_Configuracion_del_Paciente");
            return data.Select(m => new Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_Registrado_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_Registrado.GetValueOrDefault(), Name = m.Usuario_Registrado_Name }
                ,Rol = m.Rol
                ,Token = m.Token
                ,Android = m.Android.GetValueOrDefault()
                ,iOS = m.iOS.GetValueOrDefault()
                ,Permite_notificaciones_por_email = m.Permite_notificaciones_por_email.GetValueOrDefault()
                ,Permite_notificaciones_push = m.Permite_notificaciones_push.GetValueOrDefault()


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Configuracion_del_Paciente>("sp_ListSelCount_Configuracion_del_Paciente", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllConfiguracion_del_Paciente>("sp_ListSelAll_Configuracion_del_Paciente", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente
                {
                    Folio = m.Configuracion_del_Paciente_Folio,
                    Fecha_de_Registro = m.Configuracion_del_Paciente_Fecha_de_Registro,
                    Hora_de_Registro = m.Configuracion_del_Paciente_Hora_de_Registro,
                    Usuario_Registrado = m.Configuracion_del_Paciente_Usuario_Registrado,
                    Rol = m.Configuracion_del_Paciente_Rol,
                    Token = m.Configuracion_del_Paciente_Token,
                    Android = m.Configuracion_del_Paciente_Android ?? false,
                    iOS = m.Configuracion_del_Paciente_iOS ?? false,
                    Permite_notificaciones_por_email = m.Configuracion_del_Paciente_Permite_notificaciones_por_email ?? false,
                    Permite_notificaciones_push = m.Configuracion_del_Paciente_Permite_notificaciones_push ?? false,

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

        public IList<Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Configuracion_del_PacienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Configuracion_del_PacienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_PacientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllConfiguracion_del_Paciente>("sp_ListSelAll_Configuracion_del_Paciente", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Configuracion_del_PacientePagingModel result = null;

            if (data != null)
            {
                result = new Configuracion_del_PacientePagingModel
                {
                    Configuracion_del_Pacientes =
                        data.Select(m => new Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente
                {
                    Folio = m.Configuracion_del_Paciente_Folio
                    ,Fecha_de_Registro = m.Configuracion_del_Paciente_Fecha_de_Registro
                    ,Hora_de_Registro = m.Configuracion_del_Paciente_Hora_de_Registro
                    ,Usuario_Registrado = m.Configuracion_del_Paciente_Usuario_Registrado
                    ,Usuario_Registrado_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Configuracion_del_Paciente_Usuario_Registrado.GetValueOrDefault(), Name = m.Configuracion_del_Paciente_Usuario_Registrado_Name }
                    ,Rol = m.Configuracion_del_Paciente_Rol
                    ,Token = m.Configuracion_del_Paciente_Token
                    ,Android = m.Configuracion_del_Paciente_Android ?? false
                    ,iOS = m.Configuracion_del_Paciente_iOS ?? false
                    ,Permite_notificaciones_por_email = m.Configuracion_del_Paciente_Permite_notificaciones_por_email ?? false
                    ,Permite_notificaciones_push = m.Configuracion_del_Paciente_Permite_notificaciones_push ?? false

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Configuracion_del_PacienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente>("sp_GetConfiguracion_del_Paciente", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelConfiguracion_del_Paciente>("sp_DelConfiguracion_del_Paciente", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente entity)
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
                var padreUsuario_Registrado = _dataProvider.GetParameter();
                padreUsuario_Registrado.ParameterName = "Usuario_Registrado";
                padreUsuario_Registrado.DbType = DbType.Int32;
                padreUsuario_Registrado.Value = (object)entity.Usuario_Registrado ?? DBNull.Value;

                var padreRol = _dataProvider.GetParameter();
                padreRol.ParameterName = "Rol";
                padreRol.DbType = DbType.String;
                padreRol.Value = (object)entity.Rol ?? DBNull.Value;
                var padreToken = _dataProvider.GetParameter();
                padreToken.ParameterName = "Token";
                padreToken.DbType = DbType.String;
                padreToken.Value = (object)entity.Token ?? DBNull.Value;
                var padreAndroid = _dataProvider.GetParameter();
                padreAndroid.ParameterName = "Android";
                padreAndroid.DbType = DbType.Boolean;
                padreAndroid.Value = (object)entity.Android ?? DBNull.Value;
                var padreiOS = _dataProvider.GetParameter();
                padreiOS.ParameterName = "iOS";
                padreiOS.DbType = DbType.Boolean;
                padreiOS.Value = (object)entity.iOS ?? DBNull.Value;
                var padrePermite_notificaciones_por_email = _dataProvider.GetParameter();
                padrePermite_notificaciones_por_email.ParameterName = "Permite_notificaciones_por_email";
                padrePermite_notificaciones_por_email.DbType = DbType.Boolean;
                padrePermite_notificaciones_por_email.Value = (object)entity.Permite_notificaciones_por_email ?? DBNull.Value;
                var padrePermite_notificaciones_push = _dataProvider.GetParameter();
                padrePermite_notificaciones_push.ParameterName = "Permite_notificaciones_push";
                padrePermite_notificaciones_push.DbType = DbType.Boolean;
                padrePermite_notificaciones_push.Value = (object)entity.Permite_notificaciones_push ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsConfiguracion_del_Paciente>("sp_InsConfiguracion_del_Paciente" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_Registrado
, padreRol
, padreToken
, padreAndroid
, padreiOS
, padrePermite_notificaciones_por_email
, padrePermite_notificaciones_push
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

        public int Update(Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente entity)
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
                var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)entity.Usuario_Registrado ?? DBNull.Value;

                var paramUpdRol = _dataProvider.GetParameter();
                paramUpdRol.ParameterName = "Rol";
                paramUpdRol.DbType = DbType.String;
                paramUpdRol.Value = (object)entity.Rol ?? DBNull.Value;
                var paramUpdToken = _dataProvider.GetParameter();
                paramUpdToken.ParameterName = "Token";
                paramUpdToken.DbType = DbType.String;
                paramUpdToken.Value = (object)entity.Token ?? DBNull.Value;
                var paramUpdAndroid = _dataProvider.GetParameter();
                paramUpdAndroid.ParameterName = "Android";
                paramUpdAndroid.DbType = DbType.Boolean;
                paramUpdAndroid.Value = (object)entity.Android ?? DBNull.Value;
                var paramUpdiOS = _dataProvider.GetParameter();
                paramUpdiOS.ParameterName = "iOS";
                paramUpdiOS.DbType = DbType.Boolean;
                paramUpdiOS.Value = (object)entity.iOS ?? DBNull.Value;
                var paramUpdPermite_notificaciones_por_email = _dataProvider.GetParameter();
                paramUpdPermite_notificaciones_por_email.ParameterName = "Permite_notificaciones_por_email";
                paramUpdPermite_notificaciones_por_email.DbType = DbType.Boolean;
                paramUpdPermite_notificaciones_por_email.Value = (object)entity.Permite_notificaciones_por_email ?? DBNull.Value;
                var paramUpdPermite_notificaciones_push = _dataProvider.GetParameter();
                paramUpdPermite_notificaciones_push.ParameterName = "Permite_notificaciones_push";
                paramUpdPermite_notificaciones_push.DbType = DbType.Boolean;
                paramUpdPermite_notificaciones_push.Value = (object)entity.Permite_notificaciones_push ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdConfiguracion_del_Paciente>("sp_UpdConfiguracion_del_Paciente" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_Registrado , paramUpdRol , paramUpdToken , paramUpdAndroid , paramUpdiOS , paramUpdPermite_notificaciones_por_email , paramUpdPermite_notificaciones_push ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Configuracion_del_Paciente.Configuracion_del_Paciente Configuracion_del_PacienteDB = GetByKey(entity.Folio, false);
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
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)entity.Usuario_Registrado ?? DBNull.Value;
                var paramUpdRol = _dataProvider.GetParameter();
                paramUpdRol.ParameterName = "Rol";
                paramUpdRol.DbType = DbType.String;
                paramUpdRol.Value = (object)entity.Rol ?? DBNull.Value;
                var paramUpdToken = _dataProvider.GetParameter();
                paramUpdToken.ParameterName = "Token";
                paramUpdToken.DbType = DbType.String;
                paramUpdToken.Value = (object)entity.Token ?? DBNull.Value;
                var paramUpdAndroid = _dataProvider.GetParameter();
                paramUpdAndroid.ParameterName = "Android";
                paramUpdAndroid.DbType = DbType.Boolean;
                paramUpdAndroid.Value = (object)entity.Android ?? DBNull.Value;
                var paramUpdiOS = _dataProvider.GetParameter();
                paramUpdiOS.ParameterName = "iOS";
                paramUpdiOS.DbType = DbType.Boolean;
                paramUpdiOS.Value = (object)entity.iOS ?? DBNull.Value;
                var paramUpdPermite_notificaciones_por_email = _dataProvider.GetParameter();
                paramUpdPermite_notificaciones_por_email.ParameterName = "Permite_notificaciones_por_email";
                paramUpdPermite_notificaciones_por_email.DbType = DbType.Boolean;
                paramUpdPermite_notificaciones_por_email.Value = (object)entity.Permite_notificaciones_por_email ?? DBNull.Value;
                var paramUpdPermite_notificaciones_push = _dataProvider.GetParameter();
                paramUpdPermite_notificaciones_push.ParameterName = "Permite_notificaciones_push";
                paramUpdPermite_notificaciones_push.DbType = DbType.Boolean;
                paramUpdPermite_notificaciones_push.Value = (object)entity.Permite_notificaciones_push ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdConfiguracion_del_Paciente>("sp_UpdConfiguracion_del_Paciente" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_Registrado , paramUpdRol , paramUpdToken , paramUpdAndroid , paramUpdiOS , paramUpdPermite_notificaciones_por_email , paramUpdPermite_notificaciones_push ).FirstOrDefault();

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

