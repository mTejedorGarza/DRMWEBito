using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Planes_por_Codigo_de_Descuento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Planes_por_Codigo_de_DescuentoService : IMS_Planes_por_Codigo_de_DescuentoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento> _MS_Planes_por_Codigo_de_DescuentoRepository;
        #endregion

        #region Ctor
        public MS_Planes_por_Codigo_de_DescuentoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento> MS_Planes_por_Codigo_de_DescuentoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Planes_por_Codigo_de_DescuentoRepository = MS_Planes_por_Codigo_de_DescuentoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_Planes_por_Codigo_de_DescuentoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento>("sp_SelAllMS_Planes_por_Codigo_de_Descuento");
        }

        public IList<Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_Planes_por_Codigo_de_Descuento_Complete>("sp_SelAllComplete_MS_Planes_por_Codigo_de_Descuento");
            return data.Select(m => new Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento
            {
                Folio = m.Folio
                ,Folio_Codigos_de_Descuento = m.Folio_Codigos_de_Descuento
                ,Planes_de_Suscripcion_Planes_de_Suscripcion = new Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion() { Folio = m.Planes_de_Suscripcion.GetValueOrDefault(), Nombre_del_Plan = m.Planes_de_Suscripcion_Nombre_del_Plan }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_Planes_por_Codigo_de_Descuento>("sp_ListSelCount_MS_Planes_por_Codigo_de_Descuento", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Planes_por_Codigo_de_Descuento>("sp_ListSelAll_MS_Planes_por_Codigo_de_Descuento", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento
                {
                    Folio = m.MS_Planes_por_Codigo_de_Descuento_Folio,
                    Folio_Codigos_de_Descuento = m.MS_Planes_por_Codigo_de_Descuento_Folio_Codigos_de_Descuento,
                    Planes_de_Suscripcion = m.MS_Planes_por_Codigo_de_Descuento_Planes_de_Suscripcion,

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

        public IList<Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Planes_por_Codigo_de_DescuentoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Planes_por_Codigo_de_DescuentoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_DescuentoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Planes_por_Codigo_de_Descuento>("sp_ListSelAll_MS_Planes_por_Codigo_de_Descuento", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_Planes_por_Codigo_de_DescuentoPagingModel result = null;

            if (data != null)
            {
                result = new MS_Planes_por_Codigo_de_DescuentoPagingModel
                {
                    MS_Planes_por_Codigo_de_Descuentos =
                        data.Select(m => new Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento
                {
                    Folio = m.MS_Planes_por_Codigo_de_Descuento_Folio
                    ,Folio_Codigos_de_Descuento = m.MS_Planes_por_Codigo_de_Descuento_Folio_Codigos_de_Descuento
                    ,Planes_de_Suscripcion = m.MS_Planes_por_Codigo_de_Descuento_Planes_de_Suscripcion
                    ,Planes_de_Suscripcion_Planes_de_Suscripcion = new Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion() { Folio = m.MS_Planes_por_Codigo_de_Descuento_Planes_de_Suscripcion.GetValueOrDefault(), Nombre_del_Plan = m.MS_Planes_por_Codigo_de_Descuento_Planes_de_Suscripcion_Nombre_del_Plan }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Planes_por_Codigo_de_DescuentoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento>("sp_GetMS_Planes_por_Codigo_de_Descuento", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_Planes_por_Codigo_de_Descuento>("sp_DelMS_Planes_por_Codigo_de_Descuento", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Codigos_de_Descuento = _dataProvider.GetParameter();
                padreFolio_Codigos_de_Descuento.ParameterName = "Folio_Codigos_de_Descuento";
                padreFolio_Codigos_de_Descuento.DbType = DbType.Int32;
                padreFolio_Codigos_de_Descuento.Value = (object)entity.Folio_Codigos_de_Descuento ?? DBNull.Value;
                var padrePlanes_de_Suscripcion = _dataProvider.GetParameter();
                padrePlanes_de_Suscripcion.ParameterName = "Planes_de_Suscripcion";
                padrePlanes_de_Suscripcion.DbType = DbType.Int32;
                padrePlanes_de_Suscripcion.Value = (object)entity.Planes_de_Suscripcion ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_Planes_por_Codigo_de_Descuento>("sp_InsMS_Planes_por_Codigo_de_Descuento" , padreFolio_Codigos_de_Descuento
, padrePlanes_de_Suscripcion
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

        public int Update(Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Codigos_de_Descuento = _dataProvider.GetParameter();
                paramUpdFolio_Codigos_de_Descuento.ParameterName = "Folio_Codigos_de_Descuento";
                paramUpdFolio_Codigos_de_Descuento.DbType = DbType.Int32;
                paramUpdFolio_Codigos_de_Descuento.Value = (object)entity.Folio_Codigos_de_Descuento ?? DBNull.Value;
                var paramUpdPlanes_de_Suscripcion = _dataProvider.GetParameter();
                paramUpdPlanes_de_Suscripcion.ParameterName = "Planes_de_Suscripcion";
                paramUpdPlanes_de_Suscripcion.DbType = DbType.Int32;
                paramUpdPlanes_de_Suscripcion.Value = (object)entity.Planes_de_Suscripcion ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Planes_por_Codigo_de_Descuento>("sp_UpdMS_Planes_por_Codigo_de_Descuento" , paramUpdFolio , paramUpdFolio_Codigos_de_Descuento , paramUpdPlanes_de_Suscripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_Planes_por_Codigo_de_Descuento.MS_Planes_por_Codigo_de_Descuento MS_Planes_por_Codigo_de_DescuentoDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Codigos_de_Descuento = _dataProvider.GetParameter();
                paramUpdFolio_Codigos_de_Descuento.ParameterName = "Folio_Codigos_de_Descuento";
                paramUpdFolio_Codigos_de_Descuento.DbType = DbType.Int32;
                paramUpdFolio_Codigos_de_Descuento.Value = (object)entity.Folio_Codigos_de_Descuento ?? DBNull.Value;
		var paramUpdPlanes_de_Suscripcion = _dataProvider.GetParameter();
                paramUpdPlanes_de_Suscripcion.ParameterName = "Planes_de_Suscripcion";
                paramUpdPlanes_de_Suscripcion.DbType = DbType.Int32;
                paramUpdPlanes_de_Suscripcion.Value = (object)entity.Planes_de_Suscripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Planes_por_Codigo_de_Descuento>("sp_UpdMS_Planes_por_Codigo_de_Descuento" , paramUpdFolio , paramUpdFolio_Codigos_de_Descuento , paramUpdPlanes_de_Suscripcion ).FirstOrDefault();

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

