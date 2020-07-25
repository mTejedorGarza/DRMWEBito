using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Meses;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Meses
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MesesService : IMesesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Meses.Meses> _MesesRepository;
        #endregion

        #region Ctor
        public MesesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Meses.Meses> MesesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MesesRepository = MesesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MesesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Meses.Meses> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Meses.Meses>("sp_SelAllMeses");
        }

        public IList<Core.Classes.Meses.Meses> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMeses_Complete>("sp_SelAllComplete_Meses");
            return data.Select(m => new Core.Classes.Meses.Meses
            {
                Clave = m.Clave
                ,Nombre = m.Nombre
                ,Cantidad_de_dias = m.Cantidad_de_dias


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Meses>("sp_ListSelCount_Meses", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Meses.Meses> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMeses>("sp_ListSelAll_Meses", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Meses.Meses
                {
                    Clave = m.Meses_Clave,
                    Nombre = m.Meses_Nombre,
                    Cantidad_de_dias = m.Meses_Cantidad_de_dias,

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

        public IList<Spartane.Core.Classes.Meses.Meses> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MesesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Meses.Meses> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MesesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Meses.MesesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMeses>("sp_ListSelAll_Meses", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MesesPagingModel result = null;

            if (data != null)
            {
                result = new MesesPagingModel
                {
                    Mesess =
                        data.Select(m => new Spartane.Core.Classes.Meses.Meses
                {
                    Clave = m.Meses_Clave
                    ,Nombre = m.Meses_Nombre
                    ,Cantidad_de_dias = m.Meses_Cantidad_de_dias

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Meses.Meses> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MesesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Meses.Meses GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Meses.Meses>("sp_GetMeses", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMeses>("sp_DelMeses", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Meses.Meses entity)
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
                var padreCantidad_de_dias = _dataProvider.GetParameter();
                padreCantidad_de_dias.ParameterName = "Cantidad_de_dias";
                padreCantidad_de_dias.DbType = DbType.Int16;
                padreCantidad_de_dias.Value = (object)entity.Cantidad_de_dias ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMeses>("sp_InsMeses" , padreNombre
, padreCantidad_de_dias
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

        public int Update(Spartane.Core.Classes.Meses.Meses entity)
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
                var paramUpdCantidad_de_dias = _dataProvider.GetParameter();
                paramUpdCantidad_de_dias.ParameterName = "Cantidad_de_dias";
                paramUpdCantidad_de_dias.DbType = DbType.Int16;
                paramUpdCantidad_de_dias.Value = (object)entity.Cantidad_de_dias ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMeses>("sp_UpdMeses" , paramUpdClave , paramUpdNombre , paramUpdCantidad_de_dias ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Meses.Meses entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Meses.Meses MesesDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdCantidad_de_dias = _dataProvider.GetParameter();
                paramUpdCantidad_de_dias.ParameterName = "Cantidad_de_dias";
                paramUpdCantidad_de_dias.DbType = DbType.Int16;
                paramUpdCantidad_de_dias.Value = (object)entity.Cantidad_de_dias ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMeses>("sp_UpdMeses" , paramUpdClave , paramUpdNombre , paramUpdCantidad_de_dias ).FirstOrDefault();

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

