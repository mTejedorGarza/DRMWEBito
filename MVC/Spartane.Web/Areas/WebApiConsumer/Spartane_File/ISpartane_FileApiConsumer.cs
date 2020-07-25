﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartane_File
{
    public interface ISpartane_FileApiConsumer
    {
        void SetAuthHeader(string token);
       
        ApiResponse<Int64> Insert(Spartane.Core.Domain.Spartane_File.Spartane_File entity);
        ApiResponse<bool> Delete(long? Key);
        ApiResponse<Int64> Update(Spartane.Core.Domain.Spartane_File.Spartane_File entity);
        ApiResponse<Spartane.Core.Domain.Spartane_File.Spartane_File> GetByKey(long? Key);

    }
}
