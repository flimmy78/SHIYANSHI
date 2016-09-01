using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 附件 接口
    /// </summary>
    public partial interface IFILE_UPLOADERBLL
    {
 
        /// <summary>
        /// 根据PREPARE_SCHEMEIDId，获取所有附件数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        List<FILE_UPLOADER> GetByRefPREPARE_SCHEMEID(string id);

        
    
    }
}

