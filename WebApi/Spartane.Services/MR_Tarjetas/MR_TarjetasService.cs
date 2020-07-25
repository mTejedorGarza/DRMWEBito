using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MR_Tarjetas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MR_Tarjetas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MR_TarjetasService : IMR_TarjetasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas> _MR_TarjetasRepository;
        #endregion

        #region Ctor
        public MR_TarjetasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas> MR_TarjetasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MR_TarjetasRepository = MR_TarjetasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MR_TarjetasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas>("sp_SelAllMR_Tarjetas");
        }

        public IList<Core.Classes.MR_Tarjetas.MR_Tarjetas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMR_Tarjetas_Complete>("sp_SelAllComplete_MR_Tarjetas");
            return data.Select(m => new Core.Classes.MR_Tarjetas.MR_Tarjetas
            {
                Folio = m.Folio
                ,Folio_Metodos_de_Pago_Paciente = m.Folio_Metodos_de_Pago_Paciente
                ,Tipo_de_Tarjeta_Tipo_de_Tarjeta = new Core.Classes.Tipo_de_Tarjeta.Tipo_de_Tarjeta() { Clave = m.Tipo_de_Tarjeta.GetValueOrDefault(), Descripcion = m.Tipo_de_Tarjeta_Descripcion }
                ,Numero_de_Tarjeta = m.Numero_de_Tarjeta
                ,Nombre_del_Titular = m.Nombre_del_Titular
                ,Ano_de_vigencia = m.Ano_de_vigencia
                ,Mes_de_vigencia = m.Mes_de_vigencia
                ,Alias_de_la_Tarjeta = m.Alias_de_la_Tarjeta
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MR_Tarjetas>("sp_ListSelCount_MR_Tarjetas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMR_Tarjetas>("sp_ListSelAll_MR_Tarjetas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas
                {
                    Folio = m.MR_Tarjetas_Folio,
                    Folio_Metodos_de_Pago_Paciente = m.MR_Tarjetas_Folio_Metodos_de_Pago_Paciente,
                    Tipo_de_Tarjeta = m.MR_Tarjetas_Tipo_de_Tarjeta,
                    Numero_de_Tarjeta = m.MR_Tarjetas_Numero_de_Tarjeta,
                    Nombre_del_Titular = m.MR_Tarjetas_Nombre_del_Titular,
                    Ano_de_vigencia = m.MR_Tarjetas_Ano_de_vigencia,
                    Mes_de_vigencia = m.MR_Tarjetas_Mes_de_vigencia,
                    Alias_de_la_Tarjeta = m.MR_Tarjetas_Alias_de_la_Tarjeta,
                    Estatus = m.MR_Tarjetas_Estatus,

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

        public IList<Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MR_TarjetasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MR_TarjetasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MR_Tarjetas.MR_TarjetasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMR_Tarjetas>("sp_ListSelAll_MR_Tarjetas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MR_TarjetasPagingModel result = null;

            if (data != null)
            {
                result = new MR_TarjetasPagingModel
                {
                    MR_Tarjetass =
                        data.Select(m => new Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas
                {
                    Folio = m.MR_Tarjetas_Folio
                    ,Folio_Metodos_de_Pago_Paciente = m.MR_Tarjetas_Folio_Metodos_de_Pago_Paciente
                    ,Tipo_de_Tarjeta = m.MR_Tarjetas_Tipo_de_Tarjeta
                    ,Tipo_de_Tarjeta_Tipo_de_Tarjeta = new Core.Classes.Tipo_de_Tarjeta.Tipo_de_Tarjeta() { Clave = m.MR_Tarjetas_Tipo_de_Tarjeta.GetValueOrDefault(), Descripcion = m.MR_Tarjetas_Tipo_de_Tarjeta_Descripcion }
                    ,Numero_de_Tarjeta = m.MR_Tarjetas_Numero_de_Tarjeta
                    ,Nombre_del_Titular = m.MR_Tarjetas_Nombre_del_Titular
                    ,Ano_de_vigencia = m.MR_Tarjetas_Ano_de_vigencia
                    ,Mes_de_vigencia = m.MR_Tarjetas_Mes_de_vigencia
                    ,Alias_de_la_Tarjeta = m.MR_Tarjetas_Alias_de_la_Tarjeta
                    ,Estatus = m.MR_Tarjetas_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.MR_Tarjetas_Estatus.GetValueOrDefault(), Descripcion = m.MR_Tarjetas_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MR_TarjetasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas>("sp_GetMR_Tarjetas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMR_Tarjetas>("sp_DelMR_Tarjetas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Metodos_de_Pago_Paciente = _dataProvider.GetParameter();
                padreFolio_Metodos_de_Pago_Paciente.ParameterName = "Folio_Metodos_de_Pago_Paciente";
                padreFolio_Metodos_de_Pago_Paciente.DbType = DbType.Int32;
                padreFolio_Metodos_de_Pago_Paciente.Value = (object)entity.Folio_Metodos_de_Pago_Paciente ?? DBNull.Value;
                var padreTipo_de_Tarjeta = _dataProvider.GetParameter();
                padreTipo_de_Tarjeta.ParameterName = "Tipo_de_Tarjeta";
                padreTipo_de_Tarjeta.DbType = DbType.Int32;
                padreTipo_de_Tarjeta.Value = (object)entity.Tipo_de_Tarjeta ?? DBNull.Value;

                var padreNumero_de_Tarjeta = _dataProvider.GetParameter();
                padreNumero_de_Tarjeta.ParameterName = "Numero_de_Tarjeta";
                padreNumero_de_Tarjeta.DbType = DbType.String;
                padreNumero_de_Tarjeta.Value = (object)entity.Numero_de_Tarjeta ?? DBNull.Value;
                var padreNombre_del_Titular = _dataProvider.GetParameter();
                padreNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                padreNombre_del_Titular.DbType = DbType.String;
                padreNombre_del_Titular.Value = (object)entity.Nombre_del_Titular ?? DBNull.Value;
                var padreAno_de_vigencia = _dataProvider.GetParameter();
                padreAno_de_vigencia.ParameterName = "Ano_de_vigencia";
                padreAno_de_vigencia.DbType = DbType.Int32;
                padreAno_de_vigencia.Value = (object)entity.Ano_de_vigencia ?? DBNull.Value;

                var padreMes_de_vigencia = _dataProvider.GetParameter();
                padreMes_de_vigencia.ParameterName = "Mes_de_vigencia";
                padreMes_de_vigencia.DbType = DbType.Int32;
                padreMes_de_vigencia.Value = (object)entity.Mes_de_vigencia ?? DBNull.Value;

                var padreAlias_de_la_Tarjeta = _dataProvider.GetParameter();
                padreAlias_de_la_Tarjeta.ParameterName = "Alias_de_la_Tarjeta";
                padreAlias_de_la_Tarjeta.DbType = DbType.String;
                padreAlias_de_la_Tarjeta.Value = (object)entity.Alias_de_la_Tarjeta ?? DBNull.Value;
                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMR_Tarjetas>("sp_InsMR_Tarjetas" , padreFolio_Metodos_de_Pago_Paciente
, padreTipo_de_Tarjeta
, padreNumero_de_Tarjeta
, padreNombre_del_Titular
, padreAno_de_vigencia
, padreMes_de_vigencia
, padreAlias_de_la_Tarjeta
, padreEstatus
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

        public int Update(Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Metodos_de_Pago_Paciente = _dataProvider.GetParameter();
                paramUpdFolio_Metodos_de_Pago_Paciente.ParameterName = "Folio_Metodos_de_Pago_Paciente";
                paramUpdFolio_Metodos_de_Pago_Paciente.DbType = DbType.Int32;
                paramUpdFolio_Metodos_de_Pago_Paciente.Value = (object)entity.Folio_Metodos_de_Pago_Paciente ?? DBNull.Value;
                var paramUpdTipo_de_Tarjeta = _dataProvider.GetParameter();
                paramUpdTipo_de_Tarjeta.ParameterName = "Tipo_de_Tarjeta";
                paramUpdTipo_de_Tarjeta.DbType = DbType.Int32;
                paramUpdTipo_de_Tarjeta.Value = (object)entity.Tipo_de_Tarjeta ?? DBNull.Value;

                var paramUpdNumero_de_Tarjeta = _dataProvider.GetParameter();
                paramUpdNumero_de_Tarjeta.ParameterName = "Numero_de_Tarjeta";
                paramUpdNumero_de_Tarjeta.DbType = DbType.String;
                paramUpdNumero_de_Tarjeta.Value = (object)entity.Numero_de_Tarjeta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)entity.Nombre_del_Titular ?? DBNull.Value;
                var paramUpdAno_de_vigencia = _dataProvider.GetParameter();
                paramUpdAno_de_vigencia.ParameterName = "Ano_de_vigencia";
                paramUpdAno_de_vigencia.DbType = DbType.Int32;
                paramUpdAno_de_vigencia.Value = (object)entity.Ano_de_vigencia ?? DBNull.Value;

                var paramUpdMes_de_vigencia = _dataProvider.GetParameter();
                paramUpdMes_de_vigencia.ParameterName = "Mes_de_vigencia";
                paramUpdMes_de_vigencia.DbType = DbType.Int32;
                paramUpdMes_de_vigencia.Value = (object)entity.Mes_de_vigencia ?? DBNull.Value;

                var paramUpdAlias_de_la_Tarjeta = _dataProvider.GetParameter();
                paramUpdAlias_de_la_Tarjeta.ParameterName = "Alias_de_la_Tarjeta";
                paramUpdAlias_de_la_Tarjeta.DbType = DbType.String;
                paramUpdAlias_de_la_Tarjeta.Value = (object)entity.Alias_de_la_Tarjeta ?? DBNull.Value;
                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMR_Tarjetas>("sp_UpdMR_Tarjetas" , paramUpdFolio , paramUpdFolio_Metodos_de_Pago_Paciente , paramUpdTipo_de_Tarjeta , paramUpdNumero_de_Tarjeta , paramUpdNombre_del_Titular , paramUpdAno_de_vigencia , paramUpdMes_de_vigencia , paramUpdAlias_de_la_Tarjeta , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MR_Tarjetas.MR_Tarjetas MR_TarjetasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Metodos_de_Pago_Paciente = _dataProvider.GetParameter();
                paramUpdFolio_Metodos_de_Pago_Paciente.ParameterName = "Folio_Metodos_de_Pago_Paciente";
                paramUpdFolio_Metodos_de_Pago_Paciente.DbType = DbType.Int32;
                paramUpdFolio_Metodos_de_Pago_Paciente.Value = (object)entity.Folio_Metodos_de_Pago_Paciente ?? DBNull.Value;
		var paramUpdTipo_de_Tarjeta = _dataProvider.GetParameter();
                paramUpdTipo_de_Tarjeta.ParameterName = "Tipo_de_Tarjeta";
                paramUpdTipo_de_Tarjeta.DbType = DbType.Int32;
                paramUpdTipo_de_Tarjeta.Value = (object)entity.Tipo_de_Tarjeta ?? DBNull.Value;
                var paramUpdNumero_de_Tarjeta = _dataProvider.GetParameter();
                paramUpdNumero_de_Tarjeta.ParameterName = "Numero_de_Tarjeta";
                paramUpdNumero_de_Tarjeta.DbType = DbType.String;
                paramUpdNumero_de_Tarjeta.Value = (object)entity.Numero_de_Tarjeta ?? DBNull.Value;
                var paramUpdNombre_del_Titular = _dataProvider.GetParameter();
                paramUpdNombre_del_Titular.ParameterName = "Nombre_del_Titular";
                paramUpdNombre_del_Titular.DbType = DbType.String;
                paramUpdNombre_del_Titular.Value = (object)entity.Nombre_del_Titular ?? DBNull.Value;
                var paramUpdAno_de_vigencia = _dataProvider.GetParameter();
                paramUpdAno_de_vigencia.ParameterName = "Ano_de_vigencia";
                paramUpdAno_de_vigencia.DbType = DbType.Int32;
                paramUpdAno_de_vigencia.Value = (object)entity.Ano_de_vigencia ?? DBNull.Value;
                var paramUpdMes_de_vigencia = _dataProvider.GetParameter();
                paramUpdMes_de_vigencia.ParameterName = "Mes_de_vigencia";
                paramUpdMes_de_vigencia.DbType = DbType.Int32;
                paramUpdMes_de_vigencia.Value = (object)entity.Mes_de_vigencia ?? DBNull.Value;
                var paramUpdAlias_de_la_Tarjeta = _dataProvider.GetParameter();
                paramUpdAlias_de_la_Tarjeta.ParameterName = "Alias_de_la_Tarjeta";
                paramUpdAlias_de_la_Tarjeta.DbType = DbType.String;
                paramUpdAlias_de_la_Tarjeta.Value = (object)entity.Alias_de_la_Tarjeta ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMR_Tarjetas>("sp_UpdMR_Tarjetas" , paramUpdFolio , paramUpdFolio_Metodos_de_Pago_Paciente , paramUpdTipo_de_Tarjeta , paramUpdNumero_de_Tarjeta , paramUpdNombre_del_Titular , paramUpdAno_de_vigencia , paramUpdMes_de_vigencia , paramUpdAlias_de_la_Tarjeta , paramUpdEstatus ).FirstOrDefault();

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

