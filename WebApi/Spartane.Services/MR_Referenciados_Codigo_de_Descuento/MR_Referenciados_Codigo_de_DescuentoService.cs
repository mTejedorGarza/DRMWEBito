using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MR_Referenciados_Codigo_de_Descuento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MR_Referenciados_Codigo_de_DescuentoService : IMR_Referenciados_Codigo_de_DescuentoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> _MR_Referenciados_Codigo_de_DescuentoRepository;
        #endregion

        #region Ctor
        public MR_Referenciados_Codigo_de_DescuentoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> MR_Referenciados_Codigo_de_DescuentoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MR_Referenciados_Codigo_de_DescuentoRepository = MR_Referenciados_Codigo_de_DescuentoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MR_Referenciados_Codigo_de_DescuentoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento>("sp_SelAllMR_Referenciados_Codigo_de_Descuento");
        }

        public IList<Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMR_Referenciados_Codigo_de_Descuento_Complete>("sp_SelAllComplete_MR_Referenciados_Codigo_de_Descuento");
            return data.Select(m => new Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento
            {
                Folio = m.Folio
                ,Folio_Codigos_de_Descuento = m.Folio_Codigos_de_Descuento
                ,Tipo_de_usuario_Tipo_Paciente = new Core.Classes.Tipo_Paciente.Tipo_Paciente() { Clave = m.Tipo_de_usuario.GetValueOrDefault(), Descripcion = m.Tipo_de_usuario_Descripcion }
                ,Usuario_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario.GetValueOrDefault(), Name = m.Usuario_Name }
                ,Fecha_de_aplicacion = m.Fecha_de_aplicacion
                ,Descuento_Total = m.Descuento_Total


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MR_Referenciados_Codigo_de_Descuento>("sp_ListSelCount_MR_Referenciados_Codigo_de_Descuento", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMR_Referenciados_Codigo_de_Descuento>("sp_ListSelAll_MR_Referenciados_Codigo_de_Descuento", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento
                {
                    Folio = m.MR_Referenciados_Codigo_de_Descuento_Folio,
                    Folio_Codigos_de_Descuento = m.MR_Referenciados_Codigo_de_Descuento_Folio_Codigos_de_Descuento,
                    Tipo_de_usuario = m.MR_Referenciados_Codigo_de_Descuento_Tipo_de_usuario,
                    Usuario = m.MR_Referenciados_Codigo_de_Descuento_Usuario,
                    Fecha_de_aplicacion = m.MR_Referenciados_Codigo_de_Descuento_Fecha_de_aplicacion,
                    Descuento_Total = m.MR_Referenciados_Codigo_de_Descuento_Descuento_Total,

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

        public IList<Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MR_Referenciados_Codigo_de_DescuentoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MR_Referenciados_Codigo_de_DescuentoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_DescuentoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMR_Referenciados_Codigo_de_Descuento>("sp_ListSelAll_MR_Referenciados_Codigo_de_Descuento", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MR_Referenciados_Codigo_de_DescuentoPagingModel result = null;

            if (data != null)
            {
                result = new MR_Referenciados_Codigo_de_DescuentoPagingModel
                {
                    MR_Referenciados_Codigo_de_Descuentos =
                        data.Select(m => new Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento
                {
                    Folio = m.MR_Referenciados_Codigo_de_Descuento_Folio
                    ,Folio_Codigos_de_Descuento = m.MR_Referenciados_Codigo_de_Descuento_Folio_Codigos_de_Descuento
                    ,Tipo_de_usuario = m.MR_Referenciados_Codigo_de_Descuento_Tipo_de_usuario
                    ,Tipo_de_usuario_Tipo_Paciente = new Core.Classes.Tipo_Paciente.Tipo_Paciente() { Clave = m.MR_Referenciados_Codigo_de_Descuento_Tipo_de_usuario.GetValueOrDefault(), Descripcion = m.MR_Referenciados_Codigo_de_Descuento_Tipo_de_usuario_Descripcion }
                    ,Usuario = m.MR_Referenciados_Codigo_de_Descuento_Usuario
                    ,Usuario_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.MR_Referenciados_Codigo_de_Descuento_Usuario.GetValueOrDefault(), Name = m.MR_Referenciados_Codigo_de_Descuento_Usuario_Name }
                    ,Fecha_de_aplicacion = m.MR_Referenciados_Codigo_de_Descuento_Fecha_de_aplicacion
                    ,Descuento_Total = m.MR_Referenciados_Codigo_de_Descuento_Descuento_Total

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MR_Referenciados_Codigo_de_DescuentoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento>("sp_GetMR_Referenciados_Codigo_de_Descuento", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMR_Referenciados_Codigo_de_Descuento>("sp_DelMR_Referenciados_Codigo_de_Descuento", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Codigos_de_Descuento = _dataProvider.GetParameter();
                padreFolio_Codigos_de_Descuento.ParameterName = "Folio_Codigos_de_Descuento";
                padreFolio_Codigos_de_Descuento.DbType = DbType.Int32;
                padreFolio_Codigos_de_Descuento.Value = (object)entity.Folio_Codigos_de_Descuento ?? DBNull.Value;
                var padreTipo_de_usuario = _dataProvider.GetParameter();
                padreTipo_de_usuario.ParameterName = "Tipo_de_usuario";
                padreTipo_de_usuario.DbType = DbType.Int32;
                padreTipo_de_usuario.Value = (object)entity.Tipo_de_usuario ?? DBNull.Value;

                var padreUsuario = _dataProvider.GetParameter();
                padreUsuario.ParameterName = "Usuario";
                padreUsuario.DbType = DbType.Int32;
                padreUsuario.Value = (object)entity.Usuario ?? DBNull.Value;

                var padreFecha_de_aplicacion = _dataProvider.GetParameter();
                padreFecha_de_aplicacion.ParameterName = "Fecha_de_aplicacion";
                padreFecha_de_aplicacion.DbType = DbType.DateTime;
                padreFecha_de_aplicacion.Value = (object)entity.Fecha_de_aplicacion ?? DBNull.Value;

                var padreDescuento_Total = _dataProvider.GetParameter();
                padreDescuento_Total.ParameterName = "Descuento_Total";
                padreDescuento_Total.DbType = DbType.Decimal;
                padreDescuento_Total.Value = (object)entity.Descuento_Total ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMR_Referenciados_Codigo_de_Descuento>("sp_InsMR_Referenciados_Codigo_de_Descuento" , padreFolio_Codigos_de_Descuento
, padreTipo_de_usuario
, padreUsuario
, padreFecha_de_aplicacion
, padreDescuento_Total
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

        public int Update(Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Codigos_de_Descuento = _dataProvider.GetParameter();
                paramUpdFolio_Codigos_de_Descuento.ParameterName = "Folio_Codigos_de_Descuento";
                paramUpdFolio_Codigos_de_Descuento.DbType = DbType.Int32;
                paramUpdFolio_Codigos_de_Descuento.Value = (object)entity.Folio_Codigos_de_Descuento ?? DBNull.Value;
                var paramUpdTipo_de_usuario = _dataProvider.GetParameter();
                paramUpdTipo_de_usuario.ParameterName = "Tipo_de_usuario";
                paramUpdTipo_de_usuario.DbType = DbType.Int32;
                paramUpdTipo_de_usuario.Value = (object)entity.Tipo_de_usuario ?? DBNull.Value;

                var paramUpdUsuario = _dataProvider.GetParameter();
                paramUpdUsuario.ParameterName = "Usuario";
                paramUpdUsuario.DbType = DbType.Int32;
                paramUpdUsuario.Value = (object)entity.Usuario ?? DBNull.Value;

                var paramUpdFecha_de_aplicacion = _dataProvider.GetParameter();
                paramUpdFecha_de_aplicacion.ParameterName = "Fecha_de_aplicacion";
                paramUpdFecha_de_aplicacion.DbType = DbType.DateTime;
                paramUpdFecha_de_aplicacion.Value = (object)entity.Fecha_de_aplicacion ?? DBNull.Value;

                var paramUpdDescuento_Total = _dataProvider.GetParameter();
                paramUpdDescuento_Total.ParameterName = "Descuento_Total";
                paramUpdDescuento_Total.DbType = DbType.Decimal;
                paramUpdDescuento_Total.Value = (object)entity.Descuento_Total ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMR_Referenciados_Codigo_de_Descuento>("sp_UpdMR_Referenciados_Codigo_de_Descuento" , paramUpdFolio , paramUpdFolio_Codigos_de_Descuento , paramUpdTipo_de_usuario , paramUpdUsuario , paramUpdFecha_de_aplicacion , paramUpdDescuento_Total ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MR_Referenciados_Codigo_de_Descuento.MR_Referenciados_Codigo_de_Descuento MR_Referenciados_Codigo_de_DescuentoDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Codigos_de_Descuento = _dataProvider.GetParameter();
                paramUpdFolio_Codigos_de_Descuento.ParameterName = "Folio_Codigos_de_Descuento";
                paramUpdFolio_Codigos_de_Descuento.DbType = DbType.Int32;
                paramUpdFolio_Codigos_de_Descuento.Value = (object)entity.Folio_Codigos_de_Descuento ?? DBNull.Value;
		var paramUpdTipo_de_usuario = _dataProvider.GetParameter();
                paramUpdTipo_de_usuario.ParameterName = "Tipo_de_usuario";
                paramUpdTipo_de_usuario.DbType = DbType.Int32;
                paramUpdTipo_de_usuario.Value = (object)entity.Tipo_de_usuario ?? DBNull.Value;
		var paramUpdUsuario = _dataProvider.GetParameter();
                paramUpdUsuario.ParameterName = "Usuario";
                paramUpdUsuario.DbType = DbType.Int32;
                paramUpdUsuario.Value = (object)entity.Usuario ?? DBNull.Value;
                var paramUpdFecha_de_aplicacion = _dataProvider.GetParameter();
                paramUpdFecha_de_aplicacion.ParameterName = "Fecha_de_aplicacion";
                paramUpdFecha_de_aplicacion.DbType = DbType.DateTime;
                paramUpdFecha_de_aplicacion.Value = (object)entity.Fecha_de_aplicacion ?? DBNull.Value;
                var paramUpdDescuento_Total = _dataProvider.GetParameter();
                paramUpdDescuento_Total.ParameterName = "Descuento_Total";
                paramUpdDescuento_Total.DbType = DbType.Decimal;
                paramUpdDescuento_Total.Value = (object)entity.Descuento_Total ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMR_Referenciados_Codigo_de_Descuento>("sp_UpdMR_Referenciados_Codigo_de_Descuento" , paramUpdFolio , paramUpdFolio_Codigos_de_Descuento , paramUpdTipo_de_usuario , paramUpdUsuario , paramUpdFecha_de_aplicacion , paramUpdDescuento_Total ).FirstOrDefault();

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

