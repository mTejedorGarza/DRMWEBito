using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_de_Codigos_de_Descuento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_de_Codigos_de_DescuentoService : IEstatus_de_Codigos_de_DescuentoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento> _Estatus_de_Codigos_de_DescuentoRepository;
        #endregion

        #region Ctor
        public Estatus_de_Codigos_de_DescuentoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento> Estatus_de_Codigos_de_DescuentoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_de_Codigos_de_DescuentoRepository = Estatus_de_Codigos_de_DescuentoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Estatus_de_Codigos_de_DescuentoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento>("sp_SelAllEstatus_de_Codigos_de_Descuento");
        }

        public IList<Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallEstatus_de_Codigos_de_Descuento_Complete>("sp_SelAllComplete_Estatus_de_Codigos_de_Descuento");
            return data.Select(m => new Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Estatus_de_Codigos_de_Descuento>("sp_ListSelCount_Estatus_de_Codigos_de_Descuento", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_de_Codigos_de_Descuento>("sp_ListSelAll_Estatus_de_Codigos_de_Descuento", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento
                {
                    Folio = m.Estatus_de_Codigos_de_Descuento_Folio,
                    Nombre = m.Estatus_de_Codigos_de_Descuento_Nombre,

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

        public IList<Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_de_Codigos_de_DescuentoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_de_Codigos_de_DescuentoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_DescuentoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllEstatus_de_Codigos_de_Descuento>("sp_ListSelAll_Estatus_de_Codigos_de_Descuento", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Estatus_de_Codigos_de_DescuentoPagingModel result = null;

            if (data != null)
            {
                result = new Estatus_de_Codigos_de_DescuentoPagingModel
                {
                    Estatus_de_Codigos_de_Descuentos =
                        data.Select(m => new Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento
                {
                    Folio = m.Estatus_de_Codigos_de_Descuento_Folio
                    ,Nombre = m.Estatus_de_Codigos_de_Descuento_Nombre

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_de_Codigos_de_DescuentoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento>("sp_GetEstatus_de_Codigos_de_Descuento", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelEstatus_de_Codigos_de_Descuento>("sp_DelEstatus_de_Codigos_de_Descuento", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsEstatus_de_Codigos_de_Descuento>("sp_InsEstatus_de_Codigos_de_Descuento" , padreNombre
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

        public int Update(Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_de_Codigos_de_Descuento>("sp_UpdEstatus_de_Codigos_de_Descuento" , paramUpdFolio , paramUpdNombre ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Estatus_de_Codigos_de_Descuento.Estatus_de_Codigos_de_Descuento Estatus_de_Codigos_de_DescuentoDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdEstatus_de_Codigos_de_Descuento>("sp_UpdEstatus_de_Codigos_de_Descuento" , paramUpdFolio , paramUpdNombre ).FirstOrDefault();

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

