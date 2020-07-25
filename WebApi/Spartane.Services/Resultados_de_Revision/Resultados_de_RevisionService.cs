using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Resultados_de_Revision;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Resultados_de_Revision
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Resultados_de_RevisionService : IResultados_de_RevisionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision> _Resultados_de_RevisionRepository;
        #endregion

        #region Ctor
        public Resultados_de_RevisionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision> Resultados_de_RevisionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Resultados_de_RevisionRepository = Resultados_de_RevisionRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Resultados_de_RevisionRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision>("sp_SelAllResultados_de_Revision");
        }

        public IList<Core.Classes.Resultados_de_Revision.Resultados_de_Revision> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallResultados_de_Revision_Complete>("sp_SelAllComplete_Resultados_de_Revision");
            return data.Select(m => new Core.Classes.Resultados_de_Revision.Resultados_de_Revision
            {
                Folio = m.Folio
                ,Nombre = m.Nombre


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Resultados_de_Revision>("sp_ListSelCount_Resultados_de_Revision", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllResultados_de_Revision>("sp_ListSelAll_Resultados_de_Revision", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision
                {
                    Folio = m.Resultados_de_Revision_Folio,
                    Nombre = m.Resultados_de_Revision_Nombre,

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

        public IList<Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Resultados_de_RevisionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Resultados_de_RevisionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_RevisionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllResultados_de_Revision>("sp_ListSelAll_Resultados_de_Revision", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Resultados_de_RevisionPagingModel result = null;

            if (data != null)
            {
                result = new Resultados_de_RevisionPagingModel
                {
                    Resultados_de_Revisions =
                        data.Select(m => new Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision
                {
                    Folio = m.Resultados_de_Revision_Folio
                    ,Nombre = m.Resultados_de_Revision_Nombre

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Resultados_de_RevisionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision>("sp_GetResultados_de_Revision", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelResultados_de_Revision>("sp_DelResultados_de_Revision", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.String;
                padreNombre.Value = (object)entity.Nombre ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsResultados_de_Revision>("sp_InsResultados_de_Revision" , padreNombre
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

        public int Update(Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdResultados_de_Revision>("sp_UpdResultados_de_Revision" , paramUpdFolio , paramUpdNombre ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Resultados_de_Revision.Resultados_de_Revision Resultados_de_RevisionDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdResultados_de_Revision>("sp_UpdResultados_de_Revision" , paramUpdFolio , paramUpdNombre ).FirstOrDefault();

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

