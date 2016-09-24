//---------------------------------
//检测项目单位
var DanWeiDDLHtmlArray = Array;
DanWeiDDLHtmlArray = [
    {
        Code: 'DianLiu',
        Remark: '电流单位',
        Value: "<select class=\"my-combox\" style=\"width:50px; height:25px\">" +
                "<option value=\"A\">A</option> " +
                 "<option value=\"KA\">KA</option>" +
                 "<option value=\"mA\">mA</option>  " +
                 "<option value=\"μA\">μA</option>" +
                 "<option value=\"nA\">nA</option> " +
                 "<option value=\"pA\">pA</option> " +
                "</select>"
    },
        {
            Code: 'DianYa',
            Remark: '电压单位',
            Value: "<select class=\"my-combox\" style=\"width:50px; height:25px\">" +
                    "<option value=\"V\">V</option> " +
                    "<option value=\"MV\">MV</option>" +
                    "<option value=\"KV\">KV</option>  " +
                    "<option value=\"mV\">mV</option>" +
                    "<option value=\"μV\">μV</option> " +
                   "</select>"
        }]

//检测项控制属性
var RuleAttributeArray = new Array;
RuleAttributeArray = [
    {
        RuleID: '38-1987_2',//检测项编号
        Remark: 'JJG(航天) 38-1987 直流标准电流源检定规程,直流电流输出',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示(show:显示，hidden:不显示)
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动((变更项名称1)|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2)
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '(RANGE_UNIT)|OUTPUT_VALUE_UNIT,ACTUAL_OUTPUT_VALUE_UNIT',
                //检测项属性单位下拉框选项(单位类型1|(检测项属性单位名称1),(检测项属性单位名称2);单位类型2|(检测项属性单位名称1),(检测项属性单位名称2))
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|(RANGE_UNIT:量程),(OUTPUT_VALUE_UNIT:输出示值),(ACTUAL_OUTPUT_VALUE_UNIT：输出实际值);DianYa|(READ_VALUE_UNIT:读数值)',
                DanWeiHtmlDDL: 'DianLiu|(RANGE_UNIT),(OUTPUT_VALUE_UNIT),(ACTUAL_OUTPUT_VALUE_UNIT);DianYa|(READ_VALUE_UNIT)',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: 'READ_VALUE,ACTUAL_OUTPUT_VALUE,RELATIVE_ERROR,UNCERTAINTY_DEGREE,REMARK,CONCLUSION'
            }]
    }
];

//根据检测项ID获取控制信息
//RuleID:检测项目ID
function GetRuleAttributeByRuleID(RuleID) {
    var Result = null;
    if (RuleID == null || RuleID.trim() == "" ) {
        return null;
    }
    $.each(RuleAttributeArray, function (i, item) {
        if (item == null || item.RuleID != RuleID) {
            return true;
        }
        Result = item;
        return false;

    });
    return Result;
}

//检测项单位联动下拉框联动
//obj:下拉框控件
//LianDongDanWeiDDLAttribute:检测项单位联动下拉框联动控件信息
function LianDongDanWeiDDL(obj, LianDongDanWeiDDLAttribute) {
    if (obj == null || LianDongDanWeiDDLAttribute == null || LianDongDanWeiDDLAttribute.trim() == "")
    {
        return;
    }
    var id = obj.id.replace(obj.name, "") + "_";//_表编号_量程编号_  
    debugger
    var ddlArray = LianDongDanWeiDDLAttribute.split(';');
    $.each(ddlArray, function (i, item) {
        var biangeng="("+obj.name+")|";
        if(item==null || item.trim()=="" || item.indexOf(biangeng)<0 )
        {
            return true;
        }
        var liandongs=item.replace(biangeng, "").split(',');
        if(liandongs==null || liandongs.length<=0)
        {
            return true;
        }        
        $.each(liandongs, function (i, item_LianDong) {
            if (item_LianDong == null || item_LianDong.trim() == "") {
                return true;
            }
            $("select[name=" + item_LianDong.trim() + "]").each(function (a, b) {
                if (b.id.indexOf(id) >= 0) {
                    b.value = obj.value;
                }
            });

        });
       
    }); 

}


