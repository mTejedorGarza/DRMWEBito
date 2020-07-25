using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Telefonos_de_Asistencia;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Telefonos_de_Asistencia
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Telefonos_de_AsistenciaService : ITelefonos_de_AsistenciaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia> _Telefonos_de_AsistenciaRepository;
        #endregion

        #region Ctor
        public Telefonos_de_AsistenciaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia> Telefonos_de_AsistenciaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Telefonos_de_AsistenciaRepository = Telefonos_de_AsistenciaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Telefonos_de_AsistenciaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia>("sp_SelAllTelefonos_de_Asistencia");
        }

        public IList<Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallTelefonos_de_Asistencia_Complete>("sp_SelAllComplete_Telefonos_de_Asistencia");
            return data.Select(m => new Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia
            {
                Folio = m.Folio
                ,Telefono = m.Telefono
                ,Departamento = m.Departamento


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Telefonos_de_Asistencia>("sp_ListSelCount_Telefonos_de_Asistencia", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTelefonos_de_Asistencia>("sp_ListSelAll_Telefonos_de_Asistencia", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia
                {
                    Folio = m.Telefonos_de_Asistencia_Folio,
                    Telefono = m.Telefonos_de_Asistencia_Telefono,
                    Departamento = m.Telefonos_de_Asistencia_Departamento,

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

        public IList<Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Telefonos_de_AsistenciaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Telefonos_de_AsistenciaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_AsistenciaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllTelefonos_de_Asistencia>("sp_ListSelAll_Telefonos_de_Asistencia", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Telefonos_de_AsistenciaPagingModel result = null;

            if (data != null)
            {
                result = new Telefonos_de_AsistenciaPagingModel
                {
                    Telefonos_de_Asistencias =
                        data.Select(m => new Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia
                {
                    Folio = m.Telefonos_de_Asistencia_Folio
                    ,Telefono = m.Telefonos_de_Asistencia_Telefono
                    ,Departamento = m.Telefonos_de_Asistencia_Departamento

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Telefonos_de_AsistenciaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia>("sp_GetTelefonos_de_Asistencia", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelTelefonos_de_Asistencia>("sp_DelTelefonos_de_Asistencia", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreTelefono = _dataProvider.GetParameter();
                padreTelefono.ParameterName = "Telefono";
                padreTelefono.DbType = DbType.String;
                padreTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var padreDepartamento = _dataProvider.GetParameter();
                padreDepartamento.ParameterName = "Departamento";
                padreDepartamento.DbType = DbType.String;
                padreDepartamento.Value = (object)entity.Departamento ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsTelefonos_de_Asistencia>("sp_InsTelefonos_de_Asistencia" , padreTelefono
, padreDepartamento
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

        public int Update(Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var paramUpdDepartamento = _dataProvider.GetParameter();
                paramUpdDepartamento.ParameterName = "Departamento";
                paramUpdDepartamento.DbType = DbType.String;
                paramUpdDepartamento.Value = (object)entity.Departamento ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTelefonos_de_Asistencia>("sp_UpdTelefonos_de_Asistencia" , paramUpdFolio , paramUpdTelefono , paramUpdDepartamento ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Telefonos_de_Asistencia.Telefonos_de_Asistencia Telefonos_de_AsistenciaDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdTelefono = _dataProvider.GetParameter();
                paramUpdTelefono.ParameterName = "Telefono";
                paramUpdTelefono.DbType = DbType.String;
                paramUpdTelefono.Value = (object)entity.Telefono ?? DBNull.Value;
                var paramUpdDepartamento = _dataProvider.GetParameter();
                paramUpdDepartamento.ParameterName = "Departamento";
                paramUpdDepartamento.DbType = DbType.String;
                paramUpdDepartamento.Value = (object)entity.Departamento ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdTelefonos_de_Asistencia>("sp_UpdTelefonos_de_Asistencia" , paramUpdFolio , paramUpdTelefono , paramUpdDepartamento ).FirstOrDefault();

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

