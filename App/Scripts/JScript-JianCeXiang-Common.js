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
                LianDongDanWeiDDL: '(RANGE_UNIT)|OUTPUT_VALUE_UNIT,ACTUAL_OUTPUT_VALUE_UNIT,UNCERTAINTY_DEGREE_UNIT;(OUTPUT_VALUE_UNIT)|ACTUAL_OUTPUT_VALUE_UNIT',
                //检测项属性单位下拉框选项(单位类型1|(检测项属性单位名称1),(检测项属性单位名称2);单位类型2|(检测项属性单位名称1),(检测项属性单位名称2))
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|(RANGE_UNIT:量程),(OUTPUT_VALUE_UNIT:输出示值),(ACTUAL_OUTPUT_VALUE_UNIT：输出实际值);DianYa|(READ_VALUE_UNIT:读数值)',
                DanWeiHtmlDDL: 'DianLiu|(RANGE_UNIT),(OUTPUT_VALUE_UNIT),(ACTUAL_OUTPUT_VALUE_UNIT),(UNCERTAINTY_DEGREE_UNIT);DianYa|(READ_VALUE_UNIT)',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: 'READ_VALUE,ACTUAL_OUTPUT_VALUE,RELATIVE_ERROR,UNCERTAINTY_DEGREE,REMARK,CONCLUSION',
                //添加量程自动计算赋值列(,检测项属性单位名称1,检测项属性单位名称2,)
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',OUTPUT_VALUE,'
            }]
    }
    ,
    {
        RuleID: '315-1983_2_1',//检测项编号
        Remark: '直流电压测量-正负极性-相对误差-单相',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示(show:显示，hidden:不显示)
                DuoTongDao: 'hidden',
                //检测项单位联动下拉框联动((变更项名称1)|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2)
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '(RANGE_UNIT)|OUTPUT_VALUE_UNIT,READ_VALUE_UNIT,UNCERTAINTY_DEGREE_UNIT',
                //检测项属性单位下拉框选项(单位类型1|(检测项属性单位名称1),(检测项属性单位名称2);单位类型2|(检测项属性单位名称1),(检测项属性单位名称2))
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|(RANGE_UNIT:量程),(OUTPUT_VALUE_UNIT:输出示值),(ACTUAL_OUTPUT_VALUE_UNIT：输出实际值);DianYa|(READ_VALUE_UNIT:读数值)',
                DanWeiHtmlDDL: 'DianYa|(RANGE_UNIT),(OUTPUT_VALUE_UNIT),(READ_VALUE_UNIT),(UNCERTAINTY_DEGREE_UNIT);',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列(,检测项属性单位名称1,检测项属性单位名称2,)
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',OUTPUT_VALUE,'
            }]
    },
    {
        RuleID: '315-1983_2_2',//检测项编号
        Remark: '直流电压测量-正负极性-相对误差-多通道',//检测项说明
        Attributes:
            [{
                //添加通道按钮是否显示(show:显示，hidden:不显示)
                DuoTongDao: 'show',
                //检测项单位联动下拉框联动((变更项名称1)|联动相名称1,联动相名称2;变更项名称2|联动相名称1,联动相名称2)
                //一个量程下的单位与对应的输出示值和输出实际值的单位联动，更改量程的单位输出示值和输出实际值单位自动变更
                LianDongDanWeiDDL: '(RANGE_UNIT)|OUTPUT_VALUE_UNIT,READ_VALUE_UNIT,UNCERTAINTY_DEGREE_UNIT',
                //检测项属性单位下拉框选项(单位类型1|(检测项属性单位名称1),(检测项属性单位名称2);单位类型2|(检测项属性单位名称1),(检测项属性单位名称2))
                //DianLiu:电流单位；DianYa:电压单位   
                //DianLiu|(RANGE_UNIT:量程),(OUTPUT_VALUE_UNIT:输出示值),(ACTUAL_OUTPUT_VALUE_UNIT：输出实际值);DianYa|(READ_VALUE_UNIT:读数值)',
                DanWeiHtmlDDL: 'DianYa|(RANGE_UNIT),(OUTPUT_VALUE_UNIT),(READ_VALUE_UNIT),(UNCERTAINTY_DEGREE_UNIT);',
                //READ_VALUE:读数值,ACTUAL_OUTPUT_VALUE:输出实际值,RELATIVE_ERROR:相对误差,UNCERTAINTY_DEGREE:不确定度,REMARK:注,CONCLUSION:结论
                BuBaoCunShuJu: '',
                //添加量程自动计算赋值列(,检测项属性单位名称1,检测项属性单位名称2,)
                //OUTPUT_VALUE：输出示值
                CalculateForAddLianCheng: ',OUTPUT_VALUE,'
            }]
    }
];
var RuleID = $("#hideRULEID").val();//检测项目ID
var RuleAttribute = GetRuleAttributeByRuleID(RuleID);
var $Tongdao_moban//模板
$(document).ready(function () {
    
    var hideHtml = $("#hideHTMLVALUE").val();
    if (hideHtml.trim() != "") {
        $("#divHtml").html("");
        $("#divHtml").append(hideHtml);
    }
    $Tongdao_moban = $("#tongdao_moban");
    if (hideHtml.trim() == "") {
        CreateTongDao();
    }
    BtnInit(RuleAttribute);
});

