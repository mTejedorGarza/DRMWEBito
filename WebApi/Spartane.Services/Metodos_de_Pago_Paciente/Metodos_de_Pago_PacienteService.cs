using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Metodos_de_Pago_Paciente;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Metodos_de_Pago_Paciente
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Metodos_de_Pago_PacienteService : IMetodos_de_Pago_PacienteService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> _Metodos_de_Pago_PacienteRepository;
        #endregion

        #region Ctor
        public Metodos_de_Pago_PacienteService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> Metodos_de_Pago_PacienteRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Metodos_de_Pago_PacienteRepository = Metodos_de_Pago_PacienteRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Metodos_de_Pago_PacienteRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>("sp_SelAllMetodos_de_Pago_Paciente");
        }

        public IList<Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMetodos_de_Pago_Paciente_Complete>("sp_SelAllComplete_Metodos_de_Pago_Paciente");
            return data.Select(m => new Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Paciente_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Paciente.GetValueOrDefault(), Name = m.Paciente_Name }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Metodos_de_Pago_Paciente>("sp_ListSelCount_Metodos_de_Pago_Paciente", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMetodos_de_Pago_Paciente>("sp_ListSelAll_Metodos_de_Pago_Paciente", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente
                {
                    Folio = m.Metodos_de_Pago_Paciente_Folio,
                    Fecha_de_Registro = m.Metodos_de_Pago_Paciente_Fecha_de_Registro,
                    Hora_de_Registro = m.Metodos_de_Pago_Paciente_Hora_de_Registro,
                    Usuario_que_Registra = m.Metodos_de_Pago_Paciente_Usuario_que_Registra,
                    Paciente = m.Metodos_de_Pago_Paciente_Paciente,

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

        public IList<Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Metodos_de_Pago_PacienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Metodos_de_Pago_PacienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_PacientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMetodos_de_Pago_Paciente>("sp_ListSelAll_Metodos_de_Pago_Paciente", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Metodos_de_Pago_PacientePagingModel result = null;

            if (data != null)
            {
                result = new Metodos_de_Pago_PacientePagingModel
                {
                    Metodos_de_Pago_Pacientes =
                        data.Select(m => new Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente
                {
                    Folio = m.Metodos_de_Pago_Paciente_Folio
                    ,Fecha_de_Registro = m.Metodos_de_Pago_Paciente_Fecha_de_Registro
                    ,Hora_de_Registro = m.Metodos_de_Pago_Paciente_Hora_de_Registro
                    ,Usuario_que_Registra = m.Metodos_de_Pago_Paciente_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Metodos_de_Pago_Paciente_Usuario_que_Registra.GetValueOrDefault(), Name = m.Metodos_de_Pago_Paciente_Usuario_que_Registra_Name }
                    ,Paciente = m.Metodos_de_Pago_Paciente_Paciente
                    ,Paciente_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Metodos_de_Pago_Paciente_Paciente.GetValueOrDefault(), Name = m.Metodos_de_Pago_Paciente_Paciente_Name }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Metodos_de_Pago_PacienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente>("sp_GetMetodos_de_Pago_Paciente", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMetodos_de_Pago_Paciente>("sp_DelMetodos_de_Pago_Paciente", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente entity)
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

                var padrePaciente = _dataProvider.GetParameter();
                padrePaciente.ParameterName = "Paciente";
                padrePaciente.DbType = DbType.Int32;
                padrePaciente.Value = (object)entity.Paciente ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMetodos_de_Pago_Paciente>("sp_InsMetodos_de_Pago_Paciente" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padrePaciente
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

        public int Update(Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente entity)
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

                var paramUpdPaciente = _dataProvider.GetParameter();
                paramUpdPaciente.ParameterName = "Paciente";
                paramUpdPaciente.DbType = DbType.Int32;
                paramUpdPaciente.Value = (object)entity.Paciente ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMetodos_de_Pago_Paciente>("sp_UpdMetodos_de_Pago_Paciente" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdPaciente ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Metodos_de_Pago_Paciente.Metodos_de_Pago_Paciente Metodos_de_Pago_PacienteDB = GetByKey(entity.Folio, false);
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
		var paramUpdPaciente = _dataProvider.GetParameter();
                paramUpdPaciente.ParameterName = "Paciente";
                paramUpdPaciente.DbType = DbType.Int32;
                paramUpdPaciente.Value = (object)entity.Paciente ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMetodos_de_Pago_Paciente>("sp_UpdMetodos_de_Pago_Paciente" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdPaciente ).FirstOrDefault();

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

