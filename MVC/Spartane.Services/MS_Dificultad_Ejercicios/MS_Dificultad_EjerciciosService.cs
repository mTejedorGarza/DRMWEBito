using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MS_Dificultad_Ejercicios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Dificultad_Ejercicios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Dificultad_EjerciciosService : IMS_Dificultad_EjerciciosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MS_Dificultad_Ejercicios.MS_Dificultad_Ejercicios> _MS_Dificultad_EjerciciosRepository;
        #endregion

        #region Ctor
        public MS_Dificultad_EjerciciosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MS_Dificultad_Ejercicios.MS_Dificultad_Ejercicios> MS_Dificultad_EjerciciosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Dificultad_EjerciciosRepository = MS_Dificultad_EjerciciosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MS_Dificultad_Ejercicios.MS_Dificultad_Ejercicios> SelAll(bool ConRelaciones)
        {
            return this._MS_Dificultad_EjerciciosRepository.Table.ToList();
        }

        public IList<Core.Domain.MS_Dificultad_Ejercicios.MS_Dificultad_Ejercicios> SelAllComplete(bool ConRelaciones)
        {
            return this._MS_Dificultad_EjerciciosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MS_Dificultad_Ejercicios.MS_Dificultad_Ejercicios> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Dificultad_EjerciciosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Dificultad_Ejercicios.MS_Dificultad_Ejercicios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Dificultad_EjerciciosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Dificultad_Ejercicios.MS_Dificultad_Ejercicios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Dificultad_EjerciciosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Dificultad_Ejercicios.MS_Dificultad_EjerciciosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MS_Dificultad_EjerciciosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MS_Dificultad_Ejercicios.MS_Dificultad_Ejercicios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Dificultad_EjerciciosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Dificultad_Ejercicios.MS_Dificultad_Ejercicios GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MS_Dificultad_Ejercicios.MS_Dificultad_Ejercicios result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MS_Dificultad_EjerciciosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MS_Dificultad_Ejercicios.MS_Dificultad_Ejercicios entity, Spartane.Core.Domain.User.GlobalData MS_Dificultad_EjerciciosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MS_Dificultad_Ejercicios.MS_Dificultad_Ejercicios entity, Spartane.Core.Domain.User.GlobalData MS_Dificultad_EjerciciosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