//获取下拉框单位html
//RuleAttribute:检测项属性
//ddlName:检查项中的属性控件名称
//DanWeiCode:单位代码（如果有值直接取，RuleAttribute、ddlName失效)
function GetDanWeiDDLHtml(RuleAttribute,ddlName, DanWeiCode) {
    var Result = null;

    if (DanWeiCode != null && DanWeiCode.trim() != "") {//如果有有单位代码直接取，RuleAttribute、ddlName失效
        $.each(DanWeiDDLHtmlArray, function (i, item) {
            if (item == null || item.Code != Code) {
                return true;
            }
            Result = item.Value;
            return false;
        });
        return Result;
    }

    if (RuleAttribute == null || RuleAttribute.RuleID == null || RuleAttribute.RuleID.trim() == ""
    || RuleAttribute.Attributes == null || RuleAttribute.Attributes[0] == null
    || RuleAttribute.Attributes[0].DanWeiHtmlDDL == null || RuleAttribute.Attributes[0].DanWeiHtmlDDL.trim() == ""
    || ddlName == null || ddlName.trim() == "") {
        return null;
    }
    var ddlArray = RuleAttribute.Attributes[0].DanWeiHtmlDDL.split(';');
    var ddlNameNew = "(" + ddlName + ")"
    $.each(ddlArray, function (i, item) {
        if (item == null || item.trim() == "" || item.indexOf(ddlNameNew) < 0 || item.split('|').length<2) {
            return true;
        }
        var dw = item.split('|')[0];
        $.each(DanWeiDDLHtmlArray, function (j, danwei) {
            if (danwei == null || danwei.Code != dw) {
                return true;
            }
            Result = danwei.Value;
            return false;
        });
    });
    return Result;   
}

//设置TD的html
//RuleAttribute:检测项目属性
//rowspan合并单元格行数
//name(控件名称),
//id(控件id不包含name部分),
//txtVal(文本框值)
function SetTDHtml(RuleAttribute,rowspan, name, id, txtVal) {
    //debugger;
    var ddlName = name + "_UNIT";//下拉框名
    var ddlId = ddlName + "_" + id;//下拉框ID
    var id = name + "_" + id;//输入框id
    var ddlHtml = GetDanWeiDDLHtml(RuleAttribute,ddlName,null);//单位下拉框html

    var htmlString = [];
    id = name + "_" + id;
    htmlString.push("<td rowspan='" + rowspan + "' align=\"right\"> ");
    htmlString.push("<input class=\"my-textbox input-width\" value='" + txtVal + "' id='" + id + "' name='" + name + "' onblur='blurValue(this)'/>");
    if (ddlHtml != null && ddlHtml.trim() != "") {
        var LianDongDanWeiDDLAttribute = null;
        if (RuleAttribute.Attributes != null
            && RuleAttribute.Attributes[0] != null && RuleAttribute.Attributes[0].LianDongDanWeiDDL != null
            && RuleAttribute.Attributes[0].LianDongDanWeiDDL.trim() != "") {
            LianDongDanWeiDDLAttribute = RuleAttribute.Attributes[0].LianDongDanWeiDDL;
        }
        htmlString.push($(ddlHtml).attr("onchange", "LianDongDanWeiDDL(this,'" + LianDongDanWeiDDLAttribute + "')").attr("name", ddlName).attr("id", ddlId)[0].outerHTML);
    }
    htmlString.push("</td>");
    return htmlString.join("");


}

//清空不需要保存的数据
function ClearBuBaoCunShuJu(RuleAttribute) {
    
    if (RuleAttribute.Attributes != null
            && RuleAttribute.Attributes[0] != null && RuleAttribute.Attributes[0].BuBaoCunShuJu != null
            && RuleAttribute.Attributes[0].BuBaoCunShuJu.trim() != "") {
        
        var BuBaoCunShuJuAttribute = RuleAttribute.Attributes[0].BuBaoCunShuJu.split(',');
        $.each(BuBaoCunShuJuAttribute, function (i, item) {
            if (item == null || item.trim()=="") {
                return true;
            }
            $("input[name="+item+"]").each(function (a, b) {
                $(b).val("");
            });            
        });
    }

}
//---------------------------------



