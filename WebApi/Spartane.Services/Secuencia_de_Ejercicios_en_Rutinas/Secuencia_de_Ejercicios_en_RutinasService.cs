using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Secuencia_de_Ejercicios_en_Rutinas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Secuencia_de_Ejercicios_en_RutinasService : ISecuencia_de_Ejercicios_en_RutinasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas> _Secuencia_de_Ejercicios_en_RutinasRepository;
        #endregion

        #region Ctor
        public Secuencia_de_Ejercicios_en_RutinasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas> Secuencia_de_Ejercicios_en_RutinasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Secuencia_de_Ejercicios_en_RutinasRepository = Secuencia_de_Ejercicios_en_RutinasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Secuencia_de_Ejercicios_en_RutinasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas>("sp_SelAllSecuencia_de_Ejercicios_en_Rutinas");
        }

        public IList<Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallSecuencia_de_Ejercicios_en_Rutinas_Complete>("sp_SelAllComplete_Secuencia_de_Ejercicios_en_Rutinas");
            return data.Select(m => new Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Secuencia_de_Ejercicios_en_Rutinas>("sp_ListSelCount_Secuencia_de_Ejercicios_en_Rutinas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSecuencia_de_Ejercicios_en_Rutinas>("sp_ListSelAll_Secuencia_de_Ejercicios_en_Rutinas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas
                {
                    Folio = m.Secuencia_de_Ejercicios_en_Rutinas_Folio,
                    Descripcion = m.Secuencia_de_Ejercicios_en_Rutinas_Descripcion,

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

        public IList<Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Secuencia_de_Ejercicios_en_RutinasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Secuencia_de_Ejercicios_en_RutinasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_RutinasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllSecuencia_de_Ejercicios_en_Rutinas>("sp_ListSelAll_Secuencia_de_Ejercicios_en_Rutinas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Secuencia_de_Ejercicios_en_RutinasPagingModel result = null;

            if (data != null)
            {
                result = new Secuencia_de_Ejercicios_en_RutinasPagingModel
                {
                    Secuencia_de_Ejercicios_en_Rutinass =
                        data.Select(m => new Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas
                {
                    Folio = m.Secuencia_de_Ejercicios_en_Rutinas_Folio
                    ,Descripcion = m.Secuencia_de_Ejercicios_en_Rutinas_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Secuencia_de_Ejercicios_en_RutinasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas>("sp_GetSecuencia_de_Ejercicios_en_Rutinas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSecuencia_de_Ejercicios_en_Rutinas>("sp_DelSecuencia_de_Ejercicios_en_Rutinas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsSecuencia_de_Ejercicios_en_Rutinas>("sp_InsSecuencia_de_Ejercicios_en_Rutinas" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSecuencia_de_Ejercicios_en_Rutinas>("sp_UpdSecuencia_de_Ejercicios_en_Rutinas" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Secuencia_de_Ejercicios_en_Rutinas.Secuencia_de_Ejercicios_en_Rutinas Secuencia_de_Ejercicios_en_RutinasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdSecuencia_de_Ejercicios_en_Rutinas>("sp_UpdSecuencia_de_Ejercicios_en_Rutinas" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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

