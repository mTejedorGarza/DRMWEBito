﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Formas_de_Pago;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Formas_de_Pago
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Formas_de_PagoService : IFormas_de_PagoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago> _Formas_de_PagoRepository;
        #endregion

        #region Ctor
        public Formas_de_PagoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago> Formas_de_PagoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Formas_de_PagoRepository = Formas_de_PagoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Formas_de_PagoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago>("sp_SelAllFormas_de_Pago");
        }

        public IList<Core.Classes.Formas_de_Pago.Formas_de_Pago> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallFormas_de_Pago_Complete>("sp_SelAllComplete_Formas_de_Pago");
            return data.Select(m => new Core.Classes.Formas_de_Pago.Formas_de_Pago
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Formas_de_Pago>("sp_ListSelCount_Formas_de_Pago", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllFormas_de_Pago>("sp_ListSelAll_Formas_de_Pago", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago
                {
                    Clave = m.Formas_de_Pago_Clave,
                    Nombre = m.Formas_de_Pago_Nombre,

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

        public IList<Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Formas_de_PagoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Formas_de_PagoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Formas_de_Pago.Formas_de_PagoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllFormas_de_Pago>("sp_ListSelAll_Formas_de_Pago", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Formas_de_PagoPagingModel result = null;

            if (data != null)
            {
                result = new Formas_de_PagoPagingModel
                {
                    Formas_de_Pagos =
                        data.Select(m => new Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago
                {
                    Clave = m.Formas_de_Pago_Clave
                    ,Nombre = m.Formas_de_Pago_Nombre

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Formas_de_PagoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago>("sp_GetFormas_de_Pago", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelFormas_de_Pago>("sp_DelFormas_de_Pago", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsFormas_de_Pago>("sp_InsFormas_de_Pago" , padreNombre
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

        public int Update(Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdFormas_de_Pago>("sp_UpdFormas_de_Pago" , paramUpdClave , paramUpdNombre ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Formas_de_Pago.Formas_de_Pago Formas_de_PagoDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdFormas_de_Pago>("sp_UpdFormas_de_Pago" , paramUpdClave , paramUpdNombre ).FirstOrDefault();

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
