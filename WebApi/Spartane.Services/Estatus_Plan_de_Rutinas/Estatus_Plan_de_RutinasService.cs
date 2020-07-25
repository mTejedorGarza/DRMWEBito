using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Estatus_Plan_de_Rutinas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_Plan_de_Rutinas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_Plan_de_RutinasService : IEstatus_Plan_de_RutinasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas> _Estatus_Plan_de_RutinasRepository;
        #endregion

        #region Ctor
        public Estatus_Plan_de_RutinasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas> Estatus_Plan_de_RutinasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_Plan_de_RutinasRepository = Estatus_Plan_de_RutinasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Estatus_Plan_de_RutinasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas>("sp_SelAllEstatus_Plan_de_Rutinas");
        }

        public IList<Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEstatus_Plan_de_Rutinas_Complete>("sp_SelAllComplete_Estatus_Plan_de_Rutinas");
            return data.Select(m => new Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Estatus_Plan_de_Rutinas>("sp_ListSelCount_Estatus_Plan_de_Rutinas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_Plan_de_Rutinas>("sp_ListSelAll_Estatus_Plan_de_Rutinas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas
                {
                    Folio = m.Estatus_Plan_de_Rutinas_Folio,
                    Descripcion = m.Estatus_Plan_de_Rutinas_Descripcion,

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

        public IList<Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_Plan_de_RutinasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_Plan_de_RutinasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_RutinasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_Plan_de_Rutinas>("sp_ListSelAll_Estatus_Plan_de_Rutinas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Estatus_Plan_de_RutinasPagingModel result = null;

            if (data != null)
            {
                result = new Estatus_Plan_de_RutinasPagingModel
                {
                    Estatus_Plan_de_Rutinass =
                        data.Select(m => new Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas
                {
                    Folio = m.Estatus_Plan_de_Rutinas_Folio
                    ,Descripcion = m.Estatus_Plan_de_Rutinas_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_Plan_de_RutinasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas>("sp_GetEstatus_Plan_de_Rutinas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEstatus_Plan_de_Rutinas>("sp_DelEstatus_Plan_de_Rutinas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEstatus_Plan_de_Rutinas>("sp_InsEstatus_Plan_de_Rutinas" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_Plan_de_Rutinas>("sp_UpdEstatus_Plan_de_Rutinas" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Estatus_Plan_de_Rutinas.Estatus_Plan_de_Rutinas Estatus_Plan_de_RutinasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_Plan_de_Rutinas>("sp_UpdEstatus_Plan_de_Rutinas" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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

