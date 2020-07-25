using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tipo_de_Ejercicio_Rutina
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tipo_de_Ejercicio_RutinaService : ITipo_de_Ejercicio_RutinaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> _Tipo_de_Ejercicio_RutinaRepository;
        #endregion

        #region Ctor
        public Tipo_de_Ejercicio_RutinaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> Tipo_de_Ejercicio_RutinaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tipo_de_Ejercicio_RutinaRepository = Tipo_de_Ejercicio_RutinaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Tipo_de_Ejercicio_RutinaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina>("sp_SelAllTipo_de_Ejercicio_Rutina");
        }

        public IList<Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTipo_de_Ejercicio_Rutina_Complete>("sp_SelAllComplete_Tipo_de_Ejercicio_Rutina");
            return data.Select(m => new Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina
            {
                Folio = m.Folio
                ,Descripcion = m.Descripcion
                ,Tipo_de_Rutina = m.Tipo_de_Rutina
                ,Nombre_para_Secuencia = m.Nombre_para_Secuencia


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Tipo_de_Ejercicio_Rutina>("sp_ListSelCount_Tipo_de_Ejercicio_Rutina", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipo_de_Ejercicio_Rutina>("sp_ListSelAll_Tipo_de_Ejercicio_Rutina", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina
                {
                    Folio = m.Tipo_de_Ejercicio_Rutina_Folio,
                    Descripcion = m.Tipo_de_Ejercicio_Rutina_Descripcion,
                    Tipo_de_Rutina = m.Tipo_de_Ejercicio_Rutina_Tipo_de_Rutina,
                    Nombre_para_Secuencia = m.Tipo_de_Ejercicio_Rutina_Nombre_para_Secuencia,

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

        public IList<Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tipo_de_Ejercicio_RutinaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipo_de_Ejercicio_RutinaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_RutinaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipo_de_Ejercicio_Rutina>("sp_ListSelAll_Tipo_de_Ejercicio_Rutina", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Tipo_de_Ejercicio_RutinaPagingModel result = null;

            if (data != null)
            {
                result = new Tipo_de_Ejercicio_RutinaPagingModel
                {
                    Tipo_de_Ejercicio_Rutinas =
                        data.Select(m => new Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina
                {
                    Folio = m.Tipo_de_Ejercicio_Rutina_Folio
                    ,Descripcion = m.Tipo_de_Ejercicio_Rutina_Descripcion
                    ,Tipo_de_Rutina = m.Tipo_de_Ejercicio_Rutina_Tipo_de_Rutina
                    ,Nombre_para_Secuencia = m.Tipo_de_Ejercicio_Rutina_Nombre_para_Secuencia

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tipo_de_Ejercicio_RutinaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina>("sp_GetTipo_de_Ejercicio_Rutina", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTipo_de_Ejercicio_Rutina>("sp_DelTipo_de_Ejercicio_Rutina", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var padreTipo_de_Rutina = _dataProvider.GetParameter();
                padreTipo_de_Rutina.ParameterName = "Tipo_de_Rutina";
                padreTipo_de_Rutina.DbType = DbType.String;
                padreTipo_de_Rutina.Value = (object)entity.Tipo_de_Rutina ?? DBNull.Value;
                var padreNombre_para_Secuencia = _dataProvider.GetParameter();
                padreNombre_para_Secuencia.ParameterName = "Nombre_para_Secuencia";
                padreNombre_para_Secuencia.DbType = DbType.String;
                padreNombre_para_Secuencia.Value = (object)entity.Nombre_para_Secuencia ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTipo_de_Ejercicio_Rutina>("sp_InsTipo_de_Ejercicio_Rutina" , padreDescripcion
, padreTipo_de_Rutina
, padreNombre_para_Secuencia
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

        public int Update(Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdTipo_de_Rutina = _dataProvider.GetParameter();
                paramUpdTipo_de_Rutina.ParameterName = "Tipo_de_Rutina";
                paramUpdTipo_de_Rutina.DbType = DbType.String;
                paramUpdTipo_de_Rutina.Value = (object)entity.Tipo_de_Rutina ?? DBNull.Value;
                var paramUpdNombre_para_Secuencia = _dataProvider.GetParameter();
                paramUpdNombre_para_Secuencia.ParameterName = "Nombre_para_Secuencia";
                paramUpdNombre_para_Secuencia.DbType = DbType.String;
                paramUpdNombre_para_Secuencia.Value = (object)entity.Nombre_para_Secuencia ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipo_de_Ejercicio_Rutina>("sp_UpdTipo_de_Ejercicio_Rutina" , paramUpdFolio , paramUpdDescripcion , paramUpdTipo_de_Rutina , paramUpdNombre_para_Secuencia ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina Tipo_de_Ejercicio_RutinaDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdTipo_de_Rutina = _dataProvider.GetParameter();
                paramUpdTipo_de_Rutina.ParameterName = "Tipo_de_Rutina";
                paramUpdTipo_de_Rutina.DbType = DbType.String;
                paramUpdTipo_de_Rutina.Value = (object)entity.Tipo_de_Rutina ?? DBNull.Value;
                var paramUpdNombre_para_Secuencia = _dataProvider.GetParameter();
                paramUpdNombre_para_Secuencia.ParameterName = "Nombre_para_Secuencia";
                paramUpdNombre_para_Secuencia.DbType = DbType.String;
                paramUpdNombre_para_Secuencia.Value = (object)entity.Nombre_para_Secuencia ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipo_de_Ejercicio_Rutina>("sp_UpdTipo_de_Ejercicio_Rutina" , paramUpdFolio , paramUpdDescripcion , paramUpdTipo_de_Rutina , paramUpdNombre_para_Secuencia ).FirstOrDefault();

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

