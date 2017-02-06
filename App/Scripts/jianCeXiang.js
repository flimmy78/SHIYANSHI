
var RuleID = $("#hideRULEID").val();//检测项目ID
var RuleAttribute = GetRuleAttributeByRuleID(RuleID);
var JiSuanBuQueDingDuPara = GetJiSuanBuQueDingDuParaArray();//计算不确定参数信息
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
    if ($tongdao.html() == "undefined" || $tongdao.html() == undefined) {
        return;
    }
    var reg = new RegExp("_t_", "g");//g,表示全部替换。

    $tongdao.html($tongdao.html().replace(reg, '_' + tableIdx + '_'));

    $tongdao.addClass('clone mt10');
    $tongdao.css('display', '');
    $tongdao.attr('id', 'tongdao_' + tableIdx);
    $tongdao.find("#tbody_moban").attr('id', 'tbody_' + tableIdx);
    $tongdao.find("#K_moban").attr('id', 'K_' + tableIdx);

    $tongdao.find('#btnAddLiangCheng').attr("onclick", "set(" + tableIdx + ",this);");


    $("#hideDangQianTongDao").val(tableIdx);
    $("#hideTongDaoShuLiang").val(tableIdx);

};

//重置
function Reset() {
    //表格清空
    var hideTongDaoShuLiang = $("#hideTongDaoShuLiang").val();//通道数量
    for (var i = 1; i <= hideTongDaoShuLiang; i++) {
        var tongdao = "#tongdao_" + i;
        $(tongdao).remove(); //$(tongdao).html("");
    }
    $("#hideDangQianTongDao").val("0");//当前通道
    $("#hideTongDaoShuLiang").val("0");
    CreateTongDao();
    ////注
    //$("#REMARK").val("");
    ////结论
    //$("#CONCLUSION").val("");
}

