using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_Dificultad_Platillos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Dificultad_Platillos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Dificultad_PlatillosService : IMS_Dificultad_PlatillosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos> _MS_Dificultad_PlatillosRepository;
        #endregion

        #region Ctor
        public MS_Dificultad_PlatillosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos> MS_Dificultad_PlatillosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Dificultad_PlatillosRepository = MS_Dificultad_PlatillosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_Dificultad_PlatillosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos>("sp_SelAllMS_Dificultad_Platillos");
        }

        public IList<Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_Dificultad_Platillos_Complete>("sp_SelAllComplete_MS_Dificultad_Platillos");
            return data.Select(m => new Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos
            {
                Folio = m.Folio
                ,Folio_Platillos = m.Folio_Platillos
                ,Dificultad_Dificultad_de_platillos = new Core.Classes.Dificultad_de_platillos.Dificultad_de_platillos() { Clave = m.Dificultad.GetValueOrDefault(), Categoria = m.Dificultad_Categoria }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_Dificultad_Platillos>("sp_ListSelCount_MS_Dificultad_Platillos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Dificultad_Platillos>("sp_ListSelAll_MS_Dificultad_Platillos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos
                {
                    Folio = m.MS_Dificultad_Platillos_Folio,
                    Folio_Platillos = m.MS_Dificultad_Platillos_Folio_Platillos,
                    Dificultad = m.MS_Dificultad_Platillos_Dificultad,

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

        public IList<Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Dificultad_PlatillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Dificultad_PlatillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_PlatillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Dificultad_Platillos>("sp_ListSelAll_MS_Dificultad_Platillos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_Dificultad_PlatillosPagingModel result = null;

            if (data != null)
            {
                result = new MS_Dificultad_PlatillosPagingModel
                {
                    MS_Dificultad_Platilloss =
                        data.Select(m => new Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos
                {
                    Folio = m.MS_Dificultad_Platillos_Folio
                    ,Folio_Platillos = m.MS_Dificultad_Platillos_Folio_Platillos
                    ,Dificultad = m.MS_Dificultad_Platillos_Dificultad
                    ,Dificultad_Dificultad_de_platillos = new Core.Classes.Dificultad_de_platillos.Dificultad_de_platillos() { Clave = m.MS_Dificultad_Platillos_Dificultad.GetValueOrDefault(), Categoria = m.MS_Dificultad_Platillos_Dificultad_Categoria }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Dificultad_PlatillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos>("sp_GetMS_Dificultad_Platillos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_Dificultad_Platillos>("sp_DelMS_Dificultad_Platillos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos entity)
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
                var padreDificultad = _dataProvider.GetParameter();
                padreDificultad.ParameterName = "Dificultad";
                padreDificultad.DbType = DbType.Int32;
                padreDificultad.Value = (object)entity.Dificultad ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_Dificultad_Platillos>("sp_InsMS_Dificultad_Platillos" , padreFolio_Platillos
, padreDificultad
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

        public int Update(Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos entity)
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
                var paramUpdDificultad = _dataProvider.GetParameter();
                paramUpdDificultad.ParameterName = "Dificultad";
                paramUpdDificultad.DbType = DbType.Int32;
                paramUpdDificultad.Value = (object)entity.Dificultad ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Dificultad_Platillos>("sp_UpdMS_Dificultad_Platillos" , paramUpdFolio , paramUpdFolio_Platillos , paramUpdDificultad ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_Dificultad_Platillos.MS_Dificultad_Platillos MS_Dificultad_PlatillosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Platillos = _dataProvider.GetParameter();
                paramUpdFolio_Platillos.ParameterName = "Folio_Platillos";
                paramUpdFolio_Platillos.DbType = DbType.Int32;
                paramUpdFolio_Platillos.Value = (object)entity.Folio_Platillos ?? DBNull.Value;
		var paramUpdDificultad = _dataProvider.GetParameter();
                paramUpdDificultad.ParameterName = "Dificultad";
                paramUpdDificultad.DbType = DbType.Int32;
                paramUpdDificultad.Value = (object)entity.Dificultad ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Dificultad_Platillos>("sp_UpdMS_Dificultad_Platillos" , paramUpdFolio , paramUpdFolio_Platillos , paramUpdDificultad ).FirstOrDefault();

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

