using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Rangos_Pediatria_por_Platillos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Rangos_Pediatria_por_Platillos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Rangos_Pediatria_por_PlatillosService : IRangos_Pediatria_por_PlatillosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> _Rangos_Pediatria_por_PlatillosRepository;
        #endregion

        #region Ctor
        public Rangos_Pediatria_por_PlatillosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> Rangos_Pediatria_por_PlatillosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Rangos_Pediatria_por_PlatillosRepository = Rangos_Pediatria_por_PlatillosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Rangos_Pediatria_por_PlatillosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>("sp_SelAllRangos_Pediatria_por_Platillos");
        }

        public IList<Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallRangos_Pediatria_por_Platillos_Complete>("sp_SelAllComplete_Rangos_Pediatria_por_Platillos");
            return data.Select(m => new Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos
            {
                Folio = m.Folio
                ,Nombre_de_rango = m.Nombre_de_rango
                ,Edad_minima = m.Edad_minima
                ,Edad_maxima = m.Edad_maxima
                ,Tiene_padecimientos = m.Tiene_padecimientos.GetValueOrDefault()


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Rangos_Pediatria_por_Platillos>("sp_ListSelCount_Rangos_Pediatria_por_Platillos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRangos_Pediatria_por_Platillos>("sp_ListSelAll_Rangos_Pediatria_por_Platillos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos
                {
                    Folio = m.Rangos_Pediatria_por_Platillos_Folio,
                    Nombre_de_rango = m.Rangos_Pediatria_por_Platillos_Nombre_de_rango,
                    Edad_minima = m.Rangos_Pediatria_por_Platillos_Edad_minima,
                    Edad_maxima = m.Rangos_Pediatria_por_Platillos_Edad_maxima,
                    Tiene_padecimientos = m.Rangos_Pediatria_por_Platillos_Tiene_padecimientos ?? false,

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

        public IList<Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Rangos_Pediatria_por_PlatillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Rangos_Pediatria_por_PlatillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_PlatillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRangos_Pediatria_por_Platillos>("sp_ListSelAll_Rangos_Pediatria_por_Platillos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Rangos_Pediatria_por_PlatillosPagingModel result = null;

            if (data != null)
            {
                result = new Rangos_Pediatria_por_PlatillosPagingModel
                {
                    Rangos_Pediatria_por_Platilloss =
                        data.Select(m => new Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos
                {
                    Folio = m.Rangos_Pediatria_por_Platillos_Folio
                    ,Nombre_de_rango = m.Rangos_Pediatria_por_Platillos_Nombre_de_rango
                    ,Edad_minima = m.Rangos_Pediatria_por_Platillos_Edad_minima
                    ,Edad_maxima = m.Rangos_Pediatria_por_Platillos_Edad_maxima
                    ,Tiene_padecimientos = m.Rangos_Pediatria_por_Platillos_Tiene_padecimientos ?? false

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Rangos_Pediatria_por_PlatillosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos>("sp_GetRangos_Pediatria_por_Platillos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelRangos_Pediatria_por_Platillos>("sp_DelRangos_Pediatria_por_Platillos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreNombre_de_rango = _dataProvider.GetParameter();
                padreNombre_de_rango.ParameterName = "Nombre_de_rango";
                padreNombre_de_rango.DbType = DbType.String;
                padreNombre_de_rango.Value = (object)entity.Nombre_de_rango ?? DBNull.Value;
                var padreEdad_minima = _dataProvider.GetParameter();
                padreEdad_minima.ParameterName = "Edad_minima";
                padreEdad_minima.DbType = DbType.Int32;
                padreEdad_minima.Value = (object)entity.Edad_minima ?? DBNull.Value;

                var padreEdad_maxima = _dataProvider.GetParameter();
                padreEdad_maxima.ParameterName = "Edad_maxima";
                padreEdad_maxima.DbType = DbType.Int32;
                padreEdad_maxima.Value = (object)entity.Edad_maxima ?? DBNull.Value;

                var padreTiene_padecimientos = _dataProvider.GetParameter();
                padreTiene_padecimientos.ParameterName = "Tiene_padecimientos";
                padreTiene_padecimientos.DbType = DbType.Boolean;
                padreTiene_padecimientos.Value = (object)entity.Tiene_padecimientos ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsRangos_Pediatria_por_Platillos>("sp_InsRangos_Pediatria_por_Platillos" , padreNombre_de_rango
, padreEdad_minima
, padreEdad_maxima
, padreTiene_padecimientos
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

        public int Update(Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdNombre_de_rango = _dataProvider.GetParameter();
                paramUpdNombre_de_rango.ParameterName = "Nombre_de_rango";
                paramUpdNombre_de_rango.DbType = DbType.String;
                paramUpdNombre_de_rango.Value = (object)entity.Nombre_de_rango ?? DBNull.Value;
                var paramUpdEdad_minima = _dataProvider.GetParameter();
                paramUpdEdad_minima.ParameterName = "Edad_minima";
                paramUpdEdad_minima.DbType = DbType.Int32;
                paramUpdEdad_minima.Value = (object)entity.Edad_minima ?? DBNull.Value;

                var paramUpdEdad_maxima = _dataProvider.GetParameter();
                paramUpdEdad_maxima.ParameterName = "Edad_maxima";
                paramUpdEdad_maxima.DbType = DbType.Int32;
                paramUpdEdad_maxima.Value = (object)entity.Edad_maxima ?? DBNull.Value;

                var paramUpdTiene_padecimientos = _dataProvider.GetParameter();
                paramUpdTiene_padecimientos.ParameterName = "Tiene_padecimientos";
                paramUpdTiene_padecimientos.DbType = DbType.Boolean;
                paramUpdTiene_padecimientos.Value = (object)entity.Tiene_padecimientos ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRangos_Pediatria_por_Platillos>("sp_UpdRangos_Pediatria_por_Platillos" , paramUpdFolio , paramUpdNombre_de_rango , paramUpdEdad_minima , paramUpdEdad_maxima , paramUpdTiene_padecimientos ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos Rangos_Pediatria_por_PlatillosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdNombre_de_rango = _dataProvider.GetParameter();
                paramUpdNombre_de_rango.ParameterName = "Nombre_de_rango";
                paramUpdNombre_de_rango.DbType = DbType.String;
                paramUpdNombre_de_rango.Value = (object)entity.Nombre_de_rango ?? DBNull.Value;
                var paramUpdEdad_minima = _dataProvider.GetParameter();
                paramUpdEdad_minima.ParameterName = "Edad_minima";
                paramUpdEdad_minima.DbType = DbType.Int32;
                paramUpdEdad_minima.Value = (object)entity.Edad_minima ?? DBNull.Value;
                var paramUpdEdad_maxima = _dataProvider.GetParameter();
                paramUpdEdad_maxima.ParameterName = "Edad_maxima";
                paramUpdEdad_maxima.DbType = DbType.Int32;
                paramUpdEdad_maxima.Value = (object)entity.Edad_maxima ?? DBNull.Value;
                var paramUpdTiene_padecimientos = _dataProvider.GetParameter();
                paramUpdTiene_padecimientos.ParameterName = "Tiene_padecimientos";
                paramUpdTiene_padecimientos.DbType = DbType.Boolean;
                paramUpdTiene_padecimientos.Value = (object)entity.Tiene_padecimientos ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRangos_Pediatria_por_Platillos>("sp_UpdRangos_Pediatria_por_Platillos" , paramUpdFolio , paramUpdNombre_de_rango , paramUpdEdad_minima , paramUpdEdad_maxima , paramUpdTiene_padecimientos ).FirstOrDefault();

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

