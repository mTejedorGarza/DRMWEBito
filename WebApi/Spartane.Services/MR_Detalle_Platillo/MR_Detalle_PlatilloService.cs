using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MR_Detalle_Platillo;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MR_Detalle_Platillo
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MR_Detalle_PlatilloService : IMR_Detalle_PlatilloService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo> _MR_Detalle_PlatilloRepository;
        #endregion

        #region Ctor
        public MR_Detalle_PlatilloService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo> MR_Detalle_PlatilloRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MR_Detalle_PlatilloRepository = MR_Detalle_PlatilloRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MR_Detalle_PlatilloRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo>("sp_SelAllMR_Detalle_Platillo");
        }

        public IList<Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMR_Detalle_Platillo_Complete>("sp_SelAllComplete_MR_Detalle_Platillo");
            return data.Select(m => new Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo
            {
                Folio = m.Folio
                ,Folio_Platillos = m.Folio_Platillos
                ,Ingrediente_Ingredientes = new Core.Classes.Ingredientes.Ingredientes() { Clave = m.Ingrediente.GetValueOrDefault(), Nombre_Ingrediente = m.Ingrediente_Nombre_Ingrediente }
                ,Cantidad = m.Cantidad
                ,Cantidad_en_Fraccion = m.Cantidad_en_Fraccion
                ,Unidad_Unidades_de_Medida = new Core.Classes.Unidades_de_Medida.Unidades_de_Medida() { Clave = m.Unidad.GetValueOrDefault(), Unidad = m.Unidad_Unidad }
                ,Cantidad_a_mostrar = m.Cantidad_a_mostrar
                ,Ingrediente_a_mostrar = m.Ingrediente_a_mostrar


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MR_Detalle_Platillo>("sp_ListSelCount_MR_Detalle_Platillo", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMR_Detalle_Platillo>("sp_ListSelAll_MR_Detalle_Platillo", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo
                {
                    Folio = m.MR_Detalle_Platillo_Folio,
                    Folio_Platillos = m.MR_Detalle_Platillo_Folio_Platillos,
                    Ingrediente = m.MR_Detalle_Platillo_Ingrediente,
                    Cantidad = m.MR_Detalle_Platillo_Cantidad,
                    Cantidad_en_Fraccion = m.MR_Detalle_Platillo_Cantidad_en_Fraccion,
                    Unidad = m.MR_Detalle_Platillo_Unidad,
                    Cantidad_a_mostrar = m.MR_Detalle_Platillo_Cantidad_a_mostrar,
                    Ingrediente_a_mostrar = m.MR_Detalle_Platillo_Ingrediente_a_mostrar,

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

        public IList<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MR_Detalle_PlatilloRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MR_Detalle_PlatilloRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_PlatilloPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMR_Detalle_Platillo>("sp_ListSelAll_MR_Detalle_Platillo", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MR_Detalle_PlatilloPagingModel result = null;

            if (data != null)
            {
                result = new MR_Detalle_PlatilloPagingModel
                {
                    MR_Detalle_Platillos =
                        data.Select(m => new Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo
                {
                    Folio = m.MR_Detalle_Platillo_Folio
                    ,Folio_Platillos = m.MR_Detalle_Platillo_Folio_Platillos
                    ,Ingrediente = m.MR_Detalle_Platillo_Ingrediente
                    ,Ingrediente_Ingredientes = new Core.Classes.Ingredientes.Ingredientes() { Clave = m.MR_Detalle_Platillo_Ingrediente.GetValueOrDefault(), Nombre_Ingrediente = m.MR_Detalle_Platillo_Ingrediente_Nombre_Ingrediente }
                    ,Cantidad = m.MR_Detalle_Platillo_Cantidad
                    ,Cantidad_en_Fraccion = m.MR_Detalle_Platillo_Cantidad_en_Fraccion
                    ,Unidad = m.MR_Detalle_Platillo_Unidad
                    ,Unidad_Unidades_de_Medida = new Core.Classes.Unidades_de_Medida.Unidades_de_Medida() { Clave = m.MR_Detalle_Platillo_Unidad.GetValueOrDefault(), Unidad = m.MR_Detalle_Platillo_Unidad_Unidad }
                    ,Cantidad_a_mostrar = m.MR_Detalle_Platillo_Cantidad_a_mostrar
                    ,Ingrediente_a_mostrar = m.MR_Detalle_Platillo_Ingrediente_a_mostrar

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MR_Detalle_PlatilloRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo>("sp_GetMR_Detalle_Platillo", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMR_Detalle_Platillo>("sp_DelMR_Detalle_Platillo", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo entity)
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
                var padreIngrediente = _dataProvider.GetParameter();
                padreIngrediente.ParameterName = "Ingrediente";
                padreIngrediente.DbType = DbType.Int32;
                padreIngrediente.Value = (object)entity.Ingrediente ?? DBNull.Value;

                var padreCantidad = _dataProvider.GetParameter();
                padreCantidad.ParameterName = "Cantidad";
                padreCantidad.DbType = DbType.String;
                padreCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;
                var padreCantidad_en_Fraccion = _dataProvider.GetParameter();
                padreCantidad_en_Fraccion.ParameterName = "Cantidad_en_Fraccion";
                padreCantidad_en_Fraccion.DbType = DbType.Decimal;
                padreCantidad_en_Fraccion.Value = (object)entity.Cantidad_en_Fraccion ?? DBNull.Value;

                var padreUnidad = _dataProvider.GetParameter();
                padreUnidad.ParameterName = "Unidad";
                padreUnidad.DbType = DbType.Int32;
                padreUnidad.Value = (object)entity.Unidad ?? DBNull.Value;

                var padreCantidad_a_mostrar = _dataProvider.GetParameter();
                padreCantidad_a_mostrar.ParameterName = "Cantidad_a_mostrar";
                padreCantidad_a_mostrar.DbType = DbType.String;
                padreCantidad_a_mostrar.Value = (object)entity.Cantidad_a_mostrar ?? DBNull.Value;
                var padreIngrediente_a_mostrar = _dataProvider.GetParameter();
                padreIngrediente_a_mostrar.ParameterName = "Ingrediente_a_mostrar";
                padreIngrediente_a_mostrar.DbType = DbType.String;
                padreIngrediente_a_mostrar.Value = (object)entity.Ingrediente_a_mostrar ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMR_Detalle_Platillo>("sp_InsMR_Detalle_Platillo" , padreFolio_Platillos
, padreIngrediente
, padreCantidad
, padreCantidad_en_Fraccion
, padreUnidad
, padreCantidad_a_mostrar
, padreIngrediente_a_mostrar
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

        public int Update(Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo entity)
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
                var paramUpdIngrediente = _dataProvider.GetParameter();
                paramUpdIngrediente.ParameterName = "Ingrediente";
                paramUpdIngrediente.DbType = DbType.Int32;
                paramUpdIngrediente.Value = (object)entity.Ingrediente ?? DBNull.Value;

                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.String;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;
                var paramUpdCantidad_en_Fraccion = _dataProvider.GetParameter();
                paramUpdCantidad_en_Fraccion.ParameterName = "Cantidad_en_Fraccion";
                paramUpdCantidad_en_Fraccion.DbType = DbType.Decimal;
                paramUpdCantidad_en_Fraccion.Value = (object)entity.Cantidad_en_Fraccion ?? DBNull.Value;

                var paramUpdUnidad = _dataProvider.GetParameter();
                paramUpdUnidad.ParameterName = "Unidad";
                paramUpdUnidad.DbType = DbType.Int32;
                paramUpdUnidad.Value = (object)entity.Unidad ?? DBNull.Value;

                var paramUpdCantidad_a_mostrar = _dataProvider.GetParameter();
                paramUpdCantidad_a_mostrar.ParameterName = "Cantidad_a_mostrar";
                paramUpdCantidad_a_mostrar.DbType = DbType.String;
                paramUpdCantidad_a_mostrar.Value = (object)entity.Cantidad_a_mostrar ?? DBNull.Value;
                var paramUpdIngrediente_a_mostrar = _dataProvider.GetParameter();
                paramUpdIngrediente_a_mostrar.ParameterName = "Ingrediente_a_mostrar";
                paramUpdIngrediente_a_mostrar.DbType = DbType.String;
                paramUpdIngrediente_a_mostrar.Value = (object)entity.Ingrediente_a_mostrar ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMR_Detalle_Platillo>("sp_UpdMR_Detalle_Platillo" , paramUpdFolio , paramUpdFolio_Platillos , paramUpdIngrediente , paramUpdCantidad , paramUpdCantidad_en_Fraccion , paramUpdUnidad , paramUpdCantidad_a_mostrar , paramUpdIngrediente_a_mostrar ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MR_Detalle_Platillo.MR_Detalle_Platillo MR_Detalle_PlatilloDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Platillos = _dataProvider.GetParameter();
                paramUpdFolio_Platillos.ParameterName = "Folio_Platillos";
                paramUpdFolio_Platillos.DbType = DbType.Int32;
                paramUpdFolio_Platillos.Value = (object)entity.Folio_Platillos ?? DBNull.Value;
		var paramUpdIngrediente = _dataProvider.GetParameter();
                paramUpdIngrediente.ParameterName = "Ingrediente";
                paramUpdIngrediente.DbType = DbType.Int32;
                paramUpdIngrediente.Value = (object)entity.Ingrediente ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.String;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;
                var paramUpdCantidad_en_Fraccion = _dataProvider.GetParameter();
                paramUpdCantidad_en_Fraccion.ParameterName = "Cantidad_en_Fraccion";
                paramUpdCantidad_en_Fraccion.DbType = DbType.Decimal;
                paramUpdCantidad_en_Fraccion.Value = (object)entity.Cantidad_en_Fraccion ?? DBNull.Value;
		var paramUpdUnidad = _dataProvider.GetParameter();
                paramUpdUnidad.ParameterName = "Unidad";
                paramUpdUnidad.DbType = DbType.Int32;
                paramUpdUnidad.Value = (object)entity.Unidad ?? DBNull.Value;
                var paramUpdCantidad_a_mostrar = _dataProvider.GetParameter();
                paramUpdCantidad_a_mostrar.ParameterName = "Cantidad_a_mostrar";
                paramUpdCantidad_a_mostrar.DbType = DbType.String;
                paramUpdCantidad_a_mostrar.Value = (object)entity.Cantidad_a_mostrar ?? DBNull.Value;
                var paramUpdIngrediente_a_mostrar = _dataProvider.GetParameter();
                paramUpdIngrediente_a_mostrar.ParameterName = "Ingrediente_a_mostrar";
                paramUpdIngrediente_a_mostrar.DbType = DbType.String;
                paramUpdIngrediente_a_mostrar.Value = (object)entity.Ingrediente_a_mostrar ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMR_Detalle_Platillo>("sp_UpdMR_Detalle_Platillo" , paramUpdFolio , paramUpdFolio_Platillos , paramUpdIngrediente , paramUpdCantidad , paramUpdCantidad_en_Fraccion , paramUpdUnidad , paramUpdCantidad_a_mostrar , paramUpdIngrediente_a_mostrar ).FirstOrDefault();

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

