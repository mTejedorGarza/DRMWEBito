using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Configuracion_de_Notificaciones;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Configuracion_de_Notificaciones
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Configuracion_de_NotificacionesService : IConfiguracion_de_NotificacionesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> _Configuracion_de_NotificacionesRepository;
        #endregion

        #region Ctor
        public Configuracion_de_NotificacionesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> Configuracion_de_NotificacionesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Configuracion_de_NotificacionesRepository = Configuracion_de_NotificacionesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> SelAll(bool ConRelaciones)
        {
            return this._Configuracion_de_NotificacionesRepository.Table.ToList();
        }

        public IList<Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> SelAllComplete(bool ConRelaciones)
        {
            return this._Configuracion_de_NotificacionesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Configuracion_de_NotificacionesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Configuracion_de_NotificacionesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Configuracion_de_NotificacionesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_NotificacionesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Configuracion_de_NotificacionesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Configuracion_de_NotificacionesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Configuracion_de_NotificacionesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones entity, Spartane.Core.Domain.User.GlobalData Configuracion_de_NotificacionesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Configuracion_de_Notificaciones.Configuracion_de_Notificaciones entity, Spartane.Core.Domain.User.GlobalData Configuracion_de_NotificacionesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

