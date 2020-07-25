using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tipo_de_Ejercicio_Rutina
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tipo_de_Ejercicio_RutinaService : ITipo_de_Ejercicio_RutinaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> _Tipo_de_Ejercicio_RutinaRepository;
        #endregion

        #region Ctor
        public Tipo_de_Ejercicio_RutinaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> Tipo_de_Ejercicio_RutinaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tipo_de_Ejercicio_RutinaRepository = Tipo_de_Ejercicio_RutinaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> SelAll(bool ConRelaciones)
        {
            return this._Tipo_de_Ejercicio_RutinaRepository.Table.ToList();
        }

        public IList<Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> SelAllComplete(bool ConRelaciones)
        {
            return this._Tipo_de_Ejercicio_RutinaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipo_de_Ejercicio_RutinaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tipo_de_Ejercicio_RutinaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipo_de_Ejercicio_RutinaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_RutinaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Tipo_de_Ejercicio_RutinaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tipo_de_Ejercicio_RutinaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Tipo_de_Ejercicio_RutinaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina entity, Spartane.Core.Domain.User.GlobalData Tipo_de_Ejercicio_RutinaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Tipo_de_Ejercicio_Rutina.Tipo_de_Ejercicio_Rutina entity, Spartane.Core.Domain.User.GlobalData Tipo_de_Ejercicio_RutinaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

