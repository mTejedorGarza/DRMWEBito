using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Rangos_Pediatria_por_Platillos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Rangos_Pediatria_por_Platillos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Rangos_Pediatria_por_PlatillosService : IRangos_Pediatria_por_PlatillosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> _Rangos_Pediatria_por_PlatillosRepository;
        #endregion

        #region Ctor
        public Rangos_Pediatria_por_PlatillosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> Rangos_Pediatria_por_PlatillosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Rangos_Pediatria_por_PlatillosRepository = Rangos_Pediatria_por_PlatillosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> SelAll(bool ConRelaciones)
        {
            return this._Rangos_Pediatria_por_PlatillosRepository.Table.ToList();
        }

        public IList<Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> SelAllComplete(bool ConRelaciones)
        {
            return this._Rangos_Pediatria_por_PlatillosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Rangos_Pediatria_por_PlatillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Rangos_Pediatria_por_PlatillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Rangos_Pediatria_por_PlatillosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_PlatillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Rangos_Pediatria_por_PlatillosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Rangos_Pediatria_por_PlatillosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Rangos_Pediatria_por_PlatillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos entity, Spartane.Core.Domain.User.GlobalData Rangos_Pediatria_por_PlatillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Rangos_Pediatria_por_Platillos.Rangos_Pediatria_por_Platillos entity, Spartane.Core.Domain.User.GlobalData Rangos_Pediatria_por_PlatillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

