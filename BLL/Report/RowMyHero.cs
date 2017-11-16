using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.Report
{
    public class RowMyHero
    {
        public int CurrentMyRow { get; set; }
        public float CurrentHeight { get; set; }
       // public bool IsBreak { get; set; }
        public int I { get; set; }
        public   float Total { get; set; }
        public float HeightInPoints { get; set; }
    }
}