//创建通道
function CreateTongDao() {
    var tableIdx = $("#hideDangQianTongDao").val();//当前通道
    tableIdx++;
    var $tongdao = $Tongdao_moban.clone().appendTo($('#tongdao'));
    $tongdao.addClass('clone');
    $tongdao.css('display', '');
    $tongdao.attr('id', 'tongdao_' + tableIdx);
    $tongdao.find("#tbody_moban").attr('id', 'tbody_' + tableIdx);
    $tongdao.find("#K_moban").attr('id', 'K_' + tableIdx);
    //var tbIdx = tableIdx;
    $tongdao.find('#btnAddLiangCheng').attr("onclick", "$('#dlg').dialog('open');set(" + tableIdx + ");");
    $("#hideDangQianTongDao").val(tableIdx);
    $("#hideTongDaoShuLiang").val(tableIdx);

};
//设置当前操作通道
function set(tbodyIndex) {
    $("#hideDangQianTongDao").val(tbodyIndex);
}
//重置
function Reset() {
    //表格清空
    var hideTongDaoShuLiang = $("#hideTongDaoShuLiang").val();//通道数量
    for (var i = 1; i <= hideTongDaoShuLiang; i++) {
        var tongdao = "#tongdao_" + i;
        $(tongdao).html("");
    }
    $("#hideTongDaoShuLiang").val("0");
    CreateTongDao();
    //注
    $("#REMARK").val("");
    //结论
    $("#CONCLUSION").val("");
}

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
    var id = obj.id.replace(obj.name, "");
    if (id.split('_').length <= 3)
    {
        id = id + "_";//_表编号_量程编号_
    }
    
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
function GetDanWeiDDLHtml(ddlName, DanWeiCode) {
    var Result = null;

    if (DanWeiCode != null && DanWeiCode.trim() != "") {//如果有有单位代码直接取，RuleAttribute、ddlName失效
        $.each(DanWeiDDLHtmlArray, function (i, item) {
            if (item == null || item.Code != DanWeiCode) {
                return true;
            }
            Result = item.Value;
            return false;
        });
        return Result;
    }

    if (ddlName == null || ddlName.trim() == "")
    {
        return "";
    }
    var AttributeValue = GetAttributeValue("DanWeiHtmlDDL");
    if (AttributeValue == null || AttributeValue.trim()=="") {
        return "";
    }
    var ddlArray = AttributeValue.split(';');
    var ddlNameNew = "(" + ddlName + ")"
    ddlNameNew = ddlNameNew.toUpperCase();
    $.each(ddlArray, function (i, item) {
        if (item == null || item.trim() == "" || item.toUpperCase().indexOf(ddlNameNew) < 0 || item.split('|').length<2) {
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
//rowspan合并单元格行数SetTDHtml
//name(控件名称),
//id(控件id不包含name部分),
//rowidx:行号
//txtVal(文本框值)，如果有值并且行号为null直接赋值，否则走自动计算
function SetTDHtml(rowspan, name, id, rowidx, txtVal) {
   
    var ddlName = name + "_UNIT";//下拉框名
    var ddlId = ddlName + "_" + id;//下拉框ID
    var id = name + "_" + id;//输入框id
    var ddlHtml = GetDanWeiDDLHtml(ddlName, null);//单位下拉框html
    if ((txtVal == null || txtVal.trim() == "") && rowidx!=null) {
        txtVal = CalculateForAddLianCheng(rowidx, name);
    }
    var htmlString = [];   
    htmlString.push("<td rowspan='" + rowspan + "' align=\"right\"> ");
    htmlString.push("<input type='text' class=\"my-textbox input-width\" value='" + txtVal + "' id='" + id + "' name='" + name + "' onblur='blurValue(this)'/>");
    if (ddlHtml != null && ddlHtml.trim() != "") {        
        var AttributeValue = GetAttributeValue("LianDongDanWeiDDL");
        htmlString.push($(ddlHtml).attr("onchange", "LianDongDanWeiDDL(this,'" + AttributeValue + "')").attr("name", ddlName).attr("id", ddlId)[0].outerHTML);
    }
    htmlString.push("</td>");
    return htmlString.join("");


}
//根据属性名获取属性值
//RuleAttribute：检查项属性对象
//Name:属性名称
function GetAttributeValue(Name)
{
    if(RuleAttribute==null || Name==null || Name.trim()=="" ||
       RuleAttribute.Attributes == null || RuleAttribute.Attributes[0] == null || RuleAttribute.Attributes[0][Name] == null
       || RuleAttribute.Attributes[0][Name].trim() == ""
        )
    {
        return "";
    }
    return RuleAttribute.Attributes[0][Name].trim();
}
//清空不需要保存的数据
function ClearBuBaoCunShuJu() {
 
    var AttributeValue = GetAttributeValue("BuBaoCunShuJu");
    if (AttributeValue != null && AttributeValue.trim()!="") {
        var BuBaoCunShuJuAttribute = AttributeValue.split(',');
        $.each(BuBaoCunShuJuAttribute, function (i, item) {
            if (item == null || item.trim() == "") {
                return true;
            }
            $("input[name=" + item + "]").each(function (a, b) {
                $(b).val("");
            });
        });
    }

}

//添加量程时自动根据行号计算赋值数据
//RuleAttribute:检测项目属性，Rowidx：行号，objName:控件名称
function CalculateForAddLianCheng(Rowidx,objName) {
    if (RuleAttribute == null || Rowidx == null)
    {
        return "";
    }
    var AttributeValue = GetAttributeValue("CalculateForAddLianCheng");
    if (AttributeValue == null || AttributeValue.trim() == "")
    {
        return "";
    }
    if (AttributeValue.indexOf(objName) < 0)
    {
        return "";
    }
    var number = $("#txtNumber").val(); //量程
    var point = $("#txtPoint").val();     //检测点数   
    var pointLen = $("#txtPointLen").val(); //小数点位数
    var arry = new Array();
    if (point == 3) {
        //输入的检测点是3的时候，按照量程*100%，量程*60%，量程*10%作为默认标准值显示
        arry.push((number * 1).toFixed(pointLen));
        arry.push((number * 0.6).toFixed(pointLen));
        arry.push((number * 0.1).toFixed(pointLen));
    }
    if (point == 5) {
        //输入的检测点是5的时候，按照量程*100%，量程*80%，量程*60%，量程*40%，量程*20%作为默认标准值显示
        arry.push((number * 1).toFixed(pointLen));
        arry.push((number * 0.8).toFixed(pointLen));
        arry.push((number * 0.6).toFixed(pointLen));
        arry.push((number * 0.4).toFixed(pointLen));
        arry.push((number * 0.2).toFixed(pointLen));
    }
    if (point == 10) {
        //输入的检测点是10的时候，按照量程*100%，量程*90%，量程*80%，量程*70%，量程*60%，量程*50%，量程*40%，量程*30%，量程*20%，量程*10%，作为默认标准值显示
        arry.push((number * 1).toFixed(pointLen));
        arry.push((number * 0.9).toFixed(pointLen));
        arry.push((number * 0.8).toFixed(pointLen));
        arry.push((number * 0.7).toFixed(pointLen));
        arry.push((number * 0.6).toFixed(pointLen));
        arry.push((number * 0.5).toFixed(pointLen));
        arry.push((number * 0.4).toFixed(pointLen));
        arry.push((number * 0.3).toFixed(pointLen));
        arry.push((number * 0.2).toFixed(pointLen));
        arry.push((number * 0.1).toFixed(pointLen));
    }
    if (arry != null && arry.length > Rowidx)
    {
        return arry[Rowidx];
    }
    return "";
}

//优化保留两位小数 zh
Number.prototype.toFixed = function toFixed(s) {
    var IsFuShu = false;//判断是否是负数，负数单独处理
    var je = 0;
    if (this.toString().indexOf('-') >= 0) {
        IsFuShu = true;
        je = this.toString().replace('-', '');
    } else je = this;
    changenum = (parseInt(je * Math.pow(10, s) + 0.5) / Math.pow(10, s)).toString();   

    index = changenum.indexOf(".");
    if (index < 0 && s > 0) {
        changenum = changenum + ".";
        for (i = 0; i < s; i++) {
            changenum = changenum + "0";
        }

    } else {
        index = changenum.length - index;
        for (i = 0; i < (s - index) + 1; i++) {
            changenum = changenum + "0";
        }

    }
    var returnNum = changenum.toString();
    if (IsFuShu)
        returnNum = '-' + returnNum;
    return returnNum;
}
//显示隐藏添加通道按钮
function ShowOrHideDuoTongDao()
{    
    if(RuleAttribute==null)
    {
        $("#btnDuoTongDao").hide();        
    }
    else
    {
        var AttributeValue = GetAttributeValue("DuoTongDao");
        if(AttributeValue!=null && AttributeValue.trim().toUpperCase()=="SHOW")
        {
            $("#btnDuoTongDao").show();           
        }
        else
        {
            $("#btnDuoTongDao").hide();           
        }
    }
}
//按钮初始化（显示、隐藏）
function BtnInit()
{
    ShowOrHideDuoTongDao();
    var PREPARE_SCHEMEID = $("#hidePREPARE_SCHEMEID").val();
    if(PREPARE_SCHEMEID.trim()!="")//数据录入
    {
        $("#btnDuoTongDao").hide();
        //$("#btnSave").hide();
        $("#btnReset").hide();
        $("#btnAddLiangCheng").hide();
        //$("#btnSave_ITE").show();
        $("#btnReset_ITE").show();
    }
    else//方案设置
    {
        //$("#btnSave").show();
        $("#btnReset").show();
        //$("#btnSave_ITE").hide();
        $("#btnReset_ITE").hide();
    }
}
//数据验证
function CheckData() {
    return true;
}

function Save()
{
    if (!CheckData()) {
        return;
    }
    var PREPARE_SCHEMEID = $("#hidePREPARE_SCHEMEID").val();//预备方案ID
    if(PREPARE_SCHEMEID.trim()!="")//数据录入
    {
        Save_ShuJuLuRu();
    }
    else//方案设置
    {
        Save_FangAn();
    }
}
//保存数据录入
function Save_ShuJuLuRu()
{
    SetAllControlHtml();
    var ID = $("#hideITEID").val();//预备方案检查项ID
    var PREPARE_SCHEMEID = $("#hidePREPARE_SCHEMEID").val();//预备方案ID
    var RULEID = $("#hideRULEID").val();//检测项ID   
    var CONCLUSION = $("#CONCLUSION").val();//结论    
    var REMARK = $("#REMARK").val();//备注  
    var HTMLVALUE = encodeURI($("#divHtml").html());

    //获取空对象用于保存添加的信息
    $.ajax({
        type: 'post', //使用post方法访问后台
        dataType: "json", //返回json格式的数据
        url: '/QUALIFIED_UNQUALIFIED_TEST_ITE/Save', //要访问的后台地址      
        contentType: 'application/x-www-form-urlencoded; charset=utf-8', //指定编码方式        
        data: { 'ID': ID, 'PREPARE_SCHEMEID': PREPARE_SCHEMEID, 'RULEID': RULEID, 'CONCLUSION': CONCLUSION, 'REMARK': REMARK, 'HTMLVALUE': HTMLVALUE },
        beforeSend: function () {
            //InitAlertJS();
        },
        complete: function () {
        }, //AJAX请求完成时隐藏loading提示

        success: function (res) {//msg为返回的数据，在这里做数据绑定               
            if (res.Code == 1) {               
                 $("#hideITEID").val(res.Message);               
                var tdID = '#' + RULEID
                $(tdID, parent.document).html('已做');//修改检测项状态
                $.messager.alert('操作提示', "操作成功！", 'info');
            }
            else {
                $.messager.alert('操作提示', res.Message, 'info');
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.messager.alert('操作提示', '操作失败!' + errorThrown.messager, 'warning');
        }
    });
}

//保存方案设置
function Save_FangAn() {
    SetAllControlHtml();
    //if (!CheckData()) {
    //    return;
    //}
    //保存方案前需清空不需要数据
    //ClearBuBaoCunShuJu();
    var OldID = $("#hideID").val();
    var RULEID = $("#hideRULEID").val();
    var SCHEMEID = $("#hideSCHEMEID").val();   
    var HTMLVALUE = encodeURI($("#divHtml").html());

   
    //获取空对象用于保存添加的信息
    $.ajax({
        type: 'post', //使用post方法访问后台
        dataType: "json", //返回json格式的数据
        url: '/PROJECTTEMPLET/Save', //要访问的后台地址      
        contentType: 'application/x-www-form-urlencoded; charset=utf-8', //指定编码方式        
        data: { 'OldID': OldID, 'RULEID': RULEID, 'SCHEMEID': SCHEMEID, 'HTMLVALUE': HTMLVALUE },
        beforeSend: function () {
            //InitAlertJS();
        },
        complete: function () {
        }, //AJAX请求完成时隐藏loading提示

        success: function (res) {//msg为返回的数据，在这里做数据绑定               
            if (res.Code == 1) {
                if ($("#hideID").val().trim() == "") {
                    $("#hideID").val(res.Message);
                }
                $.messager.alert('操作提示', "操作成功！", 'info');
            }
            else {
                $.messager.alert('操作提示', res.Message, 'info');
            }
            if ($("#hideID").val() != "") {
                $("#UNDERTAKE_LABORATORYID").attr("disabled", "disabled");
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.messager.alert('操作提示', '操作失败!' + errorThrown.messager, 'warning');
        }
    });
}
//由于html无法获取value，重新给outerHTML赋值
function SetAllControlHtml()
{
    $("input[type='text']").each(function () {
        if (this.id != "")
        {
            var id = "#" + this.id;
            var outerHTML = this.outerHTML;
            var startIndex = outerHTML.indexOf(" value=");
            if (startIndex < 0)//没有初始化value
            {
                outerHTML = outerHTML.replace('>',' value="'+this.value+'" >')
            }
            else//初始化过value
            {
                var endIndex = outerHTML.indexOf('"', outerHTML.indexOf('"', startIndex) + 1);
                var length = endIndex - startIndex;
                var str = outerHTML.substring(startIndex, endIndex);
                outerHTML = outerHTML.replace(str, ' value="' + this.value + '" ')
            }            
            $(id).prop('outerHTML', outerHTML);
        }      
        
    });
    $("select").each(function () {        
        if (this.id != "") {
            var id = "#" + this.id;
            var outerHTML = this.outerHTML;
            outerHTML = outerHTML.replace(' selected="selected"', ' ')
            var oldValue = 'value="' + this.value + '"';            
            outerHTML = outerHTML.replace(' value="' + this.value + '"', ' value="' + this.value + '" selected="selected" ');
            $(id).prop('outerHTML', outerHTML);
        }
        
    });
}
//---------------------------------



