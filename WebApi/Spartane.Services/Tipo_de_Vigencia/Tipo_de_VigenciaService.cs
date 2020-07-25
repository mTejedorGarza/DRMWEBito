using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Tipo_de_Vigencia;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tipo_de_Vigencia
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tipo_de_VigenciaService : ITipo_de_VigenciaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia> _Tipo_de_VigenciaRepository;
        #endregion

        #region Ctor
        public Tipo_de_VigenciaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia> Tipo_de_VigenciaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tipo_de_VigenciaRepository = Tipo_de_VigenciaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Tipo_de_VigenciaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia>("sp_SelAllTipo_de_Vigencia");
        }

        public IList<Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTipo_de_Vigencia_Complete>("sp_SelAllComplete_Tipo_de_Vigencia");
            return data.Select(m => new Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia
            {
                Clave = m.Clave
                ,Vigencia = m.Vigencia


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Tipo_de_Vigencia>("sp_ListSelCount_Tipo_de_Vigencia", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipo_de_Vigencia>("sp_ListSelAll_Tipo_de_Vigencia", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia
                {
                    Clave = m.Tipo_de_Vigencia_Clave,
                    Vigencia = m.Tipo_de_Vigencia_Vigencia,

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

        public IList<Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tipo_de_VigenciaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipo_de_VigenciaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_VigenciaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipo_de_Vigencia>("sp_ListSelAll_Tipo_de_Vigencia", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Tipo_de_VigenciaPagingModel result = null;

            if (data != null)
            {
                result = new Tipo_de_VigenciaPagingModel
                {
                    Tipo_de_Vigencias =
                        data.Select(m => new Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia
                {
                    Clave = m.Tipo_de_Vigencia_Clave
                    ,Vigencia = m.Tipo_de_Vigencia_Vigencia

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tipo_de_VigenciaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia>("sp_GetTipo_de_Vigencia", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTipo_de_Vigencia>("sp_DelTipo_de_Vigencia", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreVigencia = _dataProvider.GetParameter();
                padreVigencia.ParameterName = "Vigencia";
                padreVigencia.DbType = DbType.String;
                padreVigencia.Value = (object)entity.Vigencia ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTipo_de_Vigencia>("sp_InsTipo_de_Vigencia" , padreVigencia
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

        public int Update(Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdVigencia = _dataProvider.GetParameter();
                paramUpdVigencia.ParameterName = "Vigencia";
                paramUpdVigencia.DbType = DbType.String;
                paramUpdVigencia.Value = (object)entity.Vigencia ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipo_de_Vigencia>("sp_UpdTipo_de_Vigencia" , paramUpdClave , paramUpdVigencia ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Tipo_de_Vigencia.Tipo_de_Vigencia Tipo_de_VigenciaDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdVigencia = _dataProvider.GetParameter();
                paramUpdVigencia.ParameterName = "Vigencia";
                paramUpdVigencia.DbType = DbType.String;
                paramUpdVigencia.Value = (object)entity.Vigencia ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipo_de_Vigencia>("sp_UpdTipo_de_Vigencia" , paramUpdClave , paramUpdVigencia ).FirstOrDefault();

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