//根据检测项ID获取控制信息
//RuleID:检测项目ID
function GetRuleAttributeByRuleID(RuleID) {
    var Result = null;
    if (RuleID == null || RuleID.trim() == "") {
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

    if (obj == null || LianDongDanWeiDDLAttribute == null || LianDongDanWeiDDLAttribute.trim() == "") {
        return;
    }
    var id = obj.id.replace(obj.name, "");
    var idarr = id.split('_');
    if (id.split('_').length <= 3) {
        id = id + "_";//_表编号_量程编号_
    } else {
        id = id.substring(0, id.lastIndexOf('_') + 1);//_表编号_量程编号_
    }

    var ddlArray = LianDongDanWeiDDLAttribute.split(';');
    $.each(ddlArray, function (i, item) {

        var biangeng = obj.name.split('_')[0] + "|";
        //if (item == null || item.trim() == "" || item.indexOf(biangeng) < 0) {
        //    return true;
        //}

        if (item == null || item.trim() == "") {
            return true;
        }
        else {
            // item = item + '_UNIT'
            if (item.indexOf(biangeng) < 0) {
                return true;
            }
        }
        var liandongs = item.replace(biangeng, "").split(',');
        if (liandongs == null || liandongs.length <= 0) {
            return true;
        }
        $.each(liandongs, function (i, item_LianDong) {

            if (item_LianDong == null || item_LianDong.trim() == "") {
                return true;
            }

            $("select[name=" + item_LianDong.trim() + "_UNIT]").each(function (a, b) {

                if (b.id.indexOf(id) >= 0) {
                    b.value = obj.value;
                }
            });

        });

    });

}
//联动自动计算不确定度
//触发事件控件
function LianDongBuQueDingDu(obj) {
    //只有在显示值或者输出实际值才触发不确定度自动计算
    if (JiSuanBuQueDingDuPara.Type == null || JiSuanBuQueDingDuPara.Type.trim() == "" || JiSuanBuQueDingDuPara.Type.trim() != "Z" || JiSuanBuQueDingDuPara.Name == "undefined"
        || obj == null || obj.name == "undefined" || obj.ID == "undefined" || (obj.name != JiSuanBuQueDingDuPara.ShuChuShiJiZhi && obj.name != JiSuanBuQueDingDuPara.ShuChuShiZhi && obj.name != JiSuanBuQueDingDuPara.PinLv)) {
        return;
    }

    var id = obj.id.replace(obj.name, "");
    //不确定度显示控件
    var ShowBuQueDingDuID = JiSuanBuQueDingDuPara.Name + id;
    var ShowBuQueDingDuObj = document.getElementById(ShowBuQueDingDuID);
    if (ShowBuQueDingDuObj == null) {
        return;
    }

    var tongDaoID = "";//通道编号
    var liangChengID = "";//量程编号
    var hangHaoID = "";//行号
    var ids = id.split("_");
    if (ids.length >= 4) {
        tongDaoID = ids[1];
        liangChengID = ids[2];
        hangHaoID = ids[3];

        //显示值属性名称或者输出实际值属性名称
        //var ShuChuShiJiZhi = obj.value;
        var ShuChuShiJiZhi = "";
        if (JiSuanBuQueDingDuPara.ShuChuShiJiZhi != null && JiSuanBuQueDingDuPara.ShuChuShiJiZhi.trim() != "" && JiSuanBuQueDingDuPara.ShuChuShiJiZhi != "undefined") {
            var ShuChuShiJiZhiID = JiSuanBuQueDingDuPara.ShuChuShiJiZhi + id;
            var ShuChuShiJiZhiObj = document.getElementById(ShuChuShiJiZhiID);
            if (ShuChuShiJiZhiObj != null) {
                ShuChuShiJiZhi = ShuChuShiJiZhiObj.value;
            }
        }
        if (ShuChuShiJiZhi == "NaN") {
            ShuChuShiJiZhi = "";
        }



        //显示值单位属性名称或者输出实际值单位属性名称  
        var ShuChuShiJiZhiDanWei = "";
        if (JiSuanBuQueDingDuPara.ShuChuShiJiZhiDanWei != null && JiSuanBuQueDingDuPara.ShuChuShiJiZhiDanWei.trim() != "" && JiSuanBuQueDingDuPara.ShuChuShiJiZhiDanWei != "undefined") {
            var ShuChuShiJiZhiDanWeiID = JiSuanBuQueDingDuPara.ShuChuShiJiZhiDanWei + id;
            var ShuChuShiJiZhiDanWeiObj = document.getElementById(ShuChuShiJiZhiDanWeiID);
            if (ShuChuShiJiZhiDanWeiObj != null) {
                ShuChuShiJiZhiDanWei = ShuChuShiJiZhiDanWeiObj.value;
            }
        }
        if (ShuChuShiJiZhiDanWei == "NaN") {
            ShuChuShiJiZhiDanWei = "";
        }

        //量程属性名称
        var LiangCheng = "";
        if (JiSuanBuQueDingDuPara.LiangCheng != null && JiSuanBuQueDingDuPara.LiangCheng.trim() != "" && JiSuanBuQueDingDuPara.LiangCheng != "undefined") {

            var LiangChengID = JiSuanBuQueDingDuPara.LiangCheng + "_" + tongDaoID + "_" + liangChengID;
            var LiangChengObj = document.getElementById(LiangChengID);
            if (LiangChengObj != null) {
                LiangCheng = LiangChengObj.value;
            }
            else {
                LiangChengID = JiSuanBuQueDingDuPara.LiangCheng + "_" + tongDaoID + "_" + liangChengID + "_1";
                LiangChengObj = document.getElementById(LiangChengID);
                if (LiangChengObj != null) {
                    LiangCheng = LiangChengObj.value;
                }
                else {
                    LiangChengID = JiSuanBuQueDingDuPara.LiangCheng + id;
                    LiangChengObj = document.getElementById(LiangChengID);
                    if (LiangChengObj != null) {
                        LiangCheng = LiangChengObj.value;
                    }
                }
            }
        }
        if (LiangCheng == "NaN") {
            LiangCheng = "";
        }

        //量程单位
        var LiangChengDanWei = "";
        if (JiSuanBuQueDingDuPara.LiangCheng != null && JiSuanBuQueDingDuPara.LiangCheng.trim() != "" && JiSuanBuQueDingDuPara.LiangCheng != "undefined") {

            var LiangChengDanWeiID = JiSuanBuQueDingDuPara.LiangCheng + "_UNIT_" + tongDaoID + "_" + liangChengID;
            var LiangChengDanWeiObj = document.getElementById(LiangChengDanWeiID);
            if (LiangChengDanWeiObj != null) {
                LiangChengDanWei = LiangChengDanWeiObj.value;
            }
            else {
                LiangChengDanWeiID = JiSuanBuQueDingDuPara.LiangCheng + "_UNIT_" + tongDaoID + "_" + liangChengID + "_1";
                LiangChengDanWeiObj = document.getElementById(LiangChengDanWeiID);
                if (LiangChengDanWeiObj != null) {
                    LiangChengDanWei = LiangChengDanWeiObj.value;
                }
                else {
                    LiangChengDanWeiID = JiSuanBuQueDingDuPara.LiangCheng + id;
                    LiangChengDanWeiObj = document.getElementById(LiangChengDanWeiID);
                    if (LiangChengDanWeiObj != null) {
                        LiangChengDanWei = LiangChengDanWeiObj.value;
                    }
                }
            }
        }
        if (LiangChengDanWei == "NaN") {
            LiangChengDanWei = "";
        }


        //K
        var K = "";
        if (JiSuanBuQueDingDuPara.K != null && JiSuanBuQueDingDuPara.K.trim() != "" && JiSuanBuQueDingDuPara.K != "undefined") {

            var KID = JiSuanBuQueDingDuPara.K + "_" + tongDaoID + "_" + liangChengID;
            var KObj = document.getElementById(KID);
            if (KObj != null) {
                K = KObj.value;
            }
            else {
                KID = JiSuanBuQueDingDuPara.K + "_" + tongDaoID + "_" + liangChengID + "_1";
                KObj = document.getElementById(KID);
                if (KObj != null) {
                    K = KObj.value;
                }
                else {
                    KID = JiSuanBuQueDingDuPara.K + "_" + tongDaoID + "_1_1";
                    KObj = document.getElementById(KID);
                    if (KObj != null) {
                        K = KObj.value;
                    }
                }
            }
        }
        if (K == "NaN") {
            K = "";
        }

        //选用电阻属性名称
        var XuanYongDianZu = "";
        if (JiSuanBuQueDingDuPara.XuanYongDianZu != null && JiSuanBuQueDingDuPara.XuanYongDianZu.trim() != "" && JiSuanBuQueDingDuPara.XuanYongDianZu != "undefined") {

            var XuanYongDianZuID = JiSuanBuQueDingDuPara.XuanYongDianZu + "_" + tongDaoID + "_" + liangChengID;
            var XuanYongDianZuObj = document.getElementById(XuanYongDianZuID);
            if (XuanYongDianZuObj != null) {
                XuanYongDianZu = XuanYongDianZuObj.value;
            }
            else {
                XuanYongDianZuID = JiSuanBuQueDingDuPara.XuanYongDianZu + "_" + tongDaoID + "_" + liangChengID + "_1";
                XuanYongDianZuObj = document.getElementById(XuanYongDianZuID);
                if (XuanYongDianZuObj != null) {
                    XuanYongDianZu = XuanYongDianZuObj.value;
                }
                else {
                    XuanYongDianZuID = JiSuanBuQueDingDuPara.XuanYongDianZu + id;
                    XuanYongDianZuObj = document.getElementById(XuanYongDianZuID);
                    if (XuanYongDianZuObj != null) {
                        XuanYongDianZu = XuanYongDianZuObj.value;
                    }
                }
            }
        }
        if (XuanYongDianZu == "NaN") {
            XuanYongDianZu = "";
        }

        //选用电阻单位属性名称
        var XuanYongDianZuDanWei = "";
        if (JiSuanBuQueDingDuPara.XuanYongDianZu != null && JiSuanBuQueDingDuPara.XuanYongDianZu.trim() != "" && JiSuanBuQueDingDuPara.XuanYongDianZu != "undefined") {

            var XuanYongDianZuDanWeiID = JiSuanBuQueDingDuPara.XuanYongDianZu + "_UNIT_" + tongDaoID + "_" + liangChengID;
            var XuanYongDianZuDanWeiObj = document.getElementById(XuanYongDianZuDanWeiID);
            if (XuanYongDianZuDanWeiObj != null) {
                XuanYongDianZuDanWei = XuanYongDianZuDanWeiObj.value;
            }
            else {
                XuanYongDianZuDanWeiID = JiSuanBuQueDingDuPara.XuanYongDianZu + "_UNIT_" + tongDaoID + "_" + liangChengID + "_1";
                XuanYongDianZuDanWeiObj = document.getElementById(XuanYongDianZuDanWeiID);
                if (XuanYongDianZuDanWeiObj != null) {
                    XuanYongDianZuDanWei = XuanYongDianZuDanWeiObj.value;
                }
                else {
                    XuanYongDianZuDanWeiID = JiSuanBuQueDingDuPara.XuanYongDianZu + "_UNIT" + id;
                    XuanYongDianZuDanWeiObj = document.getElementById(XuanYongDianZuDanWeiID);
                    if (XuanYongDianZuDanWeiObj != null) {
                        XuanYongDianZuDanWei = XuanYongDianZuDanWeiObj.value;
                    }
                }
            }
        }
        if (XuanYongDianZuDanWei == "NaN") {
            XuanYongDianZuDanWei = "";
        }

        //输出示值、标准值属性名称
        var ShuChuShiZhi = "";
        if (JiSuanBuQueDingDuPara.ShuChuShiZhi != null && JiSuanBuQueDingDuPara.ShuChuShiZhi.trim() != "" && JiSuanBuQueDingDuPara.ShuChuShiZhi != "undefined") {

            var ShuChuShiZhiID = JiSuanBuQueDingDuPara.ShuChuShiZhi + id;
            var ShuChuShiZhiObj = document.getElementById(ShuChuShiZhiID);
            if (ShuChuShiZhiObj != null) {
                ShuChuShiZhi = ShuChuShiZhiObj.value;
            }
        }
        if (ShuChuShiZhi == "NaN") {
            ShuChuShiZhi = "";
        }

        //输出示值单位、标准值单位属性名称
        var ShuChuShiZhiDanWei = "";
        if (JiSuanBuQueDingDuPara.ShuChuShiZhi != null && JiSuanBuQueDingDuPara.ShuChuShiZhi.trim() != "" && JiSuanBuQueDingDuPara.ShuChuShiZhi != "undefined") {

            var ShuChuShiZhiDanWeiID = JiSuanBuQueDingDuPara.ShuChuShiZhi + "_UNIT" + id;
            var ShuChuShiZhiDanWeiObj = document.getElementById(ShuChuShiZhiDanWeiID);
            if (ShuChuShiZhiDanWeiObj != null) {
                ShuChuShiZhiDanWei = ShuChuShiZhiDanWeiObj.value;
            }
        }
        if (ShuChuShiZhiDanWei == "NaN") {
            ShuChuShiZhiDanWei = "";
        }

        //频率属性名称
        var PinLv = "";
        if (JiSuanBuQueDingDuPara.PinLv != null && JiSuanBuQueDingDuPara.PinLv.trim() != "" && JiSuanBuQueDingDuPara.PinLv != "undefined") {

            var PinLvID = JiSuanBuQueDingDuPara.PinLv + id;
            var PinLvObj = document.getElementById(PinLvID);
            if (PinLvObj != null) {
                PinLv = PinLvObj.value;
            }
        }
        if (PinLv == "NaN") {
            PinLv = "";
        }

        //频率单位属性名称
        var PinLvDanWei = "";
        if (JiSuanBuQueDingDuPara.PinLv != null && JiSuanBuQueDingDuPara.PinLv.trim() != "" && JiSuanBuQueDingDuPara.PinLv != "undefined") {

            var PinLvDanWeiID = JiSuanBuQueDingDuPara.PinLv + "_UNIT" + id;
            var PinLvDanWeiObj = document.getElementById(PinLvDanWeiID);
            if (PinLvDanWeiObj != null) {
                PinLvDanWei = PinLvDanWeiObj.value;
            }
        }
        if (PinLvDanWei == "NaN") {
            PinLvDanWei = "";
        }

        //获取空对象用于保存添加的信息
        $.ajax({
            type: 'post', //使用post方法访问后台
            dataType: "json", //返回json格式的数据
            url: '/PROJECTTEMPLET/GetSuanBuQueDingDu', //要访问的后台地址
            contentType: 'application/x-www-form-urlencoded; charset=utf-8', //指定编码方式
            data: { 'RuleID': RuleID, 'ShuChuShiJiZhi': ShuChuShiJiZhi, 'ShuChuShiJiZhiDanWei': ShuChuShiJiZhiDanWei, 'LiangCheng': LiangCheng, 'LiangChengDanWei': LiangChengDanWei, 'K': K, 'XuanYongDianZu': XuanYongDianZu, 'XuanYongDianZuDanWei': XuanYongDianZuDanWei, 'ShuChuShiZhi': ShuChuShiZhi, 'ShuChuShiZhiDanWei': ShuChuShiZhiDanWei, 'PinLv': PinLv, 'PinLvDanWei': PinLvDanWei },
            //data: { 'RuleID': RuleID },
            beforeSend: function () {
                //InitAlertJS();
            },
            complete: function () {
            }, //AJAX请求完成时隐藏loading提示

            success: function (res) {//msg为返回的数据，在这里做数据绑定
                if (res.Code == 1) {
                    ShowBuQueDingDuObj.value = res.Message;
                    var BuQueDingDuZhiID = "BuQueDingDuZhi" + "_" + ShowBuQueDingDuID;//不确定度原始值隐藏控件                   

                    var BuQueDingDuZhiObj = document.getElementById(BuQueDingDuZhiID);
                    if (BuQueDingDuZhiObj != null) {
                        BuQueDingDuZhiObj.value = res.Message;
                        JiSuanBuQueDingDuByType(BuQueDingDuZhiID, ShowBuQueDingDuID);
                    }
                    else {
                        JiSuanBuQueDingDuByType(ShowBuQueDingDuID, ShowBuQueDingDuID);
                    }

                }
                else {
                    //$.messager.alert('操作提示', res.Message, 'info');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $.messager.alert('操作提示', '操作失败!' + errorThrown.messager, 'warning');
            }
        });
    }




}
//获取不确定度设置详情
function GetJiSuanBuQueDingDuParaArray() {
    var JiSuanBuQueDingDuParaArray = new Array;

    JiSuanBuQueDingDuParaArray.Type = "";//不确定度计算方式
    var AttributeValue = GetAttributeValue("JiSuanBuQueDingDu");
    if (AttributeValue == null || AttributeValue.trim() == "") {
        return JiSuanBuQueDingDuParaArray;
    }
    var type = AttributeValue.split(":")[0].trim().toUpperCase();
    if (type != "A" && type != "Z" && AttributeValue.split(":").length < 2) {
        return JiSuanBuQueDingDuParaArray;
    }

    if (AttributeValue.split(":").length < 2) {
        return JiSuanBuQueDingDuParaArray;
    }
    else if (AttributeValue.split(":")[1].split("|") < 1) {
        return JiSuanBuQueDingDuParaArray;
    }
    else {
        JiSuanBuQueDingDuParaArray.Name = AttributeValue.split(":")[1].split("|")[0];//不确定文本框名称
    }
    JiSuanBuQueDingDuParaArray.Type = type;
    if (type == "Z" && AttributeValue.split("|")[1].length > 1 && AttributeValue.split("|")[1].split(";").length >= "6") {
        //检测项属性名称后需要加自动或者按钮不确定计算
        //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称)
        //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
        //例如：显示值属性名称;量程属性名称;K属性名称;;
        //按钮计算不确定(A:检测项属性名称)

        var pArray = AttributeValue.split("|")[1].split(";");
        JiSuanBuQueDingDuParaArray.ShuChuShiJiZhi = pArray[0];//显示值属性名称或者输出实际值属性名称
        JiSuanBuQueDingDuParaArray.ShuChuShiJiZhiDanWei = pArray[0] + "_UNIT";//显示值单位属性名称或者输出实际值单位属性名称
        JiSuanBuQueDingDuParaArray.LiangCheng = pArray[1];//量程属性名称
        JiSuanBuQueDingDuParaArray.K = pArray[2];//量程属性名称
        JiSuanBuQueDingDuParaArray.XuanYongDianZu = pArray[3];//选用电阻属性名称
        JiSuanBuQueDingDuParaArray.ShuChuShiZhi = pArray[4];//输出示值、标准值属性名称
        JiSuanBuQueDingDuParaArray.PinLv = pArray[5];//频率属性名称
    }
    else if (type == "Z") {
        JiSuanBuQueDingDuParaArray.Type = "";
    }
    return JiSuanBuQueDingDuParaArray;
}

//获取每行不确定度按钮
//Name：不确定度按钮所在某检测项控件名称后
function GetJiSuanBuQueDingDuType(Name) {
    var Result = ""
    if (Name == null || Name.trim() == "") {
        return "";
    }
    var AttributeValue = GetAttributeValue("JiSuanBuQueDingDu");
    if (AttributeValue == null || AttributeValue.trim() == "") {
        return "";
    }
    var type = AttributeValue.split(":")[0].trim().toUpperCase();
    if (type != "A" && type != "Z" && AttributeValue.split(":").length < 2) {
        return "";
    }
    if (type == "Z" && JiSuanBuQueDingDuParaArray != null && JiSuanBuQueDingDuParaArray.length == 0) {
        debugger
        if (AttributeValue.split("|")[1].length > 1 && AttributeValue.split("|")[1].split(";").length >= "4") {

            //检测项属性名称后需要加自动或者按钮不确定计算
            //自动计算不确定(Z:检测项属性名称|显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称)
            //自动计算不确定度中的显示值属性名称或者输出实际值属性名称;量程属性名称;K属性名称;选用电阻属性名称，如果对应的属性可以为空，但顺序不能变并且个数不能变
            //例如：显示值属性名称;量程属性名称;K属性名称;;
            //按钮计算不确定(A:检测项属性名称)

            var pArray = AttributeValue.split("|")[1].split(";");
            JiSuanBuQueDingDuParaArray.ShuChuShiJiZhi = pArray[0];
            JiSuanBuQueDingDuParaArray.ShuChuShiJiZhiDanWei = pArray[0] + "_UNIT";
            JiSuanBuQueDingDuParaArray.LiangCheng = pArray[1];
            JiSuanBuQueDingDuParaArray.K = pArray[2];
            JiSuanBuQueDingDuParaArray.XuanYongDianZu = pArray[3];
        }
        else {
            return "";
        }

    }
    AttributeValue = AttributeValue.split(":")[1];
    var objArray = AttributeValue.split(',');
    var NameNew = Name;
    NameNew = NameNew.toUpperCase();
    $.each(objArray, function (i, item) {
        if (item == null || item.trim() == "" || item.toUpperCase().indexOf(NameNew) < 0) {
            return true;
        }
        Result = type;
        return false;

    });
    return Result;
}

//获取下拉框单位html
//RuleAttribute:检测项属性
//ddlName:检查项中的属性控件名称
//DanWeiCode:单位代码（如果有值直接取，RuleAttribute、ddlName失效)
function GetDanWeiDDLHtml(ddlName, DanWeiCode) {

    var Result = null;

    if (DanWeiCode != null && DanWeiCode.trim() != "") {
        //如果有有单位代码直接取，RuleAttribute、ddlName失效
        $.each(DanWeiDDLHtmlArray, function (i, item) {
            if (item == null || item.Code != DanWeiCode) {
                return true;
            }
            Result = item.Value;
            return false;
        });
        return Result;
    }

    if (ddlName == null || ddlName.trim() == "") {
        return "";
    }
    var AttributeValue = GetAttributeValue("DanWeiHtmlDDL");
    if (AttributeValue == null || AttributeValue.trim() == "") {
        return "";
    }
    var ddlArray = AttributeValue.split(';');
    var ddlNameNew = ddlName;
    ddlNameNew = ddlNameNew.toUpperCase();
    $.each(ddlArray, function (i, item) {
        if (item == null || item.trim() == "" || item.toUpperCase().indexOf(ddlNameNew) < 0 || item.split('|').length < 2) {
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
//classstyle样式类名
//unit在输入框后面的单位
//blurValue数表离开输入框之后触发的事件
function SetTDHtml(rowspan, name, id, rowidx, txtVal, classstyle, unit, blurValue, selectCode) {

    
    //下拉框
    var ddlName = name + "_UNIT";//下拉框名
    var ddlId = ddlName + "_" + id;//下拉框ID    

    var id = name + "_" + id;//输入框id

    //不确定度(隐藏域中存储不确定计算过程html路径)
    var BuQueDingDuLuJingName = "BuQueDingDuLuJing";//不确定度名
    var BuQueDingDuLuJingId = BuQueDingDuLuJingName + "_" + id;//不确定度ID

    //不确定度(隐藏域中存储不确定原始值)
    var BuQueDingDuZhiName = "BuQueDingDuZhi";//不确定度名
    var BuQueDingDuZhiId = BuQueDingDuZhiName + "_" + id;//不确定度ID

    var ddlHtml = GetDanWeiDDLHtml(name, null);//单位下拉框html
    if ((txtVal == null || txtVal.trim() == "") && rowidx != null) {
        txtVal = CalculateForAddLianCheng(rowidx, name);
    }
    if ((classstyle == null || classstyle.trim() == "")) {
        classstyle = 'classstyle';
    }
    var htmlString = [];
    htmlString.push("<td class='" + classstyle + "' rowspan='" + rowspan + "' align='center' > ");
    //增加下拉框类型
    if (selectCode != null && selectCode.trim() != "") {
        var selectHtml = GetDanWeiDDLHtml(name, selectCode);//单位下拉框html
        if (blurValue != null && blurValue.trim() != "") {
            htmlString.push($(selectHtml).attr("onchange", blurValue + "(this)").attr("name", name).attr("id", id)[0].outerHTML);
        } else {
            htmlString.push($(selectHtml).attr("name", name).attr("id", id)[0].outerHTML);
        }
    } else {
        if (blurValue != null && blurValue.trim() != "") {
            htmlString.push("<input type='text' class=\"my-textbox input-width\" value='" + txtVal + "' id='" + id + "' name='" + name + "' onblur='" + blurValue + "(this);LianDongBuQueDingDu(this);'/>");

        } else {
            htmlString.push("<input type='text' class=\"my-textbox input-width\" value='" + txtVal + "' id='" + id + "' name='" + name + "' onblur='LianDongBuQueDingDu(this);'/>");

        }
    }
    if (ddlHtml != null && ddlHtml.trim() != "") {
        var AttributeValue = GetAttributeValue("LianDongDanWeiDDL");

        htmlString.push($(ddlHtml).attr("onchange", "LianDongDanWeiDDL(this,'" + AttributeValue + "')").attr("name", ddlName).attr("id", ddlId)[0].outerHTML);
    }
    if (unit) {
        htmlString.push(unit);
    }

    //不确定度
    //var JiSuanBuQueDingDuType = GetJiSuanBuQueDingDuType(name);    

    if (JiSuanBuQueDingDuPara.Type != null && JiSuanBuQueDingDuPara.Type.trim() != "" && JiSuanBuQueDingDuPara.Name == name) {

        htmlString.push("<input type='hidden' name='" + BuQueDingDuZhiName + "' id='" + BuQueDingDuZhiId + "' value=''/>");
        if (JiSuanBuQueDingDuPara.Type == "A") {//按钮计算不确定度
            htmlString.push("<input type='hidden' name='" + BuQueDingDuLuJingName + "' id='" + BuQueDingDuLuJingId + "' value=''/>");
            var returnIds = BuQueDingDuZhiId + "&" + BuQueDingDuLuJingId + "^" + BuQueDingDuLuJingId + "^" + id;
            htmlString.push("<a href=\"#\" name=\"btnBuQueDing\" class=\"my-linkbutton\" onclick = \"showModal('" + returnIds + "', '/PROJECTTEMPLET/JiSuanBuQueDingDu?ID=" + id + "&RuleID=" + RuleID + "');\">计算</a>")
        }
        //else if (JiSuanBuQueDingDuPara.Type == "Z")//每行自动计算不确定度
        //{

        //}
    }
    htmlString.push("</td>");
    return htmlString.join("");


}
//底部不确定计算
function JiSuanBuQueDingDu_DiBu(obj) {
    if (obj != null && obj.id != "undefined") {
        var id = obj.id;
        id = id.substring(id.indexOf('_') + 1);
        var BuQueDingDuLuJingId = "BuQueDingDuLuJing_" + id; //不确定度(隐藏域中存储不确定计算过程html路径)
        var BuQueDingDuZhiId = "BuQueDingDuZhi_" + id;//不确定度(隐藏域中存储不确定原始值)
        var returnIds = BuQueDingDuZhiId + "&" + BuQueDingDuLuJingId + "^" + BuQueDingDuLuJingId + "^" + id;
        showModal(returnIds, "/PROJECTTEMPLET/JiSuanBuQueDingDu?ID=" + id + "&RuleID=" + RuleID);


    }

}

//添加底部不确定度行
function addBuQueDingRow() {
    var tr = $('#tbodyBuQueDingDuD_2').find('tr:last').clone();
    $('input', tr).each(function () {
        if (this.name != "" && this.id != "" && this.id.lastIndexOf("_") >= 0) {
            var num = (parseInt(this.id.substring(this.id.lastIndexOf("_") + 1)) + 1);
            var id = this.id.substring(0, this.id.lastIndexOf("_")) + "_" + num;
            $(this).attr('id', id);
        }
        //if (this.name != "btn_txtvalueD") {
        //    $(this).val("");
        //}
    });
    $('select', tr).each(function () {
        if (this.name != "" && this.id != "" && this.id.lastIndexOf("_") >= 0) {
            var num = (parseInt(this.id.substring(this.id.lastIndexOf("_") + 1)) + 1);
            var id = this.id.substring(0, this.id.lastIndexOf("_")) + "_" + num;
            $(this).attr('id', id);
        }
    });
    $("#tbodyBuQueDingDuD_2").append(tr);

}
//修改不确定度展示方式及小数位数联动不确定度
function ChangeBuQueDingDuShowTypeOrBuQueDingDuXiaoShuWeiShu() {
    $("input[name='BuQueDingDuZhi']").each(function () {
        //除了隐藏模板中的输入框，其他所有的输入框
        if (this.id != "") {
            var ShowBuQueDingDuId = this.id.replace(this.name + "_", "");
            JiSuanBuQueDingDuByType(this.id, ShowBuQueDingDuId);
        }
    });
}
//根据不确定展示类型计算不确定值
//BuQueDingDuZhiId:不确定度原始值控件Id
//ShowBuQueDingDuId:不确定度展示控件Id
function JiSuanBuQueDingDuByType(BuQueDingDuZhiId, ShowBuQueDingDuId) {
    var type = $("#ddlBuQueDingDuShowType").val();
    var pos = $("#BuQueDingDuXiaoShuWeiShu").val();

    var BuQueDingDuZhi = document.getElementById(BuQueDingDuZhiId);
    var ShowBuQueDingDu = document.getElementById(ShowBuQueDingDuId);
    if (BuQueDingDuZhi == null || ShowBuQueDingDu == null) {
        return;
    }
    if (BuQueDingDuZhi.value.trim() == "") {
        BuQueDingDuZhi.value = ShowBuQueDingDu.value;
    }
    if (BuQueDingDuZhi.value.trim() == "") {
        ShowBuQueDingDu.value = "";
        return;
    }
    if (type == "B")//百分比模式
    {
        ShowBuQueDingDu.value = percentages(BuQueDingDuZhi.value, pos);
    }
    else if (type == "K")//科学计算法模式
    {
        ShowBuQueDingDu.value = kexue(BuQueDingDuZhi.value, pos);
    }
    else//原始模式
    {
        ShowBuQueDingDu.value = zeroFloat(BuQueDingDuZhi.value, pos);
    }
}
//弹计算不确定过程框
function showModal(me, url) { //弹出窗体
    var constrols = null;
    var BuQueDingDuLuJing = null;
    var BuQueDingDuZhiId = "";
    var ShowBuQueDingDuId = "";
    if (me != null && me.trim() != "")//回填控件id
    {
        constrols = me.split("^")[0].split("&");
        BuQueDingDuZhiId = constrols[0];

        if (me.split("^").length > 1) {
            BuQueDingDuLuJing = me.split("^")[1];
            var BuQueDingDuLuJingObj = document.getElementById(BuQueDingDuLuJing);
            if (BuQueDingDuLuJingObj != null) {
                url += "&URL=" + BuQueDingDuLuJingObj.value;
            }
        }
        if (me.split("^").length > 2) {
            ShowBuQueDingDuId = me.split("^")[2];
        }
    }
    var reValue = window.showModalDialog(url, window, "dialogHeight:500px; dialogWidth:987px;  status:off; scroll:auto");

    if (reValue == null || reValue == "undefined" || reValue == "") {
        return; //如果返回值为空，就返回
    }
    else {
        var reValues = reValue.split("&");
        for (var i = 0; i < constrols.length; i++) {
            if (reValues.length - 1 >= i) {
                var constrol = document.getElementById(constrols[i]);
                if (constrol != null) {
                    constrol.value = reValues[i];
                }
            }
        }
        JiSuanBuQueDingDuByType(BuQueDingDuZhiId, ShowBuQueDingDuId);
    }
    return;
}
//根据属性名获取属性值
//RuleAttribute：检查项属性对象
//Name:属性名称
function GetAttributeValue(Name) {
    if (RuleAttribute == null || Name == null || Name.trim() == "" ||
       RuleAttribute.Attributes == null || RuleAttribute.Attributes[0] == null || RuleAttribute.Attributes[0][Name] == null
       || RuleAttribute.Attributes[0][Name].trim() == ""
        ) {
        return "";
    }
    return RuleAttribute.Attributes[0][Name].trim();
}
//清空不需要保存的数据
function ClearBuBaoCunShuJu() {

    var AttributeValue = GetAttributeValue("BuBaoCunShuJu");
    if (AttributeValue != null && AttributeValue.trim() != "") {
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
function CalculateForAddLianCheng(Rowidx, objName) {
    if (RuleAttribute == null || Rowidx == null) {
        return "";
    }
    var AttributeValue = GetAttributeValue("CalculateForAddLianCheng");
    if (AttributeValue == null || AttributeValue.trim() == "") {
        return "";
    }
    if (AttributeValue.indexOf(objName) < 0) {
        return "";
    }
    var number = $("#txtNumber").val(); //量程
    var point = $("#txtPoint").val();     //检测点数   
    var pointLen = $("#txtPointLen").val(); //小数点位数
    if (number == "" || pointLen == "" || point == "") {
        return "";
    }
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
    if (arry != null && arry.length > Rowidx) {
        return arry[Rowidx];
    }
    return "";
}

//优化保留两位小数 四舍五入
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
function ShowOrHideDuoTongDao() {

    if (RuleAttribute == null) {
        $("#btnDuoTongDao").hide();
    }
    else {
        var AttributeValue = GetAttributeValue("DuoTongDao");
        if (AttributeValue != null && AttributeValue.trim().toUpperCase() == "SHOW") {
            $("#btnDuoTongDao").show();
        }
        else {
            $("#btnDuoTongDao").hide();
        }
    }
}
//显示隐藏底部不确定部分
function ShowOrHideDiBuBuQueDingDu() {
    if (RuleAttribute == null) {
        $("#tbBuQueDingDuD").remove();
        $("#tbBuQueDingDuG").remove();
    }
    else {


        var AttributeValue = GetAttributeValue("JiSuanBuQueDingDu_DiBu")
        if (AttributeValue != null && AttributeValue.trim().toUpperCase() == "D") {//动态添加
            $("#tbBuQueDingDuD").show();
            $("#tbBuQueDingDuG").remove();
        }
        else if (AttributeValue != null && AttributeValue.trim().toUpperCase() == "G") {//固定两行
            $("#tbBuQueDingDuD").remove();
            $("#tbBuQueDingDuG").show();
        }
        else {
            $("#tbBuQueDingDuD").remove();
            $("#tbBuQueDingDuG").remove();
        }
    }
}
//按钮初始化（显示、隐藏）
function BtnInit() {
    ShowOrHideDuoTongDao();
    ShowOrHideDiBuBuQueDingDu();
    var PREPARE_SCHEMEID = $("#hidePREPARE_SCHEMEID").val();

    if (PREPARE_SCHEMEID.trim() != "")//数据录入
    {
        //$("#btnDuoTongDao").hide();
        ////$("#btnSave").hide();
        //$("#btnReset").hide();
        //$("#btnAddLiangCheng").hide();
        ////$("#btnSave_ITE").show();
        //$("#btnReset_ITE").show();
        $("a").each(function () {
            if (this.id != "btnSave" && this.name != "btnBuQueDing") {
                $(this).hide();
            }
            else {
                $(this).show();
            }
        });

    }
    else//方案设置
    {

        //$("#btnSave").show();
        //$("#btnReset").show();
        //$("#btnSave_ITE").hide();
        //$("#btnReset_ITE").hide();
    }
}
//数据验证
function CheckData() {
    return true;
}

function Save() {
    if (!CheckData()) {
        return;
    }
    var PREPARE_SCHEMEID = $("#hidePREPARE_SCHEMEID").val();//预备方案ID
    if (PREPARE_SCHEMEID.trim() != "")//数据录入
    {
        Save_ShuJuLuRu();
    }
    else//方案设置
    {
        Save_FangAn();
    }
}
//保存数据录入
function Save_ShuJuLuRu() {
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
function SetAllControlHtml() {

    $("input[type='text']").not('#tongdao_moban :input').each(function () {

        //除了隐藏模板中的输入框，其他所有的输入框
        if (this.id != "") {

            if (this.attributes.value != undefined) {
                this.attributes.value.value = $(this).val();
            } else {//如果没有写value属性，则加上
                var value = $(this).val();
                $(this).attr("value", value);
            }


        }
    });

    $("select").not('#tongdao_moban select').each(function () {
        //除了隐藏模板中的下拉框，其他所有的下拉框
        if (this.id != "") {

            var value = $(this).val();
            //清除所有的selected
            $(this).find("option").each(function (i, item) {
                if ($(item).val() == value) {
                    //将选中的value的option设置为selected
                    $(item).attr("selected", true);
                } else {
                    $(item).attr("selected", false);
                }


            }
        );

        }

    });
}
function JS1(thi) {
}


function PointFloat(src, pos) {

    return Math.round(src * Math.pow(10, pos)) / Math.pow(10, pos);
}

//保留小数位数 四舍六入奇进偶舍
function fomatFloat(src, pos) {

    var numArray, resultSymbol = "";
    if (src < 0) {
        resultSymbol = "-";
    }
    if (pos == "undefined" || pos == "") {
        pos = new Number(0);
    }
    src = src.toString().replace("-", "");
    if (src.indexOf('.') > 0) {
        numArray = src.split('.');
        if (numArray[1].length > pos) {
            var endStr, isCarry = false;
            if (numArray[1].length > parseFloat(pos) + 1) {
                endStr = numArray[1].substring(parseFloat(pos) + 1);
                for (var i = 0; i < endStr.length; i++) {
                    if (endStr[i] > 0) {
                        isCarry = true;
                        break;
                    }
                }
            }
            numArray[1] = numArray[1].substring(0, pos + 1);
            var endChar = numArray[1][pos];
            var newpoint = new Number("0." + numArray[1].substring(0, pos));
            if (endChar >= 5 && pos >= 0) {
                if (endChar > 5) {
                    if (pos == 0) {
                        numArray[1] = 1;
                    }
                    else {
                        numArray[1] = parseFloat(newpoint) + parseFloat(Math.pow(0.1, pos));
                    }
                }
                else if (endChar == 5) {
                    //5后面有有效数字，直接向前进一位
                    if (isCarry) {
                        numArray[1] = parseFloat(newpoint) + parseFloat(Math.pow(0.1, pos));
                        return PointFloat(resultSymbol + eval(numArray.join("+")), pos);
                    }
                    if (pos == 0) {
                        if (numArray[0] % 2 != 0) {
                            numArray[1] = 1;
                        } else {
                            numArray[1] = 0;
                        }
                        return PointFloat(resultSymbol + eval(numArray.join("+")), pos);
                    }
                    var preChar = numArray[1][pos - 1];
                    if (preChar % 2 == 0) {
                        numArray[1] = newpoint;
                    }
                    else {
                        numArray[1] = parseFloat(newpoint) + parseFloat(Math.pow(0.1, pos));
                    }
                }
                return PointFloat(resultSymbol + eval(numArray.join("+")), pos);
            }
            else {
                numArray[1] = newpoint;
                return PointFloat(resultSymbol + eval(numArray.join("+")), pos);
            }
        }
        return resultSymbol + src;

    } else {
        return resultSymbol + src;
    }

}
$(function () {
    ////
    //debugger
    //var dsa = kexue(3.504501, 3);
    //var dsa1 = kexue(35.04501, 3);
    //var dsa2 = kexue(0.3504501, 3);
    //var dsa4 = kexue(-0.03504501, 3);
    //var dsa15 = kexue(-35.04501, 3);
    //var dsa26 = kexue(-3504.501, 3);

    //var gf = (round2(3.504501, 3));
    //var ewgf = (round2(9.8249, 3));

});

//科学技术法
//pos保留的小数位数，不足的位数补零
function kexue(src, pos) {
    if (pos == "undefined" || pos == "") {

        return;
    }
    var resultSymbol = "";
    if (src < 0) {
        resultSymbol = "-";
    }
    src = src.toString().replace("-", "");
    var zero = "";
    for (var i = 0; i < pos; i++) {
        zero += "0";
    }

    var p = Math.floor(Math.log(src) / Math.LN10);
    var n = src * Math.pow(10, -p);

    n = numeral(n).format('0.' + zero);
    var str = '*10'
    if (p >= 0) {
        str += "+";
    }
    return resultSymbol + n + str + p;

    //return numeral(src).format('0.' + zero + 'e+0');//'0.000e+0'

}
//小数变成百分比
//pos保留的小数位数，不足的位数补零
function percentages(src, pos) {
    if (pos == "undefined" || pos == "") {

        return;
    }
    var zero = "";
    for (var i = 0; i < pos; i++) {
        zero += "0";
    }

    return numeral(src).format('0.' + zero + '%');//'(0.000 %)'

}
//小数位数不够的时候补足零
function zeroFloat(src, pos) {
    if (pos == "undefined" || pos == "") {

        return;
    }
    var zero = "";
    for (var i = 0; i < pos; i++) {
        zero += "0";
    }

    return numeral(src).format('0.' + zero);

}

//【平均值】=（上升+下降）/2
//obj 自身对象
//first 第一列的值
//second 第二列的值
//gold 平均值
function getAverage(obj, first, second, gold) {
    var r1, r2,n;
    try { r1 = first.toString().split(".")[1].length } catch (e) { r1 = 0 }
    try { r2 = second.toString().split(".")[1].length } catch (e) { r2 = 0 }
    //last modify by deeka
    //动态控制精度长度
    n = (r1 >= r2) ? r1 : r2;
    var jianfa1 = accDiv(accAdd(first, second), 2);
    if (n != 0)
    {
        var jianfa1 = zeroFloat(fomatFloat(jianfa1, n), n);
    }
    $(obj).parent().parent().find("#" + gold).val(jianfa1);
}
//相对误差
//obj 自身对象
//first 第一列的值，做分母第一位
//second 第二列的值，做分子
//gold 误差列
function xiangDuiWuCha(obj, first, second, gold) {

    wuCha(obj, first, second, first, gold);
}
//通用的误差算法
//obj 自身对象
//first 第一列的值，做分母第一位
//second 第二列的值，做分母第二位
//third 第三列的值，做分子
//gold 误差列
function wuCha(obj, first, second, third, gold) {
    //重新计算当前行
    var name = $(obj).attr("name");
    var id = $(obj).attr("id");
    id = id.substring(id.indexOf('_'));

    first = first + id;//改动的地方，参与计算的列的name值
    second = second + id;//改动的地方，参与计算的列的name值
    third = third + id;
    gold = gold + id;//改动的地方，误差的列的name值

    var firstData = $(obj).parent().parent().find("#" + first).val();
    var secondData = $(obj).parent().parent().find("#" + second).val();
    var thirdData = $(obj).parent().parent().find("#" + third).val();
    if (firstData != "undefined" && secondData != "undefined" && firstData != "" && thirdData != "undefined" && thirdData != "" && secondData != "" && thirdData != "0") {
        var txtPointLen = $("#mywuchaxiaoshuweishu").val(); //小数点位数
        
        var jianfa = accDiv(accSub(firstData, secondData), thirdData) * 100;
        var data1 = (fomatFloat(jianfa, txtPointLen), txtPointLen);

        var data = zeroFloat(fomatFloat(jianfa, txtPointLen), txtPointLen);
        $(obj).parent().parent().find("#" + gold).val(data);
    }

}
function wuChaLiangCheng(obj, first, second, third, gold) {
    //重新计算当前行
    var name = $(obj).attr("name");
    var id = $(obj).attr("id");
    id = id.substring(id.indexOf('_'));
    var tongdao = id.split('_')[1];
    var lian = id.split('_')[2];

    first = first + id;//改动的地方，参与计算的列的name值
    second = second + id;//改动的地方，参与计算的列的name值
    third = third + "_" + tongdao + "_" + lian;
    gold = gold + id;//改动的地方，误差的列的name值

    var firstData = $("#" + first).val();
    var secondData = $("#" + second).val();
    var thirdData = $("#" + third).val();
    if (firstData != "undefined" && secondData != "undefined" && firstData != "" && thirdData != "undefined" && thirdData != "" && secondData != "" && thirdData != "0") {
        var txtPointLen = $("#mywuchaxiaoshuweishu").val(); //小数点位数
        //【误差】=（示值-标准值/量程）/10*100，不同的准确度等级小数位数不同，四舍六入，逢五奇进偶不进
     
        var jianfa = accSub(firstData,accDiv(secondData, thirdData)) * 10;
        
        var data = zeroFloat(fomatFloat(jianfa, txtPointLen), txtPointLen);
        $(obj).parent().parent().find("#" + gold).val(data);
    }

}

//绝对误差
//obj 自身对象
//first 第一列的值，做分母第一位
//second 第二列的值，做分子
//gold 误差列
function jueDuiWuCha(obj, first, second, gold) {
    //重新计算当前行
    //重新计算当前行
    var name = $(obj).attr("name");
    var id = $(obj).attr("id");
    id = id.substring(id.indexOf('_'));

    first = first + id;//改动的地方，参与计算的列的name值
    second = second + id;//改动的地方，参与计算的列的name值
    gold = gold + id;//改动的地方，误差的列的name值

    var firstData = $(obj).parent().parent().find("#" + first).val();
    var secondData = $(obj).parent().parent().find("#" + second).val();
    if (firstData != "" && secondData != "") {
        var txtPointLen = $("#mywuchaxiaoshuweishu").val(); //小数点位数
        var jianfa = (accSub(firstData, secondData));
        var baoliu = (jianfa * 1).toFixed(txtPointLen);
        var data = zeroFloat(baoliu, txtPointLen);

        $(obj).parent().parent().find("#" + gold).val(data);
    }

}

//表头单位联动
//自身
//className同一类的类名
function uonchange(thi, className) {

    var checkvalue = $(thi).find("option:selected").val();  //获取Select选择的value  
    $('.' + className + '').each(function () {
        //关联的所有的下拉框                
        $(this).find("option[value='" + checkvalue + "']").attr("selected", true);

    });
}
//相对误差
//obj 自身对象
//first 第一列的值，做分母第一位
//second 第二列的值，做分子
//gold 误差列
function yinYongWuCha(obj, first, second, third, fourth, fifth, gold) {


    //重新计算当前行
    var name = $(obj).attr("name");
    var id = $(obj).attr("id");
    id = id.substring(id.indexOf('_'));
    var tongdao = id.split('_')[1];

    first = first + id;//改动的地方，参与计算的列的name值
    second = second + id;//改动的地方，参与计算的列的name值
    third = third + "_" + tongdao + "_1_1";
    fourth = fourth + "_" + tongdao + "_1_1";
    fifth = fifth + "_" + tongdao + "_1_1";

    gold = gold + id;//改动的地方，误差的列的name值

    var firstData = $("#" + first).val();
    var secondData = $("#" + second).val();
    var thirdData = $("#" + third).val();
    var fourthData = $("#" + fourth).val();
    var fifthData = $("#" + fifth).val();
    if (firstData != "undefined" && secondData != "undefined" && thirdData != "undefined" && fourthData != "undefined" && fifthData != "undefined"
        && firstData != "" && secondData != "" && thirdData != "" && fourthData != "" && fifthData != "") {
        var txtPointLen = $("#mywuchaxiaoshuweishu").val(); //小数点位数
        //引用误差=Round(（实际输出值-标准输出值）/（输出范围的最大值-输出范围的最小值）*100/等级,1)*等级
        var a=accSub(firstData, secondData);
        var b = accSub(thirdData, fourthData);
        var c = accDiv(a, b);
        var d=(accDiv((c * 100), fifthData).toFixed(1));
        var jianfa = accMul(d, fifthData);
        var data = zeroFloat(jianfa, txtPointLen);


        $(obj).parent().parent().find("#" + gold).val(data);
    }


}
///二等标准电阻标称值
//obj 自身对象
//计算值的控件名称
function erDengBiaoChenZhi(obj, targetControlName) {
    var biaochenzhi = $(obj).val();
    if ((biaochenzhi == '10000' || biaochenzhi == '100000') && biaochenzhi != "") {
        $(obj).parent().parent().find("#" + targetControlName).val(biaochenzhi);
    }
}


///实际值Rx
//obj 自身对象
//计算值的控件名称
//rn控件名称
//axv控件名称
//JDDL控件名称
// anv控件名称
//biaoChen控件名称
//目標控件名称
function shiIiZhiRX(obj, rNControlName, axvControlName, JDDLControlName, anvControlName, biaoChenControlName, targetControlName) {
    //重新计算当前行
    var name = $(obj).attr("name");
    var id = $(obj).attr("id");
    id = id.substring(id.indexOf('_'));
    var tongdao = id.split('_')[1];
    var rowidx = id.split('_')[3];

    var rn = rNControlName + "_" + tongdao + "_1" + "_" + rowidx;
    var axv = axvControlName + "_" + tongdao + "_1" + "_" + rowidx;
    var jiandingdianliu = JDDLControlName + "_" + tongdao + "_1" + "_" + rowidx;
    var anv = anvControlName + "_" + tongdao + "_1" + "_" + rowidx;
    var biaochenzhi = biaoChenControlName + "_" + tongdao + "_1" + "_" + rowidx;
    var bcz = $("#" + biaochenzhi).val();
    var targetControlId = targetControlName + "_" + tongdao + "_1" + "_" + rowidx;


    var rnValue = $("#" + rn).val();
    var axvValue = $("#" + axv).val();
    var anvValue = $("#" + anv).val();
    var jiandingValue = $("#" + jiandingdianliu).val();

    var length = 2;
    if (bcz != "" && bcz == "10000")
        length = 1;
    if (bcz != "" && bcz == "100000")
        length = 0;
    if (rnValue != "" && axvValue != "" && jiandingValue != "") {
        var shijizhiRx = (parseFloat(rnValue) + (parseFloat(axvValue) / parseFloat(jiandingValue) - parseFloat(anvValue) / parseFloat(jiandingValue))).toFixed(length);

        $(obj).parent().parent().find("#" + targetControlId).val(shijizhiRx);
    }
}


///贝塞尔公式STDEV
///计算标准偏差
///strData 值逗号隔开
///返回 sd 标准偏差值
function calculate(strData) {
    var x = strData;//getData();
    x = x.replace(' ', '');
    var arr = x.split(',');
    if (arr.length == 1) return false;
    var lcm = 0;
    var flag = false;
    var total = 0;
    for (var j = 0; j < arr.length; j++) {
        arr[j] = parseFloat(arr[j]);
        total += arr[j];
    }
    var mean = total / arr.length;
    mean = Math.round(mean * 100000000000) / 100000000000;
    var xm2 = 0;
    var srt = '';
    var srt1 = '';
    var srt2 = '';
    for (var j = 0; j < arr.length; j++) {
        xm2 += Math.pow((arr[j] - mean), 2);
        if (j == arr.length - 1) {
            srt += '(' + arr[j] + '-' + mean + ')^2';
            srt1 += '(' + (arr[j] - mean) + ')^2';
            srt2 += '(' + Math.pow((arr[j] - mean), 2) + ')';
        } else {
            srt += '(' + arr[j] + '-' + mean + ')^2+';
            srt1 += '(' + (arr[j] - mean) + ')^2+';
            srt2 += '(' + Math.pow((arr[j] - mean), 2) + ')+';
        }
    }
    var sd = xm2 / (arr.length - 1);
    var psd = xm2 / (arr.length);
    var sd1 = sd;
    var psd1 = psd;
    sd = Math.sqrt(sd);
    psd = Math.sqrt(psd);
    var sVariance = Math.pow(sd, 2);
    sVariance = Math.round(sVariance * 1000000) / 1000000;
    var pVariance = Math.pow(psd, 2);
    pVariance = Math.round(pVariance * 10000000) / 10000000;
    sd = Math.round(sd * 1000000000000) / 1000000000000;//标准偏差
    return sd;
    // psd = Math.round(psd * 1000000) / 1000000;


}


//加法函数，用来得到精确的加法结果 
//说明：javascript的加法结果会有误差，在两个浮点数相加的时候会比较明显。这个函数返回较为精确的加法结果。 
//调用：accAdd(arg1,arg2) 
//返回值：arg1加上arg2的精确结果 
function accAdd(arg1, arg2) {
    var r1, r2, m;
    try { r1 = arg1.toString().split(".")[1].length } catch (e) { r1 = 0 }
    try { r2 = arg2.toString().split(".")[1].length } catch (e) { r2 = 0 }
    m = Math.pow(10, Math.max(r1, r2))
    return (arg1 * m + arg2 * m) / m
}
//给Number类型增加一个add方法，调用起来更加方便。 
Number.prototype.add = function (arg) {
    return accAdd(arg, this);
}

//减法函数，用来得到精确的加法结果 
//说明：javascript的加法结果会有误差，在两个浮点数相加的时候会比较明显。这个函数返回较为精确的加法结果。 
//调用：accAdd(arg1,arg2) 
//返回值：arg1加上arg2的精确结果 
function accSub(arg1, arg2) {
    var r1, r2, m, n;
    try { r1 = arg1.toString().split(".")[1].length } catch (e) { r1 = 0 }
    try { r2 = arg2.toString().split(".")[1].length } catch (e) { r2 = 0 }
    m = Math.pow(10, Math.max(r1, r2));
    //last modify by deeka
    //动态控制精度长度
    n = (r1 >= r2) ? r1 : r2;
    return ((arg1 * m - arg2 * m) / m).toFixed(n);
}

//除法函数，用来得到精确的除法结果 
//说明：javascript的除法结果会有误差，在两个浮点数相除的时候会比较明显。这个函数返回较为精确的除法结果。 
//调用：accDiv(arg1,arg2) 
//返回值：arg1除以arg2的精确结果 
function accDiv(arg1, arg2) {
    var t1 = 0, t2 = 0, r1, r2;
    try { t1 = arg1.toString().split(".")[1].length } catch (e) { }
    try { t2 = arg2.toString().split(".")[1].length } catch (e) { }
    with (Math) {
        r1 = Number(arg1.toString().replace(".", ""))
        r2 = Number((arg2).toString().replace(".", ""))
        return (r1 / r2) * pow(10, t2 - t1);
    }
}
//给Number类型增加一个div方法，调用起来更加方便。 
Number.prototype.div = function (arg) {
    return accDiv(this, arg);
}

//乘法函数，用来得到精确的乘法结果 
//说明：javascript的乘法结果会有误差，在两个浮点数相乘的时候会比较明显。这个函数返回较为精确的乘法结果。 
//调用：accMul(arg1,arg2) 
//返回值：arg1乘以arg2的精确结果 
function accMul(arg1, arg2) {
    var m = 0, s1 = arg1.toString(), s2 = arg2.toString();
    try { m += s1.split(".")[1].length } catch (e) { }
    try { m += s2.split(".")[1].length } catch (e) { }
    return Number(s1.replace(".", "")) * Number(s2.replace(".", "")) / Math.pow(10, m)
}
//给Number类型增加一个mul方法，调用起来更加方便。 
Number.prototype.mul = function (arg) {
    return accMul(arg, this);
}

