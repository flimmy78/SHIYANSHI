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
  
 */
                    var length = 0;
                    var split = paras.ShuChuShiJiZhi.Split('.');
                    if (split.Length > 1)
                    {
                        length = split[1].Length;//备注：n =【显示值 +】的小数位数
                    }

                    var ui = Math.Pow(10, -length) / 2 / Math.Sqrt(3); //被试设备分辨力ui = (10 - n / 2) /√3
                    // 最大允许误差ui=(指标1*10-6*ABS【显示值+】+指标2)/2，备注指标2的单位要换算成和【显示值+】单位一致
                    UNCERTAINTYTABLE d = GetUNCERTAINTYTABLE(paras, data);
                    var uiMax = (Convert.ToDouble(d.INDEX1) * Math.Pow(10, -6) * Math.Abs(Convert.ToDouble(paras.ShuChuShiJiZhi))
                        + Convert.ToDouble(d.INDEX2)) * Math.Pow(10, DanWeiHuanSuan(d.INDEX2UNIT, paras.ShuChuShiJiZhiDanWei)) / 2;

                    // 算法=((被试设备分辨力ui)^2+(最大允许误差ui)^2)^0.5*k，小数位数要与【显示值+】位数一致	
                    return Math.Pow((Math.Pow(ui, 2) + Math.Pow(uiMax, 2)), 0.5) * Convert.ToDouble(paras.K);
                case "9":
                    /*																																	
每行算一个不确定度																																						
根据输出示值判定应该取的量程范围内的指标，一个量程内取指标肯定参考指标表一个量程内的																																						
算法=((被试设备分辨力ui)^2+(最大允许误差ui)^2)^0.5*k，小数位数要与【输出实际值】位数一致																																						
被试设备分辨力ui=(10-n/2)/√3  备注：n=【输出实际值】的小数位数																																						
最大允许误差ui=(指标1*10-6*ABS【输出实际值】+指标2*10-6*量程)/2																																						
																																						
例如第一个行不确定度U(k=2)=											0.0001 				V																							
公式为：((10^(-4)/2/SQRT(3))^2+((3*10^(-6)*ABS(S16)+0.2*10^(-6)*20)/2)^2)^0.5*2			
 */
                    var length9 = 0;
                    var split9 = paras.ShuChuShiJiZhi.Split('.');
                    if (split9.Length > 1)
                    {
                        length9 = split9[1].Length;//备注：n =【显示值 +】的小数位数
                    }

                    var ui9 = Math.Pow(10, -length9) / 2 / Math.Sqrt(3); //被试设备分辨力ui = (10 - n / 2) /√3

                    UNCERTAINTYTABLE d9 = GetUNCERTAINTYTABLE(paras, data);
                    var uiMax9 = (Convert.ToDouble(d9.INDEX1) * Math.Pow(10, -6) * Math.Abs(Convert.ToDouble(paras.ShuChuShiJiZhi))
                        + Convert.ToDouble(d9.INDEX2) * Math.Pow(10, -6) * Convert.ToDouble(d9.ENDRANGESCOPE)) / 2;

                    // 算法=((被试设备分辨力ui)^2+(最大允许误差ui)^2)^0.5*k，小数位数要与【显示值+】位数一致	
                    return Math.Pow((Math.Pow(ui9, 2) + Math.Pow(uiMax9, 2)), 0.5) * Convert.ToDouble(paras.K);

                case "5":
                    /*																																	
算法=((被试设备分辨力ui)^2+(最大允许误差ui)^2)^0.5*k，小数位数要与【显示值】位数一致
被试设备分辨力ui=(10-n/2)/√3  备注：n=【显示值】的小数位数
最大允许误差ui=(指标1*10-6*ABS【显示值】+指标2)/2,备注指标2为0		
 */
                    var length5 = 0;
                    var split5 = paras.ShuChuShiJiZhi.Split('.');
                    if (split5.Length > 1)
                    {
                        length5 = split5[1].Length;//备注：n =【显示值 +】的小数位数
                    }

                    var ui5 = Math.Pow(10, -length5) / 2 / Math.Sqrt(3); //被试设备分辨力ui = (10 - n / 2) /√3

                    UNCERTAINTYTABLE d5 = GetUNCERTAINTYTABLE(paras, data);
                    var uiMax5 = (Convert.ToDouble(d5.INDEX1) * Math.Pow(10, -6) * Math.Abs(Convert.ToDouble(paras.ShuChuShiJiZhi))
                        + 0) / 2;

                    // 算法=((被试设备分辨力ui)^2+(最大允许误差ui)^2)^0.5*k，小数位数要与【显示值+】位数一致	
                    return Math.Pow((Math.Pow(ui5, 2) + Math.Pow(uiMax5, 2)), 0.5) * Convert.ToDouble(paras.K);
                case "6":
                    /*																																	
2、算法，分两种情况  
2.1、如有没有使用变换器参与运算：((被试设备分辨力ui)^2+(最大允许误差ui)^2)^0.5*k,小数位数要与【输出实际值】位数一致  
  如果没有使用变换器，参考8508A交流电流并结合当前量程取指标值
2.2、如有变换器参与运算：((被试设备分辨力ui)^2+(最大允许误差ui)^2+（变换器指标ui)^2)^0.5*k,小数位数要与【输出实际值】位数一致  
  如果有变换器，那么参考8508A交流电压，永远取2V量程档的指标85、10
被试设备分辨力ui=(10-n/2)/√3  备注：n=【输出实际值】的小数位数  
最大允许误差ui=(指标1*10-6*ABS【输出实际值】+指标2*10-6*量程)/2  
变换器指标ui=变换器指标/2，备注：标准电阻指标为0.00005 	
 */
                    var length6 = 0;
                    var split6 = paras.ShuChuShiJiZhi.Split('.');
                    if (split6.Length > 1)
                    {
                        length6 = split6[1].Length;//备注：n =【显示值 +】的小数位数
                    }

                    var ui6 = Math.Pow(10, -length6) / 2 / Math.Sqrt(3); //被试设备分辨力ui = (10 - n / 2) /√3

                    UNCERTAINTYTABLE d6 = GetUNCERTAINTYTABLE(paras, data);
                    var uiMax6 = (Convert.ToDouble(d6.INDEX1) * Math.Pow(10, -6) * Math.Abs(Convert.ToDouble(paras.ShuChuShiJiZhi))
                        + Convert.ToDouble(d6.INDEX2) * Math.Pow(10, -6) * Convert.ToDouble(d6.ENDRANGESCOPE)) / 2;

                    if (paras.XuanYongDianZu == "是")
                    {
                        return Math.Pow((Math.Pow(ui6, 2) + Math.Pow(uiMax6, 2) + Math.Pow(0.00005, 2)), 0.5) * Convert.ToDouble(paras.K);

                    }
                    else
                    {
                        return Math.Pow((Math.Pow(ui6, 2) + Math.Pow(uiMax6, 2)), 0.5) * Convert.ToDouble(paras.K);
                    }

                case "8":
                    /*																																	
1、每行算一个不确定度，根据输出示值判断应该取自哪个量程范围内的指标，一个量程内取指标肯定参考指标表一个量程内的																																
2、算法，分两种情况																																
2.1、如有无选用电阻参与运算：((被试设备分辨力ui)^2+(最大允许误差ui)^2)^0.5*k,小数位数要与【输出实际值】位数一致																																
		如果无选用电阻，参考8508A直流电流并结合当前量程取指标值																														
2.2、如有有选用电阻参与运算：((被试设备分辨力ui)^2+(最大允许误差ui)^2+（标准电阻指标ui)^2)^0.5*k,小数位数要与【输出实际值】位数一致																																
		如果有选用电阻，那么参考8508A直流电压，并判定应该取的量程段的指标值																														
被试设备分辨力ui=(10-n/2)/√3  备注：n=【输出实际值】的小数位数																																
最大允许误差ui=(指标1*10-6*ABS【输出实际值】+指标2*10-6*量程)/2																																
标准电阻指标ui=标准电阻/2，备注：如果选用电阻阻值为0.01，那么标准电阻指标为0.00001，如果为0.001，那么标准电阻指标为0.0001，以此类推																																
																																
例如第一个量程有选用电阻参与运算，第一个行不确定度U(k=2)=																				0.001 				mA								
公式为：((10^(-3)/2/SQRT(3))^2+((3.0*10^(-6)*ABS(AD36)+0.2*10^(-6)*2)/2)^2+(0.00001/2)^2)^0.5*2																																
																																
例如第二个量程无选用电阻参与运算，第一个行不确定度U(k=2)=																				0.003 				μA								
公式为：((10^(-3)/2/SQRT(3))^2+((12*10^(-6)*ABS(AD36)+2*10^(-6)*200)/2)^2)^0.5*2																																

 */
                    var length8 = 0;
                    var split8 = paras.ShuChuShiJiZhi.Split('.');
                    if (split8.Length > 1)
                    {
                        length8 = split8[1].Length;//备注：n =【显示值 +】的小数位数
                    }

                    var ui8 = Math.Pow(10, -length8) / 2 / Math.Sqrt(3); //被试设备分辨力ui = (10 - n / 2) /√3

                    UNCERTAINTYTABLE d8 = GetUNCERTAINTYTABLE(paras, data);
                    var uiMax8 = (Convert.ToDouble(d8.INDEX1) * Math.Pow(10, -6) * Math.Abs(Convert.ToDouble(paras.ShuChuShiJiZhi))
                        + Convert.ToDouble(d8.INDEX2) * Math.Pow(10, -6) * Convert.ToDouble(d8.ENDRANGESCOPE)) / 2;

                    if (!string.IsNullOrWhiteSpace(paras.XuanYongDianZu))
                    {

                        return Math.Pow((Math.Pow(ui8, 2) + Math.Pow(uiMax8, 2) + Math.Pow(0.0000001/Convert.ToDouble( paras.XuanYongDianZu), 2)), 0.5) * Convert.ToDouble(paras.K);

                    }
                    else
                    {
                        return Math.Pow((Math.Pow(ui8, 2) + Math.Pow(uiMax8, 2)), 0.5) * Convert.ToDouble(paras.K);
                    }


                default:
                    break;
            }

            return result;

        }
        public static UNCERTAINTYTABLE GetUNCERTAINTYTABLE(BuQueDingBuInput paras, List<UNCERTAINTYTABLE> data)
        {
            var liangcheng = DanWei(paras.ShuChuShiZhi, paras.ShuChuShiJiZhiDanWei);
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
                    "<select class=\"my-combobox\" name=\"DianLiu\" style=\"width:50px; \">" +
                "<option value=\"A\">A</option> " +
                 "<option value=\"kA\">kA</option>" +
                 "<option value=\"mA\">mA</option>  " +
                 "<option value=\"μA\">μA</option>" +
                 "<option value=\"nA\">nA</option> " +
                 "<option value=\"pA\">pA</option> " +
                "</select>"
                 "<option value=\"Hz\">Hz</option> " +
                    "<option value=\"kHz\">kHz</option>" +
                    "<option value=\"MHz\">MHz</option>  " +
                    "<option value=\"GHz\">GHz</option>  " +
                1MA（兆安）=1000kA（千安）=1000000A（安） 
1A（安）=1000mA（毫安）=1000000μA（微安）
nA是纳安等于0.001微安，pA 皮安，就是0.000001微安 
1nA=0.001微安，1pA=0.000001微安 
                   */
            switch (danwei)
            {
                case "Hz":
                    return Convert.ToDouble(result);
                case "kHz":
                    return Convert.ToDouble(result) * 1000;
                case "MHz":
                    return Convert.ToDouble(result) * 1000 * 1000;
                case "GHz":
                    return Convert.ToDouble(result) * 1000 * 1000 * 1000;
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
                case "pA":
                    return Convert.ToDouble(result) * 0.001 * 0.001;
                case "nA":
                    return Convert.ToDouble(result) * 0.001;
                case "μA":
                    return Convert.ToDouble(result);
                case "mA":
                    return Convert.ToDouble(result) * 1000;
                case "A":
                    return Convert.ToDouble(result) * 1000 * 1000;
                case "kA":
                    return Convert.ToDouble(result) * 1000 * 1000 * 1000;
                case "MA":
                    return Convert.ToDouble(result) * 1000 * 1000 * 1000 * 1000;
                default:
                    break;
            }
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yuan">指标表里面的（数据库）</param>
        /// <param name="mubiao">数据录入页面</param>
        /// <returns></returns>
        public static double DanWeiHuanSuan(string yuan, string mubiao)
        {
            /*

                1MA（兆安）=1000kA（千安）=1000000A（安） 
1A（安）=1000mA（毫安）=1000000μA（微安）
nA是纳安等于0.001微安，pA 皮安，就是0.000001微安 
1nA=0.001微安，1pA=0.000001微安 
                   */
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("μV", 1);
            dic.Add("mV", 2);
            dic.Add("V", 3);
            dic.Add("KV", 4);
            dic.Add("MV", 5);
            dic.Add("pA", 6);
            dic.Add("nA", 7);
            dic.Add("μA", 8);
            dic.Add("mA", 9); dic.Add("A", 10); dic.Add("kA", 11); dic.Add("MA", 12);
            var data = dic[yuan] - dic[mubiao];
            if (data == 0)
            {
                return 0;
            }
            else
            {
                return Math.Pow(10, data * 3);
            }

            return 0;
        }
    }

}
