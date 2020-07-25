using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Notificaciones_Paciente;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Notificaciones_Paciente
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Notificaciones_PacienteService : IDetalle_Notificaciones_PacienteService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente> _Detalle_Notificaciones_PacienteRepository;
        #endregion

        #region Ctor
        public Detalle_Notificaciones_PacienteService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente> Detalle_Notificaciones_PacienteRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Notificaciones_PacienteRepository = Detalle_Notificaciones_PacienteRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Notificaciones_PacienteRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente>("sp_SelAllDetalle_Notificaciones_Paciente");
        }

        public IList<Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Notificaciones_Paciente_Complete>("sp_SelAllComplete_Detalle_Notificaciones_Paciente");
            return data.Select(m => new Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente
            {
                Folio = m.Folio
                ,FolioConfiguracion = m.FolioConfiguracion
                ,Funcionalidad_Funcionalidades_para_Notificacion = new Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion() { Folio = m.Funcionalidad.GetValueOrDefault(), Funcionalidad = m.Funcionalidad_Funcionalidad }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Notificaciones_Paciente>("sp_ListSelCount_Detalle_Notificaciones_Paciente", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Notificaciones_Paciente>("sp_ListSelAll_Detalle_Notificaciones_Paciente", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente
                {
                    Folio = m.Detalle_Notificaciones_Paciente_Folio,
                    FolioConfiguracion = m.Detalle_Notificaciones_Paciente_FolioConfiguracion,
                    Funcionalidad = m.Detalle_Notificaciones_Paciente_Funcionalidad,

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

        public IList<Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Notificaciones_PacienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Notificaciones_PacienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_PacientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Notificaciones_Paciente>("sp_ListSelAll_Detalle_Notificaciones_Paciente", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Notificaciones_PacientePagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Notificaciones_PacientePagingModel
                {
                    Detalle_Notificaciones_Pacientes =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente
                {
                    Folio = m.Detalle_Notificaciones_Paciente_Folio
                    ,FolioConfiguracion = m.Detalle_Notificaciones_Paciente_FolioConfiguracion
                    ,Funcionalidad = m.Detalle_Notificaciones_Paciente_Funcionalidad
                    ,Funcionalidad_Funcionalidades_para_Notificacion = new Core.Classes.Funcionalidades_para_Notificacion.Funcionalidades_para_Notificacion() { Folio = m.Detalle_Notificaciones_Paciente_Funcionalidad.GetValueOrDefault(), Funcionalidad = m.Detalle_Notificaciones_Paciente_Funcionalidad_Funcionalidad }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Notificaciones_PacienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente>("sp_GetDetalle_Notificaciones_Paciente", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Notificaciones_Paciente>("sp_DelDetalle_Notificaciones_Paciente", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolioConfiguracion = _dataProvider.GetParameter();
                padreFolioConfiguracion.ParameterName = "FolioConfiguracion";
                padreFolioConfiguracion.DbType = DbType.Int32;
                padreFolioConfiguracion.Value = (object)entity.FolioConfiguracion ?? DBNull.Value;
                var padreFuncionalidad = _dataProvider.GetParameter();
                padreFuncionalidad.ParameterName = "Funcionalidad";
                padreFuncionalidad.DbType = DbType.Int32;
                padreFuncionalidad.Value = (object)entity.Funcionalidad ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Notificaciones_Paciente>("sp_InsDetalle_Notificaciones_Paciente" , padreFolioConfiguracion
, padreFuncionalidad
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

        public int Update(Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolioConfiguracion = _dataProvider.GetParameter();
                paramUpdFolioConfiguracion.ParameterName = "FolioConfiguracion";
                paramUpdFolioConfiguracion.DbType = DbType.Int32;
                paramUpdFolioConfiguracion.Value = (object)entity.FolioConfiguracion ?? DBNull.Value;
                var paramUpdFuncionalidad = _dataProvider.GetParameter();
                paramUpdFuncionalidad.ParameterName = "Funcionalidad";
                paramUpdFuncionalidad.DbType = DbType.Int32;
                paramUpdFuncionalidad.Value = (object)entity.Funcionalidad ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Notificaciones_Paciente>("sp_UpdDetalle_Notificaciones_Paciente" , paramUpdFolio , paramUpdFolioConfiguracion , paramUpdFuncionalidad ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Notificaciones_Paciente.Detalle_Notificaciones_Paciente Detalle_Notificaciones_PacienteDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolioConfiguracion = _dataProvider.GetParameter();
                paramUpdFolioConfiguracion.ParameterName = "FolioConfiguracion";
                paramUpdFolioConfiguracion.DbType = DbType.Int32;
                paramUpdFolioConfiguracion.Value = (object)entity.FolioConfiguracion ?? DBNull.Value;
		var paramUpdFuncionalidad = _dataProvider.GetParameter();
                paramUpdFuncionalidad.ParameterName = "Funcionalidad";
                paramUpdFuncionalidad.DbType = DbType.Int32;
                paramUpdFuncionalidad.Value = (object)entity.Funcionalidad ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Notificaciones_Paciente>("sp_UpdDetalle_Notificaciones_Paciente" , paramUpdFolio , paramUpdFolioConfiguracion , paramUpdFuncionalidad ).FirstOrDefault();

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

