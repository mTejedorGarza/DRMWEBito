using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MS_Uso_del_Ejercicio;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Uso_del_Ejercicio
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Uso_del_EjercicioService : IMS_Uso_del_EjercicioService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> _MS_Uso_del_EjercicioRepository;
        #endregion

        #region Ctor
        public MS_Uso_del_EjercicioService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> MS_Uso_del_EjercicioRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Uso_del_EjercicioRepository = MS_Uso_del_EjercicioRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> SelAll(bool ConRelaciones)
        {
            return this._MS_Uso_del_EjercicioRepository.Table.ToList();
        }

        public IList<Core.Domain.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> SelAllComplete(bool ConRelaciones)
        {
            return this._MS_Uso_del_EjercicioRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Uso_del_EjercicioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Uso_del_EjercicioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Uso_del_EjercicioRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Uso_del_Ejercicio.MS_Uso_del_EjercicioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MS_Uso_del_EjercicioPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Uso_del_EjercicioRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MS_Uso_del_EjercicioInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio entity, Spartane.Core.Domain.User.GlobalData MS_Uso_del_EjercicioInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MS_Uso_del_Ejercicio.MS_Uso_del_Ejercicio entity, Spartane.Core.Domain.User.GlobalData MS_Uso_del_EjercicioInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

