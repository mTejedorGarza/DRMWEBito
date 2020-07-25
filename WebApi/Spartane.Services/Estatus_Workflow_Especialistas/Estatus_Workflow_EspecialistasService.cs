using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Estatus_Workflow_Especialistas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_Workflow_Especialistas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_Workflow_EspecialistasService : IEstatus_Workflow_EspecialistasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas> _Estatus_Workflow_EspecialistasRepository;
        #endregion

        #region Ctor
        public Estatus_Workflow_EspecialistasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas> Estatus_Workflow_EspecialistasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_Workflow_EspecialistasRepository = Estatus_Workflow_EspecialistasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Estatus_Workflow_EspecialistasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas>("sp_SelAllEstatus_Workflow_Especialistas");
        }

        public IList<Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEstatus_Workflow_Especialistas_Complete>("sp_SelAllComplete_Estatus_Workflow_Especialistas");
            return data.Select(m => new Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas
            {
                Clave = m.Clave
                ,Estatus = m.Estatus


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Estatus_Workflow_Especialistas>("sp_ListSelCount_Estatus_Workflow_Especialistas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_Workflow_Especialistas>("sp_ListSelAll_Estatus_Workflow_Especialistas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas
                {
                    Clave = m.Estatus_Workflow_Especialistas_Clave,
                    Estatus = m.Estatus_Workflow_Especialistas_Estatus,

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

        public IList<Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_Workflow_EspecialistasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_Workflow_EspecialistasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_EspecialistasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_Workflow_Especialistas>("sp_ListSelAll_Estatus_Workflow_Especialistas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Estatus_Workflow_EspecialistasPagingModel result = null;

            if (data != null)
            {
                result = new Estatus_Workflow_EspecialistasPagingModel
                {
                    Estatus_Workflow_Especialistass =
                        data.Select(m => new Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas
                {
                    Clave = m.Estatus_Workflow_Especialistas_Clave
                    ,Estatus = m.Estatus_Workflow_Especialistas_Estatus

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_Workflow_EspecialistasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas>("sp_GetEstatus_Workflow_Especialistas", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Clave";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEstatus_Workflow_Especialistas>("sp_DelEstatus_Workflow_Especialistas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.String;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEstatus_Workflow_Especialistas>("sp_InsEstatus_Workflow_Especialistas" , padreEstatus
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);

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

        public int Update(Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.String;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_Workflow_Especialistas>("sp_UpdEstatus_Workflow_Especialistas" , paramUpdClave , paramUpdEstatus ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);
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
		public int Update_Datos_Generales(Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas Estatus_Workflow_EspecialistasDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.String;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_Workflow_Especialistas>("sp_UpdEstatus_Workflow_Especialistas" , paramUpdClave , paramUpdEstatus ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);
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

