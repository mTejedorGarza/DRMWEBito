using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MR_Padecimientos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MR_Padecimientos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MR_PadecimientosService : IMR_PadecimientosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos> _MR_PadecimientosRepository;
        #endregion

        #region Ctor
        public MR_PadecimientosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos> MR_PadecimientosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MR_PadecimientosRepository = MR_PadecimientosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MR_PadecimientosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos>("sp_SelAllMR_Padecimientos");
        }

        public IList<Core.Classes.MR_Padecimientos.MR_Padecimientos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMR_Padecimientos_Complete>("sp_SelAllComplete_MR_Padecimientos");
            return data.Select(m => new Core.Classes.MR_Padecimientos.MR_Padecimientos
            {
                Folio = m.Folio
                ,Folio_Rangos_Pediatria_por_Platillos = m.Folio_Rangos_Pediatria_por_Platillos
                ,Padecimiento_Padecimientos = new Core.Classes.Padecimientos.Padecimientos() { Clave = m.Padecimiento.GetValueOrDefault(), Descripcion = m.Padecimiento_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MR_Padecimientos>("sp_ListSelCount_MR_Padecimientos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMR_Padecimientos>("sp_ListSelAll_MR_Padecimientos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos
                {
                    Folio = m.MR_Padecimientos_Folio,
                    Folio_Rangos_Pediatria_por_Platillos = m.MR_Padecimientos_Folio_Rangos_Pediatria_por_Platillos,
                    Padecimiento = m.MR_Padecimientos_Padecimiento,

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

        public IList<Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MR_PadecimientosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MR_PadecimientosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MR_Padecimientos.MR_PadecimientosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMR_Padecimientos>("sp_ListSelAll_MR_Padecimientos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MR_PadecimientosPagingModel result = null;

            if (data != null)
            {
                result = new MR_PadecimientosPagingModel
                {
                    MR_Padecimientoss =
                        data.Select(m => new Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos
                {
                    Folio = m.MR_Padecimientos_Folio
                    ,Folio_Rangos_Pediatria_por_Platillos = m.MR_Padecimientos_Folio_Rangos_Pediatria_por_Platillos
                    ,Padecimiento = m.MR_Padecimientos_Padecimiento
                    ,Padecimiento_Padecimientos = new Core.Classes.Padecimientos.Padecimientos() { Clave = m.MR_Padecimientos_Padecimiento.GetValueOrDefault(), Descripcion = m.MR_Padecimientos_Padecimiento_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MR_PadecimientosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos>("sp_GetMR_Padecimientos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMR_Padecimientos>("sp_DelMR_Padecimientos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Rangos_Pediatria_por_Platillos = _dataProvider.GetParameter();
                padreFolio_Rangos_Pediatria_por_Platillos.ParameterName = "Folio_Rangos_Pediatria_por_Platillos";
                padreFolio_Rangos_Pediatria_por_Platillos.DbType = DbType.Int32;
                padreFolio_Rangos_Pediatria_por_Platillos.Value = (object)entity.Folio_Rangos_Pediatria_por_Platillos ?? DBNull.Value;
                var padrePadecimiento = _dataProvider.GetParameter();
                padrePadecimiento.ParameterName = "Padecimiento";
                padrePadecimiento.DbType = DbType.Int32;
                padrePadecimiento.Value = (object)entity.Padecimiento ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMR_Padecimientos>("sp_InsMR_Padecimientos" , padreFolio_Rangos_Pediatria_por_Platillos
, padrePadecimiento
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

        public int Update(Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Rangos_Pediatria_por_Platillos = _dataProvider.GetParameter();
                paramUpdFolio_Rangos_Pediatria_por_Platillos.ParameterName = "Folio_Rangos_Pediatria_por_Platillos";
                paramUpdFolio_Rangos_Pediatria_por_Platillos.DbType = DbType.Int32;
                paramUpdFolio_Rangos_Pediatria_por_Platillos.Value = (object)entity.Folio_Rangos_Pediatria_por_Platillos ?? DBNull.Value;
                var paramUpdPadecimiento = _dataProvider.GetParameter();
                paramUpdPadecimiento.ParameterName = "Padecimiento";
                paramUpdPadecimiento.DbType = DbType.Int32;
                paramUpdPadecimiento.Value = (object)entity.Padecimiento ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMR_Padecimientos>("sp_UpdMR_Padecimientos" , paramUpdFolio , paramUpdFolio_Rangos_Pediatria_por_Platillos , paramUpdPadecimiento ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MR_Padecimientos.MR_Padecimientos MR_PadecimientosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Rangos_Pediatria_por_Platillos = _dataProvider.GetParameter();
                paramUpdFolio_Rangos_Pediatria_por_Platillos.ParameterName = "Folio_Rangos_Pediatria_por_Platillos";
                paramUpdFolio_Rangos_Pediatria_por_Platillos.DbType = DbType.Int32;
                paramUpdFolio_Rangos_Pediatria_por_Platillos.Value = (object)entity.Folio_Rangos_Pediatria_por_Platillos ?? DBNull.Value;
		var paramUpdPadecimiento = _dataProvider.GetParameter();
                paramUpdPadecimiento.ParameterName = "Padecimiento";
                paramUpdPadecimiento.DbType = DbType.Int32;
                paramUpdPadecimiento.Value = (object)entity.Padecimiento ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMR_Padecimientos>("sp_UpdMR_Padecimientos" , paramUpdFolio , paramUpdFolio_Rangos_Pediatria_por_Platillos , paramUpdPadecimiento ).FirstOrDefault();

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

