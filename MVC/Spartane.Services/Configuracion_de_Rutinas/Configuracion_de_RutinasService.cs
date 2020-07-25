using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Configuracion_de_Rutinas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Configuracion_de_Rutinas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Configuracion_de_RutinasService : IConfiguracion_de_RutinasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas> _Configuracion_de_RutinasRepository;
        #endregion

        #region Ctor
        public Configuracion_de_RutinasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas> Configuracion_de_RutinasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Configuracion_de_RutinasRepository = Configuracion_de_RutinasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas> SelAll(bool ConRelaciones)
        {
            return this._Configuracion_de_RutinasRepository.Table.ToList();
        }

        public IList<Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas> SelAllComplete(bool ConRelaciones)
        {
            return this._Configuracion_de_RutinasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Configuracion_de_RutinasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Configuracion_de_RutinasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Configuracion_de_RutinasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_RutinasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Configuracion_de_RutinasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Configuracion_de_RutinasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Configuracion_de_RutinasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas entity, Spartane.Core.Domain.User.GlobalData Configuracion_de_RutinasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Configuracion_de_Rutinas.Configuracion_de_Rutinas entity, Spartane.Core.Domain.User.GlobalData Configuracion_de_RutinasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

