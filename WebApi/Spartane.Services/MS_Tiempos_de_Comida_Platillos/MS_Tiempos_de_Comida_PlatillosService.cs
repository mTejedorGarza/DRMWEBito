using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Tiempos_de_Comida_Platillos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Tiempos_de_Comida_PlatillosService : IMS_Tiempos_de_Comida_PlatillosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos> _MS_Tiempos_de_Comida_PlatillosRepository;
        #endregion

        #region Ctor
        public MS_Tiempos_de_Comida_PlatillosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos> MS_Tiempos_de_Comida_PlatillosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Tiempos_de_Comida_PlatillosRepository = MS_Tiempos_de_Comida_PlatillosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_Tiempos_de_Comida_PlatillosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos>("sp_SelAllMS_Tiempos_de_Comida_Platillos");
        }

        public IList<Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_Tiempos_de_Comida_Platillos_Complete>("sp_SelAllComplete_MS_Tiempos_de_Comida_Platillos");
            return data.Select(m => new Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos
            {
                Folio = m.Folio
                ,Folio_Platillos = m.Folio_Platillos
                ,Tiempo_de_Comida_Tiempos_de_Comida = new Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida() { Clave = m.Tiempo_de_Comida.GetValueOrDefault(), Comida = m.Tiempo_de_Comida_Comida }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_Tiempos_de_Comida_Platillos>("sp_ListSelCount_MS_Tiempos_de_Comida_Platillos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Tiempos_de_Comida_Platillos>("sp_ListSelAll_MS_Tiempos_de_Comida_Platillos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos
                {
                    Folio = m.MS_Tiempos_de_Comida_Platillos_Folio,
                    Folio_Platillos = m.MS_Tiempos_de_Comida_Platillos_Folio_Platillos,
                    Tiempo_de_Comida = m.MS_Tiempos_de_Comida_Platillos_Tiempo_de_Comida,

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

        public IList<Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Tiempos_de_Comida_PlatillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Tiempos_de_Comida_PlatillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_PlatillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Tiempos_de_Comida_Platillos>("sp_ListSelAll_MS_Tiempos_de_Comida_Platillos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_Tiempos_de_Comida_PlatillosPagingModel result = null;

            if (data != null)
            {
                result = new MS_Tiempos_de_Comida_PlatillosPagingModel
                {
                    MS_Tiempos_de_Comida_Platilloss =
                        data.Select(m => new Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos
                {
                    Folio = m.MS_Tiempos_de_Comida_Platillos_Folio
                    ,Folio_Platillos = m.MS_Tiempos_de_Comida_Platillos_Folio_Platillos
                    ,Tiempo_de_Comida = m.MS_Tiempos_de_Comida_Platillos_Tiempo_de_Comida
                    ,Tiempo_de_Comida_Tiempos_de_Comida = new Core.Classes.Tiempos_de_Comida.Tiempos_de_Comida() { Clave = m.MS_Tiempos_de_Comida_Platillos_Tiempo_de_Comida.GetValueOrDefault(), Comida = m.MS_Tiempos_de_Comida_Platillos_Tiempo_de_Comida_Comida }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Tiempos_de_Comida_PlatillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos>("sp_GetMS_Tiempos_de_Comida_Platillos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_Tiempos_de_Comida_Platillos>("sp_DelMS_Tiempos_de_Comida_Platillos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Platillos = _dataProvider.GetParameter();
                padreFolio_Platillos.ParameterName = "Folio_Platillos";
                padreFolio_Platillos.DbType = DbType.Int32;
                padreFolio_Platillos.Value = (object)entity.Folio_Platillos ?? DBNull.Value;
                var padreTiempo_de_Comida = _dataProvider.GetParameter();
                padreTiempo_de_Comida.ParameterName = "Tiempo_de_Comida";
                padreTiempo_de_Comida.DbType = DbType.Int32;
                padreTiempo_de_Comida.Value = (object)entity.Tiempo_de_Comida ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_Tiempos_de_Comida_Platillos>("sp_InsMS_Tiempos_de_Comida_Platillos" , padreFolio_Platillos
, padreTiempo_de_Comida
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

        public int Update(Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Platillos = _dataProvider.GetParameter();
                paramUpdFolio_Platillos.ParameterName = "Folio_Platillos";
                paramUpdFolio_Platillos.DbType = DbType.Int32;
                paramUpdFolio_Platillos.Value = (object)entity.Folio_Platillos ?? DBNull.Value;
                var paramUpdTiempo_de_Comida = _dataProvider.GetParameter();
                paramUpdTiempo_de_Comida.ParameterName = "Tiempo_de_Comida";
                paramUpdTiempo_de_Comida.DbType = DbType.Int32;
                paramUpdTiempo_de_Comida.Value = (object)entity.Tiempo_de_Comida ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Tiempos_de_Comida_Platillos>("sp_UpdMS_Tiempos_de_Comida_Platillos" , paramUpdFolio , paramUpdFolio_Platillos , paramUpdTiempo_de_Comida ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_Tiempos_de_Comida_Platillos.MS_Tiempos_de_Comida_Platillos MS_Tiempos_de_Comida_PlatillosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Platillos = _dataProvider.GetParameter();
                paramUpdFolio_Platillos.ParameterName = "Folio_Platillos";
                paramUpdFolio_Platillos.DbType = DbType.Int32;
                paramUpdFolio_Platillos.Value = (object)entity.Folio_Platillos ?? DBNull.Value;
		var paramUpdTiempo_de_Comida = _dataProvider.GetParameter();
                paramUpdTiempo_de_Comida.ParameterName = "Tiempo_de_Comida";
                paramUpdTiempo_de_Comida.DbType = DbType.Int32;
                paramUpdTiempo_de_Comida.Value = (object)entity.Tiempo_de_Comida ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Tiempos_de_Comida_Platillos>("sp_UpdMS_Tiempos_de_Comida_Platillos" , paramUpdFolio , paramUpdFolio_Platillos , paramUpdTiempo_de_Comida ).FirstOrDefault();

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

