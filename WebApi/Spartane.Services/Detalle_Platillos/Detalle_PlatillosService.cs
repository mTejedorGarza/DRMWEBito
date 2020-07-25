using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Platillos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Platillos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_PlatillosService : IDetalle_PlatillosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> _Detalle_PlatillosRepository;
        #endregion

        #region Ctor
        public Detalle_PlatillosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> Detalle_PlatillosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_PlatillosRepository = Detalle_PlatillosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_PlatillosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos>("sp_SelAllDetalle_Platillos");
        }

        public IList<Core.Classes.Detalle_Platillos.Detalle_Platillos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Platillos_Complete>("sp_SelAllComplete_Detalle_Platillos");
            return data.Select(m => new Core.Classes.Detalle_Platillos.Detalle_Platillos
            {
                Folio = m.Folio
                ,Folio_Platillos = m.Folio_Platillos
                ,Cantidad = m.Cantidad
                ,Unidad = m.Unidad
                ,Ingrediente_Ingredientes = new Core.Classes.Ingredientes.Ingredientes() { Clave = m.Ingrediente.GetValueOrDefault(), Nombre_Ingrediente = m.Ingrediente_Nombre_Ingrediente }
                ,Unidad_SMAE = m.Unidad_SMAE
                ,Porciones = m.Porciones
                ,Texto_para_mostrar = m.Texto_para_mostrar


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Platillos>("sp_ListSelCount_Detalle_Platillos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Platillos>("sp_ListSelAll_Detalle_Platillos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos
                {
                    Folio = m.Detalle_Platillos_Folio,
                    Folio_Platillos = m.Detalle_Platillos_Folio_Platillos,
                    Cantidad = m.Detalle_Platillos_Cantidad,
                    Unidad = m.Detalle_Platillos_Unidad,
                    Ingrediente = m.Detalle_Platillos_Ingrediente,
                    Unidad_SMAE = m.Detalle_Platillos_Unidad_SMAE,
                    Porciones = m.Detalle_Platillos_Porciones,
                    Texto_para_mostrar = m.Detalle_Platillos_Texto_para_mostrar,

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

        public IList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_PlatillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_PlatillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Platillos.Detalle_PlatillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Platillos>("sp_ListSelAll_Detalle_Platillos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_PlatillosPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_PlatillosPagingModel
                {
                    Detalle_Platilloss =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos
                {
                    Folio = m.Detalle_Platillos_Folio
                    ,Folio_Platillos = m.Detalle_Platillos_Folio_Platillos
                    ,Cantidad = m.Detalle_Platillos_Cantidad
                    ,Unidad = m.Detalle_Platillos_Unidad
                    ,Ingrediente = m.Detalle_Platillos_Ingrediente
                    ,Ingrediente_Ingredientes = new Core.Classes.Ingredientes.Ingredientes() { Clave = m.Detalle_Platillos_Ingrediente.GetValueOrDefault(), Nombre_Ingrediente = m.Detalle_Platillos_Ingrediente_Nombre_Ingrediente }
                    ,Unidad_SMAE = m.Detalle_Platillos_Unidad_SMAE
                    ,Porciones = m.Detalle_Platillos_Porciones
                    ,Texto_para_mostrar = m.Detalle_Platillos_Texto_para_mostrar

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_PlatillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos>("sp_GetDetalle_Platillos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Platillos>("sp_DelDetalle_Platillos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos entity)
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
                var padreCantidad = _dataProvider.GetParameter();
                padreCantidad.ParameterName = "Cantidad";
                padreCantidad.DbType = DbType.String;
                padreCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;
                var padreUnidad = _dataProvider.GetParameter();
                padreUnidad.ParameterName = "Unidad";
                padreUnidad.DbType = DbType.Int32;
                padreUnidad.Value = (object)entity.Unidad ?? DBNull.Value;

                var padreIngrediente = _dataProvider.GetParameter();
                padreIngrediente.ParameterName = "Ingrediente";
                padreIngrediente.DbType = DbType.Int32;
                padreIngrediente.Value = (object)entity.Ingrediente ?? DBNull.Value;

                var padreUnidad_SMAE = _dataProvider.GetParameter();
                padreUnidad_SMAE.ParameterName = "Unidad_SMAE";
                padreUnidad_SMAE.DbType = DbType.Int32;
                padreUnidad_SMAE.Value = (object)entity.Unidad_SMAE ?? DBNull.Value;

                var padrePorciones = _dataProvider.GetParameter();
                padrePorciones.ParameterName = "Porciones";
                padrePorciones.DbType = DbType.Int32;
                padrePorciones.Value = (object)entity.Porciones ?? DBNull.Value;

                var padreTexto_para_mostrar = _dataProvider.GetParameter();
                padreTexto_para_mostrar.ParameterName = "Texto_para_mostrar";
                padreTexto_para_mostrar.DbType = DbType.String;
                padreTexto_para_mostrar.Value = (object)entity.Texto_para_mostrar ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Platillos>("sp_InsDetalle_Platillos" , padreFolio_Platillos
, padreCantidad
, padreUnidad
, padreIngrediente
, padreUnidad_SMAE
, padrePorciones
, padreTexto_para_mostrar
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

        public int Update(Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos entity)
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
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.String;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;
                var paramUpdUnidad = _dataProvider.GetParameter();
                paramUpdUnidad.ParameterName = "Unidad";
                paramUpdUnidad.DbType = DbType.Int32;
                paramUpdUnidad.Value = (object)entity.Unidad ?? DBNull.Value;

                var paramUpdIngrediente = _dataProvider.GetParameter();
                paramUpdIngrediente.ParameterName = "Ingrediente";
                paramUpdIngrediente.DbType = DbType.Int32;
                paramUpdIngrediente.Value = (object)entity.Ingrediente ?? DBNull.Value;

                var paramUpdUnidad_SMAE = _dataProvider.GetParameter();
                paramUpdUnidad_SMAE.ParameterName = "Unidad_SMAE";
                paramUpdUnidad_SMAE.DbType = DbType.Int32;
                paramUpdUnidad_SMAE.Value = (object)entity.Unidad_SMAE ?? DBNull.Value;

                var paramUpdPorciones = _dataProvider.GetParameter();
                paramUpdPorciones.ParameterName = "Porciones";
                paramUpdPorciones.DbType = DbType.Int32;
                paramUpdPorciones.Value = (object)entity.Porciones ?? DBNull.Value;

                var paramUpdTexto_para_mostrar = _dataProvider.GetParameter();
                paramUpdTexto_para_mostrar.ParameterName = "Texto_para_mostrar";
                paramUpdTexto_para_mostrar.DbType = DbType.String;
                paramUpdTexto_para_mostrar.Value = (object)entity.Texto_para_mostrar ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Platillos>("sp_UpdDetalle_Platillos" , paramUpdFolio , paramUpdFolio_Platillos , paramUpdCantidad , paramUpdUnidad , paramUpdIngrediente , paramUpdUnidad_SMAE , paramUpdPorciones , paramUpdTexto_para_mostrar ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Platillos.Detalle_Platillos Detalle_PlatillosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Platillos = _dataProvider.GetParameter();
                paramUpdFolio_Platillos.ParameterName = "Folio_Platillos";
                paramUpdFolio_Platillos.DbType = DbType.Int32;
                paramUpdFolio_Platillos.Value = (object)entity.Folio_Platillos ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.String;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;
                var paramUpdUnidad = _dataProvider.GetParameter();
                paramUpdUnidad.ParameterName = "Unidad";
                paramUpdUnidad.DbType = DbType.Int32;
                paramUpdUnidad.Value = (object)entity.Unidad ?? DBNull.Value;
		var paramUpdIngrediente = _dataProvider.GetParameter();
                paramUpdIngrediente.ParameterName = "Ingrediente";
                paramUpdIngrediente.DbType = DbType.Int32;
                paramUpdIngrediente.Value = (object)entity.Ingrediente ?? DBNull.Value;
                var paramUpdUnidad_SMAE = _dataProvider.GetParameter();
                paramUpdUnidad_SMAE.ParameterName = "Unidad_SMAE";
                paramUpdUnidad_SMAE.DbType = DbType.Int32;
                paramUpdUnidad_SMAE.Value = (object)entity.Unidad_SMAE ?? DBNull.Value;
                var paramUpdPorciones = _dataProvider.GetParameter();
                paramUpdPorciones.ParameterName = "Porciones";
                paramUpdPorciones.DbType = DbType.Int32;
                paramUpdPorciones.Value = (object)entity.Porciones ?? DBNull.Value;
                var paramUpdTexto_para_mostrar = _dataProvider.GetParameter();
                paramUpdTexto_para_mostrar.ParameterName = "Texto_para_mostrar";
                paramUpdTexto_para_mostrar.DbType = DbType.String;
                paramUpdTexto_para_mostrar.Value = (object)entity.Texto_para_mostrar ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Platillos>("sp_UpdDetalle_Platillos" , paramUpdFolio , paramUpdFolio_Platillos , paramUpdCantidad , paramUpdUnidad , paramUpdIngrediente , paramUpdUnidad_SMAE , paramUpdPorciones , paramUpdTexto_para_mostrar ).FirstOrDefault();

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

