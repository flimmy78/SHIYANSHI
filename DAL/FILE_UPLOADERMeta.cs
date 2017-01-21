using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(FILE_UPLOADERMetadata))]//使用FILE_UPLOADERMetadata对FILE_UPLOADER进行数据验证
    public partial class FILE_UPLOADER 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "预备方案")]
        public string PREPARE_SCHEMEIDOld { get; set; }

        [Display(Name = "不合格类型")]
        public string UNQUALIFIEDTYPE { get; set; }

        /// <summary>
        /// 报告批准人行号
        /// </summary>
        public int Row_PiZhunRen
        {
            get
            {
                int index = -1;
                if (!string.IsNullOrWhiteSpace(REMARK) && REMARK.Trim() != "" && REMARK.Split('_').Length >= 2)
                {
                    try
                    {
                        index = Convert.ToInt32(REMARK.Split('|')[0].Split('_')[0]);
                    }
                    catch
                    {

                    }
                }
                return index;
            }
        }
        /// <summary>
        /// 报告核验员行号
        /// </summary>
        public int Row_HeYanYuan
        {
            get
            {
                int index = -1;
                if (!string.IsNullOrWhiteSpace(REMARK) && REMARK.Trim() != "" && REMARK.Split('|').Length >= 2)
                {
                    try
                    {
                        index = Convert.ToInt32(REMARK.Split('|')[1].Split('_')[0]);
                    }
                    catch
                    {

                    }
                }
                if (index == -1 && Row_PiZhunRen != -1)
                {
                    index = Row_PiZhunRen + 2;
                }
                return index;
            }
        }
        /// <summary>
        /// 报告检定员/校准员行号
        /// </summary>
        public int Row_JianDingYuan
        {
            get
            {
                int index = -1;
                if (!string.IsNullOrWhiteSpace(REMARK) && REMARK.Trim() != "" && REMARK.Split('|').Length >= 3 && REMARK.Split('|')[2].Split('_').Length >= 2)
                {
                    try
                    {
                        index = Convert.ToInt32(REMARK.Split('|')[2].Split('_')[0]);
                    }
                    catch
                    {

                    }
                }
                if (index == -1 && Row_HeYanYuan != -1)
                {
                    index = Row_HeYanYuan + 2;
                }
                return index;
            }
        }
        /// <summary>
        /// 报告批准人列号
        /// </summary>
        public int Col_PiZhunRen
        {
            get
            {
                int index = -1;
                if (!string.IsNullOrWhiteSpace(REMARK) && REMARK.Trim() != "" && REMARK.Split('_').Length >= 2 && REMARK.Split('|')[1].Split('_').Length >= 2)
                {
                    try
                    {
                        index = Convert.ToInt32(REMARK.Split('|')[0].Split('_')[1]);
                    }
                    catch
                    {

                    }
                }
                return index;
            }
        }
        /// <summary>
        /// 报告核验员列号
        /// </summary>
        public int Col_HeYanYuan
        {
            get
            {
                int index = -1;
                if (!string.IsNullOrWhiteSpace(REMARK) && REMARK.Trim() != "" && REMARK.Split('|').Length >= 2 && REMARK.Split('|')[1].Split('_').Length >= 2)
                {
                    try
                    {
                        index = Convert.ToInt32(REMARK.Split('|')[1].Split('_')[1]);
                    }
                    catch
                    {

                    }
                }
                if (index == -1 && Col_PiZhunRen != -1)
                {
                    index = Col_PiZhunRen + 2;
                }
                return index;
            }
        }
        /// <summary>
        /// 报告检定员/校准员列号
        /// </summary>
        public int Col_JianDingYuan
        {
            get
            {
                int index = -1;
                if (!string.IsNullOrWhiteSpace(REMARK) && REMARK.Trim() != "" && REMARK.Split('|').Length >= 3 && REMARK.Split('|')[2].Split('_').Length >= 2)
                {
                    try
                    {
                        index = Convert.ToInt32(REMARK.Split('|')[2].Split('_')[1]);
                    }
                    catch
                    {

                    }
                }
                if (index == -1 && Col_HeYanYuan != -1)
                {
                    index = Col_HeYanYuan + 2;
                }
                return index;
            }
        }

        #region 原始记录
        /// <summary>
        /// 原始记录检定员/校准员行号
        /// </summary>
        public int Row_JianDingYuan_YuanShiJiLu
        {
            get
            {
                int index = -1;
                if (!string.IsNullOrWhiteSpace(REMARK2) && REMARK2.Trim() != "" && REMARK2.Split('|')[0].Split('_').Length >= 2)
                {
                    try
                    {
                        index = Convert.ToInt32(REMARK2.Split('|')[0].Split('_')[0]);
                    }
                    catch
                    {

                    }
                }               
                return index;
            }
        }
        /// <summary>
        /// 原始记录检定员/校准员列号
        /// </summary>
        public int Col_JianDingYuan_YuanShiJiLu
        {
            get
            {
                int index = -1;
                if (!string.IsNullOrWhiteSpace(REMARK2) && REMARK2.Trim() != "" && REMARK2.Split('|')[0].Split('_').Length >= 2)
                {
                    try
                    {
                        index = Convert.ToInt32(REMARK2.Split('|')[0].Split('_')[1]);
                    }
                    catch
                    {

                    }
                }
                return index;
            }
        }
        /// <summary>
        /// 原始记录核验员行号
        /// </summary>
        public int Row_HeYanYuan_YuanShiJiLu
        {
            get
            {
                int index = -1;
                if (!string.IsNullOrWhiteSpace(REMARK2) && REMARK2.Trim() != "" && REMARK2.Split('|').Length >= 2 && REMARK2.Split('|')[1].Split('_').Length >= 2)
                {
                    try
                    {
                        index = Convert.ToInt32(REMARK2.Split('|')[1].Split('_')[0]);
                    }
                    catch
                    {

                    }
                }
                if (index == -1 && Row_JianDingYuan_YuanShiJiLu != -1)
                {
                    index = Row_JianDingYuan_YuanShiJiLu;
                }
                return index;
            }
        }
        /// <summary>
        /// 原始记录核验员列号
        /// </summary>
        public int Col_HeYanYuan_YuanShiJiLu
        {
            get
            {
                int index = -1;
                if (!string.IsNullOrWhiteSpace(REMARK2) && REMARK2.Trim() != "" && REMARK2.Split('|').Length >= 2 && REMARK2.Split('|')[1].Split('_').Length >= 2)
                {
                    try
                    {
                        index = Convert.ToInt32(REMARK2.Split('|')[1].Split('_')[1]);
                    }
                    catch
                    {

                    }
                }
                if (index == -1 && Col_JianDingYuan_YuanShiJiLu != -1)
                {
                    index = Col_JianDingYuan_YuanShiJiLu + 18;
                }
                return index;
            }
        }
        #endregion 
        #endregion

    }
    public partial class FILE_UPLOADERMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "名称", Order = 2)]
			public object NAME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "路径", Order = 3)]
			public object PATH { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "全路径", Order = 4)]
			public object FULLPATH { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "后缀", Order = 5)]
			public object SUFFIX { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "大小", Order = 6)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? SIZE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "备注", Order = 7)]
			public object REMARK { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "原始记录名称2", Order = 8)]
			public object NAME2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "原始记录路径2", Order = 9)]
			public object PATH2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "原始记录全路径2", Order = 10)]
			public object FULLPATH2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "原始记录后缀2", Order = 11)]
			public object SUFFIX2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "原始记录大小2", Order = 12)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? SIZE2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "原始记录备注2", Order = 13)]
			public object REMARK2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "原始记录状态2", Order = 14)]
			public object STATE2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 15)]
			public object STATE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 16)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 17)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "结论", Order = 18)]
			public object CONCLUSION { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "预备方案", Order = 19)]
			public object PREPARE_SCHEMEID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 20)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 21)]
			public object UPDATEPERSON { get; set; }


    }
}
 

