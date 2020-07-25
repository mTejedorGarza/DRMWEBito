using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Estatus_de_Pago_de_Facturas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_de_Pago_de_Facturas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_de_Pago_de_FacturasService : IEstatus_de_Pago_de_FacturasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas> _Estatus_de_Pago_de_FacturasRepository;
        #endregion

        #region Ctor
        public Estatus_de_Pago_de_FacturasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas> Estatus_de_Pago_de_FacturasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_de_Pago_de_FacturasRepository = Estatus_de_Pago_de_FacturasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Estatus_de_Pago_de_FacturasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas>("sp_SelAllEstatus_de_Pago_de_Facturas");
        }

        public IList<Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEstatus_de_Pago_de_Facturas_Complete>("sp_SelAllComplete_Estatus_de_Pago_de_Facturas");
            return data.Select(m => new Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Estatus_de_Pago_de_Facturas>("sp_ListSelCount_Estatus_de_Pago_de_Facturas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_de_Pago_de_Facturas>("sp_ListSelAll_Estatus_de_Pago_de_Facturas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas
                {
                    Folio = m.Estatus_de_Pago_de_Facturas_Folio,
                    Nombre = m.Estatus_de_Pago_de_Facturas_Nombre,

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

        public IList<Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_de_Pago_de_FacturasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_de_Pago_de_FacturasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_FacturasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_de_Pago_de_Facturas>("sp_ListSelAll_Estatus_de_Pago_de_Facturas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Estatus_de_Pago_de_FacturasPagingModel result = null;

            if (data != null)
            {
                result = new Estatus_de_Pago_de_FacturasPagingModel
                {
                    Estatus_de_Pago_de_Facturass =
                        data.Select(m => new Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas
                {
                    Folio = m.Estatus_de_Pago_de_Facturas_Folio
                    ,Nombre = m.Estatus_de_Pago_de_Facturas_Nombre

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_de_Pago_de_FacturasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas>("sp_GetEstatus_de_Pago_de_Facturas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEstatus_de_Pago_de_Facturas>("sp_DelEstatus_de_Pago_de_Facturas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEstatus_de_Pago_de_Facturas>("sp_InsEstatus_de_Pago_de_Facturas" , padreNombre
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

        public int Update(Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_de_Pago_de_Facturas>("sp_UpdEstatus_de_Pago_de_Facturas" , paramUpdFolio , paramUpdNombre ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Estatus_de_Pago_de_Facturas.Estatus_de_Pago_de_Facturas Estatus_de_Pago_de_FacturasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_de_Pago_de_Facturas>("sp_UpdEstatus_de_Pago_de_Facturas" , paramUpdFolio , paramUpdNombre ).FirstOrDefault();

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

