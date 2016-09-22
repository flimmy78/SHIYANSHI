using System;
using System.Collections.Generic;
using Langben.DAL;
namespace Langben.IBLL
{
    public interface ICOMPANYHander
    {
        List<COMPANY> GetCOMPANY(string CATEGORY);
    }
}

