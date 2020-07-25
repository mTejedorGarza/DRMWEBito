using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Roles_para_Notificar;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Roles_para_Notificar
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Roles_para_NotificarService : IRoles_para_NotificarService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar> _Roles_para_NotificarRepository;
        #endregion

        #region Ctor
        public Roles_para_NotificarService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar> Roles_para_NotificarRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Roles_para_NotificarRepository = Roles_para_NotificarRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Roles_para_NotificarRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar>("sp_SelAllRoles_para_Notificar");
        }

        public IList<Core.Classes.Roles_para_Notificar.Roles_para_Notificar> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallRoles_para_Notificar_Complete>("sp_SelAllComplete_Roles_para_Notificar");
            return data.Select(m => new Core.Classes.Roles_para_Notificar.Roles_para_Notificar
            {
                Folio = m.Folio
                ,Folio_Configuracion_de_Notificaciones = m.Folio_Configuracion_de_Notificaciones
                ,Rol_Tipo_Paciente = new Core.Classes.Tipo_Paciente.Tipo_Paciente() { Clave = m.Rol.GetValueOrDefault(), Descripcion = m.Rol_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Roles_para_Notificar>("sp_ListSelCount_Roles_para_Notificar", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRoles_para_Notificar>("sp_ListSelAll_Roles_para_Notificar", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar
                {
                    Folio = m.Roles_para_Notificar_Folio,
                    Folio_Configuracion_de_Notificaciones = m.Roles_para_Notificar_Folio_Configuracion_de_Notificaciones,
                    Rol = m.Roles_para_Notificar_Rol,

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

        public IList<Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Roles_para_NotificarRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Roles_para_NotificarRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Roles_para_Notificar.Roles_para_NotificarPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRoles_para_Notificar>("sp_ListSelAll_Roles_para_Notificar", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Roles_para_NotificarPagingModel result = null;

            if (data != null)
            {
                result = new Roles_para_NotificarPagingModel
                {
                    Roles_para_Notificars =
                        data.Select(m => new Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar
                {
                    Folio = m.Roles_para_Notificar_Folio
                    ,Folio_Configuracion_de_Notificaciones = m.Roles_para_Notificar_Folio_Configuracion_de_Notificaciones
                    ,Rol = m.Roles_para_Notificar_Rol
                    ,Rol_Tipo_Paciente = new Core.Classes.Tipo_Paciente.Tipo_Paciente() { Clave = m.Roles_para_Notificar_Rol.GetValueOrDefault(), Descripcion = m.Roles_para_Notificar_Rol_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Roles_para_NotificarRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar>("sp_GetRoles_para_Notificar", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelRoles_para_Notificar>("sp_DelRoles_para_Notificar", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Configuracion_de_Notificaciones = _dataProvider.GetParameter();
                padreFolio_Configuracion_de_Notificaciones.ParameterName = "Folio_Configuracion_de_Notificaciones";
                padreFolio_Configuracion_de_Notificaciones.DbType = DbType.Int32;
                padreFolio_Configuracion_de_Notificaciones.Value = (object)entity.Folio_Configuracion_de_Notificaciones ?? DBNull.Value;
                var padreRol = _dataProvider.GetParameter();
                padreRol.ParameterName = "Rol";
                padreRol.DbType = DbType.Int32;
                padreRol.Value = (object)entity.Rol ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsRoles_para_Notificar>("sp_InsRoles_para_Notificar" , padreFolio_Configuracion_de_Notificaciones
, padreRol
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

        public int Update(Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Configuracion_de_Notificaciones = _dataProvider.GetParameter();
                paramUpdFolio_Configuracion_de_Notificaciones.ParameterName = "Folio_Configuracion_de_Notificaciones";
                paramUpdFolio_Configuracion_de_Notificaciones.DbType = DbType.Int32;
                paramUpdFolio_Configuracion_de_Notificaciones.Value = (object)entity.Folio_Configuracion_de_Notificaciones ?? DBNull.Value;
                var paramUpdRol = _dataProvider.GetParameter();
                paramUpdRol.ParameterName = "Rol";
                paramUpdRol.DbType = DbType.Int32;
                paramUpdRol.Value = (object)entity.Rol ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRoles_para_Notificar>("sp_UpdRoles_para_Notificar" , paramUpdFolio , paramUpdFolio_Configuracion_de_Notificaciones , paramUpdRol ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Roles_para_Notificar.Roles_para_Notificar Roles_para_NotificarDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Configuracion_de_Notificaciones = _dataProvider.GetParameter();
                paramUpdFolio_Configuracion_de_Notificaciones.ParameterName = "Folio_Configuracion_de_Notificaciones";
                paramUpdFolio_Configuracion_de_Notificaciones.DbType = DbType.Int32;
                paramUpdFolio_Configuracion_de_Notificaciones.Value = (object)entity.Folio_Configuracion_de_Notificaciones ?? DBNull.Value;
		var paramUpdRol = _dataProvider.GetParameter();
                paramUpdRol.ParameterName = "Rol";
                paramUpdRol.DbType = DbType.Int32;
                paramUpdRol.Value = (object)entity.Rol ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRoles_para_Notificar>("sp_UpdRoles_para_Notificar" , paramUpdFolio , paramUpdFolio_Configuracion_de_Notificaciones , paramUpdRol ).FirstOrDefault();

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

