using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Langben.DAL;
using Langben.BLL;

namespace Langben.BLL.Report
{
    /// <summary>
    /// 自动计算不确定度公式
    /// </summary>
    public static partial class GongShi
    {
        public static double GetBuQueDingDu(BuQueDingBuInput paras, List<UNCERTAINTYTABLE> data, BuQueDingDu buQueDingDu)
        {
            double result = 0;

            switch (buQueDingDu.GongShi)
            {
                case "2":
                    /*																																		
 每行算一个不确定度																																		
 根据标准值判定所在范围的指标																																		
 算法=((被试设备分辨力ui)^2+(最大允许误差ui)^2)^0.5*k，小数位数要与【显示值+】位数一致																																		
 被试设备分辨力ui=(10-n/2)/√3  备注：n=【显示值+】的小数位数																																		
 最大允许误差ui=(指标1*10-6*ABS【显示值+】+指标2)/2，备注指标2的单位要换算成和【显示值+】单位一致																																		

 例如第一个行不确定度U(k=2)=									0.00004 					V																				
 公式为：((10^(-5)/2/SQRT(3))^2+((3.5*10^(-6)*ABS(S17)+2.5*10^(-6))/2)^2)^0.5*2																																		
 =((10^(-4)/2/SQRT(3))^2+((45*10^(-6)*ABS(W41)+50*10^(-6))/2)^2)^0.5*2
 */
                    var length = paras.ShuChuShiJiZhi.Length;//备注：n =【显示值 +】的小数位数
                    var ui = Math.Pow(10, -length) / 2 / Math.Sqrt(3); //被试设备分辨力ui = (10 - n / 2) /√3
                                                                       // 最大允许误差ui=(指标1*10-6*ABS【显示值+】+指标2)/2，备注指标2的单位要换算成和【显示值+】单位一致		

                    UNCERTAINTYTABLE d= GetUNCERTAINTYTABLE(paras,data);

                    var uiMax = (Convert.ToDouble(d.INDEX1) * 10 - 6 * Math.Abs(Convert.ToDouble(paras.ShuChuShiJiZhi)) + Convert.ToDouble(d.INDEX2)) / 2;

                    // 算法=((被试设备分辨力ui)^2+(最大允许误差ui)^2)^0.5*k，小数位数要与【显示值+】位数一致	
                    result = Math.Pow((Math.Pow(ui, 2) + Math.Pow(uiMax, 2)), 0.5) * 2;
                    break;
                default:
                    break;
            }

            return result;

        }
        public static UNCERTAINTYTABLE GetUNCERTAINTYTABLE(BuQueDingBuInput paras, List<UNCERTAINTYTABLE> data)
        {
            var liangcheng = DanWei(paras.ShuChuShiJiZhi, paras.ShuChuShiJiZhiDanWei);
            foreach (var f in data)
            {//THEUNIT
                if (f.THEUNIT == "<")
                {
                    if (f.ENDUNIT == "<")
                    {
                        if ((DanWei(f.THEUNIT, f.THERANGESCOPE) < liangcheng) && liangcheng < (DanWei(f.ENDUNIT, f.ENDRANGESCOPE)))
                        {
                            return f;
                        }
                    }
                    else if (f.ENDUNIT == "<=")
                    {
                        if ((DanWei(f.THEUNIT, f.THERANGESCOPE) < liangcheng) && liangcheng <= (DanWei(f.ENDUNIT, f.ENDRANGESCOPE)))
                        {
                            return f;
                        }
                    }

                }
                else if (f.THEUNIT == "<=")
                {
                    if (f.ENDUNIT == "<")
                    {
                        if ((DanWei(f.THEUNIT, f.THERANGESCOPE) <= liangcheng) && liangcheng < (DanWei(f.ENDUNIT, f.ENDRANGESCOPE)))
                        {
                            return f;
                        }
                    }
                    else if (f.ENDUNIT == "<=")
                    {
                        if ((DanWei(f.THEUNIT, f.THERANGESCOPE) <= liangcheng) && liangcheng <= (DanWei(f.ENDUNIT, f.ENDRANGESCOPE)))
                        {
                            return f;
                        }
                    }
                }
                else
                {
                    if (f.ENDUNIT == "<")
                    {
                        if (liangcheng < (DanWei(f.ENDUNIT, f.ENDRANGESCOPE)))
                        {
                            return f;
                        }
                    }
                    else if (f.ENDUNIT == "<=")
                    {
                        if (liangcheng <= (DanWei(f.ENDUNIT, f.ENDRANGESCOPE)))
                        {
                            return f;
                        }
                    }
                }


            }


            return null;
        }
        public static double DanWei(string result, string danwei)
        {
            /*
             "<select class=\"my-combobox\" name=\"DianYa\" style=\"width:50px; \">" +
                    "<option value=\"V\">V</option> " +
                    "<option value=\"MV\">MV</option>" +
                    "<option value=\"kV\">kV</option>  " +
                    "<option value=\"mV\">mV</option>" +
                    "<option value=\"μV\">μV</option> " +
                   "</select>"
                   */
            switch (danwei)
            {
                case "μV":
                    return Convert.ToDouble(result);
                case "mV":
                    return Convert.ToDouble(result) * 1000;
                case "V":
                    return Convert.ToDouble(result) * 1000 * 1000;
                case "KV":
                    return Convert.ToDouble(result) * 1000 * 1000 * 1000;
                case "MV":
                    return Convert.ToDouble(result) * 1000 * 1000 * 1000 * 1000;
                default:
                    break;
            }
            return 0;
        }
    }

}
