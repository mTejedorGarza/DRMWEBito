﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Ejercicios_Rutinas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Ejercicios_Rutinas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Ejercicios_RutinasService : IDetalle_Ejercicios_RutinasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas> _Detalle_Ejercicios_RutinasRepository;
        #endregion

        #region Ctor
        public Detalle_Ejercicios_RutinasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas> Detalle_Ejercicios_RutinasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Ejercicios_RutinasRepository = Detalle_Ejercicios_RutinasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Ejercicios_RutinasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas>("sp_SelAllDetalle_Ejercicios_Rutinas");
        }

        public IList<Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Ejercicios_Rutinas_Complete>("sp_SelAllComplete_Detalle_Ejercicios_Rutinas");
            return data.Select(m => new Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas
            {
                Folio = m.Folio
                ,Folio_Rutinas = m.Folio_Rutinas
                ,Orden_de_realizacion = m.Orden_de_realizacion
                ,Secuencia = m.Secuencia
                ,Enfoque_del_Ejercicio_Tipo_de_Enfoque_del_Ejercicio = new Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio() { Folio = m.Enfoque_del_Ejercicio.GetValueOrDefault(), Descripcion = m.Enfoque_del_Ejercicio_Descripcion }
                ,Ejercicio_Ejercicios = new Core.Classes.Ejercicios.Ejercicios() { Clave = m.Ejercicio.GetValueOrDefault(), Nombre_del_Ejercicio = m.Ejercicio_Nombre_del_Ejercicio }
                ,Cantidad_de_series = m.Cantidad_de_series
                ,Cantidad_de_repeticiones = m.Cantidad_de_repeticiones
                ,Descanso_en_segundos = m.Descanso_en_segundos


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Ejercicios_Rutinas>("sp_ListSelCount_Detalle_Ejercicios_Rutinas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Ejercicios_Rutinas>("sp_ListSelAll_Detalle_Ejercicios_Rutinas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas
                {
                    Folio = m.Detalle_Ejercicios_Rutinas_Folio,
                    Folio_Rutinas = m.Detalle_Ejercicios_Rutinas_Folio_Rutinas,
                    Orden_de_realizacion = m.Detalle_Ejercicios_Rutinas_Orden_de_realizacion,
                    Secuencia = m.Detalle_Ejercicios_Rutinas_Secuencia,
                    Enfoque_del_Ejercicio = m.Detalle_Ejercicios_Rutinas_Enfoque_del_Ejercicio,
                    Ejercicio = m.Detalle_Ejercicios_Rutinas_Ejercicio,
                    Cantidad_de_series = m.Detalle_Ejercicios_Rutinas_Cantidad_de_series,
                    Cantidad_de_repeticiones = m.Detalle_Ejercicios_Rutinas_Cantidad_de_repeticiones,
                    Descanso_en_segundos = m.Detalle_Ejercicios_Rutinas_Descanso_en_segundos,

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

        public IList<Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Ejercicios_RutinasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Ejercicios_RutinasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_RutinasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Ejercicios_Rutinas>("sp_ListSelAll_Detalle_Ejercicios_Rutinas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Ejercicios_RutinasPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Ejercicios_RutinasPagingModel
                {
                    Detalle_Ejercicios_Rutinass =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas
                {
                    Folio = m.Detalle_Ejercicios_Rutinas_Folio
                    ,Folio_Rutinas = m.Detalle_Ejercicios_Rutinas_Folio_Rutinas
                    ,Orden_de_realizacion = m.Detalle_Ejercicios_Rutinas_Orden_de_realizacion
                    ,Secuencia = m.Detalle_Ejercicios_Rutinas_Secuencia
                    ,Enfoque_del_Ejercicio = m.Detalle_Ejercicios_Rutinas_Enfoque_del_Ejercicio
                    ,Enfoque_del_Ejercicio_Tipo_de_Enfoque_del_Ejercicio = new Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio() { Folio = m.Detalle_Ejercicios_Rutinas_Enfoque_del_Ejercicio.GetValueOrDefault(), Descripcion = m.Detalle_Ejercicios_Rutinas_Enfoque_del_Ejercicio_Descripcion }
                    ,Ejercicio = m.Detalle_Ejercicios_Rutinas_Ejercicio
                    ,Ejercicio_Ejercicios = new Core.Classes.Ejercicios.Ejercicios() { Clave = m.Detalle_Ejercicios_Rutinas_Ejercicio.GetValueOrDefault(), Nombre_del_Ejercicio = m.Detalle_Ejercicios_Rutinas_Ejercicio_Nombre_del_Ejercicio }
                    ,Cantidad_de_series = m.Detalle_Ejercicios_Rutinas_Cantidad_de_series
                    ,Cantidad_de_repeticiones = m.Detalle_Ejercicios_Rutinas_Cantidad_de_repeticiones
                    ,Descanso_en_segundos = m.Detalle_Ejercicios_Rutinas_Descanso_en_segundos

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Ejercicios_RutinasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas>("sp_GetDetalle_Ejercicios_Rutinas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Ejercicios_Rutinas>("sp_DelDetalle_Ejercicios_Rutinas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Rutinas = _dataProvider.GetParameter();
                padreFolio_Rutinas.ParameterName = "Folio_Rutinas";
                padreFolio_Rutinas.DbType = DbType.Int32;
                padreFolio_Rutinas.Value = (object)entity.Folio_Rutinas ?? DBNull.Value;
                var padreOrden_de_realizacion = _dataProvider.GetParameter();
                padreOrden_de_realizacion.ParameterName = "Orden_de_realizacion";
                padreOrden_de_realizacion.DbType = DbType.Int32;
                padreOrden_de_realizacion.Value = (object)entity.Orden_de_realizacion ?? DBNull.Value;

                var padreSecuencia = _dataProvider.GetParameter();
                padreSecuencia.ParameterName = "Secuencia";
                padreSecuencia.DbType = DbType.String;
                padreSecuencia.Value = (object)entity.Secuencia ?? DBNull.Value;
                var padreEnfoque_del_Ejercicio = _dataProvider.GetParameter();
                padreEnfoque_del_Ejercicio.ParameterName = "Enfoque_del_Ejercicio";
                padreEnfoque_del_Ejercicio.DbType = DbType.Int32;
                padreEnfoque_del_Ejercicio.Value = (object)entity.Enfoque_del_Ejercicio ?? DBNull.Value;

                var padreEjercicio = _dataProvider.GetParameter();
                padreEjercicio.ParameterName = "Ejercicio";
                padreEjercicio.DbType = DbType.Int32;
                padreEjercicio.Value = (object)entity.Ejercicio ?? DBNull.Value;

                var padreCantidad_de_series = _dataProvider.GetParameter();
                padreCantidad_de_series.ParameterName = "Cantidad_de_series";
                padreCantidad_de_series.DbType = DbType.Int32;
                padreCantidad_de_series.Value = (object)entity.Cantidad_de_series ?? DBNull.Value;

                var padreCantidad_de_repeticiones = _dataProvider.GetParameter();
                padreCantidad_de_repeticiones.ParameterName = "Cantidad_de_repeticiones";
                padreCantidad_de_repeticiones.DbType = DbType.Int32;
                padreCantidad_de_repeticiones.Value = (object)entity.Cantidad_de_repeticiones ?? DBNull.Value;

                var padreDescanso_en_segundos = _dataProvider.GetParameter();
                padreDescanso_en_segundos.ParameterName = "Descanso_en_segundos";
                padreDescanso_en_segundos.DbType = DbType.Int32;
                padreDescanso_en_segundos.Value = (object)entity.Descanso_en_segundos ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Ejercicios_Rutinas>("sp_InsDetalle_Ejercicios_Rutinas" , padreFolio_Rutinas
, padreOrden_de_realizacion
, padreSecuencia
, padreEnfoque_del_Ejercicio
, padreEjercicio
, padreCantidad_de_series
, padreCantidad_de_repeticiones
, padreDescanso_en_segundos
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

        public int Update(Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Rutinas = _dataProvider.GetParameter();
                paramUpdFolio_Rutinas.ParameterName = "Folio_Rutinas";
                paramUpdFolio_Rutinas.DbType = DbType.Int32;
                paramUpdFolio_Rutinas.Value = (object)entity.Folio_Rutinas ?? DBNull.Value;
                var paramUpdOrden_de_realizacion = _dataProvider.GetParameter();
                paramUpdOrden_de_realizacion.ParameterName = "Orden_de_realizacion";
                paramUpdOrden_de_realizacion.DbType = DbType.Int32;
                paramUpdOrden_de_realizacion.Value = (object)entity.Orden_de_realizacion ?? DBNull.Value;

                var paramUpdSecuencia = _dataProvider.GetParameter();
                paramUpdSecuencia.ParameterName = "Secuencia";
                paramUpdSecuencia.DbType = DbType.String;
                paramUpdSecuencia.Value = (object)entity.Secuencia ?? DBNull.Value;
                var paramUpdEnfoque_del_Ejercicio = _dataProvider.GetParameter();
                paramUpdEnfoque_del_Ejercicio.ParameterName = "Enfoque_del_Ejercicio";
                paramUpdEnfoque_del_Ejercicio.DbType = DbType.Int32;
                paramUpdEnfoque_del_Ejercicio.Value = (object)entity.Enfoque_del_Ejercicio ?? DBNull.Value;

                var paramUpdEjercicio = _dataProvider.GetParameter();
                paramUpdEjercicio.ParameterName = "Ejercicio";
                paramUpdEjercicio.DbType = DbType.Int32;
                paramUpdEjercicio.Value = (object)entity.Ejercicio ?? DBNull.Value;

                var paramUpdCantidad_de_series = _dataProvider.GetParameter();
                paramUpdCantidad_de_series.ParameterName = "Cantidad_de_series";
                paramUpdCantidad_de_series.DbType = DbType.Int32;
                paramUpdCantidad_de_series.Value = (object)entity.Cantidad_de_series ?? DBNull.Value;

                var paramUpdCantidad_de_repeticiones = _dataProvider.GetParameter();
                paramUpdCantidad_de_repeticiones.ParameterName = "Cantidad_de_repeticiones";
                paramUpdCantidad_de_repeticiones.DbType = DbType.Int32;
                paramUpdCantidad_de_repeticiones.Value = (object)entity.Cantidad_de_repeticiones ?? DBNull.Value;

                var paramUpdDescanso_en_segundos = _dataProvider.GetParameter();
                paramUpdDescanso_en_segundos.ParameterName = "Descanso_en_segundos";
                paramUpdDescanso_en_segundos.DbType = DbType.Int32;
                paramUpdDescanso_en_segundos.Value = (object)entity.Descanso_en_segundos ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Ejercicios_Rutinas>("sp_UpdDetalle_Ejercicios_Rutinas" , paramUpdFolio , paramUpdFolio_Rutinas , paramUpdOrden_de_realizacion , paramUpdSecuencia , paramUpdEnfoque_del_Ejercicio , paramUpdEjercicio , paramUpdCantidad_de_series , paramUpdCantidad_de_repeticiones , paramUpdDescanso_en_segundos ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas Detalle_Ejercicios_RutinasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Rutinas = _dataProvider.GetParameter();
                paramUpdFolio_Rutinas.ParameterName = "Folio_Rutinas";
                paramUpdFolio_Rutinas.DbType = DbType.Int32;
                paramUpdFolio_Rutinas.Value = (object)entity.Folio_Rutinas ?? DBNull.Value;
                var paramUpdOrden_de_realizacion = _dataProvider.GetParameter();
                paramUpdOrden_de_realizacion.ParameterName = "Orden_de_realizacion";
                paramUpdOrden_de_realizacion.DbType = DbType.Int32;
                paramUpdOrden_de_realizacion.Value = (object)entity.Orden_de_realizacion ?? DBNull.Value;
                var paramUpdSecuencia = _dataProvider.GetParameter();
                paramUpdSecuencia.ParameterName = "Secuencia";
                paramUpdSecuencia.DbType = DbType.String;
                paramUpdSecuencia.Value = (object)entity.Secuencia ?? DBNull.Value;
		var paramUpdEnfoque_del_Ejercicio = _dataProvider.GetParameter();
                paramUpdEnfoque_del_Ejercicio.ParameterName = "Enfoque_del_Ejercicio";
                paramUpdEnfoque_del_Ejercicio.DbType = DbType.Int32;
                paramUpdEnfoque_del_Ejercicio.Value = (object)entity.Enfoque_del_Ejercicio ?? DBNull.Value;
		var paramUpdEjercicio = _dataProvider.GetParameter();
                paramUpdEjercicio.ParameterName = "Ejercicio";
                paramUpdEjercicio.DbType = DbType.Int32;
                paramUpdEjercicio.Value = (object)entity.Ejercicio ?? DBNull.Value;
                var paramUpdCantidad_de_series = _dataProvider.GetParameter();
                paramUpdCantidad_de_series.ParameterName = "Cantidad_de_series";
                paramUpdCantidad_de_series.DbType = DbType.Int32;
                paramUpdCantidad_de_series.Value = (object)entity.Cantidad_de_series ?? DBNull.Value;
                var paramUpdCantidad_de_repeticiones = _dataProvider.GetParameter();
                paramUpdCantidad_de_repeticiones.ParameterName = "Cantidad_de_repeticiones";
                paramUpdCantidad_de_repeticiones.DbType = DbType.Int32;
                paramUpdCantidad_de_repeticiones.Value = (object)entity.Cantidad_de_repeticiones ?? DBNull.Value;
                var paramUpdDescanso_en_segundos = _dataProvider.GetParameter();
                paramUpdDescanso_en_segundos.ParameterName = "Descanso_en_segundos";
                paramUpdDescanso_en_segundos.DbType = DbType.Int32;
                paramUpdDescanso_en_segundos.Value = (object)entity.Descanso_en_segundos ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Ejercicios_Rutinas>("sp_UpdDetalle_Ejercicios_Rutinas" , paramUpdFolio , paramUpdFolio_Rutinas , paramUpdOrden_de_realizacion , paramUpdSecuencia , paramUpdEnfoque_del_Ejercicio , paramUpdEjercicio , paramUpdCantidad_de_series , paramUpdCantidad_de_repeticiones , paramUpdDescanso_en_segundos ).FirstOrDefault();

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

