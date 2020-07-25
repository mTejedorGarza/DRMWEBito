using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Resultado_de_Autorizacion;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Resultado_de_Autorizacion
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Resultado_de_AutorizacionService : IResultado_de_AutorizacionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion> _Resultado_de_AutorizacionRepository;
        #endregion

        #region Ctor
        public Resultado_de_AutorizacionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion> Resultado_de_AutorizacionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Resultado_de_AutorizacionRepository = Resultado_de_AutorizacionRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Resultado_de_AutorizacionRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion>("sp_SelAllResultado_de_Autorizacion");
        }

        public IList<Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallResultado_de_Autorizacion_Complete>("sp_SelAllComplete_Resultado_de_Autorizacion");
            return data.Select(m => new Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Resultado_de_Autorizacion>("sp_ListSelCount_Resultado_de_Autorizacion", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllResultado_de_Autorizacion>("sp_ListSelAll_Resultado_de_Autorizacion", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion
                {
                    Folio = m.Resultado_de_Autorizacion_Folio,
                    Nombre = m.Resultado_de_Autorizacion_Nombre,

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

        public IList<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Resultado_de_AutorizacionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Resultado_de_AutorizacionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_AutorizacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllResultado_de_Autorizacion>("sp_ListSelAll_Resultado_de_Autorizacion", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Resultado_de_AutorizacionPagingModel result = null;

            if (data != null)
            {
                result = new Resultado_de_AutorizacionPagingModel
                {
                    Resultado_de_Autorizacions =
                        data.Select(m => new Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion
                {
                    Folio = m.Resultado_de_Autorizacion_Folio
                    ,Nombre = m.Resultado_de_Autorizacion_Nombre

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Resultado_de_AutorizacionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion>("sp_GetResultado_de_Autorizacion", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelResultado_de_Autorizacion>("sp_DelResultado_de_Autorizacion", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsResultado_de_Autorizacion>("sp_InsResultado_de_Autorizacion" , padreNombre
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

        public int Update(Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdResultado_de_Autorizacion>("sp_UpdResultado_de_Autorizacion" , paramUpdFolio , paramUpdNombre ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Resultado_de_Autorizacion.Resultado_de_Autorizacion Resultado_de_AutorizacionDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdResultado_de_Autorizacion>("sp_UpdResultado_de_Autorizacion" , paramUpdFolio , paramUpdNombre ).FirstOrDefault();

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

