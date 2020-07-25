using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Secuencia_de_Ejercicios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Secuencia_de_EjerciciosService : IDetalle_Secuencia_de_EjerciciosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios> _Detalle_Secuencia_de_EjerciciosRepository;
        #endregion

        #region Ctor
        public Detalle_Secuencia_de_EjerciciosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios> Detalle_Secuencia_de_EjerciciosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Secuencia_de_EjerciciosRepository = Detalle_Secuencia_de_EjerciciosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Secuencia_de_EjerciciosRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Secuencia_de_EjerciciosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Secuencia_de_EjerciciosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Secuencia_de_EjerciciosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Secuencia_de_EjerciciosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_EjerciciosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Secuencia_de_EjerciciosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Secuencia_de_EjerciciosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Secuencia_de_EjerciciosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios entity, Spartane.Core.Domain.User.GlobalData Detalle_Secuencia_de_EjerciciosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios.Detalle_Secuencia_de_Ejercicios entity, Spartane.Core.Domain.User.GlobalData Detalle_Secuencia_de_EjerciciosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

