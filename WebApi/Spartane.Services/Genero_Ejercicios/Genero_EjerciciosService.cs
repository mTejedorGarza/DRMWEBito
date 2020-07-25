﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Genero_Ejercicios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Genero_Ejercicios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Genero_EjerciciosService : IGenero_EjerciciosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios> _Genero_EjerciciosRepository;
        #endregion

        #region Ctor
        public Genero_EjerciciosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios> Genero_EjerciciosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Genero_EjerciciosRepository = Genero_EjerciciosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Genero_EjerciciosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios>("sp_SelAllGenero_Ejercicios");
        }

        public IList<Core.Classes.Genero_Ejercicios.Genero_Ejercicios> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallGenero_Ejercicios_Complete>("sp_SelAllComplete_Genero_Ejercicios");
            return data.Select(m => new Core.Classes.Genero_Ejercicios.Genero_Ejercicios
            {
                Folio = m.Folio
                ,Descripcion = m.Descripcion


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Genero_Ejercicios>("sp_ListSelCount_Genero_Ejercicios", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllGenero_Ejercicios>("sp_ListSelAll_Genero_Ejercicios", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios
                {
                    Folio = m.Genero_Ejercicios_Folio,
                    Descripcion = m.Genero_Ejercicios_Descripcion,

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

        public IList<Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Genero_EjerciciosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Genero_EjerciciosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Genero_Ejercicios.Genero_EjerciciosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllGenero_Ejercicios>("sp_ListSelAll_Genero_Ejercicios", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Genero_EjerciciosPagingModel result = null;

            if (data != null)
            {
                result = new Genero_EjerciciosPagingModel
                {
                    Genero_Ejercicioss =
                        data.Select(m => new Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios
                {
                    Folio = m.Genero_Ejercicios_Folio
                    ,Descripcion = m.Genero_Ejercicios_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Genero_EjerciciosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios>("sp_GetGenero_Ejercicios", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelGenero_Ejercicios>("sp_DelGenero_Ejercicios", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsGenero_Ejercicios>("sp_InsGenero_Ejercicios" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdGenero_Ejercicios>("sp_UpdGenero_Ejercicios" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Genero_Ejercicios.Genero_Ejercicios Genero_EjerciciosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdGenero_Ejercicios>("sp_UpdGenero_Ejercicios" , paramUpdFolio , paramUpdDescripcion ).FirstOrDefault();

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

