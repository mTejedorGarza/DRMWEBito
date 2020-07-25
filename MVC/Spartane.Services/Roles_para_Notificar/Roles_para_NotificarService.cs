using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Roles_para_Notificar;
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
        private readonly IRepository<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar> _Roles_para_NotificarRepository;
        #endregion

        #region Ctor
        public Roles_para_NotificarService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar> Roles_para_NotificarRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Roles_para_NotificarRepository = Roles_para_NotificarRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar> SelAll(bool ConRelaciones)
        {
            return this._Roles_para_NotificarRepository.Table.ToList();
        }

        public IList<Core.Domain.Roles_para_Notificar.Roles_para_Notificar> SelAllComplete(bool ConRelaciones)
        {
            return this._Roles_para_NotificarRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Roles_para_NotificarRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Roles_para_NotificarRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Roles_para_NotificarRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Roles_para_Notificar.Roles_para_NotificarPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Roles_para_NotificarPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Roles_para_NotificarRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Roles_para_NotificarInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar entity, Spartane.Core.Domain.User.GlobalData Roles_para_NotificarInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Roles_para_Notificar.Roles_para_Notificar entity, Spartane.Core.Domain.User.GlobalData Roles_para_NotificarInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

