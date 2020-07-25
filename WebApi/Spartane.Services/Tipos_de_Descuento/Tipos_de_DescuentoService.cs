using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Tipos_de_Descuento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tipos_de_Descuento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tipos_de_DescuentoService : ITipos_de_DescuentoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento> _Tipos_de_DescuentoRepository;
        #endregion

        #region Ctor
        public Tipos_de_DescuentoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento> Tipos_de_DescuentoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tipos_de_DescuentoRepository = Tipos_de_DescuentoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Tipos_de_DescuentoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento>("sp_SelAllTipos_de_Descuento");
        }

        public IList<Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTipos_de_Descuento_Complete>("sp_SelAllComplete_Tipos_de_Descuento");
            return data.Select(m => new Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento
            {
                Clave = m.Clave
                ,Nombre = m.Nombre


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Tipos_de_Descuento>("sp_ListSelCount_Tipos_de_Descuento", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipos_de_Descuento>("sp_ListSelAll_Tipos_de_Descuento", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento
                {
                    Clave = m.Tipos_de_Descuento_Clave,
                    Nombre = m.Tipos_de_Descuento_Nombre,

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

        public IList<Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tipos_de_DescuentoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipos_de_DescuentoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_DescuentoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipos_de_Descuento>("sp_ListSelAll_Tipos_de_Descuento", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Tipos_de_DescuentoPagingModel result = null;

            if (data != null)
            {
                result = new Tipos_de_DescuentoPagingModel
                {
                    Tipos_de_Descuentos =
                        data.Select(m => new Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento
                {
                    Clave = m.Tipos_de_Descuento_Clave
                    ,Nombre = m.Tipos_de_Descuento_Nombre

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tipos_de_DescuentoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento>("sp_GetTipos_de_Descuento", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTipos_de_Descuento>("sp_DelTipos_de_Descuento", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.String;
                padreNombre.Value = (object)entity.Nombre ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTipos_de_Descuento>("sp_InsTipos_de_Descuento" , padreNombre
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

        public int Update(Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipos_de_Descuento>("sp_UpdTipos_de_Descuento" , paramUpdClave , paramUpdNombre ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Tipos_de_Descuento.Tipos_de_Descuento Tipos_de_DescuentoDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipos_de_Descuento>("sp_UpdTipos_de_Descuento" , paramUpdClave , paramUpdNombre ).FirstOrDefault();

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

