using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Telefonos_de_Asistencia;
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
        private readonly IRepository<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> _Telefonos_de_AsistenciaRepository;
        #endregion

        #region Ctor
        public Telefonos_de_AsistenciaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> Telefonos_de_AsistenciaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Telefonos_de_AsistenciaRepository = Telefonos_de_AsistenciaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> SelAll(bool ConRelaciones)
        {
            return this._Telefonos_de_AsistenciaRepository.Table.ToList();
        }

        public IList<Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> SelAllComplete(bool ConRelaciones)
        {
            return this._Telefonos_de_AsistenciaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Telefonos_de_AsistenciaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Telefonos_de_AsistenciaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Telefonos_de_AsistenciaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_AsistenciaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Telefonos_de_AsistenciaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Telefonos_de_AsistenciaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Telefonos_de_AsistenciaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia entity, Spartane.Core.Domain.User.GlobalData Telefonos_de_AsistenciaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Telefonos_de_Asistencia.Telefonos_de_Asistencia entity, Spartane.Core.Domain.User.GlobalData Telefonos_de_AsistenciaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

