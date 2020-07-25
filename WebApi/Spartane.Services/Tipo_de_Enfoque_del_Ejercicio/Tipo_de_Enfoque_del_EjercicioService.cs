using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tipo_de_Enfoque_del_Ejercicio
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tipo_de_Enfoque_del_EjercicioService : ITipo_de_Enfoque_del_EjercicioService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio> _Tipo_de_Enfoque_del_EjercicioRepository;
        #endregion

        #region Ctor
        public Tipo_de_Enfoque_del_EjercicioService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio> Tipo_de_Enfoque_del_EjercicioRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tipo_de_Enfoque_del_EjercicioRepository = Tipo_de_Enfoque_del_EjercicioRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Tipo_de_Enfoque_del_EjercicioRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio>("sp_SelAllTipo_de_Enfoque_del_Ejercicio");
        }

        public IList<Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTipo_de_Enfoque_del_Ejercicio_Complete>("sp_SelAllComplete_Tipo_de_Enfoque_del_Ejercicio");
            return data.Select(m => new Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio
            {
                Folio = m.Folio
                ,Descripcion = m.Descripcion


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Tipo_de_Enfoque_del_Ejercicio>("sp_ListSelCount_Tipo_de_Enfoque_del_Ejercicio", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipo_de_Enfoque_del_Ejercicio>("sp_ListSelAll_Tipo_de_Enfoque_del_Ejercicio", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio
                {
                    Folio = m.Tipo_de_Enfoque_del_Ejercicio_Folio,
                    Descripcion = m.Tipo_de_Enfoque_del_Ejercicio_Descripcion,

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

        public IList<Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tipo_de_Enfoque_del_EjercicioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipo_de_Enfoque_del_EjercicioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_EjercicioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipo_de_Enfoque_del_Ejercicio>("sp_ListSelAll_Tipo_de_Enfoque_del_Ejercicio", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Tipo_de_Enfoque_del_EjercicioPagingModel result = null;

            if (data != null)
            {
                result = new Tipo_de_Enfoque_del_EjercicioPagingModel
                {
                    Tipo_de_Enfoque_del_Ejercicios =
                        data.Select(m => new Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio
                {
                    Folio = m.Tipo_de_Enfoque_del_Ejercicio_Folio
                    ,Descripcion = m.Tipo_de_Enfoque_del_Ejercicio_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tipo_de_Enfoque_del_EjercicioRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio>("sp_GetTipo_de_Enfoque_del_Ejercicio", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTipo_de_Enfoque_del_Ejercicio>("sp_DelTipo_de_Enfoque_del_Ejercicio", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio entity)
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
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTipo_de_Enfoque_del_Ejercicio>("sp_InsTipo_de_Enfoque_del_Ejercicio" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio entity)
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


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipo_de_Enfoque_del_Ejercicio>("sp_UpdTipo_de_Enfoque_del_Ejercicio" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Tipo_de_Enfoque_del_Ejercicio.Tipo_de_Enfoque_del_Ejercicio Tipo_de_Enfoque_del_EjercicioDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipo_de_Enfoque_del_Ejercicio>("sp_UpdTipo_de_Enfoque_del_Ejercicio" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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

