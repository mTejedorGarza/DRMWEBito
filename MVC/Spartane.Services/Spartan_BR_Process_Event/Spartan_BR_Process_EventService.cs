﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_BR_Process_Event;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Process_Event
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Process_EventService : ISpartan_BR_Process_EventService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event> _Spartan_BR_Process_EventRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Process_EventService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event> Spartan_BR_Process_EventRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Process_EventRepository = Spartan_BR_Process_EventRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event> SelAll(bool ConRelaciones)
        {
            return this._Spartan_BR_Process_EventRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_BR_Process_EventRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Process_EventRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Process_EventRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Process_EventRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_EventPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_BR_Process_EventPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Process_EventRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event GetByKey(short Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event result=null;
            return result;
        }

        public bool Delete(short Key, Spartane.Core.Domain.User.GlobalData Spartan_BR_Process_EventInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public short Insert(Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Process_EventInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }

        public short Update(Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Process_EventInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }
        #endregion
    }
}

