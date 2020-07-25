using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Planes_de_Rutinas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Planes_de_Rutinas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Planes_de_RutinasService : IDetalle_Planes_de_RutinasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas> _Detalle_Planes_de_RutinasRepository;
        #endregion

        #region Ctor
        public Detalle_Planes_de_RutinasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas> Detalle_Planes_de_RutinasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Planes_de_RutinasRepository = Detalle_Planes_de_RutinasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Planes_de_RutinasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas>("sp_SelAllDetalle_Planes_de_Rutinas");
        }

        public IList<Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Planes_de_Rutinas_Complete>("sp_SelAllComplete_Detalle_Planes_de_Rutinas");
            return data.Select(m => new Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas
            {
                Folio = m.Folio
                ,Folio_Planes_de_Rutinas = m.Folio_Planes_de_Rutinas
                ,Numero_de_Dia_Dias_de_la_semana = new Core.Classes.Dias_de_la_semana.Dias_de_la_semana() { Clave = m.Numero_de_Dia.GetValueOrDefault(), Dia = m.Numero_de_Dia_Dia }
                ,Fecha = m.Fecha
                ,Orden_de_Realizacion = m.Orden_de_Realizacion
                ,Secuencia_del_Ejercicio = m.Secuencia_del_Ejercicio
                ,Enfoque_del_Ejercicio_Tipo_de_Enfoque_del_Ejercicio = new Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio() { Folio = m.Enfoque_del_Ejercicio.GetValueOrDefault(), Descripcion = m.Enfoque_del_Ejercicio_Descripcion }
                ,Ejercicio_Ejercicios = new Core.Classes.Ejercicios.Ejercicios() { Clave = m.Ejercicio.GetValueOrDefault(), Nombre_del_Ejercicio = m.Ejercicio_Nombre_del_Ejercicio }
                ,Realizado = m.Realizado.GetValueOrDefault()


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Planes_de_Rutinas>("sp_ListSelCount_Detalle_Planes_de_Rutinas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Planes_de_Rutinas>("sp_ListSelAll_Detalle_Planes_de_Rutinas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas
                {
                    Folio = m.Detalle_Planes_de_Rutinas_Folio,
                    Folio_Planes_de_Rutinas = m.Detalle_Planes_de_Rutinas_Folio_Planes_de_Rutinas,
                    Numero_de_Dia = m.Detalle_Planes_de_Rutinas_Numero_de_Dia,
                    Fecha = m.Detalle_Planes_de_Rutinas_Fecha,
                    Orden_de_Realizacion = m.Detalle_Planes_de_Rutinas_Orden_de_Realizacion,
                    Secuencia_del_Ejercicio = m.Detalle_Planes_de_Rutinas_Secuencia_del_Ejercicio,
                    Enfoque_del_Ejercicio = m.Detalle_Planes_de_Rutinas_Enfoque_del_Ejercicio,
                    Ejercicio = m.Detalle_Planes_de_Rutinas_Ejercicio,
                    Realizado = m.Detalle_Planes_de_Rutinas_Realizado ?? false,

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

        public IList<Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Planes_de_RutinasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Planes_de_RutinasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_RutinasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Planes_de_Rutinas>("sp_ListSelAll_Detalle_Planes_de_Rutinas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Planes_de_RutinasPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Planes_de_RutinasPagingModel
                {
                    Detalle_Planes_de_Rutinass =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas
                {
                    Folio = m.Detalle_Planes_de_Rutinas_Folio
                    ,Folio_Planes_de_Rutinas = m.Detalle_Planes_de_Rutinas_Folio_Planes_de_Rutinas
                    ,Numero_de_Dia = m.Detalle_Planes_de_Rutinas_Numero_de_Dia
                    ,Numero_de_Dia_Dias_de_la_semana = new Core.Classes.Dias_de_la_semana.Dias_de_la_semana() { Clave = m.Detalle_Planes_de_Rutinas_Numero_de_Dia.GetValueOrDefault(), Dia = m.Detalle_Planes_de_Rutinas_Numero_de_Dia_Dia }
                    ,Fecha = m.Detalle_Planes_de_Rutinas_Fecha
                    ,Orden_de_Realizacion = m.Detalle_Planes_de_Rutinas_Orden_de_Realizacion
                    ,Secuencia_del_Ejercicio = m.Detalle_Planes_de_Rutinas_Secuencia_del_Ejercicio
                    ,Enfoque_del_Ejercicio = m.Detalle_Planes_de_Rutinas_Enfoque_del_Ejercicio
                    ,Enfoque_del_Ejercicio_Tipo_de_Enfoque_del_Ejercicio = new Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio() { Folio = m.Detalle_Planes_de_Rutinas_Enfoque_del_Ejercicio.GetValueOrDefault(), Descripcion = m.Detalle_Planes_de_Rutinas_Enfoque_del_Ejercicio_Descripcion }
                    ,Ejercicio = m.Detalle_Planes_de_Rutinas_Ejercicio
                    ,Ejercicio_Ejercicios = new Core.Classes.Ejercicios.Ejercicios() { Clave = m.Detalle_Planes_de_Rutinas_Ejercicio.GetValueOrDefault(), Nombre_del_Ejercicio = m.Detalle_Planes_de_Rutinas_Ejercicio_Nombre_del_Ejercicio }
                    ,Realizado = m.Detalle_Planes_de_Rutinas_Realizado ?? false

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Planes_de_RutinasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas>("sp_GetDetalle_Planes_de_Rutinas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Planes_de_Rutinas>("sp_DelDetalle_Planes_de_Rutinas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Planes_de_Rutinas = _dataProvider.GetParameter();
                padreFolio_Planes_de_Rutinas.ParameterName = "Folio_Planes_de_Rutinas";
                padreFolio_Planes_de_Rutinas.DbType = DbType.Int32;
                padreFolio_Planes_de_Rutinas.Value = (object)entity.Folio_Planes_de_Rutinas ?? DBNull.Value;
                var padreNumero_de_Dia = _dataProvider.GetParameter();
                padreNumero_de_Dia.ParameterName = "Numero_de_Dia";
                padreNumero_de_Dia.DbType = DbType.Int32;
                padreNumero_de_Dia.Value = (object)entity.Numero_de_Dia ?? DBNull.Value;

                var padreFecha = _dataProvider.GetParameter();
                padreFecha.ParameterName = "Fecha";
                padreFecha.DbType = DbType.DateTime;
                padreFecha.Value = (object)entity.Fecha ?? DBNull.Value;

                var padreOrden_de_Realizacion = _dataProvider.GetParameter();
                padreOrden_de_Realizacion.ParameterName = "Orden_de_Realizacion";
                padreOrden_de_Realizacion.DbType = DbType.Int32;
                padreOrden_de_Realizacion.Value = (object)entity.Orden_de_Realizacion ?? DBNull.Value;

                var padreSecuencia_del_Ejercicio = _dataProvider.GetParameter();
                padreSecuencia_del_Ejercicio.ParameterName = "Secuencia_del_Ejercicio";
                padreSecuencia_del_Ejercicio.DbType = DbType.String;
                padreSecuencia_del_Ejercicio.Value = (object)entity.Secuencia_del_Ejercicio ?? DBNull.Value;
                var padreEnfoque_del_Ejercicio = _dataProvider.GetParameter();
                padreEnfoque_del_Ejercicio.ParameterName = "Enfoque_del_Ejercicio";
                padreEnfoque_del_Ejercicio.DbType = DbType.Int32;
                padreEnfoque_del_Ejercicio.Value = (object)entity.Enfoque_del_Ejercicio ?? DBNull.Value;

                var padreEjercicio = _dataProvider.GetParameter();
                padreEjercicio.ParameterName = "Ejercicio";
                padreEjercicio.DbType = DbType.Int32;
                padreEjercicio.Value = (object)entity.Ejercicio ?? DBNull.Value;

                var padreRealizado = _dataProvider.GetParameter();
                padreRealizado.ParameterName = "Realizado";
                padreRealizado.DbType = DbType.Boolean;
                padreRealizado.Value = (object)entity.Realizado ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Planes_de_Rutinas>("sp_InsDetalle_Planes_de_Rutinas" , padreFolio_Planes_de_Rutinas
, padreNumero_de_Dia
, padreFecha
, padreOrden_de_Realizacion
, padreSecuencia_del_Ejercicio
, padreEnfoque_del_Ejercicio
, padreEjercicio
, padreRealizado
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

        public int Update(Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Planes_de_Rutinas = _dataProvider.GetParameter();
                paramUpdFolio_Planes_de_Rutinas.ParameterName = "Folio_Planes_de_Rutinas";
                paramUpdFolio_Planes_de_Rutinas.DbType = DbType.Int32;
                paramUpdFolio_Planes_de_Rutinas.Value = (object)entity.Folio_Planes_de_Rutinas ?? DBNull.Value;
                var paramUpdNumero_de_Dia = _dataProvider.GetParameter();
                paramUpdNumero_de_Dia.ParameterName = "Numero_de_Dia";
                paramUpdNumero_de_Dia.DbType = DbType.Int32;
                paramUpdNumero_de_Dia.Value = (object)entity.Numero_de_Dia ?? DBNull.Value;

                var paramUpdFecha = _dataProvider.GetParameter();
                paramUpdFecha.ParameterName = "Fecha";
                paramUpdFecha.DbType = DbType.DateTime;
                paramUpdFecha.Value = (object)entity.Fecha ?? DBNull.Value;

                var paramUpdOrden_de_Realizacion = _dataProvider.GetParameter();
                paramUpdOrden_de_Realizacion.ParameterName = "Orden_de_Realizacion";
                paramUpdOrden_de_Realizacion.DbType = DbType.Int32;
                paramUpdOrden_de_Realizacion.Value = (object)entity.Orden_de_Realizacion ?? DBNull.Value;

                var paramUpdSecuencia_del_Ejercicio = _dataProvider.GetParameter();
                paramUpdSecuencia_del_Ejercicio.ParameterName = "Secuencia_del_Ejercicio";
                paramUpdSecuencia_del_Ejercicio.DbType = DbType.String;
                paramUpdSecuencia_del_Ejercicio.Value = (object)entity.Secuencia_del_Ejercicio ?? DBNull.Value;
                var paramUpdEnfoque_del_Ejercicio = _dataProvider.GetParameter();
                paramUpdEnfoque_del_Ejercicio.ParameterName = "Enfoque_del_Ejercicio";
                paramUpdEnfoque_del_Ejercicio.DbType = DbType.Int32;
                paramUpdEnfoque_del_Ejercicio.Value = (object)entity.Enfoque_del_Ejercicio ?? DBNull.Value;

                var paramUpdEjercicio = _dataProvider.GetParameter();
                paramUpdEjercicio.ParameterName = "Ejercicio";
                paramUpdEjercicio.DbType = DbType.Int32;
                paramUpdEjercicio.Value = (object)entity.Ejercicio ?? DBNull.Value;

                var paramUpdRealizado = _dataProvider.GetParameter();
                paramUpdRealizado.ParameterName = "Realizado";
                paramUpdRealizado.DbType = DbType.Boolean;
                paramUpdRealizado.Value = (object)entity.Realizado ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Planes_de_Rutinas>("sp_UpdDetalle_Planes_de_Rutinas" , paramUpdFolio , paramUpdFolio_Planes_de_Rutinas , paramUpdNumero_de_Dia , paramUpdFecha , paramUpdOrden_de_Realizacion , paramUpdSecuencia_del_Ejercicio , paramUpdEnfoque_del_Ejercicio , paramUpdEjercicio , paramUpdRealizado ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Planes_de_Rutinas.Detalle_Planes_de_Rutinas Detalle_Planes_de_RutinasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Planes_de_Rutinas = _dataProvider.GetParameter();
                paramUpdFolio_Planes_de_Rutinas.ParameterName = "Folio_Planes_de_Rutinas";
                paramUpdFolio_Planes_de_Rutinas.DbType = DbType.Int32;
                paramUpdFolio_Planes_de_Rutinas.Value = (object)entity.Folio_Planes_de_Rutinas ?? DBNull.Value;
		var paramUpdNumero_de_Dia = _dataProvider.GetParameter();
                paramUpdNumero_de_Dia.ParameterName = "Numero_de_Dia";
                paramUpdNumero_de_Dia.DbType = DbType.Int32;
                paramUpdNumero_de_Dia.Value = (object)entity.Numero_de_Dia ?? DBNull.Value;
                var paramUpdFecha = _dataProvider.GetParameter();
                paramUpdFecha.ParameterName = "Fecha";
                paramUpdFecha.DbType = DbType.DateTime;
                paramUpdFecha.Value = (object)entity.Fecha ?? DBNull.Value;
                var paramUpdOrden_de_Realizacion = _dataProvider.GetParameter();
                paramUpdOrden_de_Realizacion.ParameterName = "Orden_de_Realizacion";
                paramUpdOrden_de_Realizacion.DbType = DbType.Int32;
                paramUpdOrden_de_Realizacion.Value = (object)entity.Orden_de_Realizacion ?? DBNull.Value;
                var paramUpdSecuencia_del_Ejercicio = _dataProvider.GetParameter();
                paramUpdSecuencia_del_Ejercicio.ParameterName = "Secuencia_del_Ejercicio";
                paramUpdSecuencia_del_Ejercicio.DbType = DbType.String;
                paramUpdSecuencia_del_Ejercicio.Value = (object)entity.Secuencia_del_Ejercicio ?? DBNull.Value;
		var paramUpdEnfoque_del_Ejercicio = _dataProvider.GetParameter();
                paramUpdEnfoque_del_Ejercicio.ParameterName = "Enfoque_del_Ejercicio";
                paramUpdEnfoque_del_Ejercicio.DbType = DbType.Int32;
                paramUpdEnfoque_del_Ejercicio.Value = (object)entity.Enfoque_del_Ejercicio ?? DBNull.Value;
		var paramUpdEjercicio = _dataProvider.GetParameter();
                paramUpdEjercicio.ParameterName = "Ejercicio";
                paramUpdEjercicio.DbType = DbType.Int32;
                paramUpdEjercicio.Value = (object)entity.Ejercicio ?? DBNull.Value;
                var paramUpdRealizado = _dataProvider.GetParameter();
                paramUpdRealizado.ParameterName = "Realizado";
                paramUpdRealizado.DbType = DbType.Boolean;
                paramUpdRealizado.Value = (object)entity.Realizado ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Planes_de_Rutinas>("sp_UpdDetalle_Planes_de_Rutinas" , paramUpdFolio , paramUpdFolio_Planes_de_Rutinas , paramUpdNumero_de_Dia , paramUpdFecha , paramUpdOrden_de_Realizacion , paramUpdSecuencia_del_Ejercicio , paramUpdEnfoque_del_Ejercicio , paramUpdEjercicio , paramUpdRealizado ).FirstOrDefault();

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

