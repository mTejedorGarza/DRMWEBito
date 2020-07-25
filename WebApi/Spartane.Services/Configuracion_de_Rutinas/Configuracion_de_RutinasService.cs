using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Configuracion_de_Rutinas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Configuracion_de_Rutinas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Configuracion_de_RutinasService : IConfiguracion_de_RutinasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas> _Configuracion_de_RutinasRepository;
        #endregion

        #region Ctor
        public Configuracion_de_RutinasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas> Configuracion_de_RutinasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Configuracion_de_RutinasRepository = Configuracion_de_RutinasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Configuracion_de_RutinasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas>("sp_SelAllConfiguracion_de_Rutinas");
        }

        public IList<Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallConfiguracion_de_Rutinas_Complete>("sp_SelAllComplete_Configuracion_de_Rutinas");
            return data.Select(m => new Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina = new Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina() { Folio = m.Tipo_de_Rutina.GetValueOrDefault(), Tipo_de_Rutina = m.Tipo_de_Rutina_Tipo_de_Rutina }
                ,Nivel_de_Dificultad_Nivel_de_dificultad = new Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad() { Folio = m.Nivel_de_Dificultad.GetValueOrDefault(), Dificultad = m.Nivel_de_Dificultad_Dificultad }
                ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Sexo.GetValueOrDefault(), Descripcion = m.Sexo_Descripcion }
                ,Cantidad_de_ejercicios = m.Cantidad_de_ejercicios
                ,Cantidad_de_series = m.Cantidad_de_series
                ,Cantidad_de_repeticiones = m.Cantidad_de_repeticiones
                ,Descanso_segundos = m.Descanso_segundos
                ,Texto_Ejercicios = m.Texto_Ejercicios
                ,Lleva_Calentamiento = m.Lleva_Calentamiento.GetValueOrDefault()
                ,Lleva_Enfriamiento = m.Lleva_Enfriamiento.GetValueOrDefault()
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Configuracion_de_Rutinas>("sp_ListSelCount_Configuracion_de_Rutinas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllConfiguracion_de_Rutinas>("sp_ListSelAll_Configuracion_de_Rutinas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas
                {
                    Folio = m.Configuracion_de_Rutinas_Folio,
                    Fecha_de_Registro = m.Configuracion_de_Rutinas_Fecha_de_Registro,
                    Hora_de_Registro = m.Configuracion_de_Rutinas_Hora_de_Registro,
                    Usuario_que_Registra = m.Configuracion_de_Rutinas_Usuario_que_Registra,
                    Tipo_de_Rutina = m.Configuracion_de_Rutinas_Tipo_de_Rutina,
                    Nivel_de_Dificultad = m.Configuracion_de_Rutinas_Nivel_de_Dificultad,
                    Sexo = m.Configuracion_de_Rutinas_Sexo,
                    Cantidad_de_ejercicios = m.Configuracion_de_Rutinas_Cantidad_de_ejercicios,
                    Cantidad_de_series = m.Configuracion_de_Rutinas_Cantidad_de_series,
                    Cantidad_de_repeticiones = m.Configuracion_de_Rutinas_Cantidad_de_repeticiones,
                    Descanso_segundos = m.Configuracion_de_Rutinas_Descanso_segundos,
                    Texto_Ejercicios = m.Configuracion_de_Rutinas_Texto_Ejercicios,
                    Lleva_Calentamiento = m.Configuracion_de_Rutinas_Lleva_Calentamiento ?? false,
                    Lleva_Enfriamiento = m.Configuracion_de_Rutinas_Lleva_Enfriamiento ?? false,
                    Estatus = m.Configuracion_de_Rutinas_Estatus,

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

        public IList<Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Configuracion_de_RutinasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Configuracion_de_RutinasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_RutinasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllConfiguracion_de_Rutinas>("sp_ListSelAll_Configuracion_de_Rutinas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Configuracion_de_RutinasPagingModel result = null;

            if (data != null)
            {
                result = new Configuracion_de_RutinasPagingModel
                {
                    Configuracion_de_Rutinass =
                        data.Select(m => new Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas
                {
                    Folio = m.Configuracion_de_Rutinas_Folio
                    ,Fecha_de_Registro = m.Configuracion_de_Rutinas_Fecha_de_Registro
                    ,Hora_de_Registro = m.Configuracion_de_Rutinas_Hora_de_Registro
                    ,Usuario_que_Registra = m.Configuracion_de_Rutinas_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Configuracion_de_Rutinas_Usuario_que_Registra.GetValueOrDefault(), Name = m.Configuracion_de_Rutinas_Usuario_que_Registra_Name }
                    ,Tipo_de_Rutina = m.Configuracion_de_Rutinas_Tipo_de_Rutina
                    ,Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina = new Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina() { Folio = m.Configuracion_de_Rutinas_Tipo_de_Rutina.GetValueOrDefault(), Tipo_de_Rutina = m.Configuracion_de_Rutinas_Tipo_de_Rutina_Tipo_de_Rutina }
                    ,Nivel_de_Dificultad = m.Configuracion_de_Rutinas_Nivel_de_Dificultad
                    ,Nivel_de_Dificultad_Nivel_de_dificultad = new Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad() { Folio = m.Configuracion_de_Rutinas_Nivel_de_Dificultad.GetValueOrDefault(), Dificultad = m.Configuracion_de_Rutinas_Nivel_de_Dificultad_Dificultad }
                    ,Sexo = m.Configuracion_de_Rutinas_Sexo
                    ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Configuracion_de_Rutinas_Sexo.GetValueOrDefault(), Descripcion = m.Configuracion_de_Rutinas_Sexo_Descripcion }
                    ,Cantidad_de_ejercicios = m.Configuracion_de_Rutinas_Cantidad_de_ejercicios
                    ,Cantidad_de_series = m.Configuracion_de_Rutinas_Cantidad_de_series
                    ,Cantidad_de_repeticiones = m.Configuracion_de_Rutinas_Cantidad_de_repeticiones
                    ,Descanso_segundos = m.Configuracion_de_Rutinas_Descanso_segundos
                    ,Texto_Ejercicios = m.Configuracion_de_Rutinas_Texto_Ejercicios
                    ,Lleva_Calentamiento = m.Configuracion_de_Rutinas_Lleva_Calentamiento ?? false
                    ,Lleva_Enfriamiento = m.Configuracion_de_Rutinas_Lleva_Enfriamiento ?? false
                    ,Estatus = m.Configuracion_de_Rutinas_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Configuracion_de_Rutinas_Estatus.GetValueOrDefault(), Descripcion = m.Configuracion_de_Rutinas_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Configuracion_de_RutinasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas>("sp_GetConfiguracion_de_Rutinas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelConfiguracion_de_Rutinas>("sp_DelConfiguracion_de_Rutinas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas entity)
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

                var padreTipo_de_Rutina = _dataProvider.GetParameter();
                padreTipo_de_Rutina.ParameterName = "Tipo_de_Rutina";
                padreTipo_de_Rutina.DbType = DbType.Int32;
                padreTipo_de_Rutina.Value = (object)entity.Tipo_de_Rutina ?? DBNull.Value;

                var padreNivel_de_Dificultad = _dataProvider.GetParameter();
                padreNivel_de_Dificultad.ParameterName = "Nivel_de_Dificultad";
                padreNivel_de_Dificultad.DbType = DbType.Int32;
                padreNivel_de_Dificultad.Value = (object)entity.Nivel_de_Dificultad ?? DBNull.Value;

                var padreSexo = _dataProvider.GetParameter();
                padreSexo.ParameterName = "Sexo";
                padreSexo.DbType = DbType.Int32;
                padreSexo.Value = (object)entity.Sexo ?? DBNull.Value;

                var padreCantidad_de_ejercicios = _dataProvider.GetParameter();
                padreCantidad_de_ejercicios.ParameterName = "Cantidad_de_ejercicios";
                padreCantidad_de_ejercicios.DbType = DbType.Int16;
                padreCantidad_de_ejercicios.Value = (object)entity.Cantidad_de_ejercicios ?? DBNull.Value;

                var padreCantidad_de_series = _dataProvider.GetParameter();
                padreCantidad_de_series.ParameterName = "Cantidad_de_series";
                padreCantidad_de_series.DbType = DbType.Int16;
                padreCantidad_de_series.Value = (object)entity.Cantidad_de_series ?? DBNull.Value;

                var padreCantidad_de_repeticiones = _dataProvider.GetParameter();
                padreCantidad_de_repeticiones.ParameterName = "Cantidad_de_repeticiones";
                padreCantidad_de_repeticiones.DbType = DbType.Int16;
                padreCantidad_de_repeticiones.Value = (object)entity.Cantidad_de_repeticiones ?? DBNull.Value;

                var padreDescanso_segundos = _dataProvider.GetParameter();
                padreDescanso_segundos.ParameterName = "Descanso_segundos";
                padreDescanso_segundos.DbType = DbType.Int32;
                padreDescanso_segundos.Value = (object)entity.Descanso_segundos ?? DBNull.Value;

                var padreTexto_Ejercicios = _dataProvider.GetParameter();
                padreTexto_Ejercicios.ParameterName = "Texto_Ejercicios";
                padreTexto_Ejercicios.DbType = DbType.String;
                padreTexto_Ejercicios.Value = (object)entity.Texto_Ejercicios ?? DBNull.Value;
                var padreLleva_Calentamiento = _dataProvider.GetParameter();
                padreLleva_Calentamiento.ParameterName = "Lleva_Calentamiento";
                padreLleva_Calentamiento.DbType = DbType.Boolean;
                padreLleva_Calentamiento.Value = (object)entity.Lleva_Calentamiento ?? DBNull.Value;
                var padreLleva_Enfriamiento = _dataProvider.GetParameter();
                padreLleva_Enfriamiento.ParameterName = "Lleva_Enfriamiento";
                padreLleva_Enfriamiento.DbType = DbType.Boolean;
                padreLleva_Enfriamiento.Value = (object)entity.Lleva_Enfriamiento ?? DBNull.Value;
                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsConfiguracion_de_Rutinas>("sp_InsConfiguracion_de_Rutinas" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreTipo_de_Rutina
, padreNivel_de_Dificultad
, padreSexo
, padreCantidad_de_ejercicios
, padreCantidad_de_series
, padreCantidad_de_repeticiones
, padreDescanso_segundos
, padreTexto_Ejercicios
, padreLleva_Calentamiento
, padreLleva_Enfriamiento
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

        public int Update(Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas entity)
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

                var paramUpdTipo_de_Rutina = _dataProvider.GetParameter();
                paramUpdTipo_de_Rutina.ParameterName = "Tipo_de_Rutina";
                paramUpdTipo_de_Rutina.DbType = DbType.Int32;
                paramUpdTipo_de_Rutina.Value = (object)entity.Tipo_de_Rutina ?? DBNull.Value;

                var paramUpdNivel_de_Dificultad = _dataProvider.GetParameter();
                paramUpdNivel_de_Dificultad.ParameterName = "Nivel_de_Dificultad";
                paramUpdNivel_de_Dificultad.DbType = DbType.Int32;
                paramUpdNivel_de_Dificultad.Value = (object)entity.Nivel_de_Dificultad ?? DBNull.Value;

                var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)entity.Sexo ?? DBNull.Value;

                var paramUpdCantidad_de_ejercicios = _dataProvider.GetParameter();
                paramUpdCantidad_de_ejercicios.ParameterName = "Cantidad_de_ejercicios";
                paramUpdCantidad_de_ejercicios.DbType = DbType.Int16;
                paramUpdCantidad_de_ejercicios.Value = (object)entity.Cantidad_de_ejercicios ?? DBNull.Value;

                var paramUpdCantidad_de_series = _dataProvider.GetParameter();
                paramUpdCantidad_de_series.ParameterName = "Cantidad_de_series";
                paramUpdCantidad_de_series.DbType = DbType.Int16;
                paramUpdCantidad_de_series.Value = (object)entity.Cantidad_de_series ?? DBNull.Value;

                var paramUpdCantidad_de_repeticiones = _dataProvider.GetParameter();
                paramUpdCantidad_de_repeticiones.ParameterName = "Cantidad_de_repeticiones";
                paramUpdCantidad_de_repeticiones.DbType = DbType.Int16;
                paramUpdCantidad_de_repeticiones.Value = (object)entity.Cantidad_de_repeticiones ?? DBNull.Value;

                var paramUpdDescanso_segundos = _dataProvider.GetParameter();
                paramUpdDescanso_segundos.ParameterName = "Descanso_segundos";
                paramUpdDescanso_segundos.DbType = DbType.Int32;
                paramUpdDescanso_segundos.Value = (object)entity.Descanso_segundos ?? DBNull.Value;

                var paramUpdTexto_Ejercicios = _dataProvider.GetParameter();
                paramUpdTexto_Ejercicios.ParameterName = "Texto_Ejercicios";
                paramUpdTexto_Ejercicios.DbType = DbType.String;
                paramUpdTexto_Ejercicios.Value = (object)entity.Texto_Ejercicios ?? DBNull.Value;
                var paramUpdLleva_Calentamiento = _dataProvider.GetParameter();
                paramUpdLleva_Calentamiento.ParameterName = "Lleva_Calentamiento";
                paramUpdLleva_Calentamiento.DbType = DbType.Boolean;
                paramUpdLleva_Calentamiento.Value = (object)entity.Lleva_Calentamiento ?? DBNull.Value;
                var paramUpdLleva_Enfriamiento = _dataProvider.GetParameter();
                paramUpdLleva_Enfriamiento.ParameterName = "Lleva_Enfriamiento";
                paramUpdLleva_Enfriamiento.DbType = DbType.Boolean;
                paramUpdLleva_Enfriamiento.Value = (object)entity.Lleva_Enfriamiento ?? DBNull.Value;
                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdConfiguracion_de_Rutinas>("sp_UpdConfiguracion_de_Rutinas" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Rutina , paramUpdNivel_de_Dificultad , paramUpdSexo , paramUpdCantidad_de_ejercicios , paramUpdCantidad_de_series , paramUpdCantidad_de_repeticiones , paramUpdDescanso_segundos , paramUpdTexto_Ejercicios , paramUpdLleva_Calentamiento , paramUpdLleva_Enfriamiento , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Configuracion_de_Rutinas.Configuracion_de_Rutinas Configuracion_de_RutinasDB = GetByKey(entity.Folio, false);
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
		var paramUpdTipo_de_Rutina = _dataProvider.GetParameter();
                paramUpdTipo_de_Rutina.ParameterName = "Tipo_de_Rutina";
                paramUpdTipo_de_Rutina.DbType = DbType.Int32;
                paramUpdTipo_de_Rutina.Value = (object)entity.Tipo_de_Rutina ?? DBNull.Value;
		var paramUpdNivel_de_Dificultad = _dataProvider.GetParameter();
                paramUpdNivel_de_Dificultad.ParameterName = "Nivel_de_Dificultad";
                paramUpdNivel_de_Dificultad.DbType = DbType.Int32;
                paramUpdNivel_de_Dificultad.Value = (object)entity.Nivel_de_Dificultad ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)entity.Sexo ?? DBNull.Value;
                var paramUpdCantidad_de_ejercicios = _dataProvider.GetParameter();
                paramUpdCantidad_de_ejercicios.ParameterName = "Cantidad_de_ejercicios";
                paramUpdCantidad_de_ejercicios.DbType = DbType.Int16;
                paramUpdCantidad_de_ejercicios.Value = (object)entity.Cantidad_de_ejercicios ?? DBNull.Value;
                var paramUpdCantidad_de_series = _dataProvider.GetParameter();
                paramUpdCantidad_de_series.ParameterName = "Cantidad_de_series";
                paramUpdCantidad_de_series.DbType = DbType.Int16;
                paramUpdCantidad_de_series.Value = (object)entity.Cantidad_de_series ?? DBNull.Value;
                var paramUpdCantidad_de_repeticiones = _dataProvider.GetParameter();
                paramUpdCantidad_de_repeticiones.ParameterName = "Cantidad_de_repeticiones";
                paramUpdCantidad_de_repeticiones.DbType = DbType.Int16;
                paramUpdCantidad_de_repeticiones.Value = (object)entity.Cantidad_de_repeticiones ?? DBNull.Value;
                var paramUpdDescanso_segundos = _dataProvider.GetParameter();
                paramUpdDescanso_segundos.ParameterName = "Descanso_segundos";
                paramUpdDescanso_segundos.DbType = DbType.Int32;
                paramUpdDescanso_segundos.Value = (object)entity.Descanso_segundos ?? DBNull.Value;
                var paramUpdTexto_Ejercicios = _dataProvider.GetParameter();
                paramUpdTexto_Ejercicios.ParameterName = "Texto_Ejercicios";
                paramUpdTexto_Ejercicios.DbType = DbType.String;
                paramUpdTexto_Ejercicios.Value = (object)entity.Texto_Ejercicios ?? DBNull.Value;
                var paramUpdLleva_Calentamiento = _dataProvider.GetParameter();
                paramUpdLleva_Calentamiento.ParameterName = "Lleva_Calentamiento";
                paramUpdLleva_Calentamiento.DbType = DbType.Boolean;
                paramUpdLleva_Calentamiento.Value = (object)entity.Lleva_Calentamiento ?? DBNull.Value;
                var paramUpdLleva_Enfriamiento = _dataProvider.GetParameter();
                paramUpdLleva_Enfriamiento.ParameterName = "Lleva_Enfriamiento";
                paramUpdLleva_Enfriamiento.DbType = DbType.Boolean;
                paramUpdLleva_Enfriamiento.Value = (object)entity.Lleva_Enfriamiento ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdConfiguracion_de_Rutinas>("sp_UpdConfiguracion_de_Rutinas" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Rutina , paramUpdNivel_de_Dificultad , paramUpdSexo , paramUpdCantidad_de_ejercicios , paramUpdCantidad_de_series , paramUpdCantidad_de_repeticiones , paramUpdDescanso_segundos , paramUpdTexto_Ejercicios , paramUpdLleva_Calentamiento , paramUpdLleva_Enfriamiento , paramUpdEstatus ).FirstOrDefault();

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

