using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Rutinas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Rutinas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class RutinasService : IRutinasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Rutinas.Rutinas> _RutinasRepository;
        #endregion

        #region Ctor
        public RutinasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Rutinas.Rutinas> RutinasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._RutinasRepository = RutinasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._RutinasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Rutinas.Rutinas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Rutinas.Rutinas>("sp_SelAllRutinas");
        }

        public IList<Core.Classes.Rutinas.Rutinas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallRutinas_Complete>("sp_SelAllComplete_Rutinas");
            return data.Select(m => new Core.Classes.Rutinas.Rutinas
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina = new Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina() { Folio = m.Tipo_de_Rutina.GetValueOrDefault(), Tipo_de_Rutina = m.Tipo_de_Rutina_Tipo_de_Rutina }
                ,Nivel_de_dificultad_Nivel_de_dificultad = new Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad() { Folio = m.Nivel_de_dificultad.GetValueOrDefault(), Dificultad = m.Nivel_de_dificultad_Dificultad }
                ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Sexo.GetValueOrDefault(), Descripcion = m.Sexo_Descripcion }
                ,Nombre_de_la_Rutina = m.Nombre_de_la_Rutina
                ,Descripcion = m.Descripcion
                ,Equipamiento = m.Equipamiento
                ,Equipamiento_alterno = m.Equipamiento_alterno
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Rutinas>("sp_ListSelCount_Rutinas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Rutinas.Rutinas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRutinas>("sp_ListSelAll_Rutinas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Rutinas.Rutinas
                {
                    Folio = m.Rutinas_Folio,
                    Fecha_de_Registro = m.Rutinas_Fecha_de_Registro,
                    Hora_de_Registro = m.Rutinas_Hora_de_Registro,
                    Usuario_que_Registra = m.Rutinas_Usuario_que_Registra,
                    Tipo_de_Rutina = m.Rutinas_Tipo_de_Rutina,
                    Nivel_de_dificultad = m.Rutinas_Nivel_de_dificultad,
                    Sexo = m.Rutinas_Sexo,
                    Nombre_de_la_Rutina = m.Rutinas_Nombre_de_la_Rutina,
                    Descripcion = m.Rutinas_Descripcion,
                    Equipamiento = m.Rutinas_Equipamiento,
                    Equipamiento_alterno = m.Rutinas_Equipamiento_alterno,
                    Estatus = m.Rutinas_Estatus,

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

        public IList<Spartane.Core.Classes.Rutinas.Rutinas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._RutinasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Rutinas.Rutinas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._RutinasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Rutinas.RutinasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRutinas>("sp_ListSelAll_Rutinas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            RutinasPagingModel result = null;

            if (data != null)
            {
                result = new RutinasPagingModel
                {
                    Rutinass =
                        data.Select(m => new Spartane.Core.Classes.Rutinas.Rutinas
                {
                    Folio = m.Rutinas_Folio
                    ,Fecha_de_Registro = m.Rutinas_Fecha_de_Registro
                    ,Hora_de_Registro = m.Rutinas_Hora_de_Registro
                    ,Usuario_que_Registra = m.Rutinas_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Rutinas_Usuario_que_Registra.GetValueOrDefault(), Name = m.Rutinas_Usuario_que_Registra_Name }
                    ,Tipo_de_Rutina = m.Rutinas_Tipo_de_Rutina
                    ,Tipo_de_Rutina_Tipo_de_Ejercicio_Rutina = new Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina() { Folio = m.Rutinas_Tipo_de_Rutina.GetValueOrDefault(), Tipo_de_Rutina = m.Rutinas_Tipo_de_Rutina_Tipo_de_Rutina }
                    ,Nivel_de_dificultad = m.Rutinas_Nivel_de_dificultad
                    ,Nivel_de_dificultad_Nivel_de_dificultad = new Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad() { Folio = m.Rutinas_Nivel_de_dificultad.GetValueOrDefault(), Dificultad = m.Rutinas_Nivel_de_dificultad_Dificultad }
                    ,Sexo = m.Rutinas_Sexo
                    ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Rutinas_Sexo.GetValueOrDefault(), Descripcion = m.Rutinas_Sexo_Descripcion }
                    ,Nombre_de_la_Rutina = m.Rutinas_Nombre_de_la_Rutina
                    ,Descripcion = m.Rutinas_Descripcion
                    ,Equipamiento = m.Rutinas_Equipamiento
                    ,Equipamiento_alterno = m.Rutinas_Equipamiento_alterno
                    ,Estatus = m.Rutinas_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Rutinas_Estatus.GetValueOrDefault(), Descripcion = m.Rutinas_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Rutinas.Rutinas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._RutinasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Rutinas.Rutinas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Rutinas.Rutinas>("sp_GetRutinas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelRutinas>("sp_DelRutinas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Rutinas.Rutinas entity)
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

                var padreNivel_de_dificultad = _dataProvider.GetParameter();
                padreNivel_de_dificultad.ParameterName = "Nivel_de_dificultad";
                padreNivel_de_dificultad.DbType = DbType.Int32;
                padreNivel_de_dificultad.Value = (object)entity.Nivel_de_dificultad ?? DBNull.Value;

                var padreSexo = _dataProvider.GetParameter();
                padreSexo.ParameterName = "Sexo";
                padreSexo.DbType = DbType.Int32;
                padreSexo.Value = (object)entity.Sexo ?? DBNull.Value;

                var padreNombre_de_la_Rutina = _dataProvider.GetParameter();
                padreNombre_de_la_Rutina.ParameterName = "Nombre_de_la_Rutina";
                padreNombre_de_la_Rutina.DbType = DbType.String;
                padreNombre_de_la_Rutina.Value = (object)entity.Nombre_de_la_Rutina ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var padreEquipamiento = _dataProvider.GetParameter();
                padreEquipamiento.ParameterName = "Equipamiento";
                padreEquipamiento.DbType = DbType.String;
                padreEquipamiento.Value = (object)entity.Equipamiento ?? DBNull.Value;
                var padreEquipamiento_alterno = _dataProvider.GetParameter();
                padreEquipamiento_alterno.ParameterName = "Equipamiento_alterno";
                padreEquipamiento_alterno.DbType = DbType.String;
                padreEquipamiento_alterno.Value = (object)entity.Equipamiento_alterno ?? DBNull.Value;
                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsRutinas>("sp_InsRutinas" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreTipo_de_Rutina
, padreNivel_de_dificultad
, padreSexo
, padreNombre_de_la_Rutina
, padreDescripcion
, padreEquipamiento
, padreEquipamiento_alterno
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

        public int Update(Spartane.Core.Classes.Rutinas.Rutinas entity)
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

                var paramUpdNivel_de_dificultad = _dataProvider.GetParameter();
                paramUpdNivel_de_dificultad.ParameterName = "Nivel_de_dificultad";
                paramUpdNivel_de_dificultad.DbType = DbType.Int32;
                paramUpdNivel_de_dificultad.Value = (object)entity.Nivel_de_dificultad ?? DBNull.Value;

                var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)entity.Sexo ?? DBNull.Value;

                var paramUpdNombre_de_la_Rutina = _dataProvider.GetParameter();
                paramUpdNombre_de_la_Rutina.ParameterName = "Nombre_de_la_Rutina";
                paramUpdNombre_de_la_Rutina.DbType = DbType.String;
                paramUpdNombre_de_la_Rutina.Value = (object)entity.Nombre_de_la_Rutina ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdEquipamiento = _dataProvider.GetParameter();
                paramUpdEquipamiento.ParameterName = "Equipamiento";
                paramUpdEquipamiento.DbType = DbType.String;
                paramUpdEquipamiento.Value = (object)entity.Equipamiento ?? DBNull.Value;
                var paramUpdEquipamiento_alterno = _dataProvider.GetParameter();
                paramUpdEquipamiento_alterno.ParameterName = "Equipamiento_alterno";
                paramUpdEquipamiento_alterno.DbType = DbType.String;
                paramUpdEquipamiento_alterno.Value = (object)entity.Equipamiento_alterno ?? DBNull.Value;
                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRutinas>("sp_UpdRutinas" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Rutina , paramUpdNivel_de_dificultad , paramUpdSexo , paramUpdNombre_de_la_Rutina , paramUpdDescripcion , paramUpdEquipamiento , paramUpdEquipamiento_alterno , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Rutinas.Rutinas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Rutinas.Rutinas RutinasDB = GetByKey(entity.Folio, false);
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
		var paramUpdNivel_de_dificultad = _dataProvider.GetParameter();
                paramUpdNivel_de_dificultad.ParameterName = "Nivel_de_dificultad";
                paramUpdNivel_de_dificultad.DbType = DbType.Int32;
                paramUpdNivel_de_dificultad.Value = (object)entity.Nivel_de_dificultad ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)entity.Sexo ?? DBNull.Value;
                var paramUpdNombre_de_la_Rutina = _dataProvider.GetParameter();
                paramUpdNombre_de_la_Rutina.ParameterName = "Nombre_de_la_Rutina";
                paramUpdNombre_de_la_Rutina.DbType = DbType.String;
                paramUpdNombre_de_la_Rutina.Value = (object)entity.Nombre_de_la_Rutina ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdEquipamiento = _dataProvider.GetParameter();
                paramUpdEquipamiento.ParameterName = "Equipamiento";
                paramUpdEquipamiento.DbType = DbType.String;
                paramUpdEquipamiento.Value = (object)entity.Equipamiento ?? DBNull.Value;
                var paramUpdEquipamiento_alterno = _dataProvider.GetParameter();
                paramUpdEquipamiento_alterno.ParameterName = "Equipamiento_alterno";
                paramUpdEquipamiento_alterno.DbType = DbType.String;
                paramUpdEquipamiento_alterno.Value = (object)entity.Equipamiento_alterno ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRutinas>("sp_UpdRutinas" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Rutina , paramUpdNivel_de_dificultad , paramUpdSexo , paramUpdNombre_de_la_Rutina , paramUpdDescripcion , paramUpdEquipamiento , paramUpdEquipamiento_alterno , paramUpdEstatus ).FirstOrDefault();

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

