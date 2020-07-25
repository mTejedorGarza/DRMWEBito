﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Tipo_de_Dieta;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tipo_de_Dieta
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tipo_de_DietaService : ITipo_de_DietaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta> _Tipo_de_DietaRepository;
        #endregion

        #region Ctor
        public Tipo_de_DietaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta> Tipo_de_DietaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tipo_de_DietaRepository = Tipo_de_DietaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Tipo_de_DietaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta>("sp_SelAllTipo_de_Dieta");
        }

        public IList<Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTipo_de_Dieta_Complete>("sp_SelAllComplete_Tipo_de_Dieta");
            return data.Select(m => new Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta
            {
                Clave = m.Clave
                ,Descripcion = m.Descripcion
                ,Categoria_para_Platillos_Categorias_de_platillos = new Core.Classes.Categorias_de_platillos.Categorias_de_platillos() { Clave = m.Categoria_para_Platillos.GetValueOrDefault(), Categoria = m.Categoria_para_Platillos_Categoria }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Tipo_de_Dieta>("sp_ListSelCount_Tipo_de_Dieta", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipo_de_Dieta>("sp_ListSelAll_Tipo_de_Dieta", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta
                {
                    Clave = m.Tipo_de_Dieta_Clave,
                    Descripcion = m.Tipo_de_Dieta_Descripcion,
                    Categoria_para_Platillos = m.Tipo_de_Dieta_Categoria_para_Platillos,

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

        public IList<Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tipo_de_DietaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipo_de_DietaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_DietaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTipo_de_Dieta>("sp_ListSelAll_Tipo_de_Dieta", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Tipo_de_DietaPagingModel result = null;

            if (data != null)
            {
                result = new Tipo_de_DietaPagingModel
                {
                    Tipo_de_Dietas =
                        data.Select(m => new Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta
                {
                    Clave = m.Tipo_de_Dieta_Clave
                    ,Descripcion = m.Tipo_de_Dieta_Descripcion
                    ,Categoria_para_Platillos = m.Tipo_de_Dieta_Categoria_para_Platillos
                    ,Categoria_para_Platillos_Categorias_de_platillos = new Core.Classes.Categorias_de_platillos.Categorias_de_platillos() { Clave = m.Tipo_de_Dieta_Categoria_para_Platillos.GetValueOrDefault(), Categoria = m.Tipo_de_Dieta_Categoria_para_Platillos_Categoria }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tipo_de_DietaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta>("sp_GetTipo_de_Dieta", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTipo_de_Dieta>("sp_DelTipo_de_Dieta", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta entity)
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
                var padreCategoria_para_Platillos = _dataProvider.GetParameter();
                padreCategoria_para_Platillos.ParameterName = "Categoria_para_Platillos";
                padreCategoria_para_Platillos.DbType = DbType.Int32;
                padreCategoria_para_Platillos.Value = (object)entity.Categoria_para_Platillos ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTipo_de_Dieta>("sp_InsTipo_de_Dieta" , padreDescripcion
, padreCategoria_para_Platillos
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

        public int Update(Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta entity)
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
                var paramUpdCategoria_para_Platillos = _dataProvider.GetParameter();
                paramUpdCategoria_para_Platillos.ParameterName = "Categoria_para_Platillos";
                paramUpdCategoria_para_Platillos.DbType = DbType.Int32;
                paramUpdCategoria_para_Platillos.Value = (object)entity.Categoria_para_Platillos ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipo_de_Dieta>("sp_UpdTipo_de_Dieta" , paramUpdClave , paramUpdDescripcion , paramUpdCategoria_para_Platillos ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta Tipo_de_DietaDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
		var paramUpdCategoria_para_Platillos = _dataProvider.GetParameter();
                paramUpdCategoria_para_Platillos.ParameterName = "Categoria_para_Platillos";
                paramUpdCategoria_para_Platillos.DbType = DbType.Int32;
                paramUpdCategoria_para_Platillos.Value = (object)entity.Categoria_para_Platillos ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTipo_de_Dieta>("sp_UpdTipo_de_Dieta" , paramUpdClave , paramUpdDescripcion , paramUpdCategoria_para_Platillos ).FirstOrDefault();

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

