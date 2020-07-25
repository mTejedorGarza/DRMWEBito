using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_Beneficiarios_Suscripcion;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Beneficiarios_Suscripcion
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Beneficiarios_SuscripcionService : IMS_Beneficiarios_SuscripcionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> _MS_Beneficiarios_SuscripcionRepository;
        #endregion

        #region Ctor
        public MS_Beneficiarios_SuscripcionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> MS_Beneficiarios_SuscripcionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Beneficiarios_SuscripcionRepository = MS_Beneficiarios_SuscripcionRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_Beneficiarios_SuscripcionRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion>("sp_SelAllMS_Beneficiarios_Suscripcion");
        }

        public IList<Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_Beneficiarios_Suscripcion_Complete>("sp_SelAllComplete_MS_Beneficiarios_Suscripcion");
            return data.Select(m => new Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion
            {
                Folio = m.Folio
                ,Folio_Planes_de_Suscripcion = m.Folio_Planes_de_Suscripcion
                ,Beneficiario_Tipo_Paciente = new Core.Classes.Tipo_Paciente.Tipo_Paciente() { Clave = m.Beneficiario.GetValueOrDefault(), Descripcion = m.Beneficiario_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_Beneficiarios_Suscripcion>("sp_ListSelCount_MS_Beneficiarios_Suscripcion", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Beneficiarios_Suscripcion>("sp_ListSelAll_MS_Beneficiarios_Suscripcion", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion
                {
                    Folio = m.MS_Beneficiarios_Suscripcion_Folio,
                    Folio_Planes_de_Suscripcion = m.MS_Beneficiarios_Suscripcion_Folio_Planes_de_Suscripcion,
                    Beneficiario = m.MS_Beneficiarios_Suscripcion_Beneficiario,

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

        public IList<Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Beneficiarios_SuscripcionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Beneficiarios_SuscripcionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_SuscripcionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_Beneficiarios_Suscripcion>("sp_ListSelAll_MS_Beneficiarios_Suscripcion", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_Beneficiarios_SuscripcionPagingModel result = null;

            if (data != null)
            {
                result = new MS_Beneficiarios_SuscripcionPagingModel
                {
                    MS_Beneficiarios_Suscripcions =
                        data.Select(m => new Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion
                {
                    Folio = m.MS_Beneficiarios_Suscripcion_Folio
                    ,Folio_Planes_de_Suscripcion = m.MS_Beneficiarios_Suscripcion_Folio_Planes_de_Suscripcion
                    ,Beneficiario = m.MS_Beneficiarios_Suscripcion_Beneficiario
                    ,Beneficiario_Tipo_Paciente = new Core.Classes.Tipo_Paciente.Tipo_Paciente() { Clave = m.MS_Beneficiarios_Suscripcion_Beneficiario.GetValueOrDefault(), Descripcion = m.MS_Beneficiarios_Suscripcion_Beneficiario_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Beneficiarios_SuscripcionRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion>("sp_GetMS_Beneficiarios_Suscripcion", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_Beneficiarios_Suscripcion>("sp_DelMS_Beneficiarios_Suscripcion", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Planes_de_Suscripcion = _dataProvider.GetParameter();
                padreFolio_Planes_de_Suscripcion.ParameterName = "Folio_Planes_de_Suscripcion";
                padreFolio_Planes_de_Suscripcion.DbType = DbType.Int32;
                padreFolio_Planes_de_Suscripcion.Value = (object)entity.Folio_Planes_de_Suscripcion ?? DBNull.Value;
                var padreBeneficiario = _dataProvider.GetParameter();
                padreBeneficiario.ParameterName = "Beneficiario";
                padreBeneficiario.DbType = DbType.Int32;
                padreBeneficiario.Value = (object)entity.Beneficiario ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_Beneficiarios_Suscripcion>("sp_InsMS_Beneficiarios_Suscripcion" , padreFolio_Planes_de_Suscripcion
, padreBeneficiario
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

        public int Update(Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Planes_de_Suscripcion = _dataProvider.GetParameter();
                paramUpdFolio_Planes_de_Suscripcion.ParameterName = "Folio_Planes_de_Suscripcion";
                paramUpdFolio_Planes_de_Suscripcion.DbType = DbType.Int32;
                paramUpdFolio_Planes_de_Suscripcion.Value = (object)entity.Folio_Planes_de_Suscripcion ?? DBNull.Value;
                var paramUpdBeneficiario = _dataProvider.GetParameter();
                paramUpdBeneficiario.ParameterName = "Beneficiario";
                paramUpdBeneficiario.DbType = DbType.Int32;
                paramUpdBeneficiario.Value = (object)entity.Beneficiario ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Beneficiarios_Suscripcion>("sp_UpdMS_Beneficiarios_Suscripcion" , paramUpdFolio , paramUpdFolio_Planes_de_Suscripcion , paramUpdBeneficiario ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_Beneficiarios_Suscripcion.MS_Beneficiarios_Suscripcion MS_Beneficiarios_SuscripcionDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Planes_de_Suscripcion = _dataProvider.GetParameter();
                paramUpdFolio_Planes_de_Suscripcion.ParameterName = "Folio_Planes_de_Suscripcion";
                paramUpdFolio_Planes_de_Suscripcion.DbType = DbType.Int32;
                paramUpdFolio_Planes_de_Suscripcion.Value = (object)entity.Folio_Planes_de_Suscripcion ?? DBNull.Value;
		var paramUpdBeneficiario = _dataProvider.GetParameter();
                paramUpdBeneficiario.ParameterName = "Beneficiario";
                paramUpdBeneficiario.DbType = DbType.Int32;
                paramUpdBeneficiario.Value = (object)entity.Beneficiario ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_Beneficiarios_Suscripcion>("sp_UpdMS_Beneficiarios_Suscripcion" , paramUpdFolio , paramUpdFolio_Planes_de_Suscripcion , paramUpdBeneficiario ).FirstOrDefault();

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

