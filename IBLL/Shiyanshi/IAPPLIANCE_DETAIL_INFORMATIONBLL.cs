using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 
    /// </summary>

    public partial interface IAPPLIANCE_DETAIL_INFORMATIONBLL
    {
        string SearchAutoComplete(string id,  string term);
    }
}

