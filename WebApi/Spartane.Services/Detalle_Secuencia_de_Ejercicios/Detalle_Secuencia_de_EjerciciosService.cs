using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Secuencia_de_Ejercicios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Secuencia_de_EjerciciosService : IDetalle_Secuencia_de_EjerciciosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios> _Detalle_Secuencia_de_EjerciciosRepository;
        #endregion

        #region Ctor
        public Detalle_Secuencia_de_EjerciciosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios> Detalle_Secuencia_de_EjerciciosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Secuencia_de_EjerciciosRepository = Detalle_Secuencia_de_EjerciciosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Secuencia_de_EjerciciosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios>("sp_SelAllDetalle_Secuencia_de_Ejercicios");
        }

        public IList<Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Secuencia_de_Ejercicios_Complete>("sp_SelAllComplete_Detalle_Secuencia_de_Ejercicios");
            return data.Select(m => new Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios
            {
                Folio = m.Folio
                ,Folio_Configuracion_Rutinas = m.Folio_Configuracion_Rutinas
                ,Orden_del_Ejercicio_Secuencia_de_Ejercicios_en_Rutinas = new Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas() { Folio = m.Orden_del_Ejercicio.GetValueOrDefault(), Descripcion = m.Orden_del_Ejercicio_Descripcion }
                ,Tipo_de_Ejercicio_Tipo_de_Ejercicio_Rutina = new Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina() { Folio = m.Tipo_de_Ejercicio.GetValueOrDefault(), Nombre_para_Secuencia = m.Tipo_de_Ejercicio_Nombre_para_Secuencia }
                ,Enfoque_Tipo_de_Enfoque_del_Ejercicio = new Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio() { Folio = m.Enfoque.GetValueOrDefault(), Descripcion = m.Enfoque_Descripcion }
                ,Secuencia_del_Ejercicio = m.Secuencia_del_Ejercicio


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Secuencia_de_Ejercicios>("sp_ListSelCount_Detalle_Secuencia_de_Ejercicios", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Secuencia_de_Ejercicios>("sp_ListSelAll_Detalle_Secuencia_de_Ejercicios", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios
                {
                    Folio = m.Detalle_Secuencia_de_Ejercicios_Folio,
                    Folio_Configuracion_Rutinas = m.Detalle_Secuencia_de_Ejercicios_Folio_Configuracion_Rutinas,
                    Orden_del_Ejercicio = m.Detalle_Secuencia_de_Ejercicios_Orden_del_Ejercicio,
                    Tipo_de_Ejercicio = m.Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio,
                    Enfoque = m.Detalle_Secuencia_de_Ejercicios_Enfoque,
                    Secuencia_del_Ejercicio = m.Detalle_Secuencia_de_Ejercicios_Secuencia_del_Ejercicio,

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

        public IList<Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Secuencia_de_EjerciciosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Secuencia_de_EjerciciosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_EjerciciosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Secuencia_de_Ejercicios>("sp_ListSelAll_Detalle_Secuencia_de_Ejercicios", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Secuencia_de_EjerciciosPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Secuencia_de_EjerciciosPagingModel
                {
                    Detalle_Secuencia_de_Ejercicioss =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios
                {
                    Folio = m.Detalle_Secuencia_de_Ejercicios_Folio
                    ,Folio_Configuracion_Rutinas = m.Detalle_Secuencia_de_Ejercicios_Folio_Configuracion_Rutinas
                    ,Orden_del_Ejercicio = m.Detalle_Secuencia_de_Ejercicios_Orden_del_Ejercicio
                    ,Orden_del_Ejercicio_Secuencia_de_Ejercicios_en_Rutinas = new Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas() { Folio = m.Detalle_Secuencia_de_Ejercicios_Orden_del_Ejercicio.GetValueOrDefault(), Descripcion = m.Detalle_Secuencia_de_Ejercicios_Orden_del_Ejercicio_Descripcion }
                    ,Tipo_de_Ejercicio = m.Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio
                    ,Tipo_de_Ejercicio_Tipo_de_Ejercicio_Rutina = new Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina() { Folio = m.Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio.GetValueOrDefault(), Nombre_para_Secuencia = m.Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_Nombre_para_Secuencia }
                    ,Enfoque = m.Detalle_Secuencia_de_Ejercicios_Enfoque
                    ,Enfoque_Tipo_de_Enfoque_del_Ejercicio = new Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio() { Folio = m.Detalle_Secuencia_de_Ejercicios_Enfoque.GetValueOrDefault(), Descripcion = m.Detalle_Secuencia_de_Ejercicios_Enfoque_Descripcion }
                    ,Secuencia_del_Ejercicio = m.Detalle_Secuencia_de_Ejercicios_Secuencia_del_Ejercicio

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Secuencia_de_EjerciciosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios>("sp_GetDetalle_Secuencia_de_Ejercicios", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Secuencia_de_Ejercicios>("sp_DelDetalle_Secuencia_de_Ejercicios", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Configuracion_Rutinas = _dataProvider.GetParameter();
                padreFolio_Configuracion_Rutinas.ParameterName = "Folio_Configuracion_Rutinas";
                padreFolio_Configuracion_Rutinas.DbType = DbType.Int32;
                padreFolio_Configuracion_Rutinas.Value = (object)entity.Folio_Configuracion_Rutinas ?? DBNull.Value;
                var padreOrden_del_Ejercicio = _dataProvider.GetParameter();
                padreOrden_del_Ejercicio.ParameterName = "Orden_del_Ejercicio";
                padreOrden_del_Ejercicio.DbType = DbType.Int32;
                padreOrden_del_Ejercicio.Value = (object)entity.Orden_del_Ejercicio ?? DBNull.Value;

                var padreTipo_de_Ejercicio = _dataProvider.GetParameter();
                padreTipo_de_Ejercicio.ParameterName = "Tipo_de_Ejercicio";
                padreTipo_de_Ejercicio.DbType = DbType.Int32;
                padreTipo_de_Ejercicio.Value = (object)entity.Tipo_de_Ejercicio ?? DBNull.Value;

                var padreEnfoque = _dataProvider.GetParameter();
                padreEnfoque.ParameterName = "Enfoque";
                padreEnfoque.DbType = DbType.Int32;
                padreEnfoque.Value = (object)entity.Enfoque ?? DBNull.Value;

                var padreSecuencia_del_Ejercicio = _dataProvider.GetParameter();
                padreSecuencia_del_Ejercicio.ParameterName = "Secuencia_del_Ejercicio";
                padreSecuencia_del_Ejercicio.DbType = DbType.String;
                padreSecuencia_del_Ejercicio.Value = (object)entity.Secuencia_del_Ejercicio ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Secuencia_de_Ejercicios>("sp_InsDetalle_Secuencia_de_Ejercicios" , padreFolio_Configuracion_Rutinas
, padreOrden_del_Ejercicio
, padreTipo_de_Ejercicio
, padreEnfoque
, padreSecuencia_del_Ejercicio
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

        public int Update(Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Configuracion_Rutinas = _dataProvider.GetParameter();
                paramUpdFolio_Configuracion_Rutinas.ParameterName = "Folio_Configuracion_Rutinas";
                paramUpdFolio_Configuracion_Rutinas.DbType = DbType.Int32;
                paramUpdFolio_Configuracion_Rutinas.Value = (object)entity.Folio_Configuracion_Rutinas ?? DBNull.Value;
                var paramUpdOrden_del_Ejercicio = _dataProvider.GetParameter();
                paramUpdOrden_del_Ejercicio.ParameterName = "Orden_del_Ejercicio";
                paramUpdOrden_del_Ejercicio.DbType = DbType.Int32;
                paramUpdOrden_del_Ejercicio.Value = (object)entity.Orden_del_Ejercicio ?? DBNull.Value;

                var paramUpdTipo_de_Ejercicio = _dataProvider.GetParameter();
                paramUpdTipo_de_Ejercicio.ParameterName = "Tipo_de_Ejercicio";
                paramUpdTipo_de_Ejercicio.DbType = DbType.Int32;
                paramUpdTipo_de_Ejercicio.Value = (object)entity.Tipo_de_Ejercicio ?? DBNull.Value;

                var paramUpdEnfoque = _dataProvider.GetParameter();
                paramUpdEnfoque.ParameterName = "Enfoque";
                paramUpdEnfoque.DbType = DbType.Int32;
                paramUpdEnfoque.Value = (object)entity.Enfoque ?? DBNull.Value;

                var paramUpdSecuencia_del_Ejercicio = _dataProvider.GetParameter();
                paramUpdSecuencia_del_Ejercicio.ParameterName = "Secuencia_del_Ejercicio";
                paramUpdSecuencia_del_Ejercicio.DbType = DbType.String;
                paramUpdSecuencia_del_Ejercicio.Value = (object)entity.Secuencia_del_Ejercicio ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Secuencia_de_Ejercicios>("sp_UpdDetalle_Secuencia_de_Ejercicios" , paramUpdFolio , paramUpdFolio_Configuracion_Rutinas , paramUpdOrden_del_Ejercicio , paramUpdTipo_de_Ejercicio , paramUpdEnfoque , paramUpdSecuencia_del_Ejercicio ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios Detalle_Secuencia_de_EjerciciosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Configuracion_Rutinas = _dataProvider.GetParameter();
                paramUpdFolio_Configuracion_Rutinas.ParameterName = "Folio_Configuracion_Rutinas";
                paramUpdFolio_Configuracion_Rutinas.DbType = DbType.Int32;
                paramUpdFolio_Configuracion_Rutinas.Value = (object)entity.Folio_Configuracion_Rutinas ?? DBNull.Value;
		var paramUpdOrden_del_Ejercicio = _dataProvider.GetParameter();
                paramUpdOrden_del_Ejercicio.ParameterName = "Orden_del_Ejercicio";
                paramUpdOrden_del_Ejercicio.DbType = DbType.Int32;
                paramUpdOrden_del_Ejercicio.Value = (object)entity.Orden_del_Ejercicio ?? DBNull.Value;
		var paramUpdTipo_de_Ejercicio = _dataProvider.GetParameter();
                paramUpdTipo_de_Ejercicio.ParameterName = "Tipo_de_Ejercicio";
                paramUpdTipo_de_Ejercicio.DbType = DbType.Int32;
                paramUpdTipo_de_Ejercicio.Value = (object)entity.Tipo_de_Ejercicio ?? DBNull.Value;
		var paramUpdEnfoque = _dataProvider.GetParameter();
                paramUpdEnfoque.ParameterName = "Enfoque";
                paramUpdEnfoque.DbType = DbType.Int32;
                paramUpdEnfoque.Value = (object)entity.Enfoque ?? DBNull.Value;
                var paramUpdSecuencia_del_Ejercicio = _dataProvider.GetParameter();
                paramUpdSecuencia_del_Ejercicio.ParameterName = "Secuencia_del_Ejercicio";
                paramUpdSecuencia_del_Ejercicio.DbType = DbType.String;
                paramUpdSecuencia_del_Ejercicio.Value = (object)entity.Secuencia_del_Ejercicio ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Secuencia_de_Ejercicios>("sp_UpdDetalle_Secuencia_de_Ejercicios" , paramUpdFolio , paramUpdFolio_Configuracion_Rutinas , paramUpdOrden_del_Ejercicio , paramUpdTipo_de_Ejercicio , paramUpdEnfoque , paramUpdSecuencia_del_Ejercicio ).FirstOrDefault();

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

