using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Nombre_del_campo_en_MS;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Nombre_del_campo_en_MS
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Nombre_del_campo_en_MSService : INombre_del_campo_en_MSService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> _Nombre_del_campo_en_MSRepository;
        #endregion

        #region Ctor
        public Nombre_del_campo_en_MSService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> Nombre_del_campo_en_MSRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Nombre_del_campo_en_MSRepository = Nombre_del_campo_en_MSRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Nombre_del_campo_en_MSRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS>("sp_SelAllNombre_del_campo_en_MS");
        }

        public IList<Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallNombre_del_campo_en_MS_Complete>("sp_SelAllComplete_Nombre_del_campo_en_MS");
            return data.Select(m => new Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS
            {
                Clave = m.Clave
                ,Descripcion = m.Descripcion
                ,Nombre_Fisico_del_Campo = m.Nombre_Fisico_del_Campo
                ,Nombre_Fisico_de_la_Tabla = m.Nombre_Fisico_de_la_Tabla


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Nombre_del_campo_en_MS>("sp_ListSelCount_Nombre_del_campo_en_MS", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllNombre_del_campo_en_MS>("sp_ListSelAll_Nombre_del_campo_en_MS", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS
                {
                    Clave = m.Nombre_del_campo_en_MS_Clave,
                    Descripcion = m.Nombre_del_campo_en_MS_Descripcion,
                    Nombre_Fisico_del_Campo = m.Nombre_del_campo_en_MS_Nombre_Fisico_del_Campo,
                    Nombre_Fisico_de_la_Tabla = m.Nombre_del_campo_en_MS_Nombre_Fisico_de_la_Tabla,

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

        public IList<Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Nombre_del_campo_en_MSRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Nombre_del_campo_en_MSRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MSPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllNombre_del_campo_en_MS>("sp_ListSelAll_Nombre_del_campo_en_MS", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Nombre_del_campo_en_MSPagingModel result = null;

            if (data != null)
            {
                result = new Nombre_del_campo_en_MSPagingModel
                {
                    Nombre_del_campo_en_MSs =
                        data.Select(m => new Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS
                {
                    Clave = m.Nombre_del_campo_en_MS_Clave
                    ,Descripcion = m.Nombre_del_campo_en_MS_Descripcion
                    ,Nombre_Fisico_del_Campo = m.Nombre_del_campo_en_MS_Nombre_Fisico_del_Campo
                    ,Nombre_Fisico_de_la_Tabla = m.Nombre_del_campo_en_MS_Nombre_Fisico_de_la_Tabla

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Nombre_del_campo_en_MSRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS>("sp_GetNombre_del_campo_en_MS", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelNombre_del_campo_en_MS>("sp_DelNombre_del_campo_en_MS", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var padreNombre_Fisico_del_Campo = _dataProvider.GetParameter();
                padreNombre_Fisico_del_Campo.ParameterName = "Nombre_Fisico_del_Campo";
                padreNombre_Fisico_del_Campo.DbType = DbType.String;
                padreNombre_Fisico_del_Campo.Value = (object)entity.Nombre_Fisico_del_Campo ?? DBNull.Value;
                var padreNombre_Fisico_de_la_Tabla = _dataProvider.GetParameter();
                padreNombre_Fisico_de_la_Tabla.ParameterName = "Nombre_Fisico_de_la_Tabla";
                padreNombre_Fisico_de_la_Tabla.DbType = DbType.String;
                padreNombre_Fisico_de_la_Tabla.Value = (object)entity.Nombre_Fisico_de_la_Tabla ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsNombre_del_campo_en_MS>("sp_InsNombre_del_campo_en_MS" , padreDescripcion
, padreNombre_Fisico_del_Campo
, padreNombre_Fisico_de_la_Tabla
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

        public int Update(Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdNombre_Fisico_del_Campo = _dataProvider.GetParameter();
                paramUpdNombre_Fisico_del_Campo.ParameterName = "Nombre_Fisico_del_Campo";
                paramUpdNombre_Fisico_del_Campo.DbType = DbType.String;
                paramUpdNombre_Fisico_del_Campo.Value = (object)entity.Nombre_Fisico_del_Campo ?? DBNull.Value;
                var paramUpdNombre_Fisico_de_la_Tabla = _dataProvider.GetParameter();
                paramUpdNombre_Fisico_de_la_Tabla.ParameterName = "Nombre_Fisico_de_la_Tabla";
                paramUpdNombre_Fisico_de_la_Tabla.DbType = DbType.String;
                paramUpdNombre_Fisico_de_la_Tabla.Value = (object)entity.Nombre_Fisico_de_la_Tabla ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdNombre_del_campo_en_MS>("sp_UpdNombre_del_campo_en_MS" , paramUpdClave , paramUpdDescripcion , paramUpdNombre_Fisico_del_Campo , paramUpdNombre_Fisico_de_la_Tabla ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Nombre_del_campo_en_MS.Nombre_del_campo_en_MS Nombre_del_campo_en_MSDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdNombre_Fisico_del_Campo = _dataProvider.GetParameter();
                paramUpdNombre_Fisico_del_Campo.ParameterName = "Nombre_Fisico_del_Campo";
                paramUpdNombre_Fisico_del_Campo.DbType = DbType.String;
                paramUpdNombre_Fisico_del_Campo.Value = (object)entity.Nombre_Fisico_del_Campo ?? DBNull.Value;
                var paramUpdNombre_Fisico_de_la_Tabla = _dataProvider.GetParameter();
                paramUpdNombre_Fisico_de_la_Tabla.ParameterName = "Nombre_Fisico_de_la_Tabla";
                paramUpdNombre_Fisico_de_la_Tabla.DbType = DbType.String;
                paramUpdNombre_Fisico_de_la_Tabla.Value = (object)entity.Nombre_Fisico_de_la_Tabla ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdNombre_del_campo_en_MS>("sp_UpdNombre_del_campo_en_MS" , paramUpdClave , paramUpdDescripcion , paramUpdNombre_Fisico_del_Campo , paramUpdNombre_Fisico_de_la_Tabla ).FirstOrDefault();

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

