using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MS_Dificultad_Platillos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Dificultad_Platillos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Dificultad_PlatillosService : IMS_Dificultad_PlatillosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos> _MS_Dificultad_PlatillosRepository;
        #endregion

        #region Ctor
        public MS_Dificultad_PlatillosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos> MS_Dificultad_PlatillosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Dificultad_PlatillosRepository = MS_Dificultad_PlatillosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos> SelAll(bool ConRelaciones)
        {
            return this._MS_Dificultad_PlatillosRepository.Table.ToList();
        }

        public IList<Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos> SelAllComplete(bool ConRelaciones)
        {
            return this._MS_Dificultad_PlatillosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Dificultad_PlatillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Dificultad_PlatillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Dificultad_PlatillosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_PlatillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MS_Dificultad_PlatillosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Dificultad_PlatillosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MS_Dificultad_PlatillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos entity, Spartane.Core.Domain.User.GlobalData MS_Dificultad_PlatillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MS_Dificultad_Platillos.MS_Dificultad_Platillos entity, Spartane.Core.Domain.User.GlobalData MS_Dificultad_PlatillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

